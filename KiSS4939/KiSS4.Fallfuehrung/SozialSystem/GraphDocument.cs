using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using KiSS4.GraphLib;

namespace KiSS4.Fallfuehrung.SozialSystem
{
	/// <summary>
	/// A <see cref="PrintDocument"/> showing a <see cref="Graph"/>.
	/// </summary>
	public class GraphDocument : PrintDocument
	{
		/// <summary>
		/// Gets the <see cref="Graph"/> the print document shows.
		/// </summary>
		public readonly Graph Graph;

		private GraphDrawing drawing;

		/// <summary>
		/// Initialize with a <see cref="Graph"/>.
		/// </summary>
		public GraphDocument(Graph g)
		{
			if (g == null) throw new ArgumentNullException("g");
			this.Graph = g;
		}

		/// <summary>
		/// When set, this title is printed on top of the document.
		/// </summary>
		public string Title;

		private int pageNr;
		private Page[] pages;
		private Font titleFont = new Font(FontFamily.GenericSansSerif, 18);
		private Point offset;

		/// <summary>
		/// Reset page number to 0.
		/// </summary>
		protected override void OnBeginPrint(PrintEventArgs e)
		{
			base.OnBeginPrint (e);
			this.pageNr = 0;
		}

		/// <summary>
		/// Prints the next page and sets <see cref="PrintPageEventArgs.HasMorePages"/>.
		/// </summary>
		protected override void OnPrintPage(PrintPageEventArgs e)
		{
			base.OnPrintPage (e);
			try
			{
				if (this.drawing == null)
				{
					if (this.Title != null)
					{
						Size s = Size.Ceiling(e.Graphics.MeasureString(this.Title, titleFont));
						this.offset = new Point(0, s.Height);
					}
					else
						this.offset = new Point();

					GraphDrawing gd = new GraphDrawing(null, this.Graph, e.Graphics, true);
					gd.Location = new Point();
						
					// pages
					Size pageSize = e.MarginBounds.Size;
					ArrayList al = new ArrayList();
					for (int pageV = 0; true; pageV++)
					{
						int y = pageV == 0 ? 0 : pageV * pageSize.Height - this.offset.Y;
						int height = pageV == 0 ? pageSize.Height - this.offset.Y : pageSize.Height;
						if (y >= gd.Size.Height) break;

						for (int pageH = 0; true; pageH++)
						{
							int x = pageH == 0 ? 0 : pageH * pageSize.Width - this.offset.X;
							int width = pageH == 0 ? pageSize.Width - this.offset.X : pageSize.Width;
							if (x >= gd.Size.Width) break;

							Rectangle r = new Rectangle(x, y, width, height);
							if (gd.HasContent(r))
								al.Add(new Page(pageH, pageV, r));
						}
					}
					this.pages = (Page[]) al.ToArray(typeof(Page));

					this.drawing = gd;
				}

				if (this.pageNr > this.pages.Length)
				{
					e.HasMorePages = false;
					return;
				}

				if (this.Title != null && pageNr == 0)
					e.Graphics.DrawString(this.Title, this.titleFont, Brushes.Black, e.MarginBounds.Location);

				// draw page
				Page page = this.pages[pageNr];
				Point loc = e.MarginBounds.Location;
				if (page.PageH == 0) loc.X += this.offset.X;
				if (page.PageV == 0) loc.Y += this.offset.Y;
				this.drawing.Location = new Point(loc.X - page.DrawingRectangle.X, loc.Y - page.DrawingRectangle.Y);
				Rectangle clip = new Rectangle(loc, page.DrawingRectangle.Size);
				clip.Intersect(e.MarginBounds);
				clip.Inflate(1, 1);
				GraphicsState gs = e.Graphics.Save();
				try
				{ 
					e.Graphics.SetClip(clip);
					this.drawing.Paint(new PaintEventArgs(e.Graphics, clip));
				}
				finally { e.Graphics.Restore(gs); }

				this.pageNr++;
				e.HasMorePages = this.pageNr < this.pages.Length;
			}
			catch (Exception) { e.Cancel = true; throw; }
		}
		
		private struct Page
		{
			public readonly int PageH;
			public readonly int PageV;
			public readonly Rectangle DrawingRectangle;

			public Page(int pageH, int pageV, Rectangle drawingRectangle)
			{
				this.PageH = pageH;
				this.PageV = pageV;
				this.DrawingRectangle = drawingRectangle;
			}
		}
	}
}
