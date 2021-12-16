using System.Drawing;
using System.Windows.Forms;

namespace PasswordManagement
{
    public partial class cPanel_Fading : Panel
    {
        string success = "Successfully Edited!";
        Font font = new Font("Gabriola", 15);
        SizeF size;

        public cPanel_Fading()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.OptimizedDoubleBuffer, true);

            Rectangle r = ClientRectangle;
            using (Graphics g = CreateGraphics())
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, 64, 64, 64)), r);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            size = e.Graphics.MeasureString(success, font);
            e.Graphics.DrawString(success, font, Brushes.WhiteSmoke,
                new PointF((Width / 2) - (size.Width / 2),
                    Height / 2 - (size.Height / 2)));
            
            //base.OnPaint(e);

        }
        
    }
}
