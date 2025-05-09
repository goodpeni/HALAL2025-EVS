﻿using MySql.Data.MySqlClient;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.IO;

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


        public void LoadData()
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

                    DgvStudentInfo.AutoGenerateColumns = false;

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


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddStudent form8 = new AddStudent(this);
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
            TxtSearch.Clear();
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

            DgvStudentInfo.Columns["StudentID"].ReadOnly = true;
            DgvStudentInfo.Columns["VoteStatus"].ReadOnly = true;

            BtnSave.Enabled = false;
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
                    LoadData();
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
            if (DgvStudentInfo.SelectedRows.Count > 0)
            {
                string studentId = DgvStudentInfo.SelectedRows[0].Cells["StudentID"].Value?.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to delete student {studentId}?",
                                                      "Confirm Deletion",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();

                            string query = "DELETE FROM student WHERE student_id = @studentId";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@studentId", studentId);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SQL Files (*.sql)|*.sql|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string sqlCommands = System.IO.File.ReadAllText(filePath);

                    string[] queries = sqlCommands.Split(new[] { ";\r\n", ";\n" }, StringSplitOptions.RemoveEmptyEntries);

                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        foreach (string query in queries)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Students imported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error importing students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt the user to choose a file location and name using SaveFileDialog
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.DefaultExt = "pdf";
                    saveFileDialog.AddExtension = true;

                    // If the user selects a file location, proceed
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Create a new PDF document
                        Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                        doc.Open();

                        // Add title
                        var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                        Paragraph title = new Paragraph("Student Information Report", titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 20f
                        };
                        doc.Add(title);

                        // Create a table with the same number of columns as the DataGridView
                        PdfPTable pdfTable = new PdfPTable(DgvStudentInfo.Columns.Count);
                        pdfTable.WidthPercentage = 100;

                        // Add headers
                        foreach (DataGridViewColumn column in DgvStudentInfo.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText))
                            {
                                BackgroundColor = new BaseColor(230, 230, 250) // light purple
                            };
                            pdfTable.AddCell(cell);
                        }

                        // Add rows
                        foreach (DataGridViewRow row in DgvStudentInfo.Rows)
                        {
                            if (row.IsNewRow) continue;

                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                string value = cell.Value?.ToString() ?? "";
                                pdfTable.AddCell(value);
                            }
                        }

                        doc.Add(pdfTable);
                        doc.Close();

                        MessageBox.Show($"Report generated successfully!\n\nSaved to: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
