using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace KiSS4.Gui.IBindingListCollection
{
	/// <summary>
	/// We use array list so we dont have to write all those
	/// boring methods ( Count, Add(), RemoveAt() ...)
	/// </summary>
	//[TypedCollection(typeof(this))]
	public class IBindingListCollection : ArrayList, IBindingList, ITypedList
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IBindingListCollection"/> class.
		/// </summary>
		/// <param name="type">The type.</param>
		public IBindingListCollection(Type type)
		{
			this.finalType = type;			
		}

		/// <summary>
		/// Searches the specified property name.
		/// </summary>
		/// <param name="PropertyName">Name of the property.</param>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public int Search(string PropertyName, object value)
		{
			// Creates a new collection and assign it the properties for button1.
			// PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.finalType, (TypedCollectionAttribute[])this.GetType().GetCustomAttributes(typeof(TypedCollectionAttribute),false));
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this[0]) ;

			// Sets an PropertyDescriptor to the specific property.
			System.ComponentModel.PropertyDescriptor myProperty = properties.Find(PropertyName, true);
			
			int found = ((IBindingList)this).Find(myProperty, value) ;
			return found ;
		}

		/// <summary>
		/// The type inside the collection
		/// </summary>
		private Type finalType = null;

		#region IBindingList

		private ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
		private ListChangedEventHandler onListChanged;

		/// <summary>
		/// Raises the <see cref="E:ListChanged"/> event.
		/// </summary>
		/// <param name="ev">The <see cref="System.ComponentModel.ListChangedEventArgs"/> instance containing the event data.</param>
		protected virtual void OnListChanged(ListChangedEventArgs ev) 
		{
			if (onListChanged != null) 
			{
				onListChanged(this, ev);
			}
		}

		/// <summary>
		/// Occurs when the list changes or an item in the list changes.
		/// </summary>
		event ListChangedEventHandler IBindingList.ListChanged 
		{
			add 
			{
				onListChanged += value;
			}
			remove 
			{
				onListChanged -= value;
			}
		}

		/// <summary>
		/// Gets whether you can update items in the list.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can update the items in the list; otherwise, false.</returns>
		bool IBindingList.AllowEdit 
		{ 
			get { return true ; }
		}

		/// <summary>
		/// Gets whether you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>; otherwise, false.</returns>
		bool IBindingList.AllowNew 
		{ 
			get { return true ; }
		}

		/// <summary>
		/// Gets whether you can remove items from the list, using <see cref="M:System.Collections.IList.Remove(System.Object)"></see> or <see cref="M:System.Collections.IList.RemoveAt(System.Int32)"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can remove items from the list; otherwise, false.</returns>
		bool IBindingList.AllowRemove 
		{ 
			get { return true ; }
		}

		/// <summary>
		/// Gets whether a <see cref="E:System.ComponentModel.IBindingList.ListChanged"></see> event is raised when the list changes or an item in the list changes.
		/// </summary>
		/// <value></value>
		/// <returns>true if a <see cref="E:System.ComponentModel.IBindingList.ListChanged"></see> event is raised when the list changes or when an item changes; otherwise, false.</returns>
		bool IBindingList.SupportsChangeNotification 
		{ 
			get { return false ; }
		}


		/// <summary>
		/// Gets whether the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)"></see> method.
		/// </summary>
		/// <value></value>
		/// <returns>true if the list supports searching using the <see cref="M:System.ComponentModel.IBindingList.Find(System.ComponentModel.PropertyDescriptor,System.Object)"></see> method; otherwise, false.</returns>
		bool IBindingList.SupportsSearching 
		{ 
			get { return true ; }
		}

		/// <summary>
		/// Gets whether the list supports sorting.
		/// </summary>
		/// <value></value>
		/// <returns>true if the list supports sorting; otherwise, false.</returns>
		bool IBindingList.SupportsSorting 
		{ 
			get { return true ; }
		}

		/// <summary>
		/// Adds a new item to the list.
		/// </summary>
		/// <returns>The item added to the list.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.AllowNew"></see> is false. </exception>
		object IBindingList.AddNew() 
		{
			return finalType.GetConstructor(new Type[]{}).Invoke(null);
		}

		private bool isSorted;

		/// <summary>
		/// Gets whether the items in the list are sorted.
		/// </summary>
		/// <value></value>
		/// <returns>true if <see cref="M:System.ComponentModel.IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor,System.ComponentModel.ListSortDirection)"></see> has been called and <see cref="M:System.ComponentModel.IBindingList.RemoveSort"></see> has not been called; otherwise, false.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		bool IBindingList.IsSorted 
		{ 
			get { return isSorted; }
		}

		private ListSortDirection listSortDirection = ListSortDirection.Ascending;

		/// <summary>
		/// Gets the direction of the sort.
		/// </summary>
		/// <value></value>
		/// <returns>One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		ListSortDirection IBindingList.SortDirection 
		{ 
			get { return listSortDirection; }
		}

		PropertyDescriptor sortProperty;

		/// <summary>
		/// Gets the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting.
		/// </summary>
		/// <value></value>
		/// <returns>The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that is being used for sorting.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		PropertyDescriptor IBindingList.SortProperty 
		{ 
			get { return sortProperty; }
		}

		/// <summary>
		/// Adds the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to the indexes used for searching.
		/// </summary>
		/// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to add to the indexes used for searching.</param>
		void IBindingList.AddIndex(PropertyDescriptor property) 
		{
			isSorted = true;
			sortProperty = property;
		}

		/// <summary>
		/// Sorts the list based on a <see cref="T:System.ComponentModel.PropertyDescriptor"></see> and a <see cref="T:System.ComponentModel.ListSortDirection"></see>.
		/// </summary>
		/// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to sort by.</param>
		/// <param name="direction">One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values.</param>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction) 
		{
			isSorted = true;
			sortProperty = property;
			listSortDirection = direction;

			ArrayList a = new ArrayList();

			this.Sort( new ObjectPropertyComparer(property.Name));
			if (direction == ListSortDirection.Descending) this.Reverse();
		}

		/// <summary>
		/// Returns the index of the row that has the given <see cref="T:System.ComponentModel.PropertyDescriptor"></see>.
		/// </summary>
		/// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to search on.</param>
		/// <param name="key">The value of the property parameter to search for.</param>
		/// <returns>
		/// The index of the row that has the given <see cref="T:System.ComponentModel.PropertyDescriptor"></see>.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSearching"></see> is false. </exception>
		int IBindingList.Find(PropertyDescriptor property, object key) 
		{
			foreach( object o in this)
			{
				if ( Match( finalType.GetProperty(property.Name).GetValue(o,null), key) ) 
					return this.IndexOf(o);
			}
			return -1;
		}

		/// <summary>
		/// Removes the <see cref="T:System.ComponentModel.PropertyDescriptor"></see> from the indexes used for searching.
		/// </summary>
		/// <param name="property">The <see cref="T:System.ComponentModel.PropertyDescriptor"></see> to remove from the indexes used for searching.</param>
		void IBindingList.RemoveIndex(PropertyDescriptor property) 
		{
			sortProperty = null;
		}

		/// <summary>
		/// Removes any sort applied using <see cref="M:System.ComponentModel.IBindingList.ApplySort(System.ComponentModel.PropertyDescriptor,System.ComponentModel.ListSortDirection)"></see>.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> is false. </exception>
		void IBindingList.RemoveSort() 
		{
			isSorted = false;
			sortProperty = null;
		}

		#endregion

		#region ITypedList
		/// <summary>
		/// Returns the <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the properties on each item used to bind data.
		/// </summary>
		/// <param name="listAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects to find in the collection as bindable. This can be null.</param>
		/// <returns>
		/// The <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that represents the properties on each item used to bind data.
		/// </returns>
		PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
		{
			ArrayList input = null ;
			ArrayList output = new ArrayList();

			if ( listAccessors != null && listAccessors.Length > 0)
			{
				// if an listAccessors is suppled, we return the 
				// properties for the LAST one - dont ask me why - 
				// I found it in the sourse code for 
				// DataView.ITypedList.GetItemProperties using a 
				// decompiler

				PropertyDescriptor childProperty = listAccessors[listAccessors.Length - 1];

				Type t = null;

				foreach ( Attribute a in childProperty.Attributes )
				{
					if ( a is TypedCollectionAttribute )
					{
						t = ((TypedCollectionAttribute)a).CollectionType;
						break;
					}
				}

				if ( t != null )
					input = new ArrayList(TypeDescriptor.GetProperties(t));
			}
			else
			{
				input = new ArrayList(TypeDescriptor.GetProperties(finalType));
			}

			return GetPropertyDescriptorCollection(input);
		}

		/// <summary>
		/// Returns the name of the list.
		/// </summary>
		/// <param name="listAccessors">An array of <see cref="T:System.ComponentModel.PropertyDescriptor"></see> objects, for which the list name is returned. This can be null.</param>
		/// <returns>The name of the list.</returns>
		string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
		{
			string name = "";

			if ( listAccessors != null )
			{
				foreach ( PropertyDescriptor p in listAccessors )
				{
					name += p.PropertyType.Name + "_";
				}
				name = name.TrimEnd('_');
			}
			else
				name = this.GetType().Name;

			return name;
		}
		#endregion

		#region Helper functions

		/// <summary>
		/// Gets the property descriptor collection.
		/// </summary>
		/// <param name="properties">The properties.</param>
		/// <returns></returns>
		protected PropertyDescriptorCollection GetPropertyDescriptorCollection( ArrayList properties )
		{
			if ( properties == null || properties.Count == 0 )
				return new PropertyDescriptorCollection(null);

			ArrayList output = new ArrayList();

			foreach ( PropertyDescriptor p in properties )
			{
				if ( p.Attributes.Matches(new Attribute[]{new BindableAttribute(false)}) ) continue;

				if ( p.PropertyType.Namespace == "System.Data.SqlTypes" )
				{
					// create the base type property descriptor
					output.Add(SqlPropertyDescriptor.GetProperty( p.Name, p.PropertyType ) );
				}
				else
				{
					output.Add(p);
				}
			}
			return new PropertyDescriptorCollection((PropertyDescriptor[])output.ToArray(typeof(PropertyDescriptor)));
		}

		/// <summary>
		/// Matches the specified data.
		/// </summary>
		/// <param name="data">The data.</param>
		/// <param name="searchValue">The search value.</param>
		/// <returns></returns>
		protected bool Match( object data, object searchValue )
		{
			// handle nulls
			if ( data == null || searchValue == null )
			{
				return (bool)(data == searchValue);
			}

			// if its a string, our comparisons should be 
			// case insensitive.
			bool IsString = (bool)(data is string);
			bool IsDateTime = (bool)(data is DateTime) ;

			// if data type is DateTime, try to cast searchValue into DateTime
			System.IFormatProvider provider = new CultureInfo( "de-CH", false ).DateTimeFormat ;

			if(data.GetType() == typeof(System.DateTime))
				searchValue = DateTime.Parse(searchValue.ToString(), provider) ;

			// bit of validation b4 we start...
			if ( data.GetType() != searchValue.GetType() )
				throw new ArgumentException("Objects must be of the same type");

			if ( ! (data.GetType().IsValueType || data is string ) )
				throw new ArgumentException("Objects must be a value type");

			

			/*
			 * Less than zero a is less than b. 
			 * Zero a equals b. 
			 * Greater than zero a is greater than b. 
			 */

			if ( IsString )
			{
				string stringData = ((string)data).ToLower(CultureInfo.CurrentCulture);
				string stringMatch = ((string)searchValue).ToLower(CultureInfo.CurrentCulture);

				return (bool)(stringData == stringMatch);			
			}	
			else if( IsDateTime)
			{
				DateTime dateTimeData = ((DateTime)data) ;
				DateTime dateTimeMatch = ((DateTime)searchValue) ;
				DateTime correctedDateTimeData = new DateTime(dateTimeData.Year, dateTimeData.Month, dateTimeData.Day, dateTimeMatch.Hour, dateTimeMatch.Minute, dateTimeMatch.Second, dateTimeMatch.Millisecond) ;
				data = correctedDateTimeData ;

				return (bool) (correctedDateTimeData == (DateTime)searchValue) ;
			}
			else 
			{
				return (bool)(Comparer.Default.Compare(data, searchValue) == 0 );			
			}
		}

		#endregion
	}
}

