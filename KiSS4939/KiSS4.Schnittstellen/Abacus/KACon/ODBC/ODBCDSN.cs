using System;

namespace KiSS4.Schnittstellen.Abacus.KACon.ODBC
{
	public class ODBCDSN
	{
		#region Enum

		public enum eDSNType
		{
			Unknown,
			System,
			User
		}

		#endregion

		#region Fields

		private eDSNType m_DSNType = eDSNType.Unknown;
		private String m_DSNName = null;
		private String m_DSNDriverName = null;
		private String m_DSNDescription = null;
		private String m_DSNServerName = null;
		private String m_DSNDriver = null;
		private String m_REG_ODBC_INI = null;
		private String m_REG_ODBC_DSN = null;
		private String m_DSNAdditionalProperties = null;

		#endregion

		#region Construction

		private ODBCDSN(String dsnName, String dsnDriverName, String description, String server, String driver)
		{
			m_DSNName = dsnName;
			m_DSNDriverName = dsnDriverName;
			m_DSNDescription = description;
			m_DSNServerName = server;
			m_DSNDriver = driver;
		}

		#endregion

		#region Properties

		public String DSNName { get { return m_DSNName; } }
		public String DSNDriver { get { return m_DSNDriver; } }
		public String DSNDriverName { get { return m_DSNDriverName; } }
		public String DSNDescription { get { return m_DSNDescription; } }
		public String DSNServerName { get { return m_DSNServerName; } }
		public String DSNDriverPath { get { return m_DSNDriver; } }
		public String DSNAdditionalProperties { get { return m_DSNAdditionalProperties; } }

		public String REG_ODBC_INI
		{
			get
			{
				return m_REG_ODBC_INI;
			}
			set
			{
				m_REG_ODBC_INI = value;
			}
		}

		public String REG_ODBC_DSN
		{
			get
			{
				return m_REG_ODBC_DSN;
			}
			set
			{
				m_REG_ODBC_DSN = value;
			}
		}

		public eDSNType DSNType
		{
			get
			{
				return m_DSNType;
			}
			set
			{
				m_DSNType = value;
			}
		}

		#endregion

		#region Public

		public static ODBCDSN ParseForODBCDSN(String dsnName, String dsnDriverName, String[] dsnElements, String[] dsnElmVals)
		{
			ODBCDSN odbcdsn = null;

			if (dsnElements != null && dsnElmVals != null)
			{
				Int32 i = 0;
				String description = null;
				String server = null;
				String driver = null;
				String additional = "";

				// For each element defined for a typical DSN get
				// its value.
				foreach (String dsnElement in dsnElements)
				{
					switch (dsnElement.ToLower())
					{
						case "description":
							description = dsnElmVals[i];
							break;

						case "server":
							server = dsnElmVals[i];
							break;

						case "driver":
							driver = dsnElmVals[i];
							break;

						default:
							additional += dsnElements[i] + " = \"" + dsnElmVals[i] + "\"" + Environment.NewLine;
							break;
					}

					i++;
				}

				odbcdsn = new ODBCDSN(dsnName, dsnDriverName, description, server, driver);
				odbcdsn.m_DSNAdditionalProperties = additional;
			}

			return odbcdsn;
		}

		public String ToString(Boolean detailed)
		{
			if (!detailed)
			{
				return this.ToString();
			}
			else
			{
				String result = "";

				result += "Name: " + m_DSNName + Environment.NewLine;
				result += "Driver: " + m_DSNDriverName + Environment.NewLine;
				result += "Description: " + m_DSNDescription + Environment.NewLine;
				result += "ServerName: " + m_DSNServerName + Environment.NewLine;
				result += "DriverBinary: " + m_DSNDriver + Environment.NewLine;
				result += "REG_ODBC_INI: " + m_REG_ODBC_INI + Environment.NewLine;
				result += "REG_ODBC_DSN: " + m_REG_ODBC_DSN + Environment.NewLine;
				result += "AdditionalProperties: " + Environment.NewLine + m_DSNAdditionalProperties + Environment.NewLine;

				return result;
			}
		}

		#region Overrides

		public override String ToString()
		{
			String result = "";

			result += m_DSNName + " # ";
			result += m_DSNDriverName + " # ";
			result += m_DSNDescription + " # ";
			result += m_DSNServerName + " # ";
			result += m_DSNDriver + " # ";

			return result;
		}

		#endregion

		#endregion
	}
}
