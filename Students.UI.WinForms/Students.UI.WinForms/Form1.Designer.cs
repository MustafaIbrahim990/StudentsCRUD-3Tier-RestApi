namespace Students.UI.WinForms
{
    partial class Form1
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
            this.btnGetAllStudents = new System.Windows.Forms.Button();
            this.btnGetPassedStudents = new System.Windows.Forms.Button();
            this.btnGetFailedStudents = new System.Windows.Forms.Button();
            this.btnGetAverageGrade = new System.Windows.Forms.Button();
            this.btnGetMaximumGrade = new System.Windows.Forms.Button();
            this.btnGetMinimumGrade = new System.Windows.Forms.Button();
            this.btnDoesStudentExist = new System.Windows.Forms.Button();
            this.btnGetStudentById = new System.Windows.Forms.Button();
            this.btnAddNewStudent = new System.Windows.Forms.Button();
            this.btnUpdateStudent = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.txtStudentID2 = new System.Windows.Forms.TextBox();
            this.txtStudentID3 = new System.Windows.Forms.TextBox();
            this.txtStudentID4 = new System.Windows.Forms.TextBox();
            this.txtStudentID1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetAllStudents
            // 
            this.btnGetAllStudents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetAllStudents.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAllStudents.Location = new System.Drawing.Point(97, 51);
            this.btnGetAllStudents.Name = "btnGetAllStudents";
            this.btnGetAllStudents.Size = new System.Drawing.Size(174, 43);
            this.btnGetAllStudents.TabIndex = 0;
            this.btnGetAllStudents.Text = "Get All Students";
            this.btnGetAllStudents.UseVisualStyleBackColor = true;
            this.btnGetAllStudents.Click += new System.EventHandler(this.btnGetAllStudents_Click);
            // 
            // btnGetPassedStudents
            // 
            this.btnGetPassedStudents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetPassedStudents.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPassedStudents.Location = new System.Drawing.Point(97, 140);
            this.btnGetPassedStudents.Name = "btnGetPassedStudents";
            this.btnGetPassedStudents.Size = new System.Drawing.Size(174, 43);
            this.btnGetPassedStudents.TabIndex = 1;
            this.btnGetPassedStudents.Text = "Get Passed Students";
            this.btnGetPassedStudents.UseVisualStyleBackColor = true;
            this.btnGetPassedStudents.Click += new System.EventHandler(this.btnGetPassedStudents_Click);
            // 
            // btnGetFailedStudents
            // 
            this.btnGetFailedStudents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetFailedStudents.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetFailedStudents.Location = new System.Drawing.Point(97, 229);
            this.btnGetFailedStudents.Name = "btnGetFailedStudents";
            this.btnGetFailedStudents.Size = new System.Drawing.Size(174, 43);
            this.btnGetFailedStudents.TabIndex = 2;
            this.btnGetFailedStudents.Text = "Get Failed Students";
            this.btnGetFailedStudents.UseVisualStyleBackColor = true;
            this.btnGetFailedStudents.Click += new System.EventHandler(this.btnGetFailedStudents_Click);
            // 
            // btnGetAverageGrade
            // 
            this.btnGetAverageGrade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetAverageGrade.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAverageGrade.Location = new System.Drawing.Point(97, 318);
            this.btnGetAverageGrade.Name = "btnGetAverageGrade";
            this.btnGetAverageGrade.Size = new System.Drawing.Size(174, 43);
            this.btnGetAverageGrade.TabIndex = 3;
            this.btnGetAverageGrade.Text = "Get Average Grade";
            this.btnGetAverageGrade.UseVisualStyleBackColor = true;
            this.btnGetAverageGrade.Click += new System.EventHandler(this.btnGetAverageGrade_Click);
            // 
            // btnGetMaximumGrade
            // 
            this.btnGetMaximumGrade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetMaximumGrade.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetMaximumGrade.Location = new System.Drawing.Point(97, 407);
            this.btnGetMaximumGrade.Name = "btnGetMaximumGrade";
            this.btnGetMaximumGrade.Size = new System.Drawing.Size(174, 43);
            this.btnGetMaximumGrade.TabIndex = 4;
            this.btnGetMaximumGrade.Text = "Get Maximum Grade";
            this.btnGetMaximumGrade.UseVisualStyleBackColor = true;
            this.btnGetMaximumGrade.Click += new System.EventHandler(this.btnGetMaximumGrade_Click);
            // 
            // btnGetMinimumGrade
            // 
            this.btnGetMinimumGrade.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetMinimumGrade.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetMinimumGrade.Location = new System.Drawing.Point(97, 496);
            this.btnGetMinimumGrade.Name = "btnGetMinimumGrade";
            this.btnGetMinimumGrade.Size = new System.Drawing.Size(174, 43);
            this.btnGetMinimumGrade.TabIndex = 5;
            this.btnGetMinimumGrade.Text = "Get Minimum Grade";
            this.btnGetMinimumGrade.UseVisualStyleBackColor = true;
            this.btnGetMinimumGrade.Click += new System.EventHandler(this.btnGetMinimumGrade_Click);
            // 
            // btnDoesStudentExist
            // 
            this.btnDoesStudentExist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDoesStudentExist.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoesStudentExist.Location = new System.Drawing.Point(532, 51);
            this.btnDoesStudentExist.Name = "btnDoesStudentExist";
            this.btnDoesStudentExist.Size = new System.Drawing.Size(174, 43);
            this.btnDoesStudentExist.TabIndex = 6;
            this.btnDoesStudentExist.Text = "Does Student Exist";
            this.btnDoesStudentExist.UseVisualStyleBackColor = true;
            this.btnDoesStudentExist.Click += new System.EventHandler(this.btnDoesStudentExist_Click);
            // 
            // btnGetStudentById
            // 
            this.btnGetStudentById.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetStudentById.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetStudentById.Location = new System.Drawing.Point(532, 140);
            this.btnGetStudentById.Name = "btnGetStudentById";
            this.btnGetStudentById.Size = new System.Drawing.Size(174, 43);
            this.btnGetStudentById.TabIndex = 7;
            this.btnGetStudentById.Text = "Get Student By Id";
            this.btnGetStudentById.UseVisualStyleBackColor = true;
            this.btnGetStudentById.Click += new System.EventHandler(this.btnGetStudentById_Click);
            // 
            // btnAddNewStudent
            // 
            this.btnAddNewStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewStudent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewStudent.Location = new System.Drawing.Point(532, 229);
            this.btnAddNewStudent.Name = "btnAddNewStudent";
            this.btnAddNewStudent.Size = new System.Drawing.Size(174, 43);
            this.btnAddNewStudent.TabIndex = 8;
            this.btnAddNewStudent.Text = "Add New Student";
            this.btnAddNewStudent.UseVisualStyleBackColor = true;
            this.btnAddNewStudent.Click += new System.EventHandler(this.btnAddNewStudent_Click);
            // 
            // btnUpdateStudent
            // 
            this.btnUpdateStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateStudent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStudent.Location = new System.Drawing.Point(532, 318);
            this.btnUpdateStudent.Name = "btnUpdateStudent";
            this.btnUpdateStudent.Size = new System.Drawing.Size(174, 43);
            this.btnUpdateStudent.TabIndex = 9;
            this.btnUpdateStudent.Text = "Update Student";
            this.btnUpdateStudent.UseVisualStyleBackColor = true;
            this.btnUpdateStudent.Click += new System.EventHandler(this.btnUpdateStudent_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteStudent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStudent.Location = new System.Drawing.Point(532, 407);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(174, 43);
            this.btnDeleteStudent.TabIndex = 10;
            this.btnDeleteStudent.Text = "Delete Student";
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // txtStudentID2
            // 
            this.txtStudentID2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudentID2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID2.Location = new System.Drawing.Point(761, 146);
            this.txtStudentID2.Multiline = true;
            this.txtStudentID2.Name = "txtStudentID2";
            this.txtStudentID2.Size = new System.Drawing.Size(205, 30);
            this.txtStudentID2.TabIndex = 11;
            // 
            // txtStudentID3
            // 
            this.txtStudentID3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudentID3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID3.Location = new System.Drawing.Point(761, 324);
            this.txtStudentID3.Multiline = true;
            this.txtStudentID3.Name = "txtStudentID3";
            this.txtStudentID3.Size = new System.Drawing.Size(205, 30);
            this.txtStudentID3.TabIndex = 12;
            // 
            // txtStudentID4
            // 
            this.txtStudentID4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudentID4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID4.Location = new System.Drawing.Point(761, 413);
            this.txtStudentID4.Multiline = true;
            this.txtStudentID4.Name = "txtStudentID4";
            this.txtStudentID4.Size = new System.Drawing.Size(205, 30);
            this.txtStudentID4.TabIndex = 13;
            // 
            // txtStudentID1
            // 
            this.txtStudentID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStudentID1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID1.Location = new System.Drawing.Point(761, 57);
            this.txtStudentID1.Multiline = true;
            this.txtStudentID1.Name = "txtStudentID1";
            this.txtStudentID1.Size = new System.Drawing.Size(205, 30);
            this.txtStudentID1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1058, 601);
            this.Controls.Add(this.txtStudentID1);
            this.Controls.Add(this.txtStudentID4);
            this.Controls.Add(this.txtStudentID3);
            this.Controls.Add(this.txtStudentID2);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.btnUpdateStudent);
            this.Controls.Add(this.btnAddNewStudent);
            this.Controls.Add(this.btnGetStudentById);
            this.Controls.Add(this.btnDoesStudentExist);
            this.Controls.Add(this.btnGetMinimumGrade);
            this.Controls.Add(this.btnGetMaximumGrade);
            this.Controls.Add(this.btnGetAverageGrade);
            this.Controls.Add(this.btnGetFailedStudents);
            this.Controls.Add(this.btnGetPassedStudents);
            this.Controls.Add(this.btnGetAllStudents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetAllStudents;
        private System.Windows.Forms.Button btnGetPassedStudents;
        private System.Windows.Forms.Button btnGetFailedStudents;
        private System.Windows.Forms.Button btnGetAverageGrade;
        private System.Windows.Forms.Button btnGetMaximumGrade;
        private System.Windows.Forms.Button btnGetMinimumGrade;
        private System.Windows.Forms.Button btnDoesStudentExist;
        private System.Windows.Forms.Button btnGetStudentById;
        private System.Windows.Forms.Button btnAddNewStudent;
        private System.Windows.Forms.Button btnUpdateStudent;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.TextBox txtStudentID2;
        private System.Windows.Forms.TextBox txtStudentID3;
        private System.Windows.Forms.TextBox txtStudentID4;
        private System.Windows.Forms.TextBox txtStudentID1;
    }
}

