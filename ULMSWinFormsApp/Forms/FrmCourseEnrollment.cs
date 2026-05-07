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
        }

        // BUG-02 FIX: Track enrolments in a list so duplicates can be detected
        private static List<Enrollment> _enrollments = new List<Enrollment>();

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            // BUG-02 FIX: Validate that required fields are not empty
            if (string.IsNullOrWhiteSpace(txtEnrollStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtEnrollStudentName.Text) ||
                string.IsNullOrWhiteSpace(cmbCourse.Text) ||
                string.IsNullOrWhiteSpace(cmbSemester.Text))
            {
                MessageBox.Show("All fields are required before enrolling.",
                                "Validation Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string studentId = txtEnrollStudentId.Text.Trim();
            string courseName = cmbCourse.Text.Trim();

            // BUG-02 FIX: Check for duplicate enrolment before adding
            bool alreadyEnrolled = _enrollments.Exists(e =>
                e.StudentId == studentId && e.CourseName == courseName);

            if (alreadyEnrolled)
            {
                MessageBox.Show("This student is already enrolled in the selected course.",
                                "Duplicate Enrolment", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            Enrollment enrollment = new Enrollment
            {
                StudentId = studentId,
                StudentName = txtEnrollStudentName.Text.Trim(),
                CourseName = courseName,
                Semester = cmbSemester.Text.Trim()
            };

            _enrollments.Add(enrollment);

            txtEnrollmentOutput.Text =
                "Enrollment completed successfully!" + Environment.NewLine +
                "Student ID: " + enrollment.StudentId + Environment.NewLine +
                "Student Name: " + enrollment.StudentName + Environment.NewLine +
                "Course: " + enrollment.CourseName + Environment.NewLine +
                "Semester: " + enrollment.Semester;
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



    }
}
