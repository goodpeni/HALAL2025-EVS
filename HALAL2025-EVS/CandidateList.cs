using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HALAL2025_EVS
{
    public partial class Candidates : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=evotingdb";
        public Candidates()
        {
            InitializeComponent();
            LoadData(); 
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT c.candidate_id, s.first_name, s.middle_name, s.last_name, p.position_name, pl.partylist_name FROM candidate c INNER JOIN student s ON c.student_id = s.student_id\r\nINNER JOIN position p ON c.position_id = p.position_id INNER JOIN partylist pl ON c.partylist_id = pl.partylist_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // ✨ Tell the DataGridView to NOT auto-generate columns
                    DgvCandidatesList.AutoGenerateColumns = false;

                    // 🧠 Now bind the data
                    DgvCandidatesList.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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
