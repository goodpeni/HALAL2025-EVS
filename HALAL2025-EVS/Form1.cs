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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if(TxtStudentID.Text == "admin" && TxtPassword.Text == "root")
            {
                MessageBox.Show("Login Success", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 form2 = new Form2();
                this.Hide();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials, please try again.");
            }
        }

        private void ChkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkShowPass.Checked)
            {
                TxtPassword.PasswordChar = '\0';
                PicBoxPass.BackgroundImage = Properties.Resources.view;
            }
            else
            {
                TxtPassword.PasswordChar = '*';
                PicBoxPass.BackgroundImage = Properties.Resources.eye;
            }
        }
    }
}
