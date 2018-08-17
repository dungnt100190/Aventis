using System;

namespace Kiss.DbContext
{
    partial class BaEinwohnerregisterEmpfangeneEreignisse
    {
        /// <summary>
        /// Gets or sets event date of this message.
        /// This is not saved on the database.
        /// </summary>
        public DateTime? EventDate { get; set; }

        /// <summary>
        /// Gets or sets a message that corresponds with the type of this event.
        /// This is not saved on the database.
        /// </summary>
        public string Message { get; set; }
    }
}