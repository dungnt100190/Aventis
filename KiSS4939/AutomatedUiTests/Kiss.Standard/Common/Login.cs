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
    /// The Login recording.
    /// </summary>
    [TestModule("07b90122-51cd-4c3a-81e4-67b195fd140d", ModuleType.Recording, 1)]
    public partial class Login : ITestModule
    {
        /// <summary>
        /// Holds an instance of the AutomatedUiTests.AutomatedUiTestsRepository repository.
        /// </summary>
        public static AutomatedUiTests.AutomatedUiTestsRepository repo = AutomatedUiTests.AutomatedUiTestsRepository.Instance;

        static Login instance = new Login();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Login()
        {
            varUsername = "tab";
            varPassword = "Ki$$2013";
            varEnvironmentFilter = "KiSS_Standard";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static Login Instance
        {
            get { return instance; }
        }

#region Variables

        string _varUsername;

        /// <summary>
        /// Gets or sets the value of variable varUsername.
        /// </summary>
        [TestVariable("99cb91a5-b774-4fab-acc0-91136f857dda")]
        public string varUsername
        {
            get { return _varUsername; }
            set { _varUsername = value; }
        }

        string _varPassword;

        /// <summary>
        /// Gets or sets the value of variable varPassword.
        /// </summary>
        [TestVariable("2c2530f5-c515-48cf-98e6-92d0fddcfaa6")]
        public string varPassword
        {
            get { return _varPassword; }
            set { _varPassword = value; }
        }

        string _varEnvironmentFilter;

        /// <summary>
        /// Gets or sets the value of variable varEnvironmentFilter.
        /// </summary>
        [TestVariable("9114814b-57d9-4364-9f11-e5bc43dd3132")]
        public string varEnvironmentFilter
        {
            get { return _varEnvironmentFilter; }
            set { _varEnvironmentFilter = value; }
        }

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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left DoubleClick item 'FrmLogin.edtFilterEnvironments' at Center.", repo.FrmLogin.edtFilterEnvironmentsInfo, new RecordItemIndex(0));
            repo.FrmLogin.edtFilterEnvironments.DoubleClick();
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable $varEnvironmentFilter with focus on 'FrmLogin.edtFilterEnvironments'.", repo.FrmLogin.edtFilterEnvironmentsInfo, new RecordItemIndex(1));
            repo.FrmLogin.edtFilterEnvironments.PressKeys(varEnvironmentFilter);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'FrmLogin.edtEnvironment_DropDown' at Center.", repo.FrmLogin.edtEnvironment_DropDownInfo, new RecordItemIndex(2));
            repo.FrmLogin.edtEnvironment_DropDown.Click();
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'FrmLogin_edtEnvironment_Popup.edtEnvironment_FirstItem' at Center.", repo.FrmLogin_edtEnvironment_Popup.edtEnvironment_FirstItemInfo, new RecordItemIndex(3));
            repo.FrmLogin_edtEnvironment_Popup.edtEnvironment_FirstItem.Click();
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'FrmLogin.rbtBenutzerIn' at Center.", repo.FrmLogin.rbtBenutzerInInfo, new RecordItemIndex(4));
            repo.FrmLogin.rbtBenutzerIn.Click();
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left DoubleClick item 'FrmLogin.edtUser' at Center.", repo.FrmLogin.edtUserInfo, new RecordItemIndex(5));
            repo.FrmLogin.edtUser.DoubleClick();
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable $varUsername with focus on 'FrmLogin.edtUser'.", repo.FrmLogin.edtUserInfo, new RecordItemIndex(6));
            repo.FrmLogin.edtUser.PressKeys(varUsername);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left DoubleClick item 'FrmLogin.edtPassword' at Center.", repo.FrmLogin.edtPasswordInfo, new RecordItemIndex(7));
            repo.FrmLogin.edtPassword.DoubleClick();
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable $varPassword with focus on 'FrmLogin.edtPassword'.", repo.FrmLogin.edtPasswordInfo, new RecordItemIndex(8));
            repo.FrmLogin.edtPassword.PressKeys(varPassword);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'FrmLogin.btnAnmelden' at Center.", repo.FrmLogin.btnAnmeldenInfo, new RecordItemIndex(9));
            repo.FrmLogin.btnAnmelden.Click();
            
            Report.Log(ReportLevel.Info, "Validation", "Validating Exists on item 'KiSS.Toolbar.FallNavigator'.", repo.KiSS.Toolbar.FallNavigatorInfo, new RecordItemIndex(10));
            Validate.Exists(repo.KiSS.Toolbar.FallNavigatorInfo);
            
        }

#region Image Feature Data
#endregion
    }
}