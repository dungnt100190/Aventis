using System.Windows.Data;

using Kiss.Model;

namespace Kiss.UI.Controls.Converter
{
    /// <summary>
    /// Gibt bei neuen Objekten (Objekte, welche noch nicht auf der Datenbank vorhanden sind)
    /// true zurück, bei allen anderen false.
    /// </summary>
    [ValueConversion(typeof(ObjectState), typeof(bool))]
    public class ObjectStateAdded2TrueConverter : ObjectState2BooleanConverter
    {
        #region Constructors

        public ObjectStateAdded2TrueConverter()
        {
            AddedValue = true;
            UnchangedValue = false;
            ModifiedValue = false;
            DeletedValue = false;
        }

        #endregion
    }
}