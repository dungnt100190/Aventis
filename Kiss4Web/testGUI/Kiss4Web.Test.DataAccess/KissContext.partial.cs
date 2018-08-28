using System.Collections.Generic;
using System.Data.Entity;

namespace Kiss4Web.Test.DataAccess
{
    public partial class KissContext : DbContext
    {
        private readonly IEnumerable<IDbChangeAuditor> _auditors;

        public KissContext(IEnumerable<IDbChangeAuditor> auditors)
            : base("name=KissDBConnection")
        {
            _auditors = auditors;
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
