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
        List<string> positionList = new List<string>();
        List<string> partylistList = new List<string>();

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
            positionList.Clear(); // Clear before adding new items

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        CmbPosition.Items.Clear();
                        CmbPosition.Items.Add("(Position)");

                        while (reader.Read())
                        {
                            string positionName = reader.GetString("position_name");
                            positionList.Add(positionName);
                            CmbPosition.Items.Add(positionName);
                        }

                        if (CmbPosition.Items.Count > 0)
                            CmbPosition.SelectedIndex = 0;
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
            partylistList.Clear(); // Clear before adding new items

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        CmbPartylist.Items.Clear();
                        CmbPartylist.Items.Add("(Partylist)");

                        while (reader.Read())
                        {
                            string partylistName = reader.GetString("partylist_name");
                            partylistList.Add(partylistName);
                            CmbPartylist.Items.Add(partylistName);
                        }

                        if (CmbPartylist.Items.Count > 0)
                            CmbPartylist.SelectedIndex = 0;
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
//

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT c.student_id, s.first_name, s.middle_name, s.last_name, p.position_name, pl.partylist_name " +
                                   "FROM candidate c " +
                                   "INNER JOIN student s ON c.student_id = s.student_id " +
                                   "INNER JOIN position p ON c.position_id = p.position_id " +
                                   "INNER JOIN partylist pl ON c.partylist_id = pl.partylist_id " +
                                   "WHERE 1 = 1";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (!string.IsNullOrWhiteSpace(position) && position != "(Position)")
                    {
                        query += " AND p.position_name = @position";
                        cmd.Parameters.AddWithValue("@position", position);
                    }

                    if (!string.IsNullOrWhiteSpace(partylist) && partylist != "(Partylist)")
                    {
                        query += " AND pl.partylist_name = @partylist";
                        cmd.Parameters.AddWithValue("@partylist", partylist);
                    }

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
            string selectedPosition = CmbPosition.SelectedItem?.ToString();
            string selectedPartylist = CmbPartylist.SelectedItem?.ToString();
            string searchId = TxtSearch.Text?.Trim();

            LoadFilteredData(
                selectedPosition != "(Position)" ? selectedPosition : null,
                selectedPartylist != "(Partylist)" ? selectedPartylist : null,
                searchId
            );
        }

        private void LoadData()
        {
//

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT c.student_id, s.first_name, s.middle_name, s.last_name, p.position_name, pl.partylist_name FROM candidate c INNER JOIN student s ON c.student_id = s.student_id INNER JOIN position p ON c.position_id = p.position_id INNER JOIN partylist pl ON c.partylist_id = pl.partylist_id";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
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
            TxtSearch.Clear();
            CmbPosition.SelectedIndex = 0;
            CmbPartylist.SelectedIndex = 0;

            LoadData();
        }

        private void Candidates_Load(object sender, EventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (DgvCandidatesList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DgvCandidatesList.SelectedRows[0];

                DataGridViewComboBoxCell positionCombo = new DataGridViewComboBoxCell();
                positionCombo.DataSource = positionList;
                positionCombo.Value = selectedRow.Cells["Position"].Value.ToString();
                selectedRow.Cells["Position"] = positionCombo;

                DataGridViewComboBoxCell partylistCombo = new DataGridViewComboBoxCell();
                partylistCombo.DataSource = partylistList;
                partylistCombo.Value = selectedRow.Cells["Partylist"].Value.ToString();
                selectedRow.Cells["Partylist"] = partylistCombo;

                selectedRow.Cells["StudentID"].ReadOnly = true;
                selectedRow.Cells["FirstName"].ReadOnly = true;
                selectedRow.Cells["MiddleName"].ReadOnly = true;
                selectedRow.Cells["LastName"].ReadOnly = true;

                DgvCandidatesList.BeginEdit(true);
            }
            else
            {
                MessageBox.Show("Please select a candidate row to edit.");
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (DgvCandidatesList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DgvCandidatesList.SelectedRows[0];

                string studentId = selectedRow.Cells["StudentID"].Value.ToString();
                string newPosition = selectedRow.Cells["Position"].Value.ToString();
                string newPartylist = selectedRow.Cells["Partylist"].Value.ToString();

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        string posQuery = "SELECT position_id FROM position WHERE position_name = @name";
                        MySqlCommand posCmd = new MySqlCommand(posQuery, conn);
                        posCmd.Parameters.AddWithValue("@name", newPosition);
                        int positionId = Convert.ToInt32(posCmd.ExecuteScalar());

                        string partyQuery = "SELECT partylist_id FROM partylist WHERE partylist_name = @name";
                        MySqlCommand partyCmd = new MySqlCommand(partyQuery, conn);
                        partyCmd.Parameters.AddWithValue("@name", newPartylist);
                        int partylistId = Convert.ToInt32(partyCmd.ExecuteScalar());

                        string updateQuery = "UPDATE candidate SET position_id = @posId, partylist_id = @partyId WHERE student_id = @studentId";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@posId", positionId);
                        updateCmd.Parameters.AddWithValue("@partyId", partylistId);
                        updateCmd.Parameters.AddWithValue("@studentId", studentId);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Candidate updated successfully.");
                        LoadData(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No row selected to save.");
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DgvCandidatesList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DgvCandidatesList.SelectedRows[0];
                string studentId = selectedRow.Cells["student_id"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this candidate?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            string deleteQuery = "DELETE FROM candidate WHERE student_id = @studentId";
                            MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                            cmd.Parameters.AddWithValue("@studentId", studentId);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Candidate deleted successfully.");
                            LoadData(); 
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting candidate: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a candidate to delete.");
            }
        }

    }
}