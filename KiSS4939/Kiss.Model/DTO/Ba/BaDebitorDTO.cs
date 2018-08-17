using System.Text;

namespace Kiss.Model.DTO.BA
{
    #region Enumerations

    public enum DebitorType
    {
        Person = 1,
        Institution = 2
    }

    #endregion

    /// <summary>
    /// DTO-Objekt für einen Debitor.
    /// </summary>
    public class BaDebitorDTO
    {
        #region Properties

        public string Adresse
        {
            get
            {
                var sb = new StringBuilder();

                bool first = false;

                if (!string.IsNullOrEmpty(StrasseHausNr))
                {
                    sb.Append(StrasseHausNr);
                    first = true;
                }

                if (!string.IsNullOrEmpty(Plz))
                {
                    if (first)
                    {
                        sb.Append(" ");
                    }

                    sb.Append(Plz);
                    first = true;
                }

                if (!string.IsNullOrEmpty(Ort))
                {
                    if (first)
                    {
                        sb.Append(" ");
                    }

                    sb.Append(Ort);
                }

                return sb.ToString();
            }
        }

        public string StrasseHausNr
        {
            get
            {
                var sb = new StringBuilder();

                bool first = false;

                if (!string.IsNullOrEmpty(Zusatz))
                {
                    sb.Append(Zusatz);
                    first = true;
                }

                if (!string.IsNullOrEmpty(Strasse))
                {
                    if (first)
                    {
                        sb.Append(", ");
                    }

                    sb.Append(Strasse);
                    first = true;
                }

                if (!string.IsNullOrEmpty(HausNr))
                {
                    if (first)
                    {
                        sb.Append(" ");
                    }

                    sb.Append(HausNr);
                }

                return sb.ToString();
            }
        }

        public BaInstitution BaInstitution
        {
            get;
            set;
        }

        public int? BaInstitutionId
        {
            get;
            set;
        }

        public BaPerson BaPerson
        {
            get;
            set;
        }

        public int? BaPersonId
        {
            get;
            set;
        }

        public string HausNr
        {
            get;
            set;
        }

        public string InstitutionName
        {
            get;
            set;
        }

        public string Nachname
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return Type == DebitorType.Person ? string.Format("{0}, {1}", Nachname, Vorname) : InstitutionName;
            }
        }

        public string Ort
        {
            get;
            set;
        }

        public string Plz
        {
            get;
            set;
        }

        public string PlzUndOrt
        {
            get
            {
                return string.Format("{0} {1}", Plz, Ort);
            }
        }

        public string Strasse
        {
            get;
            set;
        }

        public DebitorType Type
        {
            get;
            set;
        }

        public int TypeInt
        {
            get { return (int)Type; }
            set { Type = (DebitorType)value; }
        }

        public string Vorname
        {
            get;
            set;
        }

        public string Zusatz
        {
            get;
            set;
        }

        #endregion
    }
}