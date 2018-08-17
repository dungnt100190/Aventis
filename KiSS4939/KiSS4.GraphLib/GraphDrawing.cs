using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace KiSS4.GraphLib
{
	/// <summary>
	/// A drawing for a <see cref="Graph"/>.
	/// </summary>
	public class GraphDrawing
	{
		private static readonly Size border = new Size(20, 20);

		/// <summary>
		/// Gets the distance between vertices.
		/// </summary>
		public static readonly Size VertexDistance = new Size(20, 120);

		/// <summary>
		/// Gets the control the drawing is on.
		/// </summary>
		public readonly Control Parent;
		
		/// <summary>
		/// Gets the graph for the drawing.
		/// </summary>
		public readonly Graph Graph;
		
		/// <summary>
		/// Gets a value whether this drawing is for printing.
		/// </summary>
		public readonly bool ForPrinting;

		private Hierarchy h;
		private Hierarchy v;
		private DisplayItem[] items;
		private DisplayItem selectedItem;

		/// <summary>
		/// Initialize.
		/// </summary>
		public GraphDrawing(Control parent, Graph graph, Graphics g, bool forPrinting)
		{
			this.Parent = parent;
			this.Graph = graph;
			this.ForPrinting = forPrinting;
			
			if (graph == null || graph.Count == 0)
			{
				this.items = new DisplayItem[0];
				this.h = new Hierarchy.Item(0, 0, 0);
				this.v = new Hierarchy.Item(0, 0, 0);
				return;
			}

			// create VertexDisplay objects in VDTemp
			VDTemp[] vds = new VDTemp[graph.Count];
			for (int iv = 0; iv < vds.Length; iv++)
				vds[iv] = new VDTemp(graph[iv].CreateDisplay(this, g));

			int rowCount;
			#region vertical assignment - set vds[*].Row
		{
			Debug.Assert(graph.Count > 0);
			Hierarchy.Item[] items = new Hierarchy.Item[graph.Count];
			for (int i = 0; i < items.Length; i++)
				items[i] = new Hierarchy.Item(0, 1, 0);

			Hierarchy h = items[0];
			for (int i = 1; i < items.Length; i++)
				h |= items[i];

			ArrayList s1 = new ArrayList(); // siblings
			ArrayList s2 = new ArrayList(); // siblings
			foreach (Vertex v in graph)
				foreach (Edge e in v.Successors)
					if (e.Src != e.Dst)
					{
						Hierarchy.Item src = items[e.Src.Ordinal];
						Hierarchy.Item dst = items[e.Dst.Ordinal];

						if (e.IsSymmetric && !dst.DependsOn(src) && !src.DependsOn(dst))
						{
							s1.Add(src);
							s2.Add(dst);
						}
                        else if (!src.DependsOn(dst))
                        {
                            src.DefineDependent(dst);
                        }
                        else if (!dst.DependsOn(src))
                        {
                            dst.DefineDependent(src);
                        }
					}

			// make remaining as sibling as possible
			for (int s = 0; s < s1.Count; s++)
			{
				Hierarchy.Item i1 = (Hierarchy.Item) s1[s];
				Hierarchy.Item i2 = (Hierarchy.Item) s2[s];
				Debug.Assert(i1 != i2);

				if (!i1.DependsOn(i2) && !i2.DependsOn(i1))
				{
					foreach (Hierarchy.Item item in i1.Predecessors)
						if (item != i2 && !item.DependsOn(i2))
						{
							item.DefineDependent(i2);
						}
					foreach (Hierarchy.Item item in i2.Predecessors)
						if (item != i1 && !item.DependsOn(i1))
						{
							item.DefineDependent(i1);
						}
					foreach (Hierarchy.Item item in i1.Successors)
						if (item != i2 && !i2.DependsOn(item))
						{
							i2.DefineDependent(item);
						}
					foreach (Hierarchy.Item item in i2.Successors)
						if (item != i1 && !i1.DependsOn(item))
						{
							i1.DefineDependent(item);
						}
				}
			}

			// add spreading items to start and end items
			Hierarchy.Item[] starters = h.StartItems;
			Hierarchy.Item[] enders = h.EndItems;
			foreach (Hierarchy.Item starter in starters)
			{
				Hierarchy.Item spread = new Hierarchy.Item(0, 0, int.MaxValue);
				spread.DefineDependent(starter);
			}
			foreach (Hierarchy.Item ender in enders)
			{
				Hierarchy.Item spread = new Hierarchy.Item(0, 0, int.MaxValue);
				ender.DefineDependent(spread);
			}
			h = h.Root;

			rowCount = h.Size;
			for (int i = 0; i < items.Length; i++)
				vds[i].Row = items[i].Location;

		}
			#endregion

			int colCount;
			#region horizontal assignment - set vds[*].Col
		{
			// count vertexes in rows
			int[] cols = new int[rowCount];
			for (int iv = 0; iv < vds.Length; iv++)
			{
				cols[vds[iv].Row]++; // add a column for the vd
			}

			// determine colCount
			colCount = 0;
			for (int iRow = 0; iRow < rowCount; iRow++)
				colCount = Math.Max(colCount, cols[iRow]);

			// initial placement
			int[] colIx = new int[vds.Length];
			int[] cc = new int[rowCount];
			for (int iv = 0; iv < vds.Length; iv++)
				colIx[iv] = cc[vds[iv].Row]++;

			int iterations = colCount;
			while (iterations > 0)
			{
				// calculate better position
				float[] ff = new float[vds.Length];
				for (int iv = 0; iv < vds.Length; iv++)
				{
					VDTemp vdt = vds[iv];
					Vertex v = vdt.VD.Vertex;

					float sum = 0;
					float weight = 0;
					foreach (Edge e in v.Successors)
					{
						float weight1 = 1f / (float) e.Priority;
						sum += (float) colIx[e.Dst.Ordinal] * weight1;
						weight += weight1;
					}
					foreach (Edge e in v.Predecessors)
					{
						float weight1 = 1f / (float) e.Priority;
						sum += (float) colIx[e.Src.Ordinal] * weight1;
						weight += weight1;
					}
					if (weight > 0f)
						ff[iv] = (colIx[iv] + sum / weight) / 2;
					else
						ff[iv] = colIx[iv];
				}

				// placement according to new positioning
				float[][] pos = new float[rowCount][];
				VDTemp[][] vdtCol = new VDTemp[rowCount][];
				for (int ir = 0; ir < rowCount; ir++)
				{
					pos[ir] = new float[cols[ir]];
					vdtCol[ir] = new VDTemp[cols[ir]];
				}
				cc = new int[rowCount];
				for (int iv = 0; iv < vds.Length; iv++)
				{
					int ir = vds[iv].Row;
					pos[ir][cc[ir]] = ff[iv];
					vdtCol[ir][cc[ir]] = vds[iv];
					cc[ir]++;
				}
				int[] colIxNew = new int[vds.Length];
				for (int ir = 0; ir < rowCount; ir++)
				{
					Array.Sort(pos[ir], vdtCol[ir]);

					int maxIx = colCount - 1;
					for (int ivCol = cols[ir] - 1; ivCol >= 0; ivCol--)
					{
						int iv = vdtCol[ir][ivCol].VD.Vertex.Ordinal;
						int ix = (int) (ff[iv] + 0.5f);
						if (ix < ivCol) ix = ivCol;
						else if (ix > maxIx) ix = maxIx;

						colIxNew[iv] = ix;
						maxIx = ix - 1;
					}
				}

				bool done = true;
				// if colIxNew == colIx, we're done
				for (int iv = 0; iv < vds.Length; iv++)
					if (colIxNew[iv] != colIx[iv])
					{
						done = false;
						break;
					}
				colIx = colIxNew;
				if (done)
					iterations = 0;
				else
					iterations--;
			}

			for (int iv = 0; iv < vds.Length; iv++)
				vds[iv].Col = colIx[iv];
		}
			#endregion

			VDTemp[,] grid = new VDTemp[colCount, rowCount];
			#region grid
			for(int iv = 0; iv < vds.Length; iv++)
			{
				Debug.Assert(grid[vds[iv].Col, vds[iv].Row] == null);
				grid[vds[iv].Col, vds[iv].Row] = vds[iv];
			}
			#endregion

			ArrayList[] ports = new ArrayList[colCount];
			Channel[] channelsH = new Channel[colCount];
			Channel[] channelsV = new Channel[rowCount];
			#region Channels and Ports - set vds[*].TopPorts, vds[*].BottomPorts
		{
			// horizontal
			for (int ic = 0; ic < colCount; ic++)
			{
				ports[ic] = new ArrayList();
				VDTemp top = null;
				for (int ir = 0; ir < rowCount; ir++)
					if (grid[ic, ir] != null)
					{
						VDTemp bottom = grid[ic, ir];
						ports[ic].Add(new Ports(top, bottom, 2 * ic));
						top = bottom;
					}
				if (top != null && top.Row + 1 < rowCount)
					ports[ic].Add(new Ports(top, null, 2 * ic));

				channelsH[ic] = new Channel(2 * ic + 1);
			}

			// vertical
			for (int ir = 0; ir < rowCount; ir++)
				channelsV[ir] = new Channel(3 * ir);
		}
			#endregion

			EdgeDisplay[] eds;
			#region create lines
		{
			// create EdgeDisplay items (optimal order to minimize crossings (?))
			ArrayList edges = new ArrayList();
			foreach (Vertex v in graph)
				foreach (Edge e in v.Successors)
					edges.Add(e);
			edges.Sort();

			eds = new EdgeDisplay[edges.Count];
			for (int ie = 0; ie < eds.Length; ie++)
			{
				Edge e = (Edge) edges[ie];
				VDTemp src = vds[e.Src.Ordinal];
				VDTemp dst = vds[e.Dst.Ordinal];

				Debug.WriteLine(string.Format("{0}->{1}", e.Src.Ordinal, e.Dst.Ordinal));

				bool srcBottom = src.Row < dst.Row;
				bool dstBottom = dst.Row < src.Row;
				EdgeDisplay ed = e.CreateDisplay(this, g, srcBottom, dstBottom);

				Line startLine; // to be set in ed
				int lineWidth = ed.LineWidth;

				if (src.BottomPorts != null && src.BottomPorts == dst.TopPorts || src.TopPorts != null && src.TopPorts == dst.BottomPorts) // direct
				{
					int srcChInd;
					int dstChInd;
					Channel ch;

					if (src.Row < dst.Row) // direct down
					{
						srcChInd = channelsV[src.Row].Index + 2;
						dstChInd = channelsV[dst.Row].Index + 1;
						ch = src.BottomPorts;
					}
					else // direct up
					{
						srcChInd = channelsV[src.Row].Index + 1;
						dstChInd = channelsV[dst.Row].Index + 2;
						ch = src.TopPorts;
					}

					LineTemp lt = new LineTemp(ch, srcChInd, dstChInd, lineWidth, ed.SrcHorizontal, ed.SrcVertical, srcBottom, ed.DstHorizontal, ed.DstVertical);
					startLine = lt.Line;
				}
				else
				{
					LineTemp lt;
					#region src port
				{
					int srcChInd;
					if (srcBottom)
						srcChInd = channelsV[src.Row].Index + 2;
					else
						srcChInd = channelsV[src.Row].Index + 1;

					Channel ch;
					if (src.Col > dst.Col)
					{
						if (srcBottom) ch = src.BottomPorts;
						else ch = src.TopPorts;
					}
					else
					{
						if (srcBottom) ch = src.BottomPorts;
						else ch = src.TopPorts;
					}
					lt = new LineTemp(ch, srcChInd, lineWidth, ed.SrcHorizontal, ed.SrcVertical, srcBottom);
					startLine = lt.Line;
				}
					#endregion

					#region intermediate lines
					if (Math.Abs(src.Row - dst.Row) > 1)
					{
					{
						Channel ch;
						if (srcBottom)
							ch = channelsV[src.Row + 1];
						else
							ch = channelsV[src.Row];
						lt = new LineTemp(ch, lt, lineWidth);
					}

					{
						Channel ch;
						if (src.Col > dst.Col)
							ch = channelsH[src.Col - 1];
						else
							ch = channelsH[src.Col];
						lt = new LineTemp(ch, lt, lineWidth);
					}
					}
					#endregion

					#region dst connecting line
				{
					Channel ch;
					if (dstBottom)
						ch = channelsV[dst.Row + 1];
					else
						ch = channelsV[dst.Row];
					lt = new LineTemp(ch, lt, lineWidth);
				}
					#endregion

					#region dst port
				{
					Channel ch;
					if (dst.Col > src.Col)
					{
						if (dstBottom) ch = dst.BottomPorts;
						else ch = dst.TopPorts;
					}
					else
					{
						if (dstBottom) ch = dst.BottomPorts;
						else ch = dst.TopPorts;
					}

					int dstChInd;
					if (dstBottom)
						dstChInd = channelsV[dst.Row].Index + 2;
					else
						dstChInd = channelsV[dst.Row].Index + 1;
					lt = new LineTemp(ch, dstChInd, lt, lineWidth, ed.DstHorizontal, ed.DstVertical, dstBottom);
				}
					#endregion
				}

				ed.startLine = startLine;
				eds[ie] = ed;
			}
		}
			#endregion

			#region Assembling - set this.h
		{
			Hierarchy prev;
			Hierarchy curr;

			if (!forPrinting) // left border
				prev = new Hierarchy.Item(border.Width);
			else
				prev = null;

			// columns
			for (int ic = 0; ic < colCount; ic++)
			{
				curr = null;

				// add vertexes in parallel
				for (int ir = 0; ir < rowCount; ir++)
				{
					VDTemp vdt = grid[ic, ir];
					if (vdt != null)
					{
						if (curr == null) curr = vdt.VD.Horizontal;
						else curr |= vdt.VD.Horizontal;
					}
				}

				// add ports between spaceL and spaceR
				foreach(Ports p in ports[ic])
				{
					p.GetHierarchy(); // cause lines to depend in the right order

					foreach (LineTemp lt in p)
					{
						if (lt.Line.SrcBottom)
						{
							p.Top.VD.SpaceBL.DefineDependent(lt.Line.Hierarchy);
							lt.Line.Hierarchy.DefineDependent(p.Top.VD.SpaceBR);
						}
						else
						{
							p.Bottom.VD.SpaceTL.DefineDependent(lt.Line.Hierarchy);
							lt.Line.Hierarchy.DefineDependent(p.Bottom.VD.SpaceTR);
						}
					}
				}

				if (prev != null && curr != null)
					prev.DefineDependent(curr);
				if (curr != null)
					prev = curr;

				// between columns
				if (ic + 1 < colCount) // add a spacing item between the grids
					curr = new Hierarchy.Item(VertexDistance.Width, 1);
				else
					curr = null;

				// channelH
				Hierarchy hCh = channelsH[ic].GetHierarchy();
				if (hCh != null)
				{
					if (curr == null)
						curr = hCh;
					else
						curr |= hCh;
				}

				if (curr != null && curr != null)
					prev.DefineDependent(curr);
				if (curr != null)
					prev = curr;
			}

			if (!forPrinting) // right border
			{
				curr = new Hierarchy.Item(border.Width);
				prev.DefineDependent(curr);
				prev = curr;
			}

			this.h = prev.Root;
		}
			#endregion

			#region Assembling - set this.v
		{
			Hierarchy prev;
			Hierarchy curr;

			if (!forPrinting) // top border
				prev = new Hierarchy.Item(border.Height);
			else
				prev = null;

			// rows
			for (int ir = 0; ir < rowCount; ir++)
			{
				// before row
				if (ir > 0) // add a spacing item between the grids
					curr = new Hierarchy.Item(VertexDistance.Height);
				else
					curr = null;

				// horizontal lines before row
				Hierarchy vCh = channelsV[ir].GetHierarchy();
				if (vCh != null)
				{
					if (curr != null)
						curr |= vCh;
					else
						curr = vCh;
				}

				if (prev != null && curr != null)
					prev.DefineDependent(curr);
				if (curr != null)
					prev = curr;

				// add vertex items
				curr = null;
				for (int ic = 0; ic < colCount; ic++)
				{
					VDTemp vdt = grid[ic, ir];
					if (vdt != null)
					{
						if (curr != null)
							curr |= vdt.VD.Vertical;
						else
							curr = vdt.VD.Vertical;

						// add port lines before vertex
						if (vdt.TopPorts != null)
						{
							foreach (LineTemp lt in vdt.TopPorts)
							{
								if (lt.Line.SrcV != null && !lt.Line.SrcBottom)
									lt.Line.SrcV.DefineDependent(vdt.VD.Vertical);
								if (lt.Line.DstV != null && !lt.Line.DstBottom)
									lt.Line.DstV.DefineDependent(vdt.VD.Vertical);
							}
						}

						// add port lines after vertex
						if (vdt.BottomPorts != null)
						{
							foreach (LineTemp lt in vdt.BottomPorts)
							{
								if (lt.Line.SrcV != null && lt.Line.SrcBottom)
									vdt.VD.Vertical.DefineDependent(lt.Line.SrcV);
								if (lt.Line.DstV != null && lt.Line.DstBottom)
									vdt.VD.Vertical.DefineDependent(lt.Line.DstV);
							}
						}
					}
				}

				if (prev != null && curr != null) prev.DefineDependent(curr);
				if (curr != null) prev = curr;
			}

			if (!forPrinting) // right border
			{
				curr = new Hierarchy.Item(border.Width);
				prev.DefineDependent(curr);
				prev = curr;
			}

			#region this can be commented out to minimize drawing area
			// make all verices depend on the same predecessors and vice versa
			foreach (VDTemp v1 in vds)
				foreach(VDTemp v2 in vds)
					if (v1 != v2 && v1.Row == v2.Row)
					{
						foreach (Hierarchy.Item item in v1.VD.Vertical.Predecessors)
							item.DefineDependent(v2.VD.Vertical);
						foreach (Hierarchy.Item item in v2.VD.Vertical.Predecessors)
							item.DefineDependent(v1.VD.Vertical);

						foreach (Hierarchy.Item item in v1.VD.Vertical.Successors)
							v2.VD.Vertical.DefineDependent(item);
						foreach (Hierarchy.Item item in v2.VD.Vertical.Successors)
							v1.VD.Vertical.DefineDependent(item);
					}
			#endregion

			this.v = prev.Root;
		}
			#endregion

			#region set this.items
			this.items = new DisplayItem[vds.Length  + eds.Length];
			for (int iv = 0; iv < vds.Length; iv++)
				this.items[iv] = vds[iv].VD;
			Array.Copy(eds, 0, this.items, vds.Length, eds.Length);

			#endregion

		}

		#region public members

		/// <summary>
		/// Gets the minimum size of the drawing.
		/// </summary>
		public Size MinSize
		{
			get { return new Size(this.h.MinSize, this.v.MinSize); }
		}

		/// <summary>
		/// Gets the maximum size of the drawing.
		/// </summary>
		public Size MaxSize
		{
			get { return new Size(this.h.MaxSize, this.v.MaxSize); }
		}

		/// <summary>
		/// Gets the original size of the drawing.
		/// </summary>
		public Size OrgSize
		{
			get { return new Size((int) this.h.OrgSize, (int) this.v.OrgSize); }
		}

		/// <summary>
		/// Gets or sets the location.
		/// </summary>
		public Point Location
		{
			get { return new Point(this.h.Location, this.v.Location); }
			set 
			{
				this.h.Location = value.X;
				this.v.Location = value.Y;
			}
		}

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		public Size Size
		{
			get { return new Size(this.h.Size, this.v.Size); }
			set
			{
				Size currSize = this.Size;
				
				this.h.Size = value.Width;
				this.v.Size = value.Height;

				if (this.Size != currSize && this.DrawingSizeChanged != null)
					this.DrawingSizeChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Zooms the drawing to the specified factor (absolute).
		/// </summary>
		public void Zoom(float zoomFactor)
		{
			this.Size = new Size((int) (zoomFactor * this.h.OrgSize), (int) (zoomFactor * this.v.OrgSize));
		}

		/// <summary>
		/// Gets or sets the selected <see cref="DisplayItem"/>.
		/// </summary>
		public DisplayItem SelectedItem
		{
			get { return this.selectedItem; }
			set
			{
				if (value != this.selectedItem)
				{
					// deselect
					if (this.selectedItem != null)
					{
						DisplayItem sel = this.selectedItem;
						this.selectedItem = null;
						sel.Invalidate();
					}

					int index;
					if (value != null && (index = Array.IndexOf(this.items, value)) >= 0)
					{
						this.selectedItem = value;
						value.Invalidate();

						if (index > 0) // put on top
						{
							Array.Copy(this.items, 0, this.items, 1, index);
							this.items[0] = value;
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets the <see cref="DisplayItem"/> that was created for the given <see cref="GraphItem"/>.
		/// </summary>
		public DisplayItem GetDisplayOf(GraphItem gi)
		{
			DisplayItem ret = null;
			foreach(DisplayItem di in this.items)
				if (di.GI == gi)
				{
					ret = di;
					break;
				}
			return ret;
		}

		/// <summary>
		/// Returns the <see cref="DisplayItem"/> at the specified location.
		/// </summary>
		public DisplayItem HitTest(Point p)
		{
			DisplayItem ret = null;
			foreach(DisplayItem di in this.items)
				if (di.HitTest(p))
				{
					ret = di;
					break;
				}
			return ret;
		}

		/// <summary>
		/// Occurs when the size of the drawing has changed.
		/// </summary>
		public event EventHandler DrawingSizeChanged;

		/// <summary>
		/// Paint all items.
		/// </summary>
		public void Paint(System.Windows.Forms.PaintEventArgs e)
		{
			// paint in reverse order
			for (int i = this.items.Length - 1; i >= 0; i--)
			{
				DisplayItem di = this.items[i];
				if (di.IntersectsWith(e.ClipRectangle))
					this.items[i].Paint(e);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the drawing has items within the specified rectangle.
		/// </summary>
		public bool HasContent(Rectangle r)
		{
			foreach (DisplayItem di in this.items)
				if (di.IntersectsWith(r))
					return true;
			return false;
		}

		/// <summary>
		/// Invalidate <see cref="Parent"/>.
		/// </summary>
		public void Invalidate(Rectangle rc)
		{
			if (this.Parent != null)
				this.Parent.Invalidate(rc);
		}
		#endregion

		/// <summary>
		/// A line that is part of an edge.
		/// </summary>
		internal class Line
		{
			public readonly bool IsVertical;
			public readonly Hierarchy Hierarchy;

			private readonly Hierarchy line; // the line item itself
			private readonly Hierarchy near; // before the line; orthogonal to the line
			private readonly Hierarchy far;  // after the line; orthogonal to the line

			// set if it's a src port
			private Hierarchy srcV;
			private bool srcBottom;

			// set if it's a dst port
			private Hierarchy dstV;
			private bool dstBottom;

			private Line prev;
			private Line next;

			// a src port line (not direct)
			public Line(int lineWidth, Hierarchy srcH, Hierarchy srcV, bool srcBottom) : this(lineWidth, srcH)
			{
				this.IsVertical = true;

				Hierarchy.Item i = new Hierarchy.Item(0, 0, int.MaxValue, int.MaxValue); // spread
				this.srcV = srcV | i;
				this.srcBottom = srcBottom;
				if (srcBottom)
					srcV.DefineDependent(i);
				else
					i.DefineDependent(srcV);
			}

			// a dst port line (not direct)
			public Line(int lineWidth, Line prev, Hierarchy dstH, Hierarchy dstV, bool dstBottom) : this(lineWidth, dstH)
			{
				Debug.Assert(!prev.IsVertical);

				this.IsVertical = true;

				Hierarchy.Item i = new Hierarchy.Item(0, 0, int.MaxValue, int.MaxValue); // spread
				this.dstV = dstV | i;
				this.dstBottom = dstBottom;
				if (dstBottom)
				{
					dstV.DefineDependent(i);
					i.DefineDependent(prev.line);
				}
				else
				{
					prev.line.DefineDependent(i);
					i.DefineDependent(dstV);
				}

				prev.next = this;
				this.prev = prev;
			}

			// an non-port line
			public Line(int lineWidth, Line prev) : this(lineWidth, (Hierarchy) null)
			{
				Debug.Assert(prev.next == null && prev.dstV == null);

				this.IsVertical = !prev.IsVertical;

				if (prev.srcV != null)
				{
					if (prev.srcBottom)
						prev.srcV.DefineDependent(this.line);
					else
						this.line.DefineDependent(prev.srcV);
				}

				prev.next = this;
				this.prev = prev;
			}

			// an direct line
			public Line(int lineWidth, Hierarchy srcH, Hierarchy srcV, bool srcBottom, Hierarchy dstH, Hierarchy dstV) :
				this(lineWidth, srcH | dstH)
			{
				this.IsVertical = true;

				this.srcV = srcV;
				this.srcBottom = srcBottom;
				this.dstV = dstV;
				this.dstBottom = !srcBottom;
				Hierarchy.Item i = new Hierarchy.Item(0, 0, int.MaxValue, int.MaxValue); // spread

				if (srcBottom)
				{
					srcV.DefineDependent(i);
					i.DefineDependent(dstV);
				}
				else
				{
					dstV.DefineDependent(i);
					i.DefineDependent(srcV);
				}
			}

			private Line(int lineWidth, Hierarchy far)
			{
				Hierarchy.Item before = new Hierarchy.Item(0, 0, int.MaxValue, int.MaxValue);
				Hierarchy.Item near = new Hierarchy.Item(5, 1);
				Hierarchy.Item line = new Hierarchy.Item(0, lineWidth, 0);
				if (far == null) far = new Hierarchy.Item(5);
				Hierarchy.Item after = new Hierarchy.Item(0, 0, int.MaxValue, int.MaxValue);

				before.DefineDependent(near);
				near.DefineDependent(line);
				line.DefineDependent(far);
				far.DefineDependent(after);

				this.Hierarchy = before | near | line | far | after;
				this.near = near;
				this.line = line;
				this.far = far;
			}


			public Line Next
			{
				get { return this.next; }
			}

			public Hierarchy SrcV
			{
				get { return this.srcV;}
			}

			public bool SrcBottom
			{
				get
				{
//					Debug.Assert(this.SrcV != null);
					return this.srcBottom;
				}
			}

			public Hierarchy DstV
			{
				get { return this.dstV; }
			}

			public bool DstBottom
			{
				get
				{
//					Debug.Assert(this.DstV != null);
					return this.dstBottom;
				}
			}

			public Point P0 // the point in src direction
			{
				get
				{
					Point ret;
					if (this.IsVertical)
						ret = new Point(this.line.Location + this.line.Size / 2, this.LocPrev);
					else
						ret = new Point(this.LocPrev, this.line.Location + this.line.Size / 2);
					return ret;
				}
			}

			public Point P1 // the point in dst direction
			{
				get
				{
					Point ret;
					if (this.IsVertical)
						ret = new Point(this.line.Location + this.line.Size / 2, this.LocNext);
					else
						ret = new Point(this.LocNext, this.line.Location + this.line.Size / 2);
					return ret;
				}
			}

			public Rectangle Bounds // a rectangle surrounding the line
			{
				get
				{
					Rectangle ret;
					int minLowBound = Math.Min(this.LowBoundPrev, this.LowBoundNext);
					int maxHighBound = Math.Max(this.HighBoundPrev, this.HighBoundNext);
					int size = this.far.Location + this.far.Size - this.near.Location;

					//Debug.Assert(this.near.Location + this.near.Size == this.far.Location);

					if (this.IsVertical)
						ret = new Rectangle(new Point(this.near.Location, minLowBound), new Size(size, maxHighBound - minLowBound));
					else
						ret = new Rectangle(new Point(minLowBound, this.near.Location), new Size(maxHighBound - minLowBound, size));
					return ret;
				}
			}

			private int LocPrev // location of previous
			{
				get
				{
					int ret;
					if (this.prev == null) // src
					{
						if (this.srcBottom)
							ret = this.srcV.Location;
						else
							ret = this.srcV.Location + this.srcV.Size;
					}
					else
						ret = this.prev.line.Location + this.prev.line.Size / 2;
					return ret;
				}
			}

			private int LocNext
			{
				get
				{
					int ret;
					if (this.next == null) // dst
					{
						if (this.dstBottom)
							ret = this.dstV.Location;
						else
							ret = this.dstV.Location + this.dstV.Size;
					}
					else
						ret = this.next.line.Location + this.next.line.Size / 2;
					return ret;
				}
			}

			private int LowBoundPrev
			{
				get
				{
					if (this.prev == null) // src
						return this.LocPrev;
					else
						return this.prev.near.Location;
				}
			}

			private int LowBoundNext
			{
				get
				{
					if (this.next == null) // dst
						return this.LocNext;
					else
						return this.next.near.Location;
				}
			}

			private int HighBoundPrev
			{
				get
				{
					if (this.prev == null) // src
						return this.LocPrev;
					else
						return this.prev.far.Location + this.prev.far.Size;
				}
			}

			private int HighBoundNext
			{
				get
				{
					if (this.next == null) // dst
						return this.LocNext;
					else
						return this.next.far.Location + this.next.far.Size;
				}
			}
		}

		private class VDTemp // used in the constructor; holds temporoary information for a VD
		{
			public readonly VertexDisplay VD;
			public int Col;
			public int Row;
			public Ports TopPorts;
			public Ports BottomPorts;

			public VDTemp(VertexDisplay vd)
			{
				this.VD = vd;
			}
		}

		private abstract class LineEnd // base class for a LineTemp or a Port
		{
			public abstract int ChannelIndex { get; } // gets the channel index

			public virtual int CompareTo(LineEnd le)
			{
				Debug.Assert(!(this is LineTemp)); // must be overridden by LineTemp
				int ret = this.ChannelIndex.CompareTo(le.ChannelIndex);
				Debug.Assert(ret != 0 || !(le is LineTemp)); // Port compared to LineTemp must not equal
				return ret;
			}
		}

		private class Port : LineEnd
		{
			private int channelIndex;

			public Port(int channelIndex)
			{
				this.channelIndex = channelIndex;
			}

			public override int ChannelIndex
			{
				get
				{
					return this.channelIndex;
				}
			}
		}

		private class LineTemp : LineEnd
		{
			public readonly Line Line; // the line
			public readonly Channel Channel; // the channel the line is on

			private LineEnd prev; // the previous LT
			private LineEnd next; // the next LT
			private int index = -1; // maintained by Channel
			private LineEnd low;
			private LineEnd high;
			private int bendLow;
			private int bendHigh;

			/// <summary>
			/// Src port.
			/// </summary>
			public LineTemp(Channel channel, int srcChannelIndex, int lineWidth, Hierarchy srcH, Hierarchy srcV, bool srcBottom)
			{
				this.Line = new Line(lineWidth, srcH, srcV, srcBottom);
				this.Channel = channel;

				this.prev = new Port(srcChannelIndex);
			}

			/// <summary>
			/// Dst port.
			/// </summary>
			public LineTemp(Channel channel, int dstChannelIndex, LineTemp prev, int lineWidth, Hierarchy dstH, Hierarchy dstV, bool dstBottom)
			{
				this.Line = new Line(lineWidth, prev.Line, dstH, dstV, dstBottom);
				this.Channel = channel;

				prev.next = this;
				this.prev = prev;

				this.next = new Port(dstChannelIndex);
				this.AddToChannel();
			}

			/// <summary>
			/// Non-port.
			/// </summary>
			public LineTemp(Channel channel, LineTemp prev, int lineWidth)
			{
				this.Line = new Line(lineWidth, prev.Line);
				this.Channel = channel;

				prev.next = this;
				this.prev = prev;
			}

			/// <summary>
			/// Direct.
			/// </summary>
			public LineTemp(Channel channel, int srcChannelIndex, int dstChannelIndex, int lineWidth, Hierarchy srcH, Hierarchy srcV, bool srcBottom, Hierarchy dstH, Hierarchy dstV)
			{
				this.Line = new Line(lineWidth, srcH, srcV, srcBottom, dstH, dstV);
				this.Channel = channel;

				this.prev = new Port(srcChannelIndex);
				this.next = new Port(dstChannelIndex);
				this.AddToChannel();
			}

			public override int ChannelIndex
			{
				get { return this.Channel.Index; }
			}

			public int Index
			{
				get
				{
					Debug.Assert(this.Channel.IsSorted);
					return this.index;
				}

				set // called from Channel.Sort()
				{
					this.index = value;
				}
			}
				
			public LineEnd Low
			{
				get { return this.low; }
			}

			public LineEnd High
			{
				get { return this.high; }
			}

			private void AddToChannel() // insert into channel, recurse to prev
			{
				// set low, high
				if (this.prev.ChannelIndex < this.next.ChannelIndex)
				{
					this.low = this.prev;
					this.high = this.next;
				}
				else if (this.prev.ChannelIndex > this.next.ChannelIndex)
				{
					this.low = this.next;
					this.high = this.prev;
				}
				else
					throw new ApplicationException("internal error.");

				// set bendLow, bendHigh
				int bendLow;
				if (this.low is LineTemp)
				{
					LineTemp lt = (LineTemp) this.low;
					int chIx = lt.next == this ? lt.prev.ChannelIndex : lt.next.ChannelIndex;
					if (chIx < this.ChannelIndex)
						bendLow = -1;
					else if (chIx > this.ChannelIndex)
						bendLow = +1;
					else
						throw new ApplicationException("internal error.");
				}
				else
					bendLow = 0;
				this.bendLow = bendLow;

				int bendHigh;
				if (this.high is LineTemp)
				{
					LineTemp lt = (LineTemp) this.high;
					int chIx = lt.next == this ? lt.prev.ChannelIndex : lt.next.ChannelIndex;
					if (chIx < this.ChannelIndex)
						bendHigh = -1;
					else if (chIx > this.ChannelIndex)
						bendHigh = +1;
					else
						throw new ApplicationException("internal error.");
				}
				else
					bendHigh = 0;
				this.bendHigh = bendHigh;

				// add to channel and recurse
				this.Channel.Add(this);
				if (this.prev is LineTemp)
					((LineTemp) this.prev).AddToChannel();
			}

			#region CompareTo

			public override int CompareTo(LineEnd le)
			{
				int ret = this.ChannelIndex.CompareTo(le.ChannelIndex);
				if (ret == 0)
				{
					Debug.Assert(le is LineTemp);
					ret = this.CompareTo((LineTemp) le, true, true);
				}
				return ret;
			}

			public int CompareTo(LineTemp lt, bool lowDir, bool highDir) // compare two LineTemp objects
			{
				Debug.Assert(lowDir || highDir);

				if (this.ChannelIndex < lt.ChannelIndex)
					return -1;
				if (this.ChannelIndex > lt.ChannelIndex)
					return +1;

				Debug.Assert(this.Channel == lt.Channel); // same channel index, same channel

				if (this.Channel.IsSorted)
				{
					return Channel.Compare(this, lt);
				}

				int cmpL;
				if (lowDir)
				{
					if (this.bendLow < 0)
					{
						if (lt.bendLow < 0)
							cmpL = -((LineTemp) this.low).CompareTo((LineTemp) lt.low, true, false);
						else
							cmpL = -1;
					}
					else if (this.bendLow > 0)
					{
						if (lt.bendLow > 0)
							cmpL = ((LineTemp) this.low).CompareTo((LineTemp) lt.low, false, true);
						else
							cmpL = +1;
					}
					else
						cmpL = -lt.bendLow;
				}
				else
					cmpL = 0;

				int cmpH;
				if (highDir)
				{
					if (this.bendHigh < 0)
					{
						if (lt.bendHigh < 0)
							cmpH = ((LineTemp) this.high).CompareTo((LineTemp) lt.high, true, false);
						else
							cmpH = -1;
					}
					else if (this.bendHigh > 0)
					{
						if (lt.bendHigh > 0)
							cmpH = -((LineTemp) this.high).CompareTo((LineTemp) lt.high, false, true);
						else
							cmpH = +1;
					}
					else
						cmpH = -lt.bendHigh;
				}
				else
					cmpH = 0;
				
				int ret;
				if (cmpL < 0)
					ret = cmpH > 0 ? 0 : -1;
				else if (cmpL > 0)
					ret = cmpH < 0 ? 0 : +1;
				else
					ret = cmpH;

				return ret;
			}

			#endregion
		}

		private class Channel : ICollection
		{
			public readonly int Index;

			private readonly ArrayList lts = new ArrayList();
			private int[,] compares;

			public Channel(int index)
			{
				this.Index = index;
				this.lts = new ArrayList();
			}

			public int Count
			{
				get { return this.lts.Count; }
			}

			public LineTemp this[int index]
			{
				get { return (LineTemp) this.lts[index]; }
			}

			public bool IsSorted
			{
				get { return this.compares != null; }
			}

			public void Add(LineTemp lt)
			{
				Debug.Assert(lt.Channel == this);
				Debug.Assert(!this.lts.Contains(lt));
				Debug.Assert(this.compares == null);
				lt.Index = this.lts.Count;
				this.lts.Add(lt);
			}

			public static int Compare(LineTemp lt1, LineTemp lt2)
			{
				Debug.Assert(lt1.Channel == lt2.Channel);
				Debug.Assert(lt1.Channel.IsSorted);
				
				return lt1.Channel.compares[lt1.Index, lt2.Index];
			}

			public Hierarchy GetHierarchy() // a hierarchy containing the lines in the right order
			{
				Debug.Assert(this.compares == null);

				int[,] compares = new int[this.lts.Count, this.lts.Count];

				Hierarchy ret = null;
				for (int i = 0; i < this.lts.Count; i++)
				{
					LineTemp lt = this[i];
					for (int j = 0; j < i; j++)
					{
						LineTemp lt1 = this[j];
						int cmp = lt.CompareTo(lt1, true, true);
						if (cmp < 0)
						{
							lt.Line.Hierarchy.DefineDependent(lt1.Line.Hierarchy);
							compares[i, j] = -1;
							compares[j, i] = +1;
						}
						else if (cmp > 0 || lt.High.CompareTo(lt1.Low) >= 0 && lt.Low.CompareTo(lt1.High) <= 0)
						{
							lt1.Line.Hierarchy.DefineDependent(lt.Line.Hierarchy);
							compares[i, j] = +1;
							compares[j, i] = -1;
						}
					}
					
					if (ret != null)
						ret |= lt.Line.Hierarchy;
					else
						ret = lt.Line.Hierarchy;
				}

				this.compares = compares;
				return ret;
			}

			#region IEnumerable Members

			public IEnumerator GetEnumerator()
			{
				return this.lts.GetEnumerator();
			}

			#endregion

			#region ICollection Members

			public bool IsSynchronized
			{
				get { return this.lts.IsSynchronized; }
			}

			public void CopyTo(Array array, int index)
			{
				this.lts.CopyTo(array, index);
			}

			public object SyncRoot
			{
				get { return this.lts.SyncRoot; }
			}

			#endregion
		}

		private class Ports : Channel
		{
			public readonly VDTemp Top;
			public readonly VDTemp Bottom;

			public Ports(VDTemp top, VDTemp bottom, int channelIndex) : base(channelIndex)
			{
				Debug.Assert(top != null || bottom != null);

				this.Top = top;
				this.Bottom = bottom;
				if (top != null)
					top.BottomPorts = this;
				if (bottom != null)
					bottom.TopPorts = this;
			}
		}
	}
}
