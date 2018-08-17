using System;
using System.Reflection;

namespace KiSS4.Schnittstellen.Newod.DTO
{
    public class GetPersonRequest
    {
        /// <summary>
        /// Get/Set ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Get/Set Mutationsart
        /// </summary>
        public string Mutationsart { get; set; }

        /// <summary>
        /// Get/Set ValidFrom
        /// </summary>
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Get ValidFromSpecified
        /// </summary>
        public bool ValidFromSpecified { get; set; }

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
