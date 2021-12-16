using System;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordManagement
{
    public partial class UserPrompt : Form
    {
        public enum PromptButtons { YesNoCancel, YesNo, Ok };

        public UserPrompt(string title, string description)
            : this(title, description, PromptButtons.YesNoCancel)
        { }

        public UserPrompt(string title, string description, PromptButtons promptButtons)
        {
            InitializeComponent();
            this.DockPadding.All = 1;

            lblTitle.Text = @title;
            lblDescription.Text = @description;
            lblTitle.Location = new Point((panelTop.Width / 2) - (lblTitle.Width / 2), lblTitle.Location.Y);

            float spacing = 0;

            switch (promptButtons)
            {
                case PromptButtons.YesNoCancel:
                    spacing = (this.Width - (btnYes.Width * 3)) / 4.0f;
                    btnYes.Location = new Point((int)spacing, btnYes.Location.Y);
                    btnNo.Location = new Point(btnYes.Width + (int)(spacing * 2), btnNo.Location.Y);
                    btnCancel.Location = new Point((btnYes.Width * 2) + (int)(spacing * 3), btnCancel.Location.Y);
                    break;
                case PromptButtons.YesNo:
                    spacing = (this.Width - (btnYes.Width * 2)) / 3.0f;
                    btnYes.Location = new Point((int)spacing, btnYes.Location.Y);
                    btnNo.Location = new Point(btnYes.Width + (int)(spacing * 2), btnNo.Location.Y);
                    btnCancel.Visible = false;
                    break;
                case PromptButtons.Ok:
                    btnYes.Text = "OK";
                    btnYes.Location = new Point((this.Width / 2) - (btnYes.Width / 2), btnYes.Location.Y);
                    btnNo.Visible = false;
                    btnCancel.Visible = false;
                    break;
                default:
                    break;
            }
            
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #region Border Events

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
            coordi = new Point(e.Location.X + lblTitle.Left, e.Location.Y + lblTitle.Top);
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
            this.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            e.Graphics.DrawRectangle(Pens.RoyalBlue, r);

            base.OnPaint(e);
        }

        #endregion
    }
}
