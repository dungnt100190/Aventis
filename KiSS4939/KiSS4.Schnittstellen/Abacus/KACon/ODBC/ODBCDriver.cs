using System;

namespace KiSS4.Schnittstellen.Abacus.KACon.ODBC
{
	public class ODBCDriver
	{
		#region Fields

		//
		// Abacus ODBC relates options
		// set value = null to skip it
		//
		//driver name to find out existing
		private const String AbacusODBCDriverName = "Abacus ODBC Driver (*.dat) 32bit";
		//driver keywords to find out existing separated by ";"
		private const String AbacusODBCDriverKeywords = "Abacus;ODBC";
		//driver binary to find out correct version
		private const String AbacusODBCDriverBinary = "abaeng32.dll";
		//driver version to find out correct version
		private const String AbacusODBCDriverVersion = "02.10";

		private String m_ODBCDriverName = null;
		private String m_APILevel = null;
		private String m_ConnectFunctions = null;
		private String m_Driver = null;
		private String m_DriverODBCVer = null;
		private String m_FileExtns = null;
		private String m_FileUsage = null;
		private String m_SetUp = null;
		private String m_SQLLevel = null;
		private String m_UsageCount = null;
		private String m_DriverAdditionalProperties = null;

		private String m_CPTimeOut = null;
		private String m_PdxUnInstall = null;

		#endregion

		#region Constructor

		private ODBCDriver(String drivername, String apilevel,
							String connectfunctions, String driver, String driverodbcver,
							String fileextns, String fileusage, String setup, String sqllevel,
							String usagecount, String cptimeout, String pdxuninstall)
		{
			m_ODBCDriverName = drivername;
			m_APILevel = apilevel;
			m_ConnectFunctions = connectfunctions;
			m_Driver = driver;
			m_DriverODBCVer = driverodbcver;
			m_FileExtns = fileextns;
			m_FileUsage = fileusage;
			m_SetUp = setup;
			m_SQLLevel = sqllevel;
			m_UsageCount = usagecount;
			m_CPTimeOut = cptimeout;
			m_PdxUnInstall = pdxuninstall;
		}

		#endregion

		#region Properties

		public String ODBCDriverName { get { return m_ODBCDriverName; } }
		public String APILevel { get { return m_APILevel; } }
		public String ConnectFunctions { get { return m_ConnectFunctions; } }
		public String DriverDLL { get { return m_Driver; } }
		public String DriverODBCVer { get { return m_DriverODBCVer; } }
		public String FileExtns { get { return m_FileExtns; } }
		public String FileUsage { get { return m_FileUsage; } }
		public String SetUp { get { return m_SetUp; } }
		public String SQLLevel { get { return m_SQLLevel; } }
		public String UsageCount { get { return m_UsageCount; } }

		public Boolean IsValidAbacusDriver
		{
			get
			{
				//check drivername with pattern, driver is valid if equals pattern
				if (AbacusODBCDriverName != null)
				{
					if (AbacusODBCDriverName != "")
					{
						if (!(m_ODBCDriverName == AbacusODBCDriverName))
						{
							return false;
						}
					}
				}

				//check drivername with keywords, driver is valid if it contains ALL keywords
				if (AbacusODBCDriverKeywords != null)
				{
					if (AbacusODBCDriverKeywords != "")
					{
						Char[] sep = { ';' };
						String[] keywords = AbacusODBCDriverKeywords.Split(sep);

						for (Int32 i = 0; i < keywords.Length; i++)
						{
							if (!m_ODBCDriverName.Contains(keywords[i]))
							{
								return false;
							}
						}
					}
				}

				//check bianry name, driver is valid if DriverDll contains binary name
				if (AbacusODBCDriverBinary != null)
				{
					if (AbacusODBCDriverVersion != "")
					{
						if (!m_DriverODBCVer.Contains(AbacusODBCDriverVersion))
						{
							return false;
						}
					}
				}

				//check version, driver is valid if DriverODBCVer contains binary version
				if (AbacusODBCDriverBinary != null)
				{
					if (AbacusODBCDriverBinary != "")
					{
						if (!m_Driver.Contains(AbacusODBCDriverBinary))
						{
							return false;
						}
					}
				}

				return true;
			}
		}

