using System.Collections.Generic;
using System.Linq;

namespace KiSS4.Gesuchverwaltung.ExcelImport.DTO
{
    public class GvGesuchDTO
    {
        #region Constructors

        public GvGesuchDTO()
        {
            GvAntragPositionDTOList = new List<GvAntragPositionDTO>();
            BaPersonDTOList = new List<BaPersonDTO>();
        }

        #endregion

        #region Properties

        public List<BaPersonDTO> BaPersonDTOList
        {
            get;
            private set;
        }

        public BaPersonDTO BaPersonDtoKlient
        {
            get { return BaPersonDTOList.First(x => x.IsKlient); }
        }

        /// <summary>
        /// BaPersonId des Klients
        /// </summary>
        public int BaPersonIdKlient
        {
            get
            {
                var baPersonId = BaPersonDtoKlient.BaPersonId;
                if (baPersonId != null)
                {
                    return (int)baPersonId;
                }

                return 0;
            }
        }

        public BaZahlungswegDTO BaZahlungswegDTO
        {
            get;
            set;
        }

        public string Begruendung
        {
            get;
            set;
        }

        public string Gesuchsgrund
        {
            get;
            set;
        }

        public GvAbklaerendeStelleDTO GvAbklaerendeStelleDTO
        {
            get;
            set;
        }

        public List<GvAntragPositionDTO> GvAntragPositionDTOList
        {
            get;
            private set;
        }

        public int GvGesuchId
        {
            get;
            set;
        }

        #endregion
    }
}