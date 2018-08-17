using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.Model.DTO.Wsh
{
    public class WshPositionSummeDTO
    {
        #region Properties

        public decimal? SummeBelegPositionenFreigegeben
        {
            get;
            set;
        }

        public decimal? SummeBelegPositionenVerbucht
        {
            get;
            set;
        }

        public int WshPositionID
        {
            get;
            set;
        }

        #endregion
    }
}
