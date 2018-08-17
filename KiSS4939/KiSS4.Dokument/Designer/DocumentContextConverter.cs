using System.Collections;
using System.ComponentModel;
using System.Data;
using KiSS4.DB;

namespace KiSS4.Dokument.Designer
{
    /// <summary>
    /// Helper class to offer only the defined contexts in a dropdown list in the property grid
    /// </summary>
    public class DocumentContextConverter : StringConverter
    {
        /// <summary>
        /// Returns whether this object supports a standard set of values that can be picked from a list.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns></returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true means show a combobox
            return Session.Active;
        }


        /// <summary>
        /// Gets a value indicating whether the list of standard values returned from the <see cref="GetStandardValues" /> method is an exclusive list.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns></returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            //true will limit to list. false will show the list, 
            //but allow free-form entry
            return Session.Active;
        }

        /// <summary>
        /// Gets a collection of available contexts
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext" /> that provides a format context.</param>
        /// <returns></returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ArrayList availableContexts = new ArrayList();
            if (Session.Active)
            {
                SqlQuery qry = DBUtil.OpenSQL("SELECT DocContextName FROM XDocContext ORDER BY 1");
                foreach (DataRow row in qry.DataTable.Rows)
                {
                    availableContexts.Add(row[0] as string);
                }
            }
            return new StandardValuesCollection(availableContexts);
        }
    }
}
