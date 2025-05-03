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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            StudentInfo form7 = new StudentInfo();
            this.Hide();
            form7.Show();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            StudentInfo form7 = new StudentInfo();
            this.Hide();
            form7.Show();
        }
    }
}
