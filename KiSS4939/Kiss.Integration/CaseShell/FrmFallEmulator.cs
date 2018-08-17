using System.Collections.Specialized;

using Kiss.Interfaces.UI;

using KiSS4.Common;

namespace Kiss.Integration.CaseShell
{
    public partial class FrmFallEmulator
    {
        private static readonly InstallationInfo _installationInfo;
        private readonly KissModulTree _currentModulTree;

        static FrmFallEmulator()
        {
            _installationInfo = InstallationInfo.GetInstallationInfo();
        }

        public FrmFallEmulator(IViewMessaging currentModulTree)
        {
            _currentModulTree = currentModulTree as KissModulTree;
        }

        public static int ProcessModulId(int modulId)
        {
            if (_installationInfo.ProductType == ProductType.PI)
            {
                switch (modulId)
                {
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 31:
                        // AKV - Fallfuehrung
                        modulId = 2;
                        break;
                }
            }
            return modulId;
        }

        public bool ReceiveMessage(HybridDictionary param)
        {
            if (param == null || param.Count < 1)
            {
                return true;
            }

            switch (_installationInfo.ProductType)
            {
                case ProductType.Standard:
                    return ReceiveMessageStandard(param);

                case ProductType.PI:
                    return ReceiveMessagePI(param);

                case ProductType.ZH:
                    return ReceiveMessageZH(param);
            }

            return _currentModulTree.ReceiveMessage(param);
        }

        public object ReturnMessage(HybridDictionary param)
        {
            if (param == null || param.Count < 1)
            {
                return null;
            }

            object result = null;
            switch (_installationInfo.ProductType)
            {
                case ProductType.Standard:
                    result = ReturnMessageStandard(param);
                    break;

                case ProductType.PI:
                    result = ReturnMessagePI(param);
                    break;

                case ProductType.ZH:
                    result = ReturnMessageZH(param);
                    break;
            }

            return result ?? _currentModulTree.ReturnMessage(param);
        }

        /// <summary>
        /// Führt Tasks durch, die vorher in CtlFall.ShowModul()/ShowModule() nach dem Öffnen eines Modultrees gemacht wurden.
        /// </summary>
        public bool ShowModul(int? modulId)
        {
            modulId = modulId ?? _currentModulTree.ModulID;
            var baPersonID = _currentModulTree.BaPersonID;

            bool success = true;

            if (_installationInfo.ProductType == ProductType.PI)
            {
                success = ShowModulPI(modulId.Value, baPersonID);
            }

            if (success)
            {
                _currentModulTree.ShowDetail();
            }

            return success;
        }
    }
}