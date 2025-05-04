namespace Enrollment_System
{
    partial class SubjectForm
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
            this.txtCourseCode = new System.Windows.Forms.TextBox();
            this.txtSubjectDesc = new System.Windows.Forms.TextBox();
            this.txtSubjCode = new System.Windows.Forms.TextBox();
            this.txtCurriculumCode = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbOffering = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.numUnits = new System.Windows.Forms.NumericUpDown();
            this.grpBoxSubj = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvRelationships = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpRelationships = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddRelationship = new System.Windows.Forms.Button();
            this.rbCorequisite = new System.Windows.Forms.RadioButton();
            this.rbPrerequisite = new System.Windows.Forms.RadioButton();
            this.txtMainEDP = new System.Windows.Forms.TextBox();
            this.labelEDP = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUnits)).BeginInit();
            this.grpBoxSubj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationships)).BeginInit();
            this.grpRelationships.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCourseCode
            // 
            this.txtCourseCode.Location = new System.Drawing.Point(41, 239);
            this.txtCourseCode.Name = "txtCourseCode";
            this.txtCourseCode.Size = new System.Drawing.Size(136, 20);
            this.txtCourseCode.TabIndex = 0;
            // 
            // txtSubjectDesc
            // 
            this.txtSubjectDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubjectDesc.Location = new System.Drawing.Point(41, 157);
            this.txtSubjectDesc.Multiline = true;
            this.txtSubjectDesc.Name = "txtSubjectDesc";
            this.txtSubjectDesc.Size = new System.Drawing.Size(136, 20);
            this.txtSubjectDesc.TabIndex = 2;
            // 
            // txtSubjCode
            // 
            this.txtSubjCode.Location = new System.Drawing.Point(41, 72);
            this.txtSubjCode.Name = "txtSubjCode";
            this.txtSubjCode.Size = new System.Drawing.Size(136, 20);
            this.txtSubjCode.TabIndex = 3;
            // 
            // txtCurriculumCode
            // 
            this.txtCurriculumCode.Location = new System.Drawing.Point(39, 331);
            this.txtCurriculumCode.Name = "txtCurriculumCode";
            this.txtCurriculumCode.Size = new System.Drawing.Size(136, 20);
            this.txtCurriculumCode.TabIndex = 4;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(236, 289);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(132, 21);
            this.cmbStatus.TabIndex = 5;
            // 
            // cmbOffering
            // 
            this.cmbOffering.FormattingEnabled = true;
            this.cmbOffering.Location = new System.Drawing.Point(236, 117);
            this.cmbOffering.Name = "cmbOffering";
            this.cmbOffering.Size = new System.Drawing.Size(132, 21);
            this.cmbOffering.TabIndex = 6;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(236, 197);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(132, 21);
            this.cmbCategory.TabIndex = 7;
            // 
            // numUnits
            // 
            this.numUnits.Location = new System.Drawing.Point(419, 197);
            this.numUnits.Name = "numUnits";
            this.numUnits.Size = new System.Drawing.Size(122, 20);
            this.numUnits.TabIndex = 8;
            // 
            // grpBoxSubj
            // 
            this.grpBoxSubj.Controls.Add(this.label8);
            this.grpBoxSubj.Controls.Add(this.btnClear);
            this.grpBoxSubj.Controls.Add(this.txtSubjCode);
            this.grpBoxSubj.Controls.Add(this.btnSave);
            this.grpBoxSubj.Controls.Add(this.label7);
            this.grpBoxSubj.Controls.Add(this.numUnits);
            this.grpBoxSubj.Controls.Add(this.label6);
            this.grpBoxSubj.Controls.Add(this.cmbStatus);
            this.grpBoxSubj.Controls.Add(this.label5);
            this.grpBoxSubj.Controls.Add(this.cmbCategory);
            this.grpBoxSubj.Controls.Add(this.label4);
            this.grpBoxSubj.Controls.Add(this.txtSubjectDesc);
            this.grpBoxSubj.Controls.Add(this.label3);
            this.grpBoxSubj.Controls.Add(this.txtCourseCode);
            this.grpBoxSubj.Controls.Add(this.label1);
            this.grpBoxSubj.Controls.Add(this.label2);
            this.grpBoxSubj.Controls.Add(this.txtCurriculumCode);
            this.grpBoxSubj.Controls.Add(this.cmbOffering);
            this.grpBoxSubj.Location = new System.Drawing.Point(274, 12);
            this.grpBoxSubj.Name = "grpBoxSubj";
            this.grpBoxSubj.Size = new System.Drawing.Size(569, 371);
            this.grpBoxSubj.TabIndex = 9;
            this.grpBoxSubj.TabStop = false;
            this.grpBoxSubj.Text = "groupBox1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(416, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "NO. OF UNITS:";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(422, 311);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(92, 34);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(422, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 34);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(233, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "STATUS:\r\n";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(233, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "CATEGORY:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(233, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "REGULAR OFFERING:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "CURRICULUM CODE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "COURSE CODE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "SUBJ CODE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "DESCRIPTION:";
            // 
            // dgvRelationships
            // 
            this.dgvRelationships.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelationships.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvRelationships.Location = new System.Drawing.Point(308, 88);
            this.dgvRelationships.Name = "dgvRelationships";
            this.dgvRelationships.Size = new System.Drawing.Size(449, 180);
            this.dgvRelationships.TabIndex = 12;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Subject Code";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Description";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Units";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Pre/Co";
            this.Column4.Name = "Column4";
            // 
            // grpRelationships
            // 
            this.grpRelationships.Controls.Add(this.btnSearch);
            this.grpRelationships.Controls.Add(this.btnAddRelationship);
            this.grpRelationships.Controls.Add(this.rbCorequisite);
            this.grpRelationships.Controls.Add(this.rbPrerequisite);
            this.grpRelationships.Controls.Add(this.txtMainEDP);
            this.grpRelationships.Controls.Add(this.labelEDP);
            this.grpRelationships.Controls.Add(this.dgvRelationships);
            this.grpRelationships.Location = new System.Drawing.Point(175, 389);
            this.grpRelationships.Name = "grpRelationships";
            this.grpRelationships.Size = new System.Drawing.Size(768, 295);
            this.grpRelationships.TabIndex = 13;
            this.grpRelationships.TabStop = false;
            this.grpRelationships.Text = "Subject Requisites";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(148, 210);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 33);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAddRelationship
            // 
            this.btnAddRelationship.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRelationship.Location = new System.Drawing.Point(496, 42);
            this.btnAddRelationship.Name = "btnAddRelationship";
            this.btnAddRelationship.Size = new System.Drawing.Size(90, 33);
            this.btnAddRelationship.TabIndex = 17;
            this.btnAddRelationship.Text = "Add";
            this.btnAddRelationship.UseVisualStyleBackColor = true;
            // 
            // rbCorequisite
            // 
            this.rbCorequisite.AutoSize = true;
            this.rbCorequisite.Location = new System.Drawing.Point(376, 51);
            this.rbCorequisite.Name = "rbCorequisite";
            this.rbCorequisite.Size = new System.Drawing.Size(77, 17);
            this.rbCorequisite.TabIndex = 16;
            this.rbCorequisite.TabStop = true;
            this.rbCorequisite.Text = "Corequisite";
            this.rbCorequisite.UseVisualStyleBackColor = true;
            // 
            // rbPrerequisite
            // 
            this.rbPrerequisite.AutoSize = true;
            this.rbPrerequisite.Location = new System.Drawing.Point(240, 51);
            this.rbPrerequisite.Name = "rbPrerequisite";
            this.rbPrerequisite.Size = new System.Drawing.Size(80, 17);
            this.rbPrerequisite.TabIndex = 15;
            this.rbPrerequisite.TabStop = true;
            this.rbPrerequisite.Text = "Prerequisite";
            this.rbPrerequisite.UseVisualStyleBackColor = true;
            // 
            // txtMainEDP
            // 
            this.txtMainEDP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMainEDP.Location = new System.Drawing.Point(110, 144);
            this.txtMainEDP.Name = "txtMainEDP";
            this.txtMainEDP.Size = new System.Drawing.Size(166, 25);
            this.txtMainEDP.TabIndex = 14;
            // 
            // labelEDP
            // 
            this.labelEDP.AutoSize = true;
            this.labelEDP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEDP.Location = new System.Drawing.Point(23, 147);
            this.labelEDP.Name = "labelEDP";
            this.labelEDP.Size = new System.Drawing.Size(72, 17);
            this.labelEDP.TabIndex = 13;
            this.labelEDP.Text = "EDP Code:\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(881, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 136);
            this.label9.TabIndex = 17;
            this.label9.Text = "REGULAR OFFERING:\r\nex. 1 - First Sem, 2 - Second Sem, etc.\r\n\r\nCATEGORY:\r\nex. LEC " +
    "- Lecture, LAB - Laboratory\r\n\r\nSTATUS:\r\nex. AC - Active, IN -Inactive\r\n";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(904, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 187);
            this.label10.TabIndex = 18;
            this.label10.Text = "SUBJ CODE:\r\nex. CC-APPSDEV22\r\n\r\nDESCRIPTION:\r\nex. Applications Development\r\n\r\nCOU" +
    "RSE CODE:\r\nex. BSIT, BSIS, etc.\r\n\r\nCURRICULUM CODE:\r\nex AY2017";
            // 
            // SubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1142, 688);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grpRelationships);
            this.Controls.Add(this.grpBoxSubj);
            this.Name = "SubjectForm";
            this.Text = "SubjectForm";
            ((System.ComponentModel.ISupportInitialize)(this.numUnits)).EndInit();
            this.grpBoxSubj.ResumeLayout(false);
            this.grpBoxSubj.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationships)).EndInit();
            this.grpRelationships.ResumeLayout(false);
            this.grpRelationships.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCourseCode;
        private System.Windows.Forms.TextBox txtSubjectDesc;
        private System.Windows.Forms.TextBox txtSubjCode;
        private System.Windows.Forms.TextBox txtCurriculumCode;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbOffering;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.NumericUpDown numUnits;
        private System.Windows.Forms.GroupBox grpBoxSubj;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvRelationships;
        private System.Windows.Forms.GroupBox grpRelationships;
        private System.Windows.Forms.TextBox txtMainEDP;
        private System.Windows.Forms.Label labelEDP;
        private System.Windows.Forms.Button btnAddRelationship;
        private System.Windows.Forms.RadioButton rbCorequisite;
        private System.Windows.Forms.RadioButton rbPrerequisite;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}