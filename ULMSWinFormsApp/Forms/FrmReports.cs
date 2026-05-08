using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmReports : Form
    {
        public FrmReports()
        {
            InitializeComponent();
            LockDropdownsToListOnly();
        }

        // FIX: Prevent typed input in ComboBoxes — DropDownList makes combo read-only.
        private void LockDropdownsToListOnly()
        {
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // ── Generate Report ──────────────────────────────────────────────────

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // ── Validation ───────────────────────────────────────────────────

            // BUG-05 FIX: Validate report type selection before proceeding
            if (string.IsNullOrWhiteSpace(cmbReportType.Text))
            {
                MessageBox.Show("Please select a report type.",
                                "Validation Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // BUG-10 FIX: Student ID must not be empty
            string studentId = txtReportStudentId.Text.Trim().ToUpper();
            if (string.IsNullOrWhiteSpace(studentId))
            {
                MessageBox.Show("A valid Student ID is required to generate a report.",
                                "Validation Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // BUG-10 FIX: Student must exist in the shared StudentStore
            if (!StudentStore.TryGetStudentById(studentId, out Student student))
            {
                MessageBox.Show($"No registered student found with ID '{studentId}'.\n" +
                                "Reports can only be generated for registered students.",
                                "Student Not Found", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // ── Async report generation ──────────────────────────────────────

            string reportType = cmbReportType.Text;

            // BUG-05 FIX: Keep UI responsive — disable button and show status
            // while report builds on a background thread via Task.Run.
            btnGenerateReport.Enabled = false;
            txtReportOutput.Text = "Generating report, please wait...";

            // BUG-05 FIX: Replaced synchronous UI-thread work with await Task.Run
            // so the message loop stays alive during report construction.
            string report = await Task.Run(() => BuildReport(reportType, student));

            txtReportOutput.Text = report;
            btnGenerateReport.Enabled = true;
        }

        // ── Report builder — runs on background thread ───────────────────────

        private static string BuildReport(string reportType, Student student)
        {
            var sb = new StringBuilder();

            sb.AppendLine("===== ULMS REPORT =====");
            sb.AppendLine("Report Type : " + reportType);
            sb.AppendLine("Student ID  : " + student.StudentId);
            sb.AppendLine("Full Name   : " + student.FullName);
            sb.AppendLine("Email       : " + student.Email);
            sb.AppendLine("Age         : " + student.Age);
            sb.AppendLine("Programme   : " + student.Programme);
            sb.AppendLine("Generated On: " + DateTime.Now);
            sb.AppendLine();

            if (reportType == "Student Summary Report")
            {
                sb.AppendLine("──── Student Profile ────");
                sb.AppendLine("Name      : " + student.FullName);
                sb.AppendLine("Email     : " + student.Email);
                sb.AppendLine("Age       : " + student.Age);
                sb.AppendLine("Programme : " + student.Programme);
                sb.AppendLine("Status    : Active");
            }
            else if (reportType == "Marks Report")
            {
                sb.AppendLine("──── Marks ────");

                // Pull the student's MarkRecord from StudentStore
                MarkRecord record = StudentStore.GetMarks(student.StudentId);

                if (record == null)
                {
                    sb.AppendLine("No marks captured for this student.");
                }
                else
                {
                    sb.AppendLine($"  Subject 1 : {record.Subject1}/100");
                    sb.AppendLine($"  Subject 2 : {record.Subject2}/100");
                    sb.AppendLine($"  Subject 3 : {record.Subject3}/100");
                    sb.AppendLine();

                    // BUG-04 FIX: Recalculate average from actual subject values
                    // rather than trusting the stored Average field, which may have
                    // been set by the original off-by-one loop.
                    double avg = Math.Round(
                        (record.Subject1 + record.Subject2 + record.Subject3) / 3.0, 2);

                    sb.AppendLine($"  Average   : {avg}%");
                    sb.AppendLine($"  Result    : {record.ResultStatus}");
                }
            }
            else if (reportType == "Enrollment Report")
            {
                sb.AppendLine("──── Enrolled Courses ────");

                var enrolments = StudentStore.GetEnrolments(student.StudentId);

                if (enrolments.Count == 0)
                {
                    sb.AppendLine("  No courses enrolled for this student.");
                }
                else
                {
                    foreach (var en in enrolments)
                        sb.AppendLine($"  • {en.CourseName,-35} [{en.Semester}]");
                }
            }
            else
            {
                sb.AppendLine("No recognised report type selected.");
            }

            sb.AppendLine();
            sb.AppendLine("===== END OF REPORT =====");
            return sb.ToString();
        }

        // ── Clear ─────────────────────────────────────────────────────────────

        private void btnClearReport_Click(object sender, EventArgs e)
        {
            cmbReportType.SelectedIndex = -1;
            txtReportStudentId.Clear();
            txtReportOutput.Clear();
            txtReportStudentId.Focus();
        }

        // ── Back ──────────────────────────────────────────────────────────────

        private void btnBackReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}