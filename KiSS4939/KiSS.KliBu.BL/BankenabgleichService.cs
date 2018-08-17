using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using KiSS4.DB;

using KiSS.Common;
using KiSS.Common.BL;
using KiSS.Common.DA;
using KiSS.KliBu.BL.DTO;
using KiSS.KliBu.BL.Extension;
using KiSS.KliBu.BL.Resources;
using KiSS.KliBu.BL.Validation;
using KiSS.KliBu.DA;

using FluentValidation.Results;

using Common.Logging;

using Autofac;

namespace KiSS.KliBu.BL
{
    /// <summary>
    /// Class to synchronize the <see cref="BankRepository"/>
    /// </summary>
    public class BankenabgleichService : ServiceBase
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Private Fields

        private IRepository<BaBank> _bankRepository;
        private Dictionary<string, BaBank> _dbBankDic;

        #endregion

        #endregion

        #region Constructors

        public BankenabgleichService(IContainer container)
            : base(container)
        {
        }

        #endregion

        #region Properties

        private Dictionary<string, BaBank> BankDictionary
        {
            get
            {
                if (_dbBankDic == null)
                {
                    // TODO von ResMgr oder kein catch?
                    try
                    {
                        _dbBankDic = _bankRepository.ToDictionary(b => b.Key);
                    }
                    catch (ArgumentException ex)
                    {
                        throw new AppException("Banken mit der gleichen ClearingNr und FilialeNr vorhanden.", ex);
                    }
                }
                return _dbBankDic;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Synchronize the bank on the <see cref="BankRepository"/> with the bank in the list.
        /// If the list contains more than one bank with the same ClearingNr and FilialeNr only the last one will be added
        /// </summary>
        /// <param name="bankList">list of bank to update</param>
        /// <param name="updatedBankList">list of bank that have been updated</param>
        /// <returns>Number of updated banks</returns>
        public ServiceResult Sync(List<Bank> bankList, out List<Bank> updatedBankList)
        {
            logger.Info("Sync enter.");

            ServiceResult serviceResult = new ServiceResult();

            updatedBankList = new List<Bank>();

            // The list must not be null
            if (bankList == null)
            {
                serviceResult.AppendError(
                    ResMgr.GetMsg(Error.IsNull)
                    .SetPropertyName("bankList")
                    );

                return serviceResult;
            }

            LookupProxy lookup = new LookupProxy(Context);

            // Only synchronize the Swiss banks
            IEnumerable<Bank> bankToSyncList = bankList.Where(b => b.Landcode == "CH");

            Stopwatch watch = new Stopwatch();
            watch.Start();

            IUnitOfWork unitOfWork = Context.Resolve<IUnitOfWork>();
            _bankRepository = Context.Resolve<IRepository<BaBank>>();

            BankValidator bankValidator = new BankValidator();

            // Bank validation
            foreach (Bank bank in bankToSyncList)
            {
                ValidationResult validationResult = bankValidator.Validate(bank);
                if (!validationResult.IsValid)
                {
                    serviceResult.AppendError(
                        ResMgr.GetMsg(Error.IsInvalidBank)
                        .Replace("ClearingNr", bank.ClearingNr)
                        .Replace("FilialeNr", bank.FilialeNr)
                        );
                    return serviceResult;
                }
            }

            // Update or add bank
            foreach (Bank bank in bankToSyncList)
            {
                BaBank dbBank = GetBaBank(bank.ClearingNr, bank.FilialeNr);
                if (dbBank != null)
                {
                    if (dbBank.IsDifferent(bank, lookup.LandLookupCode))
                    {
                        dbBank.Set(bank, lookup.LandLookupCode);
                        bank.ID = dbBank.BaBankID;
                        dbBank.Modifier = DBUtil.GetDBRowCreatorModifier();
                        dbBank.Modified = DateTime.Now;
                        updatedBankList.Add(bank);
                    }
                }
                else
                {
                    BaBank newDbBank = new BaBank();
                    newDbBank.Set(bank, lookup.LandLookupCode);
                    newDbBank.Creator = DBUtil.GetDBRowCreatorModifier();
                    newDbBank.Created = DateTime.Now;
                    newDbBank.Modifier = DBUtil.GetDBRowCreatorModifier();
                    newDbBank.Modified = DateTime.Now;
                    _bankRepository.Add(newDbBank);
                    BankDictionary.Add(newDbBank.Key, newDbBank);
                    updatedBankList.Add(bank);
                }
            }

            // Set SicUpdated flag to false for Banks that are not anymore is the list
            foreach(BaBank dbBank in BankDictionary.Values.Where(b => b.SicUpdated))
            {
                if (bankToSyncList.Where(b => b.ClearingNr == dbBank.ClearingNr && b.FilialeNr == dbBank.FilialeNr).Count() == 0)
                {
                    dbBank.SicUpdated = false;
                }
            }

            unitOfWork.Save();

            // get the ID for new banks
            foreach (Bank bank in updatedBankList.Where(b => b.ID == 0))
            {
                BaBank dbBank = GetBaBank(bank.ClearingNr, bank.FilialeNr);
                bank.ID = dbBank.BaBankID;
            }

            watch.Stop();
            logger.Debug(String.Format("Consumed time to synchronize: {0}s", watch.ElapsedMilliseconds / 1000));

            // Add an entry in the XLog table
            KiSS.Lookup.BL.DTO.Log log = new KiSS.Lookup.BL.DTO.Log(this.GetType().FullName, KiSS.Lookup.BL.DTO.LogLevel.INFO, "updated", DBUtil.GetDBRowCreatorModifier(), true);
            log.Comment = string.Format("{0} method, {1} updated bank", new StackFrame().GetMethod().Name, updatedBankList.Count);
            lookup.AddLog(log);

            logger.Info("Sync done.");
            return serviceResult;
        }

        #endregion

        #region Private Methods

        private BaBank GetBaBank(string clearingNr, int filialeNr)
        {
            BaBank dbBank = null;
            BankDictionary.TryGetValue(BaBank.KeyValue(clearingNr, filialeNr), out dbBank);
            return dbBank;
        }

        #endregion

        #endregion
    }
}