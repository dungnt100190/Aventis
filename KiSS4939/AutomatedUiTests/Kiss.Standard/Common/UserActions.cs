/*
 * Created by Ranorex
 * User: rcxp
 * Date: 02.07.2013
 * Time: 14:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;

using Ranorex;
	
using KiSS4.Gui;
using KiSS4.Main;

namespace AutomatedUiTests.Common
{
	/// <summary>
	/// Description of BaseModule.
	/// </summary>
	public class UserActions
	{
        private static AutomatedUiTests.AutomatedUiTestsRepository repository = AutomatedUiTests.AutomatedUiTestsRepository.Instance;

        public static void FrmFallbearbeitung_SelectModul(string modulID)
		{
            //try to select the required modul
            var parameters = new object[1];
            parameters[0] = string.Format(CtlFall.TAB_PAGE_NAME_PATTERN, modulID);
            repository.KiSS.FrmFallbearbeitung.TabModulTree.InvokeMethod("SelectTab", parameters);
		}
		
		public static void SelectTab(Control tabControl, string tabPageName)
		{
            var parameters = new object[1];
            parameters[0] = tabPageName;
			tabControl.InvokeMethod("SelectTab", parameters);
		}
		
        public static void SelectBezugsperson(string nameBezugsperson, string vornameBezugsperson)
        {
        	var cell = repository.KiSS.FrmFallbearbeitung.Modul_B.ModulTree_Basis.FindSingle<Ranorex.Cell>(string.Format(".//cell[@accessiblevalue='{0}, {1}']", nameBezugsperson, vornameBezugsperson));
        	cell.Click();
        }
        
        public static void FallNavigator_SelectFall(string nameFalltraeger, string vornameFalltraeger, string modulID)
        {
        	switch (modulID) {
        		case "1":
        			modulID = "2";
        			break;
        		case "2":
        			modulID = "3";
        			break;
        		case "3":
        			modulID = "4";
        			break;
        		case "4":
        			modulID = "5";
        			break;
        		case "5":
        			modulID = "6";
        			break;
        		case "6":
        			modulID = "7";
        			break;
        		case "7":
        			modulID = "8";
        			break;
        	}
        	/*
        	 * .//cell[@Text='{0} {1}']  --Zellen unterhalb des parents, in beliebiger Tiefe, @Text muss so etwas wie "Name Vorname" sein
        	 * /..                       --davon den Parent (also die Row)
        	 * /cell[{2}]   			 --dann die x-te Zelle (Spalte)
        	 */
        	var rxPath = string.Format(".//cell[@Text='{0} {1}']/../cell[{2}]", nameFalltraeger, vornameFalltraeger, modulID);
        	var cell = repository.KiSS.Forms.FrmFallNavigator.FindSingle<Ranorex.Cell>(rxPath);
        	cell.Click();
        }
        
        public static void GotoFall_ShowFall(string modulId)
        {
        	var parameters = new object[1];
        	parameters[0] = Convert.ToInt32(modulId);
        	repository.KiSS.FrmDatenExplorer.CtlGotoFall.CtlGotoFall.InvokeMethod("ShowFall", parameters);
        }
	}
}
