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
    public partial class SubjectSched : Form
    {
        public SubjectSched()
        {
            InitializeComponent();
        }
        public static class Database
        {
            public static string ConnectionString => @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\seant\OneDrive\Documents\Works\2nd Year 2nd Sem\StudentInformationSystem.accdb"";";

            public static OleDbConnection GetConnection()
            {
                return new OleDbConnection(ConnectionString);
            }
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(Database.ConnectionString))
                {
                    conn.Open();
                    string sql = @"INSERT INTO SubjectSchedFile 
                          (SSFEDPCODE, SSFSUBJCODE, SSFSTARTTIME, SSFENDTIME, SSFDAYS, SSFROOM, 
                           SSFMAXSIZE, SSFCLASSSIZE, SSFSTATUS, SSFXM, SSFSECTION, SSFSCHOOLYEAR)
                           VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", int.Parse(txtEDPCode.Text.Trim()));
                        cmd.Parameters.AddWithValue("?", txtSubjCode.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtStartTime.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtEndTime.Text.Trim());
                        cmd.Parameters.AddWithValue("?", cmbDays.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("?", txtRoom.Text.Trim());
                        cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtMaxSize.Text));
                        cmd.Parameters.AddWithValue("?", Convert.ToInt32(txtClassSize.Text)); // maybe set default = 0
                        cmd.Parameters.AddWithValue("?", cmbStatus.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("?", cmbXMorPM.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("?", txtSection.Text.Trim());
                        cmd.Parameters.AddWithValue("?", txtSchoolYear.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Schedule added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSubjectSchedules();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubjectSchedules()
        {
            try
            {
                using (OleDbConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT SSFEDPCODE, SSFSUBJCODE, SSFSTARTTIME, SSFENDTIME, SSFDAYS, SSFROOM, SSFMAXSIZE, SSFCLASSSIZE, SSFSTATUS, SSFXM, SSFSECTION, SSFSCHOOLYEAR FROM SubjectSchedFile";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvSubjectSchedules.DataSource = dt; // 🠖 This loads it into your DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subject schedules: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubjectSched_Load(object sender, EventArgs e)
        {
            cmbDays.Items.AddRange(new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" });
            cmbStatus.Items.AddRange(new string[] { "Ac", "In", "Dis", "Res", "Cld" });
            cmbXMorPM.Items.AddRange(new string[] { "AM", "PM" });
        }

        private void btnViewSchedules_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT SSFEDPCODE, SSFSUBJCODE, SSFSTARTTIME, SSFENDTIME, SSFDAYS, SSFROOM, SSFMAXSIZE, SSFCLASSSIZE, SSFSTATUS, SSFXM, SSFSECTION, SSFSCHOOLYEAR FROM SubjectSchedFile";

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvSubjectSchedules.DataSource = dt; // << make sure this is YOUR DataGridView name
                        dgvSubjectSchedules.Columns["SSFSTARTTIME"].DefaultCellStyle.Format = "hh:mm tt";
                        dgvSubjectSchedules.Columns["SSFENDTIME"].DefaultCellStyle.Format = "hh:mm tt";
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
