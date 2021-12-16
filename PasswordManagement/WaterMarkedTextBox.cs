using System;
using System.Windows.Forms;
using System.Drawing;

namespace PasswordManagement
{
    class WaterMarkedTextBox : TextBox
    {
        public enum WaterMarkedTextAlign {Left, Right,Center };

        private Font oldFont = null;
        private bool waterMarkTextEnabled = false;

        #region Attributes 
        private Color _waterMarkColor = Color.Gray;
        public Color WaterMarkColor
        {
            get { return _waterMarkColor; }
            set
            {
                _waterMarkColor = value;
                Invalidate();
            }
        }

        private string _waterMarkText = "Water Mark";
        public string WaterMarkText
        {
            get { return _waterMarkText; }
            set { _waterMarkText = value; Invalidate(); }
        }

        private WaterMarkedTextAlign waterMarkedTextAlign = WaterMarkedTextAlign.Left;
        public WaterMarkedTextAlign wmTextAlign
        {
            get { return waterMarkedTextAlign; }
            set
            {
                waterMarkedTextAlign = value;
                Invalidate();
            }
        }
        #endregion

        //Default constructor
        public WaterMarkedTextBox()
        {
            JoinEvents(true);
        }

        //Override OnCreateControl ... thanks to  "lpgray .. codeproject guy"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            WaterMark_Toggle(null, null);
        }

        //Override OnPaint
        protected override void OnPaint(PaintEventArgs args)
        {
            // Use the same font that was defined in base class
            System.Drawing.Font drawFont = new Font(Font.FontFamily,
                Font.Size, Font.Style, Font.Unit);
            //Create new brush with gray color or 
            SolidBrush drawBrush = new SolidBrush(WaterMarkColor);//use Water mark color

            SizeF length = args.Graphics.MeasureString(WaterMarkText, drawFont);
            //Draw Text or WaterMark
            switch (waterMarkedTextAlign)
            {
                case WaterMarkedTextAlign.Left:
                    args.Graphics.DrawString((waterMarkTextEnabled ? WaterMarkText : Text),
                drawFont, drawBrush, new PointF(0.0F, (this.Height / 2) - (length.Height / 2)));
                    break;
                case WaterMarkedTextAlign.Right:
                    args.Graphics.DrawString((waterMarkTextEnabled ? WaterMarkText : Text),
                drawFont, drawBrush, new PointF(this.Width - length.Width, (this.Height / 2) - (length.Height / 2)));
                    break;
                case WaterMarkedTextAlign.Center:
                    if(waterMarkTextEnabled)
                    {
                        args.Graphics.DrawString(WaterMarkText,
                               drawFont, drawBrush, new PointF((this.Width / 2) - (length.Width / 2),
                               (this.Height / 2) - (length.Height / 2)));
                    }
                    else
                    {
                        args.Graphics.DrawString(Text,
                            drawFont, drawBrush, new PointF(0.0F, (this.Height / 2) - (length.Height / 2)));
                    }
                    
                    break;
                default:
                    args.Graphics.DrawString((waterMarkTextEnabled ? WaterMarkText : Text),
                drawFont, drawBrush, new PointF(0.0F, (this.Height / 2) - (length.Height / 2)));
                    break;
            }

            base.OnPaint(args);
        }

        private void JoinEvents(bool join)
        {
            if (join)
            {
                this.TextChanged += new EventHandler(this.WaterMark_Toggle);
                this.LostFocus += new EventHandler(this.WaterMark_Toggle);
                this.FontChanged += new EventHandler(this.WaterMark_FontChanged);
                //No one of the above events will start immeddiatlly 
                //TextBox control still in constructing, so,
                //Font object (for example) couldn't be catched from within
                //WaterMark_Toggle
                //So, call WaterMark_Toggel through OnCreateControl after TextBox
                //is totally created
                //No doupt, it will be only one time call

                //Old solution uses Timer.Tick event to check Create property
            }
        }

        private void WaterMark_Toggle(object sender, EventArgs args)
        {
            if (string.IsNullOrWhiteSpace(Text))
                EnableWaterMark();
            else
                DisableWaterMark();
        }

        private void EnableWaterMark()
        {
            //Save current font until returning the UserPaint style to false (NOTE:
            //It is a try and error advice)
            oldFont = new Font(Font.FontFamily, Font.Size, Font.Style,
               Font.Unit);
            //Enable OnPaint event handler
            this.SetStyle(ControlStyles.UserPaint, true);
            this.waterMarkTextEnabled = true;
            //Triger OnPaint immediatly
            Refresh();
        }

        private void DisableWaterMark()
        {
            //Disbale OnPaint event handler
            this.waterMarkTextEnabled = false;
            this.SetStyle(ControlStyles.UserPaint, false);
            //Return back oldFont if existed
            if (oldFont != null)
                this.Font = new Font(oldFont.FontFamily, oldFont.Size,
                    oldFont.Style, oldFont.Unit);
        }

        private void WaterMark_FontChanged(object sender, EventArgs args)
        {
            if (waterMarkTextEnabled)
            {
                oldFont = new Font(Font.FontFamily, Font.Size, Font.Style,
                    Font.Unit);
                Refresh();
            }
        }
        
    }
}