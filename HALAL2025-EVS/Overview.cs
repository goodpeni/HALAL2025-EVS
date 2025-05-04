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

        private void LoadVoteCharts()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                c.vote_count, 
                                CONCAT(s.first_name, ' ', s.last_name) AS candidate_name, 
                                c.position_id 
                             FROM candidate c 
                             INNER JOIN student s ON c.student_id = s.student_id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Clear all chart points and enable labels
                    SetupChartSeries(ChrPres);
                    SetupChartSeries(ChrVice);
                    SetupChartSeries(ChrSec);
                    SetupChartSeries(ChrTreas);
                    SetupChartSeries(ChrAudit);
                    SetupChartSeries(ChrPIO);
                    SetupChartSeries(ChrPO);
                    SetupChartSeries(ChrG4Rep);
                    SetupChartSeries(ChrG5Rep);
                    SetupChartSeries(ChrG6Rep);

                    while (reader.Read())
                    {
                        int positionId = reader.GetInt32("position_id");
                        string candidateName = reader.GetString("candidate_name");
                        int voteCount = reader.GetInt32("vote_count");
                        string labelText = $"{candidateName} - {voteCount}";

                        var point = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                        point.AxisLabel = candidateName;
                        point.YValues = new double[] { voteCount };
                        point.Label = labelText;

                        switch (positionId)
                        {
                            case 1: ChrPres.Series[0].Points.Add(point); break;
                            case 2: ChrVice.Series[0].Points.Add(point); break;
                            case 3: ChrSec.Series[0].Points.Add(point); break;
                            case 4: ChrTreas.Series[0].Points.Add(point); break;
                            case 5: ChrAudit.Series[0].Points.Add(point); break;
                            case 6: ChrPIO.Series[0].Points.Add(point); break;
                            case 7: ChrPO.Series[0].Points.Add(point); break;
                            case 8: ChrG4Rep.Series[0].Points.Add(point); break;
                            case 9: ChrG5Rep.Series[0].Points.Add(point); break;
                            case 10: ChrG6Rep.Series[0].Points.Add(point); break;
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading charts: " + ex.Message);
                }
            }
        }


        private void SetupChartSeries(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            var series = chart.Series[0];
            series.Points.Clear();
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.Black;
            series.Font = new Font("Segoe UI", 7, FontStyle.Bold);
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
            LoadVoteCharts();
        }

        private void ChrPres_Click(object sender, EventArgs e)
        {

        }

        private void ChrVice_Click(object sender, EventArgs e)
        {

        }

        private void ChrSec_Click(object sender, EventArgs e)
        {

        }

        private void ChrTreas_Click(object sender, EventArgs e)
        {

        }

        private void ChrAudit_Click(object sender, EventArgs e)
        {

        }

        private void ChrPIO_Click(object sender, EventArgs e)
        {

        }

        private void ChrPO_Click(object sender, EventArgs e)
        {

        }

        private void ChrG4Rep_Click(object sender, EventArgs e)
        {

        }

        private void ChrG5Rep_Click(object sender, EventArgs e)
        {

        }

        private void ChrG6Rep_Click(object sender, EventArgs e)
        {

        }
    }
}
