using System;

namespace KiSS4.Dokument.MsOfficeCommons
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class OfficeProgramControl
	{
		/// <summary>
		/// Asks the user for save changes and close document.
		/// </summary>
		internal abstract void AskUserForSaveChangesAndCloseDocument();

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="OfficeProgramControl"/> is visible.
		/// </summary>
		/// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
		public abstract Boolean Visible
		{
			get;
			set;
		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		public abstract void Save();

		/// <summary>
		/// Creates the document from template.
		/// </summary>
		/// <param name="templateFileInfo">The template file info.</param>
		/// <param name="documentFileInfo">The document file info.</param>
		internal abstract void CreateDocumentFromTemplate(
			System.IO.FileInfo templateFileInfo, 
			System.IO.FileInfo documentFileInfo);

		/// <summary>
		/// Saves as.
		/// </summary>
		/// <param name="filePath">Path where the file ist stored.</param>
		public abstract void SaveAs(
			String filePath);

		/// <summary>
		/// Closes the document.
		/// </summary>
		internal abstract void CloseDocument();

		/// <summary>
		/// Quits this instance.
		/// </summary>
		public abstract void Quit();

		/// <summary>
		/// Opens the specified file.
		/// </summary>
		/// <param name="filePath">The path of the file.</param>
		/// <param name="isTemplate">if set to <c>true</c> [is template].</param>
		/// <param name="makeVisible">if set to <c>true</c> [make visible].</param>
		/// <param name="resetProtection">if set to <c>true</c> [reset protection].</param>
		internal abstract void Open(
			String filePath, 
			Boolean isTemplate, 
			Boolean makeVisible, 
			Boolean resetProtection);
	}
}
