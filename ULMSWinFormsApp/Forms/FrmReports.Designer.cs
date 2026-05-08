namespace ULMSWinFormsApp.Forms
{
    partial class FrmReports
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbReportType = new ComboBox();
            txtReportStudentId = new TextBox();
            btnGenerateReport = new Button();
            btnClearReport = new Button();
            btnBackReport = new Button();
            txtReportOutput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 90);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(142, 32);
            label1.TabIndex = 0;
            label1.Text = "Report Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(494, 90);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(187, 32);
            label2.TabIndex = 1;
            label2.Text = "Student ID Filter";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(859, 90);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(167, 32);
            label3.TabIndex = 2;
            label3.Text = "Report Output";
            // 
            // cmbReportType
            // 
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Student Summary Report", "Marks Report", "Enrollment Report" });
            cmbReportType.Location = new Point(70, 186);
            cmbReportType.Margin = new Padding(5);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(355, 40);
            cmbReportType.TabIndex = 3;
            // 
            // txtReportStudentId
            // 
            txtReportStudentId.Location = new Point(494, 186);
            txtReportStudentId.Margin = new Padding(5);
            txtReportStudentId.Name = "txtReportStudentId";
            txtReportStudentId.Size = new Size(201, 39);
            txtReportStudentId.TabIndex = 4;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(20, 598);
            btnGenerateReport.Margin = new Padding(5);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(405, 50);
            btnGenerateReport.TabIndex = 5;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnClearReport
            // 
            btnClearReport.Location = new Point(494, 598);
            btnClearReport.Margin = new Padding(5);
            btnClearReport.Name = "btnClearReport";
            btnClearReport.Size = new Size(405, 50);
            btnClearReport.TabIndex = 6;
            btnClearReport.Text = "Clear";
            btnClearReport.UseVisualStyleBackColor = true;
            btnClearReport.Click += btnClearReport_Click;
            // 
            // btnBackReport
            // 
            btnBackReport.Location = new Point(983, 598);
            btnBackReport.Margin = new Padding(5);
            btnBackReport.Name = "btnBackReport";
            btnBackReport.Size = new Size(405, 50);
            btnBackReport.TabIndex = 7;
            btnBackReport.Text = "Back";
            btnBackReport.UseVisualStyleBackColor = true;
            btnBackReport.Click += btnBackReport_Click;
            // 
            // txtReportOutput
            // 
            txtReportOutput.Location = new Point(762, 141);
            txtReportOutput.Margin = new Padding(5);
            txtReportOutput.Multiline = true;
            txtReportOutput.Name = "txtReportOutput";
            txtReportOutput.ReadOnly = true;
            txtReportOutput.ScrollBars = ScrollBars.Vertical;
            txtReportOutput.Size = new Size(773, 372);
            txtReportOutput.TabIndex = 8;
            // 
            // FrmReports
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1596, 917);
            Controls.Add(txtReportOutput);
            Controls.Add(btnBackReport);
            Controls.Add(btnClearReport);
            Controls.Add(btnGenerateReport);
            Controls.Add(txtReportStudentId);
            Controls.Add(cmbReportType);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(5);
            Name = "FrmReports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Umoja Learning Management System - Reports";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbReportType;
        private TextBox txtReportStudentId;
        private Button btnGenerateReport;
        private Button btnClearReport;
        private Button btnBackReport;
        private TextBox txtReportOutput;
    }
}