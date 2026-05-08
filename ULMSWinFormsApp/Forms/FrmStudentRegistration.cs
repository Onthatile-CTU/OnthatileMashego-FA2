using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
            LockDropdownsToListOnly();
        }


        // FIX: Prevent typed input in ComboBoxes
        // DropDownStyle.DropDownList makes the combo read-only at design time,
        //ENFORCES DROPDOWN
        private void LockDropdownsToListOnly()
        {
            cmbProgramme.DropDownStyle = ComboBoxStyle.DropDownList;
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

            // FIX: Added Email format validation 
            // Must match: something@something.something (basic RFC-style check)
            string email = txtEmail.Text.Trim();
            bool emailValid = Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);

            if (!emailValid)
            {
                MessageBox.Show("Please enter a valid email address (e.g. student@example.com).",
                                "Invalid Email", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            //Building student object
            Student student = new Student
            {
                StudentId = txtStudentId.Text.Trim().ToUpper(),
                FullName = txtFullName.Text.Trim(),
                Email = email,
                Age = age,
                Programme = cmbProgramme.Text.Trim()
            };

            //FIX: Duplicate ID / duplicate email check via StudentStore 
            // StudentStore.TryRegisterStudent rejects:
            //   1. duplicate StudentId  (same ID already registered)
            //   2. duplicate Email      (same email already registered)
            if (!StudentStore.TryRegisterStudent(student, out string error))
            {
                MessageBox.Show(error, "Registration Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //SUCCESS
            txtStudentOutput.Text =
                "Student saved/registered successfully!" + Environment.NewLine +
                "──────────────────────────────────" + Environment.NewLine +
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

        private void FrmStudentRegistration_Load(object sender, EventArgs e)
        {
            // Code to run when the form loads
        }

    }
}
