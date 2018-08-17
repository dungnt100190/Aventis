using System.Collections.Generic;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;

using Kiss.Database;
using Kiss.Interfaces.BL;

namespace Kiss.BL.KissSystem
{
    /// <summary>
    /// Service for executing  SQL statements.
    /// This is a internal class and must not be
    /// used by view components. The only reason it is public
    /// is because it is useful for unit-tests.
    /// Vorbild: http://commons.apache.org/dbutils/
    /// </summary>
    public class SqlService : ServiceBase
    {
        #region Constructors

        private SqlService()
        {
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>        
        /// Gets the underlying store connection (SqlConnection in our case).
        /// The state of the connection will not be modified by this
        /// method. When the EF-Mock implementation is used, null
        /// will be returned.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <returns>
        /// The store connection (SqlConnection in our case).         
        /// </returns>
        public static IDbConnection GetStoreConnection(IUnitOfWork unitOfWork)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            if (!(unitOfWork is EFUnitOfWork))
            {
                return null;
            }
            var context = ((EFUnitOfWork)unitOfWork).Context;
            if (context != null)
            {
                var entityConnection = (EntityConnection)context.Connection;
                var connection = (SqlConnection)entityConnection.StoreConnection;
                return connection;
            }
            return null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///  Executes the sql statement and returns the result
        ///  as a DataTable. 
        ///  If the EF is mocked, null will be returned.  
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="sql">The sql to execute.</param>
        /// <param name="statementParameters">The parameter values. For example: ("@Name", "Muster")</param>
        /// <returns>null in case of mock, the datatable otherwise.</returns>
        public DataTable Execute(IUnitOfWork unitOfWork, string sql, IDictionary<string, object> statementParameters)
        {
            IDbConnection connection = GetStoreConnection(unitOfWork);
            if (connection == null)
            {
                return null;
            }

            ConnectionState state = connection.State;
            if (state == ConnectionState.Closed)
            {
                connection.Open();
            }

            IDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            foreach (var kv in statementParameters)
            {
                var param = command.CreateParameter();
                param.ParameterName = kv.Key;
                param.Value = kv.Value;
                command.Parameters.Add(param);
            }

            var adapter = new SqlDataAdapter();
            adapter.SelectCommand = (SqlCommand)command;
            var result = new DataTable();
            adapter.Fill(result);

            //var result = command.ExecuteScalar();))
            if (state == ConnectionState.Closed)
            {
                connection.Close();
            }

            return result;
        }

        /// <summary>
        ///  If the EF is mocked, null will be returned.  
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="sql"></param>
        /// <param name="statementParameters"></param>
        /// <returns></returns>
        public DataTable Execute(IUnitOfWork unitOfWork, string sql, params KeyValuePair<string, object>[] statementParameters)
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (var o in statementParameters)
            {
                dictionary.Add(o.Key, o.Value);
            }
            return Execute(unitOfWork, sql, dictionary);
        }

        /// <summary>
        /// Executes an SQL statement that contains parameters in the form {0}, {1}, ...
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable Execute(IUnitOfWork unitOfWork, string sql, params object[] parameters)
        {
            var dictionary = ConvertToCommandParameters(ref sql, parameters);
            return Execute(unitOfWork, sql, dictionary);
        }

        /// <summary>
        /// Executes an SQL statement that contains parameters in the form {0}, {1}, ...
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(IUnitOfWork unitOfWork, string sql, params object[] parameters)
        {
            var dictionary = ConvertToCommandParameters(ref sql, parameters);
            return ExecuteScalar(unitOfWork, sql, dictionary);
        }

        /// <summary>
        /// Executes the statement and returns the scalar value.      
        /// If the EF is mocked, null will be returned.  
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="sql">The sql statement to execute.</param>
        /// <param name="statementParameters">Dictionary with parameters. For example (@name, "duck")</param>
        /// <returns>The result of the sql statement.</returns>
        public object ExecuteScalar(IUnitOfWork unitOfWork, string sql, IDictionary<string, object> statementParameters)
        {
            IDbConnection connection = GetStoreConnection(unitOfWork);
            if (connection == null)
            {
                return null;
            }

            ConnectionState state = connection.State;
            if (state == ConnectionState.Closed)
            {
                connection.Open();
            }

            IDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            foreach (var kv in statementParameters)
            {
                var param = command.CreateParameter();
                param.ParameterName = kv.Key;
                param.Value = kv.Value;
                command.Parameters.Add(param);
            }
            var result = command.ExecuteScalar();
            if (state == ConnectionState.Closed)
            {
                connection.Close();
            }

            return result;
        }

        /// <summary>
        /// See other ExecuteScalar method for documentation.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="sql"></param>
        /// <param name="statementParameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(IUnitOfWork unitOfWork, string sql, params KeyValuePair<string, object>[] statementParameters)
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (var o in statementParameters)
            {
                dictionary.Add(o.Key, o.Value);
            }
            return ExecuteScalar(unitOfWork, sql, dictionary);
        }

        #endregion

        #region Private Static Methods

        private static IDictionary<string, object> ConvertToCommandParameters(ref string sql, params object[] parameters)
        {
            var dictionary = new Dictionary<string, object>();

            for (int i = 0; i < parameters.Length; i++)
            {
                var oldParam = "{" + i + "}";
                var newParam = "@" + i;
                sql = sql.Replace(oldParam, newParam);

                dictionary.Add(newParam, parameters[i]);
            }

            return dictionary;
        }

        #endregion

        #endregion
    }
}