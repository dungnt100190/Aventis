using KiSS4.DB;

namespace KiSS4.Gui
{
	/// <summary>
	/// Gui element that allows a user to manipulate (navigate, insert, add, remove) a datasource
	/// </summary>
	public partial class KissLocalNavigator : DevExpress.XtraEditors.DataNavigator
	{
		/// <summary>
		/// Initializes a new instance of the <see cref= "KiSS4.Gui.KissLocalNavigator"/> class
		/// </summary>
		public KissLocalNavigator()
		{
			InitializeComponent();
			this.ButtonClick += kissLocalNavigator_ButtonClick;
		}

		/// <summary>
		/// Sets up the default appearance
		/// Since the image indices are set at design time, we have to assign the correct indices here
		/// </summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			this.Buttons.PrevPage.Visible = false;
			this.Buttons.NextPage.Visible = false;
			this.Buttons.ImageList = KissImageList.SmallImageList;
			this.Buttons.First.ImageIndex = KissImageList.GetImageIndex(10);
			this.Buttons.Prev.ImageIndex = KissImageList.GetImageIndex(11);
			this.Buttons.Next.ImageIndex = KissImageList.GetImageIndex(13);
			this.Buttons.Last.ImageIndex = KissImageList.GetImageIndex(15);
			this.Buttons.Append.ImageIndex = KissImageList.GetImageIndex(1);
			this.Buttons.EndEdit.ImageIndex = KissImageList.GetImageIndex(2);
			this.Buttons.CancelEdit.ImageIndex = KissImageList.GetImageIndex(3);
			this.Buttons.Remove.ImageIndex = KissImageList.GetImageIndex(4);
		}


		/// <summary>
		/// Eventhandler: the user has clicked a button
		/// Invokes the corresponding method on the <see cref="KiSS4.DB.SqlQuery">SqlQuery</see>
		/// </summary>
		/// <param name="sender">The source of the event</param>
		/// <param name="e">A <see cref="DevExpress.XtraEditors.NavigatorButtonClickEventArgs">NavigatorButtonClickEventArgs</see> that contains the event data</param>
		private void kissLocalNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			SqlQuery qry = this.DataSource as SqlQuery;
			if (qry != null)
			{
				if (e.Button == Buttons.Append)
				{
					qry.Insert();
					e.Handled = true;
				}
				else if (e.Button == Buttons.Remove)
				{
					qry.Delete();
					e.Handled = true;
				}
				else if (e.Button == Buttons.EndEdit)
				{
					qry.Post();
					e.Handled = true;
				}
				else if (e.Button == Buttons.CancelEdit)
				{
					qry.Cancel();
					e.Handled = true;
				}
			}
		}
	}
}

