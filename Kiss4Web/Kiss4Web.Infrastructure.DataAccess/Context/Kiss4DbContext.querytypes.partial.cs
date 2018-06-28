using Kiss4Web.Model.QueryTypes;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    public partial class Kiss4DbContext
    {
        public virtual DbSet<SpezialkontoDisplayItem> SpezialkontoDisplayItems { get; set; }

        private void CreateQueryTypeModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpezialkontoDisplayItem>(spezkonto =>
            {
                spezkonto.HasKey(x => x.BgSpezkontoId);
            });
        }
    }
}