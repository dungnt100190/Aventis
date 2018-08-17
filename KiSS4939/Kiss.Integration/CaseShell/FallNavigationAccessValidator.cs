using System;
using System.Collections;

using KiSS4.DB;
using KiSS4.Main.PI;

namespace Kiss.Integration.CaseShell
{
    public class FallNavigationAccessValidator
    {
        public static bool AllowNavigate(IDictionary kiss4Parameters, out string message)
        {
            message = null;

            if (!kiss4Parameters.Contains("BaPersonID"))
            {
                return false;
            }

            var installationInfo = InstallationInfo.GetInstallationInfo();

            var baPersonID = (int)kiss4Parameters["BaPersonID"];

            switch (installationInfo.ProductType)
            {
                case ProductType.Standard:
                    break;

                case ProductType.PI:
                    return AllowNavigatePI(baPersonID, out message);

                case ProductType.ZH:
                    break;
            }

            return true;
        }

        private static bool AllowNavigatePI(int baPersonID, out string message)
        {
            message = null;
            try
            {
                // if the user has no rights to display this user, we show an exception
                if (!KiSS4.Common.PI.FaUtils.UserMayShowPersonDossier(baPersonID))
                {
                    //lblPersonName.Text = KissMsg.GetMLMessage("CtlFall", "AccessDeniedLabel", "Keine Rechte für dieses Dossier!");
                    message = KissMsg.GetMLMessage(typeof(CtlFall).Name, "AccessDeniedToPerson", "Sie besitzen keine Rechte, das Dossier dieser Person anzuzeigen.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                message = KissMsg.GetMLMessage(typeof(CtlFall).Name, "ErrorShowModule", "Fehler bei der Verarbeitung. Die Person kann nicht angezeigt werden.", ex);
                return false;
            }
            return true;
        }
    }
}