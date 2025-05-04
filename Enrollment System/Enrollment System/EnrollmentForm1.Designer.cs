namespace Enrollment_System
{
    partial class EnrollmentForm
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
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.dgvSubjects = new System.Windows.Forms.DataGridView();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.btnAddSubject = new System.Windows.Forms.Button();
            this.btnSaveEnrollment = new System.Windows.Forms.Button();
            this.EDP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStudentID
            // 
            this.txtStudentID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.Location = new System.Drawing.Point(29, 209);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(125, 25);
            this.txtStudentID.TabIndex = 0;
            this.txtStudentID.TextChanged += new System.EventHandler(this.txtStudentID_TextChanged);
            this.txtStudentID.Leave += new System.EventHandler(this.txtStudentID_Leave);
            // 
            // dgvSubjects
            // 
            this.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDP,
            this.Description});
            this.dgvSubjects.Location = new System.Drawing.Point(304, 62);
            this.dgvSubjects.Name = "dgvSubjects";
            this.dgvSubjects.Size = new System.Drawing.Size(726, 537);
            this.dgvSubjects.TabIndex = 1;
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStudentName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentName.Location = new System.Drawing.Point(178, 212);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(18, 17);
            this.lblStudentName.TabIndex = 2;
            this.lblStudentName.Text = "\"\"";
            // 
            // btnAddSubject
            // 
            this.btnAddSubject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSubject.Location = new System.Drawing.Point(38, 309);
            this.btnAddSubject.Name = "btnAddSubject";
            this.btnAddSubject.Size = new System.Drawing.Size(76, 34);
            this.btnAddSubject.TabIndex = 3;
            this.btnAddSubject.Text = "Add";
            this.btnAddSubject.UseVisualStyleBackColor = true;
            // 
            // btnSaveEnrollment
            // 
            this.btnSaveEnrollment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEnrollment.Location = new System.Drawing.Point(162, 309);
            this.btnSaveEnrollment.Name = "btnSaveEnrollment";
            this.btnSaveEnrollment.Size = new System.Drawing.Size(76, 34);
            this.btnSaveEnrollment.TabIndex = 4;
            this.btnSaveEnrollment.Text = "Save";
            this.btnSaveEnrollment.UseVisualStyleBackColor = true;
            this.btnSaveEnrollment.Click += new System.EventHandler(this.btnSaveEnrollment_Click);
            // 
            // EDP
            // 
            this.EDP.HeaderText = "EDPCode";
            this.EDP.Name = "EDP";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // EnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1042, 611);
            this.Controls.Add(this.btnSaveEnrollment);
            this.Controls.Add(this.btnAddSubject);
            this.Controls.Add(this.lblStudentName);
            this.Controls.Add(this.dgvSubjects);
            this.Controls.Add(this.txtStudentID);
            this.Name = "EnrollmentForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.EnrollmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.DataGridView dgvSubjects;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Button btnAddSubject;
        private System.Windows.Forms.Button btnSaveEnrollment;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}