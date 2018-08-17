using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using KiSS4.DB;

namespace KiSS4.DesignerHost
{
    public class MyNameCreationService : INameCreationService
    {
        private IServiceProvider serviceProvider;
        private INameCreationService nameCreationService;

        public MyNameCreationService(IServiceContainer serviceContainer)
        {
            this.serviceProvider = (IServiceProvider)serviceContainer;
            nameCreationService = (INameCreationService)serviceProvider.GetService(typeof(INameCreationService));
            serviceContainer.RemoveService(typeof(INameCreationService));
        }


        string INameCreationService.CreateName(IContainer container, Type dataType)
        {
            string baseName = dataType.Name;

            MyToolboxItem toolBoxItem = null;
            IToolboxService toolBox = (IToolboxService)serviceProvider.GetService(typeof(IToolboxService));
            if (toolBox != null)
                toolBoxItem = toolBox.GetSelectedToolboxItem() as MyToolboxItem;

			if (toolBoxItem == null || container == null)
			{
				return nameCreationService.CreateName(container, dataType);
			}

            if (dataType == typeof(Gui.KissLabel) && !DBUtil.IsEmpty(toolBoxItem.DataMember))
                baseName = "lbl" + toolBoxItem.DataMember;
            else if (!DBUtil.IsEmpty(toolBoxItem.DataMember))
                baseName = "edt" + toolBoxItem.DataMember;
            else if (typeof(Gui.KissGrid).IsAssignableFrom(dataType) && !DBUtil.IsEmpty(toolBoxItem.DisplayName))
                baseName = "grd" + toolBoxItem.DisplayName;
            else if (typeof(DevExpress.XtraGrid.Views.Base.BaseView).IsAssignableFrom(dataType) && !DBUtil.IsEmpty(toolBoxItem.DisplayName))
                baseName = "gvw" + toolBoxItem.DisplayName;
            else if (typeof(Gui.KissTree).IsAssignableFrom(dataType) && !DBUtil.IsEmpty(toolBoxItem.DisplayName))
                baseName = "tre" + toolBoxItem.DisplayName;
			
            int idx = 1;
            string finalName = baseName + (toolBoxItem != null ? "" : idx.ToString());
            while (container.Components[finalName] != null)
            {
                idx++;
                finalName = baseName + idx.ToString();
            }

            return finalName;
        }

        bool INameCreationService.IsValidName(string name)
        {
            return nameCreationService.IsValidName(name);
        }

        void INameCreationService.ValidateName(string name)
        {
            nameCreationService.ValidateName(name);
        }

    }
}
