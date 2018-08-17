namespace KiSS4.Favoriten.Model
{
    public class FavoriteControl
    {
        #region Fields

        #region Private Fields

        private string _name;
        private string _type;
        private string _value;
        private int _xSearchControlTemplateFieldId;

        #endregion

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public int XSearchControlTemplateFieldId
        {
            get { return _xSearchControlTemplateFieldId; }
            set { _xSearchControlTemplateFieldId = value; }
        }

        #endregion
    }
}