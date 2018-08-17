using System;

using Kiss.DbContext;
using Kiss.Infrastructure.Constant;

namespace Kiss.DataAccess.Test.Seeder
{
    public class FaLeistungSeeder : DbSeeder<FaLeistung>
    {
        public FaLeistungSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public bool IsZh
        {
            get;
            set;
        }

        public override FaLeistung CreateEntity()
        {
            return CreateFaLeistung(null, null, null, 2, 200); // ToDo: enums for modul, prozesscode
        }

        public FaLeistung CreateFaLeistung(FaFall fall, BaPerson person, XUser user, int modulID, int faProzessCode)
        {
            person = person ?? DbSeed.GetOrCreateEntity<BaPerson>();
            user = user ?? DbSeed.GetOrCreateEntity<XUser>();

            if (IsZh)
            {
                // NUR BEI ZH!!
                fall = fall ?? DbSeed.GetOrCreateEntity<FaFall>();
            }

            var leistung = new FaLeistung
                               {
                                   BaPerson = person,
                                   XUser = user,
                                   DatumVon = new DateTime(DateTime.Today.Year, 1, 1),
                                   FaFall = fall,
                                   ModulID = modulID,
                                   FaProzessCode = faProzessCode,
                                   GemeindeCode = 351
                               };
            DbSeed.Add(leistung);
            return leistung;
        }

        public FaLeistung CreateWsh(FaFall fall = null, BaPerson person = null, XUser user = null)
        {
            return CreateFaLeistung(fall, person, null, 103 /*WSH*/, (int)LOVsGenerated.FaProzess.Existenzsicherung);
        }
    }
}