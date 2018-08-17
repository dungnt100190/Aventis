using System;

namespace KiSS4.Klientenbuchhaltung
{
    public interface IBeleg
    {
        string Belegnummer { get; }
        //TODO
        //FlTransfer Transfer { get; }
        int TypSource { get; }
        DateTime Buchungsdatum { get; }
        DateTime Rechnungsdatum { get; }
        DateTime Verfalldatum { get; }
        int IdKreditor { get; }
        int IdZahlungsweg { get; }
        string Buchungstext { get; }
        string Extern { get; }
        string ESR { get; }
        decimal Betrag { get; }
        IBelegKostenart[] Kostenarten { get; }
        bool Provisorisch { get; }
    }
}
