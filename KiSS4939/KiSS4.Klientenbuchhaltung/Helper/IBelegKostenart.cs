
namespace KiSS4.Klientenbuchhaltung
{
    public interface IBelegKostenart
    {
        string Intern { get; }
        int IdFibuKostenart { get; }
        decimal Betrag { get; }
        IBelegKostenstelle[] Kostenstellen { get; }
    }
}
