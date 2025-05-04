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
    public partial class StudentListForm : Form
    {
        public StudentListForm()
        {
            InitializeComponent();
        }

		private void LoadStudents()
		{
			using (OleDbConnection conn = Database.GetConnection())
			{
				conn.Open();
				string sql = "SELECT * FROM StudentFile";
				OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
				DataTable dt = new DataTable();
				adapter.Fill(dt);
				dgvStudents.DataSource = dt;
			}
		}

		private void StudentListForm_Load(object sender, EventArgs e)
        {
			LoadStudents();
		}
    }
}
