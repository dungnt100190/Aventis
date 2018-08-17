using System;

namespace Kiss.DbContext
{
    public interface IAuditableEntity
    {
        /// <summary>
        /// Erstelldatum des Entities.
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// Ersteller des Entities.
        /// </summary>
        string Creator { get; set; }

        /// <summary>
        /// Letztes Mutationsdatum des Entities.
        /// </summary>
        DateTime Modified { get; set; }

        /// <summary>
        /// Benutzername der letzten Mutation des Entities.
        /// </summary>
        string Modifier { get; set; }
    }
}
