using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PasswordManagement
{
    public partial class SetupMasterKey : Form
    {
        ToolTip tooltip = new ToolTip();
        bool isKeyValid, isKeyValid2;

        public SetupMasterKey()
        {
            InitializeComponent();
            txtMasterKey.Select();
            tooltip.SetToolTip(PasswordValidity, "Key must contain 7 or more characters with at least 1 character and number");
            tooltip.SetToolTip(PasswordValidity2, "Key must match above input");
            tooltip.SetToolTip(EmailHelp, "Email will be used for key recovery\nPlease enter a valid email");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!isKeyValid || !isKeyValid2 || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                !txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                return;

            AddPasswordToDB();

            txtMasterKey.Visible = txtConfirmMasterKey.Visible = txtEmail.Visible
                = EmailHelp.Visible = lblWarning.Visible = PasswordValidity.Visible
                = PasswordValidity2.Visible = btnConfirm.Visible = btnLater.Visible = false;
            lblCompleted.Visible = btnProceed.Visible = true;
        }

        private void btnLater_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Dispose();
        }
        
        private void btnProceed_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void txtSetPassword_TextChanged(object sender, EventArgs e)
        {
            if(txtMasterKey.Text.Length >= 7 && CheckForAlphabetNumber(txtMasterKey.Text))
            {
                PasswordValidity.BackgroundImage = Properties.Resources.tick;
                isKeyValid = true;
            }
            else
            {
                PasswordValidity.BackgroundImage = Properties.Resources.cross;
                isKeyValid = false;
            }
        }

        private void txtConfirmSetPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmMasterKey.Text == txtMasterKey.Text)
            {
                PasswordValidity2.BackgroundImage = Properties.Resources.tick;
                lblWarning.ForeColor = Color.Green;
                isKeyValid2 = true;
            }
            else
            {
                PasswordValidity2.BackgroundImage = Properties.Resources.cross;
                lblWarning.ForeColor = Color.Crimson;
                isKeyValid2 = false;
            }
        }

        private bool CheckForAlphabetNumber(string text)
        {
            char[] characters = {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
            'l','m','n','o','p','q','r','s','t','u','v','w', 'x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N',
            'O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', };

            bool charExists = false, numExists = false;

            foreach(char character in characters)
            {
                if(text.Contains(character.ToString()))
                {
                    charExists = true;
                }
            }
            foreach(char number in numbers)
            {
                if(text.Contains(number.ToString()))
                {
                    numExists = true;
                }
            }

            if (charExists && numExists) return true;
            else return false;

        }

        private void AddPasswordToDB()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Resources.ConnectionString))
            using (SqlCommand command = new SqlCommand("INSERT INTO Identification (PasswordKey, Email) VALUES(@password, @email)", connection))
            {
                connection.Open();
                command.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = txtMasterKey.Text;
                command.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = txtEmail.Text;

                command.ExecuteNonQuery();
            }
        }

        #region Styling

        bool moveForm = false;
        Point coordi = new Point();

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            moveForm = true;
            coordi = e.Location;
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            moveForm = false;
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
        }

        private void lblDescription_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveForm)
                this.SetDesktopLocation(MousePosition.X - coordi.X, MousePosition.Y - coordi.Y);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnLater_MouseEnter(object sender, EventArgs e)
        {
            btnLater.ForeColor = Color.FromArgb(40, 40, 40);
            btnProceed.ForeColor = Color.FromArgb(40, 40, 40);
        }
        
        private void btnLater_MouseLeave(object sender, EventArgs e)
        {
            btnLater.ForeColor = SystemColors.ControlDarkDark;
            btnProceed.ForeColor = SystemColors.ControlDarkDark;
        }

        #endregion

    }
}
