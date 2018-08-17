using System;
using System.Collections;

namespace KiSS4.Dokument.WordAutomation.Elements
{
	/// <summary>
	/// Collection of WordFields used for MailMerge
	/// </summary>
	public class WordMergeFields : ReadOnlyCollectionBase 
	{

		/// <summary>
		/// Add an WordField object to collection.
		/// </summary>
		public void Add(WordMergeField w)
		{
			if (w ==  null) throw new ArgumentNullException("log");
			this.InnerList.Add(w);
		}       

		/// <summary>
		/// Gets an item by index.
		/// </summary>
		public WordMergeField this[int index]
		{     
			get { return (WordMergeField) this.InnerList[index]; }
		}
	}
}