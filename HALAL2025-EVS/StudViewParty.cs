using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;
using System.IO;
using System.Drawing;

namespace HALAL2025_EVS
{
    public partial class ViewPartylist : Form
    {
        string connectionString = "server=127.0.0.1;port=3306;uid=root;pwd=;database=evotingdb";

        public ViewPartylist()
        {
            InitializeComponent();
            LoadPartylists(); // Call the method on form load
            CmbFilter.SelectedIndexChanged += CmbFilter_SelectedIndexChanged;

        }

        private void LoadPartylists()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT partylist_name FROM partylist";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    CmbFilter.Items.Clear(); // Clear existing items
                    while (reader.Read())
                    {
                        CmbFilter.Items.Add(reader.GetString("partylist_name"));
                    }

                    if (CmbFilter.Items.Count > 0)
                        CmbFilter.SelectedIndex = 0; // Optionally select the first item
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading partylist: " + ex.Message);
            }
        }

        private void BtnVoteNow_Click(object sender, EventArgs e)
        {
            VoteNow form2 = new VoteNow(LOGIN.LoggedInStudentID);
            this.Hide();
            form2.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LOGIN form1 = new LOGIN();
            this.Hide();
            form1.Show();
        }
        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPartylist = CmbFilter.SelectedItem.ToString();
            LoadCandidatesByPartylist(selectedPartylist);
        }

        private void LoadCandidatesByPartylist(string partylistName)
        {
            string query = @"
        SELECT 
            c.position_id,
            CONCAT(s.first_name, ' ', s.last_name) AS candidate_name,
            c.photo
        FROM candidate c
        INNER JOIN student s ON c.student_id = s.student_id
        INNER JOIN partylist p ON c.partylist_id = p.partylist_id
        WHERE p.partylist_name = @partylistName";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@partylistName", partylistName);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Clear previous images and names
                    ClearCandidateUI();

                    while (reader.Read())
                    {
                        int positionId = reader.GetInt32("position_id");
                        string name = reader.GetString("candidate_name");
                        byte[] photoData = reader["photo"] as byte[];

                        Image photo = null;
                        if (photoData != null)
                        {
                            using (MemoryStream ms = new MemoryStream(photoData))
                            {
                                photo = Image.FromStream(ms);
                            }
                        }

                        // Assign photo and name to the correct picture box and label
                        SetCandidateUI(positionId, name, photo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading candidates: " + ex.Message);
            }
        }
        private void SetCandidateUI(int positionId, string name, Image photo)
        {
            switch (positionId)
            {
                case 1:
                    PicBoxPres.Image = photo;
                    LblPresName.Text = name;
                    break;
                case 2:
                    PicBoxVice.Image = photo;
                    LblViceName.Text = name;
                    break;
                case 3:
                    PicBoxSec.Image = photo;
                    LblSecName.Text = name;
                    break;
                case 4:
                    PicBoxTreas.Image = photo;
                    LblTreasName.Text = name;
                    break;
                case 5:
                    PicBoxAudit.Image = photo;
                    LblAuditName.Text = name;
                    break;
                case 6:
                    PicBoxPIO.Image = photo;
                    LblPIOName.Text = name;
                    break;
                case 7:
                    PicBoxPO.Image = photo;
                    LblPOName.Text = name;
                    break;
                case 8:
                    PicBoxG4Rep.Image = photo;
                    LblG4RepName.Text = name;
                    break;
                case 9:
                    PicBoxG5Rep.Image = photo;
                    LblG5RepName.Text = name;
                    break;
                case 10:
                    PicBoxG6Rep.Image = photo;
                    LblG6RepName.Text = name;
                    break;
            }
        }
        private void ClearCandidateUI()
        {
            PicBoxPres.Image = null; LblPresName.Text = "";
            PicBoxVice.Image = null; LblViceName.Text = "";
            PicBoxSec.Image = null; LblSecName.Text = "";
            PicBoxTreas.Image = null; LblTreasName.Text = "";
            PicBoxAudit.Image = null; LblAuditName.Text = "";
            PicBoxPIO.Image = null; LblPIOName.Text = "";
            PicBoxPO.Image = null; LblPOName.Text = "";
            PicBoxG4Rep.Image = null; LblG4RepName.Text = "";
            PicBoxG5Rep.Image = null; LblG5RepName.Text = "";
            PicBoxG6Rep.Image = null; LblG6RepName.Text = "";
        }
    }
}
