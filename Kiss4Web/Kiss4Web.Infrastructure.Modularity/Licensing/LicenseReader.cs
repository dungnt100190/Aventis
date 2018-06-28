using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Kiss4Web.Infrastructure.Modularity.Licensing
{
    public class LicenseReader : ILicenseReader
    {
        private readonly SqlConnection _connection;
        private readonly Lazy<IEnumerable<KissModul>> _licensedModules;

        public LicenseReader(SqlConnection connection)
        {
            _connection = connection;
            _licensedModules = new Lazy<IEnumerable<KissModul>>(ReadLicensedModules);
        }

        public IEnumerable<KissModul> GetLicensedModules()
        {
            return _licensedModules.Value;
        }

        private IEnumerable<KissModul> ReadLicensedModules()
        {
            return _connection.Query<KissModul>(@"SELECT ModulID FROM dbo.XModul WHERE Licensed = 1")
                              .Where(mod => Enum.IsDefined(typeof(KissModul), mod))
                              .ToList();
        }
    }
}