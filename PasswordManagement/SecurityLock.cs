using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace PasswordManagement
{
    public partial class SecurityLock : Form
    {
        string id = string.Empty, email = string.Empty;
        int counter = 3;
        ToolTip t = new ToolTip();

        public SecurityLock(string id, string email)
        {
            InitializeComponent();

            this.id = id;
            this.email = email;
            this.panelOverlay.Dock = DockStyle.Fill;
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnProceed.PerformClick();
            }
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (txtID.Text == id)
                DialogResult = DialogResult.OK;
            else
            {
                if (counter == 0)
                {
                    DialogResult = DialogResult.Cancel;
                    return;
                }

                t.Show("Incorrect Key " + counter + " tries remaining", txtID, new Point(0, -30));
                counter--;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            

            //curly lines
            PointF p = new PointF(this.Width / 10.0F, this.Height - 5);
            PointF p1 = new PointF(-1, this.Height / 10.0F);

            byte r = 50, g = 100, b = 150;
            Pen pen = new Pen(Color.FromArgb(r, g, b));
            pen.Width = 3;
            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            for (int i = 0; i < 30; i++)
            {
                e.Graphics.DrawLine(pen, p, p1);

                r += 10;
                g += 10;
                b += 10;

                p.X += 3;
                p1.Y += 3;

                pen.Color = Color.FromArgb(r, g, b);
            }

            //shadow
            Rectangle r1 = new Rectangle(-1, -1, Width - 0, Height - 0);
            Rectangle r2 = new Rectangle(-1, -1, Width - 1, Height - 1);
            Rectangle r3 = new Rectangle(-1, -1, Width - 2, Height - 2);
            Rectangle r4 = new Rectangle(-1, -1, Width - 3, Height - 3);

            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(255, 30, 30, 30)), r4);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(230, 10, 10, 10)), r3);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(180, 0, 0, 0)), r2);
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(150, 0, 0, 0)), r1);

            base.OnPaint(e);
            
        }

        private bool startMoving = false;
        private Point initialPoint;
        private void SecurityLock_MouseDown(object sender, MouseEventArgs e)
        {
            startMoving = true;
            initialPoint = e.Location;
        }

        private void SecurityLock_MouseUp(object sender, MouseEventArgs e)
        {
            startMoving = false;
            if (this.Location.Y - 20 < 0)
                this.Location = new Point(this.Location.X, -10);
            if (this.Location.Y > Screen.PrimaryScreen.WorkingArea.Height - 10)
                this.Location = new Point(this.Location.X, Screen.PrimaryScreen.WorkingArea.Height - 30);
        }

        private void SecurityLock_MouseMove(object sender, MouseEventArgs e)
        {
            if (initialPoint == null) return;
            if(startMoving)
                this.SetDesktopLocation(MousePosition.X - initialPoint.X, MousePosition.Y - initialPoint.Y);
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

        private async void btnForgotKey_Click(object sender, EventArgs e)
        {
            string mailFrom = "holygrail49@hotmail.com";
            string mailTo = email;
            string mailFromPW = "EluCidaTe19";

            string subject = "ZPass - Key Recovery";
            string body = "Your key is: " + id;

            try
            {
                txtID.Enabled = false;
                btnForgotKey.Enabled = false;
                panelOverlay.Visible = true;
                loadingCircle.Visible = true;
                btnForgotKey.BackColor = panelOverlay.BackColor;

                await System.Threading.Tasks.Task.Run(() => SendHotmail(mailFrom, mailTo, subject, body, mailFromPW));

                using (UserPrompt up = new UserPrompt("", "Key has been sent to your registered email!", UserPrompt.PromptButtons.Ok))
                {
                    up.ShowDialog();
                }

            }
            catch
            {
                using (UserPrompt up = new UserPrompt("", "Key could not be sent to your registered email!", UserPrompt.PromptButtons.Ok))
                {
                    up.ShowDialog();
                }
            }
            finally
            {
                txtID.Enabled = true;
                btnForgotKey.Enabled = true;
                panelOverlay.Visible = false;
                loadingCircle.Visible = false;
                btnForgotKey.BackColor = Color.Transparent;
            }

        }

        private void btnForgotKey_MouseEnter(object sender, EventArgs e)
        {
            btnForgotKey.ForeColor = Color.FromArgb(40, 40, 40);
        }

        private void btnForgotKey_MouseLeave(object sender, EventArgs e)
        {
            btnForgotKey.ForeColor = SystemColors.ControlDarkDark;
        }
        
        private void SendHotmail(string mailFrom, string mailTo, string subject, string body, string mailFromPW)
        {
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(mailFrom);
                msg.To.Add(mailTo);

                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = true;

                using (SmtpClient sc = new SmtpClient("smtp.live.com"))
                {
                    sc.Port = 587;
                    sc.Credentials = new NetworkCredential(mailFrom, mailFromPW);
                    sc.EnableSsl = true;
                    sc.Send(msg);
                }
            }
        }

    }
}
