using System;
using System.Drawing;
using System.Windows.Forms;

namespace KiSS4.GraphLib
{
	/// <summary>
	/// Base class for a <see cref="VertexDisplay"/> or a <see cref="EdgeDisplay"/>.
	/// </summary>
	public abstract class DisplayItem
	{
		/// <summary>
		/// Gets the <see cref="GraphDisplay"/>.
		/// </summary>
		public readonly GraphDrawing GD;

		/// <summary>
		/// Gets the <see cref="GraphItem"/> this objects displays.
		/// </summary>
		public readonly GraphItem GI;

		/// <summary>
		/// Initialize.
		/// </summary>
		public DisplayItem(GraphDrawing gd, GraphItem gi)
		{
			if (gd == null) throw new ArgumentNullException("gd");
			if (gi == null) throw new ArgumentNullException("gi");
			this.GD = gd;
			this.GI = gi;
		}

		/// <summary>
		/// Gets a value indicating whether p is within this item.
		/// </summary>
		public abstract bool HitTest(Point p);

		/// <summary>
		/// Gets a string for the tool tip at the specified location (or null).
		/// </summary>
		public abstract string ToolTipText(Point p);


		internal abstract bool IntersectsWith(Rectangle r);

		/// <summary>
		/// Paints the item.
		/// </summary>
		protected internal abstract void Paint(PaintEventArgs e);

		/// <summary>
		/// Gets a value indicating whether this item is selected.
		/// </summary>
		public bool IsSelected
		{
			get { return this.GD.SelectedItem == this; }
		}

		/// <summary>
		/// Invalidates the item, causing it to be repainted.
		/// </summary>
		public abstract void Invalidate();

		/// <summary>
		/// Called on an unhandeled KeyDown event; currently doesn't do a thing.
		/// </summary>
		/// <param name="e"></param>
		protected internal virtual void OnKeyDown(KeyEventArgs e)
		{}

		/// <summary>
		/// Called on an unhandeled Double Click event
		/// </summary>
		/// <param name="e"></param>
		public virtual void OnDoubleClick(EventArgs e)
		{}
	}
}
