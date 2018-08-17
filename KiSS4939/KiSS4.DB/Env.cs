using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace KiSS4.DB
{
	/// <summary>
	/// A KiSS4 environment
	/// </summary>
	public class Env
	{
		#region Fields and Properties
		/// <summary>
		/// Name
		/// </summary>
		public string Name;

		/// <summary>
		/// Environment Type (prod,test,train,dev)
		/// </summary>
		public EnvType EnvType;

		/// <summary>
		/// ConnectionString with decrypted password
		/// </summary>
		public string ConnectionString;

    
		/// <summary>
		/// ConnectionString für OLEDB Zugriff auf die Kiss-Datenbank. Dieser wird
		/// im AddOn Word und Excel verwendet.
		/// Der ConnectionString wird vom "normalen" SqlServer ConnectionString
		/// abgeleitet. Folgende Werte werden übernommen (nicht abschliessend):
		/// - User
		/// - Passwort 		
        /// Siehe auch <see cref="KiSS4.Dokument.Utilities.FileUtilities.OLEDBConnectionString"/> 		
		/// </summary>		
		public string OLEDBConnectionString
		{
			get { 
               string tmpConConnectionString = "provider=sqloledb;" + this.ConnectionString.Replace("server=", "Data Source=").Replace("Trusted_Connection=Yes", "Integrated Security=SSPI"); 
               return tmpConConnectionString;
            } 
        }

		#endregion

		/// <summary>
		/// Initialize.
		/// </summary>
		public Env(string name, EnvType envType, string connectionString)
		{
			this.Name = name;
			this.EnvType = envType;
			this.ConnectionString = connectionString;
		}
	}
}
