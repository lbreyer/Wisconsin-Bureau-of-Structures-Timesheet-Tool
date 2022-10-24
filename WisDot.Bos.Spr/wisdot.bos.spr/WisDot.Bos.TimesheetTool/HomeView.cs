using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WisDot.Bos.Spr.Core.Domain.Services;
using WisDot.Bos.Spr.Core.Domain.Models;

namespace WisDot.Bos.TimesheetTool
{
    public partial class HomeView : Form, IHomeView
    {
        private HomeController controller;
        private List<TimesheetEntry> tsEntries;
        private List<TimesheetEntry> fltEntries;

        #region Constructor
        public HomeView()
        {
            InitializeComponent();
            controller = new HomeController(this);
            tsEntries = new List<TimesheetEntry>();
        }
        #endregion Constructor

        #region IHomeView implementation
        public void SetController(HomeController controller)
        {
            this.controller = controller;
        }

        public void ClearImportResultsList()
        {
            this.listViewImportResults.Columns.Clear();
            this.listViewImportResults.Columns.Add("Id", 150, HorizontalAlignment.Left);
            this.listViewImportResults.Columns.Add("Last Name", 150, HorizontalAlignment.Left);
            this.listViewImportResults.Columns.Add("First Name", 150, HorizontalAlignment.Left);
            this.listViewImportResults.Columns.Add("Proj ID", 150, HorizontalAlignment.Left);
            this.listViewImportResults.Columns.Add("Str ID", 150, HorizontalAlignment.Left);
            this.listViewImportResults.Columns.Add("Activity Code", 150, HorizontalAlignment.Left);
            this.listViewImportResults.Columns.Add("Hours", 150, HorizontalAlignment.Left);
            this.listViewImportResults.Columns.Add("Ending Date", 150, HorizontalAlignment.Left);
            this.listViewImportResults.Items.Clear();
        }

        public void ClearImportResultsGrid()
        {
            this.dataGridViewImportResults.Rows.Clear();
        }

        public void AddResultsToList(List<TimesheetEntry> timesheetEntries)
        {
            ClearImportResultsGrid();

            foreach (var timesheetEntry in timesheetEntries.OrderBy(el => el.EmployeeLastName).ThenBy(el => el.EmployeeFirstName).ThenBy(el => el.ActivityCode))
            {
                //AddResultToList(timesheetEntry);
                //dataGridViewImportResults.Rows.Add();
                AddResultToGrid(timesheetEntry);
            }
        }

        public void AddResultToList(TimesheetEntry timesheetEntry)
        {
            ListViewItem item = new ListViewItem(new string[] { timesheetEntry.EmployeeId.ToString(), timesheetEntry.EmployeeLastName });
            this.listViewImportResults.Items.Add(item);
        }

        public void AddResultToGrid(TimesheetEntry timesheetEntry)
        {
            var dgv = dataGridViewImportResults;
            dgv.Rows.Add();
            dgv.Rows[dgv.Rows.GetLastRow(0)].Cells["ColumnEmployeeId"].Value = timesheetEntry.EmployeeId;
            dgv.Rows[dgv.Rows.GetLastRow(0)].Cells["ColumnLastName"].Value = timesheetEntry.EmployeeLastName;
            dgv.Rows[dgv.Rows.GetLastRow(0)].Cells["ColumnFirstName"].Value = timesheetEntry.EmployeeFirstName;
            dgv.Rows[dgv.Rows.GetLastRow(0)].Cells["ColumnProjectId"].Value = timesheetEntry.ProjectId;
            dgv.Rows[dgv.Rows.GetLastRow(0)].Cells["ColumnActivity"].Value = String.Format("{0}-{1}", timesheetEntry.ActivityCode, timesheetEntry.ActivityDescription);
            dgv.Rows[dgv.Rows.GetLastRow(0)].Cells["ColumnStructureId"].Value = timesheetEntry.StructureId;
            dgv.Rows[dgv.Rows.GetLastRow(0)].Cells["ColumnWorkNumber"].Value = timesheetEntry.WorkNumber;
            dgv.Rows[dgv.Rows.GetLastRow(0)].Cells["ColumnWeekEndingDate"].Value = timesheetEntry.WeekEndingDate.ToString("yyyy/MM/dd");
            dgv.Rows[dgv.Rows.GetLastRow(0)].Cells["ColumnHours"].Value = timesheetEntry.TotalHours;
        }

        public string TimesheetFilePath
        {
            get { return this.textBoxTimesheetFilePath.Text; }
            set { this.textBoxTimesheetFilePath.Text = value; }
        }

