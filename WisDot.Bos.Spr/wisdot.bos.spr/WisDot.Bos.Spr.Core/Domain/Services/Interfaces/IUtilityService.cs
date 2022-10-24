using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.Spr.Core.Domain.Models;


namespace WisDot.Bos.Spr.Core.Domain.Services.Interfaces
{
    public interface IUtilityService
    {
        void ExportClipboardToExcel();
        void ExportImportResultsToExcel(List<TimesheetEntry> tsEntries, string filePath="");
        string GenerateUniqueFilename(string fileExtension);
        void OpenExcelFile(string filePath);
        //bool FileExists(string filePath);
        List<TimesheetEntry> FilterGridResults(string name, List<TimesheetEntry> tsEntries);
    }
}
