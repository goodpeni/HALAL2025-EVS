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
    public partial class VoteNow : Form
    {
        public VoteNow()
        {
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LOGIN form1 = new LOGIN();
            this.Hide();
            form1.Show();
        }

        private void BtnReview_Click(object sender, EventArgs e)
        {
            Preview form3 = new Preview();
            form3.Show();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            VoteStatus form4 = new VoteStatus();
            this.Hide();
            form4.Show();
        }

        private void BtnPartylists_Click(object sender, EventArgs e)
        {
            ViewPartylist form5 = new ViewPartylist();
            this.Hide();
            form5.Show();
        }

        private void BtnPFPres1_Click(object sender, EventArgs e)
        {
            Platform form12 = new Platform();
            form12.Show();
        }

       
    }
}
