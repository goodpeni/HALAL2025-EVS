using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Notice.Warning.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HALAL2025_EVS
{
    public partial class StudentInfo : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=evotingdb";
        public StudentInfo()
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
                    string query = "SELECT student_id, first_name, middle_name, last_name, year_level, section, vote_status FROM student";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // ✨ Tell the DataGridView to NOT auto-generate columns
                    DgvStudentInfo.AutoGenerateColumns = false;

                    // 🧠 Now bind the data
                    DgvStudentInfo.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LOGIN form1 = new LOGIN();
            this.Hide();
            form1.Show();
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddStudent form8 = new AddStudent();
            form8.Show();
        }

        private void BtnCandidates_Click(object sender, EventArgs e)
        {
            Candidates form9 = new Candidates();
            this.Hide();
            form9.Show();
        }

        private void BtnOverview_Click(object sender, EventArgs e)
        {
            Overview form6 = new Overview();
            this.Hide();
            form6.Show();
        }

        private void BtnClearFilter_Click(object sender, EventArgs e)
        {
            CmbGLevel.Text = "  (Grade Level)";
            CmbSection.Text = "     (Section)";
        }
    }
}
