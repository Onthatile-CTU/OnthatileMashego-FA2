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
    public partial class FrmMarksCapture : Form
    {
        public FrmMarksCapture()
        {
            InitializeComponent();
        }

        private void btnCalculateResults_Click(object sender, EventArgs e)
        {
            // BUG-03 FIX: Validate that all mark fields contain numeric values
            if (!double.TryParse(txtSubject1.Text, out double subject1) ||
                !double.TryParse(txtSubject2.Text, out double subject2) ||
                !double.TryParse(txtSubject3.Text, out double subject3))
            {
                MessageBox.Show("Please enter valid numeric values for all subjects.",
                                "Invalid Input", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // BUG-03 FIX: Validate mark range (0 to 100) for each subject
            if (subject1 < 0 || subject1 > 100 ||
                subject2 < 0 || subject2 > 100 ||
                subject3 < 0 || subject3 > 100)
            {
                MessageBox.Show("All marks must be between 0 and 100.",
                                "Out of Range", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // BUG-03 FIX: Validate Student ID and Name are not empty
            if (string.IsNullOrWhiteSpace(txtMarkStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtMarkStudentName.Text))
            {
                MessageBox.Show("Student ID and Name are required.",
                                "Validation Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            MarkRecord record = new MarkRecord();

            record.StudentId = txtMarkStudentId.Text.Trim();
            record.StudentName = txtMarkStudentName.Text.Trim();
            record.Subject1 = subject1;
            record.Subject2 = subject2;
            record.Subject3 = subject3;

            // BUG-04 FIX: Corrected average calculation.
            // Original faulty line: record.Subject1 + record.Subject2 + record.Subject3 / 3
            // Due to operator precedence, only Subject3 was divided by 3, not the total.
            // Fix: wrap the sum in parentheses so all three are summed before dividing.
            record.Average = (record.Subject1 + record.Subject2 + record.Subject3) / 3;

            if (record.Average >= 50)
            {
                record.ResultStatus = "PASS";
            }
            else
            {
                record.ResultStatus = "FAIL";
            }

            txtMarksOutput.Text =
                "Marks processed successfully!" + Environment.NewLine +
                "Student ID: " + record.StudentId + Environment.NewLine +
                "Student Name: " + record.StudentName + Environment.NewLine +
                "Subject 1: " + record.Subject1 + Environment.NewLine +
                "Subject 2: " + record.Subject2 + Environment.NewLine +
                "Subject 3: " + record.Subject3 + Environment.NewLine +
                "Average: " + Math.Round(record.Average, 2) + Environment.NewLine +
                "Final Result: " + record.ResultStatus;
        }

        private void btnClearMarks_Click(object sender, EventArgs e)
        {
            txtMarkStudentId.Clear();
            txtMarkStudentName.Clear();
            txtSubject1.Clear();
            txtSubject2.Clear();
            txtSubject3.Clear();
            txtMarksOutput.Clear();
            txtMarkStudentId.Focus();
        }

        private void btnBackMarks_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
