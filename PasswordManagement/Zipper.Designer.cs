namespace PasswordManagement
{
    partial class Zipper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zipper));
            this.btnClearPicture = new System.Windows.Forms.Button();
            this.panelPasswordLength = new System.Windows.Forms.Panel();
            this.txtPasswordLength = new System.Windows.Forms.TextBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.btnGoToLink = new System.Windows.Forms.Button();
            this.btnCopyLink = new System.Windows.Forms.Button();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.btnGenPassword = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddImage = new System.Windows.Forms.Label();
            this.lblExtras = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtExtras = new System.Windows.Forms.TextBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.comboGetCategory = new System.Windows.Forms.ComboBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSortDescending = new System.Windows.Forms.Button();
            this.btnSortAscending = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLockUnlock = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.accountsDataSet = new PasswordManagement.AccountsDataSet();
            this.accountsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelSearchRegion = new System.Windows.Forms.Panel();
            this.txtCategory = new PasswordManagement.WaterMarkedTextBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.roundedTextBox1 = new PasswordManagement.RoundedTextBox();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnDeleteCategory = new System.Windows.Forms.Button();
            this.comboEditingCategory = new System.Windows.Forms.ComboBox();
            this.panelAccountsRegion = new System.Windows.Forms.Panel();
            this.loadingCircle = new PasswordManagement.LoadingCircle();
            this.lblNoAccountPrompt = new System.Windows.Forms.Label();
            this.panelAddSort = new System.Windows.Forms.Panel();
            this.lstViewAccountsSaved = new PasswordManagement.ListViewCustom();
            this.Accounts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelPasswordStrength = new PasswordManagement.cPanel_PasswordStrength();
            this.panelFadingEffect = new PasswordManagement.cPanel_Fading();
            this.panelPasswordLength.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataSetBindingSource)).BeginInit();
            this.panelSearchRegion.SuspendLayout();
            this.panelAccountsRegion.SuspendLayout();
            this.panelAddSort.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearPicture
            // 
            this.btnClearPicture.FlatAppearance.BorderSize = 0;
            this.btnClearPicture.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClearPicture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClearPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearPicture.Font = new System.Drawing.Font("Maiandra GD", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPicture.Location = new System.Drawing.Point(441, 64);
            this.btnClearPicture.Name = "btnClearPicture";
            this.btnClearPicture.Size = new System.Drawing.Size(20, 20);
            this.btnClearPicture.TabIndex = 8;
            this.btnClearPicture.Text = "x";
            this.btnClearPicture.UseVisualStyleBackColor = true;
            this.btnClearPicture.Click += new System.EventHandler(this.btnClearPicture_Click);
            // 
            // panelPasswordLength
            // 
            this.panelPasswordLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelPasswordLength.Controls.Add(this.txtPasswordLength);
            this.panelPasswordLength.Location = new System.Drawing.Point(838, 277);
            this.panelPasswordLength.Name = "panelPasswordLength";
            this.panelPasswordLength.Size = new System.Drawing.Size(42, 30);
            this.panelPasswordLength.TabIndex = 8;
            this.panelPasswordLength.Visible = false;
            this.panelPasswordLength.MouseLeave += new System.EventHandler(this.panelPasswordLength_MouseLeave);
            // 
            // txtPasswordLength
            // 
            this.txtPasswordLength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtPasswordLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPasswordLength.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordLength.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPasswordLength.Location = new System.Drawing.Point(8, 7);
            this.txtPasswordLength.MaxLength = 3;
            this.txtPasswordLength.Name = "txtPasswordLength";
            this.txtPasswordLength.Size = new System.Drawing.Size(25, 15);
            this.txtPasswordLength.TabIndex = 0;
            this.txtPasswordLength.TabStop = false;
            this.txtPasswordLength.Text = "15";
            this.txtPasswordLength.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswordLength_KeyDown);
            // 
            // comboCategory
            // 
            this.comboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(561, 497);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(233, 24);
            this.comboCategory.TabIndex = 5;
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.InitialImage = global::PasswordManagement.Properties.Resources.defaultimg;
            this.pbImage.Location = new System.Drawing.Point(461, 72);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(170, 70);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 9;
            this.pbImage.TabStop = false;
            this.pbImage.BackgroundImageChanged += new System.EventHandler(this.pbImage_BackgroundImageChanged);
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Maiandra GD", 9.75F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtPassword.Location = new System.Drawing.Point(561, 315);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(233, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDuplicate.FlatAppearance.BorderSize = 0;
            this.btnDuplicate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuplicate.Image = global::PasswordManagement.Properties.Resources.duplicate;
            this.btnDuplicate.Location = new System.Drawing.Point(440, 584);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(20, 21);
            this.btnDuplicate.TabIndex = 9;
            this.btnDuplicate.TabStop = false;
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // btnGoToLink
            // 
            this.btnGoToLink.BackColor = System.Drawing.Color.Transparent;
            this.btnGoToLink.FlatAppearance.BorderSize = 0;
            this.btnGoToLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToLink.Image = global::PasswordManagement.Properties.Resources.externalink;
            this.btnGoToLink.Location = new System.Drawing.Point(838, 230);
            this.btnGoToLink.Name = "btnGoToLink";
            this.btnGoToLink.Size = new System.Drawing.Size(22, 22);
            this.btnGoToLink.TabIndex = 7;
            this.btnGoToLink.TabStop = false;
            this.btnGoToLink.UseVisualStyleBackColor = false;
            this.btnGoToLink.Click += new System.EventHandler(this.btnGoToLink_Click);
            // 
            // btnCopyLink
            // 
            this.btnCopyLink.BackColor = System.Drawing.Color.Transparent;
            this.btnCopyLink.FlatAppearance.BorderSize = 0;
            this.btnCopyLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyLink.Image = global::PasswordManagement.Properties.Resources.copylink;
            this.btnCopyLink.Location = new System.Drawing.Point(807, 230);
            this.btnCopyLink.Name = "btnCopyLink";
            this.btnCopyLink.Size = new System.Drawing.Size(22, 22);
            this.btnCopyLink.TabIndex = 7;
            this.btnCopyLink.TabStop = false;
            this.btnCopyLink.UseVisualStyleBackColor = false;
            this.btnCopyLink.Click += new System.EventHandler(this.btnCopyLink_Click);
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPassword.FlatAppearance.BorderSize = 0;
            this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPassword.Image = global::PasswordManagement.Properties.Resources.show;
            this.btnShowPassword.Location = new System.Drawing.Point(807, 314);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(25, 24);
            this.btnShowPassword.TabIndex = 7;
            this.btnShowPassword.TabStop = false;
            this.btnShowPassword.UseVisualStyleBackColor = false;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // btnGenPassword
            // 
            this.btnGenPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnGenPassword.FlatAppearance.BorderSize = 0;
            this.btnGenPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenPassword.Image = global::PasswordManagement.Properties.Resources.genpw;
            this.btnGenPassword.Location = new System.Drawing.Point(838, 313);
            this.btnGenPassword.Name = "btnGenPassword";
            this.btnGenPassword.Size = new System.Drawing.Size(24, 24);
            this.btnGenPassword.TabIndex = 7;
            this.btnGenPassword.TabStop = false;
            this.btnGenPassword.UseVisualStyleBackColor = false;
            this.btnGenPassword.Click += new System.EventHandler(this.btnGenPassword_Click);
            this.btnGenPassword.MouseEnter += new System.EventHandler(this.btnGenPassword_MouseEnter);
            this.btnGenPassword.MouseLeave += new System.EventHandler(this.btnGenPassword_MouseLeave);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(497, 182);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 29);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblAddImage
            // 
            this.lblAddImage.AutoSize = true;
            this.lblAddImage.BackColor = System.Drawing.Color.Transparent;
            this.lblAddImage.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddImage.Location = new System.Drawing.Point(492, 92);
            this.lblAddImage.Name = "lblAddImage";
            this.lblAddImage.Size = new System.Drawing.Size(108, 29);
            this.lblAddImage.TabIndex = 1;
            this.lblAddImage.Text = "Click to add Image";
            this.lblAddImage.Visible = false;
            this.lblAddImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // lblExtras
            // 
            this.lblExtras.AutoSize = true;
            this.lblExtras.BackColor = System.Drawing.Color.Transparent;
            this.lblExtras.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtras.Location = new System.Drawing.Point(490, 355);
            this.lblExtras.Name = "lblExtras";
            this.lblExtras.Size = new System.Drawing.Size(48, 29);
            this.lblExtras.TabIndex = 1;
            this.lblExtras.Text = "Extras:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(477, 309);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(64, 29);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(474, 265);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(68, 29);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // txtExtras
            // 
            this.txtExtras.Font = new System.Drawing.Font("Maiandra GD", 9.75F);
            this.txtExtras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtExtras.Location = new System.Drawing.Point(561, 367);
            this.txtExtras.Multiline = true;
            this.txtExtras.Name = "txtExtras";
            this.txtExtras.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExtras.Size = new System.Drawing.Size(233, 108);
            this.txtExtras.TabIndex = 4;
            // 
            // txtWebsite
            // 
            this.txtWebsite.Font = new System.Drawing.Font("Maiandra GD", 9.75F);
            this.txtWebsite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtWebsite.Location = new System.Drawing.Point(561, 229);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(233, 23);
            this.txtWebsite.TabIndex = 1;
            this.txtWebsite.TextChanged += new System.EventHandler(this.txtWebsite_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Maiandra GD", 9.75F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtUsername.Location = new System.Drawing.Point(561, 271);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(233, 23);
            this.txtUsername.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Maiandra GD", 9.75F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtName.Location = new System.Drawing.Point(561, 188);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(233, 23);
            this.txtName.TabIndex = 0;
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.BackColor = System.Drawing.Color.Transparent;
            this.lblWebsite.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebsite.Location = new System.Drawing.Point(487, 223);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(54, 29);
            this.lblWebsite.TabIndex = 1;
            this.lblWebsite.Text = "Website:";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(150, 70);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // comboGetCategory
            // 
            this.comboGetCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGetCategory.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboGetCategory.FormattingEnabled = true;
            this.comboGetCategory.Location = new System.Drawing.Point(354, 9);
            this.comboGetCategory.Name = "comboGetCategory";
            this.comboGetCategory.Size = new System.Drawing.Size(70, 24);
            this.comboGetCategory.TabIndex = 10;
            this.comboGetCategory.SelectedIndexChanged += new System.EventHandler(this.comboGetCategory_SelectedIndexChanged);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Image = global::PasswordManagement.Properties.Resources.addblank;
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.Location = new System.Drawing.Point(12, 7);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(92, 26);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.TabStop = false;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSortDescending
            // 
            this.btnSortDescending.BackColor = System.Drawing.Color.Transparent;
            this.btnSortDescending.FlatAppearance.BorderSize = 0;
            this.btnSortDescending.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnSortDescending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortDescending.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortDescending.Image = global::PasswordManagement.Properties.Resources.sortdescend;
            this.btnSortDescending.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSortDescending.Location = new System.Drawing.Point(227, 8);
            this.btnSortDescending.Name = "btnSortDescending";
            this.btnSortDescending.Size = new System.Drawing.Size(124, 26);
            this.btnSortDescending.TabIndex = 3;
            this.btnSortDescending.TabStop = false;
            this.btnSortDescending.Text = "Sort Descending";
            this.btnSortDescending.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSortDescending.UseVisualStyleBackColor = false;
            this.btnSortDescending.Click += new System.EventHandler(this.btnSortDescending_Click);
            // 
            // btnSortAscending
            // 
            this.btnSortAscending.BackColor = System.Drawing.Color.Transparent;
            this.btnSortAscending.FlatAppearance.BorderSize = 0;
            this.btnSortAscending.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.btnSortAscending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortAscending.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortAscending.Image = global::PasswordManagement.Properties.Resources.sort;
            this.btnSortAscending.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSortAscending.Location = new System.Drawing.Point(108, 7);
            this.btnSortAscending.Name = "btnSortAscending";
            this.btnSortAscending.Size = new System.Drawing.Size(119, 26);
            this.btnSortAscending.TabIndex = 3;
            this.btnSortAscending.TabStop = false;
            this.btnSortAscending.Text = "Sort Ascending";
            this.btnSortAscending.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSortAscending.UseVisualStyleBackColor = false;
            this.btnSortAscending.Click += new System.EventHandler(this.btnSortAscending_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnSave.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Location = new System.Drawing.Point(832, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnDelete.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDelete.Location = new System.Drawing.Point(771, 575);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 35);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLockUnlock
            // 
            this.btnLockUnlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLockUnlock.BackColor = System.Drawing.Color.Transparent;
            this.btnLockUnlock.BackgroundImage = global::PasswordManagement.Properties.Resources.unlocked;
            this.btnLockUnlock.FlatAppearance.BorderSize = 0;
            this.btnLockUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockUnlock.Location = new System.Drawing.Point(466, 585);
            this.btnLockUnlock.Name = "btnLockUnlock";
            this.btnLockUnlock.Size = new System.Drawing.Size(20, 20);
            this.btnLockUnlock.TabIndex = 7;
            this.btnLockUnlock.TabStop = false;
            this.btnLockUnlock.UseVisualStyleBackColor = false;
            this.btnLockUnlock.Click += new System.EventHandler(this.btnLockUnlock_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.btnAddCategory.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAddCategory.Location = new System.Drawing.Point(179, 86);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(105, 26);
            this.btnAddCategory.TabIndex = 10;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // accountsDataSet
            // 
            this.accountsDataSet.DataSetName = "AccountsDataSet";
            this.accountsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountsDataSetBindingSource
            // 
            this.accountsDataSetBindingSource.DataSource = this.accountsDataSet;
            this.accountsDataSetBindingSource.Position = 0;
            // 
            // panelSearchRegion
            // 
            this.panelSearchRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panelSearchRegion.Controls.Add(this.txtCategory);
            this.panelSearchRegion.Controls.Add(this.btnClearSearch);
            this.panelSearchRegion.Controls.Add(this.elementHost1);
            this.panelSearchRegion.Controls.Add(this.btnEditCategory);
            this.panelSearchRegion.Controls.Add(this.btnDeleteCategory);
            this.panelSearchRegion.Controls.Add(this.btnAddCategory);
            this.panelSearchRegion.Controls.Add(this.comboEditingCategory);
            this.panelSearchRegion.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSearchRegion.Location = new System.Drawing.Point(899, 40);
            this.panelSearchRegion.Name = "panelSearchRegion";
            this.panelSearchRegion.Size = new System.Drawing.Size(301, 577);
            this.panelSearchRegion.TabIndex = 16;
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtCategory.Location = new System.Drawing.Point(33, 87);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(134, 23);
            this.txtCategory.TabIndex = 14;
            this.txtCategory.WaterMarkColor = System.Drawing.Color.Gray;
            this.txtCategory.WaterMarkText = "Add / Edit";
            this.txtCategory.wmTextAlign = PasswordManagement.WaterMarkedTextBox.WaterMarkedTextAlign.Left;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Image = global::PasswordManagement.Properties.Resources.x;
            this.btnClearSearch.Location = new System.Drawing.Point(251, 23);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(22, 22);
            this.btnClearSearch.TabIndex = 7;
            this.btnClearSearch.TabStop = false;
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Visible = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(29, 17);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(260, 37);
            this.elementHost1.TabIndex = 8;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.roundedTextBox1;
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.btnEditCategory.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEditCategory.Location = new System.Drawing.Point(179, 120);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(105, 26);
            this.btnEditCategory.TabIndex = 12;
            this.btnEditCategory.Text = "Edit";
            this.btnEditCategory.UseVisualStyleBackColor = false;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.btnDeleteCategory.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDeleteCategory.Location = new System.Drawing.Point(179, 156);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(105, 26);
            this.btnDeleteCategory.TabIndex = 13;
            this.btnDeleteCategory.Text = "Remove";
            this.btnDeleteCategory.UseVisualStyleBackColor = false;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // comboEditingCategory
            // 
            this.comboEditingCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboEditingCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEditingCategory.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEditingCategory.FormattingEnabled = true;
            this.comboEditingCategory.Location = new System.Drawing.Point(33, 122);
            this.comboEditingCategory.Name = "comboEditingCategory";
            this.comboEditingCategory.Size = new System.Drawing.Size(134, 24);
            this.comboEditingCategory.TabIndex = 11;
            // 
            // panelAccountsRegion
            // 
            this.panelAccountsRegion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAccountsRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAccountsRegion.Controls.Add(this.loadingCircle);
            this.panelAccountsRegion.Controls.Add(this.lblNoAccountPrompt);
            this.panelAccountsRegion.Controls.Add(this.panelAddSort);
            this.panelAccountsRegion.Controls.Add(this.lstViewAccountsSaved);
            this.panelAccountsRegion.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAccountsRegion.Location = new System.Drawing.Point(0, 40);
            this.panelAccountsRegion.Name = "panelAccountsRegion";
            this.panelAccountsRegion.Size = new System.Drawing.Size(434, 577);
            this.panelAccountsRegion.TabIndex = 17;
            // 
            // loadingCircle
            // 
            this.loadingCircle.Active = true;
            this.loadingCircle.BackColor = System.Drawing.SystemColors.Control;
            this.loadingCircle.Color = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.loadingCircle.InnerCircleRadius = 6;
            this.loadingCircle.Location = new System.Drawing.Point(191, 301);
            this.loadingCircle.Name = "loadingCircle";
            this.loadingCircle.NumberSpoke = 9;
            this.loadingCircle.OuterCircleRadius = 7;
            this.loadingCircle.RotationSpeed = 100;
            this.loadingCircle.Size = new System.Drawing.Size(36, 30);
            this.loadingCircle.SpokeThickness = 4;
            this.loadingCircle.StylePreset = PasswordManagement.LoadingCircle.StylePresets.Firefox;
            this.loadingCircle.TabIndex = 20;
            this.loadingCircle.Text = "loadingCircle1";
            this.loadingCircle.Visible = false;
            // 
            // lblNoAccountPrompt
            // 
            this.lblNoAccountPrompt.AutoSize = true;
            this.lblNoAccountPrompt.BackColor = System.Drawing.Color.White;
            this.lblNoAccountPrompt.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoAccountPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblNoAccountPrompt.Location = new System.Drawing.Point(98, 260);
            this.lblNoAccountPrompt.Name = "lblNoAccountPrompt";
            this.lblNoAccountPrompt.Size = new System.Drawing.Size(255, 38);
            this.lblNoAccountPrompt.TabIndex = 1;
            this.lblNoAccountPrompt.Text = "There is Nothing Here!\r\nClick \'Add New\' to add an account";
            this.lblNoAccountPrompt.Visible = false;
            // 
            // panelAddSort
            // 
            this.panelAddSort.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelAddSort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAddSort.Controls.Add(this.btnAddNew);
            this.panelAddSort.Controls.Add(this.comboGetCategory);
            this.panelAddSort.Controls.Add(this.btnSortAscending);
            this.panelAddSort.Controls.Add(this.btnSortDescending);
            this.panelAddSort.Location = new System.Drawing.Point(-1, -1);
            this.panelAddSort.Name = "panelAddSort";
            this.panelAddSort.Size = new System.Drawing.Size(434, 41);
            this.panelAddSort.TabIndex = 16;
            // 
            // lstViewAccountsSaved
            // 
            this.lstViewAccountsSaved.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Accounts});
            this.lstViewAccountsSaved.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstViewAccountsSaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lstViewAccountsSaved.FullRowSelect = true;
            this.lstViewAccountsSaved.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstViewAccountsSaved.HideSelection = false;
            this.lstViewAccountsSaved.Location = new System.Drawing.Point(-1, 40);
            this.lstViewAccountsSaved.MultiSelect = false;
            this.lstViewAccountsSaved.Name = "lstViewAccountsSaved";
            this.lstViewAccountsSaved.Size = new System.Drawing.Size(435, 536);
            this.lstViewAccountsSaved.SmallImageList = this.imageList;
            this.lstViewAccountsSaved.TabIndex = 18;
            this.lstViewAccountsSaved.TabStop = false;
            this.lstViewAccountsSaved.TileSize = new System.Drawing.Size(20, 20);
            this.lstViewAccountsSaved.UseCompatibleStateImageBehavior = false;
            this.lstViewAccountsSaved.View = System.Windows.Forms.View.Details;
            this.lstViewAccountsSaved.CollectionChanged += new System.EventHandler<System.EventArgs>(this.lstViewAccountsSaved_CollectionChanged);
            this.lstViewAccountsSaved.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstViewAccountsSaved_ItemSelectionChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblCategory.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(481, 494);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 29);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Gabriola", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.lblDescription.Location = new System.Drawing.Point(517, 1);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(140, 39);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Password Manager";
            this.lblDescription.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDescription_MouseDown);
            this.lblDescription.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDescription_MouseMove);
            this.lblDescription.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDescription_MouseUp);
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
            this.btnClose.Location = new System.Drawing.Point(1174, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 21);
            this.btnClose.TabIndex = 20;
            this.btnClose.TabStop = false;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.btnMinimize.Location = new System.Drawing.Point(1149, 8);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(23, 21);
            this.btnMinimize.TabIndex = 21;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelTop.Controls.Add(this.btnMinimize);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.lblDescription);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 40);
            this.panelTop.TabIndex = 11;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(644, 105);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(54, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Zipper";
            this.lblTitle.UseMnemonic = false;
            // 
            // panelPasswordStrength
            // 
            this.panelPasswordStrength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPasswordStrength.Location = new System.Drawing.Point(561, 336);
            this.panelPasswordStrength.Name = "panelPasswordStrength";
            this.panelPasswordStrength.PasswordStrengthValue = PasswordManagement.cPanel_PasswordStrength.PasswordStrength.None;
            this.panelPasswordStrength.Size = new System.Drawing.Size(233, 3);
            this.panelPasswordStrength.TabIndex = 8;
            this.panelPasswordStrength.MouseHover += new System.EventHandler(this.panelPasswordStrength_MouseHover);
            // 
            // panelFadingEffect
            // 
            this.panelFadingEffect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelFadingEffect.Location = new System.Drawing.Point(884, 575);
            this.panelFadingEffect.Name = "panelFadingEffect";
            this.panelFadingEffect.Size = new System.Drawing.Size(460, 577);
            this.panelFadingEffect.TabIndex = 13;
            this.panelFadingEffect.Visible = false;
            // 
            // Zipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1200, 617);
            this.Controls.Add(this.panelPasswordLength);
            this.Controls.Add(this.btnClearPicture);
            this.Controls.Add(this.panelAccountsRegion);
            this.Controls.Add(this.txtExtras);
            this.Controls.Add(this.panelSearchRegion);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.btnLockUnlock);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.panelPasswordStrength);
            this.Controls.Add(this.txtWebsite);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDuplicate);
            this.Controls.Add(this.btnGoToLink);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopyLink);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblAddImage);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.panelFadingEffect);
            this.Controls.Add(this.btnGenPassword);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnShowPassword);
            this.Controls.Add(this.lblWebsite);
            this.Controls.Add(this.lblExtras);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Zipper";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZPass_KeyDown);
            this.panelPasswordLength.ResumeLayout(false);
            this.panelPasswordLength.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataSetBindingSource)).EndInit();
            this.panelSearchRegion.ResumeLayout(false);
            this.panelSearchRegion.PerformLayout();
            this.panelAccountsRegion.ResumeLayout(false);
            this.panelAccountsRegion.PerformLayout();
            this.panelAddSort.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblExtras;
        private System.Windows.Forms.TextBox txtExtras;
        cPanel_Fading panelFadingEffect;
        private System.Windows.Forms.Button btnSortAscending;
        private System.Windows.Forms.Button btnSortDescending;
        private System.Windows.Forms.Button btnGenPassword;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.Button btnLockUnlock;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.Button btnGoToLink;
        private System.Windows.Forms.Button btnCopyLink;
        private cPanel_PasswordStrength panelPasswordStrength;
        private System.Windows.Forms.Panel panelPasswordLength;
        private System.Windows.Forms.TextBox txtPasswordLength;
        private System.Windows.Forms.BindingSource accountsDataSetBindingSource;
        private AccountsDataSet accountsDataSet;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Label lblAddImage;
        private System.Windows.Forms.Button btnClearPicture;
        private System.Windows.Forms.ComboBox comboGetCategory;
        private System.Windows.Forms.Panel panelSearchRegion;
        private System.Windows.Forms.Panel panelAccountsRegion;
        private System.Windows.Forms.Panel panelAddSort;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private RoundedTextBox roundedTextBox1;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnDeleteCategory;
        private System.Windows.Forms.ComboBox comboEditingCategory;
        private System.Windows.Forms.Label lblTitle;
        private WaterMarkedTextBox txtCategory;
        private System.Windows.Forms.Label lblNoAccountPrompt;
        private ListViewCustom lstViewAccountsSaved;
        private System.Windows.Forms.ColumnHeader Accounts;
        private LoadingCircle loadingCircle;
    }
}

