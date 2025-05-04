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
    public partial class LOGIN : Form
    {
        public static string LoggedInStudentID { get; private set; } // Static variable to store the student ID globally

        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=evotingdb";

        public LOGIN()
        {
            InitializeComponent();
            this.AcceptButton = BtnLogin;
        }

        public void Login()
        {
            string adminQuery = "SELECT * FROM admin WHERE admin_name = @id AND admin_password = @pass";
            string studentQuery = "SELECT * FROM student WHERE student_id = @id AND student_password = @pass";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (MySqlCommand studentCmd = new MySqlCommand(studentQuery, connection))
                    {
                        studentCmd.Parameters.AddWithValue("@id", TxtStudentID.Text);
                        studentCmd.Parameters.AddWithValue("@pass", TxtPassword.Text);

                        using (MySqlDataReader studentReader = studentCmd.ExecuteReader())
                        {
                            if (studentReader.Read())
                            {
                                // Store the logged-in student's ID
                                LoggedInStudentID = TxtStudentID.Text;

                                // Check if the student has already voted (vote_status = 1)
                                int voteStatus = Convert.ToInt32(studentReader["vote_status"]);
                                if (voteStatus == 1)
                                {
                                    // If vote_status is 1, go directly to the VoteStatus form
                                    MessageBox.Show("You have already voted.");
                                    VoteStatus form4 = new VoteStatus();
                                    this.Hide();
                                    form4.Show();
                                }
                                else
                                {
                                    // Otherwise, allow the student to vote
                                    MessageBox.Show("Login Success! Please proceed to vote.");
                                    VoteNow form2 = new VoteNow(LoggedInStudentID);
                                    this.Hide();
                                    form2.Show();
                                }
                                return;
                            }
                        }
                    }

                    using (MySqlCommand adminCmd = new MySqlCommand(adminQuery, connection))
                    {
                        adminCmd.Parameters.AddWithValue("@id", TxtStudentID.Text);
                        adminCmd.Parameters.AddWithValue("@pass", TxtPassword.Text);

                        using (MySqlDataReader adminReader = adminCmd.ExecuteReader())
                        {
                            if (adminReader.Read())
                            {
                                MessageBox.Show("Login Success! (Admin)");
                                Overview form6 = new Overview();
                                this.Hide();
                                form6.Show();
                                return;
                            }
                        }
                    }

                    MessageBox.Show("Invalid credentials, please try again.");
                    TxtStudentID.Clear();
                    TxtPassword.Clear();
                    ChkShowPass.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void ChkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkShowPass.Checked)
            {
                TxtPassword.PasswordChar = '\0';
                PicBoxPass.BackgroundImage = Properties.Resources.view;
            }
            else
            {
                TxtPassword.PasswordChar = '*';
                PicBoxPass.BackgroundImage = Properties.Resources.eye;
            }
        }
    }

}
