using System;

namespace Kiss4Web.Infrastructure.DataAccess.Model
{
    public interface IDbModelVerifier
    {
        bool Verified { get; }

        Exception VerifyModelAgainstDatabaseException { get; }

        void VerifyModelAgainstDatabase();
    }
}