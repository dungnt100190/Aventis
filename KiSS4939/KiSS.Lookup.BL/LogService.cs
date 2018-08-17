using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

using KiSS.Common.BL;
using KiSS.Common.DA;
using KiSS.Common.Logging;
using KiSS.Lookup.BL.DTO;
using KiSS.Lookup.BL.Extension;
using KiSS.Lookup.BL.Resources;
using KiSS.Lookup.BL.Validation;
using KiSS.Lookup.DA;

using Common.Logging;

using Autofac;

namespace KiSS.Lookup.BL
{
    /// <summary>
    /// Service conating CRUD operations for XLog.
    /// </summary>
    /// <remarks>
    /// Optimistic Locking not provided so far.
    /// </remarks>
    public class LogService : ServiceBase
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Private Fields

        private IRepository<XLog> _repository;
        private IUnitOfWork _unitOfWork;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        public LogService(IContainer container)
            : base(container)
        {
            _unitOfWork = Context.Resolve<IUnitOfWork>();
            _repository = Context.Resolve<IRepository<XLog>>();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds a <see cref="Log"/> in the <see cref="XLogRepository"/>
        /// </summary>
        /// <param name="log">The <see cref="Log"/> to add</param>
        /// <returns>The <see cref="ServiceResult"/> containing the validation and business logic results</returns>
        public ServiceResult Add(Log log)
        {
            LogValidator validator = new LogValidator();
            ServiceResult serviceResult = new ServiceResult(validator.Validate(log));

            if(!serviceResult.Success)
                return serviceResult;

            using (var trans = new TransactionScope())
            {
                if (_repository.Count(l => l.XLogID == log.ID) > 0)
                {
                    serviceResult.AppendError(
                        ResMgr.GetMsg(Error.IdAlreadyExists)
                            .SetPropertyName("XLog").Replace("ID", log.ID)
                        );
                    return serviceResult;
                }

                XLog xLog = new XLog();
                xLog.Set(log);
                _repository.Add(xLog);

                _unitOfWork.Save();
                trans.Complete();

                logger.AuditInfo(log);
            }

            return serviceResult;
        }

        /// <summary>
        /// Deletes a <see cref="Log"/> in the <see cref="XLogRepository"/>
        /// </summary>
        /// <param name="log">Log to delete</param>
        /// <returns></returns>
        public ServiceResult Delete(Log log)
        {
            LogValidator validator = new LogValidator();
            ServiceResult serviceResult = new ServiceResult(validator.Validate(log));

            if (!serviceResult.Success)
                return serviceResult;

            using (var trans = new TransactionScope())
            {
                if (_repository.Count(l => l.XLogID == log.ID) > 1)
                {
                    serviceResult.AppendError(
                            ResMgr.GetMsg(Error.IdIsNotUnique)
                                .SetPropertyName("XLog").Replace("ID", log.ID)
                        );
                    return serviceResult;
                }

                XLog xLog = new XLog();
                xLog.Set(log);
                _repository.Delete(xLog);

                _unitOfWork.Save();
                trans.Complete();

                logger.AuditInfo(log);
            }

            return serviceResult;
        }

        /// <summary>
        /// Gets the <see cref="Log"/> by his code
        /// </summary>
        /// <param name="id">Log code</param>
        /// <returns>An <see cref="Log"/></returns>
        public Log GetById(int id)
        {
            return _repository
                .Where(l => l.XLogID == id)
                .First()   // in EF 1.0 .Single() ist not supported
                .ToLog();
        }

        /// <summary>
        /// Retrieves all plz from the <see cref="LookupRepository"/>
        /// </summary>
        /// <returns>A <see cref="List<Log>"/></returns>
        public List<Log> RetrieveAll()
        {
            var query = from l in _repository
                        select l;

            return query.ToLogList();
        }

        /// <summary>
        /// Updates a <see cref="Log"/> in the <see cref="LookupRepository"/>
        /// </summary>
        /// <param name="log">The <see cref="Log"/> to update</param>
        /// <returns>The <see cref="ServiceResult"/></returns>
        /// <remarks>
        /// A 'Optimistic Locking'-Check is provided, when the same Service Instance is used for Query and Update
        /// </remarks>
        public ServiceResult Update(Log log)
        {
            LogValidator validator = new LogValidator();
            ServiceResult serviceResult = new ServiceResult(validator.Validate(log));

            if (!serviceResult.Success)
                return serviceResult;

            XLog xLog = _repository
                .Where(l => l.XLogID == log.ID)
                .First();   // in EF 1.0 .Single() ist not supported

            xLog.Set(log);

            _unitOfWork.Save();

            logger.AuditInfo(log);

            return serviceResult;
        }

        #endregion

        #endregion
    }
}