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
    public partial class StudentEntryForm : Form
    {
        public StudentEntryForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text) || !int.TryParse(txtID.Text, out int studentId) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(cbxCourse.Text) || string.IsNullOrWhiteSpace(cbxRemarks.Text) ||
                    !int.TryParse(txtYear.Text, out int year))
                {
                    MessageBox.Show("Please fill out all required fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OleDbConnection thisConnection = Database.GetConnection();
                string sql = "INSERT INTO StudentFile (STFSTUDID, STFSTUDLNAME, STFSTUDFNAME, STFSTUDMNAME, STFSTUDCOURSE, STFSTUDYEAR, STFSTUDREMARKS, STFSTUDSTATUS) " +
                             "VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                OleDbCommand thisCommand = new OleDbCommand(sql, thisConnection);

                thisCommand.Parameters.AddWithValue("?", Convert.ToInt32(txtID.Text));
                thisCommand.Parameters.AddWithValue("?", txtLastName.Text);
                thisCommand.Parameters.AddWithValue("?", txtFirstName.Text);
                thisCommand.Parameters.AddWithValue("?", txtMiddleInitial.Text);
                thisCommand.Parameters.AddWithValue("?", cbxCourse.Text);
                thisCommand.Parameters.AddWithValue("?", Convert.ToInt16(txtYear.Text));
                thisCommand.Parameters.AddWithValue("?", cbxRemarks.Text);
                thisCommand.Parameters.AddWithValue("?", "AC");

                thisConnection.Open();
                thisCommand.ExecuteNonQuery();
                thisConnection.Close();

                MessageBox.Show("Entries Recorded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtID.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleInitial.Clear();
            cbxCourse.SelectedIndex = -1;
            txtYear.Clear();
            cbxRemarks.SelectedIndex = -1;
        }
    }
}
