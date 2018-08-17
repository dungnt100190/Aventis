using System;
using System.Reflection;

// todo Dateonly attribute -> trim time

namespace KiSS4.Schnittstellen.Newod.DTO
{
    public class PersonSearchCriteria
    {
        // nur Fallträger

        public PersonSearchCriteria()
        {
            IsMapped = false;
            OnlyFT = false;
            Soundex = false;
        }

        public string ID { get; set; }

        public string NewodNummer { get; set; }

        public bool IsMapped { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime? BirthDayFrom { get; set; }

        public DateTime? BirthDayTo { get; set; }

        public string Ahv11 { get; set; }

        public string Ahv13 { get; set; }

        public string Strasse { get; set; }

        public string Hausnr { get; set; }

        public string Plz { get; set; }

        public string Ort { get; set; }

        public string Country { get; set; }

        public string CountryIso2Code { get; set; }

        public bool OnlyFT { get; set; }

        public bool Soundex { get; set; }

        /// <summary>
        /// Removes all leading and trailling white-space character for all string properties form the current object.
        /// </summary>
        public void Trim()
        {
            // TODO add this logic to a base class

            PropertyInfo[] properties = this.GetType().GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                if (prop.PropertyType == typeof(string))
                {
                    string value = prop.GetValue(this, null) as string;
                    if (value != null)
                    {
                        value = value.Trim();
                    }
                    // hat einen Setter?
                    if (prop.GetSetMethod() != null)
                    {
                        if (value == "")
                        {
                            prop.SetValue(this, null, null);
                        }
                        else
                        {
                            prop.SetValue(this, value, null);
                        }
                    }
                }
            }
        }
    }
}