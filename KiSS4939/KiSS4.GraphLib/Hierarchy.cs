using System;
using System.Collections;
using System.Diagnostics;

namespace KiSS4.GraphLib
{
	/// <summary>
	/// A hierarchy of dependent items.
	/// </summary>
	public class Hierarchy
	{
		// variables for roots and non-roots
		private Item[] items;
		private Item[] startItems;
		private Item[] endItems;

		// variables for roots only
		private bool needsSort; // set when dependencies change
		private bool needsDistribute; // set when scale changes

		// variables for items and roots
		private int orgSize;
		private int minSize;
		private int maxSize;
		private int size;
		private int location;

		private Hierarchy(int dummy) // called from the item constructor or from operator |
		{
			// it's in the responsability of the caller to make sure that
			// - the items are non-null and distinct
			// - are sorted or needsSort is true
			// - needsDistribute is set accordingly
			// - have the same root
		}

		private Hierarchy(Hierarchy h1, Hierarchy h2) // two different roots to combine to a new root
		{
			Debug.Assert(h1 != h2 && h1.IsRoot && h2.IsRoot);

			this.items = new Item[h1.items.Length + h2.items.Length];
			Array.Copy(h1.items, this.items, h1.items.Length);
			Array.Copy(h2.items, 0, this.items, h1.items.Length, h2.items.Length);

			foreach (Item i in this.items)
				i.root = this;

			this.needsSort = true;
			this.needsDistribute = true;
		}

		#region public properties

		/// <summary>
		/// Gets a value indicating whether this instance is a root hierarchy.
		/// </summary>
		public bool IsRoot
		{
			get { return this.items[0].root == this; }
		}

		/// <summary>
		/// Gets the root hierarchy of this instance.
		/// </summary>
		/// <value>this instance, if it's a root hierarchy, or the hierarchy containing the items of this instance.</value>
		public Hierarchy Root
		{
			get { return this.items[0].root; }
		}

		/// <summary>
		/// Gets the original size.
		/// </summary>
		/// <remarks>
		/// <p>
		/// For an item: gets the item's original size set in the constructor.
		/// Items are scaled proportionally to this value, but always between <see cref="MinSize"/> and
		/// <see cref="MaxSize"/>.
		/// </p>
		/// <p>
		/// For a root hierarchy: Gets the <see cref="Size"/> corresponding to all items having the <see cref="OrgSize"/> of 1.
		/// </p>
		/// </remarks>
		/// <exception cref="InvalidOperationException">Non-root hierarchy has no OrgSize.</exception>
		public int OrgSize
		{
			get
			{
				if (this is Item) return this.orgSize;
				if (!this.IsRoot) throw new InvalidOperationException("Non-root hierarchy has no OrgSize.");
				this.Sort();
				return this.orgSize;
			}
		}

		/// <summary>
		/// Gets the minimum size.
		/// </summary>
		/// <remarks>
		/// <p>
		/// For an item: gets the item's minimum size set in the constructor. The item will never have a size
		/// less than this value.
		/// </p>
		/// <p>For a root hierarchy: Gets the minimum size calculated from the items.</p>
		/// </remarks>
		/// <exception cref="InvalidOperationException">Non-root hierarchy has no MinSize.</exception>
		public int MinSize
		{
			get
			{
				if (this is Item) return this.minSize;
				if (!this.IsRoot) throw new InvalidOperationException("Non-root hierarchy has no MinSize.");
				this.Sort();
				return this.minSize;
			}
		}

		/// <summary>
		/// Gets the maximum size.
		/// </summary>
		/// <remarks>
		/// <p>
		/// For an item: gets the item's maximum size set in the constructor. If it's less than the
		/// <see cref="MinSize"/>, <see cref="MinSize"/> takes precedence.
		/// </p>
		/// <p>For a root hierarchy: Gets the maximum size calculated from the items.</p>
		/// </remarks>
		/// <exception cref="InvalidOperationException">Non-root hierarchy has no MaxSize.</exception>
		public int MaxSize
		{
			get
			{
				if (this is Item) return this.maxSize;
				if (!this.IsRoot) throw new InvalidOperationException("Non-root hierarchy has no MaxSize.");
				this.Sort();
				return this.maxSize;
			}
		}

