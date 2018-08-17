using System;
using System.Collections;
using System.Diagnostics;

namespace KiSS4.GraphLib
{
	/// <summary>
	/// A graph consisting of <see cref="Vertex"/> and <see cref="Edge"/> objects.
	/// </summary>
	/// <remarks>A graph basically is a collection of <see cref="Vertex"/> objects.</remarks>
	public class Graph : ICollection
	{
		private ArrayList items = new ArrayList();

		/// <summary>
		/// Gets the <see cref="Vertex"/> at the specified index.
		/// </summary>
		public Vertex this[int index]
		{
			get { return (Vertex) this.items[index]; }
		}

		internal void Add(Vertex v)
		{
			Debug.Assert(v != null);
			Debug.Assert(!this.items.Contains(v));
			this.items.Add(v);
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
