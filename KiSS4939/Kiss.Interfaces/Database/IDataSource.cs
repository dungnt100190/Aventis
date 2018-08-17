using System.ComponentModel;
using System.Data;

namespace Kiss.Interfaces.Database
{
    public interface IDataSource
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the AllowPositionChanging property
        /// set to false to force the DataSource to stay on the same position
        /// </summary>
        [Browsable(false)]
        [DefaultValue(true)]
        bool AllowSelectionChanging
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this SqlQuery supports updating.
        /// </summary>
        [DefaultValue(false)]
        bool CanUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// Get the rowstate of the current row. If no row is attached, you get a DataRowState.Detached value.
        /// </summary>
        DataRowState CurrentRowState
        {
            get;
        }

        /// <summary>
        /// Get flag if datasource has a Row instance
        /// </summary>
        bool HasRow
        {
            get;
        }

        /// <summary>
        /// Returns true if the query is empty.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        bool IsEmpty
        {
            get;
        }

        /// <summary>
        /// Gets or Sets the RowModified property
        /// set to true to force the BeforePost() Event
        /// will be automatically set to false after PositionChanged, Post, Insert and Delete
        /// will be automatically set to true after ColumnChanged
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        bool RowModified
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Value of the named Column of the current <see cref="DataRowView"/>
        /// </summary>
        [Browsable(false)]
        object this[string columnName]
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Save the inserted or updated row to the database (Errors are displayed)
        /// </summary>
        bool Post();

        /// <summary>
        /// Save the inserted or updated row to the database (Errors are displayed)
        /// </summary>
        /// <param name="performEndEditGrids"></param>
        /// <param name="isSilentPosting"></param>
        bool Post(bool performEndEditGrids, bool isSilentPosting);

        #endregion
    }
}