		/// <summary>
		/// Gets or sets the location of the hierarchy.
		/// </summary>
		/// <remarks>If not a root: gets the minimum location of all items.</remarks>
		/// <exception cref="InvalidOperationException">Can't set Location on a non-root hierarchy.</exception>
		public int Location
		{
			get
			{ 
				if (this.IsRoot) return this.location;

				this.Root.Distribute();
				if (this is Item) // a non-root item
					return this.location;

				int ret = this.items[0].location;
				for(int i = 1; i < this.items.Length; i++)
					ret = Math.Min(ret, this.items[i].location);

				return ret;
			}
			
			set
			{
				if (!this.IsRoot) throw new InvalidOperationException("Can't set Location on a non-root hierarchy.");

				int offs = value - this.location;
				if (offs != 0)
				{
					this.location = value;
					if (!(this is Item) && !this.needsDistribute) // relocate items
						foreach (Item i in this.items)
							i.location += offs;
				}
			}
		}

		/// <summary>
		/// Gets or sets the actual size of the hierarchy.
		/// </summary>
		/// <remarks>If not a root, returns the span between all items in this instance.</remarks>
		/// <exception cref="InvalidOperationException">Can't set Size on a non-root hierarchy.</exception>
		public int Size
		{
			get
			{
				if (this is Item) return this.size;

				this.Root.Distribute();
				if (this.IsRoot) return this.size;

				int minLoc = this.items[0].location;
				int maxLocSize = this.items[0].location + this.items[0].size;
				for (int i = 1; i < this.items.Length; i++)
				{
					minLoc = Math.Min(minLoc, this.items[i].location);
					maxLocSize = Math.Max(maxLocSize, this.items[i].location + this.items[i].size);
				}
				return maxLocSize - minLoc;
			}

			set
			{
				if (!this.IsRoot) throw new InvalidOperationException("Can't set Size on a non-root hierarchy.");

				// trim
				if (value > this.MaxSize) value = this.MaxSize;
				if (value < this.MinSize) value = this.MinSize;

				if (value != this.size)
				{
					this.size = value;
					this.needsDistribute = !(this is Item);
				}
			}
		}

		#endregion

		#region items

		/// <summary>
		/// Gets all the items of this hierarchy.
		/// </summary>
		public Item[] GetItems()
		{
			return (Item[]) this.items.Clone();
		}

		#endregion

		#region sort and distribute

