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
using static Mysqlx.Notice.Warning.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HALAL2025_EVS
{
    public partial class StudentInfo : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=evotingdb";
        public StudentInfo()
        {
            InitializeComponent();
            LoadData();

            BtnEdit.Enabled = false;
            BtnSave.Enabled = false;

            DgvStudentInfo.CellValueChanged += DgvStudentInfo_CellValueChanged;
            DgvStudentInfo.CurrentCellDirtyStateChanged += DgvStudentInfo_CurrentCellDirtyStateChanged;
        }


        private void LoadData()
        {
            DgvStudentInfo.ReadOnly = true;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT student_id, first_name, middle_name, last_name, grade_level, section, vote_status FROM student";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // ✨ Tell the DataGridView to NOT auto-generate columns
                    DgvStudentInfo.AutoGenerateColumns = false;

                    // 🧠 Now bind the data
                    DgvStudentInfo.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadFilteredData(string gradeLevel, string section, string voteStatus, string studentId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT student_id, first_name, middle_name, last_name, grade_level, section, vote_status FROM student WHERE 1=1";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    if (!string.IsNullOrWhiteSpace(gradeLevel) && gradeLevel != "(Grade Level)")
                    {
                        query += " AND grade_level = @gradeLevel";
                        cmd.Parameters.AddWithValue("@gradeLevel", gradeLevel);
                    }

                    if (!string.IsNullOrWhiteSpace(section) && section != "(Section)")
                    {
                        query += " AND section = @section";
                        cmd.Parameters.AddWithValue("@section", section);
                    }

                    if (!string.IsNullOrWhiteSpace(voteStatus) && voteStatus != "(Vote Status)")
                    {
                        int voteValue = voteStatus == "Yes" ? 1 : 0;
                        query += " AND vote_status = @voteStatus";
                        cmd.Parameters.AddWithValue("@voteStatus", voteValue);
                    }

                    if (!string.IsNullOrWhiteSpace(studentId))
                    {
                        query += " AND student_id LIKE @studentId";
                        cmd.Parameters.AddWithValue("@studentId", studentId + "%");
                    }

                    cmd.CommandText = query;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DgvStudentInfo.AutoGenerateColumns = false;
                    DgvStudentInfo.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ApplyFilters()
        {
            string selectedGrade = CmbGLevel.SelectedItem?.ToString();
            string selectedSection = CmbSection.SelectedItem?.ToString();
            string selectedVoteStatus = CmbVoteStatus.SelectedItem?.ToString();
            string searchId = TxtSearch.Text?.Trim();

            LoadFilteredData(selectedGrade, selectedSection, selectedVoteStatus, searchId);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LOGIN form1 = new LOGIN();
            this.Hide();
            form1.Show();
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddStudent form8 = new AddStudent();
            form8.Show();
        }

        private void BtnCandidates_Click(object sender, EventArgs e)
        {
            Candidates form9 = new Candidates();
            this.Hide();
            form9.Show();
        }

        private void BtnOverview_Click(object sender, EventArgs e)
        {
            Overview form6 = new Overview();
            this.Hide();
            form6.Show();
        }

        private void BtnClearFilter_Click(object sender, EventArgs e)
        {
            CmbGLevel.Text = "  (Grade Level)";
            CmbSection.Text = "     (Section)";
            CmbVoteStatus.Text = "   (Vote Status)";
            LoadData();
        }

        private void CmbGLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void CmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void CmbVoteStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            DgvStudentInfo.ReadOnly = false;

            // Make only the student_id column read-only
            DgvStudentInfo.Columns["StudentID"].ReadOnly = true;
            DgvStudentInfo.Columns["VoteStatus"].ReadOnly = true;

            BtnSave.Enabled = false; // Wait for actual changes
        }

        private void DgvStudentInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BtnSave.Enabled = true;
            }
        }

        private void DgvStudentInfo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DgvStudentInfo.IsCurrentCellDirty)
            {
                DgvStudentInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    foreach (DataGridViewRow row in DgvStudentInfo.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string studentId = row.Cells["StudentID"].Value?.ToString();
                        string firstName = row.Cells["FirstName"].Value?.ToString();
                        string middleName = row.Cells["MiddleName"].Value?.ToString();
                        string lastName = row.Cells["LastName"].Value?.ToString();
                        string gradeLevel = row.Cells["Grade"].Value?.ToString();
                        string section = row.Cells["Section"].Value?.ToString();
                        int voteStatus = row.Cells["VoteStatus"].Value != null && row.Cells["VoteStatus"].Value.ToString() == "1" ? 1 : 0;

                        string query = @"UPDATE student 
                                SET first_name = @firstName, 
                                    middle_name = @middleName, 
                                    last_name = @lastName, 
                                    grade_level = @gradeLevel, 
                                    section = @section, 
                                    vote_status = @voteStatus 
                                WHERE student_id = @studentId";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@firstName", firstName);
                            cmd.Parameters.AddWithValue("@middleName", middleName);
                            cmd.Parameters.AddWithValue("@lastName", lastName);
                            cmd.Parameters.AddWithValue("@gradeLevel", gradeLevel);
                            cmd.Parameters.AddWithValue("@section", section);
                            cmd.Parameters.AddWithValue("@voteStatus", voteStatus);
                            cmd.Parameters.AddWithValue("@studentId", studentId);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh after save
                    DgvStudentInfo.ReadOnly = true;
                    BtnSave.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes: " + ex.Message);
                }
            }
        }

        private void DgvStudentInfo_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvStudentInfo.SelectedRows.Count > 0 || DgvStudentInfo.CurrentRow != null)
            {
                BtnEdit.Enabled = true;
            }
            else
            {
                BtnEdit.Enabled = false;
            }
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {
            DgvStudentInfo.SelectionChanged += DgvStudentInfo_SelectionChanged;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected
            if (DgvStudentInfo.SelectedRows.Count > 0)
            {
                // Get the student ID of the selected row
                string studentId = DgvStudentInfo.SelectedRows[0].Cells["StudentID"].Value?.ToString();

                // Confirm deletion
                DialogResult result = MessageBox.Show($"Are you sure you want to delete student {studentId}?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Delete from the database
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();

                            // Prepare the SQL query to delete the student by student ID
                            string query = "DELETE FROM student WHERE student_id = @studentId";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@studentId", studentId);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    // Remove the row from the DataGridView
                                    DgvStudentInfo.Rows.RemoveAt(DgvStudentInfo.SelectedRows[0].Index);
                                }
                                else
                                {
                                    MessageBox.Show("Error: Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting student: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
