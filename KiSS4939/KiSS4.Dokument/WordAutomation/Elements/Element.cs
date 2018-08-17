using System.Data.SqlClient;

namespace KiSS4.Dokument.WordAutomation.Elements
{
	/// <summary>
	/// This is the base Element Class. A WordTextMark in a WordTemplate has
	/// a reference on a Element Object.
	/// </summary>
	abstract public class Element
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Element"/> class.
		/// </summary>
		/// <param name="cmd">The CMD.</param>
		public Element(SqlCommand cmd)
		{
			if(cmd != null)
			  this.Initialize(cmd) ;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Element"/> class.
		/// </summary>
		public Element()
		{
		}

		/// <summary>
		/// Init.
		/// </summary>
		/// <param name="cmd">The CMD.</param>
		protected virtual void Initialize(SqlCommand cmd)
		{
		}
	}
}