		private void Sort()
		{
			Debug.Assert(this.IsRoot & !(this is Item));

			if (!this.needsSort) return;
			this.needsSort = false;

			// needsSort implies the following conditions
			Debug.Assert(this.needsDistribute);
			Debug.Assert(this.startItems == null);
			Debug.Assert(this.endItems == null);

			#region sort so that each item comes before it's successors and after it's predecessors
			for (int i = 0; i < this.items.Length; i++)
			{
				Item item = this.items[i];

				// find minimum position of successors at index lower than i
				int pos = i;
				foreach (Item s in item.succ)
				{
					int posS = Array.IndexOf(this.items, s, 0, i);
					if (posS >= 0) // there's a successor before i
						pos = Math.Min(pos, posS);
				}
				if (pos < i) // there's a successor before i
				{
					// exchange
					this.items[i] = this.items[pos];
					this.items[pos] = item;

					i = pos; // this caused grey hair: restart search after pos, not i!!
				}
				this.items[i].index = i;
			}
			#endregion

			double[] scales; // ascending scale factors leading to min and max values of items
			int[] totSizes; // corresponding total size for each scale factor
			#region scales, totSizes
		{
			// distinct scales
			ArrayList alScales = new ArrayList();
			for (int i = 0; i < this.items.Length; i++)
			{
				Item item = this.items[i];

				if (item.orgSize > 0)
				{
					double scale;
					int ind;

					// min
					scale = (double) item.minSize / (double) item.orgSize;
					ind = alScales.BinarySearch(scale);
					if (ind < 0) alScales.Insert(~ind, scale);

					// max
					if (item.maxSize > item.minSize)
					{
						scale = (double) item.maxSize / (double) item.orgSize;
						ind = alScales.BinarySearch(scale);
						if (ind < 0) alScales.Insert(~ind, scale);
					}
				}
			}
			if (alScales.Count == 0) // all orgSizes 0
				alScales.Add(1d); // dummy

			ArrayList alTotSizes = new ArrayList();
			for (int s = 0; s < alScales.Count; s++)
			{
				double scale = (double) alScales[s];
				long totSize = this.TotSize(scale);

				if (totSize > int.MaxValue) // this scale is too big
				{
					if (s == 0)
						throw new ApplicationException("MinSize of items are too big.");

					while (totSize > int.MaxValue) // should iteratie once, but because of rounding errors...
					{
						double scalePrev = (double) alScales[s-1];
						long totSizePrev = (long) (int) alTotSizes[s-1];

						scale = scalePrev + (scale - scalePrev) * ((double) (int.MaxValue - totSizePrev) / (double) (totSize - totSizePrev));
						scale--; // else can lead to infinite loops
						totSize = this.TotSize(scale);
					}

					alScales[s] = scale; // replace scale with a scale leading to int.MaxValue
					
					alScales.RemoveRange(s + 1, alScales.Count - (s + 1)); // remove remaining scales
				}

				if (s > 0 && (long) (int) alTotSizes[s-1] >= totSize) // previous scale leads to same tot size
				{
					// remove previous scale
					alScales.RemoveAt(s - 1);
					s--;
				}
				else // add totSize
				{
					Debug.Assert(s == 0 || (int) alTotSizes[s-1] < totSize);
					alTotSizes.Add((int) totSize);
				}
			}

			scales = (double[]) alScales.ToArray(typeof(double));
			totSizes = (int[]) alTotSizes.ToArray(typeof(int));

			Debug.Assert(scales.Length > 0 && scales.Length == totSizes.Length);
		}
			#endregion

			#region // set distOffs and distSize; minSize, maxSize, orgSize
		{
			ArrayList[] xOffsets = new ArrayList[items.Length];
			ArrayList[] yOffsets = new ArrayList[items.Length];
			ArrayList[] xSizes = new ArrayList[items.Length];
			ArrayList[] ySizes = new ArrayList[items.Length];
			for (int i = 0; i < this.items.Length; i++)
			{
				xOffsets[i] = new ArrayList(scales.Length);
				yOffsets[i] = new ArrayList(scales.Length);
				xSizes[i] = new ArrayList(scales.Length);
				ySizes[i] = new ArrayList(scales.Length);
			}

			for (int s = 0; s < scales.Length; s++)
			{
				int[] offsets;
				int[] sizes;

				this.Distribute(scales[s], out offsets, out sizes);

				for (int i = 0; i < this.items.Length; i++)
				{
					int count;

					// offsets
					count = xOffsets[i].Count;
					if (count <= 1)
					{
						xOffsets[i].Add(totSizes[s]);
						yOffsets[i].Add(offsets[i]);
					}
					else
					{
						int x0 = totSizes[s];
						int x1 = (int) xOffsets[i][count-1];
						int x2 = (int) xOffsets[i][count-2];
						int y0 = offsets[i];
						int y1 = (int) yOffsets[i][count-1];
						int y2 = (int) yOffsets[i][count-2];
						double slope1 = (double) (y1 - y2) / (double) (x1 - x2);
						double slope2 = (double) (y0 - y2) / (double) (x0 - x2);

						if (slope1 == slope2) // replace
						{
							xOffsets[i][count-1] = x0;
							yOffsets[i][count-1] = y0;
						}
						else // add
						{
							xOffsets[i].Add(x0);
							yOffsets[i].Add(y0);
						}
					}

					// sizes
					count = xSizes[i].Count;
					if (count <= 1)
					{
						xSizes[i].Add(totSizes[s]);
						ySizes[i].Add(sizes[i]);
					}
					else
					{
						int x0 = totSizes[s];
						int x1 = (int) xSizes[i][count-1];
						int x2 = (int) xSizes[i][count-2];
						int y0 = sizes[i];
						int y1 = (int) ySizes[i][count-1];
						int y2 = (int) ySizes[i][count-2];
						double slope1 = (double) (y1 - y2) / (double) (x1 - x2);
						double slope2 = (double) (y0 - y2) / (double) (x0 - x2);

						if (slope1 == slope2) // replace
						{
							xSizes[i][count-1] = x0;
							ySizes[i][count-1] = y0;
						}
						else // add
						{
							xSizes[i].Add(x0);
							ySizes[i].Add(y0);
						}
					}
				}
			}

			// set distribution functions
			for (int i = 0; i < this.items.Length; i++)
			{
				Item item = this.items[i];
				item.offsDist = new DistFunct((int[]) xOffsets[i].ToArray(typeof(int)), (int[]) yOffsets[i].ToArray(typeof(int)));
				item.sizeDist = new DistFunct((int[]) xSizes[i].ToArray(typeof(int)), (int[]) ySizes[i].ToArray(typeof(int)));
			}

			// set min, max, org
			this.minSize = totSizes[0];
			this.maxSize = totSizes[totSizes.Length - 1];
			long org = this.TotSize(1);
			if (org > this.maxSize) org = this.maxSize;
			if (org < this.minSize) org = this.minSize;
			this.orgSize = (int) org;
			this.size = this.orgSize;
		}
			#endregion
		}

