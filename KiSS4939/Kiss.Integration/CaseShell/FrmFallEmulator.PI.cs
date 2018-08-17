using System;
using System.Collections.Specialized;

using Kiss.Infrastructure;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Main.PI;

namespace Kiss.Integration.CaseShell
{
    partial class FrmFallEmulator
    {
        private bool ReceiveMessagePI(HybridDictionary param)
        {
            int? modulId = null;
            if (param.Contains("ModulID"))
            {
                modulId = (int)param["ModulID"];
            }

            // action depending
            switch (Convert.ToString(param["Action"]))
            {
                case "ShowFall":
                    return ShowModul(modulId);

                case "DisplayModul":
                    // TODO
                    // Show modul of current person
                    //DisplayModul(Convert.ToInt32(param["ModulID"]));
                    return true;

                case "RefreshTree":
                    if (_currentModulTree == null)
                    {
                        return false;
                    }

                    // refresh tree
                    _currentModulTree.Refresh();

                    // do special action on CltFaModulTree
                    FormController.SendMessage(_currentModulTree, "Action", "ValidateClosedItems");
                    FormController.SendMessage(_currentModulTree, "Action", "UpdateFVUserID");

                    // TODO
                    // update icons
                    //CtlFall ctlFall = GetCurrentCtlFall();

                    //if (ctlFall != null)
                    //{
                    //    ctlFall.RefreshFallIcons();
                    //}

                    return true;

                case "JumpToPath":
                    if (_currentModulTree != null)
                    {
                        return FormController.SendMessage(_currentModulTree, param);
                    }
                    return true;

                case "JumpToNodeByID":
                    if (_currentModulTree == null)
                    {
                        return false;
                    }

                    _currentModulTree.FocusedNode = _currentModulTree.KissTree.FindNodeByID(Convert.ToInt32(param["NodeID"]));
                    return true;

                case "JumpToNodeByFieldValue":
                    // check if we have a FieldName
                    if (!param.Contains("FieldName"))
                    {
                        // take ID as default if none is given
                        param["FieldName"] = "ID";
                    }

                    if (ShowModul(modulId))
                    {
                        if (_currentModulTree != null)
                        {
                            // try to find a focused node by fieldname and its fieldvalue
                            _currentModulTree.FocusedNode = _currentModulTree.KissTree.FindNodeByFieldValue(
                                Convert.ToString(param["FieldName"]),
                                param["FieldValue"]);

                            // check if we have a focused node
                            if (_currentModulTree.FocusedNode == null)
                            {
                                // node not found
                                return false;
                            }

                            // send message further on
                            _currentModulTree.DetailControl.ReceiveMessage(param);
                            return true;
                        }
                    }

                    return false;

                case "RefreshPersonInfoTitle":
                    // Refresh name of person shown in CtlFall
                    if (_currentModulTree == null)
                    {
                        return false;
                    }

                    // TODO
                    //ctlFall = GetCurrentCtlFall();

                    //if (ctlFall != null)
                    //{
                    //    ctlFall.SetPersonInfoTitel();
                    //    return true;
                    //}
                    return false;
            }

            // did not understand message
            return false;
        }

        private object ReturnMessagePI(HybridDictionary param)
        {
            // action depending
            switch (Convert.ToString(param["Action"]))
            {
                case "CurrentModulTree":
                    // get current modul tree
                    return _currentModulTree;
            }

            // did not understand message
            return null;
        }

        private bool ShowModulPI(int modulID, int baPersonID)
        {
            if (_currentModulTree == null)
            {
                return false;
            }

            try
            {
                // if the user has no rights to display this user, we show an exception
                if (!KiSS4.Common.PI.FaUtils.UserMayShowPersonDossier(baPersonID))
                {
                    //lblPersonName.Text = KissMsg.GetMLMessage("CtlFall", "AccessDeniedLabel", "Keine Rechte für dieses Dossier!");
                    KissMsg.ShowError(typeof(CtlFall).Name, "AccessDeniedToPerson", "Sie besitzen keine Rechte, das Dossier dieser Person anzuzeigen.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(typeof(CtlFall).Name, "ErrorShowModule", "Fehler bei der Verarbeitung. Die Person kann nicht angezeigt werden.", ex);
                return false;
            }

            switch (modulID)
            {
                case 1:
                    // select person node
                    var personNode = _currentModulTree.KissTree.FindNodeByKeyID("P" + baPersonID);

                    if (personNode != null)
                    {
                        _currentModulTree.FocusedNode = personNode;
                    }
                    return true;

                case 2:
                    modulID = 20011;
                    break;

                default:
                    modulID = modulID * 10000;
                    break;
            }

            var node = DBUtil.FindNodeByValue(_currentModulTree.KissTree.Nodes, modulID.ToString(), "ModulTreeID");

            if (node != null)
            {
                node.Expanded = true;
                _currentModulTree.FocusedNode = node;
                ApplicationFacade.DoEvents();
            }

            return true;
        }
    }
}