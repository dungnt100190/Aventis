using System.Drawing;

namespace KiSS4.GraphLib
{
	/// <summary>
	/// A vertex in a <see cref="Graph"/>.
	/// </summary>
	public abstract class Vertex : GraphItem
	{
		/// <summary>
		/// Gets the edges before this instance.
		/// </summary>
		public readonly EdgeCollection Predecessors = new EdgeCollection();

		/// <summary>
		/// Gets the edges after this instance.
		/// </summary>
		public readonly EdgeCollection Successors = new EdgeCollection();

		/// <summary>
		/// The ordinal number of the Vertex in the graph.
		/// </summary>
		public readonly int Ordinal;

		/// <summary>
		/// Initialize.
		/// </summary>
		public Vertex(Graph g) : base(g)
		{
			this.Ordinal = g.Count;
			g.Add(this);
		}

		/// <summary>
		/// When implememted by a class, creates a <see cref="VertexDisplay"/> instance to draw this instance.
		/// </summary>
		protected internal abstract VertexDisplay CreateDisplay(GraphDrawing gd, Graphics g);
	}
}
