using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.Spr.Core.Domain.Models;

namespace WisDot.Bos.TimesheetTool
{
    public interface IHomeView
    {
        void SetController(HomeController controller);
        //void ImportTimesheetEntries(int monthWeekEndingDate, int yearWeekEndingDate);
        void ClearImportResultsList();
        void ClearImportResultsGrid();
        void AddResultToList(TimesheetEntry timesheetEntry);
        void AddResultsToList(List<TimesheetEntry> timesheetEntries);
        string TimesheetFilePath { get; set; }
        string ProgressReportFilePath { get; set; }
        int TimePeriodMonth { get; set; }
        int TimePeriodYear { get; set; }
        List<TimesheetEntry> TimesheetEntries { get; set; }
        List<TimesheetEntry> FilteredEntries { get; set; }
        /*
        string UserId { get; set; }
        string Password { get; set; }*/
    }
}
