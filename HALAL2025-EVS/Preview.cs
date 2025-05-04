using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HALAL2025_EV
{
    public partial class Preview : Form
    {
        private Dictionary<int, string> selectedCandidates;

        // Constructor to receive the selected candidates
        public Preview(Dictionary<int, string> selectedCandidates)
        {
            InitializeComponent();
            this.selectedCandidates = selectedCandidates;
            DisplaySelectedCandidates();
        }

        private void DisplaySelectedCandidates()
        {
            // Check if a candidate has been selected for each position and set the label text
            LblPresName.Text = selectedCandidates.ContainsKey(1) ? selectedCandidates[1] : "No candidate selected";
            LblViceName.Text = selectedCandidates.ContainsKey(2) ? selectedCandidates[2] : "No candidate selected";
            LblSecName.Text = selectedCandidates.ContainsKey(3) ? selectedCandidates[3] : "No candidate selected";
            LblTreasName.Text = selectedCandidates.ContainsKey(4) ? selectedCandidates[4] : "No candidate selected";
            LblAuditName.Text = selectedCandidates.ContainsKey(5) ? selectedCandidates[5] : "No candidate selected";
            LblPIOName.Text = selectedCandidates.ContainsKey(6) ? selectedCandidates[6] : "No candidate selected";
            LblPOName.Text = selectedCandidates.ContainsKey(7) ? selectedCandidates[7] : "No candidate selected";
            LblG4RepName.Text = selectedCandidates.ContainsKey(8) ? selectedCandidates[8] : "No candidate selected";
            LblG5RepName.Text = selectedCandidates.ContainsKey(9) ? selectedCandidates[9] : "No candidate selected";
            LblG6RepName.Text = selectedCandidates.ContainsKey(10) ? selectedCandidates[10] : "No candidate selected";
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
