using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmReports : Form
    {
        public FrmReports()
        {
            InitializeComponent();
        }

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // BUG-05 FIX: Validate inputs before generating
            if (string.IsNullOrWhiteSpace(cmbReportType.Text))
            {
                MessageBox.Show("Please select a report type.",
                                "Validation Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string reportType = cmbReportType.Text;
            string studentId = txtReportStudentId.Text;

            // BUG-05 FIX: Replaced Thread.Sleep(4000) with async Task.Delay to avoid
            // blocking the UI thread. The form now stays responsive during report generation.
            btnGenerateReport.Enabled = false;
            txtReportOutput.Text = "Generating report, please wait...";

            await Task.Delay(500); // Simulates a non-blocking async data load

            StringBuilder report = new StringBuilder();

            report.AppendLine("===== ULMS REPORT =====");
            report.AppendLine("Report Type: " + reportType);
            report.AppendLine("Student ID Filter: " + studentId);
            report.AppendLine("Generated On: " + DateTime.Now);
            report.AppendLine();

            if (reportType == "Student Summary Report")
            {
                report.AppendLine("Student Name: John Doe");
                report.AppendLine("Programme: Software Engineering");
                report.AppendLine("Status: Active");
            }
            else if (reportType == "Marks Report")
            {
                // BUG-05 FIX: Corrected average — was hardcoded as 169 (a sum, not an average)
                double s1 = 78, s2 = 65, s3 = 80;
                double avg = Math.Round((s1 + s2 + s3) / 3, 2);
                report.AppendLine("Subject 1: " + s1);
                report.AppendLine("Subject 2: " + s2);
                report.AppendLine("Subject 3: " + s3);
                report.AppendLine("Average: " + avg);
            }
            else if (reportType == "Enrollment Report")
            {
                report.AppendLine("Course 1: Programming 1");
                report.AppendLine("Course 2: Database Systems");
                report.AppendLine("Semester: Semester 1");
            }
            else
            {
                report.AppendLine("No report type selected.");
            }

            txtReportOutput.Text = report.ToString();
            btnGenerateReport.Enabled = true;
        }

        private void btnClearReport_Click(object sender, EventArgs e)
        {
            cmbReportType.SelectedIndex = -1;
            txtReportStudentId.Clear();
            txtReportOutput.Clear();
            txtReportStudentId.Focus();
        }

        private void btnBackReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
