using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraGrid;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.UI;

namespace KiSS4.DB
{
    /// <summary>
    /// Main data access component for KISS, combines DataAdapter, DataTable and DataBinding
    /// </summary>
    [DesignerAttribute(typeof(Designer.SqlQueryDesigner))]
    public class SqlQuery : Component, IListSource, IBindingList, ITypedList, ISupportInitialize, IDataSource
    {
        private const string DEFAULT_CANCEL_BUTTON_TEXT = @"Abbrechen";
        private const string DEFAULT_DELETE_QUESTION = "Soll der Datensatz gelöscht werden ?";
        private const string DEFAULT_REFRESH_BUTTON_TEXT = @"Daten aktualisieren";

        private const string DEFAULT_TIMESTAMP_MESSAGE =
@"Der gewählte Datensatz wurde in der Zwischenzeit von einer anderen Person geändert oder gelöscht.
{0}
Aktualisieren sie die Daten zuerst, um Ihre Änderungen zu speichern.";

        private const string DEFAULT_USER_LABEL_MESSAGE = @"Person: {0}";
        private static readonly Regex _rgxDeleteQuestion = new Regex(@"\[(?<fn>\S+)\]");
        private readonly ArrayList _ambiguousColumns = new ArrayList();

        // the SqlAdapter in use
        private SqlDataAdapter _adapter;

        private bool _adapterCommandsBuilt;
        private bool _allowSelectionChanging = true;
        private bool _batchUpdate;
        private string _cancelButtonText;
        private bool _canDelete;
        private bool _canInsert;
        private bool _canUpdate;
        private int _currentPosition;

        // the DataSet
        private DataSet _dataset;

        // the DataTable
        private DataTable _datatable;

        private DataRow _deletedRow;
        private string _deleteQuestion;
        private string _delStmt;

        // seconds
        private int _fillTimeout = 30;

        private bool _inAfterDeleteEvent;
        private bool _inAfterInsertEvent;
        private bool _inBeforeDeleteEvent;
        private DataRow _insertedRow;

        // seconds
        private int _insertTimeOut = 30;

        private string _insStmt;
        private bool _isBinding;
        private bool _isDeleting;
        private bool _isFilling;
        private bool _isInserting;
        private bool _isSilentPostingFromXDocument;
        private object[] _lastUsedPrms;
        private string _lastUsedSelStmt;
        private bool _noDeleteQuestion;
        private string _refreshButtonText;
        private bool _rowModified;
        private string _selStmt;
        private string _tableName;
        private string _timestampMessage;

        //is set to true in Insert(), to allow users with only 'CanInsert'-right to save multiple times until he selects another row
        private bool _treatCurrentRowAsAdded;

        // Column definitions for TableName
        private TableSchema _ts;

        // seconds
        private int _updateTimeOut = 30;

        private string _updStmt;
        private string _userLabelMessage;

        #region initialization

        /// <summary>
        /// Initialize with container.
        /// </summary>
        public SqlQuery(IContainer container)
        {
            container.Add(this);
            Init();
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        public SqlQuery()
        {
            Init();
        }

        private void Init()
        {
            _dataset = new DataSet();
            _datatable = _dataset.Tables.Add("Table");
            _adapter = new SqlDataAdapter();

            //adapter events
            //adapter.SelectCommand.UpdatedRowSource = UpdateRowSource.Both;
            //adapter.FillError += new FillErrorEventHandler(OnFillError);
            //adapter.RowUpdated += new SqlRowUpdatedEventHandler(OnRowUpdated);
            //adapter.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);

            // data table events
            _datatable.ColumnChanging += OnColumnChanging;
            _datatable.ColumnChanged += OnColumnChanged;
        }

        #endregion initialization

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataset.Dispose();
                _adapter.Dispose();
            }
            base.Dispose(disposing);
        }

        #region designable properties

        /// <summary>
        /// Occurs when the value of the KiSS4.DB.SqlQuery.SelectStatement property has changed.
        /// </summary>
        public event EventHandler SelectStatementChanged;

        /// <summary>
        /// Gets or sets a value indicating whether this SqlQuery use batchUpdate.
        /// </summary>
        [DefaultValue(false)]
        public bool BatchUpdate
        {
            get { return _batchUpdate; }
            set
            {
                _batchUpdate = value;
            }
        }

