using System;

namespace KiSS4.Klientenbuchhaltung
{
    public abstract class Buchung
    {
        public abstract DateTime Datum { get; }
        public abstract int BelegNr { get; }
        public abstract string Kostenart { get; }
        public abstract string KostenartText { get; }
        public abstract string Buchungstext { get; }
        public abstract decimal Auszahlung { get; }
        public abstract decimal Einnahme { get; }
        public abstract decimal Saldovortrag { get; }
    }
}
