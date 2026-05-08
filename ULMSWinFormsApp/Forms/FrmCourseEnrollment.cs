using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmCourseEnrollment : Form
    {
        public FrmCourseEnrollment()
        {
            InitializeComponent();
            LockDropdownsToListOnly();
        }

        // FIX: Prevent typed input in ComboBoxes
        // DropDownStyle.DropDownList makes the combo read-only at design time,
        //ENFORCES DROPDOWN
        private void LockDropdownsToListOnly()
        {
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSemester.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // BUG-02 FIX: Track enrolments in a list so duplicates can be detected
        private static List<Enrollment> _enrollments = new List<Enrollment>();

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            // BUG-02 FIX: Validate that required fields are not empty
            /*if (string.IsNullOrWhiteSpace(txtEnrollStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtEnrollStudentName.Text) ||
                string.IsNullOrWhiteSpace(cmbCourse.Text) ||
                string.IsNullOrWhiteSpace(cmbSemester.Text))
            {
                MessageBox.Show("All fields are required before enrolling.",
                                "Validation Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }*/

            if (string.IsNullOrWhiteSpace(txtEnrollStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtEnrollStudentName.Text) ||
                cmbCourse.SelectedIndex < 0 ||
                cmbSemester.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Please fill in Student ID, Student Name, and select both " +
                    "Course and Semester from the dropdown lists.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string studentId = txtEnrollStudentId.Text.Trim().ToUpper();
            string studentName = txtEnrollStudentName.Text.Trim();
            string courseName = cmbCourse.Text.Trim();
            string semester = cmbSemester.Text.Trim();

            // BUG-02 FIX: Check for duplicate enrolment before adding

            /*
            bool alreadyEnrolled = _enrollments.Exists(e =>
                e.StudentId == studentId && e.CourseName == courseName);

            if (alreadyEnrolled)
            {
                MessageBox.Show("This student is already enrolled in the selected course.",
                                "Duplicate Enrolment", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            */

            // FIX: Verify the student exists in the StudentStore 
            // ID AND Name must match what was used at registration.
            if (!StudentStore.TryGetStudent(studentId, studentName, out Student student))
            {
                MessageBox.Show(
                    $"No registered student found with ID '{studentId}' and " +
                    $"name '{studentName}'.\n\n" +
                    "Please register the student first, or check that the " +
                    "ID and name match exactly as registered.",
                    "Student Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // FIX: Duplicate enrolment check 
            if (StudentStore.IsEnrolled(studentId, courseName))
            {
                MessageBox.Show(
                    $"Student '{studentName}' is already enrolled in '{courseName}'.",
                    "Duplicate Enrolment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Enrollment enrollment = new Enrollment
            {
                StudentId = studentId,
                StudentName = student.FullName,
                CourseName = courseName,
                Semester = semester
            };

            //_enrollments.Add(enrollment);
            StudentStore.AddEnrolment(enrollment);

            /* txtEnrollmentOutput.Text =
                 "Enrollment completed successfully!" + Environment.NewLine +
                 "Student ID: " + enrollment.StudentId + Environment.NewLine +
                 "Student Name: " + enrollment.StudentName + Environment.NewLine +
                 "Course: " + enrollment.CourseName + Environment.NewLine +
                 "Semester: " + enrollment.Semester;*/

            // FIX: Show all enrolments for this student 
            var allEnrolments = StudentStore.GetEnrolments(studentId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("== Enrolment successful! ==");
            sb.AppendLine("──────────────────────────────────");
            sb.AppendLine($"Student ID   : {studentId}");
            sb.AppendLine($"Student Name : {student.FullName}");
            sb.AppendLine();
            sb.AppendLine("Enrolled Courses:");
            foreach (var e2 in allEnrolments)
                sb.AppendLine($"  • {e2.CourseName} — {e2.Semester}");

            txtEnrollmentOutput.Text = sb.ToString();
        }

        private void btnClearEnrollment_Click(object sender, EventArgs e)
        {
            txtEnrollStudentId.Clear();
            txtEnrollStudentName.Clear();
            cmbCourse.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            txtEnrollmentOutput.Clear();
            txtEnrollStudentId.Focus();
        }

        private void btnBackEnrollment_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCourseEnrollment_Load(object sender, EventArgs e)
        {
            // Code to run when the form loads
        }

        private void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
