using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

namespace Kiss.Integration
{
    public class UserControlFactory
    {
        private readonly ViewFactory _viewFactory;

        public UserControlFactory()
        {
            _viewFactory = new ViewFactory();
        }

        public static void SaveLayout(Control ctl)
        {
            var kissUserControl = ctl as KissUserControl;

            if (kissUserControl != null)
            {
                try
                {
                    kissUserControl.SaveLayout();
                }
                catch (LayoutException ex)
                {
                    KissMsg.ShowError("KissForm", "LayoutTeilweiseGespeichert", "Layout konnte teilweise nicht gespeichert werden.", ex);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("KissForm", "LayoutNichtGespeichert", "Layout konnte nicht gespeichert werden.", ex);
                }
            }

            ctl.SaveLayoutOfChildControls();
        }

        //TODO: ReturnValue auf Object und überall wo es gebraucht wird, dann mit as UserControl casten.
        public object Create(ControlCreationParameters creationParameters)
        {
            if (creationParameters.IsWpf)
            {
                var classId = _viewFactory.GetClassID(creationParameters.TypeName);
                if (classId != null)
                {
                    var initParameters = new InitParameters();

                    if (creationParameters.WpfInitParameters != null)
                    {
                        if (creationParameters.WpfInitParameters.ContainsKey("FaLeistungID"))
                        {
                            initParameters.FaLeistungID = creationParameters.WpfInitParameters["FaLeistungID"] as int?;
                        }
                        if (creationParameters.WpfInitParameters.ContainsKey("BaPersonID"))
                        {
                            initParameters.BaPersonID = creationParameters.WpfInitParameters["BaPersonID"] as int?;
                        }
                        if (creationParameters.WpfInitParameters.ContainsKey("Title"))
                        {
                            initParameters.Title = creationParameters.WpfInitParameters["Title"] as string;
                        }
                        if (creationParameters.WpfInitParameters.ContainsKey("FaFallID"))
                        {
                            initParameters.FaFallID = creationParameters.WpfInitParameters["FaFallID"] as int?;
                        }
                        if (creationParameters.WpfInitParameters.ContainsKey("CustomData"))
                        {
                            initParameters.CustomData = creationParameters.WpfInitParameters["CustomData"] as Dictionary<string, object>;
                        }
                    }

                    return _viewFactory.CreateView(classId.Value, initParameters);
                }
                return null;
            }

            var control = AssemblyLoader.CreateInstance(creationParameters.TypeName, creationParameters.ConstructorParameters ?? new object[] { });
            if (control == null)
            {
                // ToDo: Log invalid type name to db
                return null;
            }

            var methodInvocations = creationParameters.InitMethodInvocations;
            if (methodInvocations != null && methodInvocations.Any())
            {
                var controlType = control.GetType();
                foreach (var methodInvocation in methodInvocations)
                {
                    var method = controlType.GetMethod(methodInvocation.Key, methodInvocation.Value.Select(par => par.GetType()).ToArray());
                    method.Invoke(control, methodInvocation.Value);
                }
            }

            return control;
        }

        public DialogResult ShowDialog(ControlCreationParameters creationParameters)
        {
            var dialog = Create(creationParameters) as Form;

            if (dialog == null)
            {
                throw new InvalidOperationException(string.Format("Dialog mit ClassName '{0}' nicht gefunden.", creationParameters.TypeName));
            }

            return dialog.ShowDialog();
        }
    }
}