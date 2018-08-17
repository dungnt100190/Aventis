using System;
using System.Data.SqlClient;
using KiSS4.DB;

namespace KiSS4.DesignerHost
{
	/// <summary>
	/// Summary description for XTableColumnDBHandler.
	/// </summary>
	public class XTableColumnDBHandler
	{
		#region Delete Columns

		/// <summary>
		/// Delete both columns, in table and history-table if existing
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		internal static void DeleteColumnWithHistory(string tableName, string columnName)
		{
			DeleteColumn(tableName, columnName);
			DeleteColumn(string.Format("Hist_{0}", tableName), columnName);
		}

		/// <summary>
		/// Delete column in table if existing
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		internal static void DeleteColumn(string tableName, string columnName)
		{
			if (columnName == null || columnName == string.Empty)
			{
				throw new ArgumentException("Column name is null or empty", "columnName");
			}
			// delete single column of table if existing and not identity 
			if (ExistsColumn(tableName, columnName) && !IsPrimaryKeyColumn(tableName, columnName) && !IsSystemColumn(tableName, columnName))
			{
				DBUtil.ExecuteScalarSQL("EXECUTE spDropTableRef {0}, {1}, 1", tableName, columnName);
				string deleteColumn = string.Format(@"ALTER TABLE [{0}] DROP COLUMN [{1}]", tableName, columnName);
				DBUtil.ExecSQLThrowingException(deleteColumn);
			}
		}

		#endregion

		#region Create Columns

		/// <summary>
		/// Create both columns, in table and history-table if not existing yet
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <param name="fieldCode"></param>
		/// <param name="size"></param>
		internal static void CreateColumnWithHistory(string tableName, string columnName, int fieldCode, int size, bool allowNULL, string defaultValue, bool defaultValueIsNull)
		{
			CreateColumn(tableName, columnName, fieldCode, size, allowNULL, defaultValue, defaultValueIsNull);
			CreateColumn(string.Format("Hist_{0}", tableName), columnName, fieldCode, size, allowNULL, defaultValue, defaultValueIsNull);
		}

