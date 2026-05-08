namespace ULMSWinFormsApp.Forms
{
    partial class FrmCourseEnrollment
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
            txtEnrollStudentId = new TextBox();
            txtEnrollStudentName = new TextBox();
            label3 = new Label();
            cmbCourse = new ComboBox();
            label4 = new Label();
            cmbSemester = new ComboBox();
            btnEnroll = new Button();
            btnClearEnrollment = new Button();
            btnBackEnrollment = new Button();
            txtEnrollmentOutput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 42);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 32);
            label1.TabIndex = 0;
            label1.Text = "Student ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 120);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(168, 32);
            label2.TabIndex = 1;
            label2.Text = "Student Name";
            // 
            // txtEnrollStudentId
            // 
            txtEnrollStudentId.Location = new Point(286, 42);
            txtEnrollStudentId.Margin = new Padding(5, 5, 5, 5);
            txtEnrollStudentId.Name = "txtEnrollStudentId";
            txtEnrollStudentId.Size = new Size(362, 39);
            txtEnrollStudentId.TabIndex = 2;
            // 
            // txtEnrollStudentName
            // 
            txtEnrollStudentName.Location = new Point(286, 120);
            txtEnrollStudentName.Margin = new Padding(5, 5, 5, 5);
            txtEnrollStudentName.Name = "txtEnrollStudentName";
            txtEnrollStudentName.Size = new Size(362, 39);
            txtEnrollStudentName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 227);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(88, 32);
            label3.TabIndex = 4;
            label3.Text = "Course";
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Items.AddRange(new object[] { "Programming 1", "Database Systems", "Web Development", "", "Software Testing" });
            cmbCourse.Location = new Point(286, 227);
            cmbCourse.Margin = new Padding(5, 5, 5, 5);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(362, 40);
            cmbCourse.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(89, 322);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(113, 32);
            label4.TabIndex = 6;
            label4.Text = "Semester";
            // 
            // cmbSemester
            // 
            cmbSemester.FormattingEnabled = true;
            cmbSemester.Items.AddRange(new object[] { "Semester 1", "", "Semester 2" });
            cmbSemester.Location = new Point(278, 330);
            cmbSemester.Margin = new Padding(5, 5, 5, 5);
            cmbSemester.Name = "cmbSemester";
            cmbSemester.Size = new Size(370, 40);
            cmbSemester.TabIndex = 7;
            // 
            // btnEnroll
            // 
            btnEnroll.Location = new Point(249, 459);
            btnEnroll.Margin = new Padding(5, 5, 5, 5);
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Size = new Size(214, 75);
            btnEnroll.TabIndex = 8;
            btnEnroll.Text = "Enroll Student";
            btnEnroll.UseVisualStyleBackColor = true;
            btnEnroll.Click += btnEnroll_Click;
            // 
            // btnClearEnrollment
            // 
            btnClearEnrollment.Location = new Point(502, 459);
            btnClearEnrollment.Margin = new Padding(5, 5, 5, 5);
            btnClearEnrollment.Name = "btnClearEnrollment";
            btnClearEnrollment.Size = new Size(214, 75);
            btnClearEnrollment.TabIndex = 9;
            btnClearEnrollment.Text = "Clear";
            btnClearEnrollment.UseVisualStyleBackColor = true;
            btnClearEnrollment.Click += btnClearEnrollment_Click;
            // 
            // btnBackEnrollment
            // 
            btnBackEnrollment.Location = new Point(769, 459);
            btnBackEnrollment.Margin = new Padding(5, 5, 5, 5);
            btnBackEnrollment.Name = "btnBackEnrollment";
            btnBackEnrollment.Size = new Size(214, 75);
            btnBackEnrollment.TabIndex = 10;
            btnBackEnrollment.Text = "Back";
            btnBackEnrollment.UseVisualStyleBackColor = true;
            btnBackEnrollment.Click += btnBackEnrollment_Click;
            // 
            // txtEnrollmentOutput
            // 
            txtEnrollmentOutput.Location = new Point(769, 37);
            txtEnrollmentOutput.Margin = new Padding(5, 5, 5, 5);
            txtEnrollmentOutput.Multiline = true;
            txtEnrollmentOutput.Name = "txtEnrollmentOutput";
            txtEnrollmentOutput.ReadOnly = true;
            txtEnrollmentOutput.Size = new Size(574, 361);
            txtEnrollmentOutput.TabIndex = 11;
            // 
            // FrmCourseEnrollment
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1433, 725);
            Controls.Add(txtEnrollmentOutput);
            Controls.Add(btnBackEnrollment);
            Controls.Add(btnClearEnrollment);
            Controls.Add(btnEnroll);
            Controls.Add(cmbSemester);
            Controls.Add(label4);
            Controls.Add(cmbCourse);
            Controls.Add(label3);
            Controls.Add(txtEnrollStudentName);
            Controls.Add(txtEnrollStudentId);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "FrmCourseEnrollment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Umoja Learning Management System - Course Enrolment";
            Load += FrmCourseEnrollment_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtEnrollStudentId;
        private TextBox txtEnrollStudentName;
        private Label label3;
        private ComboBox cmbCourse;
        private Label label4;
        private ComboBox cmbSemester;
        private Button btnEnroll;
        private Button btnClearEnrollment;
        private Button btnBackEnrollment;
        private TextBox txtEnrollmentOutput;
    }
}