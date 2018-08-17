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

namespace AutomatedUiTests.Institutionen
{
    /// <summary>
    /// The InstitutionErfassen recording.
    /// </summary>
    [TestModule("f0a8eea2-e3c6-40dd-90bd-8561461ece86", ModuleType.Recording, 1)]
    public partial class InstitutionErfassen : ITestModule
    {
        /// <summary>
        /// Holds an instance of the AutomatedUiTests.AutomatedUiTestsRepository repository.
        /// </summary>
        public static AutomatedUiTests.AutomatedUiTestsRepository repo = AutomatedUiTests.AutomatedUiTestsRepository.Instance;

        static InstitutionErfassen instance = new InstitutionErfassen();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public InstitutionErfassen()
        {
            InstitutionName = "Ranorex";
            Strasse = "Teststrasse";
            HausNr = "1";
            PLZ = "3000";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static InstitutionErfassen Instance
        {
            get { return instance; }
        }

#region Variables

        string _InstitutionName;

        /// <summary>
        /// Gets or sets the value of variable InstitutionName.
        /// </summary>
        [TestVariable("90db8ed7-2483-4a03-a12a-f0793dd68b14")]
        public string InstitutionName
        {
            get { return _InstitutionName; }
            set { _InstitutionName = value; }
        }

        string _Strasse;

        /// <summary>
        /// Gets or sets the value of variable Strasse.
        /// </summary>
        [TestVariable("5cee634f-a08a-4b52-be34-79643058560b")]
        public string Strasse
        {
            get { return _Strasse; }
            set { _Strasse = value; }
        }

        string _HausNr;

        /// <summary>
        /// Gets or sets the value of variable HausNr.
        /// </summary>
        [TestVariable("a64ce4ab-1a8f-4327-b004-e6555e1c018b")]
        public string HausNr
        {
            get { return _HausNr; }
            set { _HausNr = value; }
        }

        string _PLZ;

        /// <summary>
        /// Gets or sets the value of variable PLZ.
        /// </summary>
        [TestVariable("5ae3941e-1516-4ee9-a7d1-b564801ddda4")]
        public string PLZ
        {
            get { return _PLZ; }
            set { _PLZ = value; }
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
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;

            Init();

            SelectTabListe();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{F5}' with focus on 'KiSS.FrmInstitutionenStamm'.", repo.KiSS.FrmInstitutionenStamm.SelfInfo, new RecordItemIndex(1));
            repo.KiSS.FrmInstitutionenStamm.Self.PressKeys("{F5}");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'KiSS.FrmInstitutionenStamm.ContainerEdit.edtInstName' at Center.", repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtInstNameInfo, new RecordItemIndex(2));
            repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtInstName.Click(100);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable $InstitutionName with focus on 'KiSS.FrmInstitutionenStamm.ContainerEdit.edtInstName'.", repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtInstNameInfo, new RecordItemIndex(3));
            repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtInstName.PressKeys(InstitutionName);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'KiSS.FrmInstitutionenStamm.ContainerEdit.edtStrasse' at Center.", repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtStrasseInfo, new RecordItemIndex(4));
            repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtStrasse.Click(100);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable $Strasse with focus on 'KiSS.FrmInstitutionenStamm.ContainerEdit.edtStrasse'.", repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtStrasseInfo, new RecordItemIndex(5));
            repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtStrasse.PressKeys(Strasse);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'KiSS.FrmInstitutionenStamm.ContainerEdit.edtHausNr' at Center.", repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtHausNrInfo, new RecordItemIndex(6));
            repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtHausNr.Click(100);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable $HausNr with focus on 'KiSS.FrmInstitutionenStamm.ContainerEdit.edtHausNr'.", repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtHausNrInfo, new RecordItemIndex(7));
            repo.KiSS.FrmInstitutionenStamm.ContainerEdit.edtHausNr.PressKeys(HausNr);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'KiSS.FrmInstitutionenStamm.ContainerEdit.EdtPLZ' at Center.", repo.KiSS.FrmInstitutionenStamm.ContainerEdit.EdtPLZInfo, new RecordItemIndex(8));
            repo.KiSS.FrmInstitutionenStamm.ContainerEdit.EdtPLZ.Click(100);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable $PLZ with focus on 'KiSS.FrmInstitutionenStamm.ContainerEdit.EdtPLZ'.", repo.KiSS.FrmInstitutionenStamm.ContainerEdit.EdtPLZInfo, new RecordItemIndex(9));
            repo.KiSS.FrmInstitutionenStamm.ContainerEdit.EdtPLZ.PressKeys(PLZ);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'KiSS.FrmInstitutionenStamm.ContainerEdit.EdtOrt' at Center.", repo.KiSS.FrmInstitutionenStamm.ContainerEdit.EdtOrtInfo, new RecordItemIndex(10));
            repo.KiSS.FrmInstitutionenStamm.ContainerEdit.EdtOrt.Click(100);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DlgAuswahl.ButtonOK' at Center.", repo.DlgAuswahl.ButtonOKInfo, new RecordItemIndex(11));
            repo.DlgAuswahl.ButtonOK.Click(100);
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{F2}' with focus on 'KiSS.FrmInstitutionenStamm'.", repo.KiSS.FrmInstitutionenStamm.SelfInfo, new RecordItemIndex(12));
            repo.KiSS.FrmInstitutionenStamm.Self.PressKeys("{F2}");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
}
