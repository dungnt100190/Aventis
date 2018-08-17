using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;

namespace Kiss.Database
{
    public class KissQueryProvider : IQueryProvider
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly IQueryProvider _queryProvider;

        #endregion

        #endregion

        #region Constructors

        public KissQueryProvider(IQueryProvider queryProvider)
        {
            _queryProvider = queryProvider;
        }

        #endregion

        #region Methods

        #region Public Methods

        public IQueryable CreateQuery(Expression expression)
        {
            return _queryProvider.CreateQuery(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return _queryProvider.CreateQuery<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return Execute(expression, true);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return Execute<TResult>(expression, true);
        }

        #endregion

        #region Private Methods

        private object Execute(Expression expression, bool retry)
        {
            try
            {
                return _queryProvider.Execute(expression);
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
                        return Execute(expression, false);
                    }

                }
                throw;
            }
        }

        private TResult Execute<TResult>(Expression expression, bool retry)
        {
            try
            {
                return _queryProvider.Execute<TResult>(expression);
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
                        return Execute<TResult>(expression, false);
                    }
                }
                throw;
            }
        }

        #endregion

        #endregion
    }
}