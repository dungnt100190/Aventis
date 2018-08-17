using System;
using System.IO;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Das Interface beschreibt die Gemeinsamkeiten von EzagOrder and DtaOrder.
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Liest oder setzt die ZugangsId.
        /// </summary>
        /// <value>The access id.</value>
        Object AccessId { get; }

        /// <summary>
        /// Gets the type of the job.
        /// </summary>
        /// <value>"DTA", "EZAG" or "ISO 20022"</value>
        String JobType { get; }

        /// <summary>
        /// Liest oder setzt die ZahlungslaufID.
        /// </summary>
        /// <value>The journal id.</value>
        Int32 JournalId { get; set; }

        /// <summary>
        /// Gets the "PaymentMessageID", an ID used to identify a payment in the ISO 20022 format.
        /// </summary>
        /// <value>The payment message id.</value>
        String PaymentMessageId { get; }

        /// <summary>
        /// Gets the "TotalBetrag".
        /// </summary>
        /// <value>The total amount.</value>
        Decimal TotalBetrag { get; }

        /// <summary>
        /// Generates the appropriate file.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        void GenerateFile(FileInfo fileInfo);
    }
}