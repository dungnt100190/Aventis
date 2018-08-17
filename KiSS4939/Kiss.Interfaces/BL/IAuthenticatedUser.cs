using System.Globalization;

namespace Kiss.Interfaces.BL
{
    public interface IAuthenticatedUser
    {
        string CreatorModifier { get; }

        /// <summary>
        /// HACK: culture wird im .NET 4.0 nicht am neuen Task übergeben.
        /// Kann im .NET 4.5 mit CultureInfo.DefaultThreadCurrentCulture und CultureInfo.DefaultThreadCurrentUICulture korrigiert werden
        /// TODO: löschen beim Wechsel auf .NET 4.5
        /// </summary>
        CultureInfo CurrentCulture { get; }

        string FirstName { get; }

        bool IsUserAdmin { get; }

        bool IsUserBIAGAdmin { get; }

        int LanguageCode { get; }

        string LastName { get; }

        string LogonName { get; }

        int UserID { get; }
    }
}