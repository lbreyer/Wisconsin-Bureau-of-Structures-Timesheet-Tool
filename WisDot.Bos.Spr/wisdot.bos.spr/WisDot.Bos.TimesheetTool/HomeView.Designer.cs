namespace WisDot.Bos.TimesheetTool
{
    partial class HomeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.tabPageImportTimesheet = new System.Windows.Forms.TabPage();
            this.groupBoxImportResults = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewImportResults = new System.Windows.Forms.DataGridView();
            this.ColumnEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnActivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStructureId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWorkNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnWeekEndingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonExportToExcel = new System.Windows.Forms.Button();
            this.buttonClearImportResults = new System.Windows.Forms.Button();
            this.groupBoxImportTimesheet = new System.Windows.Forms.GroupBox();
            this.listViewImportResults = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxImport = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonImportTimesheet = new System.Windows.Forms.Button();
            this.textBoxTimesheetFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxProgressReportDatabaseFilePath = new System.Windows.Forms.TextBox();
            this.textBoxTimePeriodYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTimePeriodMonth = new System.Windows.Forms.TextBox();
            this.tabControlFunctions = new System.Windows.Forms.TabControl();
            this.tabPageImportTimesheet.SuspendLayout();
            this.groupBoxImportResults.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportResults)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxImportTimesheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImport)).BeginInit();
            this.tabControlFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageReports
            // 
            this.tabPageReports.Location = new System.Drawing.Point(4, 22);
            this.tabPageReports.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageReports.Size = new System.Drawing.Size(728, 405);
            this.tabPageReports.TabIndex = 1;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // tabPageImportTimesheet
            // 
            this.tabPageImportTimesheet.Controls.Add(this.groupBoxImportResults);
            this.tabPageImportTimesheet.Controls.Add(this.groupBoxImportTimesheet);
            this.tabPageImportTimesheet.Location = new System.Drawing.Point(4, 22);
            this.tabPageImportTimesheet.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageImportTimesheet.Name = "tabPageImportTimesheet";
            this.tabPageImportTimesheet.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageImportTimesheet.Size = new System.Drawing.Size(728, 405);
            this.tabPageImportTimesheet.TabIndex = 0;
            this.tabPageImportTimesheet.Text = "Import Timesheet";
            this.tabPageImportTimesheet.UseVisualStyleBackColor = true;
            // 
            // groupBoxImportResults
            // 
            this.groupBoxImportResults.Controls.Add(this.panel2);
            this.groupBoxImportResults.Controls.Add(this.panel1);
            this.groupBoxImportResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxImportResults.Location = new System.Drawing.Point(2, 119);
            this.groupBoxImportResults.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxImportResults.Name = "groupBoxImportResults";
            this.groupBoxImportResults.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxImportResults.Size = new System.Drawing.Size(724, 284);
            this.groupBoxImportResults.TabIndex = 12;
            this.groupBoxImportResults.TabStop = false;
            this.groupBoxImportResults.Text = "Results";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewImportResults);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 232);
            this.panel2.TabIndex = 17;
            // 
            // dataGridViewImportResults
            // 
            this.dataGridViewImportResults.AllowUserToAddRows = false;
            this.dataGridViewImportResults.AllowUserToDeleteRows = false;
            this.dataGridViewImportResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImportResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEmployeeId,
            this.ColumnLastName,
            this.ColumnFirstName,
            this.ColumnProjectId,
            this.ColumnActivity,
            this.ColumnStructureId,
            this.ColumnWorkNumber,
            this.ColumnWeekEndingDate,
            this.ColumnHours});
            this.dataGridViewImportResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewImportResults.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewImportResults.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewImportResults.Name = "dataGridViewImportResults";
            this.dataGridViewImportResults.ReadOnly = true;
            this.dataGridViewImportResults.RowTemplate.Height = 24;
            this.dataGridViewImportResults.Size = new System.Drawing.Size(720, 232);
            this.dataGridViewImportResults.TabIndex = 15;
            // 
            // ColumnEmployeeId
            // 
            this.ColumnEmployeeId.HeaderText = "Employee ID";
            this.ColumnEmployeeId.Name = "ColumnEmployeeId";
            this.ColumnEmployeeId.ReadOnly = true;
            // 
            // ColumnLastName
            // 
            this.ColumnLastName.HeaderText = "Last Name";
            this.ColumnLastName.Name = "ColumnLastName";
            this.ColumnLastName.ReadOnly = true;
            // 
            // ColumnFirstName
            // 
            this.ColumnFirstName.HeaderText = "First Name";
            this.ColumnFirstName.Name = "ColumnFirstName";
            this.ColumnFirstName.ReadOnly = true;
            // 
            // ColumnProjectId
            // 
            this.ColumnProjectId.HeaderText = "Project ID";
            this.ColumnProjectId.Name = "ColumnProjectId";
            this.ColumnProjectId.ReadOnly = true;
            // 
            // ColumnActivity
            // 
            this.ColumnActivity.HeaderText = "Activity";
            this.ColumnActivity.Name = "ColumnActivity";
            this.ColumnActivity.ReadOnly = true;
            // 
            // ColumnStructureId
            // 
            this.ColumnStructureId.HeaderText = "Structure ID";
            this.ColumnStructureId.Name = "ColumnStructureId";
            this.ColumnStructureId.ReadOnly = true;
            // 
            // ColumnWorkNumber
            // 
            this.ColumnWorkNumber.HeaderText = "Work Number";
            this.ColumnWorkNumber.Name = "ColumnWorkNumber";
            this.ColumnWorkNumber.ReadOnly = true;
            // 
            // ColumnWeekEndingDate
            // 
            this.ColumnWeekEndingDate.HeaderText = "Week Ending Date";
            this.ColumnWeekEndingDate.Name = "ColumnWeekEndingDate";
            this.ColumnWeekEndingDate.ReadOnly = true;
            // 
            // ColumnHours
            // 
            this.ColumnHours.HeaderText = "Hours";
            this.ColumnHours.Name = "ColumnHours";
            this.ColumnHours.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textSearch);
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.buttonExportToExcel);
            this.panel1.Controls.Add(this.buttonClearImportResults);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 35);
            this.panel1.TabIndex = 16;
            // 
            // textSearch
            // 
            this.textSearch.Enabled = false;
            this.textSearch.Location = new System.Drawing.Point(14, 6);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(138, 20);
            this.textSearch.TabIndex = 17;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Enabled = false;
            this.buttonSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSearch.Location = new System.Drawing.Point(167, 6);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(72, 21);
            this.buttonSearch.TabIndex = 16;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonExportToExcel
            // 
            this.buttonExportToExcel.Location = new System.Drawing.Point(292, 6);
            this.buttonExportToExcel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExportToExcel.Name = "buttonExportToExcel";
            this.buttonExportToExcel.Size = new System.Drawing.Size(89, 21);
            this.buttonExportToExcel.TabIndex = 15;
            this.buttonExportToExcel.Text = "Export to Excel";
            this.buttonExportToExcel.UseVisualStyleBackColor = true;
            this.buttonExportToExcel.Click += new System.EventHandler(this.buttonExportToExcel_Click);
            // 
            // buttonClearImportResults
            // 
            this.buttonClearImportResults.Location = new System.Drawing.Point(391, 6);
            this.buttonClearImportResults.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClearImportResults.Name = "buttonClearImportResults";
            this.buttonClearImportResults.Size = new System.Drawing.Size(78, 21);
            this.buttonClearImportResults.TabIndex = 14;
            this.buttonClearImportResults.Text = "Clear Grid";
            this.buttonClearImportResults.UseVisualStyleBackColor = true;
            this.buttonClearImportResults.Click += new System.EventHandler(this.buttonClearImportResults_Click);
            // 
            // groupBoxImportTimesheet
            // 
            this.groupBoxImportTimesheet.Controls.Add(this.listViewImportResults);
            this.groupBoxImportTimesheet.Controls.Add(this.label1);
            this.groupBoxImportTimesheet.Controls.Add(this.pictureBoxImport);
            this.groupBoxImportTimesheet.Controls.Add(this.label2);
            this.groupBoxImportTimesheet.Controls.Add(this.buttonImportTimesheet);
            this.groupBoxImportTimesheet.Controls.Add(this.textBoxTimesheetFilePath);
            this.groupBoxImportTimesheet.Controls.Add(this.label5);
            this.groupBoxImportTimesheet.Controls.Add(this.textBoxProgressReportDatabaseFilePath);
            this.groupBoxImportTimesheet.Controls.Add(this.textBoxTimePeriodYear);
            this.groupBoxImportTimesheet.Controls.Add(this.label3);
            this.groupBoxImportTimesheet.Controls.Add(this.label4);
            this.groupBoxImportTimesheet.Controls.Add(this.textBoxTimePeriodMonth);
            this.groupBoxImportTimesheet.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxImportTimesheet.Location = new System.Drawing.Point(2, 2);
            this.groupBoxImportTimesheet.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxImportTimesheet.Name = "groupBoxImportTimesheet";
            this.groupBoxImportTimesheet.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxImportTimesheet.Size = new System.Drawing.Size(724, 117);
            this.groupBoxImportTimesheet.TabIndex = 11;
            this.groupBoxImportTimesheet.TabStop = false;
            this.groupBoxImportTimesheet.Text = "Import";
            // 
            // listViewImportResults
            // 
            this.listViewImportResults.GridLines = true;
            this.listViewImportResults.HideSelection = false;
            this.listViewImportResults.Location = new System.Drawing.Point(601, 48);
            this.listViewImportResults.Margin = new System.Windows.Forms.Padding(2);
            this.listViewImportResults.Name = "listViewImportResults";
            this.listViewImportResults.Size = new System.Drawing.Size(59, 34);
            this.listViewImportResults.TabIndex = 14;
            this.listViewImportResults.UseCompatibleStateImageBehavior = false;
            this.listViewImportResults.View = System.Windows.Forms.View.Details;
            this.listViewImportResults.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timesheet Excel Data File (Source):";
            // 
            // pictureBoxImport
            // 
            this.pictureBoxImport.Image = global::WisDot.Bos.TimesheetTool.Properties.Resources.ajax_loader;
            this.pictureBoxImport.Location = new System.Drawing.Point(464, 77);
            this.pictureBoxImport.Name = "pictureBoxImport";
            this.pictureBoxImport.Size = new System.Drawing.Size(32, 24);
            this.pictureBoxImport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxImport.TabIndex = 10;
            this.pictureBoxImport.TabStop = false;
            this.pictureBoxImport.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Progress Report Access DB (Destination):";
            // 
            // buttonImportTimesheet
            // 
            this.buttonImportTimesheet.Location = new System.Drawing.Point(393, 79);
            this.buttonImportTimesheet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonImportTimesheet.Name = "buttonImportTimesheet";
            this.buttonImportTimesheet.Size = new System.Drawing.Size(56, 21);
            this.buttonImportTimesheet.TabIndex = 9;
            this.buttonImportTimesheet.Text = "Import";
            this.buttonImportTimesheet.UseVisualStyleBackColor = true;
            this.buttonImportTimesheet.Click += new System.EventHandler(this.buttonImportTimesheet_Click);
            // 
            // textBoxTimesheetFilePath
            // 
            this.textBoxTimesheetFilePath.Location = new System.Drawing.Point(223, 24);
            this.textBoxTimesheetFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTimesheetFilePath.Name = "textBoxTimesheetFilePath";
            this.textBoxTimesheetFilePath.ReadOnly = true;
            this.textBoxTimesheetFilePath.Size = new System.Drawing.Size(363, 20);
            this.textBoxTimesheetFilePath.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Year";
            // 
            // textBoxProgressReportDatabaseFilePath
            // 
            this.textBoxProgressReportDatabaseFilePath.Location = new System.Drawing.Point(223, 48);
            this.textBoxProgressReportDatabaseFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProgressReportDatabaseFilePath.Name = "textBoxProgressReportDatabaseFilePath";
            this.textBoxProgressReportDatabaseFilePath.ReadOnly = true;
            this.textBoxProgressReportDatabaseFilePath.Size = new System.Drawing.Size(363, 20);
            this.textBoxProgressReportDatabaseFilePath.TabIndex = 3;
            // 
            // textBoxTimePeriodYear
            // 
            this.textBoxTimePeriodYear.Location = new System.Drawing.Point(337, 80);
            this.textBoxTimePeriodYear.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTimePeriodYear.MaxLength = 4;
            this.textBoxTimePeriodYear.Name = "textBoxTimePeriodYear";
            this.textBoxTimePeriodYear.Size = new System.Drawing.Size(33, 20);
            this.textBoxTimePeriodYear.TabIndex = 7;
            this.textBoxTimePeriodYear.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTimePeriodYear_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time Period:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Month";
            // 
            // textBoxTimePeriodMonth
            // 
            this.textBoxTimePeriodMonth.Location = new System.Drawing.Point(260, 80);
            this.textBoxTimePeriodMonth.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTimePeriodMonth.MaxLength = 2;
            this.textBoxTimePeriodMonth.Name = "textBoxTimePeriodMonth";
            this.textBoxTimePeriodMonth.Size = new System.Drawing.Size(26, 20);
            this.textBoxTimePeriodMonth.TabIndex = 5;
            this.textBoxTimePeriodMonth.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTimePeriodMonth_Validating);
            // 
            // tabControlFunctions
            // 
            this.tabControlFunctions.Controls.Add(this.tabPageImportTimesheet);
            this.tabControlFunctions.Controls.Add(this.tabPageReports);
            this.tabControlFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFunctions.Location = new System.Drawing.Point(0, 0);
            this.tabControlFunctions.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlFunctions.Name = "tabControlFunctions";
            this.tabControlFunctions.SelectedIndex = 0;
            this.tabControlFunctions.Size = new System.Drawing.Size(736, 431);
            this.tabControlFunctions.TabIndex = 0;
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 431);
            this.Controls.Add(this.tabControlFunctions);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HomeView";
            this.Text = "Timesheeter";
            this.tabPageImportTimesheet.ResumeLayout(false);
            this.groupBoxImportResults.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxImportTimesheet.ResumeLayout(false);
            this.groupBoxImportTimesheet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImport)).EndInit();
            this.tabControlFunctions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.TabPage tabPageImportTimesheet;
        private System.Windows.Forms.GroupBox groupBoxImportResults;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewImportResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnActivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStructureId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWorkNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWeekEndingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHours;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExportToExcel;
        private System.Windows.Forms.Button buttonClearImportResults;
        private System.Windows.Forms.GroupBox groupBoxImportTimesheet;
        private System.Windows.Forms.ListView listViewImportResults;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.PictureBox pictureBoxImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonImportTimesheet;
        private System.Windows.Forms.TextBox textBoxTimesheetFilePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxProgressReportDatabaseFilePath;
        private System.Windows.Forms.TextBox textBoxTimePeriodYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTimePeriodMonth;
        private System.Windows.Forms.TabControl tabControlFunctions;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textSearch;
    }
}

