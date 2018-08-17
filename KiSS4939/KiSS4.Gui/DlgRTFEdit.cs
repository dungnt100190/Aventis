using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for DlgRTFEdit.
	/// </summary>
	public class DlgRTFEdit : KiSS4.Gui.KissDialog
	{
		private KiSS4.Gui.KissButton btnSave;
		private KiSS4.Gui.KissButton btnCancel;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.Bar bar2;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repeditFont;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repeditFontSize;
		private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repeditFontColor;
		private DevExpress.XtraBars.BarButtonItem btnBold;
		private DevExpress.XtraBars.BarButtonItem btnItalic;
		private DevExpress.XtraBars.BarButtonItem btnUnderline;
		private DevExpress.XtraBars.BarEditItem editFontName;
		private DevExpress.XtraBars.BarEditItem editFontSize;
		private DevExpress.XtraBars.BarButtonItem btnLeft;
		private DevExpress.XtraBars.BarButtonItem btnCenter;
		private DevExpress.XtraBars.BarButtonItem btnRight;
		private DevExpress.XtraBars.BarButtonItem btnBullets;
		private KiSS4.Gui.KissRTFEdit editRTF;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;

		private bool updating;

		/// <summary>
		/// Initializes a new instance of the <see cref="DlgRTFEdit"/> class.
		/// </summary>
		/// <param name="readOnly">if set to <c>true</c> [read only].</param>
		public DlgRTFEdit(bool readOnly)
		{
			InitializeComponent();

			foreach (FontFamily f in FontFamily.Families)
				repeditFont.Items.Add(f.Name);

			int[] FontSizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

			foreach (int i in FontSizes)
				repeditFontSize.Items.Add(i);

			editRTF.ReadOnly = readOnly;
			barManager1.Bars["Format"].Visible = !readOnly;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}

				if (this.barManager1 != null) this.barManager1.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Gets the RTF editor.
		/// </summary>
		/// <value>The RTF editor.</value>
		[Browsable(false)]
		public KissRTFEdit RTFEditor
		{
			get { return editRTF; }
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgRTFEdit));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			this.btnSave = new KiSS4.Gui.KissButton();
			this.btnCancel = new KiSS4.Gui.KissButton();
			this.editRTF = new KiSS4.Gui.KissRTFEdit();
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar2 = new DevExpress.XtraBars.Bar();
			this.editFontName = new DevExpress.XtraBars.BarEditItem();
			this.repeditFont = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.editFontSize = new DevExpress.XtraBars.BarEditItem();
			this.repeditFontSize = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.btnBold = new DevExpress.XtraBars.BarButtonItem();
			this.btnItalic = new DevExpress.XtraBars.BarButtonItem();
			this.btnUnderline = new DevExpress.XtraBars.BarButtonItem();
			this.btnLeft = new DevExpress.XtraBars.BarButtonItem();
			this.btnCenter = new DevExpress.XtraBars.BarButtonItem();
			this.btnRight = new DevExpress.XtraBars.BarButtonItem();
			this.btnBullets = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.repeditFontColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repeditFont)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repeditFontSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repeditFontColor)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(478, 370);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 24);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "OK";
			this.btnSave.UseVisualStyleBackColor = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(566, 370);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Abbruch";
			this.btnCancel.UseVisualStyleBackColor = false;
			// 
			// editRTF
			// 
			this.editRTF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.editRTF.BackColor = System.Drawing.Color.White;
			this.editRTF.EditValue = ((object)(resources.GetObject("editRTF.EditValue")));
			this.editRTF.Font = new System.Drawing.Font("Arial", 10F);
			this.editRTF.Location = new System.Drawing.Point(8, 35);
			this.editRTF.Name = "editRTF";
			this.editRTF.Size = new System.Drawing.Size(640, 328);
			this.editRTF.TabIndex = 0;
			this.editRTF.SelectionChanged += new System.EventHandler(this.editRTF_SelectionChanged);
			// 
			// barManager1
			// 
			this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
			this.barManager1.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Format", new System.Guid("d4a4634c-4da4-4ab3-89b1-b88708b9247f"))});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Images = this.imageList1;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnBold,
            this.btnItalic,
            this.btnUnderline,
            this.editFontName,
            this.editFontSize,
            this.btnLeft,
            this.btnCenter,
            this.btnRight,
            this.btnBullets});
			this.barManager1.MaxItemId = 9;
			this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repeditFont,
            this.repeditFontSize,
            this.repeditFontColor});
			this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
			// 
			// bar2
			// 
			this.bar2.BarItemVertIndent = 5;
			this.bar2.BarName = "Format";
			this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
			this.bar2.DockCol = 0;
			this.bar2.DockRow = 0;
			this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.editFontName, "", false, true, true, 168),
            new DevExpress.XtraBars.LinkPersistInfo(this.editFontSize),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBold),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnItalic),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUnderline),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLeft, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCenter),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRight),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBullets, true)});
			this.bar2.OptionsBar.AllowQuickCustomization = false;
			this.bar2.OptionsBar.DisableCustomization = true;
			this.bar2.Text = "Format";
			// 
			// editFontName
			// 
			this.editFontName.Caption = "FontName";
			this.editFontName.CategoryGuid = new System.Guid("d4a4634c-4da4-4ab3-89b1-b88708b9247f");
			this.editFontName.Edit = this.repeditFont;
			this.editFontName.Id = 3;
			this.editFontName.Name = "editFontName";
			this.editFontName.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.editFontName_ItemClick);
			this.editFontName.EditValueChanged += new System.EventHandler(this.editFontName_EditValueChanged);
			// 
			// repeditFont
			// 
			this.repeditFont.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.repeditFont.Appearance.Options.UseFont = true;
			this.repeditFont.AutoHeight = false;
			serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
			serializableAppearanceObject1.Options.UseBackColor = true;
			this.repeditFont.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
			this.repeditFont.DropDownRows = 12;
			this.repeditFont.Name = "repeditFont";
			// 
			// editFontSize
			// 
			this.editFontSize.Caption = "FontSize";
			this.editFontSize.CategoryGuid = new System.Guid("d4a4634c-4da4-4ab3-89b1-b88708b9247f");
			this.editFontSize.Edit = this.repeditFontSize;
			this.editFontSize.Id = 4;
			this.editFontSize.Name = "editFontSize";
			this.editFontSize.EditValueChanged += new System.EventHandler(this.editFontSize_EditValueChanged);
			// 
			// repeditFontSize
			// 
			this.repeditFontSize.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.repeditFontSize.Appearance.Options.UseFont = true;
			this.repeditFontSize.AutoHeight = false;
			serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
			serializableAppearanceObject2.Options.UseBackColor = true;
			this.repeditFontSize.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
			this.repeditFontSize.DropDownRows = 12;
			this.repeditFontSize.Name = "repeditFontSize";
			// 
			// btnBold
			// 
			this.btnBold.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.btnBold.Caption = "bold";
			this.btnBold.CategoryGuid = new System.Guid("d4a4634c-4da4-4ab3-89b1-b88708b9247f");
			this.btnBold.Id = 0;
			this.btnBold.ImageIndex = 0;
			this.btnBold.Name = "btnBold";
			// 
			// btnItalic
			// 
			this.btnItalic.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.btnItalic.Caption = "italic";
			this.btnItalic.CategoryGuid = new System.Guid("d4a4634c-4da4-4ab3-89b1-b88708b9247f");
			this.btnItalic.Id = 1;
			this.btnItalic.ImageIndex = 1;
			this.btnItalic.Name = "btnItalic";
			// 
			// btnUnderline
			// 
			this.btnUnderline.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.btnUnderline.Caption = "underline";
			this.btnUnderline.CategoryGuid = new System.Guid("d4a4634c-4da4-4ab3-89b1-b88708b9247f");
			this.btnUnderline.Id = 2;
			this.btnUnderline.ImageIndex = 2;
			this.btnUnderline.Name = "btnUnderline";
			// 
			// btnLeft
			// 
			this.btnLeft.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.btnLeft.Caption = "Left";
			this.btnLeft.CategoryGuid = new System.Guid("d4a4634c-4da4-4ab3-89b1-b88708b9247f");
			this.btnLeft.GroupIndex = 1;
			this.btnLeft.Id = 5;
			this.btnLeft.ImageIndex = 3;
			this.btnLeft.Name = "btnLeft";
			// 
			// btnCenter
			// 
			this.btnCenter.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.btnCenter.Caption = "Center";
			this.btnCenter.CategoryGuid = new System.Guid("d4a4634c-4da4-4ab3-89b1-b88708b9247f");
			this.btnCenter.GroupIndex = 1;
			this.btnCenter.Id = 6;
			this.btnCenter.ImageIndex = 4;
			this.btnCenter.Name = "btnCenter";
			// 
			// btnRight
			// 
			this.btnRight.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.btnRight.Caption = "Right";
			this.btnRight.CategoryGuid = new System.Guid("d4a4634c-4da4-4ab3-89b1-b88708b9247f");
			this.btnRight.GroupIndex = 1;
			this.btnRight.Id = 7;
			this.btnRight.ImageIndex = 5;
			this.btnRight.Name = "btnRight";
			// 
			// btnBullets
			// 
			this.btnBullets.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.btnBullets.Caption = "Bullets";
			this.btnBullets.CategoryGuid = new System.Guid("d4a4634c-4da4-4ab3-89b1-b88708b9247f");
			this.btnBullets.Id = 8;
			this.btnBullets.ImageIndex = 6;
			this.btnBullets.Name = "btnBullets";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			this.imageList1.Images.SetKeyName(2, "");
			this.imageList1.Images.SetKeyName(3, "");
			this.imageList1.Images.SetKeyName(4, "");
			this.imageList1.Images.SetKeyName(5, "");
			this.imageList1.Images.SetKeyName(6, "");
			// 
			// repeditFontColor
			// 
			this.repeditFontColor.AutoHeight = false;
			this.repeditFontColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repeditFontColor.Name = "repeditFontColor";
			// 
			// DlgRTFEdit
			// 
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(658, 399);
			this.ControlBox = false;
			this.Controls.Add(this.editRTF);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "DlgRTFEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Memo editieren (formatiert)";
			this.Load += new System.EventHandler(this.DlgRTFEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repeditFont)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repeditFontSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repeditFontColor)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Handles the Load event of the DlgRTFEdit control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void DlgRTFEdit_Load(object sender, System.EventArgs e)
		{
			GetCurrentFormat();
		}

		/// <summary>
		/// Gets the select font.
		/// </summary>
		/// <value>The select font.</value>
		private Font SelectFont
		{
			get
			{
				if (editRTF.SelectionFont != null)
					return editRTF.SelectionFont;
				return editRTF.Font;
			}
		}

		/// <summary>
		/// Gets the current format.
		/// </summary>
		private void GetCurrentFormat()
		{
			updating = true;

			editFontName.EditValue = SelectFont.Name;
			editFontSize.EditValue = SelectFont.Size;
			btnBold.Down = SelectFont.Bold;
			btnItalic.Down = SelectFont.Italic;
			btnUnderline.Down = SelectFont.Underline;
			btnBullets.Down = editRTF.SelectionBullet;
			switch (editRTF.SelectionAlignment)
			{
				case HorizontalAlignment.Left:
					btnLeft.Down = true;
					break;
				case HorizontalAlignment.Center:
					btnCenter.Down = true;
					break;
				case HorizontalAlignment.Right:
					btnRight.Down = true;
					break;
			}

			updating = false;
		}

		/// <summary>
		/// Sets the current format.
		/// </summary>
		private void SetCurrentFormat()
		{
			FontStyle fontStyle = new FontStyle();
			if (btnBold.Down)
				fontStyle |= FontStyle.Bold;
			if (btnItalic.Down)
				fontStyle |= FontStyle.Italic;
			if (btnUnderline.Down)
				fontStyle |= FontStyle.Underline;

			float fontSize = 8;
			if (!DBUtil.IsEmpty(editFontSize.EditValue))
				fontSize = Convert.ToSingle(editFontSize.EditValue);

			string fontName = editFontName.EditValue.ToString();

			editRTF.SelectionFont = new Font(fontName, fontSize, fontStyle);
		}

		/// <summary>
		/// Handles the SelectionChanged event of the editRTF control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editRTF_SelectionChanged(object sender, System.EventArgs e)
		{
			GetCurrentFormat();
		}

		/// <summary>
		/// Handles the EditValueChanged event of the editFontName control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editFontName_EditValueChanged(object sender, System.EventArgs e)
		{
			if (!updating) SetCurrentFormat();
		}

		/// <summary>
		/// Handles the EditValueChanged event of the editFontSize control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void editFontSize_EditValueChanged(object sender, System.EventArgs e)
		{
			if (!updating) SetCurrentFormat();
		}

		/// <summary>
		/// Handles the ItemClick event of the barManager1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs"/> instance containing the event data.</param>
		private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (e.Item == btnBold || e.Item == btnItalic || e.Item == btnUnderline ||
				e.Item == editFontName || e.Item == editFontSize)
			{
				SetCurrentFormat();
			}
			else if (e.Item == btnLeft)
				editRTF.SelectionAlignment = HorizontalAlignment.Left;
			else if (e.Item == btnCenter)
				editRTF.SelectionAlignment = HorizontalAlignment.Center;
			else if (e.Item == btnRight)
				editRTF.SelectionAlignment = HorizontalAlignment.Right;
			else if (e.Item == btnBullets)
				editRTF.SelectionBullet = btnBullets.Down;
		}

		/// <summary>
		/// Handles the ItemClick event of the editFontName control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs"/> instance containing the event data.</param>
		private void editFontName_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			SetCurrentFormat();
		}
	}
}
