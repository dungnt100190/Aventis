using System.Windows.Data;

using Kiss.Model;

namespace Kiss.UI.Controls.Converter
{
    /// <summary>
    /// Gibt bei neuen Objekten (Objekte, welche noch nicht auf der Datenbank vorhanden sind)
    /// false zurück, bei allen anderen true.
    /// </summary>
    [ValueConversion(typeof(ObjectState), typeof(bool))]
    internal class ObjectStateAddedToFalseConverter : ObjectState2BooleanConverter
    {
        public ObjectStateAddedToFalseConverter()
        {
            AddedValue = false;
            UnchangedValue = true;
            ModifiedValue = true;
            DeletedValue = true;
        }
    }
}