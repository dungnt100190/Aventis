using System.Linq;

using Kiss.DbContext;

namespace Kiss.DataAccess.Sys
{
    public class XDocumentRepository : Repository<XDocument>
    {
        public XDocumentRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public XDocumentRepository()
        {
        }

        /// <summary>
        /// Löscht ein Dokument anhand einer ID ohne das ganze FileBinary zu laden
        /// </summary>
        /// <param name="id">DocumentId das gelöscht werden muss</param>
        /// <returns></returns>
        public XDocument Remove(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }

            var documentToDelete = DbSet
                .Where(x => x.DocumentID == id)
                .Select(x => new { x.DocumentID, x.XDocumentTS })
                .FirstOrDefault();
            if (documentToDelete != null)
            {
                var doc = new XDocument
                {
                    DocumentID = documentToDelete.DocumentID,
                    XDocumentTS = documentToDelete.XDocumentTS
                };
                DbSet.Attach(doc);
                return DbSet.Remove(doc);
            }

            return null;
        }
    }
}