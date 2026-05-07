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
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
        }


        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            // FIX: Validate required fields are not empty
            if (string.IsNullOrWhiteSpace(txtStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(cmbProgramme.Text))
            {
                MessageBox.Show("All fields are required.",
                                "Validation Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // FIX: Replaced int.Parse (crashes on invalid input) with int.TryParse
            if (!int.TryParse(txtAge.Text, out int age) || age < 1 || age > 120)
            {
                MessageBox.Show("Please enter a valid age (1-120).",
                                "Invalid Age", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            Student student = new Student
            {
                StudentId = txtStudentId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Age = age,
                Programme = cmbProgramme.Text
            };

            txtStudentOutput.Text =
                "Student saved successfully!" + Environment.NewLine +
                "Student ID: " + student.StudentId + Environment.NewLine +
                "Full Name: " + student.FullName + Environment.NewLine +
                "Email: " + student.Email + Environment.NewLine +
                "Age: " + student.Age + Environment.NewLine +
                "Programme: " + student.Programme;
        }

        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            cmbProgramme.SelectedIndex = -1;
            txtStudentOutput.Clear();
            txtStudentId.Focus();
        }

        //Add Back button to return to dashboard
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
