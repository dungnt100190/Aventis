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

namespace AutomatedUiTests.Fallfuehrung
{
    /// <summary>
    /// The BesprechungErfassen recording.
    /// </summary>
    [TestModule("698e9767-57a9-4910-b43d-b9ecb0820c75", ModuleType.Recording, 1)]
    public partial class BesprechungErfassen : ITestModule
    {
        /// <summary>
        /// Holds an instance of the AutomatedUiTests.AutomatedUiTestsRepository repository.
        /// </summary>
        public static AutomatedUiTests.AutomatedUiTestsRepository repo = AutomatedUiTests.AutomatedUiTestsRepository.Instance;

        static BesprechungErfassen instance = new BesprechungErfassen();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public BesprechungErfassen()
        {
            varNameKontaktpartner = "Testfall";
            varVornameKontaktpartner = "Neuer Fall1";
            varUserNameVorname = "Bedag, Support";
            varStichwort = "Test Stichwort";
            varThema1 = "Wohnen";
            varThema2 = "Finanzen/Administration";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static BesprechungErfassen Instance
        {
            get { return instance; }
        }

#region Variables

        string _varNameKontaktpartner;

        /// <summary>
        /// Gets or sets the value of variable varNameKontaktpartner.
        /// </summary>
        [TestVariable("2c8d42a9-6813-454e-ab4c-a9c6ae9e8491")]
        public string varNameKontaktpartner
        {
            get { return _varNameKontaktpartner; }
            set { _varNameKontaktpartner = value; }
        }

        string _varVornameKontaktpartner;

        /// <summary>
        /// Gets or sets the value of variable varVornameKontaktpartner.
        /// </summary>
        [TestVariable("d65e1796-933d-4d25-8066-8615cb9f1ae2")]
        public string varVornameKontaktpartner
        {
            get { return _varVornameKontaktpartner; }
            set { _varVornameKontaktpartner = value; }
        }

        string _varUserNameVorname;

        /// <summary>
        /// Gets or sets the value of variable varUserNameVorname.
        /// </summary>
        [TestVariable("82189ecb-2c7f-42a3-9ec1-7854db129d35")]
        public string varUserNameVorname
        {
            get { return _varUserNameVorname; }
            set { _varUserNameVorname = value; }
        }

        string _varStichwort;

        /// <summary>
        /// Gets or sets the value of variable varStichwort.
        /// </summary>
        [TestVariable("f04d0049-d4ca-4554-b4bd-1bd4f2e266f1")]
        public string varStichwort
        {
            get { return _varStichwort; }
            set { _varStichwort = value; }
        }

        string _varThema1;

        /// <summary>
        /// Gets or sets the value of variable varThema1.
        /// </summary>
        [TestVariable("e4641d40-07a9-47c8-8c14-582b85917068")]
        public string varThema1
        {
            get { return _varThema1; }
            set { _varThema1 = value; }
        }

        string _varThema2;

        /// <summary>
        /// Gets or sets the value of variable varThema2.
        /// </summary>
        [TestVariable("f3957cad-6698-4ec6-a355-aaed5a7f5768")]
        public string varThema2
        {
            get { return _varThema2; }
            set { _varThema2 = value; }
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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung' at 36;9.", repo.KiSS.FrmFallbearbeitung.Modul_F.BesprechungInfo, new RecordItemIndex(0));
            repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung.Click("36;9");
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{F5}' with focus on 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung'.", repo.KiSS.FrmFallbearbeitung.Modul_F.BesprechungInfo, new RecordItemIndex(1));
            repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung.PressKeys("{F5}");
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeContains (Text>$varNameKontaktpartner) on item 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Kontaktpartner'.", repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.KontaktpartnerInfo, new RecordItemIndex(2));
            Validate.Attribute(repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.KontaktpartnerInfo, "Text", new Regex(Regex.Escape(varNameKontaktpartner)));
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeContains (Text>$varVornameKontaktpartner) on item 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Kontaktpartner'.", repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.KontaktpartnerInfo, new RecordItemIndex(3));
            Validate.Attribute(repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.KontaktpartnerInfo, "Text", new Regex(Regex.Escape(varVornameKontaktpartner)));
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (EditValue=$varUserNameVorname) on item 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Autor'.", repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.AutorInfo, new RecordItemIndex(4));
            Validate.Attribute(repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.AutorInfo, "EditValue", varUserNameVorname);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Stichwort' at 92;5.", repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.StichwortInfo, new RecordItemIndex(5));
            repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Stichwort.Click("92;5");
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence from variable $varStichwort with focus on 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Stichwort'.", repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.StichwortInfo, new RecordItemIndex(6));
            repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Stichwort.PressKeys(varStichwort);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Themen_Wohnen' at 11;8.", repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Themen_WohnenInfo, new RecordItemIndex(7));
            repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Themen_Wohnen.Click("11;8");
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Themen_FinanzenAdministration' at 10;6.", repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Themen_FinanzenAdministrationInfo, new RecordItemIndex(8));
            repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.PanDetail.Themen_FinanzenAdministration.Click("10;6");
            
            Report.Log(ReportLevel.Info, "Keyboard", "Key sequence '{F2}'.", new RecordItemIndex(9));
            Keyboard.Press("{F2}");
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Text=$varStichwort) on item 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.SelectedRow.Stichwort'.", repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.SelectedRow.StichwortInfo, new RecordItemIndex(10));
            Validate.Attribute(repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.SelectedRow.StichwortInfo, "Text", varStichwort);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeContains (Text>$varThema1) on item 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.SelectedRow.Themen'.", repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.SelectedRow.ThemenInfo, new RecordItemIndex(11));
            Validate.Attribute(repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.SelectedRow.ThemenInfo, "Text", new Regex(Regex.Escape(varThema1)));
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeContains (Text>$varThema2) on item 'KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.SelectedRow.Themen'.", repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.SelectedRow.ThemenInfo, new RecordItemIndex(12));
            Validate.Attribute(repo.KiSS.FrmFallbearbeitung.Modul_F.Besprechung_Folder.SelectedRow.ThemenInfo, "Text", new Regex(Regex.Escape(varThema2)));
            
        }

#region Image Feature Data
#endregion
    }
}