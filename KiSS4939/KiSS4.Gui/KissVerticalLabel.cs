using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Gui
{
	#region Enum DrawDirection

	/// <summary>
	/// Enumeration for DrawDirection used in KissVerticalLabel
	/// </summary>
	public enum DrawDirection
	{
		/// <summary>
		/// Draw direction form top to bottom. 
		/// </summary>
		TopDown = 0,

		/// <summary>
		/// Draw direction from bottom to top.
		/// </summary>
		DownTop = 1
	}

	#endregion

	/// <summary>
	/// VerticalLabel is a component that displays a label, but instead of the
	/// text being horizontal it is displayed vertically.
	///
	/// This is achieved by drawing using the specified Font and overriding
	/// the OnPaint method to draw with the font rotated.
	///
	/// Windows designer support is also included, the default text and alignment
	/// can be set in the designer
	/// </summary>
	[System.Drawing.ToolboxBitmapAttribute(typeof(System.Windows.Forms.Label))]
	public class KissVerticalLabel : System.Windows.Forms.UserControl
	{
		#region Fields

		//private System.ComponentModel.Container components;

		/// <summary>
		/// Property: Internal field for the current label text
		/// </summary>
		private string labelText;

		/// <summary>
		/// Property: Internal field for the alignment of the vertical text
		/// </summary>
		private ContentAlignment labelTextAlign = ContentAlignment.TopLeft;

		/// <summary>
		/// Property: Internal field for the drawing direction of the text
		/// </summary>
		private DrawDirection drawDirection = DrawDirection.TopDown;

		/// <summary>
		/// Property: The border style used to paint the control
		/// </summary>
		private System.Windows.Forms.BorderStyle borderStyle = System.Windows.Forms.BorderStyle.None;

		/// <summary>
		/// Property: The border color used to paint the control
		/// </summary>
		private System.Drawing.Color borderColor = System.Drawing.Color.Black;

		/// <summary>
		/// Property: The width of the border used to paint the control
		/// </summary>
		private int borderWidth = 1;

		/// <summary>
		/// Property: Enable automatic resizing depending on font-size and text content
		/// </summary>
		private bool autoSize;

		/// <summary>
		/// Property: Enables the automatic handling of text that extends beyond the width of the label control
		/// </summary>
		private bool autoEllipsis;

		#endregion

		#region Constructor / Initialize / Dispose

		/// <summary>
		/// Default constructor
		/// </summary>
		public KissVerticalLabel()
		{
			InitializeComponent();

			// add style for transparent color
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.UpdateStyles();
		}

		/// <summary>
		/// Dispose control
		/// </summary>
		/// <param name="disposing">True if disposing</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				//if (!((components == null)))
				//{
				//   components.Dispose();
				//}
			}

			base.Dispose(disposing);
		}

		/// <summary>
		/// Initialize control and components on control
		/// </summary>
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.Size = new System.Drawing.Size(24, 100);
		}

		#endregion

		#region Properties

		/// <summary>
		/// Enable automatic resizing depending on font-size and text content
		/// </summary>
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("Enable automatic resizing depending on font-size and text content")]
		public bool AutoResize
		{
			get { return this.autoSize; }
			set
			{
				this.autoSize = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Enables the automatic handling of text that extends beyond the width of the label control
		/// </summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Enables the automatic handling of text that extends beyond the width of the label control")]
		public bool AutoEllipsis
		{
			get { return this.autoEllipsis; }
			set
			{
				this.autoEllipsis = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Text to display vertically in label
		/// </summary>
		[Category("VerticalLabel")]
		[DefaultValue(null)]
		[Description("Text to display vertically in label")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new string Text
		{
			get { return this.labelText; }
			set
			{
				this.labelText = value;
				Invalidate();
			}
		}

		/// <summary>
		/// Specifies alignment of content on the drawing surface
		/// </summary>
		[Category("VerticalLabel")]
		[DefaultValue(typeof(ContentAlignment), "TopLeft")]
		[Description("Specifies alignment of content on the drawing surface")]
		public ContentAlignment TextAlign
		{
			get { return this.labelTextAlign; }
			set
			{
				this.labelTextAlign = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// Specifies the drawing direction for the text
		/// </summary>
		[Category("VerticalLabel")]
		[DefaultValue(typeof(DrawDirection), "TopDown")]
		[Description("Specifies the drawing direction for the text")]
		public DrawDirection DrawDirection
		{
			get { return this.drawDirection; }
			set
			{
				this.drawDirection = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// The border style used to paint the control.
		/// </summary>
		[DefaultValueAttribute(typeof(System.Windows.Forms.BorderStyle), "None")]
		[CategoryAttribute("Appearance")]
		[DescriptionAttribute("The border style used to paint the control.")]
		public new System.Windows.Forms.BorderStyle BorderStyle
		{
			get { return this.borderStyle; }
			set
			{
				this.borderStyle = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// The border color used to paint the control.
		/// </summary>
		[DefaultValueAttribute(typeof(System.Drawing.Color), "WindowFrame")]
		[CategoryAttribute("Appearance")]
		[DescriptionAttribute("The border color used to paint the control.")]
		public System.Drawing.Color BorderColor
		{
			get { return this.borderColor; }
			set
			{
				this.borderColor = value;
				this.Invalidate();
			}
		}

		/// <summary>
		/// The width of the border used to paint the control.
		/// </summary>
		[DefaultValueAttribute(typeof(int), "1")]
		[CategoryAttribute("Appearance")]
		[DescriptionAttribute("The width of the border used to paint the control.")]
		public int BorderWidth
		{
			get { return this.borderWidth; }
			set
			{
				this.borderWidth = value;
				this.Invalidate();
			}
		}

		#endregion

		#region Event: OnPaint, OnResize

		/// <summary>
		/// Overriden onPaint method to draw a string vertically on the screen
		/// </summary>
		/// <param name="e">Default PaintEventArgs parameter</param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			// AUTOSIZE and AUTOELLIPSIS:
			string textToDisplay = DoAutosizeAutoEllipsis(e.Graphics);

			// TEXT:
			// init variables
			float sngControlWidth;
			float sngControlHeight;
			float sngTransformX;
			float sngTransformY;
			Color labelColor = this.BackColor;
			Pen labelBorderPen = new Pen(labelColor, 0);
			SolidBrush labelBackColorBrush = new SolidBrush(labelColor);
			SolidBrush labelForeColorBrush = new SolidBrush(base.ForeColor);

			// do paint on base control
			base.OnPaint(e);

			// define size
			sngControlWidth = this.Size.Width;
			sngControlHeight = this.Size.Height;

			// draw size for text
			e.Graphics.DrawRectangle(labelBorderPen, 0, 0, sngControlWidth, sngControlHeight);
			e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, sngControlWidth, sngControlHeight);

			// transformation depending on drawdirection
			if (this.DrawDirection == DrawDirection.TopDown)
			{
				// top to down
				sngTransformX = sngControlWidth;
				sngTransformY = 0;
				e.Graphics.TranslateTransform(sngTransformX, sngTransformY);
				e.Graphics.RotateTransform(90);
			}
			else
			{
				// down to top
				sngTransformX = 0;
				sngTransformY = sngControlHeight;
				e.Graphics.TranslateTransform(sngTransformX, sngTransformY);
				e.Graphics.RotateTransform(270);
			}

			#region figure out offset to achieve the desired alignment

			//default top-left alignment
			float yOffset = 0;                  // in horizontal mode this would be left
			float xOffset = 0;                  // in horizontal mode this would be top
			int borderOffset = BorderOffset();  // if borderstyle is not "none", adjust a correction factor in order to prevent writing in border
			SizeF sf = e.Graphics.MeasureString(textToDisplay, Font);

			// adjust default offset depending to border
			xOffset = borderOffset;
			yOffset = borderOffset;

			if (this.labelTextAlign == ContentAlignment.BottomCenter ||
				 this.labelTextAlign == ContentAlignment.MiddleCenter ||
				 this.labelTextAlign == ContentAlignment.TopCenter)
			{
				// handle center alignment
				yOffset = (this.Size.Height - sf.Width) / 2;
			}
			else if (this.labelTextAlign == ContentAlignment.BottomRight ||
						this.labelTextAlign == ContentAlignment.MiddleRight ||
						this.labelTextAlign == ContentAlignment.TopRight)
			{
				// handle right alignment
				yOffset = this.Size.Height - sf.Width - borderOffset;
			}

			if (this.labelTextAlign == ContentAlignment.MiddleLeft ||
				 this.labelTextAlign == ContentAlignment.MiddleCenter ||
				 this.labelTextAlign == ContentAlignment.MiddleRight)
			{
				// handle middle alignment
				xOffset = (this.Size.Width - sf.Height) / 2;
			}
			else if (this.labelTextAlign == ContentAlignment.BottomLeft ||
						this.labelTextAlign == ContentAlignment.BottomCenter ||
						this.labelTextAlign == ContentAlignment.BottomRight)
			{
				// handle bottom alignment
				xOffset = this.Size.Width - sf.Height - borderOffset;
			}

			#endregion

			// draw the text into the rotated control
			e.Graphics.DrawString(textToDisplay, Font, labelForeColorBrush, yOffset, xOffset);

			// BORDER:
			GraphicsPath graphPath;
			graphPath = this.GetPath();

			if (this.borderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
			{
				System.Drawing.Pen borderPen = new System.Drawing.Pen(this.borderColor, this.borderWidth);
				e.Graphics.DrawPath(borderPen, graphPath);
				borderPen.Dispose();
			}
			else if (this.borderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
			{
				if (this.DrawDirection == DrawDirection.TopDown)
				{
					DrawBorder3D(e.Graphics, new Rectangle(0, 1, base.Height, base.Width + 1));
				}
				else
				{
					DrawBorder3D(e.Graphics, new Rectangle(1, 0, base.Height + 1, base.Width));
				}
			}
			else if (this.borderStyle == System.Windows.Forms.BorderStyle.None)
			{
				// nothing to do
			}

			graphPath.Dispose();
		}

		/// <summary>
		/// Overriden onPaint method to redraw a string vertically on the screen
		/// </summary>
		/// <param name="e">Event arguments</param>
		protected override void OnResize(EventArgs e)
		{
			// Invalidate on resize event due to alignment and repositioning
			Invalidate();
			base.OnResize(e);
		}

		#endregion

		#region Helper methods

		/// <summary>
		/// Do autosize and autoellipsis depending on current values
		/// </summary>
		/// <param name="g">The instance of the graphics to use</param>
		/// <returns>The text to display in label</returns>
		private string DoAutosizeAutoEllipsis(Graphics g)
		{
			// check value
			if (this.AutoResize)
			{
				// calculate size for current text and font
				SizeF sf = g.MeasureString(this.labelText, Font);

				// apply new size
				base.Width = (int)sf.Height + 2 * BorderOffset();
				base.Height = (int)sf.Width + 2 * BorderOffset();

				// lock resizing
				base.MinimumSize = base.Size;
				base.MaximumSize = base.MaximumSize;

				// return current text 
				return this.labelText;
			}
			else
			{
				// unlock resizing
				base.MinimumSize = new Size(0, 0);
				base.MaximumSize = new Size(0, 0);

				// do autoellipsis if neccessary
				if (!this.AutoEllipsis)
				{
					return this.labelText;
				}

				// calculate size for current text and font
				SizeF sf = g.MeasureString(this.labelText, Font);
				int borderOffset = BorderOffset();

				// check if we need to do ellipsis
				//TODO: DBUtil.IsEmpty()
				if (base.Height >= ((int)sf.Width + 2 * borderOffset) || DBUtil.IsEmpty(this.labelText))
				{
					// no need to do ellipsis
					return this.labelText;
				}
				else
				{
					// define vars
					string textToReturn;
					int charsToRemove = 1;

					try
					{
						// cut chars at the end of the text
						while (true)
						{
							// cut char
							textToReturn = string.Format("{0}...", this.labelText.Substring(0, this.labelText.Length - charsToRemove));

							sf = g.MeasureString(textToReturn, Font);
							if (base.Height >= ((int)sf.Width + 2 * borderOffset) || textToReturn.Equals("..."))
							{
								// we found a suitable value to return
								return textToReturn;
							}

							// cut one more char
							charsToRemove++;
						}
					}
					catch (Exception ex)
					{
						// do nothing with text, just return
						System.Diagnostics.Debug.WriteLine(ex.Message);
						return this.labelText;
					}
				}
			}
		}

		/// <summary>
		/// Get border offset depending on border width and style
		/// </summary>
		/// <returns>The offset of the border</returns>
		private int BorderOffset()
		{
			switch (this.BorderStyle)
			{
				case BorderStyle.Fixed3D:
					return 2;

				case BorderStyle.FixedSingle:
					return this.BorderWidth;

				default:
					return 0;
			}
		}

		/// <summary>
		/// Get the GraphicsPath arround panel depending on current settings
		/// </summary>
		/// <returns>The GraphicsPath arround panel</returns>
		protected System.Drawing.Drawing2D.GraphicsPath GetPath()
		{
			System.Drawing.Drawing2D.GraphicsPath graphPath = new System.Drawing.Drawing2D.GraphicsPath();
			System.Drawing.Rectangle rect = new Rectangle(0, 0, base.Height, base.Width);

			// handle problem with borderwith = 1
			if (this.BorderWidth == 1)
			{
				if (this.DrawDirection == DrawDirection.TopDown)
				{
					rect = new Rectangle(0, 1, base.Height - 1, base.Width - 1);
				}
				else
				{
					rect = new Rectangle(1, 0, base.Height - 1, base.Width - 1);
				}
			}

			// path depending on borderstyle
			if (this.borderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
			{
				// not really used, setup in OnPaint()
				graphPath.AddRectangle(rect);
			}
			else
			{
				try
				{
					int offset = 0;

					if (this.borderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
					{
						if (this.borderWidth > 1)
						{
							offset = DoubleToInt(this.BorderWidth / 2);
						}
					}

					graphPath.AddRectangle(System.Drawing.Rectangle.Inflate(rect, -offset, -offset));
				}
				catch (System.Exception)
				{
					graphPath.AddRectangle(rect);
				}
			}

			return graphPath;
		}

		/// <summary>
		/// Draw a 3d border arround rectangle
		/// </summary>
		/// <param name="graphics">The instance of the graphic object</param>
		/// <param name="rectangle">The rectangle to surround with a border</param>
		public static void DrawBorder3D(System.Drawing.Graphics graphics, System.Drawing.Rectangle rectangle)
		{
			graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
			graphics.DrawLine(System.Drawing.SystemPens.ControlDark, rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Y);
			graphics.DrawLine(System.Drawing.SystemPens.ControlDark, rectangle.X, rectangle.Y, rectangle.X, rectangle.Height - 1);
			graphics.DrawLine(System.Drawing.SystemPens.ControlDarkDark, rectangle.X + 1, rectangle.Y + 1, rectangle.Width - 1, rectangle.Y + 1);
			graphics.DrawLine(System.Drawing.SystemPens.ControlDarkDark, rectangle.X + 1, rectangle.Y + 1, rectangle.X + 1, rectangle.Height - 1);
			graphics.DrawLine(System.Drawing.SystemPens.ControlLight, rectangle.X + 1, rectangle.Height - 2, rectangle.Width - 2, rectangle.Height - 2);
			graphics.DrawLine(System.Drawing.SystemPens.ControlLight, rectangle.Width - 2, rectangle.Y + 1, rectangle.Width - 2, rectangle.Height - 2);
			graphics.DrawLine(System.Drawing.SystemPens.ControlLightLight, rectangle.X, rectangle.Height - 1, rectangle.Width - 1, rectangle.Height - 1);
			graphics.DrawLine(System.Drawing.SystemPens.ControlLightLight, rectangle.Width - 1, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);
		}

		/// <summary>
		/// Convert value in double to int value
		/// </summary>
		/// <param name="value">The value to convert to int</param>
		/// <returns>Converted integer value from double</returns>
		public static int DoubleToInt(double value)
		{
			return System.Decimal.ToInt32(System.Decimal.Floor(System.Decimal.Parse((value).ToString())));
		}

		#endregion
	}
}