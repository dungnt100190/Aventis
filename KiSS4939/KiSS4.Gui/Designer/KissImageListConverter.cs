using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;

namespace KiSS4.Gui.Designer
{
	class KissImageListConverter : ImageIndexConverter
	{
		/// <summary>
		/// Determines if the type converter supports a standard set of values that can be picked from a list.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context, which can be used to extract additional information about the environment this type converter is being invoked from. This parameter or properties of this parameter can be null.</param>
		/// <returns>
		/// true if the <see cref="System.Windows.Forms.ImageIndexConverter.GetStandardValues"></see> method returns a standard set of values; otherwise, false. Always returns true.
		/// </returns>
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			ImageList imgList = KissImageList.SmallImageList;
			return true;
		}


		/// <summary>
		/// Determines if the list of standard values returned from the <see cref="System.Windows.Forms.ImageIndexConverter.GetStandardValues"></see> method is an exclusive list.
		/// </summary>
		/// <param name="context">A formatter context.</param>
		/// <returns>
		/// true if the <see cref="System.Windows.Forms.ImageIndexConverter.GetStandardValues"></see> method returns an exclusive list of valid values; otherwise, false. This implementation always returns false.
		/// </returns>
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return false;
		}

		/// <summary>
		/// Converts the specified value object to a 32-bit signed integer object.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context.</param>
		/// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"></see> to provide locale information.</param>
		/// <param name="value">The <see cref="T:System.Object"></see> to convert.</param>
		/// <returns>
		/// An <see cref="T:System.Object"></see> that represents the converted value.
		/// </returns>
		/// <exception cref="T:System.Exception">The conversion could not be performed. </exception>
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				if (((string)value) != "(none)" && ((string)value) != "")
				{
					try
					{
						return Int32.Parse(((string)value));
					}
					catch
					{
						return -1;
					}
				}
				else
					return -1;
			}
			else
				return null;
		}

		/// <summary>
		/// Converts the specified object to the specified destination type.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context, which can be used to extract additional information about the environment this type converter is being invoked from. This parameter or properties of this parameter can be null.</param>
		/// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"></see> that provides locale information.</param>
		/// <param name="value">The object to convert, typically an index represented as an <see cref="T:System.Int32"></see>.</param>
		/// <param name="destinationType">The type to convert the object to, often a <see cref="T:System.String"></see>.</param>
		/// <returns>
		/// An <see cref="T:System.Object"></see> that represents the converted value.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">The destinationType is null. </exception>
		/// <exception cref="T:System.NotSupportedException">The specified value could not be converted to the specified destinationType.</exception>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (value is Int32)
			{
				if (((int)value) >= 0)
					return ((int)value).ToString();
				else
					return "(none)";
			}
			else
				return null;
		}

		/// <summary>
		/// Returns a collection of standard index values for the image list associated with the specified format context.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that provides a format context, which can be used to extract additional information about the environment this type converter is being invoked from. This parameter or properties of this parameter can be null.</param>
		/// <returns>
		/// A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"></see> that holds a standard set of valid index values. If no image list is found, this collection will contain a single object with a value of -1.
		/// </returns>
		/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			ArrayList ResultList = new ArrayList();

			ResultList.Add(-1);

			foreach (DataRow row in KissImageList.qryXIcon.DataTable.Rows)
				ResultList.Add(row["XIconID"]);

			StandardValuesCollection Result = new StandardValuesCollection(ResultList);
			return Result;
		}
	}

	class KissImageListEditor : UITypeEditor
	{
		/// <summary>
		/// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
		/// </summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
		/// <returns>
		/// true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)"></see> is implemented; otherwise, false.
		/// </returns>
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
		{
			ImageList imgList = KissImageList.SmallImageList;
			return true;
		}

		/// <summary>
		/// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs"></see>.
		/// </summary>
		/// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs"></see> that indicates what to paint and where to paint it.</param>
		public override void PaintValue(PaintValueEventArgs e)
		{
			Image image = null;
			int iconID = -1;

			// check if we have a valid icon id
			if (e.Value != null && e.Value is int)
			{
				iconID = (int)e.Value;
			}

			if (iconID > 0)
				try
				{
					image = KissImageList.GetSmallImage(iconID);
				}
				catch { }

			if (iconID == -1)
			{

			}
			else if (image == null)
			{	// value -1 : Draws a cross to indicate no image.
				e.Graphics.DrawLine(Pens.Red, e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
				e.Graphics.DrawLine(Pens.Red, e.Bounds.Right - 1, e.Bounds.Y + 1, e.Bounds.X + 1, e.Bounds.Bottom - 1);
			}
			else if (iconID >= 0)
			{
				e.Graphics.DrawImage(image, e.Bounds);
			}
		}
	}
}
