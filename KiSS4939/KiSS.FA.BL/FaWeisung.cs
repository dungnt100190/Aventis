using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Infrastructure.Constant;

namespace KiSS.FA.BL
{
    /// <summary>
    /// Klasse um die Weisungen zu handeln
    /// </summary>
    public class FaWeisung
    {
        #region Enumerations

        /// <summary>
        /// Verschiedene Terminentyp. Wird im Workflow gebraucht.
        /// </summary>
        public enum Termin
        {
            Keine = 0,
            Weisung = 10,
            Mahnung1 = 21,
            Mahnung2 = 22,
            Mahnung3 = 23,
            Verfuegung = 30
        }

        /// <summary>
        /// Person die für die Weisung Zuständig ist. Wird im Workflow gebraucht.
        /// </summary>
        public enum Zustaendig
        {
            Niemand = 0,
            Ersteller = 1,
            RD = 2
        }

        /// <summary>
        /// Weisungsart
        /// </summary>
        public enum Weisungsart
        {
            Schriftlich = 0,
            Muendlich = 1
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields


        // FeldName
        private const string EDT_ANGEDROHTE_KONSEQUENZ = "edtAngedrohteKonsequenz";
        private const string EDT_ANGEDROHTE_KUERZUNG_GB = "edtAngedrohteKuerzungGB";
        private const string EDT_AUFLAGENTEXT = "edtAuflagentext";
        private const string EDT_AUSGANGSLAGE = "edtAusgangslage";
        private const string EDT_BEMERKUNG = "edtBemerkung";
        private const string EDT_BETREFF = "edtBetreff";
        private const string EDT_BETROFFENE_PERSONEN = "edtBetroffenePersonen";
        private const string EDT_DATUM_VERFUEGUNG = "edtDatumVerfuegung";
        private const string DOC_DATUM_VERFUEGUNG = "docDatumVerfuegung";
        private const string EDT_KONSEQUENZ_BIS = "edtKonsequenzBis";
        private const string EDT_KONSEQUENZ = "edtKonsequenz";
        private const string EDT_KONSEQUENZ_VON = "edtKonsequenzVon";
        private const string EDT_KUERZUNG_BIS = "edtKuerzungBis";
        private const string EDT_KUERZUNG_GB = "edtKuerzungGB";
        private const string EDT_KUERZUNG_VON = "edtKuerzungVon";
        private const string EDT_TERMIN = "edtTermin";
        private const string DOC_TERMIN = "docTermin";
        private const string EDT_TERMIN_MAHNUNG_1 = "edtTerminMahnung1";
        private const string DOC_TERMIN_MAHNUNG_1 = "docTerminMahnung1";
        private const string EDT_TERMIN_MAHNUNG_2 = "edtTerminMahnung2";
        private const string DOC_TERMIN_MAHNUNG_2 = "docTerminMahnung2";
        private const string EDT_TERMIN_MAHNUNG_3 = "edtTerminMahnung3";
        private const string DOC_TERMIN_MAHNUNG_3 = "docTerminMahnung3";
        private const string EDT_WEISUNGSART = "edtWeisungsart";

        #endregion

        #region Private Fields

        private static List<FaWeisungStatusFeld> _FaWeisungAktiveFelder = new List<FaWeisungStatusFeld> { 
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.Init, "", false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.WeisungBearbeiten, EDT_WEISUNGSART, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.WeisungBearbeiten, EDT_BETREFF, true),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.WeisungBearbeiten, EDT_BETROFFENE_PERSONEN, true),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.WeisungBearbeiten, EDT_AUSGANGSLAGE, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.WeisungBearbeiten, EDT_AUFLAGENTEXT, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.WeisungBearbeiten, EDT_ANGEDROHTE_KUERZUNG_GB, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.WeisungBearbeiten, EDT_ANGEDROHTE_KONSEQUENZ, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.WeisungBearbeiten, EDT_TERMIN, true),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.WeisungBearbeiten, DOC_TERMIN, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.PruefungRD, EDT_AUSGANGSLAGE, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.PruefungRD, EDT_AUFLAGENTEXT, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.PruefungRD, DOC_TERMIN, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.Mahnung1Bearbeiten, EDT_TERMIN_MAHNUNG_1, true),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.Mahnung1Bearbeiten, DOC_TERMIN_MAHNUNG_1, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.Mahnung2Bearbeiten, EDT_TERMIN_MAHNUNG_2, true),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.Mahnung2Bearbeiten, DOC_TERMIN_MAHNUNG_2, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.Mahnung3Bearbeiten, EDT_TERMIN_MAHNUNG_3, true),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.Mahnung3Bearbeiten, DOC_TERMIN_MAHNUNG_3, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.Mahnung1PruefungRD, DOC_TERMIN_MAHNUNG_1, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.Mahnung2PruefungRD, DOC_TERMIN_MAHNUNG_2, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.Mahnung3PruefungRD, DOC_TERMIN_MAHNUNG_3, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.VerfuegungBearbeiten, EDT_DATUM_VERFUEGUNG, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.VerfuegungBearbeiten, DOC_DATUM_VERFUEGUNG, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.VerfuegungBearbeiten, EDT_KUERZUNG_GB, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.VerfuegungBearbeiten, EDT_KUERZUNG_VON, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.VerfuegungBearbeiten, EDT_KUERZUNG_BIS, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.VerfuegungBearbeiten, EDT_KONSEQUENZ, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.VerfuegungBearbeiten, EDT_KONSEQUENZ_VON, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.VerfuegungBearbeiten, EDT_KONSEQUENZ_BIS, false),
           new FaWeisungStatusFeld(LOVsGenerated.FaWeisungStatus.VerfuegungPruefungRD, DOC_DATUM_VERFUEGUNG, false)
        };

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Liste von aktive Felder für jeden Status
        /// </summary>
        public static List<FaWeisungStatusFeld> FaWeisungAktiveFelder
        {
            get { return _FaWeisungAktiveFelder;}
        }

        #endregion
    }
}