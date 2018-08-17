using System;
using System.Collections.Generic;
using System.Linq;
using Kiss.DataAccess.Validation;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fs;

namespace Kiss.DataAccess.Fa
{
    // ToDo: In File auslagern
    public class FaPhaseKlient
    {
        public int FaPhaseID { get; set; }
        public int BaPersonID { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string BaPersonVorname { get; set; }
        public string BaPersonName { get; set; }
        public int? FsDienstleistungspaketID_Zugewiesen { get; set; }
        public int? FsDienstleistungspaketID_Bedarf { get; set; }
    }

    public class FaPhaseRepository : Repository<FaPhase>
    {
        public FaPhaseRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }


        public FsDienstleistungAuswertungGesamtDTO[] GetPhasenDienstleistungAuswertung(DateTime datumVon,
                                                                                       DateTime datumBis)
        {
            return DbSet
                .Where(pha => pha.UserID.HasValue &&
                              pha.DatumVon <= datumBis &&
                              (pha.DatumBis == null || pha.DatumBis >= datumVon))
                .GroupBy(pha => pha.XUser,
                         (user, phasen) => new
                                               {
                                                   Key = user,
                                                   OrgUnit =
                                               user.XOrgUnit_User.FirstOrDefault(ouu => ouu.OrgUnitMemberCode == 2),
                                                   Phasen = phasen.Where(pha => pha.UserID == user.UserID)
                                               })
                .Select(grp => new FsDienstleistungAuswertungGesamtDTO
                                   {
                                       UserId = grp.Key.UserID,
                                       Mitarbeiter = grp.Key.LastName,
                                       //ToDo: LastNameFirstName
                                       Team = grp.OrgUnit == null ? string.Empty : grp.OrgUnit.XOrgUnit.ItemName,
                                       AnzahlDlpBedarf =
                                           grp.Phasen.Count(x => x.FsDienstleistungspaketID_Bedarf != null),
                                       AnzahlDlpZugewiesen =
                                           grp.Phasen.Count(x => x.FsDienstleistungspaketID_Zugewiesen != null),
                                       AnzahlPhasenIntake = grp.Phasen.Count(x => x.FaPhaseCode == 1),
                                       AnzahlPhasenBeratung = grp.Phasen.Count(x => x.FaPhaseCode == 2),
                                   })
                .Where(dto => dto.AnzahlPhasenIntake > 0 || dto.AnzahlPhasenBeratung > 0)
                .ToArray();
        }

        public FaPhaseKlient[] GetPhasenOfUserInPeriod(int? userId, DateTime datumVon, DateTime datumBis)
        {
            return DbSet
                   .Where(pha => pha.DatumVon <= datumBis &&
                                 (pha.DatumBis == null || pha.DatumBis >= datumVon) &&
                                 (pha.UserID == userId || userId == null))
                   .Select(pha => new FaPhaseKlient
                                      {
                                          FaPhaseID = pha.FaPhaseID,
                                          BaPersonID = pha.FaLeistung.BaPersonID,
                                          DatumVon = pha.DatumVon,
                                          DatumBis = pha.DatumBis,
                                          BaPersonVorname = pha.FaLeistung.BaPerson.Vorname,
                                          BaPersonName = pha.FaLeistung.BaPerson.Name,
                                          FsDienstleistungspaketID_Zugewiesen = pha.FsDienstleistungspaketID_Zugewiesen,
                                          FsDienstleistungspaketID_Bedarf = pha.FsDienstleistungspaketID_Bedarf
                                      })
                   .ToArray();
        }
    }
}
