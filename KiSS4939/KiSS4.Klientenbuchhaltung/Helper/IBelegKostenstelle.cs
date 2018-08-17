
namespace KiSS4.Klientenbuchhaltung
{
    public interface IBelegKostenstelle
    {
        string NameFbKostenstelle { get; }
        decimal Betrag { get; }
        string NrmKonto { get; }
    }
}
