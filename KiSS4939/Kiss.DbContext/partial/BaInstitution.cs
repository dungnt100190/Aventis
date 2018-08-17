namespace Kiss.DbContext
{
    public partial class BaInstitution
    {
        public string NameVorname
        {
            get
            {
                if (!string.IsNullOrEmpty(Vorname))
                {
                    return string.Format("{0}, {1}", Name, Vorname);
                }
                return Name;
            }
        }

        public override string ToString()
        {
            var format = "{0}, {1}"; // ToDo: aus config holen / static hinterlegen?
            if (!string.IsNullOrEmpty(Vorname))
            {
                // ToDo: format-logik, siehe emedko
                return string.Format(format, Name, Vorname);
            }
            return Name;
        }
    }
}