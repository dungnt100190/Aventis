using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace KiSS4.Gui.IBindingListCollection
{
	/// <summary>
	/// The SQL Property Descriptor.
	/// </summary>
	public class SqlPropertyDescriptor : PropertyDescriptor
	{
		/// <summary>
		/// Only way to create the PropertyDescriptor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="sqlType"></param>
		/// <returns></returns>
		public static SqlPropertyDescriptor GetProperty(string name, Type sqlType)
		{
			// we need to use the attributes of the base type
			Type baseType = sqlType.GetProperty("Value").PropertyType;
			ArrayList attribs = new ArrayList(TypeDescriptor.GetAttributes(baseType));

			Attribute[] attrs = (Attribute[])attribs.ToArray(typeof(Attribute));

			return new SqlPropertyDescriptor(name, attrs, sqlType, baseType);
		}

		private Type SqlType;
		private Type BaseType;

		/// <summary>
		/// Initializes a new instance of the <see cref="SqlPropertyDescriptor"/> class.
		/// </summary>
		/// <param name="descr">The descr.</param>
		/// <remarks>Do NOT use this!</remarks>
		protected SqlPropertyDescriptor(MemberDescriptor descr) : base(descr) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SqlPropertyDescriptor"/> class.
		/// </summary>
		/// <param name="descr">A <see cref="T:System.ComponentModel.MemberDescriptor"></see> containing the name of the member and its attributes.</param>
		/// <param name="attrs">An <see cref="T:System.Attribute"></see> array containing the attributes you want to associate with the property.</param>
		/// <remarks>Do NOT use this!</remarks>
		protected SqlPropertyDescriptor(MemberDescriptor descr, Attribute[] attrs) : base(descr, attrs) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SqlPropertyDescriptor"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="attrs">The attrs.</param>
		/// <remarks>Do NOT use this!</remarks>
		protected SqlPropertyDescriptor(string name,Attribute[] attrs) : base(name,attrs){}

		/// <summary>
		/// Initializes a new instance of the <see cref="SqlPropertyDescriptor"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="attrs">The attrs.</param>
		/// <param name="sqlType">Type of the SQL.</param>
		/// <param name="baseType">Type of the base.</param>
		/// <remarks>USE THIS!</remarks>
		protected SqlPropertyDescriptor( string name,Attribute[] attrs, Type sqlType, Type baseType ) : base(name,attrs)
		{
			SqlType = sqlType;
			BaseType = baseType;
		}

		/// <summary>
		/// Indicates whether the value can be reset.
		/// </summary>
		/// <param name="component"></param>
		/// <returns></returns>
		public override bool CanResetValue(object component) 
		{ 
			return false; 
		}

		/// <summary>
		/// Reset the value.
		/// </summary>
		/// <param name="component"></param>
		public override void ResetValue(object component)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Determines a value indicating whether the value of this property needs to be persisted.
		/// </summary>
		/// <param name="component">The component with the property to be examined for persistence.</param>
		/// <returns>
		/// true if the property should be persisted; otherwise, false.
		/// </returns>
		public override bool ShouldSerializeValue(object component)
		{
			return false;
		}

		/// <summary>
		/// When overridden in a derived class, gets the type of the component this property is bound to.
		/// </summary>
		/// <value></value>
		/// <returns>A <see cref="T:System.Type"></see> that represents the type of component this property is bound to. When the <see cref="M:System.ComponentModel.PropertyDescriptor.GetValue(System.Object)"></see> or <see cref="M:System.ComponentModel.PropertyDescriptor.SetValue(System.Object,System.Object)"></see> methods are invoked, the object specified might be an instance of this type.</returns>
		public override Type ComponentType
		{
			get { return BaseType; }
		}

		/// <summary>
		/// Gets a value indicating whether this property is read-only.
		/// </summary>
		/// <value></value>
		/// <returns>true if the property is read-only; otherwise, false.</returns>
		public override bool IsReadOnly
		{
			get { return false; }
		}

		/// <summary>
		/// Gets the type of the property.
		/// </summary>
		/// <value></value>
		/// <returns>A <see cref="T:System.Type"></see> that represents the type of the property.</returns>
		public override Type PropertyType
		{
			get { return BaseType; }
		}

		/// <summary>
		/// Sets the value of the component to a different value.
		/// </summary>
		/// <param name="component">The component with the property value that is to be set.</param>
		/// <param name="value">The new value.</param>
		public override void SetValue(object component,object value)
		{
			try
			{
				PropertyInfo pi = component.GetType().GetProperty(this.Name);
				object o;
				if ( value == DBNull.Value )
				{
					o = component.GetType().GetField("Null", BindingFlags.Static | BindingFlags.Public | BindingFlags.GetField).GetValue(component);
						
				}
				else
				{
					o = pi.PropertyType.GetConstructor(new Type[]{BaseType}).Invoke(new object[]{value});
				}
				pi.SetValue(component,o, null);
			}
			catch(Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}

		/// <summary>
		/// Gets the current value of the property on a component.
		/// </summary>
		/// <param name="component">The component with the property for which to retrieve the value.</param>
		/// <returns>
		/// The value of a property for a given component.
		/// </returns>
		public override object GetValue(object component)
		{
			try
			{
				object Property = component.GetType().GetProperty(this.Name).GetValue(component,null);

				// handle nulls
				if ( (bool)Property.GetType().GetProperty("IsNull").GetValue(Property,null) ) return DBNull.Value;

				object Value = Property.GetType().GetProperty("Value").GetValue(Property,null);
				return Value;
			}
			catch(Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return null;
		}
	}
}
