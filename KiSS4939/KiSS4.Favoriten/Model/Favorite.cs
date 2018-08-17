using System.Collections.Generic;

namespace KiSS4.Favoriten.Model
{
    /// <summary>
    /// Store single favorite entry
    /// </summary>
    public class Favorite
    {
        #region Enumerations

        public enum FavoriteDisplayType
        {
            Folder = 0,
            Favorite = 1
        }

        #endregion

        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// The icon id in XIcon for Folder
        /// </summary>
        public const int FOLDER_XICONID = 166;

        /// <summary>
        /// The icon id in XIcon for favorite item entry
        /// </summary>
        public const int ITEM_XICONID = 210;

        /// <summary>
        /// The icon id in XIcon for favorite item entry with autosearch
        /// </summary>
        public const int ITEM_XICONID_AUTOSEARCH = 23;

        #endregion

        #region Private Fields

        private string _className;
        private string _classUserText;
        private string _colLayout;
        private IList<FavoriteControl> _favoriteControls = new List<FavoriteControl>();
        private bool _hasBeenDeleted;
        private bool _hasBeenModified;
        private FavoriteDisplayType _iconId;
        private int? _moduleTreeId;
        private string _moduleTreeName;
        private string _name;
        private int? _parentXSearchControlTemplateId;
        private bool _searchImmediately;
        private bool _setFocus;
        private int _sortKey;
        private int _userId;
        private int _xSearchControlTemplateId;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Favorite"/> class.
        /// </summary>
        public Favorite()
        {
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="favoriteToCopy">The favorite instance to copy</param>
        public Favorite(Favorite favoriteToCopy)
        {
            _name = favoriteToCopy.Name;
            _xSearchControlTemplateId = favoriteToCopy.XSearchControlTemplateId;
            _parentXSearchControlTemplateId = favoriteToCopy.ParentXSearchControlTemplateId;
            _iconId = favoriteToCopy.IconId;
            _userId = favoriteToCopy.UserId;
            _moduleTreeId = favoriteToCopy.ModulTreeId;
            _moduleTreeName = favoriteToCopy.ModulTreeName;
            _colLayout = favoriteToCopy.ColLayout;
            _searchImmediately = favoriteToCopy.SearchImmediately;
            _className = favoriteToCopy.ClassName;
            _classUserText = favoriteToCopy.ClassUserText;
            _sortKey = favoriteToCopy.SortKey;
            _hasBeenModified = favoriteToCopy.HasBeenModified;
            _hasBeenDeleted = favoriteToCopy.HasBeenDeleted;
            _setFocus = favoriteToCopy.SetFocus;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get and set the classname of favorite
        /// </summary>
        public string ClassName
        {
            get
            {
                // validate first
                if (string.IsNullOrEmpty(_className))
                {
                    return null;
                }

                return _className;
            }

            set { _className = value; }
        }

        /// <summary>
        /// Get and set the userfriendly text for given class of favorite
        /// </summary>
        public string ClassUserText
        {
            get
            {
                // validate
                if (string.IsNullOrEmpty(_classUserText))
                {
                    // no usertext, just return classname
                    return ClassName;
                }
                {
                    // we have a usertext, return this
                    return _classUserText;
                }
            }
            set { _classUserText = value; }
        }

        public string ColLayout
        {
            get { return _colLayout; }
            set { _colLayout = value; }
        }

        public IList<FavoriteControl> FavoriteControls
        {
            get { return _favoriteControls; }
            set { _favoriteControls = value; }
        }

        public bool HasBeenDeleted
        {
            get { return _hasBeenDeleted; }
            set { _hasBeenDeleted = value; }
        }

        public bool HasBeenModified
        {
            get { return _hasBeenModified; }
            set { _hasBeenModified = value; }
        }

        public FavoriteDisplayType IconId
        {
            get { return _iconId; }
            set { _iconId = value; }
        }

        public int? ModulTreeId
        {
            get
            {
                if (_moduleTreeId == 0)
                    return null;

                return _moduleTreeId;
            }

            set { _moduleTreeId = value; }
        }

        public string ModulTreeName
        {
            get { return _moduleTreeName; }
            set { _moduleTreeName = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int? ParentXSearchControlTemplateId
        {
            get
            {
                if (_parentXSearchControlTemplateId < 0)
                {
                    return null;
                }

                return _parentXSearchControlTemplateId;
            }

            set { _parentXSearchControlTemplateId = value; }
        }

        public bool SearchImmediately
        {
            get { return _searchImmediately; }
            set { _searchImmediately = value; }
        }

        public bool SetFocus
        {
            get { return _setFocus; }
            set { _setFocus = value; }
        }

        public int SortKey
        {
            get { return _sortKey; }
            set { _sortKey = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public int XSearchControlTemplateId
        {
            get { return _xSearchControlTemplateId; }
            set { _xSearchControlTemplateId = value; }
        }

        #endregion
    }
}