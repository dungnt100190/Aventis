using System;
using System.Text;

using Kiss.Infrastructure;

namespace Kiss.Model
{
    public partial class BaPerson
    {
        public BaPerson()
        {
            //Alter
            AddPropertyMapping(PropertyName.GetPropertyName(() => Geburtsdatum),
                                PropertyName.GetPropertyName(() => Alter));
            AddPropertyMapping(PropertyName.GetPropertyName(() => Sterbedatum),
                                PropertyName.GetPropertyName(() => Alter));

            //NameVorname
            AddPropertyMapping(PropertyName.GetPropertyName(() => Name),
                                PropertyName.GetPropertyName(() => NameVorname));
            AddPropertyMapping(PropertyName.GetPropertyName(() => Vorname),
                                PropertyName.GetPropertyName(() => NameVorname));

            //NameVornameAlter
            AddPropertyMapping(PropertyName.GetPropertyName(() => NameVorname),
                                PropertyName.GetPropertyName(() => NameVornameAlter));
            AddPropertyMapping(PropertyName.GetPropertyName(() => Alter),
                                PropertyName.GetPropertyName(() => NameVornameAlter));
        }

        #region Properties

        /// <summary>
        /// Returns the Age of the Person, calculated with the current date. If a Sterbedatum is defined (and it is earlier than the current date), this
        /// Sterbedatum is considered.
        /// </summary>
        public int? Alter
        {
            get
            {
                DateTime referenzDatum = DateTime.Today;

                if (!Geburtsdatum.HasValue)
                {
                    return null;
                }

                DateTime geburtsdatum = Geburtsdatum.Value;

                if (Sterbedatum.HasValue && Sterbedatum.Value < referenzDatum)
                {
                    //sterbedatum ist relevant
                    referenzDatum = Sterbedatum.Value;
                }

                //geburtsdatum
                if (geburtsdatum < referenzDatum)
                {
                    int years = referenzDatum.Year - geburtsdatum.Year;
                    //wenn das Referenzdatum vor dem Geburtsdatum liegt, muss noch ein Jahr subtrahiert werden
                    if (referenzDatum.Month < geburtsdatum.Month
                        || (referenzDatum.Month == geburtsdatum.Month && referenzDatum.Day < geburtsdatum.Day))
                    {
                        years--;
                    }

                    return years;
                }

                return null;
            }
        }

        public string NameVorname
        {
            get
            {                
                var nameVorname = new StringBuilder(Name);
                if (!string.IsNullOrEmpty(Vorname))
                {
                    nameVorname.Append(", ");
                    nameVorname.Append(Vorname);
                }
                return nameVorname.ToString();
            }
        }

        public string NameVornameAlter
        {
            get
            {
                var nameVornameAlter = new StringBuilder(NameVorname);

                if (Alter.HasValue)
                {
                    nameVornameAlter.Append(" (");
                    nameVornameAlter.Append(Alter);
                    nameVornameAlter.Append(")");
                }
                
                return nameVornameAlter.ToString();
            }
        }

        #endregion
    }
}