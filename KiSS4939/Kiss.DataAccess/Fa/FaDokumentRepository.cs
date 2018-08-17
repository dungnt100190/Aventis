using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;

namespace Kiss.DataAccess.Fa
{
    public class FaDokumentRepository : Repository<FaDokumente>
    {
        public FaDokumentRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public IList<FaDokumentDTO> GetDTOByFaLeistungID(int[] faLeistungID)
        {
            return DbSet
                   .Where(dok => faLeistungID.Contains(dok.FaLeistungID) &&
                                 !dok.IsDeleted &&
                                 dok.DatumErstellung.HasValue)
                   .Select(dok => new FaDokumentDTO
                                      {
                                          FaDokumentID = dok.FaDokumenteID,
                                          DatumErstellung = dok.DatumErstellung ?? (DateTime)SqlDateTime.MinValue,
                                          //DatumErstellung = dok.DatumErstellung ?? DateTime.MinValue, // Geht mit ProviderManifestToken="2005" im edmx nicht
                                          Stichwort = dok.Stichwort,
                                          DocFormatCode = dok.XDocument == null ? null : dok.XDocument.DocFormatCode,
                                          FaThemaCodes = dok.FaThemaCodes,
                                          FaLeistungID = dok.FaLeistungID,
                                          Absender = dok.XUser_Absender,
                                          Adressat = dok.BaPerson_Adressat
                                      })
                   .ToList();
        }
    }
}