		private long TotSize(double scale) // calc tot size for a given scale (long)
		{
			Debug.Assert(this.IsRoot && !this.needsSort);

			long[] sizes = new long[this.items.Length];
			long[] offsets = new long[this.items.Length];
			long totSize = 0;

			for (int i = 0; i < this.items.Length; i++)
			{
				Item item = this.items[i];
				
				// size
				long size = checked((long) (scale * item.orgSize + 0.5));
				if (size > item.maxSize) size = item.maxSize;
				if (size < item.minSize) size = item.minSize;
				sizes[i] = size;

				// offset
				long offset = 0;
				foreach (Item p in item.pred)
				{
					Debug.Assert(p.index < i);
					offset = Math.Max(offset, checked(offsets[p.index] + sizes[p.index]));
				}
				offsets[i] = offset;

				// totSize
				totSize = Math.Max(totSize, checked(offset + size));
			}

			return totSize;
		}

		private void Distribute(double scale, out int[] offsets, out int[] sizes) // distribute items for a given scale
		{
			Debug.Assert(this.IsRoot && !this.needsSort);

			// forward: sizes, maxSizes, offsets, totSize
			sizes = new int[this.items.Length];
			int[] maxSizes = new int[this.items.Length];
			offsets = new int[this.items.Length];
			int totSize = 0;
			for (int i = 0; i < this.items.Length; i++)
			{
				Item item = this.items[i];

				// sizes[i]
				int size = checked((int) (scale * item.orgSize + 0.5)); // scaled size
				if (size > item.maxSize) size = item.maxSize;
				if (size < item.minSize) size = item.minSize;
				sizes[i] = size;

				// maxSizes[i]
                int maxSize = int.MaxValue;
                if (item.MaxOrgSize > item.orgSize)
                {
                    if (item.MaxOrgSize == int.MaxValue)
                        maxSize = int.MaxValue;
                    else
                    {
                        double maxSizeDouble = (scale * item.MaxOrgSize + 0.5);
                        if (maxSizeDouble < int.MaxValue)
                            maxSize = checked((int)maxSizeDouble); // scaled max size
                    }
                    if (maxSize > item.maxSize) maxSize = item.maxSize;
                    if (maxSize < item.minSize) maxSize = item.minSize;
                    Debug.Assert(maxSize >= size);
                }
                else
					maxSize = size;
				maxSizes[i] = maxSize;

				// offsets[i]
				int offset = 0;
				foreach (Item p in item.pred)
				{
					Debug.Assert(p.index < i);
					offset = Math.Max(offset, offsets[p.index] + sizes[p.index]);
				}
				offsets[i] = offset;

				// totSize
				totSize = Math.Max(totSize, offset + size);
			}

			SpareSize[] spares = new SpareSize[this.items.Length];

			while (true)
			{
				// backward: spare sizes
				bool quit = true;
				for (int i = this.items.Length - 1; i >= 0; i--)
				{
					Item item = this.items[i];
					int far = offsets[i] + sizes[i];

					// combine successors
					SpareSize spare = new SpareSize();
					if (item.succ.Count == 0) // end item
						spare.Spare = totSize - far;
					else
					{
						spare.Spare = int.MaxValue;

						foreach (Item s in item.succ)
						{
							Debug.Assert(s.index > i);
							Debug.Assert(offsets[s.index] >= far);
							SpareSize spareSucc = spares[s.index];

							// spare size: min(space from item to successor + spare of successor)
							spare.Spare = Math.Min(spare.Spare, offsets[s.index] - far + spareSucc.Spare);

							if (spare.Spare > 0)
							{
								// distribution values: max of all
								spare.OrgCount = Math.Max(spare.OrgCount, spareSucc.OrgCount);
								spare.Org0Count = Math.Max(spare.Org0Count, spareSucc.Org0Count);
								spare.OversizeCount = Math.Max(spare.OversizeCount, spareSucc.OversizeCount);
							}
							else
							{
								spare.OrgCount = 0;
								spare.Org0Count = 0;
								spare.OversizeCount = 0;
								break;
							}
						}
					}

					if (spare.Spare > 0) // add distribution value for item
					{
						quit = false; // there is spare size to distribute

						if (sizes[i] < maxSizes[i])
						{
							if (item.orgSize > 0)
								spare.OrgCount++;
							else
								spare.Org0Count++;
						}
						else
							spare.OversizeCount++;
					}

					spares[i] = spare;
				}
				if (quit) break;

				// forward: increase sizes
				for (int i = 0; i < this.items.Length; i++)
				{
					Item item = this.items[i];
					SpareSize spare = spares[i];

					// calculate offset and new spare as the total of the predecessors
					int offset = 0;
					foreach (Item p in item.pred)
					{
						Debug.Assert(p.index < i);

						offset = Math.Max(offset, offsets[p.index] + sizes[p.index]);

						SpareSize sparePred = spares[p.index];
						spare.OrgCount = Math.Max(spare.OrgCount, sparePred.OrgCount);
						spare.Org0Count = Math.Max(spare.Org0Count, sparePred.Org0Count);
						spare.OversizeCount = Math.Max(spare.OversizeCount, sparePred.OversizeCount);
					}

					// adjust spare size
					Debug.Assert(offset >= offsets[i]);
					int maxIncr = spare.Spare - (offset - offsets[i]);
					Debug.Assert(spare.Spare - maxIncr >= 0);

					offsets[i] = offset;
					spares[i] = spare;

					if (spare.Spare > 0)
					{
						int incr;
						if (sizes[i] < maxSizes[i])
						{
							if (item.orgSize > 0)
								incr = Math.Max(1, spare.Spare / spare.OrgCount);
							else if (spare.OrgCount > 0)
								incr = 0;
							else
								incr = Math.Max(1, spare.Spare / spare.Org0Count);
							incr = Math.Min(incr, maxIncr);
							sizes[i] += Math.Min(incr, maxSizes[i] - sizes[i]);
						}
						else
						{
							if (spare.OrgCount > 0 || spare.Org0Count > 0)
								incr = 0;
							else
								incr = Math.Max(1, spare.Spare / spare.OversizeCount);
							incr = Math.Min(incr, maxIncr);
							sizes[i] += incr;
						}
					}
				}
			}

			// center
			for (int i = 0; i < this.items.Length; i++)
			{
				if (sizes[i] > maxSizes[i])
				{
					offsets[i] += (sizes[i] - maxSizes[i]) / 2;
					sizes[i] = maxSizes[i];
				}
			}
		}

