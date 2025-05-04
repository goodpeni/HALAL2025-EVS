namespace HALAL2025_EVS
{
    partial class AddStudent
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
            this.PicBoxLogo = new System.Windows.Forms.PictureBox();
            this.LblTitle1 = new System.Windows.Forms.Label();
            this.PnlAddStud = new System.Windows.Forms.Panel();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.ChkShowPass = new System.Windows.Forms.CheckBox();
            this.TxtConfirmPass = new System.Windows.Forms.TextBox();
            this.CmbSection = new System.Windows.Forms.ComboBox();
            this.CmbGrade = new System.Windows.Forms.ComboBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.LblPassworrd = new System.Windows.Forms.Label();
            this.LblGrade = new System.Windows.Forms.Label();
            this.LblLastName = new System.Windows.Forms.Label();
            this.TxtMiddleName = new System.Windows.Forms.TextBox();
            this.LblMiddleName = new System.Windows.Forms.Label();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.LblFirstName = new System.Windows.Forms.Label();
            this.TxtStudentID = new System.Windows.Forms.TextBox();
            this.LblStudentID = new System.Windows.Forms.Label();
            this.LblSection = new System.Windows.Forms.Label();
            this.LblConfirmPass = new System.Windows.Forms.Label();
            this.LblAddStud = new System.Windows.Forms.Label();
            this.PnlHeading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLogo)).BeginInit();
            this.PnlAddStud.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlHeading
            // 
            this.PnlHeading.BackColor = System.Drawing.Color.DarkCyan;
            this.PnlHeading.BackgroundImage = global::HALAL2025_EVS.Properties.Resources.login_bg;
            this.PnlHeading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlHeading.Controls.Add(this.LblTitle2);
            this.PnlHeading.Controls.Add(this.PicBoxLogo);
            this.PnlHeading.Controls.Add(this.LblTitle1);
            this.PnlHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeading.Location = new System.Drawing.Point(0, 0);
            this.PnlHeading.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PnlHeading.Name = "PnlHeading";
            this.PnlHeading.Size = new System.Drawing.Size(467, 67);
            this.PnlHeading.TabIndex = 4;
            // 
            // LblTitle2
            // 
            this.LblTitle2.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle2.ForeColor = System.Drawing.Color.White;
            this.LblTitle2.Location = new System.Drawing.Point(69, 31);
            this.LblTitle2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitle2.Name = "LblTitle2";
            this.LblTitle2.Size = new System.Drawing.Size(310, 20);
            this.LblTitle2.TabIndex = 2;
            this.LblTitle2.Text = "IBAYO ELEMENTARY SCHOOL";
            this.LblTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PicBoxLogo
            // 
            this.PicBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.PicBoxLogo.BackgroundImage = global::HALAL2025_EVS.Properties.Resources.halal20225;
            this.PicBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicBoxLogo.Location = new System.Drawing.Point(10, 1);
            this.PicBoxLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PicBoxLogo.Name = "PicBoxLogo";
            this.PicBoxLogo.Size = new System.Drawing.Size(56, 61);
            this.PicBoxLogo.TabIndex = 1;
            this.PicBoxLogo.TabStop = false;
            // 
            // LblTitle1
            // 
            this.LblTitle1.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle1.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle1.ForeColor = System.Drawing.Color.White;
            this.LblTitle1.Location = new System.Drawing.Point(68, 10);
            this.LblTitle1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblTitle1.Name = "LblTitle1";
            this.LblTitle1.Size = new System.Drawing.Size(376, 28);
            this.LblTitle1.TabIndex = 0;
            this.LblTitle1.Text = "HALAL 2025 E-VOTING SYSTEM\r\n";
            this.LblTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PnlAddStud
            // 
            this.PnlAddStud.BackgroundImage = global::HALAL2025_EVS.Properties.Resources.login_bg;
            this.PnlAddStud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlAddStud.Controls.Add(this.BtnAdd);
            this.PnlAddStud.Controls.Add(this.BtnBack);
            this.PnlAddStud.Controls.Add(this.ChkShowPass);
            this.PnlAddStud.Controls.Add(this.TxtConfirmPass);
            this.PnlAddStud.Controls.Add(this.CmbSection);
            this.PnlAddStud.Controls.Add(this.CmbGrade);
            this.PnlAddStud.Controls.Add(this.TxtPassword);
            this.PnlAddStud.Controls.Add(this.TxtLastName);
            this.PnlAddStud.Controls.Add(this.LblPassworrd);
            this.PnlAddStud.Controls.Add(this.LblGrade);
            this.PnlAddStud.Controls.Add(this.LblLastName);
            this.PnlAddStud.Controls.Add(this.TxtMiddleName);
            this.PnlAddStud.Controls.Add(this.LblMiddleName);
            this.PnlAddStud.Controls.Add(this.TxtFirstName);
            this.PnlAddStud.Controls.Add(this.LblFirstName);
            this.PnlAddStud.Controls.Add(this.TxtStudentID);
            this.PnlAddStud.Controls.Add(this.LblStudentID);
            this.PnlAddStud.Controls.Add(this.LblSection);
            this.PnlAddStud.Controls.Add(this.LblConfirmPass);
            this.PnlAddStud.Location = new System.Drawing.Point(36, 110);
            this.PnlAddStud.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PnlAddStud.Name = "PnlAddStud";
            this.PnlAddStud.Size = new System.Drawing.Size(396, 423);
            this.PnlAddStud.TabIndex = 5;
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(71)))), ((int)(((byte)(74)))));
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(271, 389);
            this.BtnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(116, 24);
            this.BtnAdd.TabIndex = 25;
            this.BtnAdd.Text = "ADD";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.Maroon;
            this.BtnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBack.FlatAppearance.BorderSize = 0;
            this.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBack.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.ForeColor = System.Drawing.Color.White;
            this.BtnBack.Location = new System.Drawing.Point(8, 389);
            this.BtnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(116, 24);
            this.BtnBack.TabIndex = 24;
            this.BtnBack.Text = "BACK";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // ChkShowPass
            // 
            this.ChkShowPass.AutoSize = true;
            this.ChkShowPass.BackColor = System.Drawing.Color.Transparent;
            this.ChkShowPass.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkShowPass.ForeColor = System.Drawing.Color.White;
            this.ChkShowPass.Location = new System.Drawing.Point(262, 351);
            this.ChkShowPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChkShowPass.Name = "ChkShowPass";
            this.ChkShowPass.Size = new System.Drawing.Size(101, 18);
            this.ChkShowPass.TabIndex = 23;
            this.ChkShowPass.Text = "show password";
            this.ChkShowPass.UseVisualStyleBackColor = false;
            this.ChkShowPass.CheckedChanged += new System.EventHandler(this.ChkShowPass_CheckedChanged);
            // 
            // TxtConfirmPass
            // 
            this.TxtConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtConfirmPass.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConfirmPass.Location = new System.Drawing.Point(178, 324);
            this.TxtConfirmPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtConfirmPass.Name = "TxtConfirmPass";
            this.TxtConfirmPass.PasswordChar = '*';
            this.TxtConfirmPass.Size = new System.Drawing.Size(185, 23);
            this.TxtConfirmPass.TabIndex = 21;
            // 
            // CmbSection
            // 
            this.CmbSection.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSection.FormattingEnabled = true;
            this.CmbSection.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.CmbSection.Location = new System.Drawing.Point(255, 213);
            this.CmbSection.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CmbSection.Name = "CmbSection";
            this.CmbSection.Size = new System.Drawing.Size(108, 24);
            this.CmbSection.TabIndex = 20;
            // 
            // CmbGrade
            // 
            this.CmbGrade.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbGrade.FormattingEnabled = true;
            this.CmbGrade.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.CmbGrade.Location = new System.Drawing.Point(125, 213);
            this.CmbGrade.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CmbGrade.Name = "CmbGrade";
            this.CmbGrade.Size = new System.Drawing.Size(56, 24);
            this.CmbGrade.TabIndex = 19;
            // 
            // TxtPassword
            // 
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.Location = new System.Drawing.Point(178, 281);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(185, 23);
            this.TxtPassword.TabIndex = 17;
            // 
            // TxtLastName
            // 
            this.TxtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtLastName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLastName.Location = new System.Drawing.Point(125, 175);
            this.TxtLastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(238, 23);
            this.TxtLastName.TabIndex = 15;
            // 
            // LblPassworrd
            // 
            this.LblPassworrd.BackColor = System.Drawing.Color.Transparent;
            this.LblPassworrd.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPassworrd.ForeColor = System.Drawing.Color.White;
            this.LblPassworrd.Location = new System.Drawing.Point(20, 284);
            this.LblPassworrd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblPassworrd.Name = "LblPassworrd";
            this.LblPassworrd.Size = new System.Drawing.Size(154, 19);
            this.LblPassworrd.TabIndex = 14;
            this.LblPassworrd.Text = "PASSWORD";
            this.LblPassworrd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblGrade
            // 
            this.LblGrade.BackColor = System.Drawing.Color.Transparent;
            this.LblGrade.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGrade.ForeColor = System.Drawing.Color.White;
            this.LblGrade.Location = new System.Drawing.Point(20, 216);
            this.LblGrade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblGrade.Name = "LblGrade";
            this.LblGrade.Size = new System.Drawing.Size(97, 19);
            this.LblGrade.TabIndex = 13;
            this.LblGrade.Text = "GRADE";
            this.LblGrade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblLastName
            // 
            this.LblLastName.BackColor = System.Drawing.Color.Transparent;
            this.LblLastName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLastName.ForeColor = System.Drawing.Color.White;
            this.LblLastName.Location = new System.Drawing.Point(20, 178);
            this.LblLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblLastName.Name = "LblLastName";
            this.LblLastName.Size = new System.Drawing.Size(97, 19);
            this.LblLastName.TabIndex = 12;
            this.LblLastName.Text = "LAST NAME";
            this.LblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtMiddleName
            // 
            this.TxtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMiddleName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMiddleName.Location = new System.Drawing.Point(125, 133);
            this.TxtMiddleName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtMiddleName.Name = "TxtMiddleName";
            this.TxtMiddleName.Size = new System.Drawing.Size(238, 23);
            this.TxtMiddleName.TabIndex = 11;
            // 
            // LblMiddleName
            // 
            this.LblMiddleName.BackColor = System.Drawing.Color.Transparent;
            this.LblMiddleName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMiddleName.ForeColor = System.Drawing.Color.White;
            this.LblMiddleName.Location = new System.Drawing.Point(20, 136);
            this.LblMiddleName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblMiddleName.Name = "LblMiddleName";
            this.LblMiddleName.Size = new System.Drawing.Size(97, 19);
            this.LblMiddleName.TabIndex = 10;
            this.LblMiddleName.Text = "MIDDLE NAME";
            this.LblMiddleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFirstName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFirstName.Location = new System.Drawing.Point(125, 90);
            this.TxtFirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(238, 23);
            this.TxtFirstName.TabIndex = 9;
            // 
            // LblFirstName
            // 
            this.LblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.LblFirstName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFirstName.ForeColor = System.Drawing.Color.White;
            this.LblFirstName.Location = new System.Drawing.Point(20, 93);
            this.LblFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblFirstName.Name = "LblFirstName";
            this.LblFirstName.Size = new System.Drawing.Size(97, 19);
            this.LblFirstName.TabIndex = 8;
            this.LblFirstName.Text = "FIRST NAME";
            this.LblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtStudentID
            // 
            this.TxtStudentID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtStudentID.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStudentID.Location = new System.Drawing.Point(125, 26);
            this.TxtStudentID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtStudentID.Name = "TxtStudentID";
            this.TxtStudentID.Size = new System.Drawing.Size(238, 23);
            this.TxtStudentID.TabIndex = 7;
            // 
            // LblStudentID
            // 
            this.LblStudentID.BackColor = System.Drawing.Color.Transparent;
            this.LblStudentID.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStudentID.ForeColor = System.Drawing.Color.White;
            this.LblStudentID.Location = new System.Drawing.Point(20, 29);
            this.LblStudentID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblStudentID.Name = "LblStudentID";
            this.LblStudentID.Size = new System.Drawing.Size(97, 19);
            this.LblStudentID.TabIndex = 6;
            this.LblStudentID.Text = "STUDENT ID";
            this.LblStudentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblSection
            // 
            this.LblSection.BackColor = System.Drawing.Color.Transparent;
            this.LblSection.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSection.ForeColor = System.Drawing.Color.White;
            this.LblSection.Location = new System.Drawing.Point(184, 216);
            this.LblSection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblSection.Name = "LblSection";
            this.LblSection.Size = new System.Drawing.Size(86, 19);
            this.LblSection.TabIndex = 18;
            this.LblSection.Text = "SECTION";
            this.LblSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblConfirmPass
            // 
            this.LblConfirmPass.BackColor = System.Drawing.Color.Transparent;
            this.LblConfirmPass.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblConfirmPass.ForeColor = System.Drawing.Color.White;
            this.LblConfirmPass.Location = new System.Drawing.Point(20, 327);
            this.LblConfirmPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblConfirmPass.Name = "LblConfirmPass";
            this.LblConfirmPass.Size = new System.Drawing.Size(241, 19);
            this.LblConfirmPass.TabIndex = 22;
            this.LblConfirmPass.Text = "CONFIRM PASSWORD";
            this.LblConfirmPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAddStud
            // 
            this.LblAddStud.BackColor = System.Drawing.Color.Transparent;
            this.LblAddStud.Font = new System.Drawing.Font("Arial Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAddStud.ForeColor = System.Drawing.Color.White;
            this.LblAddStud.Location = new System.Drawing.Point(36, 73);
            this.LblAddStud.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblAddStud.Name = "LblAddStud";
            this.LblAddStud.Size = new System.Drawing.Size(396, 36);
            this.LblAddStud.TabIndex = 3;
            this.LblAddStud.Text = "ADD STUDENT";
            this.LblAddStud.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HALAL2025_EVS.Properties.Resources.darkmode;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(467, 559);
            this.ControlBox = false;
            this.Controls.Add(this.LblAddStud);
            this.Controls.Add(this.PnlAddStud);
            this.Controls.Add(this.PnlHeading);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form8";
            this.PnlHeading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLogo)).EndInit();
            this.PnlAddStud.ResumeLayout(false);
            this.PnlAddStud.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlHeading;
        private System.Windows.Forms.Label LblTitle2;
        private System.Windows.Forms.PictureBox PicBoxLogo;
        private System.Windows.Forms.Label LblTitle1;
        private System.Windows.Forms.Panel PnlAddStud;
        private System.Windows.Forms.Label LblAddStud;
        private System.Windows.Forms.Label LblStudentID;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.Label LblPassworrd;
        private System.Windows.Forms.Label LblGrade;
        private System.Windows.Forms.Label LblLastName;
        private System.Windows.Forms.TextBox TxtMiddleName;
        private System.Windows.Forms.Label LblMiddleName;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.Label LblFirstName;
        private System.Windows.Forms.TextBox TxtStudentID;
        private System.Windows.Forms.ComboBox CmbSection;
        private System.Windows.Forms.ComboBox CmbGrade;
        private System.Windows.Forms.Label LblSection;
        private System.Windows.Forms.Label LblConfirmPass;
        private System.Windows.Forms.TextBox TxtConfirmPass;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.CheckBox ChkShowPass;
    }
}