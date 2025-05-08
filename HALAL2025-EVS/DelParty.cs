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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace HALAL2025_EVS
{
    public partial class DelParty : Form
    {
        string connectionString = "server=127.0.0.1;uid=root;pwd=;database=evotingdb;";
        private Candidates parentForm;

        public DelParty(Candidates parent)
        {
            InitializeComponent();
            parentForm = parent;
            LoadPartylists();

        }

        public class Partylist
        {
            public int PartylistID { get; set; }
            public string PartylistName { get; set; }

            public override string ToString()
            {
                return PartylistName;
            }
        }
        private void LoadPartylists()
        {
            CmbPartylist.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT partylist_id, partylist_name FROM partylist";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Partylist partylist = new Partylist
                            {
                                PartylistID = Convert.ToInt32(reader["partylist_id"]),
                                PartylistName = reader["partylist_name"].ToString()
                            };
                            CmbPartylist.Items.Add(partylist);
                        }
                    }

                    if (CmbPartylist.Items.Count > 0)
                        CmbPartylist.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading partylists: " + ex.Message);
                }
            }
        }




        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (CmbPartylist.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a partylist to delete.");
                return;
            }

            string selectedPartylistName = CmbPartylist.SelectedItem.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete the partylist '{selectedPartylistName}' and all its associated candidates?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Get partylist_id from name
                    string getIdQuery = "SELECT partylist_id FROM partylist WHERE partylist_name = @name";
                    int partylistId;

                    using (MySqlCommand getIdCmd = new MySqlCommand(getIdQuery, conn))
                    {
                        getIdCmd.Parameters.AddWithValue("@name", selectedPartylistName);
                        object result = getIdCmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Selected partylist not found.");
                            return;
                        }

                        partylistId = Convert.ToInt32(result);
                    }

                    // 2. Delete candidates with this partylist_id
                    string deleteCandidatesQuery = "DELETE FROM candidate WHERE partylist_id = @id";
                    using (MySqlCommand deleteCandCmd = new MySqlCommand(deleteCandidatesQuery, conn))
                    {
                        deleteCandCmd.Parameters.AddWithValue("@id", partylistId);
                        deleteCandCmd.ExecuteNonQuery();
                    }

                    // 3. Delete partylist
                    string deletePartylistQuery = "DELETE FROM partylist WHERE partylist_id = @id";
                    using (MySqlCommand deletePartyCmd = new MySqlCommand(deletePartylistQuery, conn))
                    {
                        deletePartyCmd.Parameters.AddWithValue("@id", partylistId);
                        deletePartyCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Partylist and associated candidates deleted successfully.");
                    LoadPartylists(); // Refresh the combobox

                    parentForm.LoadData();
                    parentForm.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during deletion: " + ex.Message);
                }

            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
