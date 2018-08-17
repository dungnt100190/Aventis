namespace KiSS4.Gesuchverwaltung.ExcelImport.DTO
{
    public class BaPersonSozialversicherungDTO
    {
        #region Properties

        public bool Arbeitslosenkasse
        {
            get;
            set;
        }

        public bool BeruflicheMassnahmeIv
        {
            get;
            set;
        }

        public bool BvgRente
        {
            get;
            set;
        }

        public bool Ergaenzungsleistungen
        {
            get;
            set;
        }

        public int? HilflosenentschaedigungCode
        {
            get;
            set;
        }

        public int? IntensivpflegezuschlagCode
        {
            get;
            set;
        }

        public int? IvGrad
        {
            get;
            set;
        }

        public bool IvHilfsmittel
        {
            get;
            set;
        }

        public bool IvTaggeld
        {
            get;
            set;
        }

        public bool Krankentaggeld
        {
            get;
            set;
        }

        public bool MedizinischeMassnahmeIv
        {
            get;
            set;
        }

        public int? RentenstufeCode
        {
            get;
            set;
        }

        public bool Sozialhilfe
        {
            get;
            set;
        }

        public bool UvgRente
        {
            get;
            set;
        }

        public bool UvgTaggeld
        {
            get;
            set;
        }

        public bool WittwenWittwerWaisenRente
        {
            get;
            set;
        }

        public string AndereSozialversicherungsleistungen
        {
            get;
            set;
        }

        #endregion
    }
}