namespace PasswordManagement
{
    partial class SetupMasterKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupMasterKey));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnLater = new System.Windows.Forms.Button();
            this.PasswordValidity = new System.Windows.Forms.PictureBox();
            this.PasswordValidity2 = new System.Windows.Forms.PictureBox();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.btnProceed = new System.Windows.Forms.Button();
            this.txtEmail = new PasswordManagement.WaterMarkedTextBox();
            this.txtConfirmMasterKey = new PasswordManagement.WaterMarkedTextBox();
            this.txtMasterKey = new PasswordManagement.WaterMarkedTextBox();
            this.EmailHelp = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordValidity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordValidity2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panelTop.Controls.Add(this.btnMinimize);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.lblDescription);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(311, 26);
            this.panelTop.TabIndex = 12;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(263, 1);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(23, 21);
            this.btnMinimize.TabIndex = 21;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.LightGray;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(288, 1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 21);
            this.btnClose.TabIndex = 20;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Gabriola", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDescription.Location = new System.Drawing.Point(104, 1);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(88, 28);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "First-Time Setup";
            this.lblDescription.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDescription_MouseDown);
            this.lblDescription.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDescription_MouseMove);
            this.lblDescription.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDescription_MouseUp);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.Crimson;
            this.lblWarning.Location = new System.Drawing.Point(56, 59);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(189, 32);
            this.lblWarning.TabIndex = 14;
            this.lblWarning.Text = "To protect your privacy, we\r\nrecommend setting a master key";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Gabriola", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.btnConfirm.Location = new System.Drawing.Point(59, 250);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 35);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnLater
            // 
            this.btnLater.AutoSize = true;
            this.btnLater.FlatAppearance.BorderSize = 0;
            this.btnLater.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLater.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLater.Font = new System.Drawing.Font("Gabriola", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLater.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLater.Location = new System.Drawing.Point(253, 355);
            this.btnLater.Name = "btnLater";
            this.btnLater.Size = new System.Drawing.Size(46, 38);
            this.btnLater.TabIndex = 4;
            this.btnLater.Text = "Later";
            this.btnLater.UseVisualStyleBackColor = true;
            this.btnLater.Click += new System.EventHandler(this.btnLater_Click);
            this.btnLater.MouseEnter += new System.EventHandler(this.btnLater_MouseEnter);
            this.btnLater.MouseLeave += new System.EventHandler(this.btnLater_MouseLeave);
            // 
            // PasswordValidity
            // 
            this.PasswordValidity.BackgroundImage = global::PasswordManagement.Properties.Resources.cross;
            this.PasswordValidity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PasswordValidity.Location = new System.Drawing.Point(226, 120);
            this.PasswordValidity.Name = "PasswordValidity";
            this.PasswordValidity.Size = new System.Drawing.Size(26, 26);
            this.PasswordValidity.TabIndex = 18;
            this.PasswordValidity.TabStop = false;
            // 
            // PasswordValidity2
            // 
            this.PasswordValidity2.BackgroundImage = global::PasswordManagement.Properties.Resources.cross;
            this.PasswordValidity2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PasswordValidity2.Location = new System.Drawing.Point(226, 158);
            this.PasswordValidity2.Name = "PasswordValidity2";
            this.PasswordValidity2.Size = new System.Drawing.Size(26, 26);
            this.PasswordValidity2.TabIndex = 18;
            this.PasswordValidity2.TabStop = false;
            // 
            // lblCompleted
            // 
            this.lblCompleted.AutoSize = true;
            this.lblCompleted.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCompleted.Location = new System.Drawing.Point(34, 125);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(257, 30);
            this.lblCompleted.TabIndex = 19;
            this.lblCompleted.Text = "                             That\'s All!\r\nWe promise you won\'t see this window ag" +
    "ain.";
            this.lblCompleted.Visible = false;
            // 
            // btnProceed
            // 
            this.btnProceed.FlatAppearance.BorderSize = 0;
            this.btnProceed.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProceed.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceed.Font = new System.Drawing.Font("Gabriola", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnProceed.Location = new System.Drawing.Point(99, 187);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(120, 35);
            this.btnProceed.TabIndex = 2;
            this.btnProceed.TabStop = false;
            this.btnProceed.Text = "Proceed to iPassword";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Visible = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            this.btnProceed.MouseEnter += new System.EventHandler(this.btnLater_MouseEnter);
            this.btnProceed.MouseLeave += new System.EventHandler(this.btnLater_MouseLeave);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtEmail.Location = new System.Drawing.Point(59, 199);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(160, 23);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtEmail.WaterMarkText = "Email";
            this.txtEmail.TextChanged += new System.EventHandler(this.txtConfirmSetPassword_TextChanged);
            // 
            // txtConfirmMasterKey
            // 
            this.txtConfirmMasterKey.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmMasterKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtConfirmMasterKey.Location = new System.Drawing.Point(59, 158);
            this.txtConfirmMasterKey.Name = "txtConfirmMasterKey";
            this.txtConfirmMasterKey.Size = new System.Drawing.Size(160, 23);
            this.txtConfirmMasterKey.TabIndex = 1;
            this.txtConfirmMasterKey.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtConfirmMasterKey.WaterMarkText = "Confirm Master Key";
            this.txtConfirmMasterKey.TextChanged += new System.EventHandler(this.txtConfirmSetPassword_TextChanged);
            // 
            // txtMasterKey
            // 
            this.txtMasterKey.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasterKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtMasterKey.Location = new System.Drawing.Point(59, 120);
            this.txtMasterKey.Name = "txtMasterKey";
            this.txtMasterKey.Size = new System.Drawing.Size(160, 23);
            this.txtMasterKey.TabIndex = 0;
            this.txtMasterKey.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtMasterKey.WaterMarkText = "Master Key";
            this.txtMasterKey.TextChanged += new System.EventHandler(this.txtSetPassword_TextChanged);
            // 
            // EmailHelp
            // 
            this.EmailHelp.BackgroundImage = global::PasswordManagement.Properties.Resources.help;
            this.EmailHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EmailHelp.Location = new System.Drawing.Point(228, 199);
            this.EmailHelp.Name = "EmailHelp";
            this.EmailHelp.Size = new System.Drawing.Size(22, 22);
            this.EmailHelp.TabIndex = 18;
            this.EmailHelp.TabStop = false;
            // 
            // SetupMasterKey
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(311, 402);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.PasswordValidity);
            this.Controls.Add(this.EmailHelp);
            this.Controls.Add(this.PasswordValidity2);
            this.Controls.Add(this.btnLater);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtConfirmMasterKey);
            this.Controls.Add(this.txtMasterKey);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SetupMasterKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetupLogin";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordValidity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordValidity2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblWarning;
        private WaterMarkedTextBox txtMasterKey;
        private WaterMarkedTextBox txtConfirmMasterKey;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.PictureBox PasswordValidity2;
        private System.Windows.Forms.PictureBox PasswordValidity;
        private System.Windows.Forms.Button btnLater;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Button btnProceed;
        private WaterMarkedTextBox txtEmail;
        private System.Windows.Forms.PictureBox EmailHelp;
    }
}