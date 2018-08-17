using System;

namespace KiSS4.Schnittstellen.Klientenbuchhaltung
{
    /// <summary>
    /// The result of transferring a new Beleg.
    /// </summary>
    public class TransferBelegResult
    {
        #region Fields

        internal readonly string Belegnummer; // not set if Error
        internal readonly string FibuMsg; // null if Verbucht, non-null otherwise
        internal readonly int Laufnummer; // not set if Error
        //TODO KbBuchungsStatusCode?
        //internal readonly FlBelegStatus Status; // Verbucht, Warning, Error

        #endregion

        #region Constructors

        //TODO
        //private TransferBelegResult(FlBelegStatus status, int laufnummer, string belegnummer, string fibuMsg)
        //{
        //    this.Status = status;
        //    this.Laufnummer = laufnummer;
        //    this.Belegnummer = belegnummer;
        //    this.FibuMsg = fibuMsg;
        //}

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates an instance for an unsuccessful transfer, returning a message.
        /// </summary>
        public static TransferBelegResult Error(string fibuMsg)
        {
            if (fibuMsg == null) throw new ArgumentNullException("fibuMsg");
            //TODO
            return null;
            //return new TransferBelegResult(FlBelegStatus.Error, -1, null, fibuMsg);
        }

        /// <summary>
        /// Creates an instance for a successful transfer, returning the laufnummer and belegnummer.
        /// </summary>
        public static TransferBelegResult OK(int laufnummer, string belegnummer)
        {
            if (belegnummer == null) throw new ArgumentNullException("belegnummer");
            //TODO
            return null;
            //return new TransferBelegResult(FlBelegStatus.Verbucht, laufnummer, belegnummer, null);
        }

        /// <summary>
        /// Creates an instance for a successful transfer, but with a warning, returning the laufnummer, belegnummer and a message.
        /// </summary>
        public static TransferBelegResult Warning(int laufnummer, string belegnummer, string fibuMsg)
        {
            if (belegnummer == null) throw new ArgumentNullException("belegnummer");
            if (fibuMsg == null) throw new ArgumentNullException("fibuMsg");
            //TODO
            return null;
            //return new TransferBelegResult(FlBelegStatus.Warning, laufnummer, belegnummer, fibuMsg);
        }
        #endregion
    }
}