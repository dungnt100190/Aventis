using System;

namespace Kiss.DbContext
{
    partial class KesBehoerde
    {
        public string DisplayText
        {
            get
            {
                return KESBID + " " + KESBName;
            }
        }
    }
}