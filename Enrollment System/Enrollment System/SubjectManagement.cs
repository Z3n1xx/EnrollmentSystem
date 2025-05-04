using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class SubjectManagement : Form
    {
        private TextBox txtSubjCode, txtDescription, txtCourseCode, txtCurrCode, txtEdpCode;
        private ComboBox cmbRegOffering, cmbCategory, cmbStatus;
        private NumericUpDown nudUnits;
        private Button btnSave, btnClear, btnSearch, btnAddReq;
        private DataGridView dgvRequisites;
        private RadioButton radPrerequisite, radCorequisite;
        private GroupBox groupBox1, groupBox2;

        public SubjectManagement()
        {
            InitializeComponent();
            InitializeUI();
            LoadInitialData();
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

            // Radio buttons for requisite type
            radPrerequisite = new RadioButton
            {
                Text = "Prerequisite",
                AutoSize = true,
                Margin = new Padding(5),
                Tag = "PR"
            };

            radCorequisite = new RadioButton
            {
                Text = "Corequisite",
                AutoSize = true,
                Margin = new Padding(5),
                Tag = "CR"
            };

            btnAddReq = CreateButton("Add", Color.FromArgb(40, 167, 69), Color.White);

            reqOptionPanel.Controls.Add(radPrerequisite);
            reqOptionPanel.Controls.Add(radCorequisite);
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
            dgvRequisites.Columns.Add("SubjectCode", "Subject Code");
            dgvRequisites.Columns.Add("RequisiteCode", "Requisite Code");
            dgvRequisites.Columns.Add("Units", "Units");
            dgvRequisites.Columns.Add("Type", "Pre/Co");
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

            // Event Handlers
            btnSave.Click += BtnSave_Click;
            btnClear.Click += BtnClear_Click;
            btnAddReq.Click += BtnAddReq_Click;
            btnSearch.Click += BtnSearch_Click;
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

        #region Database Operations
        private bool SaveSubject()
        {
            if (!ValidateSubject()) return false;

            try
            {
                using (OleDbConnection conn = Database.GetConnection()) // Using your class
                {
                    conn.Open();

                    string subjectSql = @"IF EXISTS (SELECT 1 FROM SubjectFile WHERE SFSUBJCODE = ?)
                                UPDATE SubjectFile SET 
                                    SFSUBJDESC = ?,
                                    SFSUBJUNITS = ?,
                                    SFSUBJREGOFRNG = ?,
                                    SFSUBJCATEGORY = ?,
                                    SFSUBJSTATUS = ?,
                                    SFSUBJCOURSECODE = ?,
                                    SFSUBJCURRCODE = ?
                                WHERE SFSUBJCODE = ?
                                ELSE
                                INSERT INTO SubjectFile 
                                (SFSUBJCODE, SFSUBJDESC, SFSUBJUNITS, SFSUBJREGOFRNG, 
                                 SFSUBJCATEGORY, SFSUBJSTATUS, SFSUBJCOURSECODE, SFSUBJCURRCODE)
                                VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(subjectSql, conn))
                    {
                        // Add parameters (both for update and insert cases)
                        cmd.Parameters.AddWithValue("@code", txtSubjCode.Text);
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                        // ... add all other parameters ...

                        cmd.ExecuteNonQuery();
                    }

                    SaveRequisites(conn); // Pass the open connection
                    return true;
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
                return false;
            }
        }

        private void SaveRequisites(OleDbConnection conn)
        {
            // Use the existing connection instead of creating a new one
            string deleteSql = "DELETE FROM SubjectPreqFile WHERE SUBJCODE = ?";
            using (OleDbCommand cmd = new OleDbCommand(deleteSql, conn))
            {
                cmd.Parameters.AddWithValue("@code", txtSubjCode.Text);
                cmd.ExecuteNonQuery();
            }

            // Insert new requisites using same connection
            string insertSql = "INSERT INTO SubjectPreqFile (SUBJCODE, SUBJPRECODE, SUBJCATEGORY) VALUES (?, ?, ?)";
            foreach (DataGridViewRow row in dgvRequisites.Rows)
            {
                using (OleDbCommand cmd = new OleDbCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@code", txtSubjCode.Text);
                    cmd.Parameters.AddWithValue("@precode", row.Cells["RequisiteCode"].Value);
                    cmd.Parameters.AddWithValue("@category", row.Cells["Type"].Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SearchSubject()
        {
            if (string.IsNullOrWhiteSpace(txtEdpCode.Text))
            {
                MessageBox.Show("Please enter an EDP Code to search", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string sql = "SELECT SFSUBJCODE, SFSUBJDESC, SFSUBJUNITS FROM SubjectFile WHERE SFSUBJCODE LIKE ? OR SFSUBJDESC LIKE ?";
                var dt = Database.GetData(
                    sql,
                    new OleDbParameter("@code", "%" + txtEdpCode.Text + "%"),
                    new OleDbParameter("@desc", "%" + txtEdpCode.Text + "%")
                );

                if (dt.Rows.Count > 0)
                {
                    var resultForm = new SearchResultsForm(dt);
                    if (resultForm.ShowDialog() == DialogResult.OK)
                    {
                        txtEdpCode.Text = resultForm.SelectedCode;
                    }
                }
                else
                {
                    MessageBox.Show("No matching subjects found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubject(string subjectCode)
        {
            try
            {
                string sql = "SELECT * FROM SubjectFile WHERE SFSUBJCODE = ?";
                var dt = Database.GetData(sql, new OleDbParameter("@code", subjectCode));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtSubjCode.Text = row["SFSUBJCODE"].ToString();
                    txtDescription.Text = row["SFSUBJDESC"].ToString();
                    nudUnits.Value = Convert.ToDecimal(row["SFSUBJUNITS"]);
                    cmbRegOffering.SelectedIndex = Convert.ToInt32(row["SFSUBJREGOFRNG"]) - 1;
                    cmbCategory.SelectedIndex = row["SFSUBJCATEGORY"].ToString() == "LEC" ? 0 : 1;
                    cmbStatus.SelectedIndex = row["SFSUBJSTATUS"].ToString() == "AC" ? 0 : 1;
                    txtCourseCode.Text = row["SFSUBJCOURSECODE"].ToString();
                    txtCurrCode.Text = row["SFSUBJCURRCODE"].ToString();

                    // Load requisites
                    LoadRequisites(subjectCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subject: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRequisites(string subjectCode)
        {
            try
            {
                dgvRequisites.Rows.Clear();
                string sql = "SELECT * FROM SubjectPreqFile WHERE SUBJCODE = ?";
                var dt = Database.GetData(sql, new OleDbParameter("@code", subjectCode));

                foreach (DataRow row in dt.Rows)
                {
                    dgvRequisites.Rows.Add(
                        row["SUBJCODE"],
                        row["SUBJPRECODE"],
                        "", // Units would need to be fetched from SubjectFile
                        row["SUBJCATEGORY"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading requisites: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Event Handlers
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveSubject())
            {
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
            if (string.IsNullOrWhiteSpace(txtSubjCode.Text))
            {
                MessageBox.Show("Please enter and save the subject first", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEdpCode.Text))
            {
                MessageBox.Show("Please enter an EDP Code", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!radPrerequisite.Checked && !radCorequisite.Checked)
            {
                MessageBox.Show("Please select requisite type", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string type = radPrerequisite.Checked ? "PR" : "CR";
            dgvRequisites.Rows.Add(txtSubjCode.Text, txtEdpCode.Text, nudUnits.Value, type);
            txtEdpCode.Clear();
            radPrerequisite.Checked = radCorequisite.Checked = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchSubject();
        }
        #endregion

        #region Utility Methods
        private bool ValidateSubject()
        {
            if (string.IsNullOrWhiteSpace(txtSubjCode.Text) || txtSubjCode.Text.StartsWith("ex."))
            {
                MessageBox.Show("Please enter a valid Subject Code", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubjCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text) || txtDescription.Text.StartsWith("ex."))
            {
                MessageBox.Show("Please enter a valid Description", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtSubjCode.Clear();
            txtDescription.Clear();
            txtCourseCode.Clear();
            txtCurrCode.Clear();
            txtEdpCode.Clear();
            cmbRegOffering.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            nudUnits.Value = 3;
            radPrerequisite.Checked = false;
            radCorequisite.Checked = false;
            dgvRequisites.Rows.Clear();
        }

        private void LoadInitialData()
        {
            cmbRegOffering.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            nudUnits.Value = 3;
        }
        #endregion
    }

    public class SearchResultsForm : Form
    {
        public string SelectedCode { get; private set; }

        public SearchResultsForm(DataTable results)
        {
            this.Text = "Search Results";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;

            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = results,
                ReadOnly = true,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            var btnSelect = new Button
            {
                Text = "Select",
                Dock = DockStyle.Bottom,
                DialogResult = DialogResult.OK
            };
            btnSelect.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    SelectedCode = dgv.SelectedRows[0].Cells["SFSUBJCODE"].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };

            this.Controls.Add(dgv);
            this.Controls.Add(btnSelect);
        }
    }
}

