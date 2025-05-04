using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrollment_System
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStudentEntry_Click(object sender, EventArgs e)
        {
			new StudentEntryForm().ShowDialog();
		}

        private void btnEnrollSubjects_Click(object sender, EventArgs e)
        {
			new EnrollmentForm().ShowDialog();
		}

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
			new StudentListForm().ShowDialog();
		}

        private void btnManageSubjects_Click(object sender, EventArgs e)
        {
            SubjectForm sf = new SubjectForm();
            sf.ShowDialog();
        }

        private void btnSubjectSchedule_Click(object sender, EventArgs e)
        {
            SubjectSched subjectSchedForm = new SubjectSched();
            subjectSchedForm.ShowDialog(); // Open it as a dialog so MainForm stays behind
        }
    }
}
