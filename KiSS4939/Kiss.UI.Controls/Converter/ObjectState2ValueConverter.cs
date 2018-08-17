using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

using Kiss.Model;

namespace Kiss.UI.Controls.Converter
{
    /// <summary>
    /// Converts an object to bool based on the fact whether the reference is set to null.
    /// A null-reference will be converted to either true or false. The default value for
    /// a null-reference is false, so it can be easily used for the binding of SelectedEntity
    /// and the IsEnabled property of the detail panel.
    /// </summary>
    public class ObjectState2ValueConverter<T> : IValueConverter
    {
        #region Methods

        public T UnchangedValue { get; set; }
        public T AddedValue { get; set; }
        public T ModifiedValue { get; set; }
        public T DeletedValue { get; set; }

        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObjectState objectState = ObjectState.Unchanged;

            if (value != null)
            {
                Enum.TryParse<ObjectState>(value.ToString(), true, out objectState);
            }

            switch (objectState)
            {
                case ObjectState.Added:
                    return AddedValue;

                case ObjectState.Deleted:
                    return DeletedValue;

                case ObjectState.Modified:
                    return ModifiedValue;

                case ObjectState.Unchanged:
                    return UnchangedValue;

                default:
                    return UnchangedValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("The ConvertBack function is not implemented");
        }

        #endregion

        #endregion
    }

    public class ObjectState2BooleanConverter : ObjectState2ValueConverter<Boolean> { }
}