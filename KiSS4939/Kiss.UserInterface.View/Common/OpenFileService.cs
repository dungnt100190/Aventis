using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Kiss.Interfaces.ViewModel;

using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

//using System.Windows.Forms;

namespace Kiss.UserInterface.View.Common
{
    public class OpenFileService : IOpenFileService
    {
        public string OpenFileDialog(string filter = null)
        {
            var fileDialog = new OpenFileDialog
                                 {
                                     Filter = filter,
                                     Multiselect = false
                                 };

            if (fileDialog.ShowDialog() == true)
            {
                return fileDialog.FileName;
            }
            return null;
        }
    }
}
