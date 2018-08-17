using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Kiss.Server.PSCD.WSMock
{
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    /// <summary>
    /// Summary description for MI_SD01_CREATE_WS
    /// </summary>
    [WebService(Namespace = "http://stzh.ch/FAMOZ_SD01_CREATE_WS")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class FAMOZ_SD01_CREATE_WS : System.Web.Services.WebService, IFAMOZ_SD01_CREATE_WS
    {
        #region EventHandlers

        [WebMethod]
        public string MI_SD01_CREATE_WS(string CALLER_ID, _STZH_SOZ_CD_F2_BAPIDFKKKO DOCUMENTHEADER, _STZH_SOZ_CD_F2_BAPI_PAYMENT PAYMENTINFO, ref _STZH_SOZ_CD_F2_BAPIDFKKOP[] PARTNERPOSITIONS, out BAPIRET2 RETURN)
        {
            System.Threading.Thread.Sleep(2000);

            RETURN = new BAPIRET2();
            if (DOCUMENTHEADER != null)
            {
                return DOCUMENTHEADER.DOC_NO;
            }
            return null;
        }

        #endregion
    }
}