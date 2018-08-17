/*
 * Created by Ranorex
 * User: rcxp
 * Date: 01.07.2013
 * Time: 17:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using KiSS4.Gui;
using KiSS4.Main;

namespace AutomatedUiTests.Common
{
    /// <summary>
    /// Description of SelectModul.
    /// </summary>
    [TestModule("AC648788-A08A-4013-9961-CEEDBF0F5D3B", ModuleType.UserCode, 1)]
    public class SelectModul : ITestModule
    {
        /// <summary>
        /// Holds an instance of the AutomatedUiTests.AutomatedUiTestsRepository repository.
        /// </summary>
        public static AutomatedUiTests.AutomatedUiTestsRepository repo = AutomatedUiTests.AutomatedUiTestsRepository.Instance;

        string _varModulID = "1";
        [TestVariable("0DA03612-26D9-4C20-A41A-794228D380FA")]
        public string varModulID
        {
        	get { return _varModulID; }
        	set { _varModulID = value; }
        }
        
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectModul()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            //try to select the required modul
            var parameters = new object[1];
            parameters[0] = string.Format(CtlFall.TAB_PAGE_NAME_PATTERN, varModulID);
            repo.KiSS.FrmFallbearbeitung.TabModulTree.InvokeMethod("SelectTab", parameters);
        }
    }
}
