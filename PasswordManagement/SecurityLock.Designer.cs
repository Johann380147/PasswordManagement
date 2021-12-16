using System.Windows.Forms;

namespace PasswordManagement
{
    partial class SecurityLock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnProceed;
        private Button btnExit;
        private Button btnForgotKey;
        private cPanel_Overlay panelOverlay;
        private LoadingCircle loadingCircle;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityLock));
            this.btnProceed = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnForgotKey = new System.Windows.Forms.Button();
            this.panelOverlay = new PasswordManagement.cPanel_Overlay();
            this.txtID = new PasswordManagement.WaterMarkedTextBox();
            this.loadingCircle = new PasswordManagement.LoadingCircle();
            this.SuspendLayout();
            // 
            // btnProceed
            // 
            this.btnProceed.BackColor = System.Drawing.Color.Transparent;
            this.btnProceed.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnProceed.Location = new System.Drawing.Point(25, 65);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(66, 30);
            this.btnProceed.TabIndex = 2;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnExit.Location = new System.Drawing.Point(128, 65);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnForgotKey
            // 
            this.btnForgotKey.BackColor = System.Drawing.Color.Transparent;
            this.btnForgotKey.FlatAppearance.BorderSize = 0;
            this.btnForgotKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnForgotKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnForgotKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgotKey.Font = new System.Drawing.Font("Gabriola", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgotKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnForgotKey.Location = new System.Drawing.Point(139, 101);
            this.btnForgotKey.Name = "btnForgotKey";
            this.btnForgotKey.Size = new System.Drawing.Size(74, 32);
            this.btnForgotKey.TabIndex = 2;
            this.btnForgotKey.Text = "Forgot Key?";
            this.btnForgotKey.UseVisualStyleBackColor = false;
            this.btnForgotKey.Click += new System.EventHandler(this.btnForgotKey_Click);
            this.btnForgotKey.MouseEnter += new System.EventHandler(this.btnForgotKey_MouseEnter);
            this.btnForgotKey.MouseLeave += new System.EventHandler(this.btnForgotKey_MouseLeave);
            // 
            // panelOverlay
            // 
            this.panelOverlay.Location = new System.Drawing.Point(0, 0);
            this.panelOverlay.Name = "panelOverlay";
            this.panelOverlay.Size = new System.Drawing.Size(35, 17);
            this.panelOverlay.TabIndex = 3;
            this.panelOverlay.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtID.Location = new System.Drawing.Point(25, 37);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(169, 22);
            this.txtID.TabIndex = 0;
            this.txtID.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtID.WaterMarkText = "Key";
            this.txtID.wmTextAlign = PasswordManagement.WaterMarkedTextBox.WaterMarkedTextAlign.Left;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = true;
            this.loadingCircle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.loadingCircle.Color = System.Drawing.Color.White;
            this.loadingCircle.InnerCircleRadius = 6;
            this.loadingCircle.Location = new System.Drawing.Point(111, 106);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 9;
            this.loadingCircle.OuterCircleRadius = 7;
            this.loadingCircle.RotationSpeed = 100;
            this.loadingCircle.Size = new System.Drawing.Size(36, 30);
            this.loadingCircle.SpokeThickness = 4;
            this.loadingCircle.StylePreset = PasswordManagement.LoadingCircle.StylePresets.Firefox;
            this.loadingCircle.TabIndex = 4;
            this.loadingCircle.Text = "loadingCircle1";
            this.loadingCircle.Visible = false;
            // 
            // SecurityLock
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(218, 139);
            this.Controls.Add(this.panelOverlay);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.loadingCircle);
            this.Controls.Add(this.btnForgotKey);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnProceed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SecurityLock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SecurityLock_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SecurityLock_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SecurityLock_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private WaterMarkedTextBox txtID;
    }
}