using System.Collections.Generic;
using Kiss4Web.Infrastructure.DataAccess.Audit;
using Kiss4Web.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    public class Kiss4DbContextFactory : IDbContextFactory, IDesignTimeDbContextFactory<Kiss4DbContext>
    {
        private readonly IEnumerable<IDbChangeAuditor> _auditors;
        private readonly ConnectionString _connectionString;
        //private readonly IValidationService _validationService;

        public Kiss4DbContextFactory(ConnectionString connectionString, IEnumerable<IDbChangeAuditor> auditors)
        {
            _connectionString = connectionString;
            //_validationService = validationService;
            _auditors = auditors;
            //_model = model;
        }

        public Kiss4DbContext Create()
        {
            return Create(new DbContextFactoryOptions());
        }

        public Kiss4DbContext Create(DbContextFactoryOptions factoryOptions)
        {
            var options = new DbContextOptionsBuilder();
            //options.UseModel(_model);
            options.UseSqlServer(_connectionString);
            return new Kiss4DbContext(options.Options, _auditors);
        }

        public IDbContext CreateDbContext()
        {
            return Create();
        }

        public Kiss4DbContext CreateDbContext(string[] args)
        {
            return Create();
        }
    }
}