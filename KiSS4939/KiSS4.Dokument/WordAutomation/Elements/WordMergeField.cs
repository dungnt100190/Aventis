using System.Collections;

namespace KiSS4.Dokument.WordAutomation.Elements
{
	/// <summary>
	/// Represents a MergeField. Inherits from Element. Contains an ArrayList to store values for merging
	/// </summary>
	public class WordMergeField : Element
	{
		private string name;
		private int startIndex;
		private int endIndex;

		/// <summary>
		/// List of values.
		/// </summary>
		public ArrayList values = new ArrayList();

		/// <summary>
		/// Initializes a new instance of the <see cref="WordMergeField"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="startIndex">The start index.</param>
		/// <param name="endIndex">The end index.</param>
		public WordMergeField(string name, int startIndex, int endIndex)
		{
			this.name = name;
			this.startIndex = startIndex;
			this.endIndex = endIndex;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WordMergeField"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		public WordMergeField(string name)
		{
			this.name = name;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		/// <summary>
		/// Gets or sets the start index.
		/// </summary>
		/// <value>The start index.</value>
		public int StartIndex
		{
			get
			{
				return this.startIndex;
			}
			set
			{
				this.startIndex = value;
			}

		}

		/// <summary>
		/// Gets or sets the end index.
		/// </summary>
		/// <value>The end index.</value>
		public int EndIndex
		{
			get
			{
				return this.endIndex;
			}
			set
			{
				this.endIndex = value;
			}
		}
	}
}
