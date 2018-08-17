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
    /// The CloseKiSS recording.
    /// </summary>
    [TestModule("f39be5a9-9104-4609-a857-2ddaae381198", ModuleType.Recording, 1)]
    public partial class CloseKiSS : ITestModule
    {
        /// <summary>
        /// Holds an instance of the AutomatedUiTests.AutomatedUiTestsRepository repository.
        /// </summary>
        public static AutomatedUiTests.AutomatedUiTestsRepository repo = AutomatedUiTests.AutomatedUiTestsRepository.Instance;

        static CloseKiSS instance = new CloseKiSS();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CloseKiSS()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CloseKiSS Instance
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
            Mouse.DefaultMoveTime = 0;
            Keyboard.DefaultKeyPressTime = 20;
            Delay.SpeedFactor = 0.0;

            Init();

            Report.Log(ReportLevel.Info, "Application", "Closing application containing item 'KiSS'.", repo.KiSS.SelfInfo, new RecordItemIndex(0));
            Host.Local.CloseApplication(repo.KiSS.Self, 1000);
            
            try {
                Report.Log(ReportLevel.Info, "Application", "(Optional Action)\r\nKilling application containing item 'KiSS'.", repo.KiSS.SelfInfo, new RecordItemIndex(1));
                Host.Local.KillApplication(repo.KiSS.Self);
            } catch(Exception ex) { Report.Warn("(Optional Action) " + ex.Message); }
            
        }

#region Image Feature Data
#endregion
    }
}