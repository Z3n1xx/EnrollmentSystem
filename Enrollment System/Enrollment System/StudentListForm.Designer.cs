namespace Enrollment_System
{
    partial class StudentListForm
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
			this.dgvStudents = new System.Windows.Forms.DataGridView();
			this.Refreshbtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvStudents
			// 
			this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStudents.Location = new System.Drawing.Point(28, 48);
			this.dgvStudents.Name = "dgvStudents";
			this.dgvStudents.Size = new System.Drawing.Size(648, 474);
			this.dgvStudents.TabIndex = 0;
			// 
			// Refreshbtn
			// 
			this.Refreshbtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Refreshbtn.Location = new System.Drawing.Point(735, 276);
			this.Refreshbtn.Name = "Refreshbtn";
			this.Refreshbtn.Size = new System.Drawing.Size(105, 45);
			this.Refreshbtn.TabIndex = 1;
			this.Refreshbtn.Text = "Refresh";
			this.Refreshbtn.UseVisualStyleBackColor = true;
			// 
			// StudentListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(894, 534);
			this.Controls.Add(this.Refreshbtn);
			this.Controls.Add(this.dgvStudents);
			this.Name = "StudentListForm";
			this.Text = "StudentListForm";
			this.Load += new System.EventHandler(this.StudentListForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button Refreshbtn;
    }
}