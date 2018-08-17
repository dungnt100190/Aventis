using System;
using System.Collections.Generic;

using KiSS4.DB;
using KiSS4.Dokument;

namespace KiSS4.BDE.ExcelImport
{
    public class BdeExcelImporter : ExcelImporter
    {
        private const string COLUMN_NAME_ANSATZ = "Ansatz";
        private const string COLUMN_NAME_ANZAHL = "Anzahl";
        private const string COLUMN_NAME_LEISTUNGSART = "Leistungsart";
        private const string COLUMN_NAME_MITARBEITERNR = "Mitarbeiter-Nr.";
        private const string COLUMN_NAME_MONAT = "Monat";
        private const int COLUMN_NR_ANSATZ = 5;
        private const int COLUMN_NR_ANZAHL = 4;
        private const int COLUMN_NR_LEISTUNGSART = 3;
        private const int COLUMN_NR_MITARBEITERNR = 1;
        private const int COLUMN_NR_MONAT = 2;
        private const string MASK_NAME = "FrmBDEZeiterfassung";

        public BdeExcelImporter(string fileName)
            : base(fileName)
        {
            BdeLeistungDTOList = new List<BdeLeistungDTO>();
        }

        public List<BdeLeistungDTO> BdeLeistungDTOList
        {
            get;
            private set;
        }

        protected override bool ProcessDocument()
        {
            var errorList = new List<string>();
            if (!ValidateExcel(errorList))
            {
                KissMsg.ShowInfo(MASK_NAME, "ExcelImportFalschesFormat_v2", "Die ausgewählte Datei besitzt nicht das geforderte Format.\r\n\r\n{0}", string.Join(Environment.NewLine, errorList));
                return false;
            }

            return ImportData();
        }

        private bool CreateDto(int rowId, string mitarbeiterNrString)
        {
            int mitarbeiterNr;
            int ansatz;
            decimal anzahl;
            DateTime monat;

            // Validierung
            if (!int.TryParse(mitarbeiterNrString, out mitarbeiterNr) ||
                !DateTime.TryParse(_excelDocument.GetValue(1, rowId, COLUMN_NR_MONAT), out monat))
            {
                return false;
            }

            // Anzahl und Ansatz ignorieren falls nichts angegeben oder 0
            // Leistungsart wird später mit einer Meldung abgefangen
            if (decimal.TryParse(_excelDocument.GetValue(1, rowId, COLUMN_NR_ANZAHL), out anzahl) &&
                anzahl > 0 &&
                int.TryParse(_excelDocument.GetValue(1, rowId, COLUMN_NR_ANSATZ), out ansatz) &&
                ansatz > 0)
            {
                var leistungsart = _excelDocument.GetValue(1, rowId, COLUMN_NR_LEISTUNGSART);
                int standardKostentraeger;
                if (string.IsNullOrEmpty(leistungsart))
                {
                    standardKostentraeger = 0;
                }
                else if (!int.TryParse(leistungsart, out standardKostentraeger))
                {
                    standardKostentraeger = -1;
                }

                BdeLeistungDTOList.Add(new BdeLeistungDTO(mitarbeiterNr, monat, standardKostentraeger, anzahl, ansatz));
            }

            return true;
        }

        private bool ImportData()
        {
            //Beginne in 2. Zeile (erste Zeile enthält Spaltentitel)
            var rowId = 2;

            while (true)
            {
                // immer vom 1. Worksheet daten holen (worksheetIndex 1)
                var mitarbeiterNr = _excelDocument.GetValue(1, rowId, COLUMN_NR_MITARBEITERNR);

                if (string.IsNullOrWhiteSpace(mitarbeiterNr))
                {
                    break;
                }

                var result = CreateDto(rowId, mitarbeiterNr);

                if (!result)
                {
                    return false;
                }

                rowId++;
            }

            return true;
        }

        private bool ValidateExcel(List<string> errorList)
        {
            //Erste Zeile enthält Spaltentitel
            const int rowId = 1;

            var spaltenTitel = _excelDocument.GetValue(1, rowId, COLUMN_NR_MITARBEITERNR);
            if (string.IsNullOrEmpty(spaltenTitel) || !spaltenTitel.Equals(COLUMN_NAME_MITARBEITERNR, StringComparison.InvariantCultureIgnoreCase))
            {
                errorList.Add(KissMsg.GetMLMessage(MASK_NAME, "ExcelImportFalscherSpaltenTitel", "Falscher Spalten-Titel: {0}, erwartet: {1}", spaltenTitel, COLUMN_NAME_MITARBEITERNR));
            }

            spaltenTitel = _excelDocument.GetValue(1, rowId, COLUMN_NR_MONAT);
            if (string.IsNullOrEmpty(spaltenTitel) || !spaltenTitel.Equals(COLUMN_NAME_MONAT, StringComparison.InvariantCultureIgnoreCase))
            {
                errorList.Add(KissMsg.GetMLMessage(MASK_NAME, "ExcelImportFalscherSpaltenTitel", "Falscher Spalten-Titel: {0}, erwartet: {1}", spaltenTitel, COLUMN_NAME_MONAT));
            }

            spaltenTitel = _excelDocument.GetValue(1, rowId, COLUMN_NR_LEISTUNGSART);
            if (string.IsNullOrEmpty(spaltenTitel) || !spaltenTitel.Equals(COLUMN_NAME_LEISTUNGSART, StringComparison.InvariantCultureIgnoreCase))
            {
                errorList.Add(KissMsg.GetMLMessage(MASK_NAME, "ExcelImportFalscherSpaltenTitel", "Falscher Spalten-Titel: {0}, erwartet: {1}", spaltenTitel, COLUMN_NAME_LEISTUNGSART));
            }

            spaltenTitel = _excelDocument.GetValue(1, rowId, COLUMN_NR_ANZAHL);
            if (string.IsNullOrEmpty(spaltenTitel) || !spaltenTitel.Equals(COLUMN_NAME_ANZAHL, StringComparison.InvariantCultureIgnoreCase))
            {
                errorList.Add(KissMsg.GetMLMessage(MASK_NAME, "ExcelImportFalscherSpaltenTitel", "Falscher Spalten-Titel: {0}, erwartet: {1}", spaltenTitel, COLUMN_NAME_ANZAHL));
            }

            spaltenTitel = _excelDocument.GetValue(1, rowId, COLUMN_NR_ANSATZ);
            if (string.IsNullOrEmpty(spaltenTitel) || !spaltenTitel.Equals(COLUMN_NAME_ANSATZ, StringComparison.InvariantCultureIgnoreCase))
            {
                errorList.Add(KissMsg.GetMLMessage(MASK_NAME, "ExcelImportFalscherSpaltenTitel", "Falscher Spalten-Titel: {0}, erwartet: {1}", spaltenTitel, COLUMN_NAME_ANSATZ));
            }

            return errorList.Count == 0;
        }
    }
}