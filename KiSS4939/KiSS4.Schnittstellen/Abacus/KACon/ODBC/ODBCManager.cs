using System;
using System.Collections;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Data.Odbc;

namespace KiSS4.Schnittstellen.Abacus.KACon.ODBC
{
	public abstract class ODBCManager
	{
		#region System Related ODBC Settings

		/******************************************************
		 * operating system related options
		 * tested with Server2k3,XP
		 * other systems may require changes here
		 * 
		 * Registry-keys for user/system-dsn-entries
		 ******************************************************/
		private const String ODBC = "SOFTWARE\\ODBC\\";
		private const String ODBC_INI = ODBC + "ODBC.INI\\";
		private const String DSN_LOC = ODBC_INI + "ODBC Data Sources\\";
		private const String ODBCINST_INI = ODBC + "ODBCINST.INI\\";
		private const String ODBC_DRIVERS = ODBCINST_INI + "ODBC Drivers\\";

		private const String KiSS_DSN_Prefix = "ABACUS";

		#endregion

		#region Constructor

		private ODBCManager()
		{
		}

		#endregion construction

		#region Public

		#region System / DSN-Handling

		public static void OpenSystemManager()
		{
			try
			{
				String name = String.Format(@"{0}\odbcad32.exe", Environment.GetFolderPath(Environment.SpecialFolder.System));

				ProcessStartInfo startInfo = new ProcessStartInfo(name);
				Process.Start(startInfo);
			}
			catch
			{
			}
		}

		public static void SetAbaDrive(string AbacusMainFolder)
		{
			try
			{
				DirectoryInfo di = new DirectoryInfo(AbacusMainFolder);

				if (!di.Exists)
				{
					return;
				}

				DirectoryInfo[] directories = di.GetDirectories();
				Boolean check = false;

				for (Int32 i = 0; i < directories.Length; i++)
				{
					if (directories[i].Name.ToUpper() == "DF")
					{
						check = true;
						break;
					}
				}

				if (!check)
				{
					return;
				}

				ProcessStartInfo startInfo = new ProcessStartInfo(di.FullName + @"\DF\SetAbaDrive.exe /yes");
				Process.Start(startInfo);
			}
			catch
			{
			}
		}

