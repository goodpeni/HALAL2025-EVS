using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using HALAL2025_EV;

namespace HALAL2025_EVS
{
    public partial class VoteNow : Form
    {
        string connectionString = "server=127.0.0.1;port=3306;uid=root;pwd=;database=evotingdb";
        private Dictionary<int, Panel> positionPanels;

        private string loggedInStudentID; // Store the logged-in student's ID

        public VoteNow(string studentID)
        {
            InitializeComponent();
            loggedInStudentID = studentID; // Set the logged-in student ID
        }

        private void UpdateVoteStatus()
        {
            string query = @"
            UPDATE student
            SET vote_status = 1
            WHERE student_id = @studentId";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@studentId", loggedInStudentID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show($"No student found with ID: {loggedInStudentID}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating vote status: " + ex.Message);
                }
            }
        }

        private void CenterPanel()
        {
            int x = (this.ClientSize.Width - PnlVoting.Width) / 2;
            int y = (int)((this.ClientSize.Height * 0.65) - (PnlVoting.Height / 2));

            PnlVoting.Location = new Point(Math.Max(0, x), Math.Max(0, y));
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
        "Are you sure you want to logout?",
        "Logout Confirmation",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    );

            if (result == DialogResult.Yes)
            {
                LOGIN form1 = new LOGIN();
                this.Hide();
                form1.Show();
            }
        }

        private void BtnReview_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> selectedCandidates = new Dictionary<int, string>();

            // Check each position panel and get the selected candidate name
            foreach (var positionPanel in positionPanels.Values)
            {
                foreach (Control control in positionPanel.Controls)
                {
                    if (control is RadioButton rb && rb.Checked)
                    {
                        int positionId = positionPanel.TabIndex;
                        selectedCandidates[positionId] = rb.Tag.ToString(); // Assuming the candidate name is stored in the Tag
                    }
                }
            }

            // Pass selected candidates to the Preview form
            Preview form3 = new Preview(selectedCandidates);
            form3.Show();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> selectedCandidates = new Dictionary<int, string>();

            // Check each position panel and get the selected candidate name
            foreach (var kvp in positionPanels)
            {
                int positionId = kvp.Key;
                Panel positionPanel = kvp.Value;

                bool hasSelected = false;

                foreach (Control control in positionPanel.Controls)
                {
                    if (control is RadioButton rb && rb.Checked)
                    {
                        selectedCandidates[positionId] = rb.Tag.ToString(); // Tag holds candidate name
                        hasSelected = true;
                        break;
                    }
                }

                if (!hasSelected)
                {
                    MessageBox.Show($"Please select a candidate for all positions before submitting.\nMissing: {GetPositionName(positionId)}",
                                    "Incomplete Vote",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Stop submission if one position is incomplete
                }
            }

            // Update the vote_count for each selected candidate
            foreach (var candidate in selectedCandidates)
            {
                string candidateName = candidate.Value;
                UpdateVoteCount(candidateName);
            }

            // Update student's vote status
            UpdateVoteStatus();

            // Show Vote Status form
            VoteStatus form4 = new VoteStatus();
            this.Hide();
            form4.Show();
        }

        private string GetPositionName(int positionId)
        {
            switch (positionId)
            {
                case 1: return "President";
                case 2: return "Vice President";
                case 3: return "Secretary";
                case 4: return "Treasurer";
                case 5: return "Auditor";
                case 6: return "Public Information Officer";
                case 7: return "Peace Officer";
                case 8: return "Grade 4 Representative";
                case 9: return "Grade 5 Representative";
                case 10: return "Grade 6 Representative";
                default: return "Unknown Position";
            }
        }
        private void UpdateVoteCount(string candidateName)
        {
            string query = @"
UPDATE candidate c
JOIN student s ON c.student_id = s.student_id
SET c.vote_count = c.vote_count + 1
WHERE CONCAT(s.first_name, ' ', s.last_name) = @candidateName";


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@candidateName", candidateName);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show($"No candidate found with name: {candidateName}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating vote count: " + ex.Message);
                }
            }
        }


        private void BtnPartylists_Click(object sender, EventArgs e)
        {
            ViewPartylist form5 = new ViewPartylist();
            this.Hide();
            form5.Show();
        }

        private void VoteNow_Load(object sender, EventArgs e)
        {
            CenterPanel();
            LoadCandidates();

            BtnClearPres.Click += (s, ev) => ClearSelection(PnlPres);
            BtnClearVice.Click += (s, ev) => ClearSelection(PnlVice);
            BtnClearSecretary.Click += (s, ev) => ClearSelection(PnlSec);
            BtnClearTreas.Click += (s, ev) => ClearSelection(PnlTreas);
            BtnClearAudit.Click += (s, ev) => ClearSelection(PnlAudit);
            BtnClearPIO.Click += (s, ev) => ClearSelection(PnlPIO);
            BtnClearPO.Click += (s, ev) => ClearSelection(PnlPO);
            BtnClearG4Repre.Click += (s, ev) => ClearSelection(PnlG4Repre);
            BtnClearG5Repre.Click += (s, ev) => ClearSelection(PnlG5Repre);
            BtnClearG6Repre.Click += (s, ev) => ClearSelection(PnlG6Repre);
        }

        private void LoadCandidates()
        {
            // Removed local declaration of positionPanels and use the class-level variable
            if (positionPanels == null)
            {
                positionPanels = new Dictionary<int, Panel>
                {
                    { 1, PnlPres },
                    { 2, PnlVice },
                    { 3, PnlSec },
                    { 4, PnlTreas },
                    { 5, PnlAudit },
                    { 6, PnlPIO },
                    { 7, PnlPO },
                    { 8, PnlG4Repre },
                    { 9, PnlG5Repre },
                    { 10, PnlG6Repre }
                };
            }

            string query = @"SELECT c.candidate_id, CONCAT(s.first_name, ' ', s.last_name) AS candidate_name, 
                    c.vote_count, c.position_id, c.photo
                    FROM candidate c 
                    INNER JOIN student s ON c.student_id = s.student_id";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Loop through the reader data
                    while (reader.Read())
                    {
                        int positionId = reader.GetInt32("position_id");
                        string candidateName = reader.GetString("candidate_name");
                        int voteCount = reader.GetInt32("vote_count");
                        byte[] photoData = reader["photo"] as byte[];
                        Image candidatePhoto = null;

                        // Convert BLOB photo data to Image
                        if (photoData != null)
                        {
                            using (MemoryStream ms = new MemoryStream(photoData))
                            {
                                candidatePhoto = Image.FromStream(ms);
                            }
                        }

                        // Get the corresponding panel based on the positionId
                        if (positionPanels.ContainsKey(positionId))
                        {
                            Panel positionPanel = positionPanels[positionId];

                            // Create and set up the controls for each candidate
                            CreateCandidateUI(positionPanel, candidateName, voteCount, candidatePhoto);
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading candidates: " + ex.Message);
                }
            }
        }

        // Keep only one version of CreateCandidateUI method
        // Declare a dictionary to keep track of candidates added to each panel
        private Dictionary<int, int> positionCandidateCount = new Dictionary<int, int>();

        private void CreateCandidateUI(Panel positionPanel, string candidateName, int voteCount, Image candidatePhoto)
        {
            int maxCandidates = 3;
            int topPadding = 40;
            int candidateHeight = 50;
            int spacing = 10;

            if (!positionCandidateCount.ContainsKey(positionPanel.TabIndex))
                positionCandidateCount[positionPanel.TabIndex] = 0;

            if (positionCandidateCount[positionPanel.TabIndex] >= maxCandidates)
                return;

            int index = positionCandidateCount[positionPanel.TabIndex]++;
            int yPos = topPadding + index * (candidateHeight + spacing);

            // Radio button
            RadioButton rbVote = new RadioButton
            {
                Location = new Point(15, yPos + 30),
                AutoSize = true,
                ForeColor = Color.Black,
                Tag = candidateName // Use for later identification
            };
            positionPanel.Controls.Add(rbVote);

            // Platform button
            Button btnPlatform = new Button
            {
                Text = "PLATFORM",
                Location = new Point(40, yPos + 25),
                Size = new Size(90, 30),
                BackColor = Color.Teal, // Match your resource color
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Font = new Font("Arial", 8.25F, FontStyle.Bold)
            };
            btnPlatform.Click += (sender, e) => ShowPlatform(candidateName);
            positionPanel.Controls.Add(btnPlatform);

            // Picture box
            PictureBox pbCandidatePhoto = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(140, yPos + 20),
                Image = candidatePhoto ?? Properties.Resources.DefaultPhoto,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };
            positionPanel.Controls.Add(pbCandidatePhoto);

            // Name label
            Label lblCandidateName = new Label
            {
                Text = candidateName.ToUpper(), // Uppercase format
                Location = new Point(200, yPos + 33),
                AutoSize = true,
                Font = new Font("Arial", 9.25F, FontStyle.Bold),
                ForeColor = Color.Black
            };
            positionPanel.Controls.Add(lblCandidateName);
        }

        // Define the ShowPlatform method
        private void ShowPlatform(string candidateName)
        {
            string query = @"SELECT CONCAT(s.first_name, ' ', s.last_name) AS candidate_name,
                    p.position_name,
                    c.campaign_message
             FROM candidate c
             INNER JOIN student s ON c.student_id = s.student_id
             INNER JOIN position p ON c.position_id = p.position_id
             WHERE CONCAT(s.first_name, ' ', s.last_name) = @candidateName
             LIMIT 1";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@candidateName", candidateName);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string fullName = reader.GetString("candidate_name");
                        string position = reader.GetString("position_name");
                        string campaignMessage = reader["campaign_message"]?.ToString() ?? "No campaign message.";

                        // Pass all three required parameters to the Platform constructor
                        Platform platformForm = new Platform(fullName, position, campaignMessage);
                        platformForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Candidate info not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading platform: " + ex.Message);
                }
            }
        }

        private void ClearSelection(Panel positionPanel)
        {
            foreach (Control control in positionPanel.Controls)
            {
                if (control is RadioButton rb)
                {
                    rb.Checked = false;
                }
            }
        }

    }
}
