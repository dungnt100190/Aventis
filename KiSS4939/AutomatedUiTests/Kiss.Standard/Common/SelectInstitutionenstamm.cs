﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

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
using Ranorex.Core.Repository;

namespace AutomatedUiTests.Common
{
    /// <summary>
    /// The SelectInstitutionenstamm recording.
    /// </summary>
    [TestModule("4d01f314-bdbd-40a8-8eb6-6ccbb0e034be", ModuleType.Recording, 1)]
    public partial class SelectInstitutionenstamm : ITestModule
    {
        /// <summary>
        /// Holds an instance of the AutomatedUiTests.AutomatedUiTestsRepository repository.
        /// </summary>
        public static AutomatedUiTests.AutomatedUiTestsRepository repo = AutomatedUiTests.AutomatedUiTestsRepository.Instance;

        static SelectInstitutionenstamm instance = new SelectInstitutionenstamm();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectInstitutionenstamm()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SelectInstitutionenstamm Instance
        {
            get { return instance; }
        }

#region Variables

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "4.1.4")]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "4.1.4")]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;

            Init();

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'KiSS.Toolbar.InstitutionenStamm' at Center.", repo.KiSS.Toolbar.InstitutionenStammInfo, new RecordItemIndex(0));
            repo.KiSS.Toolbar.InstitutionenStamm.Click();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating Exists on item 'KiSS.Forms.FrmInstitutionenStamm'.", repo.KiSS.Forms.FrmInstitutionenStammInfo, new RecordItemIndex(1));
            Validate.Exists(repo.KiSS.Forms.FrmInstitutionenStammInfo);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
}
