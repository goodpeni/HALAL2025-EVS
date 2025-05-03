using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HALAL2025_EVS
{
    public partial class Overview : Form
    {
        string connectionString = "server=127.0.0.1;port=3306;uid=root;pwd=;database=evotingdb";
        public Overview()
        {
            InitializeComponent();
        }

        private void LoadCandidateCount()
        {
            string query = "SELECT COUNT(*) FROM candidate";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int candidateCount = Convert.ToInt32(cmd.ExecuteScalar()); 
                    LblTotalCandid.Text = candidateCount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadStudentCount()
        {
            string query = "SELECT COUNT(*) FROM student";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int studentCount = Convert.ToInt32(cmd.ExecuteScalar()); 
                    LblTotalStud.Text = studentCount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadStudentVotedCount()
        {
            string query = "SELECT COUNT(*) FROM student WHERE vote_status = 0";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int studentVotedCount = Convert.ToInt32(cmd.ExecuteScalar()); 
                    LblTotalStud.Text = studentVotedCount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void CenterPanel()
        {
            int x = (this.ClientSize.Width - PnlRankings.Width) / 2;
            int y = (int)((this.ClientSize.Height * 0.7) - (PnlRankings.Height / 2));

            PnlRankings.Location = new Point(Math.Max(0, x), Math.Max(0, y));
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

        private void Overview_Load(object sender, EventArgs e)
        {
            CenterPanel();
            LoadCandidateCount();
            LoadStudentCount();
            LoadStudentVotedCount();
        }
    }
}
