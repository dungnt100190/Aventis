using System.Data.Entity;

namespace Kiss.DbContext
{
    public interface IKissContext : IDbContext
    {
        IDbSet<BaPerson> BaPerson { get; }      // Repository for BaPerson
        IDbSet<FaLeistung> FaLeistung { get; }  // Repository for FaLeistung
        IDbSet<BaZahlungsweg> BaZahlungsweg { get; }
        //IDbSet<WshAbzug> WshAbzug { get; }
        //IDbSet<WshAbzugDetail> WshAbzugDetail { get; }
        //IDbSet<WshGrundbudgetPosition> WshGrundbudgetPosition { get; }
        //IDbSet<WshGrundbudgetPositionDebitor> WshGrundbudgetPositionDebitor { get; }
        //IDbSet<WshGrundbudgetPositionKreditor> WshGrundbudgetPositionKreditor { get; }
        //IDbSet<WshHaushaltPerson> WshHaushaltPerson { get; }
        //IDbSet<WshKategorie> WshKategorie { get; }
        //IDbSet<WshKategorie_KbuKonto> WshKategorie_KbuKonto { get; }
        //IDbSet<WshKontoAttribut> WshKontoAttribut { get; }
        //IDbSet<WshPosition> WshPosition { get; }
        //IDbSet<WshPositionDebitor> WshPositionDebitor { get; }
        //IDbSet<WshPositionKreditor> WshPositionKreditor { get; }
        IDbSet<HistoryVersion> HistoryVersion { get; }
        IDbSet<BaAdresse> BaAdresse { get; }
        IDbSet<VmPosition> VmPosition { get; }

    }
}
