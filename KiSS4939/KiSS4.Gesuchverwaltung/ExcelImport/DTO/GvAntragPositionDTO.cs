using Kiss.Infrastructure.Constant;

namespace KiSS4.Gesuchverwaltung.ExcelImport.DTO
{
    public class GvAntragPositionDTO
    {
        #region Properties

        public decimal Betrag
        {
            get;
            set;
        }

        public string Bezeichnung
        {
            get;
            set;
        }

        public LOVsGenerated.GvAntragPositionTyp GvAntragPositionTyp
        {
            get;
            set;
        }

        #endregion
    }
}