using System.Collections.Generic;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Audit;
using Microsoft.EntityFrameworkCore;

namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    public partial class Kiss4DbContext : IDbContext
    {
        private readonly IEnumerable<IDbChangeAuditor> _auditors;

        public Kiss4DbContext(DbContextOptions options, IEnumerable<IDbChangeAuditor> auditors)
            : base(options)
        {
            _auditors = auditors;
        }

        public async Task SaveChangesAsync()
        {
            if (_auditors != null)
            {
                foreach (var auditor in _auditors)
                {
                    auditor.AuditEntities(ChangeTracker.Entries(), this);
                }
            }
            await base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            if (_auditors != null)
            {
                foreach (var auditor in _auditors)
                {
                    auditor.AuditEntities(ChangeTracker.Entries(), this);
                }
            }
            return base.SaveChanges();
        }

        public void ExecuteSqlCommand(string sql)
        {
            if (_auditors != null)
            {
                foreach (var auditor in _auditors)
                {
                    auditor.AuditEntities(ChangeTracker.Entries(), this);
                }
            }
            this.Database.ExecuteSqlCommand(sql);
        }
    }
}