        public string ProgressReportFilePath
        {
            get { return this.textBoxProgressReportDatabaseFilePath.Text; }
            set { this.textBoxProgressReportDatabaseFilePath.Text = value;  }
        }

        public int TimePeriodMonth
        {
            get
            {
                if (!String.IsNullOrEmpty(this.textBoxTimePeriodMonth.Text.Trim()))
                {
                    return Convert.ToInt32(this.textBoxTimePeriodMonth.Text.Trim());
                }
                else
                {
                    return 0;
                }
            }
            set { this.textBoxTimePeriodMonth.Text = value.ToString(); }
        }

        public int TimePeriodYear
        {
            get
            {
                if (!String.IsNullOrEmpty(this.textBoxTimePeriodYear.Text.Trim()))
                {
                    return Convert.ToInt32(this.textBoxTimePeriodYear.Text.Trim());
                }
                else
                {
                    return 0;
                }
            }
            set { this.textBoxTimePeriodYear.Text = value.ToString(); }
        }

        public List<TimesheetEntry> TimesheetEntries
        {
            get
            {
                return tsEntries;
            }
            set
            {
                tsEntries = value;
            }
        }

        public List<TimesheetEntry> FilteredEntries
        {
            get
            {
                return fltEntries;
            }
            set
            {
                fltEntries = value;
            }
        }
        #endregion IHomeView implementation

        #region Events
        private async void buttonImportTimesheet_Click(object sender, EventArgs e)
        {
            buttonImportTimesheet.Enabled = false;
            pictureBoxImport.Visible = true;
            buttonClearImportResults.Enabled = false;
            buttonExportToExcel.Enabled = false;
            buttonSearch.Enabled = false;
            textSearch.Enabled = false;
            await Task.Run(() => controller.ImportTimesheetEntries());
            AddResultsToList(this.TimesheetEntries);
            buttonClearImportResults.Enabled = true;
            buttonExportToExcel.Enabled = true;
            pictureBoxImport.Visible = false;
            buttonImportTimesheet.Enabled = true;
            buttonSearch.Enabled = true;
            textSearch.Enabled = true;
        }

        private void buttonExportToExcel_Click(object sender, EventArgs e)
        {
            controller.ExportImportResultsToExcel();
            //controller.ExportClipboardToExcel();
            /*
            pictureBoxImport.Visible = true;
            await Task.Run(() => controller.ExportDataGridToExcel(dataGridViewImportResults));
            pictureBoxImport.Visible = false;*/
        }

        private void buttonClearImportResults_Click(object sender, EventArgs e)
        {
            //ClearImportResultsList();
            ClearImportResultsGrid();
            buttonSearch.Text = "Search";
            textSearch.Text = null;
            buttonSearch.Enabled = false;
            textSearch.Enabled = false;
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            if(buttonSearch.Text == "Search")
            {
                if(textSearch.Text != null)
                {
                    await Task.Run(() =>  controller.FilterResultsFromGrid(textSearch.Text));
                    ClearImportResultsGrid();
                    AddResultsToList(this.FilteredEntries);
                    buttonSearch.Text = "Cancel";
                    textSearch.Enabled = false;
                }
                
            }
            else 
            {
                
                buttonSearch.Enabled = false;
                textSearch.Enabled = false;
                textSearch.Text = null;
                ClearImportResultsGrid();
                AddResultsToList(this.TimesheetEntries);
                buttonSearch.Text = "Search";
                buttonSearch.Enabled = true;
                textSearch.Enabled = true;
            }
            

        }
        #endregion Events

        #region Validation
        private void textBoxTimePeriodMonth_Validating(object sender, CancelEventArgs e)
        {
            bool isValid = true;
            int month = 0;
            bool isConverted = Int32.TryParse(textBoxTimePeriodMonth.Text.Trim(), out month);

            if (!isConverted)
            {
                isValid = false;
            }
            else
            {
                if (month < 1 || month > 12)
                {
                    isValid = false;
                }
            }

            if (!isValid)
            {
                showMessage("Enter a valid month number.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void textBoxTimePeriodYear_Validating(object sender, CancelEventArgs e)
        {
            bool isValid = true;
            int year = 0;
            bool isConverted = Int32.TryParse(textBoxTimePeriodYear.Text.Trim(), out year);

            if (!isConverted)
            {
                isValid = false;
            }
            
            if (!isValid)
            {
                showMessage("Enter a valid year.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void showMessage(string message, string caption, MessageBoxButtons button, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, button, icon);
        }


        #endregion Validation

        #region Internal methods
        #endregion Internal methods

    }
}
