using System.Collections;
using System.ComponentModel;
using System.Data;
using KiSS4.DB;

namespace KiSS4.Gui.Designer
{
	/// <summary>
	/// Helper class to offer only the defined contexts in a dropdown list in the property grid
	/// </summary>
	class HyperlinkContextConverter : StringConverter
	{
		/// <summary>
		/// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
		/// <returns>
		/// true if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"></see> should be called to find a common set of values the object supports; otherwise, false.
		/// </returns>
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			//true means show a combobox
			return Session.Active;
		}

		/// <summary>
		/// Returns whether the collection of standard values returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"></see> is an exclusive list of possible values, using the specified context.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
		/// <returns>
		/// true if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"></see> returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"></see> is an exhaustive list of possible values; false if other values are possible.
		/// </returns>
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			//true will limit to list. false will show the list, 
			//but allow free-form entry
			return Session.Active;
		}

		/// <summary>
		/// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
		/// <returns>
		/// A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"></see> that holds a standard set of valid values, or null if the data type does not support a standard set of values.
		/// </returns>
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			ArrayList availableContexts = new ArrayList();
			if (Session.Active)
			{
				SqlQuery qry = DBUtil.OpenSQL("SELECT Name FROM XHyperlinkContext");
				foreach (DataRow row in qry.DataTable.Rows)
				{
					availableContexts.Add(row["Name"] as string);					
				}
			}
			return new StandardValuesCollection(availableContexts);
		}
	}
}