		private struct SpareSize // controls the spare size distribution of an item
		{
			public int Spare;			// spare size to distribute
			public int OrgCount;		// number of items < max size and orgSize > 0
			public int Org0Count;		// number of items < max size and orgSize == 0
			public int OversizeCount;	// number of items with max size
		}

		private void Distribute()
		{
			Debug.Assert(this.IsRoot & !(this is Item));

			this.Sort();

			if (!this.needsDistribute) return;
			this.needsDistribute = false;

			for (int i = 0; i < this.items.Length; i++)
			{
				Item item = this.items[i];
				item.location = checked(this.location + item.offsDist[this.size]);
				item.size = item.sizeDist[this.size];
			}
		}

		#endregion

		#region operator |, DefineDependent

		/// <summary>
		/// Make all items in the specified hierarchies be on the same root.
		/// </summary>
		/// <returns>A <see cref="Hierarchy"/> containing all items of h1 and h2.</returns>
		public static Hierarchy operator |(Hierarchy h1, Hierarchy h2)
		{
			if (h1 == null) throw new ArgumentNullException("h1");
			if (h2 == null) throw new ArgumentNullException("h2");

			Hierarchy ret;
			if (h1 == h2)
				ret = h1;
			else if (h1.IsRoot && h2.IsRoot)
				ret = new Hierarchy(h1, h2);
			else if (h1.Root == h2.Root) // on same root, but not both root
			{
				if (h1.IsRoot)
					ret = h1;
				else if (h2.IsRoot)
					ret = h2;

				else
				{

					// combine h1.items and h2.items to a new Hierarchy (non-root)
					ArrayList al = new ArrayList(h1.items);
					foreach (Item i in h2.items)
						if (!al.Contains(i))
							al.Add(i);
				
					ret = new Hierarchy(0);
					ret.items = (Item[]) al.ToArray(typeof(Item));
				}
			}
			else // on different roots; items are distinct
			{
				new Hierarchy(h1.Root, h2.Root); // create new root

				// items = h1.items and h2.items
				Item[] items = new Item[h1.items.Length + h2.items.Length];
				Array.Copy(h1.items, items, h1.items.Length);
				Array.Copy(h2.items, 0, items, h1.items.Length, h2.items.Length);

				ret = new Hierarchy(0);
				ret.items = items;
			}

			return ret;
		}

