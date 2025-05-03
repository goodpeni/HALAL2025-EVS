using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALAL2025_EVS
{
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LOGIN form1 = new LOGIN();
            this.Hide();
            form1.Show();
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            StudentInfo form7 = new StudentInfo();
            this.Hide();
            form7.Show();
        }

        private void BtnCandidates_Click(object sender, EventArgs e)
        {
            Candidates form9 = new Candidates();
            this.Hide();
            form9.Show();
        }

        private void LblTotalCandidInfo_Click(object sender, EventArgs e)
        {
            Candidates form9 = new Candidates();
            this.Hide();
            form9.Show();
        }

        private void LblTotalStudInfo_Click(object sender, EventArgs e)
        {
            StudentInfo form7 = new StudentInfo();
            this.Hide();
            form7.Show();
        }

        private void LblVotedStudInfo_Click(object sender, EventArgs e)
        {
            StudentInfo form7 = new StudentInfo();
            this.Hide();
            form7.Show();
        }
    }
}
