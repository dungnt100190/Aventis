using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KiSS4.Gui
{
	/// <summary>
	/// KissPanel for scrolling functionality
	/// </summary>
	[System.Drawing.ToolboxBitmapAttribute(typeof(System.Windows.Forms.Panel))]
	public class KissScrollablePanel : Panel
	{
		#region Fields

		// fields
		/// <summary>
		/// Set if picRightBottom shall be used to determine if scrollbars have to be shown
		/// </summary>
		private bool useSaveScrollMode;

		// form components and controls
		private PictureBox picRightBottom;

		#endregion

		#region Constructor / Init

		/// <summary>
		/// Default constructor, setup default behaviour
		/// </summary>
		public KissScrollablePanel()
		{
			// init
			InitializeComponent();

			// setup default values
			this.AutoScroll = true;
			this.AutoScrollMargin = new System.Drawing.Size(6, 6);
		}

		/// <summary>
		/// Initialize components on control
		/// </summary>
		private void InitializeComponent()
		{
			this.picRightBottom = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picRightBottom)).BeginInit();
			this.SuspendLayout();
			// 
			// picRightBottom
			// 
			this.picRightBottom.BackColor = System.Drawing.Color.Transparent;
			this.picRightBottom.Location = new System.Drawing.Point(0, 0);
			this.picRightBottom.Name = "picRightBottom";
			this.picRightBottom.Size = new System.Drawing.Size(1, 1);
			this.picRightBottom.TabIndex = 0;
			this.picRightBottom.TabStop = false;
			this.picRightBottom.Visible = false;
			// 
			// KissScrollablePanel
			//
			((System.ComponentModel.ISupportInitialize)(this.picRightBottom)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		#region Properties

		/// <summary>
		/// Indicates wheather scroll bars automatically appear when the control contents are larger than its visible area.
		/// </summary>
		[Browsable(true)]
		[DefaultValue(true)]
		[Description("Indicates wheather scroll bars automatically appear when the control contents are larger than its visible area.")]
		public new bool AutoScroll
		{
			get { return base.AutoScroll; }
			set { base.AutoScroll = value; }
		}

		/// <summary>
		/// Gets or sets the size of the auto-scroll margin
		/// </summary>
		[Localizable(true)]
		[Browsable(true)]
		[DefaultValue(typeof(Size), "6; 6")]
		[Description("The margin arround control during auto scroll")]
		public new Size AutoScrollMargin
		{
			get { return base.AutoScrollMargin; }
			set { base.AutoScrollMargin = value; }
		}

		/// <summary>
		/// Force showing scrollbars even for anchored, docked or otherwise positioned controls if normal mode does not work and controls become hidden.
		/// </summary>
		[Browsable(true)]
		[DefaultValue(false)]
		[Description("Force showing scrollbars even for anchored, docked or otherwise positioned controls if normal mode does not work and controls become hidden.")]
		public bool SaveScrollMode
		{
			get { return this.useSaveScrollMode; }
			set
			{
				// apply value to base
				this.useSaveScrollMode = value;
				this.picRightBottom.Visible = value;

				// release events
				this.Layout -= new System.Windows.Forms.LayoutEventHandler(this.KissScrollablePanel_Layout);
				this.Resize -= new System.EventHandler(this.KissScrollablePanel_Resize);
				this.SizeChanged -= new System.EventHandler(this.KissScrollablePanel_SizeChanged);

				// add/remove picRightBottom and do force resizing if value is set
				if (value)
				{
					if (!this.Controls.Contains(picRightBottom))
					{
						this.Controls.Add(picRightBottom);
					}

					// connect events
					this.Layout += new System.Windows.Forms.LayoutEventHandler(this.KissScrollablePanel_Layout);
					this.Resize += new System.EventHandler(this.KissScrollablePanel_Resize);
					this.SizeChanged += new System.EventHandler(this.KissScrollablePanel_SizeChanged);

					this.DoSaveScrollMode();
				}
				else
				{
					if (this.Controls.Contains(picRightBottom))
					{
						this.Controls.Remove(picRightBottom);
					}
				}
			}
		}

		#endregion

		#region Events

		/// <summary>
		/// The Resize event, used to setup possible scrollbars if anchored or min/max-sized controls are hidden
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The event arguments</param>
		private void KissScrollablePanel_Resize(object sender, EventArgs e)
		{
			DoSaveScrollMode();
		}

		/// <summary>
		/// The SizeChanged event, used to setup possible scrollbars if anchored or min/max-sized controls are hidden
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The event arguments</param>
		private void KissScrollablePanel_SizeChanged(object sender, EventArgs e)
		{
			DoSaveScrollMode();
		}

		/// <summary>
		/// The Layout event, used to setup possible scrollbars if anchored or min/max-sized controls are hidden
		/// </summary>
		/// <param name="sender">The sender of the event</param>
		/// <param name="e">The event arguments</param>
		private void KissScrollablePanel_Layout(object sender, LayoutEventArgs e)
		{
			DoSaveScrollMode();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Set if currently working in DoSaveScrollMode
		/// </summary>
		private bool isDoingSaveScrollMode;

		/// <summary>
		/// Do save scroll mode recalculation
		/// </summary>
		public void DoSaveScrollMode()
		{
			// check if need to process picBottomRight
			if (!this.AutoScroll || !this.useSaveScrollMode || this.isDoingSaveScrollMode)
			{
				return;
			}

			try
			{
				// vars
				this.isDoingSaveScrollMode = true;
				this.AutoScroll = false;
				int maxRight = 0;
				int maxBottom = 0;

				// loop through first-level-childcontrols to determine maxRight and maxBottom
				foreach (Control ctl in this.Controls)
				{
					if (ctl != null && ctl != picRightBottom)
					{
						// setup new maxRight
						if (maxRight < ctl.Left + ctl.Width)
						{
							maxRight = ctl.Left + ctl.Width;
						}

						// setup new maxBottom
						if (maxBottom < ctl.Top + ctl.Height)
						{
							maxBottom = ctl.Top + ctl.Height;
						}
					}
				}

				// setup new position for picBottomRight
				picRightBottom.Left = maxRight - 1;
				picRightBottom.Top = maxBottom - 1;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);

				if (System.Diagnostics.Debugger.IsAttached)
				{
					System.Diagnostics.Debugger.Break();
				}
			}
			finally
			{
				this.AutoScroll = true;
				this.isDoingSaveScrollMode = false;
			}
		}

		#endregion
	}
}
