using System;
using System.ComponentModel;
using KiSS4.DB;

namespace KiSS4.Common
{
	/// <summary>
	/// Summary description for KissReferenzNrEdit.
	/// </summary>
	public class KissReferenzNrEdit : KiSS4.Gui.KissTextEdit, IKissBindableEdit
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Initializes a new instance of the <see cref="KissReferenzNrEdit"/> class.
		/// </summary>
		/// <param name="container">The container.</param>
		public KissReferenzNrEdit(System.ComponentModel.IContainer container)
		{
			//
			// Required for Windows.Forms Class Composition Designer support
			//
			container.Add(this);

			InitializeComponent();

			this.Properties.Appearance.Options.UseTextOptions = true;
			this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

			this.EditValueChanged += new EventHandler(KissReferenzNrEdit_EditValueChanged);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="KissReferenzNrEdit"/> class.
		/// </summary>
		public KissReferenzNrEdit()
		{
			//
			// Required for Windows.Forms Class Composition Designer support
			//
			InitializeComponent();

			this.Properties.Appearance.Options.UseTextOptions = true;
			this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

			this.EditValueChanged += new EventHandler(KissReferenzNrEdit_EditValueChanged);
		}

		/// <summary>
		/// Formats this instance.
		/// </summary>
		public void Format()
		{
			string temp = this.Text.Replace(" ", "");
			int count = 0;

			for (int i = temp.Length - 1; i >= 0; i--)
			{
				count++;
				if (count == 5)
				{
					temp = temp.Insert(i, " ");
					count = 0;
				}
			}

			this.Text = temp;
			this.Select(this.Text.Length, 0);
		}

		/// <summary>
		/// Raises the <see cref="E:Leave"/> event.
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			this.Format();
		}

		/// <summary>
		/// Validates the referenz nummer.
		/// </summary>
		/// <param name="EsrTeilnehmerNr">The esr teilnehmer nr.</param>
		/// <returns></returns>
		public bool ValidateReferenzNummer(string EsrTeilnehmerNr)
		{
			// Speziell Fall (ESR 5 Positionen)
			if (EsrTeilnehmerNr.Length == 5)
			{
				if (this.ReferenzNummer.Length != 15)
				{
					KissMsg.ShowInfo("KissReferenzNrEdit", "RefNrZuKurz", "Referenz Nummer muss 15 Positionen lang sein");
					return false;
				}
			}

			// Standart 9 Positionen ESR Teilnehmer
			else
			{
				if (this.ReferenzNummer.Length != 27 && this.ReferenzNummer.Length != 16)
				{
					KissMsg.ShowInfo("KissReferenzNrEdit", "RefNrNichtOK", "Referenz Nummer muss 16 oder 27 Positionen sein");
					return false;
				}

				else if (!Utils.CheckMod10Nummer(this.ReferenzNummer))
				{
					KissMsg.ShowInfo("KissReferenzNrEdit", "RefNrFalsch", "Referenz Nummer falsch, die Prüfziffer stimmt nicht");
					return false;
				}
			}
			return true;
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
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Gets or sets the referenz nummer.
		/// </summary>
		/// <value>The referenz nummer.</value>
		[DefaultValue("")]
		public string ReferenzNummer
		{
			get
			{
				if (DesignMode && DataSource != null && DataMember != "") return string.Empty;
				return this.Text.Trim().Replace(" ", "");
			}
			set
			{
				this.Text = value;
			}
		}

		/// <summary>
		/// Gets the name of the bindable property.
		/// </summary>
		/// <returns></returns>
		/// <remarks>Replace default binding Property, Value is saved unformated in the Database</remarks>
		string IKissBindableEdit.GetBindablePropertyName()
		{
			return "EditValueRefNr";
		}

		/// <summary>
		/// Bindingproperty. Unformated Value to save in Database
		/// </summary>
		/// <value>The edit value ref nr.</value>
		[DefaultValue(null)]
		public object EditValueRefNr
		{
			get
			{
				if (DesignMode && DataSource != null && DataMember != "") return null;

				if (DBUtil.IsEmpty(this.EditValue))
					return this.EditValue;
				else
					return this.ReferenzNummer;
			}
			set
			{
				this.EditValue = value;
				this.Format();
			}
		}

		/// <summary>
		/// Occurs when [edit value ref nr changed].
		/// </summary>
		public event System.EventHandler EditValueRefNrChanged;

		/// <summary>
		/// Called when [edit value ref nr changed].
		/// </summary>
		protected virtual void OnEditValueRefNrChanged()
		{
			if (EditValueRefNrChanged != null)
				EditValueRefNrChanged(this, EventArgs.Empty);
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		/// <summary>
		/// Handles the EditValueChanged event of the KissReferenzNrEdit control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void KissReferenzNrEdit_EditValueChanged(object sender, EventArgs e)
		{
			this.OnEditValueRefNrChanged();
		}
	}
}