		/// <summary>
		/// Make all items of h depend on all items of this instance.
		/// </summary>
		public void DefineDependent(Hierarchy h)
		{
			if (h == null) throw new ArgumentNullException("h");

			ICollection endItems = this.GetEndItems(); Debug.Assert(endItems.Count > 0);
			ICollection startItems = h.GetStartItems(); Debug.Assert(startItems.Count > 0);
			bool changed;

			if (this.Root != h.Root) // on different roots -> no circular depenedencies possible
			{
				new Hierarchy(this.Root, h.Root);

				foreach (Item end in endItems)
					end.succ.AddRange(startItems);

				foreach (Item start in startItems)
					start.pred.AddRange(endItems);

				changed = true;
			}
			else // on same root
			{
				// check
				if (this.IsRoot || h.IsRoot) throw new InvalidOperationException("Circular dependencies.");
				foreach(Item end in endItems)
					foreach(Item start in startItems)
						if (start == end || end.DependsOn(start))
							throw new InvalidOperationException("Circular dependencies.");

				changed = false;
				foreach (Item end in endItems)
					foreach(Item start in startItems)
						changed |= end.DefDep(start);
			}

			if (changed)
			{
				this.Root.needsSort = true;
				this.Root.needsDistribute = true;
				this.Root.startItems = null;
				this.Root.endItems = null;
			}
		}

		#endregion

		#region start, end items; succ, pred

		private Item[] GetStartItems()
		{
			if (this.startItems == null)
			{

				ArrayList al = new ArrayList();
				if (this.IsRoot) // all items with no predecessors
				{
					foreach (Item i in this.items)
						if (i.pred.Count == 0)
							al.Add(i);
				}
				else // all items with no predecessor in this.items
				{
					foreach (Item i in this.items)
					{
						bool ok = true;
						foreach (Item p in i.pred)
							if (Array.IndexOf(this.items, p) >= 0)
							{
								ok = false;
								break;
							}
						if (ok) al.Add(i);
					}
				}
				this.startItems = (Item[]) al.ToArray(typeof(Item));
				Debug.Assert(this.startItems.Length > 0);
			}

			return this.startItems;
		}

