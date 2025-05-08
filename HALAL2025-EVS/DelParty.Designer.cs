namespace HALAL2025_EVS
{
    partial class DelParty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlHeading = new System.Windows.Forms.Panel();
            this.LblTitle2 = new System.Windows.Forms.Label();
            this.LblTitle1 = new System.Windows.Forms.Label();
            this.PicBoxLogo = new System.Windows.Forms.PictureBox();
            this.LblAddParty = new System.Windows.Forms.Label();
            this.PnlAddPartylist = new System.Windows.Forms.Panel();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.LblPartylistName = new System.Windows.Forms.Label();
            this.CmbPartylist = new System.Windows.Forms.ComboBox();
            this.PnlHeading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLogo)).BeginInit();
            this.PnlAddPartylist.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlHeading
            // 
            this.PnlHeading.BackColor = System.Drawing.Color.DarkCyan;
            this.PnlHeading.BackgroundImage = global::HALAL2025_EVS.Properties.Resources.login_bg;
            this.PnlHeading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlHeading.Controls.Add(this.LblTitle2);
            this.PnlHeading.Controls.Add(this.LblTitle1);
            this.PnlHeading.Controls.Add(this.PicBoxLogo);
            this.PnlHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeading.Location = new System.Drawing.Point(0, 0);
            this.PnlHeading.Margin = new System.Windows.Forms.Padding(2);
            this.PnlHeading.Name = "PnlHeading";
            this.PnlHeading.Size = new System.Drawing.Size(433, 67);
            this.PnlHeading.TabIndex = 7;
            // 
            // LblTitle2
            // 
            this.LblTitle2.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle2.ForeColor = System.Drawing.Color.White;
            this.LblTitle2.Location = new System.Drawing.Point(71, 28);
            this.LblTitle2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitle2.Name = "LblTitle2";
            this.LblTitle2.Size = new System.Drawing.Size(286, 20);
            this.LblTitle2.TabIndex = 4;
            this.LblTitle2.Text = "IBAYO ELEMENTARY SCHOOL";
            this.LblTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitle1
            // 
            this.LblTitle1.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle1.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle1.ForeColor = System.Drawing.Color.White;
            this.LblTitle1.Location = new System.Drawing.Point(70, 7);
            this.LblTitle1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitle1.Name = "LblTitle1";
            this.LblTitle1.Size = new System.Drawing.Size(361, 28);
            this.LblTitle1.TabIndex = 3;
            this.LblTitle1.Text = "HALAL 2025 E-VOTING SYSTEM\r\n";
            this.LblTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PicBoxLogo
            // 
            this.PicBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.PicBoxLogo.BackgroundImage = global::HALAL2025_EVS.Properties.Resources.halal20225;
            this.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicBoxLogo.Location = new System.Drawing.Point(10, 2);
            this.PicBoxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.PicBoxLogo.Name = "PicBoxLogo";
            this.PicBoxLogo.Size = new System.Drawing.Size(56, 61);
            this.PicBoxLogo.TabIndex = 1;
            this.PicBoxLogo.TabStop = false;
            // 
            // LblAddParty
            // 
            this.LblAddParty.BackColor = System.Drawing.Color.Transparent;
            this.LblAddParty.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAddParty.ForeColor = System.Drawing.Color.White;
            this.LblAddParty.Location = new System.Drawing.Point(26, 75);
            this.LblAddParty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblAddParty.Name = "LblAddParty";
            this.LblAddParty.Size = new System.Drawing.Size(378, 36);
            this.LblAddParty.TabIndex = 9;
            this.LblAddParty.Text = "ADD PARTYLIST";
            this.LblAddParty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlAddPartylist
            // 
            this.PnlAddPartylist.BackgroundImage = global::HALAL2025_EVS.Properties.Resources.login_bg;
            this.PnlAddPartylist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlAddPartylist.Controls.Add(this.CmbPartylist);
            this.PnlAddPartylist.Controls.Add(this.BtnDelete);
            this.PnlAddPartylist.Controls.Add(this.BtnBack);
            this.PnlAddPartylist.Controls.Add(this.LblPartylistName);
            this.PnlAddPartylist.Location = new System.Drawing.Point(26, 116);
            this.PnlAddPartylist.Margin = new System.Windows.Forms.Padding(2);
            this.PnlAddPartylist.Name = "PnlAddPartylist";
            this.PnlAddPartylist.Size = new System.Drawing.Size(378, 136);
            this.PnlAddPartylist.TabIndex = 10;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(71)))), ((int)(((byte)(74)))));
            this.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDelete.FlatAppearance.BorderSize = 0;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(233, 89);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(116, 24);
            this.BtnDelete.TabIndex = 75;
            this.BtnDelete.Text = "DELETE";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.Maroon;
            this.BtnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBack.FlatAppearance.BorderSize = 0;
            this.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBack.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.ForeColor = System.Drawing.Color.White;
            this.BtnBack.Location = new System.Drawing.Point(30, 89);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(116, 24);
            this.BtnBack.TabIndex = 74;
            this.BtnBack.Text = "BACK";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // LblPartylistName
            // 
            this.LblPartylistName.BackColor = System.Drawing.Color.Transparent;
            this.LblPartylistName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPartylistName.ForeColor = System.Drawing.Color.White;
            this.LblPartylistName.Location = new System.Drawing.Point(27, 33);
            this.LblPartylistName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblPartylistName.Name = "LblPartylistName";
            this.LblPartylistName.Size = new System.Drawing.Size(127, 19);
            this.LblPartylistName.TabIndex = 57;
            this.LblPartylistName.Text = "PARTYLIST NAME\r\n\r\n";
            this.LblPartylistName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbPartylist
            // 
            this.CmbPartylist.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPartylist.FormattingEnabled = true;
            this.CmbPartylist.Location = new System.Drawing.Point(158, 29);
            this.CmbPartylist.Name = "CmbPartylist";
            this.CmbPartylist.Size = new System.Drawing.Size(191, 24);
            this.CmbPartylist.TabIndex = 76;
            // 
            // DelParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HALAL2025_EVS.Properties.Resources.darkmode;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(433, 282);
            this.Controls.Add(this.PnlAddPartylist);
            this.Controls.Add(this.LblAddParty);
            this.Controls.Add(this.PnlHeading);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DelParty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DelParty";
            this.PnlHeading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLogo)).EndInit();
            this.PnlAddPartylist.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlHeading;
        private System.Windows.Forms.Label LblTitle2;
        private System.Windows.Forms.Label LblTitle1;
        private System.Windows.Forms.PictureBox PicBoxLogo;
        private System.Windows.Forms.Label LblAddParty;
        private System.Windows.Forms.Panel PnlAddPartylist;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label LblPartylistName;
        private System.Windows.Forms.ComboBox CmbPartylist;
    }
}