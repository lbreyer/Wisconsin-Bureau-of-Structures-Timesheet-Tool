using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace WisDot.Bos.Spr.Core.Data.Interfaces
{
    internal interface ITimesheetQuery
    {
        string GetTimesheetFilePath();
        List<IXLRow> GetTimesheetRows(int monthOfWeekEndingDate, int yearOfWeekEndingDate);
    }
}
