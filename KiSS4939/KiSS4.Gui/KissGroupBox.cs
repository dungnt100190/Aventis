using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KiSS4.Gui
{
    /// <summary>
    /// KiSS control used to replace default .NET GroupBox
    /// </summary>
    [ToolboxBitmap(typeof(KissGroupBox), "KissGroupBox.bmp")]
    public class KissGroupBox : GroupBox
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const int ARCHEIGHT = 6;
        private const int ARCWIDTH = 6;
        private const int DEFAULTTEXTHEIGHTSUBTRACTOR = 7;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissGroupBox"/> class.
        /// </summary>
        public KissGroupBox()
        {
            this.SuspendLayout();

            // setup style
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);

            // set default values to fit KiSS look and feel
            this.Font = GuiConfig.GroupBoxFont;
            this.TextForeColor = GuiConfig.GroupBoxTextForeColor;
            this.BackColor = GuiConfig.GroupBoxBackColor;
            this.BorderColor = GuiConfig.GroupBoxBorderColor;
            this.Border3DColor = GuiConfig.GroupBoxBorder3DColor;

            this.ResumeLayout(false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the background color of the groupbox
        /// </summary>
        [DefaultValue(typeof(Color), "247, 239, 231")]
        [Description("Get or set the background color of the groupbox")]
        [Category("Appearance")]
        public override Color BackColor
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the 3D border color of the groupbox
        /// </summary>
        [DefaultValue(typeof(Color), "255, 255, 255")]
        [Description("Get or set the 3D border color of the groupbox")]
        [Category("Appearance")]
        public Color Border3DColor
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the border color of the groupbox
        /// </summary>
        [DefaultValue(typeof(Color), "207, 159, 112")]
        [Description("Get or set the border color of the groupbox")]
        [Category("Appearance")]
        public Color BorderColor
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the text fore color of the groupbox
        /// </summary>
        [DefaultValue(typeof(Color), "0, 0, 0")]
        [Description("Get or set the text fore color of the groupbox")]
        [Category("Appearance")]
        public Color TextForeColor
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Paints the control
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> arguments</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            #region Check VisualStyles
            
            if (!Application.RenderWithVisualStyles)
            {
                // no visual styles enabled, use only base for rendering
                base.OnPaint(e);
                return;
            } 

            #endregion

            #region Init

            // setup flag
            bool hasText = !string.IsNullOrEmpty(Text);

            // setup text sizes
            Size textSize = TextRenderer.MeasureText(Text, this.Font);

            // setup vars
            Rectangle borderRect = this.ClientRectangle;
            Rectangle textRect = this.ClientRectangle;

            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            GraphicsPath path3D = new System.Drawing.Drawing2D.GraphicsPath();
            Brush textBrush = new SolidBrush(TextForeColor);
            Brush borderBrush = new SolidBrush(BorderColor);
            Brush borderBrush3D = new SolidBrush(Border3DColor);
            Brush backgroundBrush = new SolidBrush(BackColor);
            Pen borderPen = new Pen(borderBrush, 1);
            Pen borderPen3D = new Pen(borderBrush3D, 1);

            #endregion

            #region Setup Rectangle

            // check if groupbox has text > different border position
            if (!hasText)
            {
                // no text, modify border rectangle
                Size generalTextSizeY = TextRenderer.MeasureText("AnyText", this.Font);

                // setup rectangle for border
                borderRect.Y += generalTextSizeY.Height / 2;
                borderRect.Height -= DEFAULTTEXTHEIGHTSUBTRACTOR;
            }
            else
            {
                // setup rectangle for border
                borderRect.Y += textSize.Height / 2;
                borderRect.Height -= DEFAULTTEXTHEIGHTSUBTRACTOR;

                // setup rectangle for text
                textRect.X += 8;
                textRect.Width = textSize.Width; //+ AddTextRectWidth(Font.Height); // try to ensure text will not be cut
                textRect.Height = textSize.Height;
            }

            #endregion

            #region Calculate Border

            // setup rounded border path
            int arcX1 = borderRect.X;
            int arcX2 = (borderRect.Width) - (ARCWIDTH) - 2;
            int arcY1 = borderRect.Y - 1;
            int arcY2 = borderRect.Height - 1;

            path.AddArc(arcX1, arcY1, ARCWIDTH, ARCHEIGHT, 180, 90); // Top Left
            path.AddArc(arcX2, arcY1, ARCWIDTH, ARCHEIGHT, 270, 90); // Top Right
            path.AddArc(arcX2, arcY2, ARCWIDTH, ARCHEIGHT, 360, 90); // Bottom Right
            path.AddArc(arcX1, arcY2, ARCWIDTH, ARCHEIGHT, 90, 90);  // Bottom Left

            path3D.AddArc(arcX1 + 1, arcY1 + 1, ARCWIDTH, ARCHEIGHT, 180, 90); // Top Left
            path3D.AddArc(arcX2 + 1, arcY1 + 1, ARCWIDTH, ARCHEIGHT, 270, 90); // Top Right
            path3D.AddArc(arcX2 + 1, arcY2 + 1, ARCWIDTH, ARCHEIGHT, 360, 90); // Bottom Right
            path3D.AddArc(arcX1 + 1, arcY2 + 1, ARCWIDTH, ARCHEIGHT, 90, 90);  // Bottom Left

            path.CloseAllFigures();
            path3D.CloseAllFigures();

            #endregion

            #region Painting

            // paint rectangle and border
            e.Graphics.FillPath(backgroundBrush, path);
            e.Graphics.DrawPath(borderPen3D, path3D);
            e.Graphics.DrawPath(borderPen, path);

            // paint text and rectangle for text (without border)
            if (hasText)
            {
                e.Graphics.FillRectangle(backgroundBrush, textRect);
                e.Graphics.DrawString(Text, Font, textBrush, Convert.ToSingle(textRect.X), Convert.ToSingle(textRect.Y));
            }

            #endregion

            #region Clean up

            if (path != null)
            {
                path.Dispose();
            }

            if (path3D != null)
            {
                path3D.Dispose();
            }

            if (borderPen != null)
            {
                borderPen.Dispose();
            }

            if (borderPen3D != null)
            {
                borderPen3D.Dispose();
            }

            if (textBrush != null)
            {
                textBrush.Dispose();
            }

            if (borderBrush != null)
            {
                borderBrush.Dispose();
            }

            if (borderBrush3D != null)
            {
                borderBrush3D.Dispose();
            }

            if (backgroundBrush != null)
            {
                backgroundBrush.Dispose();
            }

            #endregion
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Due to strange behaviour in MeasureText function call, we do not always get the proper size used for the text.
        /// Use this method to add some additional space for drawing the text of the groupbox
        /// </summary>
        /// <param name="textFontHeight">The height of the font, used to calculate an additional space</param>
        /// <returns>The additional space to add to width of textarea rectangle</returns>
        private int AddTextRectWidth(int textFontHeight)
        {
            // 0..10
            if (textFontHeight < 11)
            {
                return 0;
            }

            // 11..14
            if (textFontHeight < 15)
            {
                return 2;
            }

            // 15
            if (textFontHeight < 16)
            {
                return 3;
            }

            // 16
            if (textFontHeight < 17)
            {
                return 5;
            }

            // 17
            if (textFontHeight < 18)
            {
                return 8;
            }

            // 18
            if (textFontHeight < 19)
            {
                return 9;
            }

            // 19
            if (textFontHeight < 20)
            {
                return 10;
            }

            // 20
            if (textFontHeight < 21)
            {
                return 12;
            }

            // > 20
            return 15;
        }

        #endregion

        #endregion
    }
}