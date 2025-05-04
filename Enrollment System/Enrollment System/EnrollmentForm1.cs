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
    public partial class EnrollmentForm : Form
    {
        public EnrollmentForm()
        {
            InitializeComponent();
        }

        private void txtStudentID_Leave(object sender, EventArgs e)
        {
			lblStudentName.Text = ""; // Clear before searching

			if (string.IsNullOrWhiteSpace(txtStudentID.Text))
				return;

			using (OleDbConnection conn = Database.GetConnection())
			{
				conn.Open();
				string sql = "SELECT STFSTUDLNAME, STFSTUDFNAME FROM StudentFile WHERE STFSTUDID = ?";
				using (OleDbCommand cmd = new OleDbCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("?", txtStudentID.Text);

					using (OleDbDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							string fullName = $"{reader["STFSTUDLNAME"]}, {reader["STFSTUDFNAME"]}";
							lblStudentName.Text = fullName;
						}
						else
						{
							lblStudentName.Text = "Student not found!";
						}
					}
				}
			}
		}

        private void btnSaveEnrollment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) || !int.TryParse(txtStudentID.Text, out int studentId))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OleDbConnection conn = Database.GetConnection())
            {
                conn.Open();

                foreach (DataGridViewRow row in dgvSubjects.Rows)
                {
                    if (row.IsNewRow) continue;

                    string edpCode = row.Cells[0].Value?.ToString();
                    string subjectCode = row.Cells[1].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(edpCode) || string.IsNullOrWhiteSpace(subjectCode))
                        continue;

                    string sql = "INSERT INTO EnrollmentFile (STFSTUDID, EDPCode, SubjectCode, EnrollmentDate) " +
                                 "VALUES (?, ?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("?", studentId);
                        cmd.Parameters.AddWithValue("?", edpCode);
                        cmd.Parameters.AddWithValue("?", subjectCode);
                        cmd.Parameters.AddWithValue("?", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Subjects enrolled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
			lblStudentName.Text = "";
		}

        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
			if (string.IsNullOrWhiteSpace(txtStudentID.Text))
			{
				lblStudentName.Text = "";
			}
		}
    }
}