		private Item[] GetEndItems()
		{
			if (this.endItems == null)
			{
				ArrayList al = new ArrayList();
				if (this.IsRoot) // all items with no successors
				{
					foreach (Item i in this.items)
						if (i.succ.Count == 0)
							al.Add(i);
				}
				else // all items with no successor in this.items
				{
					foreach (Item i in this.items)
					{
						bool ok = true;
						foreach (Item s in i.succ)
							if (Array.IndexOf(this.items, s) >= 0)
							{
								ok = false;
								break;
							}
						if (ok) al.Add(i);
					}
				}
				this.endItems = (Item[]) al.ToArray(typeof(Item));
				Debug.Assert(this.endItems.Length > 0);
			}

			return this.endItems;
		}

		/// <summary>
		/// Gets the items which do not have predecessors within this instance.
		/// </summary>
		public Item[] StartItems
		{
			get { return (Item[]) this.GetStartItems().Clone(); }
		}

		/// <summary>
		/// Gets the items which do not have successors within this instance.
		/// </summary>
		public Item[] EndItems
		{
			get { return (Item[]) this.GetEndItems().Clone(); }
		}

		/// <summary>
		/// Gets the items which are successors of the <see cref="EndItems"/>.
		/// </summary>
		public Item[] Successors
		{
			get
			{
				if (this.IsRoot) return new Item[0];
				
				ArrayList al = new ArrayList();
				foreach (Item i in this.GetEndItems())
					foreach (Item s in i.succ)
						if (!al.Contains(s))
							al.Add(s);

				return (Item[]) al.ToArray(typeof(Item));
			}
		}

		/// <summary>
		/// Gets the items which are predecessors of the <see cref="StartItems"/>.
		/// </summary>
		public Item[] Predecessors
		{
			get
			{
				if (this.IsRoot) return new Item[0];

				ArrayList al = new ArrayList();
				foreach (Item i in this.GetStartItems())
					foreach (Item p in i.pred)
						if (!al.Contains(p))
							al.Add(p);

				return (Item[]) al.ToArray(typeof(Item));
			}
		}

		#endregion

		#region debugging
#if (DEBUG)
		private string tag;

		/// <summary>
		/// DEBUG only: returns the text set by <see cref="SetTag"/>; otherwise the base implementation.
		/// </summary>
		public override string ToString()
		{
			return this.tag == null ? base.ToString () : this.tag;
		}

#endif
		/// <summary>
		/// DEBUG only: Sets a string identifying this instance.
		/// </summary>
		[Conditional("DEBUG")]
		public void SetTag(string value)
		{
#if (DEBUG)
			this.tag = value;
#endif
		}

		#endregion

		/// <summary>
		/// An item in a hierarchy.
		/// </summary>
		public class Item : Hierarchy
		{
			/// <summary>
			/// Gets the maximum scaled original the item can get.
			/// </summary>
			public readonly int MaxOrgSize;
			
			internal Hierarchy root;
			internal ArrayList succ = new ArrayList();
			internal ArrayList pred = new ArrayList();
			internal DistFunct offsDist;
			internal DistFunct sizeDist;
			internal int index; // within root when sorted;

			private bool called; // recursion control

			#region constructors
			/// <summary>
			/// Equivalent to Item(orgSize, 0, int.MaxValue, 0)
			/// </summary>
			public Item(int orgSize) :
				this(orgSize, 0, int.MaxValue, 0)
			{}

			/// <summary>
			/// Equivalent to Item(orgSize, minSize, int.MaxValue, 0)
			/// </summary>
			public Item(int orgSize, int minSize) :
				this(orgSize, minSize, int.MaxValue, 0)
			{}

			/// <summary>
			/// Equivalent to Item(orgSize, minSize, maxSize, 0)
			/// </summary>
			public Item(int orgSize, int minSize, int maxSize) :
				this(orgSize, minSize, maxSize, 0)
			{}

