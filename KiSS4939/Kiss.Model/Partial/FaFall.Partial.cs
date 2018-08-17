using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Infrastructure;

namespace Kiss.Model
{
    public partial class FaFall
    {
        public FaFall()
        {
            AddPropertyMapping(PropertyName.GetPropertyName(() => BaPerson),
                                PropertyName.GetPropertyName(() => FaFallIDFaFalltraeger));
        }

        public string FaFallIDFaFalltraeger
        {
            get
            {
                if(this.BaPerson != null)
                {
                    return string.Format("F{0} {1}", FaFallID, this.BaPerson.NameVorname);
                }
                return string.Format("F{0}", FaFallID);
            }
        }
    }
}
