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
    public partial class Platform : Form
    {
        private string candidateName;
        private string candidatePosition;
        private string candidatePlatform;

        public Platform(string fullName, string position, string campaignMessage)
        {
            InitializeComponent();

            // Set the values directly into the labels
            LblName.Text = fullName;
            LblPosition.Text = position;
            LblShowPlatform.Text = campaignMessage;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // or use this.Hide(); if returning to a form still open
        }
    }
}
