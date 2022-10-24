using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using WisDot.Bos.Spr.Core.Domain.Models;
using WisDot.Bos.Spr.Core.Domain.Services.Interfaces;
using WisDot.Bos.Spr.Core.Data;

namespace WisDot.Bos.Spr.Core.Domain.Services
{
    public class UtilityService : IUtilityService
    {
        private DataConnector dataConn;

        public UtilityService()
        {
            dataConn = new DataConnector();
        }

        public void ExportClipboardToExcel()
        {
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        public void ExportImportResultsToExcel(List<TimesheetEntry> tsEntries, string filePath="")
        {
            XLWorkbook wb = new XLWorkbook();
            var wsEmployees = wb.AddWorksheet("Employees");
            var wsTimesheetEntries = wb.AddWorksheet("Timesheet Entries");
            List<string> employeeColumns = new List<string>()
            {
                "Last Name", "First Name"
            };
            List<string> timesheetEntryColumns = new List<string>()
            {
                "Employee ID", "Last Name", "First Name", "Project ID", "Activity", "Structure ID",
                "Work Number", "Week Ending Date", "Hours"
            };
            int cc = 1; // Column counter
            int rc = 1; // Row counter

            foreach (var columnName in employeeColumns)
            {
                wsEmployees.Cell(rc, cc).Value = columnName;
                cc++;
            }

            rc = 2;

            foreach (var emp in tsEntries.GroupBy(x => new { x.EmployeeLastName, x.EmployeeFirstName }).Select(g => g.First()).ToList().OrderBy(x => x.EmployeeLastName).ThenBy(x => x.EmployeeFirstName))
            {
                wsEmployees.Cell(rc, 1).Value = emp.EmployeeLastName;
                wsEmployees.Cell(rc, 2).Value = emp.EmployeeFirstName;
                rc++;
            }

            cc = 1;
            rc = 1;

            foreach (var columnName in timesheetEntryColumns)
            {
                wsTimesheetEntries.Cell(rc, cc).Value = columnName;
                cc++;
            }

            rc = 2;

            foreach (var tsEntry in tsEntries.OrderBy(el => el.EmployeeLastName).ThenBy(el => el.EmployeeFirstName).ThenBy(el => el.ActivityCode))
            {
                wsTimesheetEntries.Cell(rc, 1).Value = tsEntry.EmployeeId;
                wsTimesheetEntries.Cell(rc, 2).Value = tsEntry.EmployeeLastName;
                wsTimesheetEntries.Cell(rc, 3).Value = tsEntry.EmployeeFirstName;
                wsTimesheetEntries.Cell(rc, 4).Value = tsEntry.ProjectId;
                wsTimesheetEntries.Cell(rc, 5).Value = String.Format("{0}-{1}", tsEntry.ActivityCode, tsEntry.ActivityDescription);
                wsTimesheetEntries.Cell(rc, 6).Value = tsEntry.StructureId;
                wsTimesheetEntries.Cell(rc, 7).Value = tsEntry.WorkNumber;
                wsTimesheetEntries.Cell(rc, 8).Value = tsEntry.WeekEndingDate.ToString("yyyy/MM/dd");
                wsTimesheetEntries.Cell(rc, 9).Value = tsEntry.TotalHours;
                rc++;
            }

            if (String.IsNullOrEmpty(filePath))
            {
                filePath = Path.Combine(dataConn.GetOutputDirectory(), GenerateUniqueFilename("xlsx"));
            }

            wb.SaveAs(filePath);
            wb.Dispose();
            OpenExcelFile(filePath);
        }

        public string GenerateUniqueFilename(string fileExtension)
        {
            return String.Format(@"{0}.{1}", DateTime.Now.Ticks, fileExtension.Replace(".", ""));
        }

        public void OpenExcelFile(string filePath)
        {
            try
            {
                var xlsApp = new Microsoft.Office.Interop.Excel.Application();
                xlsApp.Visible = true;
                var xlsBooks = xlsApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook xlsBook = xlsBooks.Open(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error opening {0}: {1}", filePath, ex.StackTrace));
            }
        }

        public List<TimesheetEntry> FilterGridResults(string name, List<TimesheetEntry> tsEntries)
        {
            if (name == null)
            {
                return tsEntries;
            }
            List<TimesheetEntry> fltEntries = new List<TimesheetEntry>();
            foreach (TimesheetEntry tsEntry in tsEntries)
            {
                string fullName = tsEntry.EmployeeFirstName + " " + tsEntry.EmployeeLastName;
                if (fullName.Contains(name))
                {
                    fltEntries.Add(tsEntry);
                    continue;
                }
            }
            return fltEntries;
        }
    }
}
