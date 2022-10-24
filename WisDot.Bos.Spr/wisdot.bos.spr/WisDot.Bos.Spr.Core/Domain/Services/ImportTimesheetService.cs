using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using WisDot.Bos.Spr.Core.Domain.Models;
using WisDot.Bos.Spr.Core.Domain.Services.Interfaces;
using WisDot.Bos.Spr.Core.Infrastructure.Interfaces;
using WisDot.Bos.Spr.Core.Infrastructure;

namespace WisDot.Bos.Spr.Core.Domain.Services
{
    public class ImportTimesheetService : IImportTimesheetService
    {
        private ITimesheetRepository tsRepo;

        public ImportTimesheetService()
        {
            tsRepo = new TimesheetRepository();
        }

        public string GetProgressReportFilePath()
        {
            return tsRepo.GetProgressReportFilePath();
        }

        public string GetTimesheetFilePath()
        {
            return tsRepo.GetTimesheetFilePath();
        }

        public List<TimesheetEntry> GetTimesheetEntries(int monthOfWeekEndingDate, int yearOfWeekEndingDate)
        {
            return tsRepo.GetTimesheetEntries(monthOfWeekEndingDate, yearOfWeekEndingDate);
        }

        public List<TimesheetEntry> ImportTimesheetEntriesIntoDatabase(int monthOfWeekEndingDate, int yearOfWeekEndingDate)
        {
            return tsRepo.ImportTimesheetEntriesIntoDatabase(monthOfWeekEndingDate, yearOfWeekEndingDate);
        }

        public bool DoesWorksheetExist(int monthOfWeekEndingDate, int yearOfWeekEndingDate)
        {
            return tsRepo.DoesWorksheetExist(monthOfWeekEndingDate, yearOfWeekEndingDate);
        }

        private void canISeeThis()
        {

        }
    }
}
