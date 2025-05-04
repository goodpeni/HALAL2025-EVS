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
    public partial class ViewPartylist : Form
    {
        public ViewPartylist()
        {
            InitializeComponent();
        }

        private void BtnVoteNow_Click(object sender, EventArgs e)
        {
            VoteNow form2 = new VoteNow(LOGIN.LoggedInStudentID);
            this.Hide();
            form2.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LOGIN form1 = new LOGIN();
            this.Hide();
            form1.Show();
        }
    }
}
