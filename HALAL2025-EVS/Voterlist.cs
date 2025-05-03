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
                    string query = "SELECT student_id, first_name, middle_name, last_name, grade_level, section, vote_status FROM student";
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

        private void LoadFilteredData(string gradeLevel, string section, string voteStatus)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT student_id, first_name, middle_name, last_name, grade_level, section, vote_status FROM student WHERE 1=1";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (!string.IsNullOrWhiteSpace(gradeLevel) && gradeLevel != "(Grade Level)")
                    {
                        query += " AND grade_level = @gradeLevel";
                        cmd.Parameters.AddWithValue("@gradeLevel", gradeLevel);
                    }

                    if (!string.IsNullOrWhiteSpace(section) && section != "(Section)")
                    {
                        query += " AND section = @section";
                        cmd.Parameters.AddWithValue("@section", section);
                    }

                    if (!string.IsNullOrWhiteSpace(voteStatus) && voteStatus != "(Vote Status)")
                    {
                        int voteValue = voteStatus == "Yes" ? 1 : 0;
                        query += " AND vote_status = @voteStatus";
                        cmd.Parameters.AddWithValue("@voteStatus", voteValue);
                    }

                    cmd.CommandText = query;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DgvStudentInfo.AutoGenerateColumns = false;
                    DgvStudentInfo.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void ApplyFilters()
        {
            string selectedGrade = CmbGLevel.SelectedItem?.ToString();
            string selectedSection = CmbSection.SelectedItem?.ToString();
            string selectedVoteStatus = CmbVoteStatus.SelectedItem?.ToString();
            LoadFilteredData(selectedGrade, selectedSection, selectedVoteStatus);
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
            CmbVoteStatus.Text = "   (Vote Status)";
            LoadData();
        }

        private void CmbGLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void CmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void CmbVoteStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
