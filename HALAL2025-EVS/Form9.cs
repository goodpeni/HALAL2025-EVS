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
    public partial class Candidates : Form
    {
        public Candidates()
        {
            InitializeComponent();
        }

        private void BtnAddCandid_Click(object sender, EventArgs e)
        {
            AddCandidate form10 = new AddCandidate();
            form10.Show();
        }

        private void BtnAddParty_Click(object sender, EventArgs e)
        {
            AddPartylist form11 = new AddPartylist();
            form11.Show();
        }

        private void BtnOverview_Click(object sender, EventArgs e)
        {
            Overview form6 = new Overview();
            this.Hide();
            form6.Show();
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            StudentInfo form7 = new StudentInfo();
            this.Hide();
            form7.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LOGIN form1 = new LOGIN();
            this.Hide();
            form1.Show();
        }
    }
}
