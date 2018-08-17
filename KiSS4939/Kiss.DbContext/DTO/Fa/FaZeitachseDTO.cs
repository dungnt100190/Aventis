using System;
using System.Collections.Generic;

using Kiss.DbContext.Enums.Sys;

namespace Kiss.DbContext.DTO.Fa
{
    #region Enumerations

    /// <summary>
    /// Typen die in der Zeitachse dargestellt werden können.
    /// Name eines Wertes wird fürs Holen von Kontig-Wert verwendet (System\Fallfuehrung\Zeitachse\AngezeigteTypen\...)
    /// --> Achtung beim umbenennen!
    /// </summary>
    public enum FaZeitachseDTOType
    {
        /// <summary>
        /// Auswertung Prozess: 1
        /// </summary>
        AuswertungProzess = 1,
        /// <summary>
        /// Besprechungen: 2
        /// </summary>
        Besprechungen = 2,
        /// <summary>
        /// Fallübergabe: 3
        /// </summary>
        Falluebergabe = 3,
        /// <summary>
        /// Korrespondenz: 4
        /// </summary>
        Korrespondenz = 4,
        /// <summary>
        /// Verträge: 6
        /// </summary>
        Vertraege = 6,
        /// <summary>
        /// Weisungen: 7
        /// </summary>
        Weisungen = 7,
        /// <summary>
        /// Ziele: 8
        /// </summary>
        Ziele = 8,
        /// <summary>
        ///  Kategorie: 9
        /// </summary>
        Kategorie = 9,
        /// <summary>
        /// Pendenzen: 5
        /// </summary>
        PendenzenErledigt = 10,
        /// <summary>
        /// PendenzenOffen
        /// </summary>
        PendenzenOffen = 11
    }

    #endregion

    public class FaZeitachseDTO : Infrastructure.Bindable
    {
        #region Properties

        // Besprechung   -> Kontaktpartner
        // Korrespondenz -> Adressat
        // Weisung       -> Betroffene Person
        // Pendenz       -> Empfaenger
        public string Empfaenger { get; set; }
        public string JumpToPath { get; set; }
        public string SARName { get; set; }
        public DateTime StartDate { get; set; }
        public string Title { get; set; }
        public FaZeitachseDTOType Type { get; set; }

        #endregion
    }

    public class FaZeitachseEventDTO : FaZeitachseDTO
    {
        #region Properties

        public DocumentFormat? DocFormat { get; set; }
        public string ShortText { get; set; }

        public int? DocFormatCode
        {
            get { return (int?)DocFormat; }

            set
            {
                if (value == null)
                {
                    DocFormat = null;
                    return;
                }

                DocFormat = (DocumentFormat)value;
            }
        }

        public string Stichwort { get; set; }
        public XLOVCode[] ThemaCodes { get; set; }

        #endregion
    }

    public class FaZeitachsePeriodDTO : FaZeitachseDTO
    {
        #region Properties

        public List<FaZeitachseEventDTO> DateLabels { get; set; }
        public List<FaZeitachseEventDTO> Documents { get; set; }
        public DateTime? EndDate { get; set; }
        public int? KategorieCode { get; set; }
        public string PendenzStatus { get; set; }

        #endregion
    }
}