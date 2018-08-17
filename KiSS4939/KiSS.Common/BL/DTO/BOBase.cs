using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KiSS.Common.BL.DTO
{
    public class BOBase
    {
        #region Methods

        #region Public Methods

        public virtual void Normalize()
        {
        }

        /// <summary>
        /// Removes all leading and trailling withe-space character for all string properties form the current object.
        /// </summary>
        public virtual void Trim()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                if(prop.PropertyType == typeof(string))
                {
                    string value = prop.GetValue(this, null)as string;
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

        #endregion

        #endregion
    }
}