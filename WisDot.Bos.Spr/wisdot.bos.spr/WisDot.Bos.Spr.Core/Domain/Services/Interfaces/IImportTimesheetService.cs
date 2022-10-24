using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WisDot.Bos.Spr.Core.Domain.Models;

namespace WisDot.Bos.Spr.Core.Domain.Services.Interfaces
{
    public interface IImportTimesheetService
    {
        string GetTimesheetFilePath();
        string GetProgressReportFilePath();
        List<TimesheetEntry> GetTimesheetEntries(int monthOfWeekEndingDate, int yearOfWeekEndingDate);
        List<TimesheetEntry> ImportTimesheetEntriesIntoDatabase(int monthOfWeekEndingDate, int yearOfWeekEndingDate);
        bool DoesWorksheetExist(int monthOfWeekEndingDate, int yearOfWeekEndingDate);
    }
}
