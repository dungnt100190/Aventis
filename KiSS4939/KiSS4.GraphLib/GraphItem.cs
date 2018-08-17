using System;

namespace KiSS4.GraphLib
{
	/// <summary>
	/// Base class for a <see cref="Vertex"/> or <see cref="Edge"/>.
	/// </summary>
	public class GraphItem
	{
		/// <summary>
		/// Gets the <see cref="Graph"/> this item is on.
		/// </summary>
		public readonly Graph Graph;

		/// <summary>
		/// Initialize.
		/// </summary>
		public GraphItem(Graph g)
		{
			if (g == null) throw new ArgumentNullException("g");
			this.Graph = g;
		}
	}
}
