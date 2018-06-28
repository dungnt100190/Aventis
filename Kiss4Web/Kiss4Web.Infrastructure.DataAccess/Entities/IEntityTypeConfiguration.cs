using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.DataAccess.Entities
{
    public interface IEntityTypeConfiguration
    {
        void BuildModel(ModelBuilder builder);
    }
}