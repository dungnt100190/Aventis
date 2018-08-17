using System;
using KiSS4.Gui;

namespace KiSS4.Common
{
	/// <summary>
	/// Summary description for KissSearchForm.
	/// </summary>
	public class KissSearchForm
		:
		KiSS4.Gui.KissChildForm
	{
		#region Fields and Properties

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Titel des Formulars.
		/// </summary>
		protected KiSS4.Gui.KissSearchTitel searchTitle;

		/// <summary>
		/// Tab Control.
		/// </summary>
		protected KiSS4.Gui.KissTabControlEx tabControlSearch;

		/// <summary>
		/// Tab page: Liste
		/// </summary>
		protected SharpLibrary.WinControls.TabPageEx tpgListe;

		/// <summary>
		/// Tab page: Suche
		/// </summary>
		protected SharpLibrary.WinControls.TabPageEx tpgSuchen;

		/// <summary>
		/// KiSS Suche.
		/// </summary>
		protected KissSearch kissSearch;

		#endregion

        public void OnNewSearch()
        {
            this.kissSearch.OnNewSearch();
        }

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="KissSearchForm"/> class.
		/// </summary>
		public KissSearchForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.tabControlSearch.SelectTab(this.tpgListe);

			kissSearch = new KissSearch(this, tabControlSearch, tpgSuchen, tpgListe);
			kissSearch.NewSearch += new EventHandler(search_NewSearch);
			kissSearch.RunSearch += new EventHandler(search_RunSearch);
		}

		#endregion

		#region KissChildForm Members

		/// <summary>
		/// Initialize Tabtitles
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLoad(EventArgs e)
		{
			this.tpgListe.Title = "Liste";
			this.tpgSuchen.Title = "Suche";

			base.OnLoad(e);
		}

		#endregion

		#region IDisposable Members

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
			}
			base.Dispose(disposing);
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControlSearch = new KiSS4.Gui.KissTabControlEx();
			this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
			this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
			this.searchTitle = new KiSS4.Gui.KissSearchTitel();
			this.tabControlSearch.SuspendLayout();
			this.tpgSuchen.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlSearch
			// 
			this.tabControlSearch.Controls.Add(this.tpgListe);
			this.tabControlSearch.Controls.Add(this.tpgSuchen);
			this.tabControlSearch.Location = new System.Drawing.Point(8, 8);
			this.tabControlSearch.Name = "tabControlSearch";
			this.tabControlSearch.ShowFixedWidthTooltip = true;
			this.tabControlSearch.Size = new System.Drawing.Size(824, 256);
			this.tabControlSearch.TabIndex = 0;
			this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
			this.tabControlSearch.TabsLineColor = System.Drawing.Color.Black;
			this.tabControlSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
			// 
			// tpgListe
			// 
			this.tpgListe.Location = new System.Drawing.Point(6, 6);
			this.tpgListe.Name = "tpgListe";
			this.tpgListe.Size = new System.Drawing.Size(812, 218);
			this.tpgListe.TabIndex = 0;
			this.tpgListe.Title = "List";
			// 
			// tpgSuchen
			// 
			this.tpgSuchen.Controls.Add(this.searchTitle);
			this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
			this.tpgSuchen.Name = "tpgSuchen";
			this.tpgSuchen.Size = new System.Drawing.Size(812, 218);
			this.tpgSuchen.TabIndex = 1;
			this.tpgSuchen.Title = "Search";
			// 
			// searchTitle
			// 
			this.searchTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.searchTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.searchTitle.Location = new System.Drawing.Point(8, 8);
			this.searchTitle.Name = "searchTitle";
			this.searchTitle.Size = new System.Drawing.Size(800, 24);
			this.searchTitle.TabIndex = 0;
			this.searchTitle.TabStop = false;
			// 
			// KissSearchForm
			// 
			this.ClientSize = new System.Drawing.Size(840, 526);
			this.Controls.Add(this.tabControlSearch);
			this.Name = "KissSearchForm";
			this.Load += new System.EventHandler(this.KissSearchForm_Load);
			this.tabControlSearch.ResumeLayout(false);
			this.tpgSuchen.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Handles the Load event of the KissSearchForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void KissSearchForm_Load(object sender, EventArgs e)
		{
			if (this.DesignMode)
			{
				kissSearch.Dispose();
				kissSearch = null;
			}
		}

		/// <summary>
		/// Initialize Controls on Search-Tabpage
		/// </summary>
		protected virtual void NewSearch()
		{
			this.tabControlSearch.SelectTab(this.tpgSuchen);
		}

		/// <summary>
		/// When overridden in a derived class, fills the SqlQuery.
		/// </summary>
		protected virtual void RunSearch()
		{

		}

		#region KissSearch Events
		/// <summary>
		/// Handles the NewSearch event of the search control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void search_NewSearch(object sender, EventArgs e)
		{
			this.NewSearch();
		}

		/// <summary>
		/// Handles the RunSearch event of the search control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void search_RunSearch(object sender, EventArgs e)
		{
			this.RunSearch();
		}
		#endregion
	}
}
