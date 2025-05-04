namespace Enrollment_System
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnStudentEntry = new System.Windows.Forms.Button();
            this.btnEnrollSubjects = new System.Windows.Forms.Button();
            this.btnViewStudents = new System.Windows.Forms.Button();
            this.btnManageSubjects = new System.Windows.Forms.Button();
            this.btnSubjectSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(213, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enrollment System";
            // 
            // btnStudentEntry
            // 
            this.btnStudentEntry.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStudentEntry.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentEntry.ForeColor = System.Drawing.Color.White;
            this.btnStudentEntry.Location = new System.Drawing.Point(133, 261);
            this.btnStudentEntry.Name = "btnStudentEntry";
            this.btnStudentEntry.Size = new System.Drawing.Size(118, 58);
            this.btnStudentEntry.TabIndex = 1;
            this.btnStudentEntry.Text = "Student Entry";
            this.btnStudentEntry.UseVisualStyleBackColor = false;
            this.btnStudentEntry.Click += new System.EventHandler(this.btnStudentEntry_Click);
            // 
            // btnEnrollSubjects
            // 
            this.btnEnrollSubjects.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnrollSubjects.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnrollSubjects.ForeColor = System.Drawing.Color.White;
            this.btnEnrollSubjects.Location = new System.Drawing.Point(312, 263);
            this.btnEnrollSubjects.Name = "btnEnrollSubjects";
            this.btnEnrollSubjects.Size = new System.Drawing.Size(118, 56);
            this.btnEnrollSubjects.TabIndex = 2;
            this.btnEnrollSubjects.Text = "Enroll Subjects";
            this.btnEnrollSubjects.UseVisualStyleBackColor = false;
            this.btnEnrollSubjects.Click += new System.EventHandler(this.btnEnrollSubjects_Click);
            // 
            // btnViewStudents
            // 
            this.btnViewStudents.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnViewStudents.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStudents.ForeColor = System.Drawing.Color.White;
            this.btnViewStudents.Location = new System.Drawing.Point(481, 263);
            this.btnViewStudents.Name = "btnViewStudents";
            this.btnViewStudents.Size = new System.Drawing.Size(118, 56);
            this.btnViewStudents.TabIndex = 3;
            this.btnViewStudents.Text = "Student List";
            this.btnViewStudents.UseVisualStyleBackColor = false;
            this.btnViewStudents.Click += new System.EventHandler(this.btnViewStudents_Click);
            // 
            // btnManageSubjects
            // 
            this.btnManageSubjects.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnManageSubjects.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageSubjects.ForeColor = System.Drawing.Color.White;
            this.btnManageSubjects.Location = new System.Drawing.Point(221, 354);
            this.btnManageSubjects.Name = "btnManageSubjects";
            this.btnManageSubjects.Size = new System.Drawing.Size(118, 56);
            this.btnManageSubjects.TabIndex = 4;
            this.btnManageSubjects.Text = "Manage Subjects";
            this.btnManageSubjects.UseVisualStyleBackColor = false;
            this.btnManageSubjects.Click += new System.EventHandler(this.btnManageSubjects_Click);
            // 
            // btnSubjectSchedule
            // 
            this.btnSubjectSchedule.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSubjectSchedule.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubjectSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSubjectSchedule.Location = new System.Drawing.Point(410, 354);
            this.btnSubjectSchedule.Name = "btnSubjectSchedule";
            this.btnSubjectSchedule.Size = new System.Drawing.Size(118, 56);
            this.btnSubjectSchedule.TabIndex = 5;
            this.btnSubjectSchedule.Text = "Subject Schedule";
            this.btnSubjectSchedule.UseVisualStyleBackColor = false;
            this.btnSubjectSchedule.Click += new System.EventHandler(this.btnSubjectSchedule_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSubjectSchedule);
            this.Controls.Add(this.btnManageSubjects);
            this.Controls.Add(this.btnViewStudents);
            this.Controls.Add(this.btnEnrollSubjects);
            this.Controls.Add(this.btnStudentEntry);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStudentEntry;
        private System.Windows.Forms.Button btnEnrollSubjects;
        private System.Windows.Forms.Button btnViewStudents;
        private System.Windows.Forms.Button btnManageSubjects;
        private System.Windows.Forms.Button btnSubjectSchedule;
    }
}