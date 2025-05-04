using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Enrollment_System
{
    public partial class SubjectForm : Form
    {
        public SubjectForm()
        {
            InitializeComponent();
            InitializeUI();
            WireUpEventHandlers();
        }

        private void WireUpEventHandlers()
        {
            btnSave.Click += BtnSave_Click;
            btnClear.Click += BtnClear_Click;
            btnAddRelationship.Click += BtnAddReq_Click;
            btnSearch.Click += BtnSearch_Click;
            rbPrerequisite.CheckedChanged += RequisiteCheckChanged;
            rbCorequisite.CheckedChanged += RequisiteCheckChanged;
        }

        private void InitializeUI()
        {
            // Form setup
            this.Text = "Subject Management";
            this.Size = new Size(850, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9);
            this.BackColor = Color.White;

            // Configure ComboBoxes
            cmbOffering.Items.AddRange(new[] { "1 - First Semester", "2 - Second Semester" });
            cmbCategory.Items.AddRange(new[] { "LEC - Lecture", "LAB - Laboratory" });
            cmbStatus.Items.AddRange(new[] { "AC - Active", "IN - Inactive" });

            // Configure DataGridView
            dgvRelationships.Columns.Clear();
            dgvRelationships.Columns.Add("SubjectCode", "Subject Code");
            dgvRelationships.Columns.Add("Description", "Description");
            dgvRelationships.Columns.Add("Units", "Units");
            dgvRelationships.Columns.Add("Type", "Pre/Co");

            // Set initial values
            cmbOffering.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            numUnits.Value = 3;
        }

        #region Event Handlers
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateSubject())
            {
                SaveSubject();
                MessageBox.Show("Subject saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void BtnAddReq_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMainEDP.Text.Trim(), out int edpCode))
                {
                    MessageBox.Show("Please enter a valid EDP Code for the subject.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string category = "";
                if (rbPrerequisite.Checked)
                    category = "PR";
                else if (rbCorequisite.Checked)
                    category = "CR";
                else
                {
                    MessageBox.Show("Please select whether it's a Prerequisite or Corequisite.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert into SubjectPreqFile
                using (OleDbConnection conn = new OleDbConnection(Database.ConnectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO SubjectPreqFile (SUBJCODE, SUBJPRECODE, SUBJCATEGORY) VALUES (?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", txtSubjCode.Text.Trim());
                        cmd.Parameters.AddWithValue("?", edpCode);
                        cmd.Parameters.AddWithValue("?", category);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Requisite saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMainEDP.Clear();
                rbPrerequisite.Checked = false;
                rbCorequisite.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMainEDP.Text.Trim(), out int edpCode))
                {
                    MessageBox.Show("Please enter a valid EDP Code to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (OleDbConnection conn = new OleDbConnection(Database.ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT SFSUBJCODE, SFSUBJDESC, SFSUBJUNITS, SFSUBJCATEGORY FROM SubjectFile WHERE SFSUBJCODE = ?";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", edpCode);

                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvRelationships.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RequisiteCheckChanged(object sender, EventArgs e)
        {
            if (sender == rbPrerequisite && rbPrerequisite.Checked)
            {
                rbCorequisite.Checked = false;
            }
            else if (sender == rbCorequisite && rbCorequisite.Checked)
            {
                rbPrerequisite.Checked = false;
            }
        }
        #endregion

        #region Database Operations
        private bool ValidateSubject()
        {
            if (string.IsNullOrWhiteSpace(txtSubjCode.Text))
            {
                MessageBox.Show("Please enter a valid Subject Code", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubjCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSubjectDesc.Text))
            {
                MessageBox.Show("Please enter a valid Description", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubjectDesc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCourseCode.Text))
            {
                MessageBox.Show("Please enter a valid Course Code", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCourseCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCurriculumCode.Text))
            {
                MessageBox.Show("Please enter a valid Curriculum Code", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurriculumCode.Focus();
                return false;
            }

            return true;
        }

        private void SaveSubject()
        {
            using (OleDbConnection conn = Database.GetConnection())
            {
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Insert Subject to SubjectFile
                    string insertSubjectQuery = @"INSERT INTO SubjectFile 
                    (SFSUBJCODE, SFSUBJDESC, SFSUBJUNITS, SFSUBJREGOFRNG, 
                     SFSUBJCATEGORY, SFSUBJSTATUS, SFSUBJCOURSECODE, SFSUBJCURRCODE)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(insertSubjectQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("?", txtSubjCode.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtSubjectDesc.Text.Trim());
                        cmd.Parameters.AddWithValue("?", (int)numUnits.Value);
                        cmd.Parameters.AddWithValue("?", cmbOffering.SelectedIndex + 1);
                        cmd.Parameters.AddWithValue("?", cmbCategory.Text.Split('-')[0].Trim());
                        cmd.Parameters.AddWithValue("?", cmbStatus.Text.Split('-')[0].Trim());
                        cmd.Parameters.AddWithValue("?", txtCourseCode.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtCurriculumCode.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Subject saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            txtSubjCode.Clear();
            txtSubjectDesc.Clear();
            txtCourseCode.Clear();
            txtCurriculumCode.Clear();
            txtMainEDP.Clear();
            cmbOffering.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            numUnits.Value = 3;
            rbPrerequisite.Checked = false;
            rbCorequisite.Checked = false;
            dgvRelationships.Rows.Clear();
        }
        #endregion
    }
}