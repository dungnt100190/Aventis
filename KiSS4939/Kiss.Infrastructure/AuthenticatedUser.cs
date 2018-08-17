using System.Globalization;
using System.Runtime.Serialization;

using Kiss.Interfaces.BL;

namespace Kiss.Infrastructure
{
    [DataContract]
    public class AuthenticatedUser : IAuthenticatedUser
    {
        [DataMember]
        public string CreatorModifier
        {
            get;
            set;
        }

        [DataMember]
        public CultureInfo CurrentCulture
        {
            get;
            set;
        }

        [DataMember]
        public string FirstName
        {
            get;
            set;
        }

        [DataMember]
        public bool IsUserAdmin
        {
            get;
            set;
        }

        [DataMember]
        public bool IsUserBIAGAdmin
        {
            get;
            set;
        }

        [DataMember]
        public int LanguageCode
        {
            get;
            set;
        }

        [DataMember]
        public string LastName
        {
            get;
            set;
        }

        [DataMember]
        public string LogonName
        {
            get;
            set;
        }

        [DataMember]
        public int UserID
        {
            get;
            set;
        }
    }
}