		private static String AbaLogin(String AbacusMainFolder, String Username, String Password)
		{
			String result = String.Empty;
			DirectoryInfo di = new DirectoryInfo(AbacusMainFolder);

			if (!di.Exists)
			{
				return String.Format("Error: Directory \"{0}\" not found!", di.FullName);
			}

			DirectoryInfo[] directories = di.GetDirectories();

			Boolean check = false;
			for (Int32 i = 0; i < directories.Length; i++)
			{
				if (directories[i].Name.ToUpper() == "DF")
				{
					check = true;
					break;
				}
			}

			if (!check)
			{
				return String.Format("Error: Directory \"{0}\\DF\" not found!", di.FullName);
			}

			if (Username == null)
			{
				return ("Error: Username cannot be null!");
			}
			if (Username == "")
			{
				return ("Error: Username cannot be empty!");
			}
			if (Password == null)
			{
				return ("Error: Password cannot be null!");
			}
			if (Password == "")
			{
				return ("Error: Password cannot be empty!");
			}

			Directory.SetCurrentDirectory(di.FullName + @"\DF\");
			ProcessStartInfo startInfo = new ProcessStartInfo("AbaLogin.exe", "/login /user=" + Username + " /pw=" + Password);
			Process.Start(startInfo);

			//freeze for a sec, AbaLogin.exe needs a little bit of time
			System.Threading.Thread.Sleep(2000);

			return null;
		}

		private static String AbaLogout(String AbacusMainFolder)
		{
			DirectoryInfo di = new DirectoryInfo(AbacusMainFolder);
			if (!di.Exists)
			{
				return String.Format("Error: Directory \"{0}\" not found!", di.FullName);
			}

			DirectoryInfo[] directories = di.GetDirectories();

			Boolean check = false;
			for (Int32 i = 0; i < directories.Length; i++)
			{
				if (directories[i].Name.ToUpper() == "DF")
				{
					check = true;
					break;
				}
			}

			if (!check)
			{
				return String.Format("Error: Directory \"{0}\\DF\" not found!", di.FullName);
			}

			Directory.SetCurrentDirectory(di.FullName + @"\DF\");
			ProcessStartInfo startInfo = new ProcessStartInfo("AbaLogin.exe", "/logout");
			Process.Start(startInfo);

			System.Threading.Thread.Sleep(2000);

			return null;
		}

		public static ODBCDriver[] GetAllODBCDrivers()
		{
			ArrayList driversList = new ArrayList();
			ODBCDriver[] odbcDrivers = null;

			RegistryKey odbcDrvLocKey = OpenComplexSubKey(Registry.LocalMachine, ODBC_DRIVERS, false);

			if (odbcDrvLocKey != null)
			{
				String[] driverNames = odbcDrvLocKey.GetValueNames();
				odbcDrvLocKey.Close();
				if (driverNames != null)
				{
					foreach (String driverName in driverNames)
					{
						ODBCDriver odbcDriver = GetODBCDriver(driverName);
						if (odbcDriver != null)
						{
							driversList.Add(odbcDriver);
						}
					}

					if (driversList.Count > 0)
					{
						odbcDrivers = new ODBCDriver[driversList.Count];
						driversList.CopyTo(odbcDrivers, 0);
					}
				}
			}

			return odbcDrivers;
		}

		public static ODBCDriver GetODBCDriver(String driverName)
		{
			try
			{
				Int32 i = 0;
				ODBCDriver odbcDriver = null;
				String[] driverElements = null;
				String[] driverElmVals = null;
				RegistryKey driverNameKey = null;

				driverNameKey = OpenComplexSubKey(Registry.LocalMachine, ODBCINST_INI + driverName, false);

				if (driverNameKey != null)
				{
					driverElements = driverNameKey.GetValueNames();
					driverElmVals = new String[driverElements.Length];

					foreach (String driverElement in driverElements)
					{
						driverElmVals[i] = driverNameKey.GetValue(driverElement).ToString();
						i++;
					}

					odbcDriver = ODBCDriver.ParseForDriver(driverName, driverElements, driverElmVals);
					driverNameKey.Close();
				}
				return odbcDriver;
			}
			catch
			{
				return null;
			}
		}

		public static ODBCDriver GetAbacusDriver()
		{
			try
			{
				ODBCDriver[] drivers = GetAllODBCDrivers();

				for (Int32 i = 0; i < drivers.Length; i++)
				{
					if (drivers[i].IsValidAbacusDriver)
					{
						return drivers[i];
					}
				}

				return null;
			}
			catch
			{
				return null;
			}
		}

		public static ODBCDSN[] GetSystemDSNList()
		{
			ODBCDSN[] dsnList = GetDSNList(Registry.LocalMachine);

			for (Int32 i = 0; i < dsnList.Length; i++)
			{
				dsnList[i].DSNType = ODBCDSN.eDSNType.System;
			}

			return dsnList;
		}

		public static ODBCDSN GetSystemDSN(String dsnName)
		{
			return GetDSN(Registry.LocalMachine, dsnName);
		}

		public static Boolean DropSystemDSN(String dsnName)
		{
			return DropDSN(Registry.LocalMachine, dsnName);
		}

		public static ODBCDSN[] GetUserDSNList()
		{
			ODBCDSN[] dsnList = GetDSNList(Registry.CurrentUser);

			for (Int32 i = 0; i < dsnList.Length; i++)
			{
				dsnList[i].DSNType = ODBCDSN.eDSNType.User;
			}

			return dsnList;
		}

		public static ODBCDSN GetUserDSN(String dsnName)
		{
			return GetDSN(Registry.CurrentUser, dsnName);
		}

		public static Boolean DropUserDSN(String dsnName)
		{
			return DropDSN(Registry.CurrentUser, dsnName);
		}

		public static ODBCDSN[] GetDSNContaining(String pattern)
		{
			try
			{
				//check dsn name with keywords, dsn is valid if its name contains ALL keywords
				ODBCDSN[] systemDSNs = GetSystemDSNList();
				ODBCDSN[] userDSNs = GetUserDSNList();
				ODBCDSN[] allDSNs = new ODBCDSN[systemDSNs.Length + userDSNs.Length];

				systemDSNs.CopyTo(allDSNs, 0);
				userDSNs.CopyTo(allDSNs, systemDSNs.Length);

				if (pattern != null)
				{
					if (pattern != "")
					{
						System.Collections.Generic.List<ODBCDSN> list = new System.Collections.Generic.List<ODBCDSN>();

						Char[] sep = { ';' };
						String[] keywords = pattern.Split(sep);

						for (Int32 dsn = 0; dsn < allDSNs.Length; dsn++)
						{
							Boolean keyFound = true;

							for (Int32 keyword = 0; keyword < keywords.Length; keyword++)
							{
								Debug.WriteLine(allDSNs[dsn].DSNName + " " + keywords[keyword]);
								if (!allDSNs[dsn].DSNName.Contains(keywords[keyword]))
								{
									keyFound = false;
									break;
								}
							}

							if (keyFound)
							{
								list.Add(allDSNs[dsn]);
							}
						}
						if (list.Count > 0)
						{
							return list.ToArray();
						}
						else
						{
							return null;
						}
					}
				}
				return null;
			}
			catch
			{

				return null;
			}
		}

		//Abacus will searching the client number at the end of DSN name
		public static ODBCDSN[] GetDSNEndingWith(String pattern)
		{
			try
			{
				//check dsn name with keywords, dsn is valid if its name contains ALL keywords
				ODBCDSN[] systemDSNs = GetSystemDSNList();
				ODBCDSN[] userDSNs = GetUserDSNList();
				ODBCDSN[] allDSNs = new ODBCDSN[systemDSNs.Length + userDSNs.Length];

				systemDSNs.CopyTo(allDSNs, 0);
				userDSNs.CopyTo(allDSNs, systemDSNs.Length);

				if (pattern != null)
				{
					if (pattern != "")
					{
						System.Collections.Generic.List<ODBCDSN> list = new System.Collections.Generic.List<ODBCDSN>();

						for (Int32 dsn = 0; dsn < allDSNs.Length; dsn++)
						{
							if (allDSNs[dsn].DSNName.EndsWith(pattern))
							{
								list.Add(allDSNs[dsn]);
							}
						}
						if (list.Count > 0)
						{
							return list.ToArray();
						}
						else
						{
							return null;
						}
					}
				}
				return null;
			}
			catch
			{

				return null;
			}
		}

		public static Boolean DropDSN(ODBCDSN dsn)
		{
			try
			{
				if (dsn.DSNType == ODBCDSN.eDSNType.System)
				{
					DropSystemDSN(dsn.DSNName);
				}

				if (dsn.DSNType == ODBCDSN.eDSNType.User)
				{
					DropUserDSN(dsn.DSNName);
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public static ODBCDSN CreateAbacusDSN(String AbacusPath, Int32 Mandant)
		{
			// we do not create the dsn anymore, because we use new strange abacus-pervasive-driver
			// >> throw error and do not continue!
			throw new NullReferenceException(String.Format("The desired DSN entry for current path '{0}' and number '{1}' does not exist, please contact your administrator.", AbacusPath, Mandant));

			/*
			driver example:
			ODBCDriverName: Abacus ODBC Driver (*.dat) 32bit
			APILevel: 2
			ConnectFunctions: YYY
			Driver: C:\WINDOWS\system32\abaeng32.dll
			DriverODBCVersion: 02.10
			FileExtensions: 
			FileUsage: 1
			SetUp: C:\WINDOWS\system32\abacfg32.dll
			SQLLevel: 0
			UsageCount: 2
			CPTimeOut: <not pooled>
			PdxUnInstall: 
			AdditionalProperties: 
			IsValidAbacusDriver: True
			 
			DSN example: 
			Name: ABACUS7777
			Driver: Abacus ODBC Driver (*.dat) 32bit
			Description: ABACUS7777
			ServerName: 
			DriverBinary: C:\WINDOWS\system32\abaeng32.dll
			REG_ODBC_INI: HKEY_CURRENT_USER\SOFTWARE\ODBC\ODBC.INI\
			REG_ODBC_DSN: HKEY_CURRENT_USER\SOFTWARE\ODBC\ODBC.INI\ABACUS7777
			AdditionalProperties: 
			*/
		}

		#endregion System

		#region Data

		public static DataSet GetAbacusLohnData(String odbcUser, String odbcPw, String abacusFolder, Int32 lohnMandant, String sqlString)
		{
			// create dsn-name (e.g. "Abacus7777")
			String dsnName = String.Format("{0}{1}", KiSS_DSN_Prefix, lohnMandant);
			
			// first try to get from UserDSN
			ODBCDSN DSN = GetUserDSN(dsnName);

			// check if success
			if (DSN == null)
			{
				// not found, try to get from SystemDSN
				DSN = GetSystemDSN(dsnName);
			}

			// check if user/system was found
			if (DSN == null)
			{
				// we do not create the dsn anymore, because we use new strange abacus-pervasive-driver
				// >> throw error and do not continue!
				throw new NullReferenceException(String.Format("The desired (user and system) DSN entry '{0}' for current path '{1}' and number '{2}' does not exist, please contact your administrator.", dsnName, abacusFolder, lohnMandant));

				// create new abacus-dsn
				//DSN = CreateAbacusDSN(abacusFolder, lohnMandant);
			}

			// DSN found, open connection on dsn-entry
			OdbcConnection con = new OdbcConnection();
			con.ConnectionString = "DSN=" + DSN.DSNName + ";UID=" + odbcUser + ";PWD=" + odbcPw + ";";

			try
			{
				con.Open();
			}
			catch (Exception conEx)
			{
				throw conEx;
			}

			OdbcDataAdapter oda = new OdbcDataAdapter();
			OdbcCommand cmd = new OdbcCommand();
			cmd.Connection = con;
			cmd.CommandTimeout = 0;
			oda.SelectCommand = cmd;

			DataSet dsResult = new DataSet();

			String strProcedure = sqlString;
			String TableMapping = null;

			try
			{
				cmd.CommandText = strProcedure;

				if (TableMapping == null)
				{
					TableMapping = "Table" + (dsResult.Tables.Count + 1).ToString();
				}

				Int32 result = oda.Fill(dsResult, TableMapping);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				TableMapping = null;
				strProcedure = "";
			}

			if (con.State != ConnectionState.Closed)
			{
				con.Close();
			}

			return dsResult;
		}

		#endregion

		#endregion

		#region Private

		private static ODBCDSN[] GetDSNList(RegistryKey baseKey)
		{
			ArrayList dsnList = new ArrayList();
			ODBCDSN[] odbcDSNs = null;

			if (baseKey == null)
			{
				return null;
			}

			RegistryKey dsnNamesKey = OpenComplexSubKey(baseKey, DSN_LOC, false);

			if (dsnNamesKey != null)
			{
				String[] dsnNames = dsnNamesKey.GetValueNames();

				if (dsnNames != null)
				{
					foreach (String dsnName in dsnNames)
					{
						ODBCDSN odbcDSN = GetDSN(baseKey, dsnName);

						if (odbcDSN != null)
						{
							dsnList.Add(odbcDSN);
						}
					}

					if (dsnList.Count > 0)
					{
						odbcDSNs = new ODBCDSN[dsnList.Count];
						dsnList.CopyTo(odbcDSNs, 0);
					}
				}

				dsnNamesKey.Close();
			}

			return odbcDSNs;
		}

		private static ODBCDSN GetDSN(RegistryKey baseKey, String dsnName)
		{
			try
			{
				Int32 j = 0;
				String dsnDriverName = null;
				RegistryKey dsnNamesKey = null;
				RegistryKey dsnNameKey = null;
				String[] dsnElements = null;
				String[] dsnElmVals = null;
				ODBCDSN odbcDSN = null;

				dsnNamesKey = OpenComplexSubKey(baseKey, DSN_LOC, false);

				if (dsnNamesKey != null)
				{
					Object o = dsnNamesKey.GetValue(dsnName);

					if (o != null)
					{
						dsnDriverName = dsnNamesKey.GetValue(dsnName).ToString();
						dsnNamesKey.Close();
					}
					else
					{
						return null;
					}
				}

				dsnNameKey = OpenComplexSubKey(baseKey, ODBC_INI + dsnName, false);

				if (dsnNameKey != null)
				{
					dsnElements = dsnNameKey.GetValueNames();

					// Create DSN Element values array.
					dsnElmVals = new String[dsnElements.Length];

					// For each element defined for a typical DSN get
					// its value.
					foreach (String dsnElement in dsnElements)
					{
						dsnElmVals[j] = dsnNameKey.GetValue(dsnElement).ToString();
						j++;
					}

					// Create ODBCDSN Object.
					odbcDSN = ODBCDSN.ParseForODBCDSN(dsnName, dsnDriverName, dsnElements, dsnElmVals);
					odbcDSN.REG_ODBC_DSN = baseKey.ToString() + "\\" + ODBC_INI + dsnName;
					odbcDSN.REG_ODBC_INI = baseKey.ToString() + "\\" + ODBC_INI;

					dsnNamesKey.Close();
				}

				return odbcDSN;
			}
			catch
			{
				return null;
			}
		}

		private static Boolean DropDSN(RegistryKey baseKey, String dsnName)
		{
			try
			{
				RegistryKey dsnLocation = OpenComplexSubKey(baseKey, DSN_LOC, true);

				if (dsnLocation == null)
				{
					return false;
				}

				RegistryKey dsnIni = OpenComplexSubKey(baseKey, ODBC_INI, true);

				if (dsnIni == null)
				{
					return false;
				}

				dsnLocation.DeleteValue(dsnName, false);
				dsnIni.DeleteSubKeyTree(dsnName);

				return true;
			}
			catch
			{
				return false;
			}
		}

		public static RegistryKey OpenComplexSubKey(RegistryKey baseKey, String complexKeyStr, Boolean writable)
		{
			Int32 prevLoc = 0, currLoc = 0;
			String subKeyStr = complexKeyStr;
			RegistryKey finalKey = baseKey;

			if (baseKey == null)
			{
				return null;
			}

			if (complexKeyStr == null)
			{
				return finalKey;
			}

			do
			{
				currLoc = complexKeyStr.IndexOf("\\", prevLoc);

				if (currLoc != -1)
				{
					subKeyStr = complexKeyStr.Substring(prevLoc, currLoc - prevLoc);
					prevLoc = currLoc + 1;
				}
				else
				{
					subKeyStr = complexKeyStr.Substring(prevLoc);
				}

				if (!subKeyStr.Equals(String.Empty))
				{
					finalKey = finalKey.OpenSubKey(subKeyStr, writable);
				}
			}
			while (currLoc != -1);

			return finalKey;
		}

		#endregion
	}
}
