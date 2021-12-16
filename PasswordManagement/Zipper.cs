using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordManagement
{
    public partial class Zipper : Form
    {
        #region Declarations

        private Timer timerFade = new Timer();
        private Timer timerFlash = new Timer();
        private Timer timerLoad = new Timer();
        private ToolTip tt = new ToolTip();
        private int a = 255, counter = 0, selection = -1;
        string categoryName = "All";
        private bool isCategorised = false;
        
        #endregion

        #region Members

        private AccountStorage storage = new AccountStorage();
        
        #endregion

        #region Constructor

        public Zipper()
        {
            InitializeComponent();
            this.DockPadding.All = 1;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.ContainerControl, true);
            
            InitTooltips();
            TimerFunctions();
            
            UpdateAll();
            txtPassword.BackColor = SystemColors.Window; //added to remedy strange behavior with lockunlock btn

            lstViewAccountsSaved.Columns[0].Width = lstViewAccountsSaved.Width - SystemInformation.VerticalScrollBarWidth - 5;
            
            lblDescription.Location = new Point((this.Width / 2) - (lblDescription.Width / 2));
            if (comboCategory.Items.Count > 0)
            {
                comboCategory.SelectedIndex = 0;
                comboGetCategory.SelectedIndex = 0;
            }
            elementHost1.Child.KeyDown += txtSearch_KeyDown;
            elementHost1.Child.KeyUp += txtSearch_KeyUp;
        }

        #endregion

        #region Control Events

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            storage.AddAccount("(new)", "", "", "", "", null, comboGetCategory.Text);

            lstViewAccountsSaved.AddItems("(new)", lstViewAccountsSaved.Items.Count);
            lstViewAccountsSaved.Items[lstViewAccountsSaved.Items.Count - 1].Tag = new Account()
            {
                Name = "(new)",
                Website = "",
                Username = "",
                Password = "",
                Extras = "",
                ImageBound = null,
                Category = @comboGetCategory.Text
            };
            imageList.Images.Add(Properties.Resources.defaultimg);

            lstViewAccountsSaved.Items[lstViewAccountsSaved.Items.Count - 1].Selected = true;
            txtName.Select();
            txtName.SelectionStart = 0;
            txtName.SelectionLength = txtName.Text.Length;

            selection = lstViewAccountsSaved.Items.Count - 1;
            lstViewAccountsSaved.EnsureVisible(selection);
            
            ignoreTextChanged = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (lstViewAccountsSaved.SelectedIndices.Count > 0)
                index = lstViewAccountsSaved.SelectedIndices[0];

            if (index == -1) return;

            using (UserPrompt up = new UserPrompt("Save Fields", "Are you sure you want to save the changes?"))
            {
                if (up.ShowDialog() != DialogResult.Yes) return;
            }

            byte[] img;

            if (pbImage.BackgroundImage == null) img = null;
            else img = pbImage.BackgroundImage.ImageToByte();

            if (!isCategorised)
            {
                storage.EditAccount(index + 1, @txtName.Text,
              @txtWebsite.Text, @txtUsername.Text, @txtPassword.Text, @txtExtras.Text,
              img, @comboCategory.Text);
            }
            else
            {
                storage.EditCategorisedAccount(index + 1, @txtName.Text,
              @txtWebsite.Text, @txtUsername.Text, @txtPassword.Text, @txtExtras.Text,
              img, @comboGetCategory.Text, @comboCategory.Text);
            }

            UpdateAll();
            StartFading();

            if (index != -1)
                lstViewAccountsSaved.Items[index].Selected = true;
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = -1;
            if (lstViewAccountsSaved.SelectedIndices.Count > 0)
                index = lstViewAccountsSaved.SelectedIndices[0];

            if (index == -1) return;
            using (UserPrompt up = new UserPrompt("Delete Account", "Are you sure you want to delete account" +
                " '" + lstViewAccountsSaved.SelectedItems[0].Text + "'?"))
            {
                if (up.ShowDialog() != DialogResult.Yes) return;
            }

            if (!isCategorised)
                storage.DeleteAccount(index + 1);
            else
                storage.DeleteCategorisedAccount(comboGetCategory.Text, index + 1);

            UpdateAll();

            if (lstViewAccountsSaved.Items.Count > 0)
            {
                selection = index - 1;
                lstViewAccountsSaved.Items[selection].Selected = true;
                
            }
            else
            {
                selection = -1;
                ClearAllFields();
            }
            
        }
        
        private  void btnDuplicate_Click(object sender, EventArgs e)
        {
            using (UserPrompt up = new UserPrompt("Duplicate Account", "Would you like to duplicate this account?"))
            {
                if (up.ShowDialog() != DialogResult.Yes) return;
            }

            byte[] img;

            if (pbImage.BackgroundImage == null) img = null;
            else img = pbImage.BackgroundImage.ImageToByte();

            storage.AddAccount(txtName.Text + " (1)", txtWebsite.Text, txtUsername.Text, txtPassword.Text, txtExtras.Text, img, comboCategory.Text);
            
            lstViewAccountsSaved.AddItems(txtName.Text + " (1)", lstViewAccountsSaved.Items.Count);
            lstViewAccountsSaved.Items[lstViewAccountsSaved.Items.Count - 1].Tag = new Account()
            {
                Name = @txtName.Text + " (1)",
                Website = @txtWebsite.Text,
                Username = @txtUsername.Text,
                Password = @txtPassword.Text,
                Extras = @txtExtras.Text,
                ImageBound = pbImage.BackgroundImage,
                Category = @comboCategory.Text
            };
            imageList.Images.Add(pbImage.BackgroundImage);

            selection = lstViewAccountsSaved.Items.Count - 1;
            lstViewAccountsSaved.Items[selection].Selected = true;
            lstViewAccountsSaved.EnsureVisible(selection);
            
        }
        
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategory.Text)) return;
            foreach (var item in comboGetCategory.Items)
            {
                if (item.ToString() == txtCategory.Text)
                {
                    using (var up = new UserPrompt("", "Category already exists", UserPrompt.PromptButtons.Ok))
                    {
                        up.ShowDialog();
                        txtCategory.Clear();
                        return;
                    }
                }
            }

            storage.AddCategory(txtCategory.Text);
            
            comboCategory.Items.Add(txtCategory.Text);
            comboGetCategory.Items.Add(txtCategory.Text);
            comboEditingCategory.Items.Add(txtCategory.Text);
            
            using (var up = new UserPrompt("", "Added '" + txtCategory.Text + "' Category", UserPrompt.PromptButtons.Ok))
            {
                up.ShowDialog();
                txtCategory.Clear();
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            storage.EditCategory(comboEditingCategory.Text, txtCategory.Text);
            UpdateAll();
            txtCategory.Clear();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            storage.DeleteCategory(comboEditingCategory.Text);

            for (int i = 0; i < comboCategory.Items.Count; i++)
            {
                if (comboCategory.Items[i].ToString() == comboEditingCategory.Text)
                {
                    comboCategory.Items.RemoveAt(i);
                    comboGetCategory.Items.RemoveAt(i);
                    break;
                }
            }

            for (int i = 0; i < comboEditingCategory.Items.Count; i++)
            {
                if (comboEditingCategory.Items[i].ToString() == comboEditingCategory.Text)
                {
                    comboEditingCategory.Items.RemoveAt(i);
                    break;
                }
            }

            SetToCategory(categoryName);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            var control = (RoundedTextBox)elementHost1.Child;
            control.txtSearch.Clear();
            control.txtSearch.Focus();
            control.txtSearch.Select(0, 0);
            btnClearSearch.Visible = false;
        }

        private void btnSortAscending_Click(object sender, EventArgs e)
        {
            if (lstViewAccountsSaved.Items.Count < 0) return;
            lstViewAccountsSaved.ClearItems();
            imageList.Images.Clear();
            Image[] images;

            var account = storage.SortListAscending();
            if (!isCategorised)
            {
                images = storage.GetAccountImages().ToArray();

                for (int i = 0; i < account.Count; i++)
                {
                    lstViewAccountsSaved.AddItems(account[i].Name, i);
                    lstViewAccountsSaved.Items[i].Tag = account[i];
                }
            }
            else
            {

                images = storage.GetAccountImagesOfCategory(comboGetCategory.Text)?.ToArray();
                var accountCategory = storage.GetAccountListOfCategory(comboGetCategory.Text);

                for (int i = 0; i < accountCategory.Count; i++)
                {
                    lstViewAccountsSaved.AddItems(accountCategory[i].Name, i);
                    lstViewAccountsSaved.Items[i].Tag = accountCategory[i];
                }
            }

            if (images != null && images.Length > 0)
            {
                imageList.Images.AddRange(images);
            }

            SetToCategory(categoryName);
        }

        private void btnSortDescending_Click(object sender, EventArgs e)
        {
            if (lstViewAccountsSaved.Items.Count < 0) return;
            lstViewAccountsSaved.ClearItems();
            imageList.Images.Clear();
            Image[] images;

            var account = storage.SortListDescending();
            if (!isCategorised)
            {
                images = storage.GetAccountImages().ToArray();
                
                for (int i = 0; i < account.Count; i++)
                {
                    lstViewAccountsSaved.AddItems(account[i].Name, i);
                    lstViewAccountsSaved.Items[i].Tag = account[i];
                }
            }
            else
            {
                images = storage.GetAccountImagesOfCategory(comboGetCategory.Text)?.ToArray();
                var accountCategory = storage.GetAccountListOfCategory(comboGetCategory.Text);

                for (int i = 0; i < accountCategory.Count; i++)
                {
                    lstViewAccountsSaved.AddItems(accountCategory[i].Name, i);
                    lstViewAccountsSaved.Items[i].Tag = accountCategory[i];
                }
            }

            if (images != null && images.Length > 0)
            {
                imageList.Images.AddRange(images);
            }
            SetToCategory(categoryName);
        }
        
        private void btnGenPassword_Click(object sender, EventArgs e)
        {
            if (isLocked) return;

            int length = 0;
            if (!int.TryParse(txtPasswordLength.Text, out length) || length < 0)
            { txtPasswordLength.Text = "0"; return; }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) ||
            txtName.Text == "(new)")
            {
                txtPassword.Text = GenX.GenerateIdentifier(length);
                timerFlash.Start();
            }
            else if (txtName.Text != "(new)")
            {
                using (UserPrompt p = new UserPrompt("Generate Password", "Would you like to overwrite your current password?"))
                {
                    if (p.ShowDialog() == DialogResult.Yes)
                    {
                        txtPassword.Text = GenX.GenerateIdentifier(length);
                        timerFlash.Start();
                    }
                }
            }

            panelPasswordLength.Visible = false;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }

        private bool isLocked = false;
        private void btnLockUnlock_Click(object sender, EventArgs e)
        {
            if (isLocked)
            {
                btnLockUnlock.BackgroundImage = Properties.Resources.unlocked;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
                btnClearPicture.Enabled = true;
                txtName.ReadOnly = false;
                txtWebsite.ReadOnly = false;
                txtUsername.ReadOnly = false;
                txtPassword.ReadOnly = false;
                txtPassword.BackColor = SystemColors.Window;
                txtExtras.ReadOnly = false;

                txtName.Cursor = Cursors.IBeam;
                txtWebsite.Cursor = Cursors.IBeam;
                txtUsername.Cursor = Cursors.IBeam;
                txtPassword.Cursor = Cursors.IBeam;
                txtExtras.Cursor = Cursors.IBeam;

                isLocked = false;
            }
            else
            {
                btnLockUnlock.BackgroundImage = Properties.Resources.locked;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnClearPicture.Enabled = false;
                txtName.ReadOnly = true;
                txtWebsite.ReadOnly = true;
                txtUsername.ReadOnly = true;
                txtPassword.ReadOnly = true;
                txtPassword.BackColor = SystemColors.Control;
                txtExtras.ReadOnly = true;

                txtName.Cursor = Cursors.Default;
                txtWebsite.Cursor = Cursors.Default;
                txtUsername.Cursor = Cursors.Default;
                txtPassword.Cursor = Cursors.Default;
                txtExtras.Cursor = Cursors.Default;

                isLocked = true;
            }


        }

        private void btnCopyLink_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWebsite.Text)) return;

            txtWebsite.Select();
            txtWebsite.SelectionStart = 0;
            txtWebsite.SelectionLength = txtWebsite.Text.Length;

            Clipboard.SetText(txtWebsite.Text);

            tt.Show("Copied to clipboard!", btnCopyLink, 0, -20, 1000);
        }

        private void btnGoToLink_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWebsite.Text))
            {
                string link = txtWebsite.Text;

                if (!link.Contains("http://"))
                    link = "http://" + txtWebsite.Text;

                System.Diagnostics.Process.Start(link);
            }

        }
        
        private void btnClearPicture_Click(object sender, EventArgs e)
        {
            pbImage.BackgroundImage = null;
            pbImage.Invalidate();
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            if (selection == -1) return;

            OpenFileDialog op = new OpenFileDialog()
            {
                Title = "Image",
                Filter = "All Images (*.png,*.jpg,*.jpeg,*.bmp,*.gif)|" +
                "*.png;*.jpg;*.jpeg;*.bmp;*.gif|" +
                "Png (*.png)|*.png|Jpg (*.jpg, *.jpeg)|*.jpg;*.jpeg|Bitmap (*.bmp)|*.bmp",
                FilterIndex = 0
            };
            if (op.ShowDialog() == DialogResult.OK)
            {
                if (pbImage.BackgroundImage != null) pbImage.BackgroundImage.Dispose();
                pbImage.BackgroundImage = new Bitmap(op.OpenFile());
            }
        }
        
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ignoreTextChanged = false;
            }
            else ignoreTextChanged = true;
        }

        private void txtSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var control = (RoundedTextBox)elementHost1.Child;
            
            if (!string.IsNullOrWhiteSpace(control.txtSearch.Text))
            {
                btnClearSearch.Visible = true;
            }

            if (e.Key == System.Windows.Input.Key.Back ||
                e.Key == System.Windows.Input.Key.Enter ||
                e.Key == System.Windows.Input.Key.Return)
            {
                if (string.IsNullOrWhiteSpace(control.txtSearch.Text))
                {
                    btnClearSearch.Visible = false;
                }
            }
        }

        private void txtSearch_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {   
            if (e.Key != System.Windows.Input.Key.Enter && e.Key != System.Windows.Input.Key.Return) return;
            
            if(!CompareText(CompareType.Exact))
                if(!CompareText(CompareType.StartWith))
                    if (!CompareText(CompareType.Contains))
                        if(!CompareText(CompareType.ChecksAll))
                        {
                            tt.Show("Account not found!", elementHost1,
                          0, -20, 2000);
                            return;
                        }
            
            var control = (RoundedTextBox)elementHost1.Child;
            control.txtSearch.Clear();
            btnClearSearch.Visible = false;
        }

        private void ZPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                btnAddNew.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                btnSave.PerformClick();
            }
            else if ((e.Control && e.KeyCode == Keys.D) ||
                e.KeyCode == Keys.Delete)
            {
                btnDelete.PerformClick();
            }
            else if (e.Control && (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus))
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
            }
            else if (e.Control && (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus))
            {
                if (this.Opacity > 0.50)
                    this.Opacity -= 0.05;
            }
        }

        private void txtPasswordLength_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btnGenPassword.PerformClick();
                panelPasswordLength.Visible = false;

                e.SuppressKeyPress = e.Handled = true;
            }
        }

        private DateTime previousTime = DateTime.Now;
        private void btnGenPassword_MouseEnter(object sender, EventArgs e)
        {
            if ((DateTime.Now - previousTime).TotalMilliseconds < 500 ||
                (txtPasswordLength.ContainsFocus && panelPasswordLength.Visible == true)) return;
            else previousTime = DateTime.Now;

            int alpha = 0, x = 833;

            panelPasswordLength.BackColor = Color.FromArgb(alpha, 64, 64, 64);
            panelPasswordLength.Location = new Point(x, panelPasswordLength.Location.Y);
            panelPasswordLength.Visible = true;

            Timer fadeIn = new Timer();
            fadeIn.Interval = 15;

            fadeIn.Tick += (s, a) =>
            {
                if (alpha > 255) alpha = 255;
                if (x >= 838) fadeIn.Stop();

                panelPasswordLength.BackColor = Color.FromArgb(alpha, 64, 64, 64);
                panelPasswordLength.Location = new Point(x, panelPasswordLength.Location.Y);
                x++;
                alpha += 45;
            };

            fadeIn.Start();
        }

        private void btnGenPassword_MouseLeave(object sender, EventArgs e)
        {
            if ((this.PointToClient(MousePosition).X < btnGenPassword.Location.X ||
                this.PointToClient(MousePosition).X > btnGenPassword.Right - 1||
                this.PointToClient(MousePosition).Y < panelPasswordLength.Location.Y ||
                this.PointToClient(MousePosition).Y > btnGenPassword.Bottom - 1) &&
                !txtPasswordLength.Focused)
            {
                int alpha = 255, x = 838;

                panelPasswordLength.BackColor = Color.FromArgb(alpha, 64, 64, 64);
                panelPasswordLength.Location = new Point(x, panelPasswordLength.Location.Y);

                Timer fadeOut = new Timer();
                fadeOut.Interval = 15;

                fadeOut.Tick += (s, a) =>
                {
                    if (alpha < 0) alpha = 0;
                    if (x <= 833)
                    {
                        fadeOut.Stop();
                        panelPasswordLength.Visible = false;
                    }

                    panelPasswordLength.BackColor = Color.FromArgb(alpha, 64, 64, 64);
                    panelPasswordLength.Location = new Point(x, panelPasswordLength.Location.Y);
                    x--;
                    alpha -= 45;
                };

                fadeOut.Start();
            }
                
        }
        
        private void panelPasswordLength_MouseLeave(object sender, EventArgs e)
        {
            if (!panelPasswordLength.Visible) return;

            if ((this.PointToClient(MousePosition).X < btnGenPassword.Location.X ||
                this.PointToClient(MousePosition).X > panelPasswordLength.Right - 1 ||
                this.PointToClient(MousePosition).Y < panelPasswordLength.Location.Y ||
                this.PointToClient(MousePosition).Y > btnGenPassword.Bottom - 1) &&
                !txtPasswordLength.Focused)
            {
                int alpha = 255, x = 838;

                panelPasswordLength.BackColor = Color.FromArgb(alpha, 64, 64, 64);
                panelPasswordLength.Location = new Point(x, panelPasswordLength.Location.Y);

                Timer fadeOut = new Timer();
                fadeOut.Interval = 15;

                fadeOut.Tick += (s, a) =>
                {
                    if (alpha < 0) alpha = 0;
                    if (x <= 833)
                    {
                        fadeOut.Stop();
                        panelPasswordLength.Visible = false;
                    }

                    panelPasswordLength.BackColor = Color.FromArgb(alpha, 64, 64, 64);
                    panelPasswordLength.Location = new Point(x, panelPasswordLength.Location.Y);
                    x--;
                    alpha -= 45;
                };

                fadeOut.Start();
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            CheckPasswordStrength();
        }
        
        private bool ignoreTextChanged = false;
        private void txtWebsite_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextChanged) return;

            txtName.Text = txtWebsite.Text;
            ignoreTextChanged = false;

        }
        
        private void panelPasswordStrength_MouseHover(object sender, EventArgs e)
        {
            switch (panelPasswordStrength.PasswordStrengthValue)
            {
                case cPanel_PasswordStrength.PasswordStrength.VeryWeak:
                    tt.SetToolTip(panelPasswordStrength, "Very Weak");
                    break;
                case cPanel_PasswordStrength.PasswordStrength.Weak:
                    tt.SetToolTip(panelPasswordStrength, "Weak");
                    break;
                case cPanel_PasswordStrength.PasswordStrength.Average:
                    tt.SetToolTip(panelPasswordStrength, "Average");
                    break;
                case cPanel_PasswordStrength.PasswordStrength.Strong:
                    tt.SetToolTip(panelPasswordStrength, "Strong");
                    break;
                case cPanel_PasswordStrength.PasswordStrength.VeryStrong:
                    tt.SetToolTip(panelPasswordStrength, "Very Strong");
                    break;
                default:
                    break;
            }
        }
        
        private void lstViewAccountsSaved_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ignoreTextChanged = true;
            CheckPasswordStrength();

            if (lstViewAccountsSaved.SelectedIndices.Count <= 0 || e.ItemIndex == -1)
            {
                return;
            }
            selection = e.ItemIndex;
            
            Account account = e.Item.Tag as Account;
            if (account == null) return;

            lblTitle.Text = @account.Name;
            txtName.Text = @account.Name;
            txtWebsite.Text = @account.Website;
            txtUsername.Text = @account.Username;
            txtPassword.Text = @account.Password;
            txtExtras.Text = @account.Extras;
            pbImage.BackgroundImage = account.ImageBound;
            
            

            for (int i = 0; i < comboCategory.Items.Count; i++)
            {
                if (account.Category == comboCategory.Items[i].ToString())
                {
                    comboCategory.SelectedIndex = i;
                    break;
                }
            }


            lstViewAccountsSaved.EnsureVisible(selection);
        }

        private void lstViewAccountsSaved_CollectionChanged(object sender, EventArgs e)
        {
            if (lstViewAccountsSaved.Items.Count > 0)
                lblNoAccountPrompt.Visible = false;
            else
                lblNoAccountPrompt.Visible = true;
        }

        private async void comboGetCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboGetCategory.SelectedIndex == -1) return;
            
            categoryName = comboGetCategory.Text;
            
            imageList.Images.Clear();
            Image[] images;
            Account[] accounts;

            timerLoad.Start();
            lstViewAccountsSaved.Enabled = false;
            lblNoAccountPrompt.BackColor = SystemColors.Control;

            await System.Threading.Tasks.Task.Run(() =>
            {
                if (categoryName == "All")
                {
                    accounts = storage.GetAccountListInfo()?.ToArray();
                    images = storage.GetAccountImages()?.ToArray();
                    isCategorised = false;
                }
                else
                {
                    accounts = storage.GetAccountListOfCategory(categoryName)?.ToArray();
                    images = storage.GetAccountImagesOfCategory(categoryName)?.ToArray();
                    isCategorised = true;
                }

                if (accounts == null || accounts.Length <= 0)
                {
                    lstViewAccountsSaved.SynchronizedInvoke(() => lstViewAccountsSaved.ClearItems());
                    ClearAllFields();
                    selection = -1;
                    return;
                }


                if (images != null && images.Length > 0)
                {
                    imageList.Images.AddRange(images);
                }


                lstViewAccountsSaved.SynchronizedInvoke(() => lstViewAccountsSaved.ClearItems());
                for (int i = 0; i < accounts.Length; i++)
                {
                    lstViewAccountsSaved.SynchronizedInvoke(() =>
                    {
                        lstViewAccountsSaved.AddItems(accounts[i].Name, i);
                        lstViewAccountsSaved.Items[i].Tag = accounts[i];
                    });
                }
            });

            if (selection != -1 && selection < lstViewAccountsSaved.Items.Count)
                lstViewAccountsSaved.Items[selection].Selected = true;
            else if(lstViewAccountsSaved.Items.Count > 0)
                lstViewAccountsSaved.Items[0].Selected = true;

            timerLoad.Stop();
            lstViewAccountsSaved.Enabled = true;
            loadingCircle.Visible = false;
            lblNoAccountPrompt.BackColor = Color.White;
            
        }

        private void pbImage_BackgroundImageChanged(object sender, EventArgs e)
        {
            if (pbImage.BackgroundImage == null)
                lblAddImage.Visible = true;
            else
                lblAddImage.Visible = false;

            if(selection == -1)
                lblTitle.Text = "Zipper";
        }
        
        #endregion

        #region Secondary Methods
        /// <summary>
        /// Returns false if no empty fields, true if any fields are empty
        /// </summary>
        /// <returns></returns>
        private bool AreFieldsEmpty()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtWebsite.Text) ||
               string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                return true;
            }
            else
                return false;
            
        }
        
        private void UpdateAll()
        {
            UpdateControlCollections();

            if(selection != -1)
                lstViewAccountsSaved.EnsureVisible(selection);
        }

        private void UpdateControlCollections()
        {
            lstViewAccountsSaved.ClearItems();
            comboCategory.Items.Clear();
            comboGetCategory.Items.Clear();
            comboEditingCategory.Items.Clear();
            comboGetCategory.Items.Add("All");
            comboCategory.Items.Add("All");

            List<Account> accountNames;
            List<Image> images;
            List<string> categories = storage.GetCategories();

            if (!isCategorised) accountNames = storage.GetAccountListInfo();
            else accountNames = storage.GetAccountListOfCategory(comboGetCategory.Text);
            if (!isCategorised) images = storage.GetAccountImages();
            else images = storage.GetAccountImagesOfCategory(comboGetCategory.Text);
            
            if (accountNames != null && accountNames.Count > 0)
            {
                for (int i = 0; i < accountNames.Count; i++)
                {
                    lstViewAccountsSaved.AddItems(accountNames[i].Name, i);
                    lstViewAccountsSaved.Items[i].Tag = accountNames[i];
                }
                if(selection + 1 >= accountNames.Count)
                {
                    selection = -1;
                }
            }
            if (categories != null && categories.Count > 0)
            {
                foreach (var item in categories)
                {
                    comboCategory.Items.Add(item);
                    comboGetCategory.Items.Add(item);
                    comboEditingCategory.Items.Add(item);
                }
            }

            if (images != null && images.Count > 0)
            {
                imageList.Images.Clear();
                imageList.Images.AddRange(images.ToArray());
            }

            SetToCategory(categoryName);
        }

        private void ClearAllFields()
        {
            txtName.SynchronizedInvoke(() => txtName.Clear());
            txtWebsite.SynchronizedInvoke(() => txtWebsite.Clear());
            txtUsername.SynchronizedInvoke(() => txtUsername.Clear());
            txtPassword.SynchronizedInvoke(() => txtPassword.Clear());
            txtExtras.SynchronizedInvoke(() => txtExtras.Clear());
            
            pbImage.SynchronizedInvoke(() =>
            {
                if (pbImage.BackgroundImage != null)
                    pbImage.BackgroundImage.Dispose();
                pbImage.BackgroundImage = null;
            });
            lblTitle.SynchronizedInvoke(() => lblTitle.Text = "Zipper");

        }

        private void InitTooltips()
        {
            tt.SetToolTip(btnShowPassword, "Peek at password");
            tt.SetToolTip(btnGenPassword, "Randomly generate password");
            tt.SetToolTip(btnLockUnlock, "Lock fields");
            tt.SetToolTip(btnDuplicate, "Duplicate account");
            tt.SetToolTip(btnCopyLink, "Copy link");
            tt.SetToolTip(btnGoToLink, "Navigate to link");
        }

        private void TimerFunctions()
        {
            timerFade.Interval = 50;
            timerFlash.Interval = 500;
            timerLoad.Interval = 500;

            timerFade.Tick += (sender, e) =>
            {
                a -= 10;
                if (a < 0)
                {
                    a = 0;
                }
                panelFadingEffect.BackColor = Color.FromArgb(a, 64, 64, 64);

                if (panelFadingEffect.BackColor == Color.FromArgb(0, 64, 64, 64))
                {
                    a = 255;
                    panelFadingEffect.Visible = false;
                    panelFadingEffect.SendToBack();
                    timerFade.Stop();
                    
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                }

            };

            timerFlash.Tick += (sender, e) =>
            {
                if (counter == 5)
                {
                    timerFlash.Stop();
                    counter = 0;
                    if (isLocked)
                        txtPassword.BackColor = SystemColors.Control;
                    else
                        txtPassword.BackColor = SystemColors.Window;
                    return;
                }

                if (txtPassword.BackColor == SystemColors.Window)
                    txtPassword.BackColor = Color.Red;
                else
                    txtPassword.BackColor = SystemColors.Window;

                counter++;

            };

            timerLoad.Tick += (sender, e) =>
            {
                loadingCircle.Visible = true;
            };
           
            panelFadingEffect.MouseClick += (sender, e) => a = 0;
        }

        private void StartFading()
        {
            panelFadingEffect.Location = new Point(436, panelTop.Height);
            panelFadingEffect.BackColor = Color.FromArgb(255, 64, 64, 64);
            panelFadingEffect.Visible = true;
            panelFadingEffect.BringToFront();
            
            btnDelete.Enabled = false;
            btnSave.Enabled = false;

            timerFade.Start();
        }

        private bool HasElementOfArray(string text, string[] array)
        {
            foreach (string n in array)
            {
                if (text.Contains(n))
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckPasswordStrength()
        {
            string text = txtPassword.Text;
            if(string.IsNullOrWhiteSpace(text))
            {
                panelPasswordStrength.PasswordStrengthValue = cPanel_PasswordStrength.PasswordStrength.None;
                return;
            }
            string[] num = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] specialCharacters = {"!", "@", "#", "$", "%", "^", "&", "*", "(", ")",
            "-", "_"};
            bool containsNum = HasElementOfArray(text, num);
            bool containsSpecial = HasElementOfArray(text, specialCharacters);

            if (text.Length >= 15 &&
                 text.CountLower() >= 1 &&
                 text.CountUpper() >= 1 &&
                 containsNum &&
                 containsSpecial)
                panelPasswordStrength.PasswordStrengthValue = cPanel_PasswordStrength.PasswordStrength.VeryStrong;
            else if (text.Length >= 12 &&
                text.CountLower() >= 1 &&
                 text.CountUpper() >= 1 &&
                 containsNum)
                panelPasswordStrength.PasswordStrengthValue = cPanel_PasswordStrength.PasswordStrength.Strong;
            else if (text.Length >= 10 &&
                 text.CountLower() >= 1 &&
                 text.CountUpper() >= 1)
                panelPasswordStrength.PasswordStrengthValue = cPanel_PasswordStrength.PasswordStrength.Average;
            else if (text.Length > 7 &&
                (text.CountLower() <= 0 ^
                 text.CountUpper() <= 0))
                panelPasswordStrength.PasswordStrengthValue = cPanel_PasswordStrength.PasswordStrength.Weak;
            else if (txtPassword.Text.Length <= 7 &&
                (text.CountLower() <= 0 ||
                 text.CountUpper() <= 0))
                panelPasswordStrength.PasswordStrengthValue = cPanel_PasswordStrength.PasswordStrength.VeryWeak;
            
        }

        private enum CompareType { Exact, StartWith, Contains, ChecksAll }
        private bool CompareText(CompareType compareType)
        {
            var control = (RoundedTextBox)elementHost1.Child;

            switch (compareType)
            {
                case CompareType.Exact:
                    for (int i = 0; i < lstViewAccountsSaved.Items.Count; i++) //checks for exact match
                    {
                        if (control.txtSearch.Text.ToLower() == lstViewAccountsSaved.Items[i].Text.ToLower())
                        {
                            lstViewAccountsSaved.Items[i].Selected = true;
                            return true;
                        }
                    }
                    return false;

                case CompareType.StartWith:
                    for (int i = 0; i < lstViewAccountsSaved.Items.Count; i++) //checks for partial match starting with
                    {
                        if (lstViewAccountsSaved.Items[i].Text.ToLower().StartsWith(control.txtSearch.Text.ToLower()))
                        {
                            lstViewAccountsSaved.Items[i].Selected = true;
                            return true;
                        }
                    }
                    return false;

                case CompareType.Contains:
                    for (int i = 0; i < lstViewAccountsSaved.Items.Count; i++) //checks for partial match
                    {
                        if (lstViewAccountsSaved.Items[i].Text.ToLower().Contains(control.txtSearch.Text.ToLower()))
                        {
                            lstViewAccountsSaved.Items[i].Selected = true;
                            return true;
                        }
                    }
                    return false;
                case CompareType.ChecksAll:
                    Account[] accounts = storage.GetAccountListInfo()?.ToArray();
                    if (accounts == null || accounts.Length <= 0) return false;


                    for(int i = 0; i <accounts.Length; i++)
                    {
                        if (accounts[i].Name.ToLower().Contains(control.txtSearch.Text.ToLower()))
                        {
                            for (int x = 0; x < comboGetCategory.Items.Count; x++)
                            {
                                if (comboGetCategory.Items[x].ToString() == "All")
                                {
                                    comboGetCategory.SelectedIndex = x;
                                    break;
                                }
                            }
                            lstViewAccountsSaved.Items[i].Selected = true;
                            return true;
                        }
                    }
                    return false;

                default:
                    return false;
            }
            
        }

        private bool SetToCategory(string category)
        {
            for (int i = 0; i < comboGetCategory.Items.Count; i++)
            {
                if (comboGetCategory.Items[i].ToString() == category)
                {
                    comboGetCategory.SelectedIndex = i;
                    return true;
                }
            }
            for (int i = 0; i < comboGetCategory.Items.Count; i++)
            {
                if (comboGetCategory.Items[i].ToString() == "All")
                {
                    comboGetCategory.SelectedIndex = i;
                    categoryName = "All";
                    return false;
                }
            }

            return false;
        }
        
        #endregion

        #region Styling

        private bool moveForm = false;
        private Point coordi = new Point();

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            moveForm = true;
            coordi = e.Location;
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            moveForm = false;
            if (this.Location.Y < 0) this.Location = new Point(this.Location.X, 0);
            if (this.Location.Y > Screen.PrimaryScreen.WorkingArea.Height - 10)
                this.Location = new Point(this.Location.X, Screen.PrimaryScreen.WorkingArea.Height - 15);
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveForm)
            {
                this.SetDesktopLocation(MousePosition.X - coordi.X, MousePosition.Y - coordi.Y);
            }
        }

        private void lblDescription_MouseDown(object sender, MouseEventArgs e)
        {
            moveForm = true;
            coordi = new Point(e.Location.X + lblDescription.Left, e.Location.Y + lblDescription.Top);
        }

        private void lblDescription_MouseUp(object sender, MouseEventArgs e)
        {
            moveForm = false;
            if (this.Location.Y < 0) this.Location = new Point(this.Location.X, 0);
            if (this.Location.Y > Screen.PrimaryScreen.WorkingArea.Height - 10)
                this.Location = new Point(this.Location.X, Screen.PrimaryScreen.WorkingArea.Height - 15);
        }

        private void lblDescription_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveForm)
                this.SetDesktopLocation(MousePosition.X - coordi.X, MousePosition.Y - coordi.Y);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            e.Graphics.DrawRectangle(Pens.RoyalBlue, r);

            e.Graphics.DrawLine(new Pen(Color.FromArgb(150, 150, 150)),
                new Point(panelAccountsRegion.Width + 1, panelAccountsRegion.Location.Y),
                new Point(panelAccountsRegion.Width + 1, this.Height - 2));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(180, 180, 180)),
                new Point(panelAccountsRegion.Width + 2, panelAccountsRegion.Location.Y),
                new Point(panelAccountsRegion.Width + 2, this.Height - 2));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(200, 200, 200)),
                new Point(panelAccountsRegion.Width + 3, panelAccountsRegion.Location.Y),
                new Point(panelAccountsRegion.Width + 3, this.Height - 2));

            e.Graphics.DrawLine(new Pen(Color.FromArgb(65, 65, 65)),
                new Point(panelSearchRegion.Location.X - 1, panelSearchRegion.Location.Y),
                new Point(panelSearchRegion.Location.X - 1, this.Height - 2));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(100, 100, 100)),
                new Point(panelSearchRegion.Location.X - 2, panelSearchRegion.Location.Y),
                new Point(panelSearchRegion.Location.X - 2, this.Height - 2));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(150, 150, 150)),
                new Point(panelSearchRegion.Location.X - 3, panelSearchRegion.Location.Y),
                new Point(panelSearchRegion.Location.X - 3, this.Height - 2));
            base.OnPaint(e);
        }
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000;
                return cp;
            }
        }
        
        #endregion
        
    }

}