			/// <summary>
			/// Initialize.
			/// </summary>
			/// <param name="orgSize">Initial value for the <see cref="OrgSize"/> property.</param>
			/// <param name="minSize">Initial value for the <see cref="MinSize"/> property.</param>
			/// <param name="maxSize">Initial value for the <see cref="MaxSize"/> property.</param>
			/// <param name="maxOrgSize">Initial value for the <see cref="MaxOrgSize"/> property.</param>
			public Item(int orgSize, int minSize, int maxSize, int maxOrgSize) : base(0)
			{
				if (orgSize < 0) throw new ArgumentOutOfRangeException("orgSize", "Is negative.");
				if (minSize < 0) throw new ArgumentOutOfRangeException("minSize", "Is negative.");
				if (maxSize < 0) throw new ArgumentOutOfRangeException("maxSize", "Is negative.");
				if (maxOrgSize < 0) throw new ArgumentOutOfRangeException("maxOrgSize", "Is negative.");

				this.orgSize = orgSize;
				this.minSize = minSize;
				this.maxSize = maxSize;
				this.MaxOrgSize = maxOrgSize;

				this.items = new Item[] { this };
				this.root = this;
				this.Size = orgSize;
			}

			#endregion

			#region dependencies

			internal bool DefDep(Item i) // add without checks; return changed flag
			{
				Debug.Assert(i.root == this.root && i != this && !this.DependsOn(i));

				bool ret = false;
				if (!i.DependsOn(this))
				{
					// remove any redundant dependencies
					ArrayList subs = new ArrayList();
					i.AddSucc(subs);
					i.ResetCalled();

					foreach (Item item in this.root.items)
						if (this == item || this.DependsOn(item))
							foreach(Item sub in subs)
								if (item.succ.Contains(sub))
								{
									item.succ.Remove(sub);
									sub.pred.Remove(item);
								}

					// add desired dependecy
					this.succ.Add(i);
					i.pred.Add(this);
					ret = true;
				}

				return ret;
			}

			private void ResetCalled() // must be called after a recursive method
			{
				if (this.called)
				{
					this.called = false;
					if (this.succ != null)
						foreach (Item succ in this.succ)
							succ.ResetCalled();
				}
			}

			/// <summary>
			/// Gets a value indicating whether this instance depends on the specified item.
			/// </summary>
			public bool DependsOn(Item i)
			{
				if (i == null) throw new ArgumentNullException("i");
				
				if (i == this) return false;
				if (i.root != this.root) return false;
				
				bool ret = i.Contains(this);
				i.ResetCalled();
				return ret;
			}

			private bool Contains(Item i)
			{
				if (this.called) return false;
				this.called = true;

				if (i == this) return true;

				foreach (Item s in this.succ)
					if (s.Contains(i))
						return true;
				return false;
			}

			private void AddSucc(IList list) // add this and all successors to the list
			{
				if (this.called) return;
				this.called = true;

				Debug.Assert(!list.Contains(this));
				list.Add(this);

				foreach (Item s in this.succ)
					s.AddSucc(list);
			}

			#endregion

		}

		internal class DistFunct
		{
			private int[] x;
			private int[] y;

			public DistFunct(int[] x, int[] y)
			{
#if (DEBUG)
				Debug.Assert(x.Length > 0 && x.Length == y.Length);

				// monotonic
				for (int i = 1; i < x.Length; i++)
				{
					Debug.Assert(x[i-1] < x[i]);
				}

				// different slopes
				for (int i = 2; i < x.Length; i++)
				{
					double slope1 = (double) (y[i-1] - y[i-2]) / (double) (x[i-1] - x[i-2]);
					double slope2 = (double) (y[i] - y[i-2]) / (double) (x[i] - x[i-2]);
					Debug.Assert(slope1 != slope2);
				}
#endif
				this.x = x;
				this.y = y;
			}

			public int this[int x]
			{
				get
				{
					int i = Array.BinarySearch(this.x, x);
					if (i >= 0) return this.y[i];

					i = ~i;
					return this.y[i-1] + (int) ((double) (this.y[i] - this.y[i-1]) * ((double) (x - this.x[i-1]) / (double) (this.x[i] - this.x[i-1])) + 0.5);
				}
			}
		}
	}
}
