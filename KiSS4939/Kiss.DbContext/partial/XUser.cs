

namespace Kiss.DbContext
{
    public partial class XUser
    {
        public string LastNameFirstName
        {
            get
            {
                if (!string.IsNullOrEmpty(FirstName))
                {
                    return string.Format("{0}, {1}", LastName, FirstName);
                }
                return LastName;
            }
        }
    }
}
