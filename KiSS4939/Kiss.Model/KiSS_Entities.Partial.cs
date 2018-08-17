using System;
using System.Data.Objects;
using System.Data.SqlClient;

using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;

namespace Kiss.Model
{
    partial class KiSS_Entities
    {
        #region Methods

        #region Public Methods

        public override int SaveChanges(SaveOptions options)
        {
            return SaveChanges(options, true);
        }

        #endregion

        #region Private Methods

        private int SaveChanges(SaveOptions options, bool retry)
        {
            try
            {
                return base.SaveChanges(options);
            }
            catch (Exception ex)
            {
                if (retry)
                {
                    var sqlEx = ex as SqlException ?? ex.InnerException as SqlException;

                    // 10054: Transport-level error
                    if (sqlEx != null && sqlEx.Number == 10054)
                    {
                        var sessionService = Container.Resolve<ISessionService>();
                        sessionService.EnsureConnection();
                        return SaveChanges(options, false);
                    }
                }
                throw;
            }
        }

        #endregion

        #endregion
    }
}