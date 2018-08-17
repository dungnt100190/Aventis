using System;
using System.Data;

namespace KiSS4.Dokument.WordAutomation
{
	/// <summary>
	/// Helps to keep track of bookmarks stored in microsft word document.
	/// </summary>
	public class BookmarkHelper
	{
		#region Fields and Properties

		private DataTable bookmarks;
		/// <summary>
		/// Table to store bookmarks.
		/// </summary>
		public DataTable Bookmarks
		{
			get { return bookmarks; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="BookmarkHelper"/> class.
		/// </summary>
		public BookmarkHelper()
		{
			bookmarks = new DataTable();

			// --- add Columns
			bookmarks.Columns.Add("OriginalBookmark");
			bookmarks.Columns.Add("BaseBookmark");
			bookmarks.Columns.Add("Start");
			bookmarks.Columns.Add("End");
		}

		#endregion

		/// <summary>
		/// Adds the bookmark.
		/// </summary>
		/// <param name="bookmark">The bookmark to be stored.</param>
		public void AddBookmark(Word.Bookmark bookmark)
		{
			if (IsReservedBookmark(bookmark.Name))
			{
				return;
			}

			// --- cut Bookmark before '_' and dismiss rest.
			String bookmarkBasetext = bookmark.Name;
			Int32 position = bookmarkBasetext.IndexOf("_");

			if (position > 0)
			{
				bookmarkBasetext = bookmarkBasetext.Substring(0, position);
			}

			DataRow row = bookmarks.NewRow();
			row["OriginalBookmark"] = bookmark.Name;
			row["BaseBookmark"] = bookmarkBasetext;
			row["Start"] = bookmark.Start;
			row["End"] = bookmark.End;

			bookmarks.Rows.Add(row);
		}

		/// <summary>
		/// Determines whether [is reserved bookmark] [the specified bookmark base].
		/// </summary>
		/// <param name="bookmarkText">The bookmark base.</param>
		/// <returns>
		/// 	<c>true</c> if [is reserved bookmark] [the specified bookmark base]; otherwise, <c>false</c>.
		/// </returns>
		public static Boolean IsReservedBookmark(String bookmarkText)
		{
			String uppercaseText = bookmarkText.ToUpper();

				return uppercaseText.StartsWith("TEXT") ||
					uppercaseText.StartsWith("KONTROLL") ||
                    uppercaseText.StartsWith("CHECKBOX") ||
                    uppercaseText.StartsWith("CASEACOCHER") ||
					uppercaseText.StartsWith("DROPDOWN");
		}
	}
}
