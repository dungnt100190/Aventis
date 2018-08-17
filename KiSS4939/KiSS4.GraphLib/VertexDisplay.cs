using System.Drawing;

namespace KiSS4.GraphLib
{
	/// <summary>
	/// Base class for an object capable of displaying a <see cref="Vertex"/>.
	/// </summary>
	public abstract class VertexDisplay : DisplayItem
	{
		/// <summary>
		/// Initialize.
		/// </summary>
		public VertexDisplay(GraphDrawing gd, Vertex v) : base(gd, v)
		{
		}

		/// <summary>
		/// Gets the <see cref="Vertex"/> displayed by this item.
		/// </summary>
		public Vertex Vertex { get { return (Vertex) this.GI; } }

		/// <summary>
		/// Gets a <see cref="Hierarchy"/> representing all horizontal items.
		/// </summary>
		protected internal abstract Hierarchy Horizontal { get; }

		/// <summary>
		/// Gets a <see cref="Hierarchy"/> representing all horizontal items.
		/// </summary>
		protected internal abstract Hierarchy Vertical { get; }

		/// <summary>
		/// Gets a <see cref="Hierarchy"/> representing the space that should come before the top ports.
		/// </summary>
		public abstract Hierarchy SpaceTL { get; }

		/// <summary>
		/// Gets a <see cref="Hierarchy"/> representing the space that should come after the top ports.
		/// </summary>
		public abstract Hierarchy SpaceTR { get; }

		/// <summary>
		/// Gets a <see cref="Hierarchy"/> representing the space that should come before the bottom ports.
		/// </summary>
		public abstract Hierarchy SpaceBL { get; }

		/// <summary>
		/// Gets a <see cref="Hierarchy"/> representing the space that should come after the bottom ports.
		/// </summary>
		public abstract Hierarchy SpaceBR { get; }

		/// <summary>
		/// true, if the point in within the <see cref="Bounds"/>.
		/// </summary>
		public override sealed bool HitTest(Point p)
		{
			return this.Bounds.Contains(p);
		}

		/// <summary>
		/// Invalidates the item, causing it to be repainted.
		/// </summary>
		public override void Invalidate()
		{
			this.GD.Invalidate(this.Bounds);
		}

		/// <summary>
		/// Gets a <see cref="Rectangle"/> surrounding all items.
		/// </summary>
		public Rectangle Bounds
		{
			get
			{
				return new Rectangle(this.Horizontal.Location, this.Vertical.Location, this.Horizontal.Size, this.Vertical.Size);
			}
		}

		internal override sealed bool IntersectsWith(Rectangle r)
		{
			return this.Bounds.IntersectsWith(r);
		}



	}
}
