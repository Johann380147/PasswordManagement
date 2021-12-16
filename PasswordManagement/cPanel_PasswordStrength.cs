using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace PasswordManagement
{
    public partial class cPanel_PasswordStrength : Panel
    {
        public enum PasswordStrength { None, VeryWeak, Weak, Average, Strong, VeryStrong }
        public PasswordStrength passwordStrength = PasswordStrength.VeryWeak;

        [Description("Defines strength of password")]
        public PasswordStrength PasswordStrengthValue
        {
            get
            {
                return passwordStrength;
            }
            set
            {
                passwordStrength = value;
                Invalidate();
            }
        }

        public cPanel_PasswordStrength()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ContainerControl |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint,
                true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (passwordStrength != PasswordStrength.None)
                e.Graphics.DrawLine(new Pen(Color.Red, 2),
                    0, 1, Width * (1.0f / 5.0f), 1);

            switch (passwordStrength)
            {
                case PasswordStrength.None:
                    e.Graphics.Clear(Color.Beige);
                    break;
                case PasswordStrength.VeryWeak:
                    break;
                case PasswordStrength.Weak:
                    e.Graphics.DrawLine(new Pen(Color.DarkRed, 2),
                        Width * (1.0f / 5.0f), 1, Width * (2.0f / 5.0f), 1);
                    break;
                case PasswordStrength.Average:
                    e.Graphics.DrawLine(new Pen(Color.DarkRed, 2),
                        Width * (1.0f / 5.0f), 1, Width * (2.0f / 5.0f), 1);
                    e.Graphics.DrawLine(new Pen(Color.Purple, 2),
                        Width * (2.0f / 5.0f), 1, Width * (3.0f / 5.0f), 1);
                    break;
                case PasswordStrength.Strong:
                    e.Graphics.DrawLine(new Pen(Color.DarkRed, 2),
                        Width * (1.0f / 5.0f), 1, Width * (2.0f / 5.0f), 1);
                    e.Graphics.DrawLine(new Pen(Color.Purple, 2),
                        Width * (2.0f / 5.0f), 1, Width * (3.0f / 5.0f), 1);
                    e.Graphics.DrawLine(new Pen(Color.DarkGreen, 2),
                        Width * (3.0f / 5.0f), 1, Width * (4.0f / 5.0f), 1);
                    break;
                case PasswordStrength.VeryStrong:
                    e.Graphics.DrawLine(new Pen(Color.DarkRed, 2),
                        Width * (1.0f / 5.0f), 1, Width * (2.0f / 5.0f), 1);
                    e.Graphics.DrawLine(new Pen(Color.Purple, 2),
                        Width * (2.0f / 5.0f), 1, Width * (3.0f / 5.0f), 1);
                    e.Graphics.DrawLine(new Pen(Color.DarkGreen, 2),
                        Width * (3.0f / 5.0f), 1, Width * (4.0f / 5.0f), 1);
                    e.Graphics.DrawLine(new Pen(Color.Green, 2),
                        Width * (4.0f / 5.0f), 1, Width, 1);
                    break;
                default:
                    break;
            }
            base.OnPaint(e);
        }
    }
}
