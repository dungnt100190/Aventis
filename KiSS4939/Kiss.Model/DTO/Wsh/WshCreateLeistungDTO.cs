using System;


namespace Kiss.Model.DTO.Wsh
{
    /// <summary>
    /// DTO object containing all data needed to create
    /// a new FaLeistung for WSH.
    /// </summary>
    public class WshCreateLeistungDTO
    {
        #region Properties

        public int BaPersonId
        {
            get; set;
        }

        public DateTime DatumVon
        {
            get; set;
        }


        public int? UserId { get; set; }

        #endregion
    }
}