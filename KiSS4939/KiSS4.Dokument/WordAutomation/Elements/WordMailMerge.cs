using System;
using System.Data;
using System.IO;

namespace KiSS4.Dokument.WordAutomation.Elements
{
	/// <summary>
	/// Represents a WordMailMerge Element. Contains a collection of MergeFields
	/// and method to initialize and run MailMerge.
	/// </summary>
	public class WordMailMerge : Element
	{
		/// <summary>
		/// Merge fields.
		/// </summary>
		public WordMergeFields wf = new WordMergeFields();

		/// <summary>
		/// Name of the datasource.
		/// </summary>
		public string dataSourceName = null;

		/// <summary>
		/// Gets the name of the data source.
		/// </summary>
		/// <value>The name of the data source.</value>
		public string DataSourceName 
		{
			get{return this.dataSourceName;}
		}

		/// <summary>
		/// Creates a comma delimited file with datasource for merge Mail 
		/// Comma used instead of tab for Word97 Compatibility
		/// </summary>
		/// <param name="Dt"></param>
		/// <param name="DataSourceName"></param>
		public WordMailMerge(DataTable Dt, string DataSourceName)
		{
			this.dataSourceName = DataSourceName;
			string fileResult = "";
			
			// first set columns name
			for(int i=0; i<Dt.Columns.Count; i++)
			{
				fileResult += Dt.Columns[i].ColumnName;
				// don't add a tab mark after last column
					if(i<Dt.Columns.Count-1)
						fileResult += ",";
			}

			for (int i=0; i<Dt.Rows.Count; i++)
			{
				fileResult += "\n";
			
				for (int j=0;j<Dt.Columns.Count;j++)
				{
					fileResult += Dt.Rows[i][j].ToString();
					if(j<Dt.Columns.Count-1)
						fileResult += ",";
				}
			}
			
			StreamWriter sw = new StreamWriter(File.Create(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + this.dataSourceName), System.Text.Encoding.Default);
			sw.Write(fileResult);
			sw.Flush();
			sw.Close();			
		}	
	}
}
