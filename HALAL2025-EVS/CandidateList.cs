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
            LoadPositionData();
            LoadPartylistData();
        }

        private void LoadPositionData()
        {
            string query = "SELECT position_name FROM position";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        // Add default option
                        CmbPosition.Items.Clear();
                        CmbPosition.Items.Add("(Position)");

                        while (reader.Read())
                        {
                            string positionName = reader.GetString("position_name");
                            CmbPosition.Items.Add(positionName);
                        }

                        if (CmbPosition.Items.Count > 0)
                        {
                            CmbPosition.SelectedIndex = 0;  // Set the default "Select" option
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading position data: " + ex.Message);
            }
        }

        private void LoadPartylistData()
        {
            string query = "SELECT partylist_name FROM partylist";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        // Add default option
                        CmbPartylist.Items.Clear();
                        CmbPartylist.Items.Add("(Partylist)");

                        while (reader.Read())
                        {
                            string partylistName = reader.GetString("partylist_name");
                            CmbPartylist.Items.Add(partylistName);
                        }

                        if (CmbPartylist.Items.Count > 0)
                        {
                            CmbPartylist.SelectedIndex = 0;  // Set the default "Select" option
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading partylist data: " + ex.Message);
            }
        }

        private void LoadFilteredData(string position, string partylist, string studentId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Start the query
                    string query = "SELECT c.student_id, s.first_name, s.middle_name, s.last_name, p.position_name, pl.partylist_name " +
                                   "FROM candidate c " +
                                   "INNER JOIN student s ON c.student_id = s.student_id " +
                                   "INNER JOIN position p ON c.position_id = p.position_id " +
                                   "INNER JOIN partylist pl ON c.partylist_id = pl.partylist_id " +
                                   "WHERE 1 = 1"; // This will allow appending filters with AND without breaking the query.

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    // Filter by position if selected
                    if (!string.IsNullOrWhiteSpace(position) && position != "(Position)")
                    {
                        query += " AND p.position_name = @position";
                        cmd.Parameters.AddWithValue("@position", position);
                    }

                    // Filter by partylist if selected
                    if (!string.IsNullOrWhiteSpace(partylist) && partylist != "(Partylist)")
                    {
                        query += " AND pl.partylist_name = @partylist";
                        cmd.Parameters.AddWithValue("@partylist", partylist);
                    }

                    // Filter by student ID if provided
                    if (!string.IsNullOrWhiteSpace(studentId))
                    {
                        query += " AND c.student_id LIKE @studentId";
                        cmd.Parameters.AddWithValue("@studentId", studentId + "%");
                    }

                    cmd.CommandText = query;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DgvCandidatesList.AutoGenerateColumns = false;
                    DgvCandidatesList.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ApplyFilters()
        {
            // Ensure you're comparing against "Select" or similar placeholder value
            string selectedPosition = CmbPosition.SelectedItem?.ToString();
            string selectedPartylist = CmbPartylist.SelectedItem?.ToString();
            string searchId = TxtSearch.Text?.Trim();

            // If the ComboBox values are the default ones, pass empty or null values
            LoadFilteredData(
                selectedPosition != "(Position)" ? selectedPosition : null,
                selectedPartylist != "(Partylist)" ? selectedPartylist : null,
                searchId
            );
        }


        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT c.student_id, s.first_name, s.middle_name, s.last_name, p.position_name, pl.partylist_name FROM candidate c INNER JOIN student s ON c.student_id = s.student_id INNER JOIN position p ON c.position_id = p.position_id INNER JOIN partylist pl ON c.partylist_id = pl.partylist_id";
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

        private void CmbAlphabets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void LblFilter_Click(object sender, EventArgs e)
        {

        }

        private void CmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BtnClearFilter_Click(object sender, EventArgs e)
        {
            // Clear ComboBox selections (if you want them to return to their default state)
            CmbPosition.SelectedIndex = 0;  // Clears the selection
            CmbPartylist.SelectedIndex = 0; // Clears the selection

            // Reload all data
            LoadData();
        }

        private void Candidates_Load(object sender, EventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
