using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Infrastructure;

namespace Kiss.Model
{
    public partial class XUser
    {
        public XUser()
        {
            //LastNameFirstName
            AddPropertyMapping(PropertyName.GetPropertyName(() => LastName),
                                PropertyName.GetPropertyName(() => LastNameFirstName));
            AddPropertyMapping(PropertyName.GetPropertyName(() => FirstName),
                                PropertyName.GetPropertyName(() => LastNameFirstName));
        }

        public string LastNameFirstName
        {
            get { return string.Format("{0}, {1}", LastName, FirstName); }
        }
    }
}
