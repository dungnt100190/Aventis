using System;

namespace KiSS4.Gui.IBindingListCollection
{
	/// <summary>
	/// Indicates the collection is typed.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class TypedCollectionAttribute : Attribute
	{
		private Type UnderlyingType;

		/// <summary>
		/// Initializes a new instance of the <see cref="TypedCollectionAttribute"/> class.
		/// </summary>
		/// <param name="underlyingType">Type of the underlying.</param>
		public TypedCollectionAttribute(Type underlyingType)
		{
			UnderlyingType = underlyingType;
		}

		/// <summary>
		/// Gets the undelying type of the collection.
		/// </summary>
		/// <value>The type of the collection.</value>
		public Type CollectionType
		{
			get { return UnderlyingType; }
		}
	}
}