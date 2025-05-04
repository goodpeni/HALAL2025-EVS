using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HALAL2025_EVS
{
    public partial class AddCandidate : Form
    {
        string connectionString = "server=127.0.0.1;uid=root;pwd=;database=evotingdb;";
        byte[] candidateImageData;

        private Candidates parentForm;

        public AddCandidate(Candidates parent)
        {
            InitializeComponent();

            parentForm = parent;

            BtnChooseFile.Click += BtnChooseFile_Click;
            BtnAddCandidate.Click += BtnAddCandidate_Click_1;
            TxtStudentID.Leave += TxtStudentID_Leave;

            LoadPartylists();
            LoadPositions();
        }


        private Dictionary<string, int> partylistDictionary = new Dictionary<string, int>();

        private void LoadPartylists()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT partylist_id, partylist_name FROM partylist";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        CmbPartylists.Items.Clear();
                        partylistDictionary.Clear(); // Clear the dictionary before loading new items

                        while (reader.Read())
                        {
                            string partylistName = reader["partylist_name"].ToString();
                            int partylistId = Convert.ToInt32(reader["partylist_id"]);
                            CmbPartylists.Items.Add(partylistName);
                            partylistDictionary[partylistName] = partylistId; // Store the partylist_id
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading partylists: " + ex.Message);
                }
            }
        }


        private Dictionary<string, int> positionDictionary = new Dictionary<string, int>();

        private void LoadPositions()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT position_id, position_name FROM position";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        CmbPosition.Items.Clear();
                        positionDictionary.Clear(); // Clear the dictionary before loading new items

                        while (reader.Read())
                        {
                            string positionName = reader["position_name"].ToString();
                            int positionId = Convert.ToInt32(reader["position_id"]);
                            CmbPosition.Items.Add(positionName);
                            positionDictionary[positionName] = positionId; // Store the position_id
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading positions: " + ex.Message);
                }
            }
        }


        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg; *.png; *.jpeg)|*.jpg;*.png;*.jpeg";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Get the file name from the selected file
                    string fileName = Path.GetFileName(ofd.FileName);

                    // Load the image into the byte array
                    Image img = Image.FromFile(ofd.FileName);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, img.RawFormat);
                        candidateImageData = ms.ToArray();
                    }

                    // Set the label text to the file name
                    LblChooseFile.Text = fileName;
                }
            }
        }


        private void TxtStudentID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtStudentID.Text)) return;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT first_name, middle_name, last_name FROM student WHERE student_id = @student_id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@student_id", TxtStudentID.Text.Trim());

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TxtFirstName.Text = reader["first_name"].ToString();
                                TxtMiddleName.Text = reader["middle_name"].ToString();
                                TxtLastName.Text = reader["last_name"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Student ID not found.");
                                TxtFirstName.Clear();
                                TxtMiddleName.Clear();
                                TxtLastName.Clear();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching student data: " + ex.Message);
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Candidates form9 = new Candidates();
            this.Hide();
            form9.Show();
        }

        private void BtnAddCandidate_Click_1(object sender, EventArgs e)
        {
            /*if (string.IsNullOrWhiteSpace(TxtCandidateID.Text.Trim()) ||
            string.IsNullOrWhiteSpace(TxtStudentID.Text.Trim()) ||
            CmbPartylists.SelectedIndex == -1 ||
            CmbPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }*/


            // Get the selected partylist_id from the dictionary
            int selectedPartylistId = partylistDictionary[CmbPartylists.SelectedItem.ToString()];

            // Get the selected position_id from the dictionary
            int selectedPositionId = positionDictionary[CmbPosition.SelectedItem.ToString()];

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO candidate (candidate_id, student_id, position_id, partylist_id, campaign_message, photo) VALUES (@candidate_id, @student_id, @position, @partylist, @campaign_message, @photo)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@candidate_id", TxtCandidateID.Text.Trim());
                        cmd.Parameters.AddWithValue("@student_id", TxtStudentID.Text.Trim());
                        cmd.Parameters.AddWithValue("@position", selectedPositionId);  // Insert position_id
                        cmd.Parameters.AddWithValue("@partylist", selectedPartylistId);  // Insert partylist_id
                        cmd.Parameters.AddWithValue("@campaign_message", TxtPlatForm.Text.Trim());
                        cmd.Parameters.Add("@photo", MySqlDbType.Blob).Value = candidateImageData;

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Candidate successfully added!");

                        // Close the current AddCandidate form and show the Candidates form
                        parentForm.LoadData();
                        parentForm.Show();
                        this.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving candidate: " + ex.Message);
                }
            }
        }
    }
}
