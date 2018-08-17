using System;
using System.Collections.Specialized;

using DevExpress.XtraTreeList.Nodes;

using KiSS4.Gui;

namespace Kiss.Integration.CaseShell
{
    partial class FrmFallEmulator
    {
        private bool ReceiveMessageStandard(HybridDictionary param)
        {
            int? modulId = null;
            if (param.Contains("ModulID"))
            {
                modulId = (int)param["ModulID"];
            }
            TreeListNode node;

            // action depending
            switch (param["Action"] as string)
            {
                case "ShowFall":
                    return ShowModul(modulId);

                case "RefreshControl":
                    // validate
                    if (_currentModulTree == null || _currentModulTree.DetailControl == null)
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
                    if (_currentModulTree == null)
                    {
                        return false;
                    }

                    _currentModulTree.Refresh();

                    // TODO
                    //CtlFall currentCtlFall = GetCurrentCtlFall();
                    //if (currentCtlFall != null)
                    //{
                    //    currentCtlFall.RefreshFallIcons();
                    //}
                    return true;

                case "JumpToPath":
                    if (ShowModul(modulId))
                    {
                        if (_currentModulTree != null)
                        {
                            return FormController.SendMessage(_currentModulTree, param);
                        }
                        return true;
                    }
                    return false;

                case "JumpToNodeByFieldValue":
                    if (!param.Contains("FieldName"))
                        param["FieldName"] = "ID";

                    if (ShowModul(modulId))
                    {
                        if (_currentModulTree == null)
                        {
                            return false;
                        }

                        node = _currentModulTree.KissTree.FindNodeByFieldValue(param["FieldName"] as string, param["FieldValue"]);
                        if (node == null)
                        {
                            return false;
                        }

                        _currentModulTree.FocusedNode = node;
                        return true;
                    }
                    return false;

                case "JumpToVermittlung":
                    if (!param.Contains("FieldName"))
                    {
                        param["FieldName"] = "ID";
                    }

                    if (_currentModulTree == null)
                    {
                        return false;
                    }

                    node = _currentModulTree.KissTree.FindNodeByFieldValue(param["FieldName"] as string, param["FieldValue"]);
                    if (node == null)
                    {
                        return false;
                    }

                    _currentModulTree.FocusedNode = node;

                    param["Action"] = "SelectRow";
                    FormController.SendMessage(_currentModulTree.DetailControl, param);

                    return true;

                case "JumpFromPendenzen":
                    if (!param.Contains("FieldName"))
                    {
                        param["FieldName"] = "ID";
                    }
                    if (!param.Contains("DokumenteID"))
                    {
                        return false;
                    }
                    if (!param.Contains("XTaskID"))
                    {
                        return false;
                    }
                    if (_currentModulTree != null)
                    {
                        _currentModulTree.FocusedNode = _currentModulTree.KissTree.FindNodeByFieldValue(param["FieldName"] as string, param["FieldValue"]);
                        _currentModulTree.DetailControl.ReceiveMessage(param);
                        return true;
                    }
                    return false;

                case "CloseFrmFall":
                    // TODO/do nothing?
                    return true;

                case "CloseActiveFall":
                    // TODO/do nothing?
                    return true;
            }

            return false;
        }

        private object ReturnMessageStandard(HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param.Count < 1)
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
                        // set BaPersonID as FaFallID (FaFall is no longer used, FaFallID = BaPersonID)
                        dic["FaFallID"] = dic["BaPersonID"];
                    }

                    // apply ClassName
                    dic["ClassName"] = "FrmFall";

                    // return dictionary
                    return dic;
            }

            // did not understand message, ask the DetailControl
            if (_currentModulTree.DetailControl != null)
            {
                return _currentModulTree.ReturnMessage(param);
            }

            return null;
        }
    }
}