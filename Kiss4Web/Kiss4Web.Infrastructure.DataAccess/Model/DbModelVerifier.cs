using System;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kiss4Web.Infrastructure.DataAccess.Model
{
    public class DbModelVerifier : IDbModelVerifier
    {
        private readonly ConnectionString _connectionString;
        private readonly object _sync = new object();
        private bool? _verified;

        public DbModelVerifier(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Verified => _verified ?? false;

        public Exception VerifyModelAgainstDatabaseException { get; private set; }

        public void VerifyModelAgainstDatabase()
        {
            // lock verhindert, dass während eines laufenden Checks weitere gestartet werden
            lock (_sync)
            {
                if (!_verified.HasValue)
                {
                    try
                    {
                        // ToDo: Verify DB-Model
                        //var initStrategy = new CreateDatabaseIfNotExists<AventisDbContext>();
                        //var builder = _model.ComposeModel(null, true);
                        //var connection = new SqlConnection(_connectionString);
                        //var model = new DbCompiledModel
                        //var model = builder.Build(connection).Compile();
                        //var context = AventisDbContext.CreateVerifyContext(connection, model, true);
                        //initStrategy.InitializeDatabase(context); // löst check aus
                        _verified = true;
                    }
                    catch (Exception ex)
                    {
                        _verified = false;
                        VerifyModelAgainstDatabaseException = ex;
                        throw;
                    }
                }
                if (_verified == false)
                {
                    throw VerifyModelAgainstDatabaseException;
                }
            }
        }
    }
}