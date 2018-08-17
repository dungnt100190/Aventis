using System;
using System.Collections.Generic;
using System.Globalization;

namespace KiSS4.Common
{
	/// <summary>
	/// Implements a collection of periods. Periods can be adedd, deleted and 
	/// looked up. The behaviour of the collection can bechanged using the
	/// appropriate properties.
	/// </summary>
	public sealed class PeriodCollection
		:
		IEnumerable<Period>
	{
		#region Fields and Properties

		private Boolean keepSorted;
		/// <summary>
		/// Gets a value indicating whether the collection is sorted
		/// after all chnages. 
		/// </summary>
		/// <value><c>true</c> if [keep sorted]; otherwise, <c>false</c>.</value>
		public Boolean KeepSorted
		{
			get { return keepSorted; }
		}

		private Boolean allowOverlapping;
		/// <summary>
		/// Gets a value indicating whether overlapping periods are allowed
		/// in the collection.
		/// </summary>
		/// <value><c>true</c> if [allow overlapping]; otherwise, <c>false</c>.</value>
		public Boolean AllowOverlapping
		{
			get { return allowOverlapping; }
		}

		private Boolean allowGaps;
		/// <summary>
		/// Gets a value indicating whether gaps between periods are allowed.
		/// </summary>
		/// <value><c>true</c> if [allow gaps]; otherwise, <c>false</c>.</value>
		public Boolean AllowGaps
		{
			get { return allowGaps; }
		}

		/// <summary>
		/// Gets the number of elements in the collection.
		/// </summary>
		/// <value>The count.</value>
		public Int32 Count
		{
			get
			{
				return list.Count;
			}
		}

		/// <summary>
		/// The list of periods.
		/// </summary>
		private List<Period> list = new List<Period>();

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="PeriodCollection"/> class.
		/// </summary>
		public PeriodCollection()
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PeriodCollection"/> class.
		/// </summary>
		/// <param name="keepSorted">if set to <c>true</c> [keep sorted].</param>
		/// <param name="allowOverlapping">if set to <c>true</c> [allow overlapping].</param>
		/// <param name="allowGaps">if set to <c>true</c> [allow gaps].</param>
		public PeriodCollection(
			Boolean keepSorted,
			Boolean allowOverlapping,
			Boolean allowGaps)
		{
			this.keepSorted = keepSorted;
			this.allowOverlapping = allowOverlapping;
			this.allowGaps = allowGaps;
		}

		#endregion

		/// <summary>
		/// Adds the specified period to the collection
		/// </summary>
		/// <param name="period">The period.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public Boolean Add(Period period)
		{
			if(period == null)
			{
				throw new ArgumentNullException("period"); 
			}

			Boolean added = false;
			Boolean addable = false;

			// --- if it is the first element
			if (list.Count == 0)
			{
				addable = true;
			}
			else
			{
				Boolean adjoins = false;
				Boolean overlaps = false;

				CheckConditions(period, ref adjoins, ref overlaps);
				addable = IsAddable(overlaps, AllowOverlapping, adjoins, AllowGaps);
			}

			if (addable)
			{
				list.Add(period);

				// --- sort if required
				if (keepSorted)
				{
					list.Sort();
				}

				added = true;
			}
			else
			{
				added = false;
			}

			return added;
		}

		/// <summary>
		/// Determines whether the specified period is addable.
		/// </summary>
		/// <param name="period">The period.</param>
		/// <returns>
		/// 	<c>true</c> if the specified period is addable; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentNullException"></exception>
		public Boolean IsAddable(Period period)
		{
			if (period == null)
			{
				throw new ArgumentNullException("period");
			}

			Boolean adjoins = false;
			Boolean overlaps = false;

			return IsAddable(period, ref adjoins, ref overlaps);
		}

		/// <summary>
		/// Determines whether the specified period is addable.
		/// </summary>
		/// <param name="period">The period.</param>
		/// <param name="adjoins">if set to <c>true</c> [adjoins].</param>
		/// <param name="overlaps">if set to <c>true</c> [overlaps].</param>
		/// <returns>
		/// 	<c>true</c> if the specified period is addable; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="ArgumentNullException"></exception>
		public Boolean IsAddable(
			Period period,
			ref Boolean adjoins,
			ref Boolean overlaps)
		{
			if (period == null)
			{
				throw new ArgumentNullException("period");
			}

			Boolean addable;

			CheckConditions(period, ref adjoins, ref overlaps);

			if(list.Count == 0)
			{
				addable = true;
			}
			else
			{
				addable = IsAddable(overlaps, AllowOverlapping, adjoins, AllowGaps);
			}
			return addable;
		}

		/// <summary>
		/// Sorts the elements in the collection.
		/// </summary>
		/// <returns></returns>
		public void Sort()
		{
			list.Sort();
		}

		/// <summary>
		/// Checks the conditions.
		/// </summary>
		/// <param name="period">The period.</param>
		/// <param name="adjoins">if set to <c>true</c> [adjoins].</param>
		/// <param name="overlaps">if set to <c>true</c> [overlaps].</param>
		/// <exception cref="ArgumentNullException"></exception>
		private void CheckConditions(
			Period period,
			ref Boolean adjoins,
			ref Boolean overlaps)
		{
			if (period == null)
			{
				throw new ArgumentNullException("period");
			}

			// --- go through the list of existing elements and check which
			//     conditions aree met.
			foreach (Period p in list)
			{
				// --- check if the new period adjoins at least with one
				//     existing element.
				if (p.Adjoins(period))
				{
					adjoins = true;
				}

				// --- check if the new period overlaps with at least one
				//     existing element.
				if (p.Overlaps(period))
				{
					adjoins = true;
					overlaps = true;
				}
			}
		}

		/// <summary>
		/// Determines whether a period can be added to the list.
		/// </summary>
		/// <param name="overlaps">if set to <c>true</c> [overlaps].</param>
		/// <param name="allowOverlap">if set to <c>true</c> [allow overlap].</param>
		/// <param name="adjoins">if set to <c>true</c> [adjoins].</param>
		/// <param name="allowGaps">if set to <c>true</c> [allow gaps].</param>
		/// <returns>
		/// 	<c>true</c> if the specified overlaps is addable; otherwise, <c>false</c>.
		/// </returns>
		private static Boolean IsAddable(
			Boolean overlaps, 
			Boolean allowOverlap, 
			Boolean adjoins, 
			Boolean allowGaps)
		{
			Boolean isAddable = true;
			
			if(overlaps && !allowOverlap)
			{
				isAddable = false;
			}

			if (!adjoins && !allowGaps)
			{
				isAddable = false;
			}

			return isAddable;
		}

		#region IEnumerable<Period> Members

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"></see> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<Period> GetEnumerator()
		{
			foreach (Period p in list)
			{
				yield return p;
			}
		}

		#endregion

		#region IEnumerable Members

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
		/// </returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			foreach (Period p in list)
			{
				yield return p;
			}
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
		/// </returns>
		public override string ToString()
		{
			return String.Format(
				CultureInfo.CurrentUICulture, 
				"Collection contains {0} Periods",
				this.Count.ToString(CultureInfo.CurrentUICulture));
		}

		#endregion
	}
}
