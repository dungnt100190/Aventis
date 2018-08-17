using System;
using System.Collections.Generic;
using System.Linq;

using KiSS.KliBu.BL.DTO;
using KiSS.KliBu.DA;

namespace KiSS.KliBu.BL.Extension
{
    /// <summary>
    /// Extension to the <see cref="BaBank"/> class
    /// </summary>
    static class BankExtensions
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Look if the two banks are different
        /// </summary>
        /// <param name="dbBank">The first bank (<see cref="BaBank"/>)</param>
        /// <param name="bank">The second bank (<see cref="Bank"/>)</param>
        /// <param name="landLookup">Delegate for 2-char Isocode lookup</param>
        /// <returns></returns>
        public static bool IsDifferent(this BaBank dbBank, Bank bank, Func<string, int?> landLookup)
        {
            if (dbBank.SicUpdated != bank.SicUpdated)
                return true;
            if (dbBank.Name != bank.Name)
                return true;
            if (dbBank.Strasse != bank.Strasse)
                return true;
            if (dbBank.PLZ != bank.PLZ)
                return true;
            if (dbBank.Ort != bank.Ort)
                return true;
            if (dbBank.ClearingNr != bank.ClearingNr)
                return true;
            if (dbBank.HauptsitzBCL != bank.HauptsitzBCL)
                return true;
            if (dbBank.ClearingNrNeu != bank.ClearingNrNeu)
                return true;
            if (dbBank.FilialeNr != bank.FilialeNr)
                return true;
            if (dbBank.GueltigAb != bank.GueltigAb)
                return true;
            if (dbBank.PCKontoNr != bank.PCKontoNrFormatiert)
                return true;
            if (dbBank.LandCode != landLookup(bank.Landcode))
                return true;
            return false;
        }

        /// <summary>
        /// Set the value of a <see cref="BaBank"/> with the ones from a <see cref="Bank"/>
        /// </summary>
        /// <param name="dbBank">The Entity to set</param>
        /// <param name="bank">The transfer object to get the value from</param>
        /// <param name="landLookup">Delegate for 2-char Isocode lookup</param>
        public static void Set(this BaBank dbBank, Bank bank, Func<string, int?> landLookup)
        {
            dbBank.SicUpdated = bank.SicUpdated;
            dbBank.LandCode = landLookup(bank.Landcode);
            dbBank.Name = bank.Name;
            dbBank.Strasse = bank.Strasse;
            dbBank.PLZ = bank.PLZ;
            dbBank.Ort = bank.Ort;
            dbBank.ClearingNr = bank.ClearingNr;
            dbBank.ClearingNrNeu = bank.ClearingNrNeu;
            dbBank.FilialeNr = bank.FilialeNr;
            dbBank.PCKontoNr = bank.PCKontoNrFormatiert;
            dbBank.GueltigAb = bank.GueltigAb;
            dbBank.HauptsitzBCL = bank.HauptsitzBCL;
            dbBank.Creator = bank.Creator;
            dbBank.Created = bank.Created;
            dbBank.Modifier = bank.Modifier;
            dbBank.Modified = bank.Modified;
        }

        /// <summary>
        /// Set the value of a <see cref="Bank"/> with the ones from a <see cref="BaBank"/>
        /// </summary>
        /// <param name="bank">The Entity to set</param>
        /// <param name="dbBank">The transfer object to get the value from</param>
        public static void Set(this Bank bank, BaBank dbBank, Func<int?, string> landLookup)
        {
            bank.ID = dbBank.BaBankID;
            bank.SicUpdated = dbBank.SicUpdated;
            bank.Landcode = landLookup(dbBank.LandCode);
            bank.Name = dbBank.Name;
            bank.Strasse = dbBank.Strasse;
            bank.PLZ = dbBank.PLZ;
            bank.Ort = dbBank.Ort;
            bank.ClearingNr = dbBank.ClearingNr;
            bank.ClearingNrNeu = dbBank.ClearingNrNeu;
            bank.FilialeNr = dbBank.FilialeNr;
            bank.PCKontoNr = dbBank.PCKontoNr;
            bank.GueltigAb = dbBank.GueltigAb;
            bank.HauptsitzBCL = dbBank.HauptsitzBCL;
            bank.Creator = dbBank.Creator;
            bank.Created = dbBank.Created;
            bank.Modifier = dbBank.Modifier;
            bank.Modified = dbBank.Modified;
        }

        /// <summary>
        /// Converts a <see cref="BaBank"/> to a <see cref="Bank"/>.
        /// </summary>
        /// <param name="baBank"></param>
        /// <returns></returns>
        public static Bank ToBank(this BaBank baBank, Func<int?, string> landLookup)
        {
            if (baBank == null)
            {
                return null;
            }
            Bank bank = new Bank();
            bank.Set(baBank, landLookup);
            return bank;
        }

        /// <summary>
        /// Get the result from <see cref="IQueryable<BaBank>"/> as a <see cref="List<Bank>"/>
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<Bank> ToBankList(this List<BaBank> lstBaBank, Func<int?, string> landLookup)
        {
            List<Bank> lst = new List<Bank>();

            foreach (BaBank baBank in lstBaBank)
            {
                lst.Add(baBank.ToBank(landLookup));
            }

            return lst;
        }

        #endregion

        #endregion
    }
}