        /// <summary>
        /// Gets or sets the Text displayed on the cancel button.
        /// </summary>
        [DefaultValue(DEFAULT_CANCEL_BUTTON_TEXT)]
        public string CancelButtonText
        {
            get
            {
                if (_cancelButtonText == null)
                {
                    _cancelButtonText = DesignMode
                                           ? DEFAULT_CANCEL_BUTTON_TEXT
                                           : KissMsg.GetMLMessage("SqlQuery", "CancelButtonText",
                                                                  DEFAULT_CANCEL_BUTTON_TEXT);
                }
                return _cancelButtonText;
            }
            set
            {
                if (DBUtil.IsEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                _cancelButtonText = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this SqlQuery supports inserting.
        /// </summary>
        [DefaultValue(false)]
        public bool CanDelete
        {
            get { return _canDelete; }
            set
            {
                _canDelete = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this SqlQuery supports inserting.
        /// </summary>
        [DefaultValue(false)]
        public bool CanInsert
        {
            get { return _canInsert; }
            set
            {
                _canInsert = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this SqlQuery supports updating.
        /// </summary>
        [DefaultValue(false)]
        public bool CanUpdate
        {
            get
            {
                //The row can be updated either with CanUpdate-right or with CanInsert-right (if the row was just inserted)
                return _canUpdate || (_treatCurrentRowAsAdded && _canInsert);
            }
            set
            {
                _canUpdate = value;
            }
        }

        /// <summary>
        /// Gets or sets the delete confirmation question.
        /// </summary>
        [DefaultValue(DEFAULT_DELETE_QUESTION)]
        public string DeleteQuestion
        {
            get
            {
                if (!_noDeleteQuestion && _deleteQuestion == null)
                {
                    _deleteQuestion = DesignMode
                                         ? DEFAULT_DELETE_QUESTION
                                         : KissMsg.GetMLMessage("SqlQuery", "DefaultDeleteQuestion",
                                                                DEFAULT_DELETE_QUESTION);
                }

                return _deleteQuestion;
            }
            set
            {
                _noDeleteQuestion = DBUtil.IsEmpty(value);
                _deleteQuestion = value;
            }
        }

        /// <summary>
        /// Gets or sets the timeout in seconds for the fill operation (default 30 sec)
        /// </summary>
        [DefaultValue(30)]
        public int FillTimeOut
        {
            get { return _fillTimeout; }
            set { _fillTimeout = value; }
        }

        /// <summary>
        /// Gets or sets the timeout in seconds for the insert operation (default 30 sec).
        /// Change this value only if really required.
        /// </summary>
        [DefaultValue(30)]
        [Description("Gets or sets the timeout in seconds for the insert operation (default 30 sec). Change this value only if really required.")]
        public int InsertTimeOut
        {
            get { return _insertTimeOut; }
            set { _insertTimeOut = value; }
        }

        public bool IsIdentityInsert
        {
            get { return _isIdentityInsert; }
            set
            {
                if (value != _isIdentityInsert)
                {
                    _isIdentityInsert = value;
                    _adapterCommandsBuilt = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Query on which this Query depends for saving.
        /// </summary>
        [DefaultValue(null)]
        public SqlQuery MasterQuery { set; get; }

        /// <summary>
        /// Gets or sets the Text displayed on the Refresh Button.
        /// </summary>
        [DefaultValue(DEFAULT_REFRESH_BUTTON_TEXT)]
        public string RefreshButtonText
        {
            get
            {
                if (_refreshButtonText == null)
                {
                    _refreshButtonText = DesignMode ? DEFAULT_REFRESH_BUTTON_TEXT : KissMsg.GetMLMessage("SqlQuery", "RefreshButtonText", DEFAULT_REFRESH_BUTTON_TEXT);
                }
                return _refreshButtonText;
            }
            set
            {
                if (DBUtil.IsEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                _refreshButtonText = value;
            }
        }

        /// <summary>
        /// Gets or sets the select statement.
        /// </summary>
        [DefaultValue(null)]
        [Editor(typeof(Designer.SqlStatementEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectStatement
        {
            get { return _selStmt; }
            set
            {
                if (value != null && value.Trim() == string.Empty)
                    value = null;
                if (_selStmt == value)
                    return;

                _selStmt = value;
                OnSelectStatementChanged(EventArgs.Empty);
                _adapterCommandsBuilt = false;
            }
        }

        /// <summary>
        /// Gets or sets table name.
        /// </summary>
        [DefaultValue(null)]
        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                if (value != null && value.Trim() == string.Empty)
                    value = null;
                if (value != _tableName)
                {
                    _tableName = value;
                    _adapterCommandsBuilt = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the timestamp error message.
        /// </summary>
        [DefaultValue(DEFAULT_TIMESTAMP_MESSAGE)]
        public string TimestampMessage
        {
            get
            {
                if (_timestampMessage == null)
                {
                    _timestampMessage = DesignMode
                                           ? DEFAULT_TIMESTAMP_MESSAGE
                                           : KissMsg.GetMLMessage("SqlQuery", "DefaultTimestampMessage",
                                                                  DEFAULT_TIMESTAMP_MESSAGE);
                }
                return _timestampMessage;
            }
            set
            {
                if (DBUtil.IsEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }
                _timestampMessage = value;
            }
        }

        public bool TreatRowAsInserted { get { return _treatCurrentRowAsAdded; } }

        /// <summary>
        /// Gets or sets the timeout in seconds for the update operation (default 30 sec).
        /// Change this value only if really required.
        /// </summary>
        [DefaultValue(30)]
        [Description("Gets or sets the timeout in seconds for the update operation (default 30 sec). Change this value only if really required.")]
        public int UpdateTimeOut
        {
            get { return _updateTimeOut; }
            set { _updateTimeOut = value; }
        }

        /// <summary>
        /// Gets or sets the Text displayed on the Refresh Button.
        /// </summary>
        [DefaultValue(DEFAULT_USER_LABEL_MESSAGE)]
        public string UserLabelMessage
        {
            get
            {
                if (_userLabelMessage == null)
                {
                    _userLabelMessage = DesignMode ? DEFAULT_USER_LABEL_MESSAGE : KissMsg.GetMLMessage("SqlQuery", "UserLabelMessage", DEFAULT_USER_LABEL_MESSAGE);
                }
                return _userLabelMessage;
            }
            set
            {
                if (DBUtil.IsEmpty(value))
                    throw new ArgumentNullException("value");
                _userLabelMessage = value;
            }
        }

        /// <summary>
        /// Raise the KiSS4.DB.SqlQuery.SelectStatementChanged event.
        /// </summary>
        /// <param name="e">e: An System.EventArgs that contains the event data.</param>
        protected virtual void OnSelectStatementChanged(EventArgs e)
        {
            if (SelectStatementChanged != null)
                SelectStatementChanged(this, e);
        }

        #endregion designable properties

        #region AutoApplyUserRights

        private bool _autoApplyUserRights = true;

        /// <summary>
        /// Gets or sets a value whether user rights sould be applied automatically.
        /// </summary>
        [DefaultValue(true)]
        public bool AutoApplyUserRights
        {
            get { return _autoApplyUserRights; }
            set { _autoApplyUserRights = value; }
        }

        /// <summary>
        /// Apply user righs with the right name set to the <see cref="SqlQuery"/>'s host control name.
        /// </summary>
        public void ApplyUserRights()
        {
            if (HostControl != null)
                ApplyUserRights(HostControl.GetType().Name);
        }

        /// <summary>
        /// Apply user righs with the specified right name.
        /// </summary>
        public void ApplyUserRights(string rightName)
        {
            DBUtil.ApplyUserRightsToSqlQuery(rightName, this);
        }

        #endregion AutoApplyUserRights

        #region runtime properties

        /// <summary>
        /// Gets the <see cref="DataSet"/> containing the datatable.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataSet DataSet
        {
            get { return _dataset; }
        }

        /// <summary>
        /// Gets the <see cref="DataTable"/> holding the data.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTable DataTable
        {
            get { return _datatable; }
        }

        /// <summary>
        /// Gets or sets the delete statement.
        /// </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        public string DeleteStatement
        {
            get { return _delStmt; }
            set
            {
                if (value != null && value.Trim() == string.Empty)
                    value = null;

                _delStmt = value;
            }
        }

        /// <summary>
        /// Gets the identity column of the base table of the query
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string IdentityColumnName
        {
            get
            {
                if (TableName == null)
                    return null;
                BuildAdapterCommands();
                if (_ts.IdentityColumn == null)
                    return null;
                return _ts.IdentityColumn.DataColumn.ColumnName;
            }
        }

        /// <summary>
        /// Gets or sets the insert statement.
        /// </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        public string InsertStatement
        {
            get { return _insStmt; }
            set
            {
                if (value != null && value.Trim() == string.Empty)
                    value = null;

                _insStmt = value;
            }
        }

        /// <summary>
        /// Gets if DataAdapter is currently Binding Controls
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsBinding
        {
            get { return _isBinding; }
        }

        /// <summary>
        /// Return true if is inDeleting
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDeleting
        {
            get { return _isDeleting; }
        }

        /// <summary>
        /// Returns true if the query is empty.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        /// <summary>
        /// Gets if DataAdapter is currently Filling
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsFilling
        {
            get { return _isFilling; }
            set { _isFilling = value; } // for special purposes
        }

        /// <summary>
        /// Return true if is isInserting
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsInserting
        {
            get { return _isInserting; }
        }

        /// <summary>
        /// Gets or sets the update statement.
        /// </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        public string UpdateStatement
        {
            get { return _updStmt; }
            set
            {
                if (value != null && value.Trim() == string.Empty)
                    value = null;

                _updStmt = value;
            }
        }

        #endregion runtime properties

        #region Public Events

        /// <summary>
        /// Occurs after a row is deleted from the database.
        /// </summary>
        public event EventHandler AfterDelete;

        /// <summary>
        /// Raised after <see cref="Fill()"/> is called.
        /// </summary>
        /// <remarks>
        /// Here you can add Relation between tables
        /// </remarks>
        public event EventHandler AfterFill;

        /// <summary>
        /// Raised after the <see cref="Insert()"/> Operation is finished.
        /// </summary>
        /// <remarks>
        /// The new row can be initialized with Field values, before user interaction
        /// </remarks>
        public event EventHandler AfterInsert;

        /// <summary>
        /// Occurs after a row is updated/inserted in the database.
        /// </summary>
        public event EventHandler AfterPost;

        /// <summary>
        /// Occurs before a row is deleted from the database (After Deletequestion).
        /// </summary>
        /// <remarks>
        /// Can be cancelled by throwing an exception
        /// Use this Event to implement your own Delete routine and call Row.AcceptChanges() to turn of SQLQuery delete.
        /// DON'T throw KissCancelException if you not realy want to cancel the delete action
        /// </remarks>
        public event EventHandler BeforeDelete;

        /// <summary>
        /// Occurs before a row is deleted from the database (Before Deletequestion).
        /// </summary>
        /// <remarks>
        /// Can be cancelled by throwing an exception
        /// Use this Event to check if a row can deleted
        /// </remarks>
        public event EventHandler BeforeDeleteQuestion;

        /// <summary>
        /// Raised before <see cref="Insert()"/> is called.
        /// </summary>
        /// <remarks>
        /// The insert operation can be cancelled by throwing an exception or values of the current row can be saved for later use after the insert
        /// </remarks>
        public event EventHandler BeforeInsert;

        /// <summary>
        /// Occurs before a row is updated/inserted in the database.
        /// </summary>
        /// <remarks>
        /// place validating code here. Can be cancelled by throwing an exception
        /// </remarks>
        public event EventHandler BeforePost;

        /// <summary>
        /// Occurs when a column has changed.
        /// </summary>
        public event DataColumnChangeEventHandler ColumnChanged;

        /// <summary>
        /// Occurs when a column changes.
        /// </summary>
        public event DataColumnChangeEventHandler ColumnChanging;

        /// <summary>
        /// raised if an error occurs during a Delete operation
        /// </summary>
        public event UnhandledExceptionEventHandler DeleteError;

        /// <summary>
        /// Raised when <see cref="Position"/> has changed.
        /// </summary>
        /// <remarks>
        /// Place synchronizing code here (Update unbound fields. Master/Detail updates)
        /// </remarks>
        public event EventHandler PositionChanged;

        /// <summary>
        ///
        /// </summary>
        public event EventHandler PositionChanging;

        /// <summary>
        /// Occurs after a Post has successfully completed
        /// </summary>
        public event EventHandler PostCompleted;

        /// <summary>
        /// raised if an error occurs during a Post operation
        /// </summary>
        public event UnhandledExceptionEventHandler PostError;

        #endregion Public Events

        #region OnXXX methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual bool OnPositionChanging(object sender, EventArgs e)
        {
            if (!AllowSelectionChanging)
            {
                return false;
            }

            // 10.07.2009 : nein, auch wenn kein PositionChanging definiert wurde,
            // soll Kontolle mit Post() gemacht werden
            //if (isFilling || PositionChanging == null) return true;
            if (_isFilling || _isDeleting)
                return true;

            EndCurrentEdit();

            // 10.07.2009 : wenn Post nicht true zurückgibt, soll die Zeile nicht verlassen werden können.
            // Und zwar sowohl im normalen wie auch im BatchUpdate-Modus
            // dehalb Korrektur (vorher wurde immer true zurückgeliefert):
            // in PositionChanging kann individuell eine Exception geworfen werden, wenn erwünscht
            //PositionChanging(sender, e);
            try
            {
                if (PositionChanging != null)
                    PositionChanging(sender, e);
            }
            catch
            {
                return false;
            }

            return true;

            // TODO : introduce a Post here systematically
            // Take care : all implementations with a Post in OnPositionChanging or OnPositionChanged
            // have to be corrected : eliminate the Post in OnPositionChanging or OnPositionChanged
            //return Post();
        }

        /// <summary>
        /// Raises the <see cref="AfterDelete"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual bool OnAfterDelete(object sender, EventArgs e)
        {
            if (AfterDelete == null)
                return true;
            try
            {
                _inAfterDeleteEvent = true;
                AfterDelete(sender, e);
            }
            finally
            {
                _inAfterDeleteEvent = false;
            }
            return true;
        }

        /// <summary>
        /// Raises the <see cref="AfterFill"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnAfterFill(object sender, EventArgs e)
        {
            if (AfterFill != null)
            {
                AfterFill(sender, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="AfterInsert"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual bool OnAfterInsert(object sender, EventArgs e)
        {
            if (AfterInsert == null)
                return true;
            try
            {
                _inAfterInsertEvent = true;

                AfterInsert(sender, e);

                ApplicationFacade.DoEvents();
                RefreshDisplay();
            }
            finally
            {
                _inAfterInsertEvent = false;
            }
            return true;
        }

        /// <summary>
        /// Raises the <see cref="AfterPost"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual bool OnAfterPost(object sender, EventArgs e)
        {
            if (AfterPost == null)
                return true;

            AfterPost(sender, e);

            return true;
        }

        /// <summary>
        /// If the <see cref="DeleteQuestion"/> is specified, asks for delete confirmation, then raises the <see cref="BeforeDelete"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual bool OnBeforeDelete(object sender, EventArgs e)
        {
            if (BeforeDelete == null)
                return true;
            try
            {
                _inBeforeDeleteEvent = true;
                BeforeDelete(sender, e);
            }
            // 10.04.2009 : Umbau Transaktionen
            catch
            {
                return false;
            }
            finally
            {
                _inBeforeDeleteEvent = false;
            }
            return true;
        }

        /// <summary>
        /// Raises the <see cref="BeforeDeleteQuestion"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual bool OnBeforeDeleteQuestion(object sender, EventArgs e)
        {
            if (BeforeDeleteQuestion == null)
                return true;

            BeforeDeleteQuestion(sender, e);

            return true;
        }

        /// <summary>
        /// Raises the <see cref="BeforeInsert"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual bool OnBeforeInsert(object sender, EventArgs e)
        {
            if (BeforeInsert == null)
                return true;

            BeforeInsert(sender, e);

            return true;
        }

        /// <summary>
        /// Raises the <see cref="BeforePost"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual bool OnBeforePost(object sender, EventArgs e)
        {
            if (BeforePost == null)
                return true;

            BeforePost(sender, e);

            return true;
        }

        /// <summary>
        /// Raises the <see cref="ColumnChanged"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (_isFilling || _isBinding || _isDeleting)
                return;

            RowModified = !_inAfterInsertEvent;
            if (ColumnChanged != null)
                ColumnChanged(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ColumnChanging"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (_isFilling || _isBinding || _isDeleting)
                return;

            if (ColumnChanging != null)
                ColumnChanging(this, e);
        }

        /// <summary>
        /// Raises the <see cref="DeleteError"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnDeleteError(object sender, UnhandledExceptionEventArgs e)
        {
            if (DeleteError != null)
                DeleteError(sender, e);
        }

        /// <summary>
        /// Called when <see cref="Position"/> has changed. Raises the <see cref="PositionChanged"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnPositionChanged(object sender, EventArgs e)
        {
            if (Row == null)
            {
                RowModified = false;
            }
            else if (BatchUpdate && RowModified)
            {
                RowModified = false;

                foreach (DataRow row in _datatable.Rows)
                {
                    if (row.RowState != DataRowState.Unchanged)
                    {
                        RowModified = true;
                        break;
                    }
                }
            }
            else if (Row.RowState == DataRowState.Unchanged)
            {
                RowModified = false;
            }
            // TODO : && !isDeleting && !iscanceling
            if (PositionChanged != null && !_isFilling && !_isInserting)
            {
                PositionChanged(sender, e);
            }

            //The user moved to another row, from now on, Post()-calls are only allowed with CanUpdate-right
            _treatCurrentRowAsAdded = false;
            //In case, the user is allowed to update (_canUpdate is true), but a PositionChanged-Eventhandler disabled some fields
            //we should not enable these fields again with EnableBoundFields(_canUpdate).
            //On the other hand, if he is not allowed to update, we should disable them.
            if (!_canUpdate)
            {
                EnableBoundFields(_canUpdate);
            }
        }

        /// <summary>
        /// Raises the <see cref="PostCompleted"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnPostCompleted(object sender, EventArgs e)
        {
            if (PostCompleted == null)
                return;
            PostCompleted(sender, e);
        }

        /// <summary>
        /// Raises the <see cref="PostError"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnPostError(object sender, UnhandledExceptionEventArgs e)
        {
            if (PostError != null)
                PostError(sender, e);
        }

        #endregion OnXXX methods

        #region Fill operations

        private bool _allowEdit = true;

        /// <summary>
        /// Bind IKissBindableEdit Control on the Hostcontrol to the SqlQuery
        /// </summary>
        public void BindControls()
        {
            try
            {
                if (_hostControl != null)
                    BindControls(_hostControl, true);
            }
            catch (Exception ex)
            {
                if (!HandleException(ex))
                    throw;
            }
        }

        /// <summary>
        /// Change Layout of IKissBindableEdit Control on the Hostcontrol depend on AllowEdit
        /// </summary>
        /// <param name="allowEdit">Editing allowed</param>
        public void EnableBoundFields(bool allowEdit)
        {
            _allowEdit = allowEdit;
            if (_hostControl != null)
            {
                EnableBoundFields(_hostControl, _allowEdit);
            }
        }

        /// <summary>
        /// Change Layout of IKissBindableEdit Control on the Hostcontrol depend on last AllowEdit Value
        /// </summary>
        public void EnableBoundFields()
        {
            EnableBoundFields(_allowEdit && (_canInsert || _canUpdate || _canDelete));
        }

        /// <summary>
        /// Fill with Statement in property <see cref="SelectStatement"/>.
        /// </summary>
        /// <returns>True if successfully executed, false if exception occured</returns>
        public bool Fill()
        {
            return Fill(_selStmt, null);
        }

        /// <summary>
        /// Fill with <see cref="SelectStatement"/>, replacing parameters.
        /// </summary>
        /// <param name="selectParameters">Additional parameters to use within current<see cref="SelectStatement"/></param>
        /// <returns>True if successfully executed, false if exception occured</returns>
        public bool Fill(params object[] selectParameters)
        {
            return Fill(_selStmt, selectParameters);
        }

        /// <summary>
        /// Fill with supplied select statement, replacing parameters.
        /// </summary>
        /// <param name="selectStatement">The select statement to execute</param>
        /// <param name="selectParameters">Addtitional parameters to use within given select statement</param>
        /// <returns>True if successfully executed, false if exception occured</returns>
        public bool Fill(string selectStatement, params object[] selectParameters)
        {
            _isFilling = true;

            if (!Session.Active)
                return false;

            if (selectStatement == null && _tableName == null)
                throw new InvalidOperationException("Fill: SelectStatement is not supplied.");
            //			if (canInsert && tableName == null && insStmt == null)
            //				throw new InvalidOperationException("Fill / CanInsert: Neither InsertStatement or TableName are supplied.");
            //			if (canUpdate && tableName == null && updStmt == null)
            //				throw new InvalidOperationException("Fill / CanUpdate: Neither UpdateStatement nor TableName are supplied.");
            //			if (canDelete && tableName == null && delStmt == null)
            //				throw new InvalidOperationException("Fill / CanDelete: Neither DeleteStatement nor TableName are supplied.");

            SqlDataAdapter adapter = _adapter;

            // clean up dataset
            _dataset.Relations.Clear();
            for (int i = _dataset.Tables.Count - 1; i >= 0; i--)
            {
                DataTable dt = _dataset.Tables[i];

                if (dt != _datatable)
                {
                    dt.Constraints.Clear();
                    _dataset.Tables.Remove(dt);
                }
            }
            UnbindControls();
            _datatable.Clear(); // full refresh of datatable

            Cursor saveCursor = Cursor.Current;
            Cursor.Current = Cursors.AppStarting;

            try
            {
                #region select statement - build stmt from TableName or bind parameters

                if (selectStatement == null)
                    adapter.SelectCommand = DBUtil.CreateSqlCommand(string.Format("SELECT * FROM [{0}]", _tableName), null);
                else
                    adapter.SelectCommand = DBUtil.CreateSqlCommand(selectStatement, selectParameters);

                #endregion select statement - build stmt from TableName or bind parameters

                #region select from database

                if (Session.Transaction != null)
                    adapter.SelectCommand.Transaction = Session.Transaction;

                try
                {
                    adapter.SelectCommand.CommandTimeout = _fillTimeout;

                    lock (Session.Connection)
                    {
                        adapter.Fill(_dataset);
                    }
                }
                catch (Exception ex)
                {
                    // failure
                    if (ex is SqlException)
                    {
                        SqlException s = (SqlException)ex;
                        switch (s.Number)
                        {
                            case -2:
                                // timeout expired
                                throw new KissErrorException(KissMsg.GetMLMessage(
                                    "SqlQuery",
                                    "ZeitUeberschritten_v01",
                                    "Die erlaubte Zeit ({0} Sekunden) für diese Abfrage wurde überschritten.",
                                    KissMsgCode.MsgError,
                                    _fillTimeout));
                        }
                    }

                    throw new KissErrorException(KissMsg.GetMLMessage(
                        "SqlQuery",
                        "FehlerDatenabfrage_v01",
                        "Fehler bei der Datenabfrage.",
                        KissMsgCode.MsgError),
                        adapter.SelectCommand == null ? "" : DBUtil.SqlCommandToString(adapter.SelectCommand), ex);
                }

                // reset restricting properties on columns
                foreach (DataTable dt in _dataset.Tables)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        dc.AllowDBNull = true;
                        dc.AutoIncrement = false;
                        if (dc.ReadOnly && dc.Expression == string.Empty)
                            dc.ReadOnly = false;
                    }
                }

                #endregion select from database

                #region Find AmbiguousColumns

                if (_lastUsedSelStmt != selectStatement)
                {
                    _ambiguousColumns.Clear();

                    for (int i = 0; i < _datatable.Columns.Count; ++i)
                    {
                        string strAmbigName = _datatable.Columns[i].ColumnName + "1";

                        for (int y = i + 1; y < _datatable.Columns.Count; ++y)
                        {
                            if (strAmbigName.Equals(_datatable.Columns[y].ColumnName) && selectStatement.IndexOf(strAmbigName) == -1)
                                _ambiguousColumns.Add(_datatable.Columns[i].ColumnName);
                        }
                    }
                }

                #endregion Find AmbiguousColumns

                SelectStatement = selectStatement;
                _lastUsedSelStmt = selectStatement;
                _lastUsedPrms = selectParameters;

                OnAfterFill(this, EventArgs.Empty);

                if (_hostControl != null)
                {
                    BindControls();
                    EnableBoundFields(CanUpdate && _datatable.Rows.Count > 0);
                }

                foreach (DataRow row in DataTable.Rows)
                {
                    if (row.RowState != DataRowState.Added && row.RowState != DataRowState.Unchanged)
                        row.AcceptChanges();
                }

                _isFilling = false;
                if (_datatable.Rows.Count > 0 && !IsDeleting)
                {
                    OnPositionChanged(this, EventArgs.Empty); //force event to synchronize positioning
                }
                _currentPosition = 0;

                // return if success or failure
                return true;
            }
            catch (Exception ex)
            {
                if (ex is KissCancelException)
                {
                    if (!HandleException(ex))
                        throw;
                }
                else
                {
                    KissCancelException kissEx = new KissErrorException(
                        KissMsg.GetMLMessage("SqlQuery", "FehlerDatenabfrage_v01",
                        "Fehler bei der Datenabfrage.",
                        KissMsgCode.MsgError),
                        adapter.SelectCommand == null ? "" : DBUtil.SqlCommandToString(adapter.SelectCommand), ex);

                    if (!HandleException(kissEx))
                        throw kissEx;
                }

                // failure
                return false;
            }
            finally
            {
                _isFilling = false;
                Cursor.Current = saveCursor;
            }
        }

        /// <summary>
        /// Find Row in Datatable and set Position
        /// </summary>
        /// <param name="searchExpression"></param>
        /// <returns></returns>
        public bool Find(string searchExpression)
        {
            return Find(searchExpression, DataTable.DefaultView.Sort);
        }

        /// <summary>
        /// Find Row in Datatable and set Position
        /// </summary>
        /// <param name="searchExpression"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public bool Find(string searchExpression, string sort)
        {
            DataRow[] rows = DataTable.Select(searchExpression, sort);
            if (rows.Length == 0)
                return false;

            for (int i = 0; i < DataTable.DefaultView.Count; i++)
            {
                if (rows[0] == DataTable.DefaultView[i].Row)
                {
                    Position = i;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns Find-Expression for the current Row
        /// </summary>
        /// <returns></returns>
        public string GetSearchExpression()
        {
            if (Count == 0 || TableName == null || Row.RowState == DataRowState.Deleted)
                return null;

            // save values of primary key columns
            if (!_adapterCommandsBuilt)
                BuildAdapterCommands();
            if (_ts != null)
            {
                ArrayList alFindExpression = new ArrayList();

                foreach (TableCol col in _ts.PrimaryKeyColumns)
                {
                    if (this[col.Name] == DBNull.Value)
                        alFindExpression.Add(string.Format("{0} = NULL", col.Name));
                    else if (this[col.Name] is int)
                        alFindExpression.Add(string.Format("{0} = {1}", col.Name, this[col.Name]));
                    else
                        alFindExpression.Add(string.Format("{0} = '{1}'", col.Name, this[col.Name]));
                }

                if (alFindExpression.Count > 0)
                    return string.Join(" AND ", (string[])alFindExpression.ToArray(typeof(string)));
            }

            return null;
        }

        /// <summary>
        /// Redo Last Fill and try to reposition.
        /// </summary>
        public void Refresh()
        {
            if (DBUtil.IsEmpty(_lastUsedSelStmt))
                return;

            if (!Post())
            {
                if (!KissMsg.ShowQuestion("SqlQuery", "DatenansichtAktualisieren", "Datenansicht trotz der nicht gespeicherten Daten aktualisieren ?"))
                    return;
            }

            RefreshSilent();
        }

        /// <summary>
        /// Unbind IKissBindableEdit Control on the Hostcontrol to the SqlQuery
        /// </summary>
        public void UnbindControls()
        {
            try
            {
                if (_hostControl != null)
                    BindControls(_hostControl, false);
            }
            catch (Exception ex)
            {
                if (!HandleException(ex))
                    throw;
            }
        }

        internal static bool HandleException(Exception ex)
        {
            if (Session.Transaction == null)
            {
                if (ex is KissCancelException)
                {
                    ((KissCancelException)ex).ShowMessage();
                }
                else
                {
                    KissMsg.ShowError(ex.Message);
                }

                return true;
            }
            return false;
        }

        private void BindControls(Control baseControl, bool bind)
        {
            _isBinding = true;

            foreach (Control ctl in baseControl.Controls)
            {
                if (ctl.Controls.Count > 0)
                    BindControls(ctl, bind); // rekursiver Aufruf

                if (ctl is IKissBindableEdit)
                {
                    IKissBindableEdit edt = (IKissBindableEdit)ctl;

                    if (edt.DataSource == this && edt.DataMember != string.Empty)
                    {
                        var kissBaseControl = baseControl as IKissActiveSQLQuery;
                        var kissHostControl = _hostControl as IKissActiveSQLQuery;

                        if (baseControl.BindingContext[this] != _hostControl.BindingContext[this] &&
                            (kissBaseControl == null || kissHostControl == null || kissBaseControl.ActiveSQLQuery == kissHostControl.ActiveSQLQuery))
                            baseControl.BindingContext = _hostControl.BindingContext;
                        if (ctl is UserControl && ctl.BindingContext[this] != _hostControl.BindingContext[this])
                            ctl.BindingContext = _hostControl.BindingContext;

                        ctl.DataBindings.Clear();
                        if (bind)
                        {
                            try
                            {
                                if (Count == 0)
                                {
                                    //reset Value to DBNull (data binding doesn't do that if query has no rows)
                                    try
                                    {
                                        PropertyInfo prop = edt.GetType().GetProperty(edt.GetBindablePropertyName());

                                        if (prop.PropertyType == typeof(string))
                                            prop.SetValue(edt, string.Empty, null);
                                        else
                                            prop.SetValue(edt, DBNull.Value, null);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new KissErrorException(
                                            KissMsg.GetMLMessage("SqlQuery", "ErrorBoundControl",
                                            "Error setting bound control to null.\r\nControl: {0}\r\nProperty: {1}", KissMsgCode.MsgError, ctl.Name, edt.GetBindablePropertyName())
                                            , ex);
                                    }
                                }

                                if (!DBUtil.IsEmpty(edt.DataMember))
                                    ctl.DataBindings.Add(edt.GetBindablePropertyName(), edt.DataSource, edt.DataMember);
                            }
                            catch (Exception ex)
                            {
                                if (ex is KissCancelException)
                                    throw;

                                throw new KissErrorException(
                                     KissMsg.GetMLMessage("SqlQuery", "FehlerDatenkopplung",
                                     "Fehler bei der Datenkopplung: Feld '{0}'", KissMsgCode.MsgError, edt.DataMember)
                                     , ex);
                            }
                        }
                    }
                }
            }

            _isBinding = false;
        }

        private void EnableBoundFields(Control baseControl, bool allowEdit)
        {
            foreach (Control ctl in baseControl.Controls)
            {
                if (ctl.Controls.Count > 0)
                    EnableBoundFields(ctl, allowEdit); // rekursiver Aufruf

                if (ctl is IKissBindableEdit)
                {
                    IKissBindableEdit edt = (IKissBindableEdit)ctl;
                    if (edt.DataSource == this && (edt.DataMember != string.Empty || edt is IKissEditable))
                    {
                        edt.AllowEdit(allowEdit);
                    }
                }
            }
        }

        private void EndEditGrids(Control baseControl)
        {
            foreach (Control ctl in baseControl.Controls)
            {
                if (ctl.Controls.Count > 0)
                    EndEditGrids(ctl); // rekursiver Aufruf

                if (ctl is GridControl && ((GridControl)ctl).DataSource == this)
                {
                    ((GridControl)ctl).MainView.CloseEditor();
                    ((GridControl)ctl).MainView.UpdateCurrentRow();
                }
            }
        }

        /// <summary>
        /// Reads the values in the database and updates the userinterface.
        /// The user will not be asked in case he already changed some
        /// values.
        /// </summary>
        private void RefreshSilent()
        {
            if (DBUtil.IsEmpty(_lastUsedSelStmt))
                return;

            string searchExpression = GetSearchExpression();
            Fill(_lastUsedSelStmt, _lastUsedPrms);
            if (Count > 1 && searchExpression != null)
                Find(searchExpression);
        }

        #endregion Fill operations

        #region Insert, Post, Delete, Undo, RefreshDisplay

        /// <summary>
        /// Cancel changes on the current row.
        /// Do not use in transactions.
        /// </summary>
        public bool Cancel()
        {
            // 06.04.2009: Umbau Transaktionen:
            // privsorische Fehlermeldung, wenn Cancel in einer Transaktion aufgerufen wird:
            if (Session.Transaction != null && (Row.RowState == DataRowState.Added || RowModified))
            {
                KissMsg.ShowInfo("Programmierfehler: SqlQuery.Cancel wird innerhalb einer Transaktion aufgerufen.");
            }

            if (Count == 0)
            {
                return true;
            }

            // check manager
            if (_manager != null)
            {
                if (_manager.Position == -1)
                    return true;

                // get all pending edits
                _manager.EndCurrentEdit();
                if (_hostControl != null)
                    EndEditGrids(_hostControl);
            }

            Row.EndEdit();

            if (Row.RowState == DataRowState.Added)
            {
                if (RowModified)
                {
                    if (!KissMsg.ShowQuestion("SqlQuery", "NeuenDatensatzLoeschen", "Neuen Datensatz wieder löschen ?"))
                    {
                        return false;
                    }
                }

                // 10.04.2009 : Umbau Transaktionen
                // Verhindern, dass später ein Post aufgerufen wird:
                _isDeleting = true;

                try
                {
                    if (_manager != null)
                    {
                        _manager.RemoveAt(_manager.Position);
                        RefreshDisplay();
                    }
                    else
                    {
                        _datatable.Rows.RemoveAt(Position);
                        _currentPosition = Count - 1;
                    }
                }
                finally
                {
                    _isDeleting = false;
                }

                if (Count == 0)
                {
                    EnableBoundFields(false);
                }
                else if (Count > 0)
                {
                    OnPositionChanged(this, EventArgs.Empty); //force event to synchronize positioning
                }
            }
            else
            {
                if (!RowModified)
                {
                    return true;
                }

                if (!KissMsg.ShowQuestion("SqlQuery", "AenderungenRueckgaengig", "Änderungen an diesem Datensatz rückgängig machen ?"))
                {
                    return false;
                }

                Row.RejectChanges();
                RefreshDisplay();
                OnPositionChanged(this, EventArgs.Empty); //force event to synchronize positioning
            }

            return true;
        }

        /// <summary>
        /// Delete the current row.
        /// </summary>
        /// <remarks>(Temporary enable CanDelete)</remarks>
        /// <param name="tableName"></param>
        public bool Delete(string tableName)
        {
            bool canDelete = CanDelete;
            CanDelete = true;

            try
            {
                if (tableName != null)
                    TableName = tableName;
                return Delete();
            }
            finally
            {
                CanDelete = canDelete;
            }
        }

        /// <summary>
        /// Delete the current row.
        /// </summary>
        public bool Delete()
        {
            try
            {
                // check manager
                if (_manager != null)
                {
                    if (_manager.Position == -1 || _manager.Current == null)
                        return false;
                }
                else
                {
                    if (Position == -1)
                        return false;
                }

                if (Row.RowState == DataRowState.Added)
                {
                    // Bei einer neuen Zeile soll nur rückgängig gemacht werden:
                    return Cancel();
                }

                if (!_canDelete)
                {
                    throw new KissErrorException(KissMsg.GetMLMessage(
                        "SqlQuery",
                        "DatensatzLoeschenNichtErlaubt",
                        "Das Löschen dieses Datensatzes ist nicht erlaubt !",
                        KissMsgCode.MsgError),
                        "SqlQuery.CanDelete = false", null);
                }

                bool transOpenInBeforeDelete = (Session.Transaction == null);

                _isDeleting = true;
                try
                {
                    _deletedRow = Row;

                    // raise the OnBeforeDeleteQuestion event
                    if (!OnBeforeDeleteQuestion(this, EventArgs.Empty))
                    {
                        return false;
                    }

                    // get confirmation from user
                    if (!_noDeleteQuestion)
                    {
                        string dq = DeleteQuestion;
                        MatchCollection matches = _rgxDeleteQuestion.Matches(DeleteQuestion);
                        foreach (Match m in matches)
                        {
                            Capture cap = m.Groups["fn"].Captures[0];
                            string fieldname = cap.Value;
                            string fieldvalue;
                            try { fieldvalue = _deletedRow[fieldname].ToString(); }
                            catch { fieldvalue = "???"; }
                            dq = dq.Substring(0, m.Index) + fieldvalue + dq.Substring(m.Index + m.Length);
                        }
                        if (!KissMsg.ShowQuestion(dq))
                        {
                            return false;
                        }
                    }

                    // Clone the Row so it can be accessed in the AfterDelete Event

                    #region RecordClone

                    DataRow deletedRowClone = null;
                    try
                    {
                        if (AfterDelete != null)
                        {
                            deletedRowClone = DataTable.NewRow();
                            deletedRowClone.ItemArray = _deletedRow.ItemArray;
                        }
                    }
                    catch { deletedRowClone = null; }

                    #endregion RecordClone

                    _deletedRow.Delete();
                    if (_batchUpdate)
                        return true;

                    // raise the OnBeforeDelete event
                    if (_deletedRow.RowState == DataRowState.Deleted && !OnBeforeDelete(this, EventArgs.Empty))
                    {
                        _deletedRow.RejectChanges();
                        return false;
                    }

                    // perform delete
                    try
                    {
                        if (_deletedRow.RowState != DataRowState.Detached)
                        {
                            if (!_adapterCommandsBuilt)
                                BuildAdapterCommands();
                            if (Session.Transaction != null)
                                _adapter.DeleteCommand.Transaction = Session.Transaction;
                            lock (Session.Connection)
                                _adapter.Update(new DataRow[] { _deletedRow });
                        }

                        _deletedRow = deletedRowClone; //Row State of deletedRow is detached, but Fields can be accessed

                        OnAfterDelete(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        _deletedRow.RejectChanges();

                        // raise the DeleteError event
                        OnDeleteError(this, new UnhandledExceptionEventArgs(ex, false));

                        if (ex is SqlException)
                        {
                            SqlException s = (SqlException)ex;
                            switch (s.Number)
                            {
                                case 547:
                                    // statement conflicted with constraint ...
                                    throw new KissErrorException(KissMsg.GetMLMessage(
                                        "SqlQuery", "ErstDatenLoeschen",
                                        "Es bestehen noch abhängige Daten. Diese müssen zuerst gelöscht werden",
                                        KissMsgCode.MsgError), ex);
                            }
                        }

                        throw new KissErrorException(KissMsg.GetMLMessage(
                            "SqlQuery", "FehlerLoeschen",
                            "Beim Löschen des Datensatzes ist ein Fehler aufgetreten !",
                            KissMsgCode.MsgError), ex);
                    }

                    if (_hostControl != null)
                        EnableBoundFields(CanUpdate && _datatable.Rows.Count > 0);

                    if (_datatable.Rows.Count > 0)
                        OnPositionChanged(this, EventArgs.Empty); //force event to synchronize positioning
                    else
                        EnableBoundFields(false);

                    if (_manager == null && _datatable.Rows.Count == _currentPosition)
                        _currentPosition--;
                }
                finally
                {
                    // Wenn die Transaktion vor SqlQuery.Delete ist,
                    // dann muss bei Fehlern die Transkation hier geschlossen werden
                    if (transOpenInBeforeDelete && (Session.Transaction != null))
                    {
                        Session.Rollback();
                    }

                    _isDeleting = false;
                    _deletedRow = null;
                }
                return true;
            }
            catch (Exception ex)
            {
                if (ex is KissCancelException)
                {
                    if (!HandleException(ex))
                        throw;
                }
                else
                {
                    KissCancelException kissEx = new KissErrorException(KissMsg.GetMLMessage(
                        "SqlQuery", "FehlerLoeschen",
                        "Beim Löschen des Datensatzes ist ein Fehler aufgetreten !", KissMsgCode.MsgError),
                        ex);

                    if (!HandleException(kissEx))
                        throw kissEx;
                }

                return false;
            }
        }

        /// <summary>
        /// Add a new row to the <see cref="DataTable"/>. (Temporary enable CanInsert)
        /// </summary>
        /// <remarks>(Temporary enable CanInsert)</remarks>
        /// <param name="tableName"></param>
        /// <returns>The row added to the table.</returns>
        public DataRow Insert(string tableName)
        {
            bool canInsert = CanInsert;
            CanInsert = true;

            try
            {
                if (tableName != null)
                    TableName = tableName;

                return Insert();
            }
            finally
            {
                CanInsert = canInsert;
            }
        }

        /// <summary>
        /// Add a new row to the <see cref="DataTable"/>.
        /// </summary>
        /// <remarks>
        /// <see cref="OnAfterInsert"/> is called for the created row, which in turn raises the <see cref="AfterInsert"/> event.
        /// The row will be added to the <see cref="DataTable"/>, but not persisted to the database yet.
        /// </remarks>
        /// <returns>The row added to the table.</returns>
        public DataRow Insert()
        {
            try
            {
                if (!_canInsert)
                {
                    throw new KissErrorException(KissMsg.GetMLMessage(
                        "SqlQuery",
                        "DatensatzEinfuegenNichtErlaubt",
                        "Das Einfügen eines Datensatzes ist nicht erlaubt !",
                        KissMsgCode.MsgError),
                        "SqlQuery.CanInsert = false", null);
                }

                if (!(OnPositionChanging(this, EventArgs.Empty) && (_batchUpdate || Post())))
                    return null;

                _isInserting = true;
                try
                {
                    // raise the BeforeInsert event
                    if (!OnBeforeInsert(this, EventArgs.Empty))
                    {
                        return null;
                    }

                    // create new row
                    _insertedRow = _datatable.NewRow();

                    // add the row to the datatable
                    _datatable.Rows.Add(_insertedRow);

                    // necessary if no manager is available (try to position)
                    if (_manager == null)
                        _currentPosition = Count - 1;
                    if (!Row.Equals(_insertedRow))
                    {
                        Last();
                        if (!Row.Equals(_insertedRow))
                            First();
                        if (!Row.Equals(_insertedRow) && Debugger.IsAttached)
                            Debugger.Break();
                    }

                    // Set default values
                    try
                    {
                        BuildAdapterCommands();
                        if (_ts != null)
                        {
                            foreach (TableCol tc1 in _ts)
                            {
                                try
                                {
                                    if (tc1.DataColumn != null && tc1.DefaultValue != DBNull.Value)
                                    {
                                        string defaultValue = tc1.DefaultValue.ToString().ToLower();

                                        if (defaultValue == "null")
                                            continue;

                                        if (tc1.Type == SqlDbType.Bit)
                                            _insertedRow[tc1.DataColumn.ColumnName] = defaultValue == "1";
                                        else if (defaultValue == "getdate()")
                                            _insertedRow[tc1.DataColumn.ColumnName] = DateTime.Now;
                                        else if (defaultValue == "datepart(year,getdate())")
                                            _insertedRow[tc1.DataColumn.ColumnName] = DateTime.Today.Year;
                                        else
                                            _insertedRow[tc1.DataColumn.ColumnName] = Convert.ChangeType(tc1.DefaultValue, tc1.DataColumn.DataType);
                                    }
                                }
                                catch
                                {
                                    if (Debugger.IsAttached)
                                    {
                                        Debugger.Break();
                                    }
                                }
                            }
                        }
                    }
                    catch { }

                    if (_hostControl != null)
                    {
                        EnableBoundFields(true);
                    }

                    RowModified = false;

                    SetCreatorCreatedIfExists();

                    // raise the AfterInsert event
                    OnAfterInsert(this, EventArgs.Empty);
                }
                finally
                {
                    _isInserting = false;
                }

                OnPositionChanged(this, EventArgs.Empty);

                //The user inserts a new row, any Post()-calls are allowed also if he only has CanInsert-right until he moves to another row.
                _treatCurrentRowAsAdded = true;
                EnableBoundFields(_canInsert);

                return _insertedRow;
            }
            catch (Exception ex)
            {
                if (ex is KissCancelException)
                {
                    if (!HandleException(ex))
                        throw;
                }
                else
                {
                    KissCancelException kissEx = new KissErrorException(KissMsg.GetMLMessage(
                        "SqlQuery", "FehlerEinfügen",
                        "Beim Einfügen des Datensatzes ist ein Fehler aufgetreten !", KissMsgCode.MsgError),
                        ex);

                    if (!HandleException(kissEx))
                        throw kissEx;
                }

                return null;
            }
        }

        /// <summary>
        /// Save the inserted or updated row to the database (Errors are displayed)
        /// </summary>
        /// <remarks>(Temporary enable CanUpdate)</remarks>
        /// <param name="tableName"></param>
        public bool Post(string tableName)
        {
            bool canUpdate = CanUpdate;
            CanUpdate = true;

            try
            {
                if (tableName != null)
                    TableName = tableName;

                return Post();
            }
            finally
            {
                CanUpdate = canUpdate;
            }
        }

        /// <summary>
        /// Save the inserted or updated row to the database (Errors are displayed)
        /// </summary>
        public bool Post()
        {
            return Post(true);
        }

        /// <summary>
        /// Save the inserted or updated row to the database (Errors are displayed)
        /// </summary>
        public bool Post(bool performEndEditGrids)
        {
            return Post(performEndEditGrids, false);
        }

        /// <summary>
        /// Save the inserted or updated row to the database (Errors are displayed)
        /// </summary>
        public bool Post(bool performEndEditGrids, bool isSilentPosting)
        {
            // In XDocument we call sqlQuery.Post in order to tell other users, the file is beeing edited.
            // In those cases we wont let the mutation-User being changed,
            // thus we introduced isSilentPostingFromXDocument:
            if (isSilentPosting)
            {
                _isSilentPostingFromXDocument = true;
            }

            try
            {
                if (_inAfterInsertEvent || _inAfterDeleteEvent || _isDeleting)
                {
                    return true;
                }

                // check manager
                if (_manager != null)
                {
                    if (_manager.Position == -1)
                    {
                        return true;
                    }

                    // get all pending edits
                    EndCurrentEdit(performEndEditGrids);
                }
                else
                {
                    if (Count == 0)
                    {
                        return true;
                    }
                }

                bool insertMode = (Row.RowState == DataRowState.Added);

                if (insertMode)
                {
                    // check if RowModified was reset programmatically
                    if (!RowModified)
                    {
                        // suppress BeforePost event and delete unsaved row
                        if (_manager != null)
                        {
                            _manager.RemoveAt(_manager.Position);
                        }
                        else
                        {
                            _datatable.Rows.RemoveAt(Position);
                        }

                        if (_hostControl != null)
                        {
                            EnableBoundFields(CanUpdate && _datatable.Rows.Count > 0);
                        }

                        // retrigger PositionChanged Event in case of special enabling/disabling application logic
                        if (_datatable.Rows.Count > 0)
                        {
                            OnPositionChanged(this, EventArgs.Empty);
                        }

                        return true;
                    }
                }
                else
                {
                    if (BatchUpdate)
                    {
                        if (Row.RowState == DataRowState.Unchanged)
                        {
                            // unchanged row or programmatically reset RowModified: nothing to do
                            return true;
                        }
                    }
                    else
                    {
                        // not batch update, do check rowModified
                        if (!RowModified && Row.RowState == DataRowState.Unchanged)
                        {
                            // unchanged row or programmatically reset RowModified: nothing to do
                            return true;
                        }
                    }

                    // update allowed?
                    if (!CanUpdate)
                    {
                        throw new KissErrorException(KissMsg.GetMLMessage(
                            "SqlQuery",
                            "DatensatzVeraendernNichtErlaubt",
                            "Das Verändern dieses Datensatzes ist nicht erlaubt !",
                            KissMsgCode.MsgError),
                            "SqlQuery.CanUpdate = false", null);
                    }
                }

                // Normalize value
                foreach (DataColumn dc in _datatable.Columns)
                {
                    // create object instances as (val != Row[dc]) is true even when the real value is the same
                    object val = Row[dc];
                    object valNormalized = DBUtil.Normalized(val);

                    if (val != valNormalized)
                    {
                        // apply normalized value
                        Row[dc] = valNormalized;
                    }
                }

                bool transOpenInBeforePost = (Session.Transaction == null);

                try
                {
                    SetModifierModifiedIfExists();

                    // raise the BeforePost event
                    if (!OnBeforePost(this, EventArgs.Empty))
                    {
                        return false;
                    }

                    // state changed to DataRowState.Unchanged: nothing left to do
                    if (Row.RowState == DataRowState.Unchanged && !RowModified)
                    {
                        return true;
                    }

                    // return if sqlQuery is in Batchupdate mode
                    if (_batchUpdate)
                    {
                        return true;
                    }

                    // perform update
                    try
                    {
                        if (Row.RowState != DataRowState.Unchanged)
                        {
                            if (!_adapterCommandsBuilt)
                            {
                                BuildAdapterCommands();
                            }

                            if (Session.Transaction != null)
                            {
                                if (_adapter.InsertCommand != null)
                                {
                                    _adapter.InsertCommand.Transaction = Session.Transaction;
                                }

                                if (_adapter.UpdateCommand != null)
                                {
                                    _adapter.UpdateCommand.Transaction = Session.Transaction;
                                }
                            }

                            if (_adapter.UpdateCommand != null)
                            {
                                // set insert or update timeout (KiSS does not use the adapter.Insert() method)
                                _adapter.UpdateCommand.CommandTimeout = insertMode ? _insertTimeOut : _updateTimeOut;
                            }

                            lock (Session.Connection)
                            {
                                _adapter.Update(new[] { Row });
                            }
                        }

                        if (OnAfterPost(this, EventArgs.Empty))
                        {
                            if (Row != null)
                            {
                                Row.AcceptChanges();
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        // raise the PostError event
                        OnPostError(this, new UnhandledExceptionEventArgs(ex, false));

                        if (ex is KissCancelException)
                        {
                            throw;
                        }

                        //The exception that is thrown by the DataAdapter during an insert, update, or delete
                        //operation if the number of rows affected equals zero.
                        //KiSS example of an update:
                        //  WHERE [BaPersonID]=@BaPersonID_old AND [BaPersonTS]=@BaPersonTS_old;
                        if (ex is DBConcurrencyException)
                        {
                            string message = TimestampMessage;
                            string userName = GetUserNameOfLastModifier();

                            if (string.IsNullOrEmpty(userName))
                            {
                                //In this case, we don't know the username.
                                message = string.Format(message, string.Empty);
                            }
                            else
                            {
                                string submessage = string.Format(UserLabelMessage, userName);
                                message = string.Format(message, submessage);
                            }

                            string messageAbbrechen = CancelButtonText;
                            string messageReload = RefreshButtonText;

                            string[] buttons = { messageAbbrechen, messageReload };

                            //Ask the user if he wants to reload the database values (and loose his changes).
                            int result = KissMsg.ShowButtonDlg(message, buttons);

                            switch (result)
                            {
                                //0: cancel
                                case 0:
                                    return false;

                                //1: reload from db
                                case 1:
                                    Row.RejectChanges();
                                    RefreshSilent();
                                    return false;

                                default:
                                    return false;
                            }
                        }
                        else if (ex is SqlException)
                        {
                            var s = (SqlException)ex;

                            switch (s.Number)
                            {
                                case 2601:
                                case 2627:
                                    // duplicate key
                                    throw new KissErrorException(KissMsg.GetMLMessage(
                                        "SqlQuery", "DatensatzExistiertBereits",
                                        "Ein Datensatz mit dieser Identifikation existiert bereits", KissMsgCode.MsgError),
                                        ex);

                                case 515:
                                    // Cannot insert the value NULL into column ...
                                    throw new KissErrorException(KissMsg.GetMLMessage(
                                        "SqlQuery", "MussfeldLeer",
                                        "Nicht alle Mussfelder sind ausgefüllt", KissMsgCode.MsgError),
                                        ex);

                                case 547:
                                    // statement conflicted with constraint ...
                                    // to provide a specific error-message, we have to determine whether
                                    // it was a CHECK or a FOREIGN KEY constraint
                                    string constraintName;
                                    bool isCheckConstraint;
                                    AnalyzeConstraintViolation(ex, out constraintName, out isCheckConstraint);
                                    if (isCheckConstraint)
                                    {
                                        throw new KissErrorException(KissMsg.GetMLMessage(
                                            "SqlQuery", "IntegritaetsCheckFehlgeschlagen",
                                            "Der Integritäts-Check '{0}' hat im Datensatz fehlerhafte Daten gefunden, welche so nicht gespeichert werden können", KissMsgCode.MsgError, constraintName),
                                            ex);
                                    }
                                    else
                                    {
                                        throw new KissErrorException(KissMsg.GetMLMessage(
                                            "SqlQuery", "DatensatzExistiertNicht",
                                            "Ein Feld verweist auf einen Datensatz einer anderen Tabelle, der nicht existiert", KissMsgCode.MsgError),
                                            ex);
                                    }
                                case 8152:
                                    // String or binary data would be truncated
                                    throw new KissErrorException(KissMsg.GetMLMessage(
                                        "SqlQuery",
                                        "StringOrBinaryDataWouldBeTruncated",
                                        "Der Inhalt eines Feldes überschreitet die maximal zugelassene Länge.\r\n\r\nBitte kürzen Sie zuerst den Inhalt und versuchen Sie anschliessend nochmals zu speichern.", KissMsgCode.MsgError),
                                        DBUtil.SqlCommandToString(_adapter.UpdateCommand), ex);

                                case -2:
                                    // timeout expired
                                    if (insertMode)
                                    {
                                        throw new KissErrorException(KissMsg.GetMLMessage(
                                            "SqlQuery",
                                            "ZeitUeberschrittenInsert_v01",
                                            "Die erlaubte Zeit ({0} Sekunden) für das Einfügen des Datensatzes wurde überschritten.",
                                            KissMsgCode.MsgError,
                                            _insertTimeOut));
                                    }
                                    else
                                    {
                                        throw new KissErrorException(KissMsg.GetMLMessage(
                                            "SqlQuery",
                                            "ZeitUeberschrittenUpdate_v01",
                                            "Die erlaubte Zeit ({0} Sekunden) für das Ändern des Datensatzes wurde überschritten.",
                                            KissMsgCode.MsgError,
                                            _updateTimeOut));
                                    }

                                default:
                                    if (insertMode)
                                    {
                                        throw new KissErrorException(KissMsg.GetMLMessage(
                                            "SqlQuery", "DatensatzVeraendernNichtErlaubt",
                                            "Das Verändern dieses Datensatzes ist nicht erlaubt !", KissMsgCode.MsgError),
                                            DBUtil.SqlCommandToString(_adapter.UpdateCommand), ex);
                                    }
                                    else
                                    {
                                        throw new KissErrorException(KissMsg.GetMLMessage(
                                            "SqlQuery", "FehlerSpeichernMutDatensatz",
                                            "Beim Speichern des veränderten Datensatzes ist ein Fehler aufgetreten !", KissMsgCode.MsgError),
                                            DBUtil.SqlCommandToString(_adapter.UpdateCommand), ex);
                                    }
                            }
                        }
                        else
                        {
                            throw new KissErrorException(KissMsg.GetMLMessage(
                                "SqlQuery", "FehlerSpeichern",
                                "Beim Speichern des Datensatzes ist ein Fehler aufgetreten !", KissMsgCode.MsgError),
                                _adapter.UpdateCommand == null ? "" : DBUtil.SqlCommandToString(_adapter.UpdateCommand), ex);
                        }
                    }
                }
                finally
                {
                    if (transOpenInBeforePost && (Session.Transaction != null))
                    {
                        Session.Rollback();
                    }
                }

                if (Row != null && Row.RowState == DataRowState.Unchanged)
                {
                    RowModified = false;
                    OnPostCompleted(this, EventArgs.Empty);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex is KissCancelException)
                {
                    if (!HandleException(ex))
                    {
                        throw;
                    }
                }
                else
                {
                    KissCancelException kissEx = new KissErrorException(KissMsg.GetMLMessage(
                        "SqlQuery", "FehlerSpeichern",
                        "Beim Speichern des Datensatzes ist ein Fehler aufgetreten !", KissMsgCode.MsgError),
                        _adapter.UpdateCommand == null ? "" : DBUtil.SqlCommandToString(_adapter.UpdateCommand), ex);

                    if (!HandleException(kissEx))
                    {
                        throw kissEx;
                    }
                }

                // failure
                return false;
            }
            finally
            {
                _isSilentPostingFromXDocument = false;
            }
        }

        /// <summary>
        /// Refresh values of bound Controls
        /// </summary>
        public void RefreshDisplay()
        {
            if (_manager == null)
                return;
            _manager.Refresh();
        }

        private void AnalyzeConstraintViolation(Exception ex, out string constraintName, out bool isCheckConstraint)
        {
            string message = ex.Message;
            int startIndex = message.IndexOf('"');
            if (startIndex != -1)
            {
                //we don't want the leading "\""
                startIndex++;

                int endIndex = message.IndexOf('"', startIndex);
                if (endIndex != -1)
                {
                    constraintName = message.Substring(startIndex, endIndex - startIndex);
                    isCheckConstraint = constraintName.StartsWith("CK");
                    return;
                }
            }
            constraintName = string.Empty;
            isCheckConstraint = false;
        }

        /// <summary>
        /// Gets the logonname of the last
        /// modifier of the current row.
        /// The actual value stored in the db is read.
        ///
        /// If there is no column named "Modifier" or in case of any other
        /// error, null will be returned.
        /// </summary>
        /// <returns>The logonname</returns>
        private String GetUserNameOfLastModifier()
        {
            //Check if a column named "Modifier" exists.
            if (_ts["Modifier"] == null)
            {
                return null;
            }

            string selStatement = _lastUsedSelStmt;
            object[] parameters = _lastUsedPrms;

            if (selStatement == null || parameters == null)
            {
                return null;
            }

            SqlQuery query = DBUtil.OpenSQL(selStatement, parameters);

            object modifiedValueObj = query["Modifier"];

            if (modifiedValueObj == null)
            {
                return null;
            }

            //Extract the id from the string modifiedValueObj
            const string pattern = @"(.*)\(";    //an example: "Diartis Support (12)".
            string name;
            Regex regex = new Regex(pattern);
            Match match = regex.Match(modifiedValueObj.ToString());
            if (match.Success)
            {
                name = match.Groups[1].Value.Trim();
            }
            else
            {
                return null;
            }
            return name;
        }

        #endregion Insert, Post, Delete, Undo, RefreshDisplay

        #region Creator/Created Modifier/Modified

        /// <summary>
        /// Apply default values to column "Creator"
        /// </summary>
        /// <remarks>
        /// Expects column exists on query, otherwise an exception will occure.
        /// The column "Created" must have a default value and therefore doesn't need to be set here.
        /// </remarks>
        public void SetCreator()
        {
            // apply Creator of datarow
            this[Constant.CREATOR] = DBUtil.GetDBRowCreatorModifier();
            this[Constant.CREATED] = DateTime.Now;
        }

        /// <summary>
        /// Apply default values to columns "Modifier" and "Modified"
        /// </summary>
        /// <remarks>Expects both columns exist on query, otherwise an exception will occure</remarks>
        public void SetModifierModified()
        {
            // apply Modifier and Modified datetime of datarow
            this[Constant.MODIFIER] = DBUtil.GetDBRowCreatorModifier();
            this[Constant.MODIFIED] = DateTime.Now;
        }

        /// <summary>
        /// Apply default values to column "Creator" if this column exists on query
        /// </summary>
        private void SetCreatorCreatedIfExists()
        {
            if (DataTable.Columns.Contains(Constant.CREATOR) && DataTable.Columns.Contains(Constant.CREATED))
            {
                SetCreator();
            }
        }

        /// <summary>
        /// Apply default values to columns "Modifier" and "Modified" if both columns exists on query
        /// </summary>
        private void SetModifierModifiedIfExists()
        {
            if (DataTable.Columns.Contains(Constant.MODIFIER) && DataTable.Columns.Contains(Constant.MODIFIED))
            {
                SetModifierModified();
            }
        }

        #endregion Creator/Created Modifier/Modified

        #region Manager support

        private ContainerControl _hostControl;
        private bool _isIdentityInsert;
        private CurrencyManager _manager;

        /// <summary>
        /// Gets or Sets the AllowPositionChanging property
        /// set to false to force the DataSource to stay on the same position
        /// </summary>
        [Browsable(false)]
        [DefaultValue(true)]
        public bool AllowSelectionChanging
        {
            get { return _allowSelectionChanging; }
            set { _allowSelectionChanging = value; }
        }

        /// <summary>
        /// Gets or sets the HostControl
        /// </summary>
        [DefaultValue(null)]
        public ContainerControl HostControl
        {
            get { return _hostControl; }
            set
            {
                _hostControl = value;
                if (_hostControl != null && !DesignMode)
                {
                    _manager = (CurrencyManager)_hostControl.BindingContext[this];

                    _manager.PositionChanged -= OnPositionChanged;
                    _manager.PositionChanged += OnPositionChanged;
                }
                else
                    _manager = null;
            }
        }

        /// <summary>
        /// Indicates, if the posting should change mutation information (user-ID and date) or  not.
        /// Is only used in XDocument yet
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        public bool IsSilentPostingFromXDocument
        {
            get { return _isSilentPostingFromXDocument; }
        }

        /// <summary>
        /// Gets the current <see cref="DataRow"/> - or null, if no current row.
        /// </summary>
        [Browsable(false)]
        public DataRow Row
        {
            get
            {
                if (_inAfterInsertEvent)
                    return _insertedRow;
                else if (_inBeforeDeleteEvent || _inAfterDeleteEvent)
                    return _deletedRow;
                else
                {
                    if (_manager == null)
                    {
                        if (Position != -1)
                            return _datatable.Rows[Position];
                    }
                    else
                    {
                        if (_manager.Position != -1)
                            return ((DataRowView)_manager.Current).Row;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Gets or Sets the RowModified property
        /// set to true to force the BeforePost() Event
        /// will be automatically set to false after PositionChanged, Post, Insert and Delete
        /// will be automatically set to true after ColumnChanged
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        public bool RowModified
        {
            get { return _rowModified; }
            set
            {
                _rowModified = value;

                if (MasterQuery != null)
                {
                    MasterQuery.RowModified = MasterQuery.RowModified || value;
                }
            }
        }

        /// <summary>
        /// Gets the Value of the named Column of the current <see cref="DataRowView"/>
        /// </summary>
        [Browsable(false)]
        public object this[string columnName, DataRowVersion rowVer]
        {
            get
            {
                try
                {
                    DataRow curRow = Row;
                    if (curRow == null)
                        return null;

                    if (_ambiguousColumns.Contains(columnName))
                    {
                        throw new KissErrorException(KissMsg.GetMLMessage(
                            "SqlQuery",
                            "AbfrageFeldExistiertMehrfach_v01",
                            "Fehler bei der Feldabfrage: Feld '{0}' existiert mehrfach.",
                            KissMsgCode.MsgError,
                            columnName),
                            _adapter.SelectCommand == null ? "" : DBUtil.SqlCommandToString(_adapter.SelectCommand), null);
                    }
                    return curRow[columnName, rowVer];
                }
                catch (Exception ex)
                {
                    if (ex is KissCancelException)
                    {
                        if (!HandleException(ex))
                            throw;
                    }
                    else
                    {
                        KissCancelException kissEx = new KissErrorException(KissMsg.GetMLMessage(
                            "SqlQuery",
                            "AbfrageFeldExistiertNicht_v01",
                            "Fehler bei der Feldabfrage: Feld '{0}' existiert nicht.",
                            KissMsgCode.MsgError,
                            columnName),
                            _adapter.SelectCommand == null ? "" : DBUtil.SqlCommandToString(_adapter.SelectCommand), ex);

                        if (!HandleException(kissEx))
                            throw kissEx;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the Value of the named Column of the current <see cref="DataRowView"/>
        /// </summary>
        [Browsable(false)]
        public object this[string columnName]
        {
            get
            {
                try
                {
                    DataRow curRow = Row;
                    if (curRow == null)
                        return null;

                    if (_ambiguousColumns.Contains(columnName))
                    {
                        throw new KissErrorException(KissMsg.GetMLMessage(
                            "SqlQuery",
                            "AbfrageFeldExistiertMehrfach",
                            "Fehler bei der Feldabfrage: Feld '{0}' existiert mehrfach.",
                            KissMsgCode.MsgError,
                            columnName),
                            _adapter.SelectCommand == null ? "" : DBUtil.SqlCommandToString(_adapter.SelectCommand), null);
                    }

                    if (curRow.HasVersion(DataRowVersion.Current))
                    {
                        return curRow[columnName];
                    }
                    else if (curRow.RowState == DataRowState.Deleted)
                    {
                        return curRow[columnName, DataRowVersion.Original];
                    }
                    else if (curRow.RowState == DataRowState.Detached)
                    {
                        return curRow[columnName];
                    }
                    else
                    {
                        return DBNull.Value;
                    }
                }
                catch (Exception ex)
                {
                    if (ex is KissCancelException)
                    {
                        if (!HandleException(ex))
                            throw;
                    }
                    else
                    {
                        KissCancelException kissEx = new KissErrorException(KissMsg.GetMLMessage(
                            "SqlQuery",
                            "AbfrageFeldExistiertNicht",
                            "Fehler bei der Feldabfrage: Feld '{0}' existiert nicht",
                            KissMsgCode.MsgError,
                            columnName),
                            _adapter.SelectCommand == null ? "" : DBUtil.SqlCommandToString(_adapter.SelectCommand), ex);

                        if (!HandleException(kissEx))
                            throw kissEx;
                    }

                    return null;
                }
            }

            set
            {
                SetValue(columnName, value, true);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the spcified column in the specified row has been modified.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        public bool ColumnModified(DataRow row, string columnName)
        {
            if (row.HasVersion(DataRowVersion.Original))
            {
                object orig = row[columnName, DataRowVersion.Original];
                object curr = row[columnName, DataRowVersion.Current];

                if (orig.GetType().IsArray && curr.GetType().IsArray && ((Array)orig).Length == ((Array)curr).Length)
                {
                    for (int i = 0; i < ((Array)orig).Length; i++)
                    {
                        if (!((Array)orig).GetValue(i).Equals(((Array)curr).GetValue(i)))
                        {
                            return true;
                        }
                    }

                    return false;
                }

                return !orig.Equals(curr);
            }

            return RowModified;
        }

        /// <summary>
        /// Gets a value indicating whether the specified column of the current row has been modified.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        public bool ColumnModified(string columnName)
        {
            return ColumnModified(Row, columnName);
        }

        /// <summary>
        /// Call EndCurrentEdit() of the CurrencyManager
        /// </summary>
        public void EndCurrentEdit()
        {
            EndCurrentEdit(false);
        }

        /// <summary>
        /// Call EndCurrentEdit() of the CurrencyManager
        /// </summary>
        public void EndCurrentEdit(bool performEndEditGrids)
        {
            if (_manager != null)
            {
                _manager.EndCurrentEdit();

                if (_hostControl != null && performEndEditGrids)
                    EndEditGrids(_hostControl);
            }
        }

        #region RowNavigation

        /// <summary>
        /// Gets the current Position - or -1 if no current row.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(-1)]
        public int Position
        {
            get
            {
                if (Count == 0)
                    return -1;
                else if (_manager != null)
                    return _manager.Position;
                else if (_currentPosition < Count)
                    return _currentPosition;
                else
                    return Count - 1;
            }
            set
            {
                // immer noch auf derselben Zeile; nix tun
                if (_currentPosition == value && (_manager == null || _manager.Position == value))
                {
                    return;
                }

                // man will auf Zeile wechseln die es nicht gibt. nix tun
                if (value >= Count)
                {
                    return;
                }

                // save changes first
                if (!Post())
                {
                    return;
                }

                if (_manager != null)
                {
                    _manager.Position = value;
                }
                else
                {
                    if (_currentPosition != value)
                    {
                        _currentPosition = value;
                        OnPositionChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the Position to the First Row
        /// </summary>
        public bool First()
        {
            if (Count == 0)
            {
                return false;
            }
            else if (!OnPositionChanging(this, EventArgs.Empty))
            {
                return false;
            }
            else if (Position != 0)
            {
                if (!Post())
                    return false;
                Position = 0;
            }
            return true;
        }

        /// <summary>
        /// Sets the Position to the Last Row
        /// </summary>
        public bool Last()
        {
            if (Count == 0)
            {
                return false;
            }
            else if (!OnPositionChanging(this, EventArgs.Empty))
            {
                return false;
            }
            else if (Position != (Count - 1))
            {
                if (!Post())
                    return false;
                Position = (Count - 1);
            }
            return true;
        }

        /// <summary>
        /// Sets the Position to the Next Row
        /// </summary>
        public bool Next()
        {
            if (Position >= (Count - 1))
            {
                return false;
            }
            else if (!OnPositionChanging(this, EventArgs.Empty))
            {
                return false;
            }
            else
            {
                if (!Post())
                    return false;
                Position++;
                return true;
            }
        }

        /// <summary>
        /// Sets the Position to the Previous Row
        /// </summary>
        public bool Previous()
        {
            if (Count == 0 || Position == 0)
            {
                return false;
            }
            else if (!OnPositionChanging(this, EventArgs.Empty))
            {
                return false;
            }
            else
            {
                if (!Post())
                    return false;
                Position--;
                return true;
            }
        }

        #endregion RowNavigation

        public void SetValue(string columnName, object value, bool normalize)
        {
            try
            {
                if (_ambiguousColumns.Contains(columnName))
                {
                    throw new KissErrorException(KissMsg.GetMLMessage(
                        "SqlQuery",
                        "ZuweisungFeldExistiertMehrfach",
                        "Fehler bei der Feldzuweisung: Feld '{0}' existiert mehrfach.",
                        KissMsgCode.MsgError,
                        columnName),
                        _adapter.SelectCommand == null ? "" : DBUtil.SqlCommandToString(_adapter.SelectCommand), null);
                }

                if (Row != null)
                {
                    if (normalize)
                    {
                        Row[columnName] = DBUtil.Normalized(value);
                    }
                    else
                    {
                        Row[columnName] = value;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is KissCancelException)
                {
                    if (!HandleException(ex))
                        throw;
                }
                else
                {
                    KissCancelException kissEx = new KissErrorException(KissMsg.GetMLMessage(
                        "SqlQuery",
                        "ZuweisungFeldExistiertNicht",
                        "Fehler bei der Feldzuweisung: Feld '{0}' existiert nicht.",
                        KissMsgCode.MsgError,
                        columnName),
                        _adapter.SelectCommand == null ? "" : DBUtil.SqlCommandToString(_adapter.SelectCommand), ex);

                    if (!HandleException(kissEx))
                        throw kissEx;
                }
            }
        }

        #endregion Manager support

        #region IListSource

        bool IListSource.ContainsListCollection { get { return ((IListSource)_datatable).ContainsListCollection; } }

        IList IListSource.GetList()
        {
            return ((IListSource)_datatable).GetList();
        }

        #endregion IListSource

        #region ICollection

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        [Browsable(false)]
        public int Count { get { return ((ICollection)_datatable.DefaultView).Count; } }

        bool ICollection.IsSynchronized { get { return ((ICollection)_datatable.DefaultView).IsSynchronized; } }

        object ICollection.SyncRoot { get { return ((ICollection)_datatable.DefaultView).SyncRoot; } }

        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)_datatable.DefaultView).CopyTo(array, index);
        }

        #endregion ICollection

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_datatable.DefaultView).GetEnumerator();
        }

        #endregion IEnumerable

        #region IList

        bool IList.IsFixedSize { get { return ((IList)_datatable.DefaultView).IsFixedSize; } }

        bool IList.IsReadOnly { get { return ((IList)_datatable.DefaultView).IsReadOnly; } }

        object IList.this[int index]
        {
            get { return ((IList)_datatable.DefaultView)[index]; }
            set { ((IList)_datatable.DefaultView)[index] = value; }
        }

        int IList.Add(object value)
        {
            Debug.WriteLine("IList.Add"); return ((IList)_datatable.DefaultView).Add(value);
        }

        void IList.Clear()
        {
            ((IList)_datatable.DefaultView).Clear();
        }

        bool IList.Contains(object value)
        {
            return ((IList)_datatable.DefaultView).Contains(value);
        }

        int IList.IndexOf(object value)
        {
            return ((IList)_datatable.DefaultView).IndexOf(value);
        }

        void IList.Insert(int index, object value)
        {
            Debug.WriteLine("IList.Insert"); ((IList)_datatable.DefaultView).Insert(index, value);
        }

        void IList.Remove(object value)
        {
            ((IList)_datatable.DefaultView).Remove(value);
        }

        void IList.RemoveAt(int index)
        {
            ((IList)_datatable.DefaultView).RemoveAt(index);
        }

        #endregion IList

        #region IBindingList

        event ListChangedEventHandler IBindingList.ListChanged
        {
            add { ((IBindingList)_datatable.DefaultView).ListChanged += value; }
            remove { ((IBindingList)_datatable.DefaultView).ListChanged -= value; }
        }

        bool IBindingList.AllowEdit { get { return _canUpdate; } }

        bool IBindingList.AllowNew { get { return _canInsert; } }

        bool IBindingList.AllowRemove { get { return _canDelete; } }

        bool IBindingList.IsSorted { get { return ((IBindingList)_datatable.DefaultView).IsSorted; } }

        ListSortDirection IBindingList.SortDirection { get { return ((IBindingList)_datatable.DefaultView).SortDirection; } }

        PropertyDescriptor IBindingList.SortProperty { get { return ((IBindingList)_datatable.DefaultView).SortProperty; } }

        bool IBindingList.SupportsChangeNotification { get { return ((IBindingList)_datatable.DefaultView).SupportsChangeNotification; } }

        bool IBindingList.SupportsSearching { get { return ((IBindingList)_datatable.DefaultView).SupportsSearching; } }

        bool IBindingList.SupportsSorting { get { return ((IBindingList)_datatable.DefaultView).SupportsSorting; } }

        void IBindingList.AddIndex(PropertyDescriptor property)
        {
            ((IBindingList)_datatable.DefaultView).AddIndex(property);
        }

        object IBindingList.AddNew()
        {
            Debug.WriteLine("IBindingList.AddNew"); return ((IBindingList)_datatable.DefaultView).AddNew();
        }

        void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            ((IBindingList)_datatable.DefaultView).ApplySort(property, direction);
        }

        int IBindingList.Find(PropertyDescriptor property, object key)
        {
            return ((IBindingList)_datatable.DefaultView).Find(property, key);
        }

        void IBindingList.RemoveIndex(PropertyDescriptor property)
        {
            ((IBindingList)_datatable.DefaultView).RemoveIndex(property);
        }

        void IBindingList.RemoveSort()
        {
            ((IBindingList)_datatable.DefaultView).RemoveSort();
        }

        #endregion IBindingList

        #region ITypedList

        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return ((ITypedList)_datatable.DefaultView).GetItemProperties(listAccessors);
        }

        string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
        {
            return ((ITypedList)_datatable.DefaultView).GetListName(listAccessors);
        }

        #endregion ITypedList

        #region ISupportInitialize

        void ISupportInitialize.BeginInit()
        {
        }

        void ISupportInitialize.EndInit()
        {
            if ((!DesignMode) && AutoApplyUserRights && HostControl != null)
                ApplyUserRights();
        }

        #endregion ISupportInitialize

        #region IDataSource

        /// <summary>
        /// Get the rowstate of the current row. If no row is attached, you get a DataRowState.Detached value.
        /// </summary>
        public DataRowState CurrentRowState
        {
            get
            {
                return HasRow ? Row.RowState : DataRowState.Detached;
            }
        }

        /// <summary>
        /// Get flag if datasource has a Row instance
        /// </summary>
        public bool HasRow
        {
            get
            {
                return Row != null;
            }
        }

        #endregion IDataSource

        #region BuildAdapterCommands

        private static string AddNamedParam(SqlCommand cmd, TableCol tc)
        {
            return AddNamedParam(cmd, tc, DataRowVersion.Current);
        }

        private static string AddNamedParam(SqlCommand cmd, TableCol tc, DataRowVersion drv)
        {
            string paramName = "@" + tc.Name;
            if (drv == DataRowVersion.Original)
                paramName += "_old";

            // SQL Server reports NText with length 16. So we do not use tc1.Length in SqlParameter ctor
            if (cmd.Parameters.IndexOf(paramName) == -1)
            {
                // validate
                if (tc.DataColumn == null)
                {
                    string exceptionMessage =
                        "DataColumn tc.DataColumn is null. Cannot add named parameter to command. ColumnName: {0}";
                    exceptionMessage = string.Format(exceptionMessage, tc.Name);
                    throw new Exception(exceptionMessage);
                }

                SqlParameter param = new SqlParameter(paramName, tc.Type);
                param.IsNullable = tc.IsNullable;
                param.SourceColumn = tc.DataColumn.ColumnName;
                param.SourceVersion = drv;

                cmd.Parameters.Add(param);
            }

            return paramName;
        }

        private void BuildAdapterCommands()
        {
            if (DesignMode)
                return;

            if (_adapterCommandsBuilt)
                return;
            if (_tableName == null)
                return;

            // get metadata
            _ts = new TableSchema(_datatable, _tableName);

            if (!(_canInsert || _canUpdate || _canDelete))
                return;

            #region insert statement - set adapter.InsertCommand

            if (_insStmt == null)
            {
                // build insert statement from ts
                SqlCommand cmd = new SqlCommand();

                ArrayList alFields = new ArrayList();
                ArrayList alParams = new ArrayList();
                foreach (TableCol tc1 in _ts)
                {
                    if ((IsIdentityInsert || tc1 != _ts.IdentityColumn) && tc1 != _ts.TimestampColumn && tc1.DataColumn != null)
                    {
                        alFields.Add("[" + tc1.Name + "]");
                        string paramName = "@" + tc1.Name;
                        if (tc1 == _ts.IdentityColumn)
                        {
                            paramName = "@" + tc1.Name + "_INPUT";
                        }
                        alParams.Add(paramName);
                        SqlParameter param = new SqlParameter(paramName, tc1.Type);
                        param.IsNullable = tc1.IsNullable;
                        param.SourceColumn = tc1.DataColumn.ColumnName;
                        cmd.Parameters.Add(param);
                    }
                }

                string ct = string.Empty;
                if (IsIdentityInsert)
                {
                    ct = string.Format("set identity_insert {0} on;", _tableName);
                }

                ct = string.Format("{0} insert [{1}] ({2}) \r\n values ({3})",
                    ct,
                    _tableName,
                    string.Join(", ", (string[])alFields.ToArray(typeof(string))),
                    string.Join(", ", (string[])alParams.ToArray(typeof(string))));

                // select identity, timestamp...
                if (_ts.IdentityColumn != null && _ts.IdentityColumn.DataColumn != null ||
                    _ts.TimestampColumn != null && _ts.TimestampColumn.DataColumn != null)
                {
                    alFields = new ArrayList();
                    alParams = new ArrayList();

                    if (_ts.IdentityColumn != null && _ts.IdentityColumn.DataColumn != null)
                    {
                        string paramName = "@" + _ts.IdentityColumn.Name;
                        alFields.Add(string.Format("{0}=[{1}]", paramName, _ts.IdentityColumn.Name));
                        SqlParameter param = cmd.Parameters.Add(paramName, _ts.IdentityColumn.Type, _ts.IdentityColumn.Length, _ts.IdentityColumn.Name);
                        param.Direction = ParameterDirection.Output;
                    }

                    if (_ts.TimestampColumn != null && _ts.TimestampColumn.DataColumn != null)
                    {
                        string paramName = "@" + _ts.TimestampColumn.Name;
                        alFields.Add(string.Format("{0}=[{1}]", paramName, _ts.TimestampColumn.Name));
                        SqlParameter param = cmd.Parameters.Add(paramName, _ts.TimestampColumn.Type, _ts.TimestampColumn.Length, _ts.TimestampColumn.Name);
                        param.Direction = ParameterDirection.Output;
                    }

                    foreach (TableCol tc in _ts.PrimaryKeyColumns)
                    {
                        if (tc == _ts.IdentityColumn)
                            alParams.Add(string.Format("[{0}]=SCOPE_IDENTITY()", tc.Name));
                        else
                            alParams.Add(string.Format("[{0}]=@{0}", tc.Name));
                    }

                    ct = string.Format("{0} select {2} from [{1}] where {3}",
                        ct, _tableName,
                        string.Join(", ", (string[])alFields.ToArray(typeof(string))),
                        string.Join(" and ", (string[])alParams.ToArray(typeof(string))));
                }

                if (IsIdentityInsert)
                {
                    ct = string.Format("{0} set identity_insert {1} off", ct, _tableName);
                }

                cmd.CommandText = ct;
                cmd.Connection = Session.Connection;
                _adapter.InsertCommand = cmd;
            }
            else
            {
                // TODO custom insert statement
                throw new NotImplementedException("custom insert statement not currently supported.");
            }

            #endregion insert statement - set adapter.InsertCommand

            #region update statement - set adapter.UpdateCommand

            if (_updStmt == null)
            {
                // build update statement from ts
                SqlCommand cmd = new SqlCommand();

                ArrayList alShortFields = new ArrayList();
                ArrayList alLongFields = new ArrayList();
                foreach (TableCol tc1 in _ts)
                {
                    if (tc1 != _ts.IdentityColumn && tc1 != _ts.TimestampColumn && tc1.DataColumn != null)
                    {
                        if (tc1.Type == SqlDbType.Text || tc1.Type == SqlDbType.NText || tc1.Type == SqlDbType.Image)
                            alLongFields.Add(string.Format("[{0}]={1}", tc1.Name, AddNamedParam(cmd, tc1)));
                        else
                            alShortFields.Add(string.Format("[{0}]={1}", tc1.Name, AddNamedParam(cmd, tc1)));
                    }
                }

                ArrayList alWhere = new ArrayList();
                foreach (TableCol tc1 in _ts.PrimaryKeyColumns)
                    alWhere.Add(string.Format("[{0}]={1}", tc1.Name, AddNamedParam(cmd, tc1, DataRowVersion.Original)));

                if (_ts.TimestampColumn != null && _ts.TimestampColumn.DataColumn != null)
                {
                    string paramName = "@" + _ts.TimestampColumn.Name + "_old";
                    alWhere.Add(string.Format("[{0}]={1}", _ts.TimestampColumn.Name, paramName));
                    SqlParameter param = new SqlParameter(paramName, _ts.TimestampColumn.Type, _ts.TimestampColumn.Length);
                    param.SourceColumn = _ts.TimestampColumn.DataColumn.ColumnName;
                    param.SourceVersion = DataRowVersion.Original;
                    cmd.Parameters.Add(param);
                }

                string ct = string.Format("--SQLCHECK_IGNORE--\r\nUPDATE [{0}]\r\n  SET {1}\r\nWHERE {2}", _tableName
                    , string.Join(", ", (string[])alShortFields.ToArray(typeof(string)))
                    , string.Join(" AND ", (string[])alWhere.ToArray(typeof(string))));

                // select timestamp...
                if (alLongFields.Count > 0 || _ts.TimestampColumn != null && _ts.TimestampColumn.DataColumn != null)
                {
                    alWhere = new ArrayList();
                    foreach (TableCol tc1 in _ts.PrimaryKeyColumns)
                        alWhere.Add(string.Format("[{0}]={1}", tc1.Name, AddNamedParam(cmd, tc1)));

                    string selectTS = string.Empty;
                    if (_ts.TimestampColumn != null && _ts.TimestampColumn.DataColumn != null)
                    {
                        string paramNameTS = "@" + _ts.TimestampColumn.Name;
                        SqlParameter paramTS = new SqlParameter(paramNameTS, _ts.TimestampColumn.Type, _ts.TimestampColumn.Length);
                        paramTS.SourceColumn = _ts.TimestampColumn.DataColumn.ColumnName;
                        paramTS.Direction = ParameterDirection.InputOutput;
                        cmd.Parameters.Add(paramTS);

                        selectTS = string.Format(";\r\nIF @@RowCount=1 SELECT {0}=[{1}] FROM [{2}] WHERE {3}"
                            , paramNameTS, _ts.TimestampColumn.Name, _tableName
                            , string.Join(" AND ", (string[])alWhere.ToArray(typeof(string))));

                        ct += selectTS;
                        alWhere.Add(string.Format("[{0}]={1}", _ts.TimestampColumn.Name, paramNameTS));
                    }

                    if (alLongFields.Count > 0)
                    {
                        ct += string.Format(";\r\nUPDATE [{0}]\r\n  SET {1}\r\nWHERE {2}", _tableName
                            , string.Join(", ", (string[])alLongFields.ToArray(typeof(string)))
                            , string.Join(" AND ", (string[])alWhere.ToArray(typeof(string))));

                        ct += selectTS;
                    }
                }

                cmd.CommandText = ct;
                cmd.Connection = Session.Connection;
                _adapter.UpdateCommand = cmd;
            }
            else
            {
                // TODO custom update statement
                throw new NotImplementedException("custom update statement not currently supported.");
            }

            #endregion update statement - set adapter.UpdateCommand

            #region delete statement - set adapter.DeleteCommand

            if (_delStmt == null)
            {
                // build delete statement from ts
                SqlCommand cmd = new SqlCommand();

                ArrayList alWhere = new ArrayList();
                foreach (TableCol tc1 in _ts.PrimaryKeyColumns)
                {
                    string paramName = "@" + tc1.Name + "_old";
                    alWhere.Add(string.Format("[{0}]={1}", tc1.Name, paramName));
                    SqlParameter param = new SqlParameter(paramName, tc1.Type);
                    param.SourceColumn = tc1.DataColumn.ColumnName;
                    param.SourceVersion = DataRowVersion.Original;
                    cmd.Parameters.Add(param);
                }
                if (_ts.TimestampColumn != null && _ts.TimestampColumn.DataColumn != null)
                {
                    string paramName = "@" + _ts.TimestampColumn.Name + "_old";
                    alWhere.Add(string.Format("[{0}]={1}", _ts.TimestampColumn.Name, paramName));
                    SqlParameter param = new SqlParameter(paramName, _ts.TimestampColumn.Type, _ts.TimestampColumn.Length);
                    param.SourceColumn = _ts.TimestampColumn.DataColumn.ColumnName;
                    param.SourceVersion = DataRowVersion.Original;
                    cmd.Parameters.Add(param);
                }

                string ct = string.Format("--SQLCHECK_IGNORE--\r\nDELETE [{0}] \r\n WHERE {1}", _tableName, string.Join(" and ", (string[])alWhere.ToArray(typeof(string))));

                cmd.CommandText = ct;
                cmd.Connection = Session.Connection;
                _adapter.DeleteCommand = cmd;
            }
            else
            {
                // TODO custom delete statement
                throw new NotImplementedException("custom delete statement not currently supported.");
            }

            #endregion delete statement - set adapter.DeleteCommand

            _adapterCommandsBuilt = true;
        }

        #endregion BuildAdapterCommands

        #region Data Export

        /// <summary>
        /// Exports all rows to a sql-file. Run the sql-script to import the data
        /// if sw is append: Create a new file or append to an existing file
        /// headerText: if null, a standard Header will be written
        /// goEachRow: if true, a 'go' command will be appended after each inserted row (good for merging new values)
        /// includeIdentity: the identity column will be exported => imported data will have the same identity
        /// </summary>
        public bool ExportDataToSqlScript(string fileName, string headerText, bool goEachRow, bool includeIdentity)
        {
            StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.Default);
            bool res = ExportDataToSqlScript(sw, headerText, goEachRow, includeIdentity);
            sw.Flush();
            sw.Close();
            if (res)
            {
                KissMsg.ShowInfo("SQLQuery", "DatenexportAbgeschl", "Datenexport abgeschlossen.\r\n\r\n{0} Datensätze exportiert nach {1}", 0, 0, Count.ToString(), fileName);
            }
            return res;
        }

        /// <summary>
        /// Exports all rows to a sql-file. Run the sql-script to import the data
        /// the sql-script is appended to the already open Streamwriter sw
        /// headerText: if null, a standard Header will be written
        /// goEachRow: if true, a 'go' command will be appended after each inserted row (good for merging new values)
        /// includeIdentity: the identity column will be exported => imported data will have the same identity
        /// </summary>
        public bool ExportDataToSqlScript(StreamWriter sw, string headerText, bool goEachRow, bool includeIdentity)
        {
            if (Count == 0)
                return false;

            if (DBUtil.IsEmpty(TableName))
                return false;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                BuildAdapterCommands();

                ArrayList alColumns = new ArrayList();
                ArrayList alColumnNames = new ArrayList();

                foreach (TableCol tc in _ts)
                {
                    if ((tc == _ts.IdentityColumn && includeIdentity) ||
                        (tc != _ts.IdentityColumn && tc != _ts.TimestampColumn && tc.DataColumn != null))
                    {
                        alColumns.Add(tc.DataColumn);
                        alColumnNames.Add("[" + tc.Name + "]");
                    }
                }

                if (headerText == null)
                {
                    sw.WriteLine("/*");
                    sw.WriteLine("KISS Data Export");
                    sw.WriteLine("  table: " + _tableName);
                    sw.WriteLine("  query: " + _adapter.SelectCommand.CommandText);
                    sw.WriteLine("  date : " + DateTime.Now.ToString("dd.MM.yyyy hh:mm"));
                    sw.WriteLine("  count: " + Count.ToString() + " records");
                    sw.WriteLine("*/");
                    sw.WriteLine();
                }
                else
                {
                    sw.WriteLine(headerText);
                    sw.WriteLine();
                }

                if (includeIdentity)
                    sw.WriteLine("set identity_insert " + TableName + " on");

                foreach (DataRow row in DataTable.Rows)
                {
                    ArrayList alValues = new ArrayList();
                    foreach (DataColumn col in alColumns)
                    {
                        alValues.Add(DBUtil.SqlLiteral(row[col.ColumnName]));
                    }

                    sw.WriteLine(string.Format("--SQLCHECK_IGNORE--\r\nINSERT [{0}]({1})",
                        _tableName,
                        string.Join(", ", (string[])alColumnNames.ToArray(typeof(string)))));

                    sw.WriteLine(string.Format("values ({0})",
                        string.Join(", ", (string[])alValues.ToArray(typeof(string)))));

                    if (goEachRow)
                        sw.WriteLine("go");
                }

                if (includeIdentity)
                    sw.WriteLine("set identity_insert " + TableName + " off");

                sw.WriteLine();
                sw.WriteLine();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                KissMsg.ShowError("SqlQuery", "FehlerDatenexport", "Fehler beim Datenexport!", ex);
                return false;
            }
            return true;
        }

        #endregion Data Export

        #region class TableCol

        private class TableCol
        {
            public DataColumn DataColumn;
            public object DefaultValue;
            public bool IsNullable;
            public bool IsReadOnly;
            public int Length;
            public string Name;
            public SqlDbType Type;
        }

        #endregion class TableCol

        #region class TableSchema

        private class TableSchema : ICollection
        {
            public readonly TableCol IdentityColumn;
            public readonly TableCol[] PrimaryKeyColumns;
            public readonly TableCol TimestampColumn;
            private readonly ArrayList _items;
            private readonly Hashtable _nameHash;

            public TableSchema(DataTable table, string tableName)
            {
                _nameHash = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
                _items = new ArrayList();

                try
                {
                    SqlCommand cmd = DBUtil.CreateSqlCommand(@"
                        SELECT col.name, type=typ.name, col.length, col.isnullable,
                          isidentity   = CASE col.status & 0x80 WHEN 0 THEN 0 ELSE 1 END,
                          defaultvalue = CASE SUBSTRING(com.text, 1, 2)
                                           WHEN '(''' THEN SUBSTRING(com.text, 3, LEN(com.text) - 4)
                                           WHEN '(('  THEN SUBSTRING(com.text, 3, LEN(com.text) - 4)
                                           ELSE            SUBSTRING(com.text, 2, LEN(com.text) - 2)
                                         END
                        FROM sysobjects           obj
                          INNER JOIN syscolumns   col ON obj.Id    = col.Id
                          INNER JOIN systypes     typ ON col.xtype = typ.xusertype
                          LEFT  JOIN syscomments  com ON com.id    = col.cdefault AND com.colid = 1
                        WHERE obj.xtype IN ('U', 'V') AND obj.name = {0}
                        ORDER BY col.colorder"
                        , tableName);

                    lock (Session.Connection)
                    {
                        SqlDataReader dr = null;
                        try
                        {
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                TableCol tc = new TableCol();

                                tc.Name = (string)dr["name"];

                                string typeStr = (string)dr["type"];
                                if (string.Compare(typeStr, "numeric", true) == 0)
                                    tc.Type = SqlDbType.Decimal;
                                else if (string.Compare(typeStr, "sql_variant") == 0)
                                    tc.Type = SqlDbType.Variant;
                                else
                                    tc.Type = (SqlDbType)Enum.Parse(typeof(SqlDbType), typeStr, true);

                                tc.Length = (short)dr["length"];
                                tc.IsNullable = (int)dr["isnullable"] == 1;
                                tc.IsReadOnly = ((int)dr["isidentity"] == 1) || tc.Type == SqlDbType.Timestamp;
                                tc.DataColumn = table.Columns[tc.Name];

                                tc.DefaultValue = dr["defaultvalue"];

                                if ((int)dr["isidentity"] == 1)
                                    IdentityColumn = tc;
                                if (tc.Type == SqlDbType.Timestamp)
                                    TimestampColumn = tc;

                                _items.Add(tc);
                                _nameHash.Add(tc.Name, tc);
                            }
                        }
                        finally { if (dr != null) dr.Close(); }

                        ArrayList al = new ArrayList();
                        cmd = DBUtil.CreateSqlCommand(@"
                            SELECT COL.name
                            FROM sysobjects             TBL
                              INNER JOIN syscolumns     COL ON TBL.id  = COL.id
                              LEFT  JOIN sysindexkeys   IDK ON IDK.id  = TBL.id AND IDK.colid = COL.colid
                              LEFT  JOIN sysindexes     IDX ON IDX.id  = TBL.id AND IDX.indid = IDK.indid AND IDX.status & 2050 = 2050
                            WHERE TBL.Name = {0} AND ((TBL.type = 'U' AND IDX.id IS NOT NULL) OR (TBL.type = 'V' AND COL.status & 0x80 != 0))
                            ORDER BY IDK.keyno"
                            , tableName);

                        try
                        {
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                string name = (string)dr["name"];
                                TableCol tc = (TableCol)_nameHash[name];
                                Debug.Assert(tc != null);
                                al.Add(tc);
                            }
                        }
                        finally
                        {
                            dr.Close();
                        }
                        PrimaryKeyColumns = (TableCol[])al.ToArray(typeof(TableCol));
                    }
                }
                catch (Exception ex)
                {
                    if (ex is KissCancelException)
                    {
                        if (!HandleException(ex))
                            throw;
                    }
                    else
                    {
                        KissCancelException kissEx = new KissErrorException(
                            KissMsg.GetMLMessage(
                            "SqlQuery",
                            "FehlerDatenSpeichern",
                            "Fehler beim Speichern der Daten.",
                            KissMsgCode.MsgError),
                            "SqlQuery.TableSchema\r\n\r\n" + ex.Message, ex);

                        if (!HandleException(kissEx))
                            throw kissEx;
                    }
                }
            }

            public int Count
            {
                get { return _items.Count; }
            }

            public bool IsSynchronized
            {
                get { return _items.IsSynchronized; }
            }

            public object SyncRoot
            {
                get { return _items.SyncRoot; }
            }

            public TableCol this[int index]
            {
                get { return (TableCol)_items[index]; }
            }

            public TableCol this[string name]
            {
                get { return (TableCol)_nameHash[name]; }
            }

            public void CopyTo(Array array, int index)
            {
                _items.CopyTo(array, index);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _items.GetEnumerator();
            }
        }

        #endregion class TableSchema
    }
}