		public String DriverAdditionalProperties()
		{
			return m_DriverAdditionalProperties;
		}

		#endregion

		#region Public

		public static ODBCDriver ParseForDriver(String driverName, String[] driverElements, String[] driverElmVals)
		{
			ODBCDriver odbcdriver = null;

			if (driverElements != null && driverElmVals != null)
			{
				String apilevel = null;
				String connectfunctions = null;
				String driver = null;
				String driverodbcver = null;
				String fileextns = null;
				String fileusage = null;
				String setup = null;
				String sqllevel = null;
				String usagecount = null;
				String cptimeout = null;
				String pdxuninstall = null;
				String additional = null;

				Int32 i = 0;

				// For each element defined for a typical Driver get
				// its value.
				foreach (String driverElement in driverElements)
				{
					switch (driverElement.ToLower())
					{
						case "apilevel":
							apilevel = driverElmVals[i].ToString();
							break;

						case "connectfunctions":
							connectfunctions = driverElmVals[i].ToString();
							break;

						case "driver":
							driver = driverElmVals[i].ToString();
							break;

						case "driverodbcver":
							driverodbcver = driverElmVals[i].ToString();
							break;

						case "fileextns":
							fileextns = driverElmVals[i].ToString();
							break;

						case "fileusage":
							fileusage = driverElmVals[i].ToString();
							break;

						case "setup":
							setup = driverElmVals[i].ToString();
							break;

						case "sqllevel":
							sqllevel = driverElmVals[i].ToString();
							break;

						case "usagecount":
							usagecount = driverElmVals[i].ToString();
							break;

						case "cptimeout":
							cptimeout = driverElmVals[i].ToString();
							break;

						case "pdxuninstall":
							pdxuninstall = driverElmVals[i].ToString();
							break;

						default:
							additional += driverElements[i] + " = \"" + driverElmVals[i] + "\"" + Environment.NewLine;
							break;
					}

					i++;
				}

				odbcdriver = new ODBCDriver(driverName, apilevel, connectfunctions, driver, driverodbcver, fileextns, fileusage, setup, sqllevel, usagecount, cptimeout, pdxuninstall);
				odbcdriver.m_DriverAdditionalProperties = additional;
			}

			return odbcdriver;
		}

		public string ToString(Boolean detailed)
		{
			if (!detailed)
			{
				return this.ToString();
			}

			String result = "";
			result += "ODBCDriverName: " + m_ODBCDriverName + Environment.NewLine;
			result += "APILevel: " + m_APILevel + Environment.NewLine;
			result += "ConnectFunctions: " + m_ConnectFunctions + Environment.NewLine;
			result += "Driver: " + m_Driver + Environment.NewLine;
			result += "DriverODBCVersion: " + m_DriverODBCVer + Environment.NewLine;
			result += "FileExtensions: " + m_FileExtns + Environment.NewLine;
			result += "FileUsage: " + m_FileUsage + Environment.NewLine;
			result += "SetUp: " + m_SetUp + Environment.NewLine;
			result += "SQLLevel: " + m_SQLLevel + Environment.NewLine;
			result += "UsageCount: " + m_UsageCount + Environment.NewLine;
			result += "CPTimeOut: " + m_CPTimeOut + Environment.NewLine;
			result += "PdxUnInstall: " + m_PdxUnInstall + Environment.NewLine;
			result += "AdditionalProperties: " + Environment.NewLine + m_DriverAdditionalProperties;
			result += "IsValidAbacusDriver: " + IsValidAbacusDriver.ToString() + Environment.NewLine;

			return result;
		}

		#region Overrides

		public override String ToString()
		{
			return m_ODBCDriverName;
		}
		
		#endregion

		#endregion
	}
}
