using System;
using KiSS4.GraphLib;

namespace KiSS4.Fallfuehrung.SozialSystem
{
	/// <summary>
	/// A relation between <see cref="Person"/>s.
	/// </summary>
	public class Relation : Edge
	{
		public readonly string SrcText;
		public readonly string DstText;

		public Relation(Person src, string srcText, Person dst, string dstText, bool isSymmetric, int priority) : base(src, dst, isSymmetric, priority)
		{
			if (srcText == null) throw new ArgumentNullException("srcText");
			if (dstText == null) throw new ArgumentNullException("dstText");
			this.SrcText = srcText;
			this.DstText = dstText;
		}

		protected override EdgeDisplay CreateDisplay(GraphDrawing gd, System.Drawing.Graphics g, bool srcBottom, bool dstBottom)
		{
			return new RelationDisplay(gd, this, g, srcBottom, dstBottom);
		}

	}
}
