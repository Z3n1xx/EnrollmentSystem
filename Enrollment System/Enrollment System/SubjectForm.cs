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
        }
        public static class Database
        {
            public static string ConnectionString => @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\seant\OneDrive\Documents\Works\2nd Year 2nd Sem\StudentInformationSystem.accdb"";";

            public static OleDbConnection GetConnection()
            {
                return new OleDbConnection(ConnectionString);
            }
        }

        private void InitializeUI()
        {
            // Form setup
            this.Text = "Subject Management";
            this.Size = new Size(850, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9);
            this.BackColor = Color.White;

            // Main layout container
            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(10),
                RowStyles = {
                    new RowStyle(SizeType.Absolute, 250), // Subject info
                    new RowStyle(SizeType.Percent, 100)    // Requisites
                }
            };
            this.Controls.Add(mainPanel);

            // 1. Subject Information Group
            groupBox1 = new GroupBox
            {
                Text = "Subject Information",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 70, 130)
            };
            mainPanel.Controls.Add(groupBox1, 0, 0);

            var subjectLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5,
                Padding = new Padding(10),
                Margin = new Padding(5)
            };
            groupBox1.Controls.Add(subjectLayout);

            // Row 1: Subject Code
            subjectLayout.Controls.Add(CreateLabel("SUBJ CODE:"), 0, 0);
            txtSubjCode = CreateTextBox("ex. CC-APPSDEV22");
            subjectLayout.Controls.Add(txtSubjCode, 1, 0);

            subjectLayout.Controls.Add(CreateLabel("REGULAR OFFERING:"), 2, 0);
            cmbRegOffering = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRegOffering.Items.AddRange(new[] { "1 - First Semester", "2 - Second Semester" });
            subjectLayout.Controls.Add(cmbRegOffering, 3, 0);

            // Row 2: Description
            subjectLayout.Controls.Add(CreateLabel("DESCRIPTION:"), 0, 1);
            txtDescription = CreateTextBox("ex. Applications Development");
            subjectLayout.Controls.Add(txtDescription, 1, 1);
            subjectLayout.SetColumnSpan(txtDescription, 3);

            // Row 3: Category and Units
            subjectLayout.Controls.Add(CreateLabel("CATEGORY:"), 0, 2);
            cmbCategory = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCategory.Items.AddRange(new[] { "LEC - Lecture", "LAB - Laboratory" });
            subjectLayout.Controls.Add(cmbCategory, 1, 2);

            subjectLayout.Controls.Add(CreateLabel("NO. OF UNITS:"), 2, 2);
            nudUnits = new NumericUpDown { Minimum = 1, Maximum = 10, Dock = DockStyle.Fill };
            subjectLayout.Controls.Add(nudUnits, 3, 2);

            // Row 4: Course Code and Status
            subjectLayout.Controls.Add(CreateLabel("COURSE CODE:"), 0, 3);
            txtCourseCode = CreateTextBox("ex. BSIT-2022");
            subjectLayout.Controls.Add(txtCourseCode, 1, 3);

            subjectLayout.Controls.Add(CreateLabel("STATUS:"), 2, 3);
            cmbStatus = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbStatus.Items.AddRange(new[] { "AC - Active", "IN - Inactive" });
            subjectLayout.Controls.Add(cmbStatus, 3, 3);

            // Row 5: Curriculum Code and Buttons
            subjectLayout.Controls.Add(CreateLabel("CURRICULUM CODE:"), 0, 4);
            txtCurrCode = CreateTextBox("ex. AY2022-2023");
            subjectLayout.Controls.Add(txtCurrCode, 1, 4);

            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true
            };
            btnSave = CreateButton("Save", Color.FromArgb(0, 123, 255), Color.White);
            btnClear = CreateButton("Clear", SystemColors.Control, SystemColors.ControlText);
            buttonPanel.Controls.Add(btnSave);
            buttonPanel.Controls.Add(btnClear);
            subjectLayout.Controls.Add(buttonPanel, 3, 4);

            // 2. Subject Requisites Group
            groupBox2 = new GroupBox
            {
                Text = "Subject Requisites",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 70, 130)
            };
            mainPanel.Controls.Add(groupBox2, 0, 1);

            var reqLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(10)
            };
            groupBox2.Controls.Add(reqLayout);

            // Requisite Options
            var reqOptionPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Height = 30
            };
            chkPrerequisite = new CheckBox { Text = "Prerequisite", AutoSize = true, Margin = new Padding(5) };
            chkCorequisite = new CheckBox { Text = "Corequisite", AutoSize = true, Margin = new Padding(5) };
            btnAddReq = CreateButton("Add", Color.FromArgb(40, 167, 69), Color.White);

            reqOptionPanel.Controls.Add(chkPrerequisite);
            reqOptionPanel.Controls.Add(chkCorequisite);
            reqOptionPanel.Controls.Add(btnAddReq);
            reqLayout.Controls.Add(reqOptionPanel, 0, 0);

            // Requisites DataGrid
            dgvRequisites = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            };
            reqLayout.Controls.Add(dgvRequisites, 0, 1);

            // Search Panel
            var searchPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Height = 30
            };
            searchPanel.Controls.Add(CreateLabel("EDP Code:"));
            txtEdpCode = CreateTextBox();
            txtEdpCode.Width = 150;
            searchPanel.Controls.Add(txtEdpCode);
            btnSearch = CreateButton("Search", Color.FromArgb(108, 117, 125), Color.White);
            searchPanel.Controls.Add(btnSearch);
            reqLayout.Controls.Add(searchPanel, 0, 2);

            // Configure Grid Columns
            dgvRequisites.Columns.Add("SubjectCode", "Subject Code");
            dgvRequisites.Columns.Add("Description", "Description");
            dgvRequisites.Columns.Add("Units", "Units");
            dgvRequisites.Columns.Add("Type", "Pre/Co");

            // Event Handlers
            btnSave.Click += BtnSave_Click;
            btnClear.Click += BtnClear_Click;
            btnAddReq.Click += BtnAddReq_Click;
            btnSearch.Click += BtnSearch_Click;
            chkPrerequisite.CheckedChanged += RequisiteCheckChanged;
            chkCorequisite.CheckedChanged += RequisiteCheckChanged;
        }

        #region Helper Methods
        private Label CreateLabel(string text)
        {
            return new Label { Text = text, TextAlign = ContentAlignment.MiddleRight, AutoSize = true };
        }

        private TextBox CreateTextBox(string placeholder = "")
        {
            var txt = new TextBox { Dock = DockStyle.Fill, Margin = new Padding(3) };
            if (!string.IsNullOrEmpty(placeholder))
            {
                txt.ForeColor = Color.Gray;
                txt.Text = placeholder;
                txt.Enter += (s, e) => { if (txt.Text == placeholder) { txt.Text = ""; txt.ForeColor = SystemColors.WindowText; } };
                txt.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = placeholder; txt.ForeColor = Color.Gray; } };
            }
            return txt;
        }

        private Button CreateButton(string text, Color backColor, Color foreColor)
        {
            return new Button
            {
                Text = text,
                Width = 80,
                BackColor = backColor,
                ForeColor = foreColor,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(5),
                Cursor = Cursors.Hand
            };
        }
        #endregion

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

        private void SubjectForm_Load(object sender, EventArgs e)
        {
            cmbOffering.Items.AddRange(new object[] { "1", "2" });
            cmbCategory.Items.AddRange(new object[] { "Lec", "Lab" });
            cmbStatus.Items.AddRange(new object[] { "AC", "IN" });

            cmbOffering.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = Database.GetConnection())
            {
                conn.Open();
                OleDbTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Insert Subject to SubjectFile
                    string insertSubjectQuery = @"INSERT INTO SubjectFile 
                (EDPCode, SubjCode, SubjDesc, SubjUnits, SubjCategory, SubjType)
                VALUES (?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(insertSubjectQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("?", txtSubjCode.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtSubjCode.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtSubjectDesc.Text.Trim());
                        cmd.Parameters.AddWithValue("?", (int)numUnits.Value);
                        cmd.Parameters.AddWithValue("?", cmbCategory.Text.Trim());
                        cmd.Parameters.AddWithValue("?", cmbType.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    // 2. Insert Prerequisites/Corequisites to SubjPreqFile
                    foreach (DataGridViewRow row in dgvRequisites.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string subjPreCode = row.Cells["SubjectCode"].Value?.ToString();
                        string category = row.Cells["PreCo"].Value?.ToString();

                        string insertRequisiteQuery = @"INSERT INTO SubjPreqFile 
                    (SubjCode, SubjPreCode, SubjCategory)
                    VALUES (?, ?, ?)";

                        using (OleDbCommand cmd = new OleDbCommand(insertRequisiteQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("?", txtSubjCode.Text.Trim()); // Main subject
                            cmd.Parameters.AddWithValue("?", subjPreCode);             // Prereq/coreq subject
                            cmd.Parameters.AddWithValue("?", category);               // PR or CR

                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Subject and requisites saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
            txtSubjCode.Clear();
            txtSubjectDesc.Clear();
            numUnits.Value = 0;
            cmbOffering.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            txtCourseCode.Clear();
            txtCurriculumCode.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all fields?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearFields();
            }
        }

        private void btnAddRelationship_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (!int.TryParse(txtMainEDP.Text.Trim(), out int mainEDP))
                {
                    MessageBox.Show("Please enter a valid EDP Code for the main subject.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txtRequisiteEDP.Text.Trim(), out int requisiteEDP))
                {
                    MessageBox.Show("Please enter a valid EDP Code for the requisite subject.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Insert into SubjPreqFile
                using (OleDbConnection conn = new OleDbConnection(Database.ConnectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO SubjectPreqFile (SUBJCODE, SUBJPRECODE, SUBJCATEGORY) VALUES (?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", mainEDP);
                        cmd.Parameters.AddWithValue("?", requisiteEDP);
                        cmd.Parameters.AddWithValue("?", category);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Requisite saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optional: Clear textboxes after saving
                txtMainEDP.Clear();
                txtRequisiteEDP.Clear();
                rbPrerequisite.Checked = false;
                rbCorequisite.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
    }
}
#endregion