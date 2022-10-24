using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WisDot.Bos.Spr.Core.Domain.Models;
using WisDot.Bos.Spr.Core.Domain.Services;
using WisDot.Bos.Spr.Core.Domain.Services.Interfaces;

namespace WisDot.Bos.TimesheetTool
{
    public class HomeController
    {
        private IHomeView view;
        private IImportTimesheetService tsServ;
        private IUtilityService utilServ;
        private List<TimesheetEntry> tsEntries;
        private List<TimesheetEntry> fltEntries;

        public HomeController(IHomeView view)
        {
            tsServ = new ImportTimesheetService();
            utilServ = new UtilityService();
            tsEntries = new List<TimesheetEntry>();
            fltEntries = new List<TimesheetEntry>();
            this.view = view;
            view.SetController(this);
            RenderImportTimesheetTab();
        }

        public void RenderImportTimesheetTab()
        {
            view.TimesheetFilePath = tsServ.GetTimesheetFilePath();
            view.ProgressReportFilePath = tsServ.GetProgressReportFilePath();

            if (view.TimePeriodMonth == 0)
            {
                view.TimePeriodMonth = DateTime.Now.Month;
            }

            if (view.TimePeriodYear == 0)
            {
                view.TimePeriodYear = DateTime.Now.Year;
            }
        }

        public void ImportTimesheetEntries()
        {
            tsEntries = tsServ.ImportTimesheetEntriesIntoDatabase(view.TimePeriodMonth, view.TimePeriodYear);
            view.TimesheetEntries = tsEntries;
        }

        public void ExportImportResultsToExcel()
        {
            utilServ.ExportImportResultsToExcel(tsEntries);
        }

        public void ExportClipboardToExcel()
        {
            utilServ.ExportClipboardToExcel();
        }

        /*
        public void AddResultsToList()
        {
            foreach (var ts in this.tsEntries)
            {
                view.AddResultToList(ts);
            }
        }*/

        public void FilterResultsFromGrid(string name)
        {

            fltEntries = utilServ.FilterGridResults(name, tsEntries);
            view.FilteredEntries = fltEntries;
        }
    }
}
