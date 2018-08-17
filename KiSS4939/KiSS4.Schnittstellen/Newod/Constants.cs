using System;

namespace KiSS4.Schnittstellen.Newod
{
    public class Constants
    {
        /// <summary>
        /// The username to use for login to newod system
        /// </summary>
        public static String NewodUserName = "XIKISSUSER";

        /// <summary>
        /// The password to use for login to newod system
        /// </summary>
        public static String NewodPassword = "xi09kiss";

        /// <summary>
        /// The uri to access newod webservice
        /// </summary>
        public static String NewodWebserviceSearchPersonUri = @"http://dbs2006.bgov.ch:8000/XISOAPAdapter/MessageServlet?channel=:KISS:CC_SOAP_KISS_SP_SENDER&amp;version=3.0&amp;Sender.Service=KISS&amp;Interface=http%3A%2F%2Fbern.ch%5EMI_SearchPerson_Out";

        /// <summary>
        /// The uri to access newod webservice
        /// </summary>
        public static String NewodWebserviceGetPersonUri = @"http://dbs2006.bgov.ch:8000/XISOAPAdapter/MessageServlet?channel=:KISS:CC_SOAP_KISS_GP_SENDER&amp;version=3.0&amp;Sender.Service=KISS&amp;Interface=http%3A%2F%2Fsap.ch%2FeCH%5EMI_GetPersonMulti_eChOut";



    }
}
