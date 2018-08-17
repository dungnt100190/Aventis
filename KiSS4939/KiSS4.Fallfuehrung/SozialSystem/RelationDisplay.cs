using System.Drawing;
using System.Windows.Forms;
using KiSS4.GraphLib;

namespace KiSS4.Fallfuehrung.SozialSystem
{
	/// <summary>
	/// Object capable to paint a <see cref="Relation"/>.
	/// </summary>
	internal class RelationDisplay : EdgeDisplay
	{
		private const int lineWidth = 1;
		private const int lineWidthSel = 3;

		private readonly Hierarchy srcH;
		private readonly Hierarchy srcV;

		private readonly Hierarchy dstH;
		private readonly Hierarchy dstV;

		private readonly StringFormat sfSrc;
		private readonly StringFormat sfDst;

		private string tttSrc;
		private string tttDst;

		public RelationDisplay(GraphDrawing gd, Relation r, Graphics g, bool srcBottom, bool dstBottom) : base(gd, r)
		{
			// measure text
			Font font = new Font(PersonDisplay.FontFamily, PersonDisplay.OrigFontSize);

			this.sfSrc = new StringFormat(StringFormatFlags.NoWrap);
			this.sfSrc.Alignment = srcBottom ? StringAlignment.Near : StringAlignment.Far;
			this.sfSrc.LineAlignment = StringAlignment.Far;
			this.sfSrc.Trimming = StringTrimming.EllipsisCharacter;
			Size sSrcFull = Size.Ceiling(g.MeasureString(r.SrcText, font, int.MaxValue, this.sfSrc));
			Size sSrc = gd.ForPrinting ? sSrcFull : Size.Ceiling(g.MeasureString(r.SrcText, font, GraphDrawing.VertexDistance.Height / 2, this.sfSrc));
			this.sfSrc.FormatFlags |= StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft; // otherwise width ignored

			this.sfDst = new StringFormat(StringFormatFlags.NoWrap);
			this.sfDst.Alignment = dstBottom ? StringAlignment.Near : StringAlignment.Far;
			this.sfDst.LineAlignment = StringAlignment.Far;
			this.sfDst.Trimming = StringTrimming.EllipsisCharacter;
			Size sDstFull = Size.Ceiling(g.MeasureString(r.DstText, font, int.MaxValue, this.sfDst));
			Size sDst = this.GD.ForPrinting ? sDstFull : Size.Ceiling(g.MeasureString(r.DstText, font, GraphDrawing.VertexDistance.Height / 2, this.sfDst));
			this.sfDst.FormatFlags |= StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft; // otherwise width ignored

			this.srcH = new Hierarchy.Item(sSrc.Height + 2); this.srcH.SetTag(this.Relation.SrcText + " (H)");
			this.dstH = new Hierarchy.Item(sDst.Height + 2); this.dstH.SetTag(this.Relation.DstText + " (H)");

			// TODO: org, maxOrg
			this.srcV = new Hierarchy.Item(sSrc.Width + 2, 0, int.MaxValue, sSrcFull.Width + 2); this.srcH.SetTag(this.Relation.SrcText + " (V)");
			this.dstV = new Hierarchy.Item(sDst.Width + 2, 0, int.MaxValue, sDstFull.Width + 2); this.dstH.SetTag(this.Relation.DstText + " (V)");
		}

		public Relation Relation
		{
			get { return (Relation) this.Edge; }
		}

		public override Hierarchy SrcHorizontal
		{
			get { return this.srcH; }
		}

		public override Hierarchy SrcVertical
		{
			get { return this.srcV; }
		}

		public override Hierarchy DstHorizontal
		{
			get { return this.dstH; }
		}

		public override Hierarchy DstVertical
		{
			get { return this.dstV; }
		}

		public override int LineWidth
		{
			get { return lineWidthSel; }
		}


		protected override void Paint(PaintEventArgs e)
		{
			Relation r = (Relation) this.Edge;

			Pen pen = new Pen(Color.Black, this.IsSelected ? lineWidthSel : lineWidth);
			// pen.EndCap = LineCap.ArrowAnchor; // for testing
			base.DrawLines(e.Graphics, pen);

			float scale = this.srcH.Root.OrgSize == 0 ? 0 : (float) this.srcH.Root.Size / (float) this.srcH.Root.OrgSize;
			float fontSize = PersonDisplay.OrigFontSize * scale;
			if (fontSize > PersonDisplay.MaxFontSize) fontSize = PersonDisplay.MaxFontSize;
			if (fontSize > PersonDisplay.MinFontSize)
			{
				Font font = new Font(PersonDisplay.FontFamily, fontSize);

				// draw src text
			{
				int cf; int lf;
				Rectangle rSrc = this.SrcTextRectangle;
				e.Graphics.MeasureString(r.SrcText, font, rSrc.Size, this.sfSrc, out cf, out lf);
				this.tttSrc = cf < r.SrcText.Length || fontSize < 6 ? r.SrcText : null;
				e.Graphics.DrawString(r.SrcText, font, Brushes.Black, rSrc, this.sfSrc);
			}

			{
				int cf; int lf;
				Rectangle rDst = this.DstTextRectangle;
				e.Graphics.MeasureString(r.DstText, font, rDst.Size, this.sfDst, out cf, out lf);
				this.tttDst = cf < r.DstText.Length || fontSize < 8 ? r.DstText : null;
				e.Graphics.DrawString(this.Relation.DstText, font, Brushes.Black, rDst, this.sfDst);
			}
			}

//			e.Graphics.DrawRectangle(Pens.Green, this.SrcTextRectangle);
//			e.Graphics.DrawRectangle(Pens.Blue, this.DstTextRectangle);
		}

		public override string ToolTipText(Point p)
		{
			Rectangle r = new Rectangle(this.srcH.Location, this.srcV.Location, this.srcH.Size, this.srcV.Size);
			if (r.Contains(p)) return this.tttSrc;

			r = new Rectangle(this.dstH.Location, this.dstV.Location, this.dstH.Size, this.dstV.Size);
			if (r.Contains(p)) return this.tttDst;

			return null;
		}

		private Rectangle SrcTextRectangle
		{
			get { return new Rectangle(this.srcH.Location, this.srcV.Location, this.srcH.Size, this.srcV.Size); }
		}

		private Rectangle DstTextRectangle
		{
			get { return new Rectangle(this.dstH.Location, this.dstV.Location, this.dstH.Size, this.dstV.Size); }
		}

	}
}
