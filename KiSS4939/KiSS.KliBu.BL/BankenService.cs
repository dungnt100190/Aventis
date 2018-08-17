using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

using KiSS.Common;
using KiSS.Common.BL;
using KiSS.Common.DA;
using KiSS.Common.DA.Extension;
using KiSS.Common.Logging;
using KiSS.KliBu.BL.DTO;
using KiSS.KliBu.BL.Extension;
using KiSS.KliBu.BL.Resources;
using KiSS.KliBu.BL.Validation;
using KiSS.KliBu.DA;

using FluentValidation.Internal;

using Common.Logging;

using Autofac;

namespace KiSS.KliBu.BL
{
    /// <summary>
    /// Service containg CRUD operations for BaBank.
    /// </summary>
    public class BankenService : ServiceBase
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Private Fields

        private IRepository<BaBank> _bankRepository;
        private LookupProxy _lookup;
        private IUnitOfWork _unitOfWork;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BankenService"/> class.
        /// </summary>
        public BankenService(IContainer container)
            : base(container)
        {
            _unitOfWork = Context.Resolve<IUnitOfWork>();
            _bankRepository = Context.Resolve<IRepository<BaBank>>();
            _lookup = new LookupProxy(Context);
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds a <see cref="Bank"/> in the <see cref="BankRepository"/>
        /// </summary>
        /// <param name="bank">The <see cref="Bank"/> to add</param>
        /// <returns>The <see cref="ServiceResult"/> containing the validation and business logic results</returns>
        public ServiceResult Add(Bank bank)
        {
            bank.Trim();

            BankValidator bankValidator = new BankValidator();
            ServiceResult serviceResult = new ServiceResult(bankValidator.Validate(bank));

            if (!serviceResult.Success)
                return serviceResult;

            bank.SicUpdated = false;

            using (var trans = new TransactionScope(TransactionScopeOption.Required))
            {
                if (_bankRepository.Count(b => b.ClearingNr == bank.ClearingNr && b.FilialeNr == bank.FilialeNr) > 0)
                {
                    serviceResult.AppendError(
                        ResMgr.GetMsg(Error.BankAlreadyExists)
                        .Replace("ClearingNr", bank.ClearingNr)
                        .Replace("FilialeNr", bank.FilialeNr)
                        );
                    return serviceResult;
                }

                BaBank dbBank = new BaBank();
                dbBank.Set(bank, _lookup.LandLookupCode);
                _bankRepository.Add(dbBank);

                _unitOfWork.Save();
                trans.Complete();

                bank.ID = dbBank.BaBankID;   // get the primary key

                logger.AuditInfo(bank);
            }

            return serviceResult;
        }

        /// <summary>
        /// Deletes a <see cref="Bank"/> in the <see cref="BankRepository"/>
        /// </summary>
        /// <param name="bank">The <see cref="Bank"/> to delete</param>
        /// <returns>The <see cref="ServiceResult"/> containing business logic results</returns>
        public ServiceResult Delete(Bank bank)
        {
            ServiceResult serviceResult = new ServiceResult();

            using (var trans = new TransactionScope(TransactionScopeOption.Required))
            {
                BaBank dbBank = GetBaBankByClearingNrAndFilialNr(bank.ClearingNr, bank.FilialeNr);
                _bankRepository.Delete(dbBank);

                _unitOfWork.Save();
                trans.Complete();
            }

            return serviceResult;
        }

        /// <summary>
        /// Get a <see cref="Bank"/> by the clearingNr and and filialeNr
        /// </summary>
        /// <param name="clearingNr">The clearingNr of the bank to get</param>
        /// <param name="filialeNr">The filialeNr of the bank to get</param>
        /// <returns>The <see cref="Bank"/>, or null if there's no bank with the given clearingNr and filialeNr</returns>
        public Bank GetByClearingNrAndFilialNr(string clearingNr, int filialeNr)
        {
            return GetBaBankByClearingNrAndFilialNr(clearingNr, filialeNr).ToBank(_lookup.LandLookupTwoCharIsoCode);
        }

        /// <summary>
        /// Get a <see cref="Bank"/> by its ID
        /// </summary>
        /// <param name="id">BaBankID</param>
        /// <returns>The <see cref="Bank"/></returns>
        public Bank GetByID(int id)
        {
            return _bankRepository
                .Where(b => b.BaBankID == id)
                .First()   // in EF 1.0 .Single() ist not supported
                .ToBank(_lookup.LandLookupTwoCharIsoCode);
        }

        /// <summary>
        /// Retrieves all bank from the <see cref="BankRepository"/>
        /// </summary>
        /// <returns>A <see cref="List<Bank>"/></returns>
        public List<Bank> RetrieveAll()
        {
            var query = from b in _bankRepository
                        select b;

            return query.ToList(logger).ToBankList(_lookup.LandLookupTwoCharIsoCode);
        }

        /// <summary>
        /// Updates a <see cref="Bank"/> in the <see cref="BankRepository"/>
        /// </summary>
        /// <param name="bank">The <see cref="Bank"/> to update</param>
        /// <returns>The <see cref="ServiceResult"/></returns>
        /// <remarks>
        /// A 'Optimistic Locking'-Check is provided, when the same Service Instance is used for Query and Update
        /// </remarks>
        public ServiceResult Update(Bank bank)
        {
            BankValidator bankValidator = new BankValidator();
            ServiceResult serviceResult = new ServiceResult(bankValidator.Validate(bank));

            if (!serviceResult.Success)
                return serviceResult;

            bank.SicUpdated = false;

            using (var trans = new TransactionScope(TransactionScopeOption.Required))
            {
                BaBank dbBank = _bankRepository
                    .Where(b => b.BaBankID == bank.ID)
                    .First();   // in EF 1.0 .Single() ist not supported

                dbBank.Set(bank, _lookup.LandLookupCode);

                _unitOfWork.Save();
                trans.Complete();
            }

            logger.AuditInfo(bank);

            return serviceResult;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get a <see cref="BaBank"/> by the clearingNr and and filialeNr
        /// </summary>
        /// <param name="clearingNr">The clearingNr of the bank to get</param>
        /// <param name="filialeNr">The filialeNr of the bank to get</param>
        /// <returns>The <see cref="BaBank"/>, or null if there's no bank with the given clearingNr and filialeNr</returns>
        private BaBank GetBaBankByClearingNrAndFilialNr(string clearingNr, int filialeNr)
        {
            var query = _bankRepository.Where(b => b.ClearingNr == clearingNr && b.FilialeNr == filialeNr);

            if (query.Count() == 0)
            {
                return null;
            }

            return query
                .First();   // in EF 1.0 .Single() ist not supported
        }

        #endregion

        #endregion
    }
}