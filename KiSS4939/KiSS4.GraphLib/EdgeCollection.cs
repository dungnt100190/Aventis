using System;
using System.Collections;
using System.Diagnostics;

namespace KiSS4.GraphLib
{
	/// <summary>
	/// Collection of <see cref="Edge"/> objects.
	/// </summary>
	public class EdgeCollection : ICollection
	{
		private ArrayList items = new ArrayList();

		/// <summary>
		/// Gets an <see cref="Edge"/> by index.
		/// </summary>
		public Edge this[int index]
		{
			get { return (Edge) this.items[index]; }
		}

		internal void Add(Edge e)
		{
			Debug.Assert(e != null);
			Debug.Assert(!this.items.Contains(e));
			this.items.Add(e);
		}

		#region ICollection Members

		/// <summary>
		/// ICollection implementation.
		/// </summary>
		public bool IsSynchronized
		{
			get { return this.items.IsSynchronized; }
		}

		/// <summary>
		/// ICollection implementation.
		/// </summary>
		public int Count
		{
			get { return this.items.Count; }
		}

		/// <summary>
		/// ICollection implementation.
		/// </summary>
		public void CopyTo(Array array, int index)
		{
			this.items.CopyTo(array, index);
		}

		/// <summary>
		/// ICollection implementation.
		/// </summary>
		public object SyncRoot
		{
			get { return this.items.SyncRoot; }
		}

		#endregion

		#region IEnumerable Members

		/// <summary>
		/// IEnumerable implementation.
		/// </summary>
		public IEnumerator GetEnumerator()
		{
			return this.items.GetEnumerator();
		}

		#endregion
	}
}
