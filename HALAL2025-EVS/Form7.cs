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
    public partial class StudentInfo : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=evotingdb";
        public StudentInfo()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {            
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT student_id, ";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    DgvStudentInfo.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LOGIN form1 = new LOGIN();
            this.Hide();
            form1.Show();
        }
    }
}
