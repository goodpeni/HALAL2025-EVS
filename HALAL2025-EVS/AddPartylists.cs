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

namespace HALAL2025_EVS
{
    public partial class AddPartylist : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=evotingdb";
        private Candidates parentForm;
        public AddPartylist(Candidates parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Candidates form9 = new Candidates();
            this.Close();
            form9.Show();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Candidates form9 = new Candidates();
            this.Close();
            form9.Show();
        }

        private void BtnAddCandidate_Click(object sender, EventArgs e)
        {
            string partylistID = TxtPartylistID.Text;
            string partylistName = TxtPartylistName.Text;
            string platform = TxtPlatform.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"INSERT INTO partylist (partylist_id, partylist_name, description)
                             VALUES (@partylistID, @partylistName, @platform)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@partylistID", partylistID);
                        cmd.Parameters.AddWithValue("@partylistName", partylistName);
                        cmd.Parameters.AddWithValue("@platform", platform);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Partylist added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            parentForm.LoadData();
                            parentForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error adding Partylist. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading partylist: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
