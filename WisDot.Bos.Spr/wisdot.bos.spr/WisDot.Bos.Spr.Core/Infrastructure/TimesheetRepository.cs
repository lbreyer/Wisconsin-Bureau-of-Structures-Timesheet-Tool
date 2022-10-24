using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using ClosedXML.Excel;
using WisDot.Bos.Spr.Core.Data;
using WisDot.Bos.Spr.Core.Data.Interfaces;
using WisDot.Bos.Spr.Core.Domain.Models;
using WisDot.Bos.Spr.Core.Infrastructure.Interfaces;

namespace WisDot.Bos.Spr.Core.Infrastructure
{
    internal class TimesheetRepository : ITimesheetRepository
    {
        private EmployeeTimesheetQuery query = new EmployeeTimesheetQuery();

        public string GetProgressReportFilePath()
        {
            return query.GetProgressReportFilePath();
        }

        public string GetTimesheetFilePath()
        {
            return query.GetTimesheetFilePath();
        }

        public List<TimesheetEntry> GetTimesheetEntries(int monthOfWeekEndingDate, int yearOfWeekEndingDate)
        {
            List<TimesheetEntry> timesheetEntries = new List<TimesheetEntry>();
            List<IXLRow> tsRows = query.GetTimesheetRows(monthOfWeekEndingDate, yearOfWeekEndingDate);

            if (tsRows.Count > 0)
            {
                var employeeWorksheet = query.GetEmployeeWorksheet();

                foreach (var tsRow in tsRows)
                {
                    DateTime weekEndingDate;

                    try
                    {
                        //weekEndingDate = Convert.ToDateTime(tsRow.Cell("A").Value).AddDays(6);
                        weekEndingDate = DateTime.Parse(tsRow.Cell("A").Value.ToString()).AddDays(6);


                        // Proceed if we have a valid week-ending date

                        TimesheetEntry tsEntry = null;
                        string firstName = tsRow.Cell("B").Value.ToString().Replace(" ", "");
                        string lastName = tsRow.Cell("C").Value.ToString().Replace(" ", "");
                        string nameLookup = String.Format("{0}{1}", lastName.Replace(" ", ""), firstName.Length >= 3 ? firstName.Substring(0, 3) : firstName);

                        // Grab the employee ID from the "Employee" worksheet
                        var matchingRows = employeeWorksheet.RowsUsed(row => row.Cell("D").GetString().ToLower().Equals(lastName.ToLower())
                                                                        && row.Cell("B").GetString().ToLower().StartsWith(firstName.Length >= 3 ? firstName.Substring(0, 3).ToLower() : firstName.ToLower()));

                        if (matchingRows.Count() > 0)
                        {
                            var matchingRow = matchingRows.First();
                            tsEntry = new TimesheetEntry();
                            int employeeId = Convert.ToInt32(matchingRow.Cell("A").Value);
                            tsEntry.EmployeeId = employeeId;
                            tsEntry.EmployeeFirstName = matchingRow.Cell("B").GetString();
                            tsEntry.EmployeeLastName = matchingRow.Cell("D").GetString();
                            tsEntry.StructureId = tsRow.Cell("D").Value.ToString();
                            tsEntry.ProjectId = tsRow.Cell("E").Value.ToString();
                            tsEntry.ActivityCode = Convert.ToInt32(tsRow.Cell("F").Value.ToString().Trim().Substring(0, 3));
                            tsEntry.ActivityDescription = tsRow.Cell("F").Value.ToString().Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                            tsEntry.WeekEndingDate = weekEndingDate;
                            tsEntry.TotalHours = Convert.ToSingle(tsRow.Cell("G").Value);

                            try
                            {
                                tsEntry.TotalHours += Convert.ToSingle(tsRow.Cell("H").Value);
                            }
                            catch { }

                            tsEntry.MonthWeekEndingDate = weekEndingDate.Month;
                            tsEntry.YearWeekEndingDate = weekEndingDate.Year;
                            timesheetEntries.Add(tsEntry);
                        }
                        else
                        {
                            Debug.Print("No matching employee");
                        }

                    }
                    catch (Exception e)
                    {
                        Debug.Print("Error in {0}:\nException: {1}", "GetTimesheets", e.StackTrace.ToString());
                    }
                }
            }

            return timesheetEntries;
        }

        public List<TimesheetEntry> ImportTimesheetEntriesIntoDatabase(int monthOfWeekEndingDate, int yearOfWeekEndingDate)
        {
            List<TimesheetEntry> timesheetEntries = GetTimesheetEntries(monthOfWeekEndingDate, yearOfWeekEndingDate);

            foreach (var tsEntry in timesheetEntries)
            {
                int workNumber = 0;
                string structureId = tsEntry.StructureId;
                string projectId = tsEntry.ProjectId;

                if (!String.IsNullOrEmpty(tsEntry.StructureId) && !String.IsNullOrEmpty(tsEntry.ProjectId))
                {
                    // Structure-specific work
                    workNumber = query.GetWorkNumber(tsEntry.StructureId, tsEntry.ProjectId);
                }
                else if (String.IsNullOrEmpty(tsEntry.StructureId) && !String.IsNullOrEmpty(tsEntry.ProjectId))
                {
                    // Non structure-specific work
                    workNumber = 99;
                    structureId = "SPECIAL";
                }
                else if (String.IsNullOrEmpty(tsEntry.StructureId) && String.IsNullOrEmpty(tsEntry.ProjectId))
                {
                    // Vacation, holiday, time off
                    workNumber = 99;
                    structureId = "SPECIAL";
                    projectId = "0000-00-00";
                }

                if (workNumber != 0)
                {
                    tsEntry.StructureId = structureId;
                    tsEntry.ProjectId = projectId;
                    tsEntry.WorkNumber = workNumber;

                    try
                    {
                        query.DeleteTimesheetEntry(tsEntry.StructureId, tsEntry.ProjectId, tsEntry.ActivityCode,
                            tsEntry.EmployeeId, tsEntry.WeekEndingDate, tsEntry.WorkNumber);
                        query.InsertTimesheetEntry(tsEntry.StructureId, tsEntry.ProjectId, tsEntry.ActivityCode,
                            tsEntry.EmployeeId, tsEntry.WeekEndingDate, tsEntry.WorkNumber,
                            tsEntry.TotalHours, tsEntry.MonthWeekEndingDate, tsEntry.YearWeekEndingDate);
                        tsEntry.IsInsertedIntoDatabase = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.Print("Error in ImportTimesheetEntriesIntoDatabase: {0}", ex.StackTrace);
                        tsEntry.IsInsertedIntoDatabase = false;
                    }
                }
            }

            return timesheetEntries;
        }

        public bool DoesWorksheetExist(int monthOfWeekEndingDate, int yearOfWeekEndingDate)
        {
            return query.DoesWorksheetExist(monthOfWeekEndingDate, yearOfWeekEndingDate);
        }
    }
}
