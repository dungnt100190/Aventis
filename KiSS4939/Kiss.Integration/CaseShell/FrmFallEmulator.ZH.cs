using System;
using System.Collections.Specialized;

using KiSS4.DB;
using KiSS4.Gui;

namespace Kiss.Integration.CaseShell
{
    partial class FrmFallEmulator
    {
        private bool ReceiveMessageZH(HybridDictionary param)
        {
            if (_currentModulTree == null)
            {
                return false;
            }

            int? modulId = null;
            if (param.Contains("ModulID"))
            {
                modulId = (int)param["ModulID"];
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "ShowFall":
                    return ShowModul(modulId);

                case "RefreshControl":
                    // refresh detail control, get modulTree validate
                    if (_currentModulTree.DetailControl == null)
                    {
                        // invalid state
                        return false;
                    }

                    // check if we have a filter for ControlName
                    if (param.Contains("ControlName") && _currentModulTree.DetailControl.GetType().Name != Convert.ToString(param["ControlName"]))
                    {
                        // nothing more to do, control does not match
                        return true;
                    }

                    // get detail control
                    var detailControl = _currentModulTree.DetailControl;

                    // save pending changes first, to prevent loosing data
                    if (!detailControl.OnSaveData())
                    {
                        // data could not be saved
                        return false;
                    }

                    // refresh detailcontrol-data
                    detailControl.OnRefreshData();

                    // if we are here, everything is ok
                    return true;

                case "RefreshTree":
                    // Refresh tree of current, active Fall
                    _currentModulTree.Refresh();

                    // TODO
                    //ctlFall = this.GetCurrentCtlFall();
                    //if (ctlFall != null)
                    //{
                    //    ctlFall.RefreshFallIcons();
                    //}
                    return true;

                case "JumpToNodeByFieldValue":
                    if (!param.Contains("FieldName")) param["FieldName"] = "ID";

                    if (ShowModul(modulId))
                    {
                        _currentModulTree.FocusedNode = _currentModulTree.KissTree.FindNodeByFieldValue(param["FieldName"] as string, param["FieldValue"]);

                        if (_currentModulTree.DetailControl != null)
                        {
                            _currentModulTree.DetailControl.ReceiveMessage(param);
                        }
                        return true;
                    }
                    return false;

                case "JumpToZahlungsweg":
                    if (!param.Contains("FieldName")) param["FieldName"] = "ID";

                    if (ShowModul(modulId))
                    {
                        _currentModulTree.FocusedNode = _currentModulTree.KissTree.FindNodeByFieldValue(param["FieldName"] as string, param["FieldValue"]);
                        _currentModulTree.DetailControl.ReceiveMessage(param);
                        return true;
                    }
                    return false;

                case "JumpFromPendenzen":
                    if (!param.Contains("FieldName")) param["FieldName"] = "ID";
                    if (!param.Contains("DokumenteID")) return false;
                    if (!param.Contains("XTaskID")) return false;

                    if (ShowModul(modulId))
                    {
                        _currentModulTree.FocusedNode = _currentModulTree.KissTree.FindNodeByFieldValue(param["FieldName"] as string, param["FieldValue"]);
                        _currentModulTree.DetailControl.ReceiveMessage(param);
                        return true;
                    }
                    return false;

                case "JumpToPath":
                    if (ShowModul(modulId))
                    {
                        return FormController.SendMessage(_currentModulTree, param);
                    }
                    return false;

                case "CloseFrmFall":
                    // TODO
                    //this.Close();
                    break;
            }

            // did not understand message
            return false;
        }

        private object ReturnMessageZH(HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "CurrentModulTree":
                    // get current modul tree
                    return _currentModulTree;

                case "GetJumpToPath":
                    var dic = (HybridDictionary)FormController.GetMessage(_currentModulTree, param);
                    if (!dic.Contains("FaFallID") && dic.Contains("BaPersonID"))
                    {
                        dic["FaFallID"] = DBUtil.ExecuteScalarSQL(@"
                            SELECT TOP 1 FaFallID
                            FROM FaFall
                            WHERE BaPersonID = {0}
                            ORDER BY DatumVon DESC", dic["BaPersonID"]);
                    }
                    return dic;
            }

            return null;
        }
    }
}