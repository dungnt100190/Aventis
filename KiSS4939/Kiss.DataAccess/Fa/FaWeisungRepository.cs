using System;
using System.Linq;
using Kiss.DbContext;
using Kiss.DbContext.Constant;
using Kiss.DbContext.DTO.Fa;
using Kiss.DbContext.Enums.Fa;
using Kiss.DbContext.Enums.Sys;

namespace Kiss.DataAccess.Fa
{
    public class FaWeisungRepository : Repository<FaWeisung>
    {
        public FaWeisungRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public FaWeisungDTO[] GetByFaLeistungIDs(int[] faLeistungIDs)
        {
            return DbSet
                   .Where(wei => faLeistungIDs.Contains(wei.FaLeistungID))
                   .Select(wei => new { Weisung = wei, LetztesProtokoll = wei.FaWeisungProtokoll.OrderByDescending(wpr => wpr.Created).FirstOrDefault() }) //let
                   .Select(wep => new FaWeisungDTO
                                      {
                                          FaWeisungID = wep.Weisung.FaWeisungID,
                                          FaLeistungID = wep.Weisung.FaLeistungID,
                                          DatumVon = wep.Weisung.Created,
                                          DatumBis = wep.Weisung.StatusCode != (int)LOVsGenerated.FaWeisungStatus.Fertig || wep.LetztesProtokoll == null ?
                                                       (DateTime?)null :
                                                       wep.LetztesProtokoll.Termin ?? wep.LetztesProtokoll.Created,
                                          Betreff = wep.Weisung.Betreff,
                                          VerantwortlichSar = wep.Weisung.XUser_VerantwortlichSar,
                                          Empfaenger = wep.Weisung.FaWeisung_BaPerson.Select(wbp => wbp.BaPerson),
                                          Dokumente = (new[]{ new{ Dokument = wep.Weisung.XDocument_Weisung, Typ = (int)WeisungDokument.Weisung, Termin = wep.Weisung.TerminWeisung },
                                                              new{ Dokument = wep.Weisung.XDocument_Mahnung1, Typ = (int)WeisungDokument.Mahnung1, Termin = wep.Weisung.TerminMahnung1 },
                                                              new{ Dokument = wep.Weisung.XDocument_Mahnung2, Typ = (int)WeisungDokument.Mahnung2, Termin = wep.Weisung.TerminMahnung2 },
                                                              new{ Dokument = wep.Weisung.XDocument_Mahnung3, Typ = (int)WeisungDokument.Mahnung3, Termin = wep.Weisung.TerminMahnung3 },
                                                              new{ Dokument = wep.Weisung.XDocument_Verfuegung, Typ = (int)WeisungDokument.Verfuegung, Termin = wep.Weisung.DatumVerfuegung } })
                                                      .Where(tmp => tmp.Dokument != null)
                                                      .Select(tmp => new FaWeisungDokumentDTO
                                                                         {
                                                                             Datum = tmp.Termin ?? tmp.Dokument.DateCreation,
                                                                             Typ = (WeisungDokument)tmp.Typ,
                                                                             Format = (DocumentFormat)(tmp.Dokument.DocFormatCode.HasValue ? tmp.Dokument.DocFormatCode.Value : 0)
                                                                         }),
                                          Protokolle = wep.Weisung.FaWeisungProtokoll
                                      })
                   .ToArray();
        }

    }
}
