using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System.Data.OleDb;
using ClosedXML.Excel;
using WisDot.Bos.Spr.Core.Data.Interfaces;

namespace WisDot.Bos.Spr.Core.Data
{
    internal class EmployeeTimesheetQuery : ITimesheetQuery, IProgressReportQuery
    {
        private static DataConnector dataConnector;
        private static OleDatabaseConnection progressReportDbConn;
        private static string timesheetFilePath;
        private static string progressReportFilePath;

        public EmployeeTimesheetQuery()
        {
            dataConnector = new DataConnector();
            progressReportDbConn = dataConnector.RequestOleConnection(Constants.DatabaseType.structuresProgressReportDatabase);
            timesheetFilePath = dataConnector.GetTimesheetFilePath();
            progressReportFilePath = dataConnector.GetProgressReportFilePath();
        }

        public string GetProgressReportFilePath()
        {
            return progressReportFilePath;
        }

        public string GetTimesheetFilePath()
        {
            return timesheetFilePath;
        }

        #region Timesheet Excel file methods
        public bool DoesWorksheetExist(int monthOfWeekEndingDate, int yearOfWeekEndingDate)
        {
            bool isExisting = false;
            string worksheetName = String.Format("{0}-{1}", yearOfWeekEndingDate, monthOfWeekEndingDate);

            try
            {
                using (var wb = new XLWorkbook(timesheetFilePath))
                {
                    if (wb.Worksheets.Where(item => item.Name.Equals(worksheetName)).Count() > 0)
                    {
                        isExisting = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print("Error in GetTimesheetRows: {0}", ex.StackTrace);
            }

            return isExisting;
        }

        public List<IXLRow> GetTimesheetRows(int monthOfWeekEndingDate, int yearOfWeekEndingDate)
        {
            List<IXLRow> rows = new List<IXLRow>();

            try
            {
                using (var wb = new XLWorkbook(timesheetFilePath))
                {
                    try
                    {
                        var ws = wb.Worksheet(String.Format("{0}-{1}", yearOfWeekEndingDate, monthOfWeekEndingDate));
                        rows.AddRange(ws.RowsUsed());
                    }
                    catch (Exception ex)
                    {
                        Debug.Print("Error in GetTimesheetRows: {0}", ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print("Error in GetTimesheetRows: {0}", ex.StackTrace);
            }

            return rows;
        }

        public IXLWorksheet GetEmployeeWorksheet()
        {
            var wb = new XLWorkbook(timesheetFilePath);
            var ws = wb.Worksheet("Employee");
            return ws;
        }

        public List<IXLRow> GetEmployeeRows()
        {
            List<IXLRow> rows = new List<IXLRow>();

            using (var wb = new XLWorkbook(timesheetFilePath))
            {
                var ws = wb.Worksheet("Employee");
                rows.AddRange(ws.RowsUsed());
            }

            return rows;
        }
        #endregion Timesheet Excel file methods

        #region Progress Report database methods
        public int GetWorkNumber(string structureId, string projectId)
        {
            int workNumber = 0;
            DataTable dt = null;
            string qry =
                @"
                    select [Work Number] as WorkNumber
                    from Project
                    where [Structure Number] = @structureId
                        and [Project Id] = @projectId
                ";
            OleDbParameter[] prms = new OleDbParameter[2];
            prms[0] = new OleDbParameter("@structureId", OleDbType.VarChar);
            prms[0].Value = structureId;
            prms[1] = new OleDbParameter("@projectId", OleDbType.VarChar);
            prms[1].Value = projectId;
            dt = dataConnector.ExecuteSelectOle(qry, prms, progressReportDbConn.OleDbConnection);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                workNumber = Convert.ToInt32(dr["WorkNumber"]);
            }

            return workNumber;
        }

        public bool IsTimesheetEntryInDatabase(string structureId, string projectId, int activityCode, int employeeId,
            DateTime weekEndingDate, int workNumber)
        {
            bool inDb = false;
            string qry =
                @"
                    select count(*)
                    from Employee_Weekly_Hours_Activity_Project
                    where [Structure Number] = @structureId
                        and Project_Id = @projectId
                        and Activity_Code = @activityCode
                        and Emp_Ssn = @employeeId
                        and Week_Ending_Date = @weekEndingDate
                        and Work_Number = @workNumber
                ";
            OleDbParameter[] prms = new OleDbParameter[6];
            prms[0] = new OleDbParameter("@structureId", OleDbType.VarChar);
            prms[0].Value = structureId;
            prms[1] = new OleDbParameter("@projectId", OleDbType.VarChar);
            prms[1].Value = projectId;
            prms[2] = new OleDbParameter("@activityCode", OleDbType.Integer);
            prms[2].Value = activityCode;
            prms[3] = new OleDbParameter("@employeeId", OleDbType.Integer);
            prms[3].Value = employeeId;
            prms[4] = new OleDbParameter("@weekEndingDate", OleDbType.Date);
            prms[4].Value = weekEndingDate;
            prms[5] = new OleDbParameter("@workNumber", OleDbType.Integer);
            prms[5].Value = workNumber;
            DataTable dt = dataConnector.ExecuteSelectOle(qry, prms, progressReportDbConn.OleDbConnection);

            if (dt != null && dt.Rows.Count > 0)
            {
                inDb = true;
            }

            return inDb;
        }

        public void DeleteTimesheetEntry(string structureId, string projectId, int activityCode, int employeeId,
            DateTime weekEndingDate, int workNumber)
        {
            string qry =
                @"
                    delete
                    from Employee_Weekly_Hours_Activity_Project
                    where [Structure Number] = @structureId
                        and Project_Id = @projectId
                        and Activity_Code = @activityCode
                        and Emp_Ssn = @employeeId
                        and Week_Ending_Date = @weekEndingDate
                        and Work_Number = @workNumber
                ";
            OleDbParameter[] prms = new OleDbParameter[6];
            prms[0] = new OleDbParameter("@structureId", OleDbType.VarChar);
            prms[0].Value = structureId;
            prms[1] = new OleDbParameter("@projectId", OleDbType.VarChar);
            prms[1].Value = projectId;
            prms[2] = new OleDbParameter("@activityCode", OleDbType.Integer);
            prms[2].Value = activityCode;
            prms[3] = new OleDbParameter("@employeeId", OleDbType.Integer);
            prms[3].Value = employeeId;
            prms[4] = new OleDbParameter("@weekEndingDate", OleDbType.Date);
            prms[4].Value = weekEndingDate;
            prms[5] = new OleDbParameter("@workNumber", OleDbType.Integer);
            prms[5].Value = workNumber;
            dataConnector.ExecuteInsertUpdateDelete(qry, prms, progressReportDbConn.OleDbConnection);
        }

        public void InsertTimesheetEntry(string structureId, string projectId, int activityCode, int employeeId,
            DateTime weekEndingDate, int workNumber, float totalHours, int monthWeekEndingDate, int yearWeekEndingDate)
        {
            string qry =
                @"
                    insert into Employee_Weekly_Hours_Activity_Project ([Structure Number], Project_Id, Activity_Code, Emp_Ssn, 
                        Week_Ending_Date, Work_Number, Total_Hours, Month_Of_Week_Ending_Date, Year_Of_Week_Ending_Date)
                    values (@structureId, @projectId, @activityCode, @employeeId, @weekEndingDate, @workNumber, @totalHours,
                        @monthWeekEndingDate, @yearWeekEndingDate)
                ";
            OleDbParameter[] prms = new OleDbParameter[9];
            prms[0] = new OleDbParameter("@structureId", OleDbType.VarChar);
            prms[0].Value = structureId;
            prms[1] = new OleDbParameter("@projectId", OleDbType.VarChar);
            prms[1].Value = projectId;
            prms[2] = new OleDbParameter("@activityCode", OleDbType.Integer);
            prms[2].Value = activityCode;
            prms[3] = new OleDbParameter("@employeeId", OleDbType.Integer);
            prms[3].Value = employeeId;
            prms[4] = new OleDbParameter("@weekEndingDate", OleDbType.Date);
            prms[4].Value = weekEndingDate;
            prms[5] = new OleDbParameter("@workNumber", OleDbType.Integer);
            prms[5].Value = workNumber;
            prms[6] = new OleDbParameter("@totalHours", OleDbType.Double);
            prms[6].Value = Convert.ToDouble(totalHours);
            prms[7] = new OleDbParameter("@monthWeekEndingDate", OleDbType.Integer);
            prms[7].Value = monthWeekEndingDate;
            prms[8] = new OleDbParameter("@yearWeekEndingDate", OleDbType.Integer);
            prms[8].Value = yearWeekEndingDate;
            dataConnector.ExecuteInsertUpdateDelete(qry, prms, progressReportDbConn.OleDbConnection);
        }
        #endregion Progress Report database methods
    }
}