		/// <summary>
		/// Create column in table if not existing yet
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <param name="fieldCode"></param>
		/// <param name="size"></param>
		internal static void CreateColumn(string tableName, string columnName, int fieldCode, int size, bool allowNULL, string defaultValue, bool defaultValueIsNull)
		{
			if (columnName == null || columnName == string.Empty)
			{
				throw new ArgumentException("Column name is null or empty", "columnName");
			}
			if (!CtlTableEditor.ExistsTable(tableName))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "TableNotFoundCannotAddColumn", "Tabelle '{0}' existiert nicht. Es kann keine neue Spalte hinzugefügt werden.", KissMsgCode.MsgError, tableName));
			}

			if (!ExistsColumn(tableName, columnName))
			{
				string strAddColumn = string.Format(@"ALTER TABLE [{0}] 
				                                       ADD [{1}] {2}", tableName, columnName, GetDataType(fieldCode, size));
				if (!allowNULL)
				{
					strAddColumn += " NOT";
				}
				if (allowNULL && defaultValueIsNull)
				{
					defaultValue = "NULL";
				}
				strAddColumn += string.Format(" NULL DEFAULT {0}", defaultValue);
				// Note: ExecSQL returns -1 (affected rows) fur the ADD statement, no matter if it succeeded or failed
				DBUtil.ExecSQLThrowingException(strAddColumn);
			}
		}

		#endregion

		#region Modify Columns

		/// <summary>
		/// Modify both columns, in table and history-table
		/// </summary>
		/// <param name="tableName">Name of the table the column belongs to</param>
		/// <param name="columnName">Name of the column to change. The name itself cannot be changed</param>
		/// <param name="fieldCode">New field code (determines the data type)</param>
		/// <param name="size">Size of the data type (e.g. varchar(size)). Ignored if size is not requested</param>
		/// <param name="allowNULL">Allow NULL in the column</param>
		/// <param name="defaultValue">New default value, if any</param>
		/// <param name="defaultValueIsNull">Set default value as NULL</param>
		internal static void ModifyColumnWithHistory(string tableName, string columnName, int fieldCode, int size, bool allowNULL, string defaultValue, bool defaultValueIsNull)
		{
			ModifyColumn(tableName, columnName, fieldCode, size, allowNULL, defaultValue, defaultValueIsNull);
			ModifyColumn(string.Format("Hist_{0}", tableName), columnName, fieldCode, size, allowNULL, defaultValue, defaultValueIsNull);
		}

		/// <summary>
		/// Modify a column on the DB
		/// </summary>
		/// <param name="tableName">Name of the table the column belongs to</param>
		/// <param name="columnName">Name of the column to change. The name itself cannot be changed</param>
		/// <param name="fieldCode">New field code (determines the data type)</param>
		/// <param name="size">Size of the data type (e.g. varchar(size)). Ignored if size is not requested</param>
		/// <param name="allowNULL">Allow NULL in the column</param>
		/// <param name="defaultValue">New default value, if any</param>
		/// <param name="defaultValueIsNull">Set default value as NULL</param>
		internal static void ModifyColumn(string tableName, string columnName, int fieldCode, int size, bool allowNULL, string defaultValue, bool defaultValueIsNull)
		{
			if (columnName == null || columnName == string.Empty)
			{
				throw new ArgumentException("Column name is null or empty", "columnName");
			}
			if (!CtlTableEditor.ExistsTable(tableName))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "TableNotFoundToModify", "Tabelle '{0}' existiert nicht. Die Spalte '{1}' kann nicht verändert werden.", KissMsgCode.MsgError, tableName, columnName));
			}

			if (!ExistsColumn(tableName, columnName))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "ColumnNotFoundToModify", "Die Spalte '{0}' der Tabelle {1} existiert nicht und kann nicht verändert werden.", KissMsgCode.MsgError, columnName, tableName));
			}
			if (!IsPhysicalDataTypeConsistent(tableName, columnName, fieldCode, false))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "InconsitencyErrorWhileSaving", "Datensatz kann wegen Inkonsistenz nicht verändert werden.", KissMsgCode.MsgError, columnName, tableName),
					string.Format("Physikalischer Datentyp der Spalte '{0}' in der Tabelle '{1}' entspricht nicht dem definierten Feldtyp", columnName, tableName), null);
			}

			string dataType = GetDataType(fieldCode, size);

			//use transaction
			SqlConnection cn = Session.Connection;
			SqlTransaction tx = cn.BeginTransaction();

			try
			{
				//drop default value first
				SqlCommand cmd = new SqlCommand(string.Format("EXECUTE spDropTableRef {0}, {1}, 1, 0, 0, 0, 0", tableName, columnName), cn, tx);
				cmd.ExecuteNonQuery();

				if (allowNULL && defaultValueIsNull)
				{
					defaultValue = "NULL";
				}
				//add default again
				string strAddDefault = string.Format(@"ALTER TABLE [{0}] 
				                                        ADD CONSTRAINT [DF_{0}_{1}]
				                                        DEFAULT {2} FOR [{1}]", tableName, columnName, defaultValue);
				cmd = new SqlCommand(strAddDefault, cn, tx);
				cmd.ExecuteNonQuery();

				// can only alter column if datatype allows statement
				if (XTableColumnDBHandler.IsDataTypeChangeable(dataType))
				{
					//modify column			
					string strModifyColumn = string.Format(@"ALTER TABLE [{0}] 
					                                          ALTER COLUMN [{1}] {2}", tableName, columnName, dataType);
					if (!allowNULL)
					{
						strModifyColumn += " NOT";
					}
					strModifyColumn += " NULL";

					cmd = new SqlCommand(strModifyColumn, cn, tx);
					cmd.ExecuteNonQuery();
				}

				tx.Commit();
			}
			catch (Exception ex)
			{
				tx.Rollback();
				KissMsg.ShowError("CtlTableColumnEditor", "ErrorModifyColumn", "Die Spalte '{0}' der Tabelle {1} konnte nicht verändert werden.", null, ex, 0, 0, columnName, tableName);
			}
		}

		#endregion

		#region DataType

		/// <summary>
		/// Get data type from table XLOVCode for the selected field code
		/// </summary>
		/// <param name="fieldCode"></param>
		/// <param name="size"></param>
		/// <returns>datatype as defined on db including size (example: "varchar(255)") or "" if invalid</returns>
		internal static string GetDataType(int fieldCode, int size)
		{
			return GetDataType(fieldCode, size, true);
		}

		/// <summary>
		/// Get data type from table XLOVCode for the selected field code
		/// </summary>
		/// <param name="fieldCode"></param>
		/// <param name="size"></param>
		/// <returns>datatype as defined on db including size (example: "varchar(255)") or "" if invalid</returns>
		internal static string GetDataType(int fieldCode, int size, bool includeSize)
		{
			try
			{
				SqlQuery qryGetDataType = DBUtil.OpenSQL(@"
					SELECT Value1, Value2
					FROM   XLOVCode
					WHERE  (LOVName = 'FieldCode') AND (Code = {0})", fieldCode);
				if (qryGetDataType.Count == 1)
				{
					string dataType = qryGetDataType["Value1"] as string;
					switch (dataType)
					{
						case null:
							{
								dataType = "(null)";
								throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "NoDataTypeDataTypeForFieldCode", "Kein Datentyp für FieldCode '{0}' abgelegt.", KissMsgCode.MsgError, fieldCode));
							}

						default:
							{
								if (includeSize)
								{
									string dataTypeSize = qryGetDataType["Value2"] as string;
									if (size > 0)
									{
										dataTypeSize = size.ToString();
									}
									else if (dataTypeSize == null)
									{
										dataTypeSize = GetDefaultSizeForDataType(dataType);
									}
									if (dataTypeSize == null)
									{
										return dataType;
									}
									else
									{
										return string.Format("{0}({1})", dataType, dataTypeSize);
									}
								}
								else
								{
									return dataType;
								}
							}
					}
				}
				else
				{
					throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "NoDataTypeForFieldCode", "Es ist kein Datentyp für Felder mit FieldCode '{0}' abgelegt.", KissMsgCode.MsgError, fieldCode));
				}
			}
			catch (Exception ex)
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "FieldCodeDataTypeQueryError", "Fehler bei der Abfrage des Datentyps für FieldCode '{0}'.", KissMsgCode.MsgError, fieldCode), ex);
			}
		}

		private static string GetDefaultSizeForDataType(string dataType)
		{
			switch (dataType)
			{
				case "varchar":
					{
						return "100";
					}
				default:
					{
						return null;
					}
			}

		}

		/// <summary>
		/// Get type as used in c# (string, int, bool, date, time) for fieldCode
		/// </summary>
		/// <param name="fieldCode"></param>
		/// <returns>Type specified in database or throw exception if not found</returns>
		internal static string GetFieldCodeInputType(int fieldCode)
		{
			try
			{
				SqlQuery qryInputType = DBUtil.OpenSQL(@"
					SELECT Value3
					FROM   XLOVCode
					WHERE  (LOVName = 'FieldCode') AND (Code = {0})", fieldCode);
				if (qryInputType.Count == 1)
				{
					qryInputType.First();
					return (string)qryInputType["Value3"];
				}
				else
				{
					throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "NoInputTypeForFieldCode", "Es ist kein Eingabetyp für ein Feld mit FieldCode '{0}' abgelegt.", KissMsgCode.MsgError, fieldCode));
				}
			}
			catch (Exception ex)
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "FieldCodeInputTypeQueryError", "Fehler bei der Abfrage des Eingabetyps für FieldCode '{0}'.", KissMsgCode.MsgError, fieldCode), ex);
			}
		}

		/// <summary>
		/// Get the physical data type for the specified field
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <returns></returns>
		internal static string GetPhysicalDataTypeOfColumnField(string tableName, string columnName)
		{
			if (columnName == null || columnName == string.Empty)
			{
				throw new ArgumentException("Column name is null or empty", "columnName");
			}

			string sValue = DBUtil.ExecuteScalarSQL(@"
				SELECT TYP.name
				FROM syscolumns        COL
				  INNER JOIN systypes  TYP ON TYP.xtype = COL.xtype
				WHERE COL.id = OBJECT_ID({0}) AND COL.name = {1}", tableName, columnName) as string;

			if (sValue == null)
			{
				// either the table or the column does not exist
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "ColumnNotFound", "Spalte '{0}' konnte in der Tabelle '{1}' nicht gefunden werden.", KissMsgCode.MsgError, columnName, tableName));
			}
			return sValue;
		}


		/// <summary>
		/// Checks if the physical data type is the same as the one saved in XTableColumn
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <returns>True if physical data type is consistent with data type in XTableColumn</returns>
		internal static bool IsPhysicalDataTypeConsistent(string tableName, string columnName, int fieldCode, bool showWarning)
		{
			if (columnName == null || columnName == string.Empty)
			{
				throw new ArgumentException("Column name is null or empty", "columnName");
			}
			string sValue = GetDataType(fieldCode, 0, false);
			string sPhysicalValue = GetPhysicalDataTypeOfColumnField(tableName, columnName);
			bool isConsistent = (sValue == sPhysicalValue);
			if (!isConsistent && showWarning)
			{
				KissMsg.ShowError("CtlTableColumnEditor", "InconsitentDataTypeInDatabaseColumn", "Physikalischer Datentyp ({0}) der Spalte '{1}' in der Tabelle '{2}' entspricht nicht dem definierten Feldtyp ({3})", null, null, 0, 0, sPhysicalValue, columnName, tableName, sValue);
			}
			return isConsistent;
		}

		/// <summary>
		/// Check if size of datatype can be modified
		/// </summary>
		/// <param name="fieldCode"></param>
		/// <returns>True if size can be modified</returns>
		internal static bool HasDataTypeVariableLength(int fieldCode)
		{
			return GetDataType(fieldCode, 0).StartsWith("varchar(");
		}

		/// <summary>
		/// Datatypes defined as "text", "ntext" or image cannot be altered by sql statement
		/// </summary>
		/// <param name="dataType"></param>
		/// <returns>True if datatype can be altered</returns>
		internal static bool IsDataTypeChangeable(int fieldCode)
		{
			return IsDataTypeChangeable(GetDataType(fieldCode, 0));
		}

		/// <summary>
		/// Datatypes defined as "text", "ntext" or image cannot be altered by sql statement
		/// </summary>
		/// <param name="dataType"></param>
		/// <returns>True if datatype can be altered</returns>
		internal static bool IsDataTypeChangeable(string dataType)
		{
			if (dataType == null)
			{
				return false;
			}
			return !(dataType.Equals("text") || dataType.Equals("ntext") || dataType.Equals("image"));
		}

		#endregion

		#region Column stuff

		/// <summary>
		/// Check if specified column exists on database
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <returns>true if existing column</returns>
		internal static bool ExistsColumn(string tableName, string columnName)
		{
			if (columnName == null || columnName == string.Empty)
			{
				return false;
			}
			//check if column exists
			SqlQuery qryColumnExists = new SqlQuery();
			qryColumnExists.Fill(@"SELECT Name
			                        FROM   syscolumns
			                        WHERE  (id = OBJECT_ID({0})) AND name={1}", tableName, columnName);

			return qryColumnExists.Count > 0;
		}

		/// <summary>
		/// Check if specified field is a primary-key
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <returns>true if primary key</returns>
		internal static bool IsPrimaryKeyColumn(string tableName, string columnName)
		{
			if (columnName == null)
			{
				return false;
			}
			SqlQuery qryPrimaryKeys = DBUtil.OpenSQL(@"
				SELECT COL.name
				FROM sysobjects            TBL
				  INNER JOIN syscolumns    COL ON TBL.id  = COL.id
				  LEFT  JOIN sysindexkeys  IDK ON IDK.id  = TBL.id AND IDK.colid = COL.colid
				  LEFT  JOIN sysindexes    IDX ON IDX.id  = TBL.id AND IDX.indid = IDK.indid AND IDX.status & 2050 = 2050
				WHERE TBL.Name = {0} AND COL.name = {1} AND ((TBL.type = 'U' AND IDX.id IS NOT NULL) OR (TBL.type = 'V' AND COL.status & 0x80 != 0))", tableName, columnName);

			return qryPrimaryKeys.Count > 0;
		}

		/// <summary>
		/// Get null/not null as defined for the specified field
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <returns>true if can be null</returns>
		internal static bool IsNullableColumn(string tableName, string columnName)
		{
			if (columnName == null || columnName == string.Empty)
			{
				throw new ArgumentException("Column name is null or empty", "columnName");
			}

			object retValue = DBUtil.ExecuteScalarSQL(@"SELECT isnullable 
			                                             FROM   syscolumns
			                                             WHERE  id=OBJECT_ID({0}) AND (name = {1})", tableName, columnName);
			if (retValue == null || !(retValue is int))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "CannotDetermineNullableValue", "Column '{0}' not found in table '{1}', cannot determine nullable value.", KissMsgCode.MsgError, columnName, tableName));
			}
			else
			{
				return ((int)retValue == 1) ? true : false;
			}
		}

		/// <summary>
		/// Get the size as defined for the specified field
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <returns>size as defined in database (always defined) or throw exception if not found</returns>
		internal static int GetSizeOfColumnField(string tableName, string columnName)
		{
			if (columnName == null || columnName == string.Empty)
			{
				throw new ArgumentException("Column name is null or empty", "columnName");
			}

			int iValue = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"SELECT length 
			                                                        FROM   syscolumns
			                                                        WHERE  id=OBJECT_ID({0}) AND (name = {1})", tableName, columnName));
			return iValue;
		}

		/// <summary>
		/// Get the default-value as defined for the specified field
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <returns>default value as defined in database or "" if not found</returns>
		internal static string GetDefaultValueOfColumnField(string tableName, string columnName, bool allowNullAsReturnValue)
		{
			if (columnName == null || columnName == string.Empty)
			{
				throw new ArgumentException("Column name is null or empty", "columnName");
			}

			string sValue = DBUtil.ExecuteScalarSQL(@"SELECT text 
			                                           FROM    syscomments
			                                           WHERE id IN (
			                                           SELECT cdefault 
			                                           FROM   syscolumns
			                                           WHERE  id=OBJECT_ID({0}) AND (name = {1}) AND  cdefault > 0)", tableName, columnName) as string;

			if (allowNullAsReturnValue && sValue == "(null)")
			{
				return null;
			}
			if (!allowNullAsReturnValue && sValue == null)
			{
				sValue = "";
			}

			return sValue;
		}

		/// <summary>
		/// Checks if column is marked as a system-column
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <returns>True if column is a system column</returns>
		internal static bool IsSystemColumn(string tableName, string columnName)
		{
			if (columnName == null || columnName == string.Empty)
			{
				return false;
			}
			object retValue = DBUtil.ExecuteScalarSQL(@"SELECT System
			                                             FROM XTableColumn
			                                             WHERE TableName = {0} AND ColumnName = {1}", tableName, columnName);
			if (retValue == null || !(retValue is bool))
			{
				return false;
			}
			else
			{
				return (bool)retValue;
			}
		}


		/// <summary>
		/// Finds the first column of a table
		/// </summary>
		/// <param name="tableName">Name of the table</param>
		/// <returns>name of the first column or null if table contains no columns</returns>
		internal static string GetFirstColumnOfTable(string tableName)
		{
			return DBUtil.ExecuteScalarSQL(@"
				      SELECT TOP 1 [name]
			         FROM syscolumns
			         WHERE [id] = OBJECT_ID( {0} )
			         ORDER BY colorder", tableName) as string;
		}
		#endregion

		#region Table stuff

		/// <summary>
		/// Checks if table is marked as a system-table
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns>True if table is a system table</returns>
		internal static bool IsSystemTable(string tableName)
		{
			object retValue = DBUtil.ExecuteScalarSQL(@"SELECT System
			                                             FROM XTable
			                                             WHERE TableName = {0}", tableName);
			if (retValue == null || !(retValue is bool))
			{
				return false;
			}
			else
			{
				return (bool)retValue;
			}
		}

		#endregion

		#region Indices / Primary Keys

		#region Create

		internal static void CreateIndex(string tableName, string indexName, bool primaryKey, bool unique, bool clustered, string columnList)
		{
			if (primaryKey)
			{
				CreatePrimaryKey(tableName, indexName, clustered, columnList);
			}
			else
			{
				CreateSimpleIndex(tableName, indexName, unique, clustered, columnList);
			}
		}


		private static void CreateSimpleIndex(string tableName, string indexName, bool unique, bool clustered, string columnList)
		{
			if (indexName == null || indexName == string.Empty)
			{
				throw new ArgumentException("Index name is null or empty", "indexName");
			}
			if (columnList == null || columnList == string.Empty)
			{
				throw new ArgumentException("ColumnList is null or empty", "columnList");
			}
			if (tableName == null || tableName == string.Empty)
			{
				throw new ArgumentException("TableName is null or empty", "tableName");
			}
			if (!CtlTableEditor.ExistsTable(tableName))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "TableDoesNotExistIndex", "Tabelle '{0}' existiert nicht. Es kann kein Index hinzugefügt werden.", KissMsgCode.MsgError, tableName));
			}

			string createIndexSql = "CREATE ";
			if (unique)
			{
				createIndexSql += "UNIQUE ";
			}
			if (!clustered)
			{
				createIndexSql += "NON";
			}
			createIndexSql += string.Format("CLUSTERED INDEX [{0}] ON [{1}]({2})", indexName, tableName, columnList);

			// Note: ExecSQL returns -1 (affected rows) fur the ADD statement, no matter if it succeeded or failed
			DBUtil.ExecSQLThrowingException(createIndexSql);
		}

		private static void CreatePrimaryKey(string tableName, string primaryKeyName, bool clustered, string columnList)
		{
			if (primaryKeyName == null || primaryKeyName == string.Empty)
			{
				throw new ArgumentException("Primary Key name is null or empty", "primaryKeyName");
			}
			if (columnList == null || columnList == string.Empty)
			{
				throw new ArgumentException("ColumnList is null or empty", "columnList");
			}
			if (tableName == null || tableName == string.Empty)
			{
				throw new ArgumentException("TableName is null or empty", "tableName");
			}
			if (!CtlTableEditor.ExistsTable(tableName))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "TableDoesNotExistPrimaryKey", "Tabelle '{0}' existiert nicht. Es kann kein Primärschlüssel hinzugefügt werden.", KissMsgCode.MsgError, tableName));
			}

			string createPrimaryKeySql = string.Format("ALTER TABLE [{0}] ADD CONSTRAINT [{1}] PRIMARY KEY ", tableName, primaryKeyName);
			if (!clustered)
			{
				createPrimaryKeySql += "NON";
			}
			createPrimaryKeySql += string.Format("CLUSTERED ({0})", columnList);

			DBUtil.ExecSQLThrowingException(createPrimaryKeySql);
		}

		#endregion

		#region Helper Methods

		//		internal static bool ExistsIndex( string tableName, string indexName )
		//		{
		//			// There may exist more than one Index with this name, therefore join sysindexes with sysobjeects to obtain the tablename
		//			object obj = DBUtil.ExecuteScalarSQL( @"SELECT si.name
		//			                                        FROM sysindexes si
		//			                                          INNER JOIN sysobjects so
		//			                                          ON so.id = si.id
		//			                                        WHERE si.name = {0} AND so.name = {1}", indexName, tableName );
		//			if( obj is string )
		//			{
		//				return obj as string == indexName;
		//			}
		//			return false;
		//		}
		//
		//
		//		internal static bool ExistsPrimaryKey( string tableName, string primaryKeyName )
		//		{
		//			object obj = DBUtil.ExecuteScalarSQL( @"SELECT name
		//			                                        FROM sysobjects
		//			                                        WHERE id = OBJECT_ID( {0} ) AND parent_obj = OBJECT_ID( {1} )", primaryKeyName, tableName );
		//			if( obj is string )
		//			{
		//				return obj as string == primaryKeyName;
		//			}
		//			return false;
		//		}

		#endregion

		#region Delete

		internal static void DeleteIndex(string tableName, string indexName, bool primaryKey)
		{
			if (primaryKey)
			{
				DeletePrimaryKey(tableName, indexName);
			}
			else
			{
				DeleteSimpleIndex(tableName, indexName);
			}
		}

		internal static void DeleteSimpleIndex(string tableName, string indexName)
		{
			if (tableName == null || tableName == string.Empty)
			{
				throw new ArgumentException("TableName is null or empty", "tableName");
			}
			if (indexName == null || indexName == string.Empty)
			{
				throw new ArgumentException("Primary Key name is null or empty", "indexName");
			}
			//if( ExistsIndex( tableName, indexName ) )
			{
				string dropPrimaryKeySql = string.Format("DROP INDEX [{0}].[{1}]", tableName, indexName);
				DBUtil.ExecSQLThrowingException(dropPrimaryKeySql);
			}
		}

		internal static void DeletePrimaryKey(string tableName, string primaryKeyName)
		{
			if (tableName == null || tableName == string.Empty)
			{
				throw new ArgumentException("TableName is null or empty", "tableName");
			}
			if (primaryKeyName == null || primaryKeyName == string.Empty)
			{
				throw new ArgumentException("Primary Key name is null or empty", "primaryKeyName");
			}
			//if( ExistsIndex( tableName, primaryKeyName ) )
			{
				string dropPrimaryKeySql = string.Format("ALTER TABLE [{0}] DROP CONSTRAINT [{1}]", tableName, primaryKeyName);
				DBUtil.ExecSQLThrowingException(dropPrimaryKeySql);
			}
		}

		#endregion

		#region Modify

		internal static void ModifyIndex(string tableName, string oldIndexName, bool oldIsPrimaryKey, bool oldUnique, bool oldClustered, string oldColumnList, string newIndexName, bool newIsPrimaryKey, bool newUnique, bool newClustered, string newColumnList)
		{
			// Delete the old Index
			if (oldIsPrimaryKey)
			{
				DeletePrimaryKey(tableName, oldIndexName);
			}
			else
			{
				DeleteSimpleIndex(tableName, oldIndexName);
			}

			// Now create the new Index
			if (newIsPrimaryKey)
			{
				try
				{
					CreatePrimaryKey(tableName, newIndexName, newClustered, newColumnList);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
					// try to recreate the old index
					CreateIndex(tableName, oldIndexName, oldIsPrimaryKey, oldUnique, oldClustered, oldColumnList);
					throw;
				}
			}
			else
			{
				try
				{
					CreateSimpleIndex(tableName, newIndexName, newUnique, newClustered, newColumnList);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
					// try to recreate the old index
					CreateIndex(tableName, oldIndexName, oldIsPrimaryKey, oldUnique, oldClustered, oldColumnList);
					throw;
				}
			}
		}

		#endregion

		#endregion

		#region Foreign Keys

		#region Create

		public static void CreateForeignKey(string foreignKeyName, string pkTable, string pkColumnList, string fkTable, string fkColumnList)
		{
			if (foreignKeyName == null || foreignKeyName == string.Empty)
			{
				throw new ArgumentException("Foreign key name is null or empty", "foreignKeyName");
			}
			if (pkTable == null || pkTable == string.Empty)
			{
				throw new ArgumentException("Primary key Table is null or empty", "pkTable");
			}
			if (pkColumnList == null || pkColumnList == string.Empty)
			{
				throw new ArgumentException("Primary key column list is null or empty", "pkColumnList");
			}
			if (fkTable == null || fkTable == string.Empty)
			{
				throw new ArgumentException("Foreign key Table is null or empty", "fkTable");
			}
			if (fkColumnList == null || fkColumnList == string.Empty)
			{
				throw new ArgumentException("Foreign key column list is null or empty", "fkColumnList");
			}
			if (!CtlTableEditor.ExistsTable(pkTable))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "TableDoesNotExistForeignKey", "Tabelle '{0}' existiert nicht. Es kann kein Fremdschlüssel hinzugefügt werden.", KissMsgCode.MsgError, pkTable));
			}
			if (!CtlTableEditor.ExistsTable(fkTable))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "TableDoesNotExistForeignKey", "Tabelle '{0}' existiert nicht. Es kann kein Fremdschlüssel hinzugefügt werden.", KissMsgCode.MsgError, fkTable));
			}

			string createForeignKeySql = string.Format("ALTER TABLE [{0}] ADD CONSTRAINT [{1}] FOREIGN KEY ({2}) REFERENCES [{3}]({4})", fkTable, foreignKeyName, fkColumnList, pkTable, pkColumnList);
			DBUtil.ExecSQLThrowingException(createForeignKeySql);
		}

		#endregion

		#region Helper Methods

		//		internal static bool ExistsIndex( string tableName, string indexName )
		//		{
		//			// There may exist more than one Index with this name, therefore join sysindexes with sysobjeects to obtain the tablename
		//			object obj = DBUtil.ExecuteScalarSQL( @"SELECT si.name
		//			                                        FROM sysindexes si
		//			                                          INNER JOIN sysobjects so
		//			                                          ON so.id = si.id
		//			                                        WHERE si.name = {0} AND so.name = {1}", indexName, tableName );
		//			if( obj is string )
		//			{
		//				return obj as string == indexName;
		//			}
		//			return false;
		//		}
		//
		//
		//		internal static bool ExistsPrimaryKey( string tableName, string primaryKeyName )
		//		{
		//			object obj = DBUtil.ExecuteScalarSQL( @"SELECT name
		//			                                        FROM sysobjects
		//			                                        WHERE id = OBJECT_ID( {0} ) AND parent_obj = OBJECT_ID( {1} )", primaryKeyName, tableName );
		//			if( obj is string )
		//			{
		//				return obj as string == primaryKeyName;
		//			}
		//			return false;
		//		}

		#endregion

		#region Delete

		internal static void DeleteForeignKey(string tableName, string foreignKeyName)
		{
			if (tableName == null || tableName == string.Empty)
			{
				throw new ArgumentException("TableName is null or empty", "tableName");
			}
			if (foreignKeyName == null || foreignKeyName == string.Empty)
			{
				throw new ArgumentException("Foreign Key name is null or empty", "foreignKeyName");
			}
			string dropForeignKeySql = string.Format("ALTER TABLE [{0}] DROP CONSTRAINT [{1}]", tableName, foreignKeyName);
			DBUtil.ExecSQLThrowingException(dropForeignKeySql);
		}

		#endregion

		#region Modify

		internal static void ModifyForeignKey(string oldForeignKeyName, string oldPkTable, string oldPkColumnList, string fkTable, string oldFkColumnList, string newForeignKeyName, string newPkTable, string newPkColumnList, string newFkColumnList)
		{
			// Delete the old Index
			DeleteForeignKey(fkTable, oldForeignKeyName);
			// Now create the new Index
			try
			{
				CreateForeignKey(newForeignKeyName, newPkTable, newPkColumnList, fkTable, newFkColumnList);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
				// try to recreate the old index
				CreateForeignKey(oldForeignKeyName, oldPkTable, oldPkColumnList, fkTable, oldFkColumnList);
				throw;
			}
		}

		#endregion

		#endregion

		#region Statistics about table entries

		/// <summary>
		/// Gets the number of records in a table
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns>Amount of physical datarows the table contains</returns>
		internal static int GetRowCount(string tableName)
		{
			object retValue = DBUtil.ExecuteScalarSQL(string.Format(@"SELECT COUNT (1)
			                                                            FROM [{0}]", tableName));
			if (retValue == null || !(retValue is int))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "RowCountFailed", "Counting of rows of table '{0}' failed", KissMsgCode.MsgError, tableName));
			}
			else
			{
				return (int)retValue;
			}
		}

		/// <summary>
		/// Gets the number of values of a column that are NULL 
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <returns>Amount of physical datarows containing NULL as the value of the current column</returns>
		internal static int GetRowWithNULLCount(string tableName, string columnName)
		{
			if (!ExistsColumn(tableName, columnName))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "ColumnNotFound", "Table '{0}' does not contain  a column with name '{1}'", KissMsgCode.MsgError, tableName, columnName));
			}
			object retValue = DBUtil.ExecuteScalarSQL(string.Format(@"SELECT COUNT (1)
			                                                            FROM [{0}]
			                                                            WHERE [{1}] is Null", tableName, columnName));
			if (retValue == null || !(retValue is int))
			{
				throw new KissErrorException(KissMsg.GetMLMessage("XTableColumnDBHandler", "NULLCountFailed", "Counting of NULL rows of table '{0}' and column '{1}' failed", KissMsgCode.MsgError, tableName, columnName));
			}
			else
			{
				return (int)retValue;
			}
		}

		#endregion
	}
}
