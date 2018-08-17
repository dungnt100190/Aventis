using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KiSSSvc.SAP.PSCD.Mock
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MI_SD01_CREATE_WS" in code, svc and config file together.
    public class FAMOZ_SD01_CREATE_WS : IFAMOZ_SD01_CREATE_WS
    {
        public MI_SD01_CREATE_WSResponse MI_SD01_CREATE_WS(MI_SD01_CREATE_WSRequest request)
        {
            var response = new MI_SD01_CREATE_WSResponse { DOCUMENTNUMBER = request.DOCUMENTHEADER.DOC_NO, PARTNERPOSITIONS = request.PARTNERPOSITIONS };
            return response;
        }
    }
}
