using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure;
using Kiss.UI.ViewModel;

namespace Kiss.Spielwiese
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        #region Private Fields

        private IEnumerable<TestEntity> _entityList;
        private bool _isAuthorized;
        private bool _isEnabled;
        private bool _isReadOnly;
        private bool _isRequired;
        private TestEntity _selectedItem;

        #endregion

        #endregion

        #region Constructors

        public MainViewModel()
        {
            IsEnabled = true;
            IsAuthorized = true;

            EntityList = new List<TestEntity>
            {
                new TestEntity { Property1 = "Entity 1" },
                new TestEntity { Property1 = "Entity 2" },
                new TestEntity { Property1 = "Entity 3" },
            };
        }

        #endregion

        #region Properties

        public SearchForStringEventHandler ButtonSearchEventHandler
        {
            get { return TestSearch; }
        }

        public IEnumerable<TestEntity> EntityList
        {
            get { return _entityList; }
            set { SetProperty(ref _entityList, value, () => EntityList); }
        }

        public bool IsAuthorized
        {
            get { return _isAuthorized; }
            set { SetProperty(ref _isAuthorized, value, () => IsAuthorized); }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value, () => IsEnabled); }
        }

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set { SetProperty(ref _isReadOnly, value, () => IsReadOnly); }
        }

        public bool IsRequired
        {
            get { return _isRequired; }
            set { SetProperty(ref _isRequired, value, () => IsRequired); }
        }

        public TestEntity SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value, () => SelectedItem); }
        }

        #endregion

        #region Methods

        #region Private Methods

        private IList<object> TestSearch(string searchString)
        {
            var testList = new List<TestEntity>
            {
                new TestEntity
                {
                    Property1 = "Test 1",
                    Property2 = "Description 1"
                },
                new TestEntity
                {
                    Property1 = "Test 2",
                    Property2 = "Description 2"
                },
                new TestEntity
                {
                    Property1 = "Test 3",
                    Property2 = "Description 3"
                },
            };

            return testList
                .Where(x => searchString == "*" || x.Property1.Contains(searchString) || x.Property2.Contains(searchString))
                .Cast<object>().ToList();
        }

        #endregion

        #endregion
    }
}