using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kiss4Web.Infrastructure.DataAccess.Model
{
    public interface IDbModelComposer
    {
        IModel ComposeModel(ModelBuilder modelBuilder = null, bool onlyModelVerification = false);
    }
}