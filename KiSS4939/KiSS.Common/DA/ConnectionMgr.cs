using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

using Autofac;
using Autofac.Builder;
using Autofac.Modules;

namespace KiSS.Common.DA
{
    public class ConnectionMgr
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string KISS_CONNECTION_STRING = "Kiss";

        #endregion

        #region Private Fields

        SqlConnection _cnn;

        #endregion

        #endregion

        #region Properties

        public SqlConnection Connection
        {
            get { return _cnn; }
            set { _cnn = value; }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static MetadataWorkspace GetMetaWorkspaceForType(Type t)
        {
            MetadataWorkspace workspace = new MetadataWorkspace(
                new string[] { "res://*/" },
                new Assembly[] { t.Assembly });

            return workspace;
        }

        #endregion

        #region Public Methods

        public void CloseConnection(IContainer container)
        {
            // autofac hack ...
            List<IComponentRegistration> entityConnectionRegistrations = container
                .ComponentRegistrations
                    .Where(p => p.Descriptor.BestKnownImplementationType == typeof(EntityConnection))
                    .ToList();

            // entity connections
            bool newInstance;

            foreach (IComponentRegistration reg in entityConnectionRegistrations)
            {
                // close and dispose all entity connections
                EntityConnection e = (EntityConnection)reg.ResolveInstance(container, Enumerable.Empty<Parameter>(), container.Disposer, out newInstance);

                if (e.State == System.Data.ConnectionState.Open)
                {
                    e.Close();
                }

                e.Dispose();
                reg.Dispose();
            }

            // connection
            if (_cnn != null)
            {
                _cnn.Close();
                _cnn.Dispose();
                _cnn = null;
            }
        }

        /// <summary>
        /// Creates a new closed <see cref="SQLConnection"/> 
        /// </summary>
        /// <returns>to initialize an EF object context the connection must be closed</returns>
        public void CreateConnection(string connectionString)
        {
            string cnnString;

            if (string.IsNullOrEmpty(connectionString))
            {
                if (ConfigurationManager.ConnectionStrings.Count < 1 ||
                    ConfigurationManager.ConnectionStrings[KISS_CONNECTION_STRING] == null)
                {
                    // TODO: invalid state, catch this to prevent "object reference not set" error > what to do?
                    _cnn = null;
                    return;
                }

                cnnString = ConfigurationManager.ConnectionStrings[KISS_CONNECTION_STRING].ConnectionString;
            }
            else
            {
                cnnString = connectionString;
            }

            _cnn = new SqlConnection(cnnString);
        }

        /// <summary>
        /// Initialize and opens the DB-Connection an the related EF connections  
        /// </summary>
        /// <param name="container">autofac IoC conatiner</param>
        /// <remarks>check again with EF 4</remarks>
        public void OpenConnection(IContainer container)
        {
            // die nachfolge Initialisierung in 2 Schritten ist notwendig, um EF ein SqlConnection zu übergeben
            // 1. alle EntityConnection mit geschlossener (!) SQLConnection erstellen
            // 1b.  SQLConnection öffnen
            // 2. EntityConnection öffnen

            // autofac hack ...
            List<IComponentRegistration> entityConnectionRegistrations = container
                .ComponentRegistrations
                    .Where(p => p.Descriptor.BestKnownImplementationType == typeof(EntityConnection))
                    .ToList();

            // 1.
            bool newInstance;

            foreach (IComponentRegistration reg in entityConnectionRegistrations)
            {
                // diposer ? - sollte keine Rolle spielen, da dies singleton sind
                reg.ResolveInstance(container, Enumerable.Empty<Parameter>(), container.Disposer, out newInstance);
            }

            // 1b.
            if (_cnn.State == System.Data.ConnectionState.Closed)
            {
                _cnn.Open();
            }

            // 2.
            foreach (IComponentRegistration reg in entityConnectionRegistrations)
            {
                EntityConnection e = (EntityConnection)reg.ResolveInstance(container, Enumerable.Empty<Parameter>(), container.Disposer, out newInstance);

                if (e.State == System.Data.ConnectionState.Closed)
                {
                    e.Open();
                }
            }
        }

        #endregion

        #endregion
    }
}