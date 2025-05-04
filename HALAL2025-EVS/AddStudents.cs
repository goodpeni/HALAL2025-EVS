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
    public partial class AddStudent : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=evotingdb";
        public AddStudent()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            StudentInfo form7 = new StudentInfo();
            this.Hide();
            form7.Show();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Validate that all fields are filled
            if (string.IsNullOrWhiteSpace(TxtStudentID.Text) ||
                string.IsNullOrWhiteSpace(TxtFirstName.Text) ||
                string.IsNullOrWhiteSpace(TxtMiddleName.Text) ||
                string.IsNullOrWhiteSpace(TxtLastName.Text) ||
                string.IsNullOrWhiteSpace(TxtPassword.Text) ||
                string.IsNullOrWhiteSpace(TxtConfirmPass.Text) ||
                CmbGrade.SelectedItem == null ||
                CmbSection.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the password and confirm password match
            if (TxtPassword.Text != TxtConfirmPass.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPassword.Clear();
                TxtConfirmPass.Clear();
                return;
            }

            // Collect data from the form
            string studentId = TxtStudentID.Text;
            string firstName = TxtFirstName.Text;
            string middleName = TxtMiddleName.Text;
            string lastName = TxtLastName.Text;
            string password = TxtPassword.Text; // You may want to hash this for security purposes
            string gradeLevel = CmbGrade.SelectedItem.ToString();
            string section = CmbSection.SelectedItem.ToString();

            // Insert into the database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Prepare the SQL query to insert the new student
                    string query = @"INSERT INTO student (student_id, first_name, middle_name, last_name, grade_level, section, student_password)
                             VALUES (@studentId, @firstName, @middleName, @lastName, @gradeLevel, @section, @password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.Parameters.AddWithValue("@firstName", firstName);
                        cmd.Parameters.AddWithValue("@middleName", middleName);
                        cmd.Parameters.AddWithValue("@lastName", lastName);
                        cmd.Parameters.AddWithValue("@gradeLevel", gradeLevel);
                        cmd.Parameters.AddWithValue("@section", section);
                        cmd.Parameters.AddWithValue("@password", password); // In a real application, hash the password before storing it

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StudentInfo form7 = new StudentInfo();
                            this.Close();
                            form7.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error adding student. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void ChkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkShowPass.Checked)
            {
                TxtConfirmPass.PasswordChar = '\0';
            }
            else
            {
                TxtConfirmPass.PasswordChar = '*';
            }
        }
    }
}
