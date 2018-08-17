//------------------------------------------------------------------------------
/// <copyright from='1997' to='2002' company='Microsoft Corporation'>
///    Copyright (c) Microsoft Corporation. All Rights Reserved.
///
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.DesignerHost
{
	/// Our implementation of a toolbox. We kept the actual toolbox control
	/// separate from the IToolboxService, but the toolbox could easily
	/// implement the service itself. Note that IToolboxUser does not pertain
	/// to the toolbox, but instead is implemented by the designers that receive
	/// ToolboxItems.
	public class ToolboxPane : System.Windows.Forms.UserControl
	{
        private MyDesignSurface designSurface;
		internal ToolboxItem pointer; // a "null" tool
		private int selectedIndex; // the index of the currently selected tool
		private bool initialPaint = true; // see ToolboxPane_Paint method

		// We load types into our categories in a rather primitive way. It is easier than
		// dealing with type resolution, but we can only do this since our list of tools
		// is standard and unchanging.
		//
		private Type[] windowsFormsToolTypes = new Type[] {
			typeof(System.Windows.Forms.PictureBox),
			typeof(System.Windows.Forms.ProgressBar),

			typeof(System.Windows.Forms.Panel),
			typeof(System.Windows.Forms.SplitContainer),
			typeof(System.Windows.Forms.TableLayoutPanel),

			typeof(System.Windows.Forms.ImageList),
			typeof(System.Windows.Forms.OpenFileDialog),
			typeof(System.Windows.Forms.SaveFileDialog),
			typeof(System.Windows.Forms.FontDialog),
			typeof(System.Windows.Forms.ColorDialog),
			typeof(System.Windows.Forms.PrintDialog),
			typeof(System.Windows.Forms.PrintPreviewDialog),
			typeof(System.Windows.Forms.PrintPreviewControl),
			typeof(System.Windows.Forms.Timer),

			typeof(DevExpress.XtraBars.BarManager),
			typeof(DevExpress.XtraBars.PopupMenu)
		};

		private SharpLibrary.WinControls.TabPageEx tabPageDataBound;
		private SharpLibrary.WinControls.TabPageEx tabPageControls;
		private System.Windows.Forms.ListBox lstControl;
		internal System.Windows.Forms.ListBox lstDataField;
		private KiSS4.Gui.KissTabControlEx tabControl;

		private System.ComponentModel.Container components = null;

		public ToolboxPane()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			pointer = new ToolboxItem();
			pointer.DisplayName = "<Pointer>";
			pointer.Bitmap = new Bitmap(16, 16);
			
			// Populate our tool lists.
			ListBox list = this.tabControl.SelectedTab.Controls[0] as ListBox;
			this.lstControl.Items.Add(pointer);
			this.lstDataField.Items.Add(pointer);
		}

		/// Clean up any resources being used.
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		// Properties

		/// We need access to the designers.
		[DefaultValue(null)]
		public MyDesignSurface DesignSurface
		{
            get { return designSurface; }
            set { designSurface = value; }
		}

		/// The currently selected tool is defined by our currently selected
		/// category (ListBox) and our selectedIndex member.
		public ToolboxItem SelectedTool
		{
			get
			{
				ListBox list = this.tabControl.SelectedTab.Controls[0] as ListBox;
				return list.Items[selectedIndex] as ToolboxItem;
			}
		}

		/// The name of our selected category (Windows Forms, Components, etc.)
		/// This property (and the next few) are all in place to support
		/// methods of the IToolboxService.
		public string SelectedCategory
		{
			get { return tabControl.SelectedTab.Text; }
		}

		/// The names of all our categories.
		public CategoryNameCollection CategoryNames
		{
			get
			{
				string[] categories = new string[tabControl.TabPages.Count];
				for (int i = 0; i < tabControl.TabPages.Count; i++)
					categories[i] = tabControl.TabPages[i].Text;

				return new CategoryNameCollection(categories);
			}
		}

		// Methods

		/// The IToolboxService has methods for getting tool collections using
		/// an optional category parameter. We support that request here.
		public ToolboxItemCollection GetToolsFromCategory(string category)
		{
			foreach (TabPage tab in tabControl.TabPages)
			{
				if (tab.Text == category)
				{
					ListBox list = tab.Controls[0] as ListBox;
					ToolboxItem[] tools = new ToolboxItem[list.Items.Count];
					list.Items.CopyTo(tools, 0);
					return new ToolboxItemCollection(tools);
				}
			}

			return null;
		}

		/// Get all of our tools.
		public ToolboxItemCollection GetAllTools()
		{
			ArrayList toolsAL = new ArrayList();
			foreach (TabPage tab in tabControl.TabPages)
			{
				ListBox list = tab.Controls[0] as ListBox;
				toolsAL.Add(list.Items);
			}
			ToolboxItem[] tools = new ToolboxItem[toolsAL.Count];
			toolsAL.CopyTo(tools);
			return new ToolboxItemCollection(tools);
		}

		/// Resets the selection to the pointer. Note that this is the only method
		/// which allows our IToolboxService to set our selection. It calls this method
		/// after a tool has been used.
		public void SelectPointer()
		{
			ListBox list = this.tabControl.SelectedTab.Controls[0] as ListBox;
			if (list.SelectedIndex > 0)
				list.Invalidate(list.GetItemRectangle(list.SelectedIndex));
			selectedIndex = 0;
			list.SelectedIndex = 0;
			list.Invalidate(list.GetItemRectangle(selectedIndex));
		}

		#region Component Designer generated code
		 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		
		private void InitializeComponent()
		{
			this.lstControl = new System.Windows.Forms.ListBox();
			this.lstDataField = new System.Windows.Forms.ListBox();
			this.tabControl = new KiSS4.Gui.KissTabControlEx();
			this.tabPageControls = new SharpLibrary.WinControls.TabPageEx();
			this.tabPageDataBound = new SharpLibrary.WinControls.TabPageEx();
			this.tabControl.SuspendLayout();
			this.tabPageControls.SuspendLayout();
			this.tabPageDataBound.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstControl
			// 
			this.lstControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.lstControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstControl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.lstControl.Location = new System.Drawing.Point(0, 0);
			this.lstControl.Name = "lstControl";
			this.lstControl.Size = new System.Drawing.Size(276, 514);
			this.lstControl.Sorted = true;
			this.lstControl.TabIndex = 0;
			this.lstControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.list_DrawItem);
			this.lstControl.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.list_MeasureItem);
			this.lstControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_MouseDown);
			this.lstControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
			// 
			// lstDataField
			// 
			this.lstDataField.AllowDrop = true;
			this.lstDataField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.lstDataField.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstDataField.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.lstDataField.Location = new System.Drawing.Point(0, 0);
			this.lstDataField.Name = "lstDataField";
			this.lstDataField.Size = new System.Drawing.Size(276, 514);
			this.lstDataField.TabIndex = 0;
			this.lstDataField.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.list_DrawItem);
			this.lstDataField.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.list_MeasureItem);
			this.lstDataField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.list_MouseDown);
			this.lstDataField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
			// 
			// tabControl
			// 
			this.tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.tabControl.Controls.Add(this.tabPageControls);
			this.tabControl.Controls.Add(this.tabPageDataBound);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedTabIndex = 1;
			this.tabControl.ShowFixedWidthTooltip = true;
			this.tabControl.Size = new System.Drawing.Size(288, 552);
			this.tabControl.TabIndex = 0;
			this.tabControl.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tabPageControls,
            this.tabPageDataBound});
			this.tabControl.TabsLineColor = System.Drawing.Color.Black;
			this.tabControl.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
			this.tabControl.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
			this.tabControl.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControl_SelectedTabChanged);
			// 
			// tabPageControls
			// 
			this.tabPageControls.Controls.Add(this.lstControl);
			this.tabPageControls.Location = new System.Drawing.Point(6, 32);
			this.tabPageControls.Name = "tabPageControls";
			this.tabPageControls.Size = new System.Drawing.Size(276, 514);
			this.tabPageControls.TabIndex = 1;
			this.tabPageControls.Title = "Steuerelemente";
			// 
			// tabPageDataBound
			// 
			this.tabPageDataBound.Controls.Add(this.lstDataField);
			this.tabPageDataBound.Location = new System.Drawing.Point(6, 32);
			this.tabPageDataBound.Name = "tabPageDataBound";
			this.tabPageDataBound.Size = new System.Drawing.Size(276, 514);
			this.tabPageDataBound.TabIndex = 0;
			this.tabPageDataBound.Title = "Datenfelder";
			// 
			// ToolboxPane
			// 
			this.Controls.Add(this.tabControl);
			this.Name = "ToolboxPane";
			this.Size = new System.Drawing.Size(288, 552);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ToolboxPane_Paint);
			this.tabControl.ResumeLayout(false);
			this.tabPageControls.ResumeLayout(false);
			this.tabPageDataBound.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		// Fill our ListBoxes with the appropriate ToolboxItems.
		internal void FillToolbox(string ClassName)
		{
			this.lstControl.Items.Clear();
			this.lstControl.Items.Add(pointer);

			// Append KiSS SqlQuery
			AddToolboxItem(this.lstControl, typeof(KiSS4.DB.SqlQuery));

			// Append KiSS Gui-Controls
			Assembly asm = Assembly.GetAssembly(typeof(Gui.KissUserControl));
			foreach (Type type in asm.GetExportedTypes())
			{
				if (typeof(Control).IsAssignableFrom(type) && !(typeof(Form).IsAssignableFrom(type) || typeof(Gui.KissUserControl).IsAssignableFrom(type))
					&& typeof(Gui.KissComplexControl) != type && typeof(Gui.KissTabControlEx) != type )
					AddToolboxItem(this.lstControl, type);
			}

			// Append Windows Controls
			foreach (Type type in windowsFormsToolTypes)
				AddToolboxItem(this.lstControl, type);

			// Append KiSS Complex Controls
			asm = Assembly.GetAssembly(typeof(Common.Utils));
			foreach (Type type in asm.GetExportedTypes())
			{
				if (typeof(Control).IsAssignableFrom(type) && !(typeof(Form).IsAssignableFrom(type) || typeof(KiSS4.Gui.KissUserControl).IsAssignableFrom(type)) )
					AddToolboxItem(this.lstControl, type);
			}

			AddToolboxItem(this.lstControl, typeof(KiSS4.Dokument.XDokument));
            AddToolboxItem(this.lstControl, typeof(KiSS4.Dokument.KissDocumentButton));

			foreach (DataRow row in DBUtil.OpenSQL("SELECT ClassName_Ref FROM XClassReference WHERE ClassName = {0}", ClassName).DataTable.Rows)
			{
				Type type = Gui.AssemblyLoader.GetType((string)row["ClassName_Ref"]);
				if (typeof(Control).IsAssignableFrom(type) && !typeof(Form).IsAssignableFrom(type))
					AddToolboxItem(this.lstControl, type);
			}
		}

		internal static void AddToolboxItem(ListBox listBox, Type type)
		{
			ToolboxItem tbi = new ToolboxItem(type);
			ToolboxBitmapAttribute tba = TypeDescriptor.GetAttributes(type)[typeof(ToolboxBitmapAttribute)] as ToolboxBitmapAttribute;
			if (tba != null)
				tbi.Bitmap = (Bitmap)tba.GetImage(type);

			listBox.Items.Add(tbi);
		}

		// Event Handlers

		/// Each ToolboxItem contains a string and a bitmap. We draw each of these each time
		/// we draw a ListBox item (a tool).
		private void list_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			// validate index (throws an exception on adding component to control due to index=-1 --> TODO: reason?)
            if (e == null || e.Index < 0)
            {
                return;
            }
            
            ListBox lbSender = sender as ListBox;

			// If this tool is the currently selected tool, draw it with a highlight.
			if (selectedIndex == e.Index)
                e.Graphics.FillRectangle(Brushes.DarkSlateGray, e.Bounds);
			else
				e.Graphics.FillRectangle(Brushes.Transparent, e.Bounds);

			ToolboxItem tbi = lbSender.Items[e.Index] as ToolboxItem;
			Rectangle BitmapBounds = new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, tbi.Bitmap.Width, e.Bounds.Height);
			Rectangle StringBounds = new Rectangle(e.Bounds.Location.X + BitmapBounds.Width, e.Bounds.Location.Y, e.Bounds.Width - BitmapBounds.Width, e.Bounds.Height);
			e.Graphics.DrawImage(tbi.Bitmap, BitmapBounds);

            if (selectedIndex == e.Index)
                e.Graphics.DrawString(tbi.DisplayName, lbSender.Font, Brushes.White, StringBounds);
            else
                e.Graphics.DrawString(tbi.DisplayName, lbSender.Font, Brushes.Black, StringBounds);
		}

		/// We measure each item by taking the combined width of the string and bitmap,
		/// and the greater height of the two.
		private void list_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
		{
			ListBox lbSender = sender as ListBox;
			ToolboxItem tbi = lbSender.Items[e.Index] as ToolboxItem;
			Size textSize = e.Graphics.MeasureString(tbi.DisplayName, lbSender.Font).ToSize();
			e.ItemWidth = tbi.Bitmap.Width + textSize.Width;
			if (tbi.Bitmap.Height > textSize.Height)
				e.ItemHeight = tbi.Bitmap.Height;
			else
				e.ItemHeight = textSize.Height;
		}

		/// This method handles a MouseDown event, which might be one of three things:
		///		1) the start of a single click
		///		2) the start of a drag
		///		3) the start of a second of two consecutive clicks (double-click)
		private void list_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// Regardless of which kind of click this is, we need to change the selection.
			// First we grab the bounds of the old selected tool so that we can de-higlight it.
			//
			ListBox lbSender = sender as ListBox;
			Rectangle lastSelectedBounds = lbSender.GetItemRectangle(selectedIndex);

			selectedIndex = lbSender.IndexFromPoint(e.X, e.Y); // change our selection
			lbSender.SelectedIndex = selectedIndex;

			lbSender.Invalidate(lastSelectedBounds); // clear highlight from last selection
			lbSender.Invalidate(lbSender.GetItemRectangle(selectedIndex)); // highlight new one
			
			if (selectedIndex != 0)
			{
				// If this is a double-click, then the user wants to add the selected component
				// to the default location on the designer, with the default size. We call
				// ToolPicked on the current designer (as a IToolboxUser) to place the tool.
				// The IToolboxService calls SelectedToolboxItemUsed(), which calls this control's
				// SelectPointer() method.
				//
				if (e.Clicks == 2)
				{
                    IToolboxUser tbu = designSurface.GetDesigner(designSurface.RootComponent) as IToolboxUser;
					if (tbu != null)
						tbu.ToolPicked((ToolboxItem)(lbSender.Items[selectedIndex]));
				}
				// Otherwise this is either a single click or a drag. Either way, we do the same
				// thing: start a drag--if this is just a single click, then the drag will
				// abort as soon as there's a MouseUp event.
				//
				else if (e.Clicks < 2)
				{
					ToolboxItem tbi = lbSender.Items[selectedIndex] as ToolboxItem;
					IToolboxService tbs = designSurface.GetService(typeof(IToolboxService)) as IToolboxService;

					if (tbi is MyToolboxItem) tbi = new ToolboxItem(((MyToolboxItem)tbi).Type);
					// The IToolboxService serializes ToolboxItems by packaging them in DataObjects.
					DataObject d = tbs.SerializeToolboxItem(tbi) as DataObject;
					try
					{
						lbSender.DoDragDrop(d, DragDropEffects.Copy);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		/// Go to the pointer whenever we change categories.
		private void tabControl_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
		{
			SelectPointer();
		}

		/// On our first paint, select the pointer.
		private void ToolboxPane_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (initialPaint)
				SelectPointer();

			initialPaint = false;
		}

		/// The toolbox can also be navigated using the keyboard commands Up, Down, and Enter.
		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			ListBox lbSender = sender as ListBox;
			Rectangle lastSelectedBounds = lbSender.GetItemRectangle(selectedIndex);
			switch (e.KeyCode)
			{
				case Keys.Up: if (selectedIndex > 0)
					{
						selectedIndex--; // change selection
						lbSender.SelectedIndex = selectedIndex;
						lbSender.Invalidate(lastSelectedBounds); // clear old highlight
						lbSender.Invalidate(lbSender.GetItemRectangle(selectedIndex)); // add new one
					}
					break;
				case Keys.Down: if (selectedIndex + 1 < lbSender.Items.Count)
					{
						selectedIndex++; // change selection
						lbSender.SelectedIndex = selectedIndex;
						lbSender.Invalidate(lastSelectedBounds); // clear old highlight
						lbSender.Invalidate(lbSender.GetItemRectangle(selectedIndex)); // add new one
					}
					break;
                case Keys.Enter: IToolboxUser tbu = designSurface.GetDesigner(designSurface.RootComponent) as IToolboxUser;
					if (tbu != null)
					{
						// Enter means place the tool with default location and default size.
						tbu.ToolPicked((ToolboxItem)(lbSender.Items[selectedIndex]));
					}
					break;
			}
		}
	}
}
