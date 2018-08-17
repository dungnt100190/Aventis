using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.Infrastructure.Enumeration
{
    #region Enumerations

    /// <summary>
    /// Positionsstatus. 
    /// Dies ist ein berechneter Status. 
    /// Die Berechung ist im Dokument Positionsstatus von Marcel Weber
    /// beschrieben.
    /// </summary>    
    [Flags]
    public enum WshPositionsstatus
    {
        None = 0x0, 
        Vorbereitet = 0x1,
        Freigegeben = 0x2,
        TeilweiseFreigegeben = 0x4,
        Ausgeglichen = 0x8,
        TeilweiseAusgeglichen = 0x10, //16, ist hex schreibweise
        TeilweiseVorbereitet = 0x20 //32, ist hex schreibweise
    }

    #endregion
}