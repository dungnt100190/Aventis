using System;
using System.Drawing;

namespace KiSS4.GraphLib
{
	/// <summary>
	/// An edge connecting two vertex objects.
	/// </summary>
	public abstract class Edge : GraphItem, IComparable
	{
		/// <summary>
		/// Gets the <see cref="Vertex"/> where this edge starts.
		/// </summary>
		public readonly Vertex Src;

		/// <summary>
		/// Gets the <see cref="Vertex"/> where this edge ends.
		/// </summary>
		public readonly Vertex Dst;

		/// <summary>
		/// Gets a value indicating whether the edge is symmetric.
		/// </summary>
		public readonly bool IsSymmetric;

		/// <summary>
		/// Gets a value indicating the prioirty (the lower, the closer the vert).
		/// </summary>
		public readonly int Priority;

		/// <summary>
		/// Initialize by connecting two vertices.
		/// </summary>
		public Edge(Vertex src, Vertex dst, bool isSymmetric, int priority) : base(src.Graph)
		{
			if (src == null) throw new ArgumentNullException("src");
			if (dst == null) throw new ArgumentNullException("dst");
			if (src == dst) throw new ArgumentException("Reflexive edges not supported.");
			if (src.Graph != dst.Graph) throw new ArgumentException("src, dst not on same Graph.");

			this.Src = src;
			this.Dst = dst;
			this.IsSymmetric = isSymmetric;
			this.Priority = priority;

			src.Successors.Add(this);
			dst.Predecessors.Add(this);
		}

		/// <summary>
		/// When implemented by a class, creates a <see cref="EdgeDisplay"/> item.
		/// </summary>
		protected internal abstract EdgeDisplay CreateDisplay(GraphDrawing gd, Graphics g, bool srcBottom, bool dstBottom);

		#region IComparable Members

		/// <summary>
		/// Supports sorting by min(src.ordinal, dst.ordinal), max(src.ordinal, dst.ordinal)
		/// </summary>
		public int CompareTo(object obj)
		{
			Edge other = (Edge) obj;

			int minThis = Math.Min(this.Src.Ordinal, this.Dst.Ordinal);
			int minOther = Math.Min(other.Src.Ordinal, other.Dst.Ordinal);

			if (minThis < minOther) return -1;
			if (minThis > minOther) return +1;

			int maxThis = Math.Max(this.Src.Ordinal, this.Dst.Ordinal);
			int maxOther = Math.Max(other.Src.Ordinal, other.Dst.Ordinal);

			return maxThis.CompareTo(maxOther);
		}

		#endregion

	}
}
