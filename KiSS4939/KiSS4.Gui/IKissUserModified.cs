using System.ComponentModel;

namespace KiSS4.Gui
{
	/*
    /// <summary>
	/// 
	/// </summary>
	public interface IKissUserModified
	{
		/// <summary>
		/// Value was modified by User
		/// </summary>
		bool UserModified { get; set;}

		/// <summary>
		/// Restore last Value
		/// </summary>
		void CancelEdit();
	}
    */

	/// <summary>
	/// 
	/// </summary>
	public class UserModifiedFldEventArgs : CancelEventArgs
	{
		bool buttonClicked;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ButtonClicked"></param>
		public UserModifiedFldEventArgs(bool ButtonClicked)
		{
			this.buttonClicked = ButtonClicked;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ButtonClicked"></param>
		/// <param name="Cancel"></param>
		public UserModifiedFldEventArgs(bool ButtonClicked, bool Cancel)
			: base(Cancel)
		{
			this.buttonClicked = ButtonClicked;
		}

		/// <summary>
		/// Indicates whether the button was clicked.
		/// </summary>
		public bool ButtonClicked
		{
			get { return buttonClicked; }
		}
	}

	/// <summary>
	/// Raised when the User changed the EditValue and leaves the Control.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void UserModifiedFldEventHandler(object sender, UserModifiedFldEventArgs e);
}