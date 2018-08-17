using System.Collections;
using System.Drawing;

namespace KiSS4.GraphLib
{
	/// <summary>
	/// Base class for an edge display.
	/// </summary>
	public abstract class EdgeDisplay : DisplayItem
	{
		// set from GraphDrawing constructor
		internal GraphDrawing.Line startLine;

		/// <summary>
		/// Initialize.
		/// </summary>
		public EdgeDisplay(GraphDrawing gd, Edge e) : base(gd, e)
		{}

		/// <summary>
		/// Gets the <see cref="Edge"/> displayed by this item.
		/// </summary>
		public Edge Edge { get { return (Edge) this.GI; } }

		/// <summary>
		/// Gets the spacing after the source port. (horizontal)
		/// </summary>
		public abstract Hierarchy SrcHorizontal { get; }

		/// <summary>
		/// Gets the orig size of the source port. (vertical)
		/// </summary>
		public abstract Hierarchy SrcVertical { get; }

		/// <summary>
		/// Gets the spacing after the destination  port. (horizontal)
		/// </summary>
		public abstract Hierarchy DstHorizontal { get; }

		/// <summary>
		/// Gets the orig size of the destination port. (vertical)
		/// </summary>
		public abstract Hierarchy DstVertical { get; }

		/// <summary>
		/// Gets the line width.
		/// </summary>
		public abstract int LineWidth { get; }

		/// <summary>
		/// Gets a value indicating whether any portion of the lines intersects with the specified rectangle.
		/// </summary>
		internal override sealed bool IntersectsWith(Rectangle rect)
		{
			for (GraphDrawing.Line l = this.startLine; l != null; l = l.Next)
				if (l.Bounds.IntersectsWith(rect))
					return true;
			return false;
		}

		/// <summary>
		/// Gets a value indicating whether the point is on the edge.
		/// </summary>
		public override bool HitTest(System.Drawing.Point p)
		{
			for (GraphDrawing.Line l = this.startLine; l != null; l = l.Next)
				if (l.Bounds.Contains(p))
					return true;
			return false;
		}

		/// <summary>
		/// Invalidates the rectangle containing the edge.
		/// </summary>
		public override sealed void Invalidate()
		{
			for (GraphDrawing.Line l = this.startLine; l != null; l = l.Next)
				this.GD.Invalidate(l.Bounds);
		}

		/// <summary>
		/// Draws the line with the given pen.
		/// </summary>
		protected void DrawLines(Graphics g, Pen pen)
		{
			ArrayList al = new ArrayList();
			al.Add(this.startLine.P0);
			for (GraphDrawing.Line l = this.startLine; l != null; l = l.Next)
			{
				al.Add(l.P1);

				// g.DrawRectangle(Pens.Red, l.Bounds);
			}

			Point[] path = (Point[]) al.ToArray(typeof(Point));
			g.DrawLines(pen, path);
		}
	}
}
