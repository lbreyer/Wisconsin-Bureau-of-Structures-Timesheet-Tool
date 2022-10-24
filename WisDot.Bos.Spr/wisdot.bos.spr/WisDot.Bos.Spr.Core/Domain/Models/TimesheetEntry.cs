using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisDot.Bos.Spr.Core.Domain.Models
{
    public class TimesheetEntry
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string StructureId { get; set; }
        public string ProjectId { get; set; }
        public int ActivityCode { get; set; }
        public DateTime WeekEndingDate { get; set; }
        public int WorkNumber { get; set; }
        public float TotalHours { get; set; }
        public string ActivityDescription { get; set; }
        public int ActivityCategoryId { get; set; }
        public string ActivityCategoryDescription { get; set; }
        public int MonthWeekEndingDate { get; set; }
        public int YearWeekEndingDate { get; set; }
        public int ExcelRowNumber { get; set; }
        public bool IsInsertedIntoDatabase { get; set; }

        public TimesheetEntry()
        {
            initialize();
        }

        private void initialize()
        {
            this.StructureId = "";
            this.ProjectId = "";
            this.ActivityDescription = "";
            this.ActivityCategoryDescription = "";
        }
    }
}
