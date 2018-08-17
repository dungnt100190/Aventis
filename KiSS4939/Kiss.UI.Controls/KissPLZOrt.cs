using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using DevExpress.Data.PLinq.Helpers;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;
using Kiss.UI.Controls.VirtualCanvas;
using Kiss.UserInterface.ViewModel.SearchBox;

namespace Kiss.UI.Controls
{
    [TemplatePart(Name = PART_TXT_PLZ, Type = typeof(KissTextEdit))]
    [TemplatePart(Name = PART_TXT_ORT, Type = typeof(KissTextEdit))]
    public class KissPLZOrt : KissComplexControl, IKissEdit
    {
        private enum SearchType
        {
            PLZ,
            Ort,
        }

        public static readonly DependencyProperty BaPLZIDProperty;
        public static readonly DependencyProperty IsAuthorizedProperty;
        public static readonly DependencyProperty IsReadOnlyProperty;
        public static readonly DependencyProperty IsRequiredProperty;

        public static readonly DependencyProperty KantonProperty;
        public static readonly DependencyProperty OrtProperty;
        public static readonly DependencyProperty PLZProperty;
        public static readonly DependencyProperty SelectedItemProperty;

        public static readonly DependencyProperty ShowKantonProperty;

        private const string PART_TXT_ORT = "PART_TxtOrt";
        private const string PART_TXT_PLZ = "PART_TxtPLZ";

        private IList<BaPLZ> _availableEntities;
        private bool _isInitialized;

        private List<GridColumnDefinition> _searchDialogColumns;

        private bool _searching;
        private KissTextEdit _txtKanton;
        private KissTextEdit _txtOrt;
        private KissTextEdit _txtPLZ;

        static KissPLZOrt()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KissPLZOrt), new FrameworkPropertyMetadata(typeof(KissPLZOrt)));

            IsAuthorizedProperty = DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPLZOrt>(x => x.IsAuthorized),
                    typeof(bool),
                    typeof(KissPLZOrt),
                    new UIPropertyMetadata(true, PropertyChanged_SetEditMode));
            IsReadOnlyProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPLZOrt>(x => x.IsReadOnly),
                    typeof(bool),
                    typeof(KissPLZOrt),
                    new UIPropertyMetadata(false, PropertyChanged_SetEditMode));
            IsRequiredProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPLZOrt>(x => x.IsRequired),
                    typeof(bool),
                    typeof(KissPLZOrt),
                    new PropertyMetadata(false));

            SelectedItemProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPLZOrt>(x => x.SelectedItem),
                    typeof(BaPLZ),
                    typeof(KissPLZOrt),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

            KantonProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPLZOrt>(x => x.Kanton),
                    typeof(string),
                    typeof(KissPLZOrt),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
            OrtProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPLZOrt>(x => x.Ort),
                    typeof(string),
                    typeof(KissPLZOrt),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
            PLZProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPLZOrt>(x => x.PLZ),
                    typeof(string),
                    typeof(KissPLZOrt),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
            BaPLZIDProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPLZOrt>(x => x.BaPLZID),
                    typeof(int?),
                    typeof(KissPLZOrt),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

            ShowKantonProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPLZOrt>(x => x.ShowKanton),
                    typeof(bool),
                    typeof(KissPLZOrt),
                    new FrameworkPropertyMetadata(true));
        }

        public KissPLZOrt()
        {
            ResourceUtil.CreateStaticResourcesForDesigner(this);

            SearchDialogColumns = new List<GridColumnDefinition>
            {
                new GridColumnDefinition
                {
                    Fieldname = "PLZ",
                    Title = "PLZ",
                },
                new GridColumnDefinition
                {
                    Fieldname = "Name",
                    Title = "Ort",
                },
                new GridColumnDefinition
                {
                    Fieldname = "Kanton",
                    Title = "Kanton",
                },
            };

            Focusable = true;
            IsTabStop = true;
        }

        public int? BaPLZID
        {
            get { return (int)GetValue(BaPLZIDProperty); }
            set { SetCurrentValue(BaPLZIDProperty, value); }
        }

        public bool IsAuthorized
        {
            get { return (bool)GetValue(IsAuthorizedProperty); }
            set { SetValue(IsAuthorizedProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        public string Kanton
        {
            get { return (string)GetValue(KantonProperty); }
            set { SetCurrentValue(KantonProperty, value); }
        }

        public string Ort
        {
            get { return (string)GetValue(OrtProperty); }
            set { SetCurrentValue(OrtProperty, value); }
        }

        public string PLZ
        {
            get { return (string)GetValue(PLZProperty); }
            set { SetCurrentValue(PLZProperty, value); }
        }

        /// <summary>
        /// Gets or sets a path to a value on the source object to serve as the visual representation of the object
        /// </summary>
        public List<GridColumnDefinition> SearchDialogColumns
        {
            get { return _searchDialogColumns; }
            set { _searchDialogColumns = value; }
        }

        public BaPLZ SelectedItem
        {
            get { return (BaPLZ)GetValue(SelectedItemProperty); }
            set
            {
                if (SelectedItem != value)
                {
                    SetValue(SelectedItemProperty, value);

                    //update PLZ, Ort, Kanton
                    if (SelectedItem != null)
                    {
                        PLZ = SelectedItem.PLZ.ToString();
                        Ort = SelectedItem.Name;
                        Kanton = SelectedItem.Kanton;
                        BaPLZID = SelectedItem.BaPLZID;
                    }
                    else
                    {
                        PLZ = null;
                        Ort = null;
                        Kanton = null;
                        BaPLZID = null;
                    }
                }
            }
        }

        public bool ShowKanton
        {
            get { return (bool)GetValue(ShowKantonProperty); }
            set { SetValue(ShowKantonProperty, value); }
        }

        public static void PropertyChanged_SetEditMode(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissPLZOrt)d;
            instance.SetEditMode();
        }

        public override void EndCurrentEdit()
        {
            if (_txtPLZ.IsFocused)
            {
                SearchIfPlzChanged();
            }
            else if (_txtOrt.IsFocused)
            {
                SearchIfOrtChanged();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _txtPLZ = EnforceInstance<KissTextEdit>(PART_TXT_PLZ);
            _txtOrt = EnforceInstance<KissTextEdit>(PART_TXT_ORT);

            _txtPLZ.PreviewLostKeyboardFocus += txtPLZ_PreviewLostKeyboardFocus;
            _txtPLZ.PreviewKeyDown += txtPLZ_PreviewKeyDown;

            _txtOrt.PreviewLostKeyboardFocus += txtOrt_PreviewLostKeyboardFocus;
            _txtOrt.PreviewKeyDown += txtOrt_PreviewKeyDown;

            BindingOperations.ClearBinding(_txtPLZ, KissTextEdit.IsAuthorizedProperty);
            BindingOperations.ClearBinding(_txtOrt, KissTextEdit.IsAuthorizedProperty);

            _isInitialized = true;
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            _txtPLZ.Focus();
        }

        private void ResetOrtValue()
        {
            if (_txtOrt == null)
            {
                return;
            }

            var expression = _txtOrt.GetBindingExpression(TextBox.TextProperty);
            if (expression != null)
            {
                expression.UpdateTarget();
            }
            else
            {
                _txtOrt.Text = string.Empty;
            }
        }

        private void ResetPLZValue()
        {
            if (_txtPLZ == null)
            {
                return;
            }

            var expression = _txtPLZ.GetBindingExpression(TextBox.TextProperty);
            if (expression != null)
            {
                expression.UpdateTarget();
            }
            else
            {
                _txtPLZ.Text = string.Empty;
            }
        }

        /// <summary>
        /// Executes the search for entered text
        /// </summary>
        /// <param name="searchText"></param>
        private bool Search(string searchText, SearchType searchType)
        {
            if (_searching)
                return false;

            try
            {
                _searching = true;

                if (string.IsNullOrEmpty(searchText))
                {
                    //serach-text is empty, clear the selected item
                    SelectedItem = null;
                    return true;
                }

                switch (searchType)
                {
                    case SearchType.Ort:
                        _availableEntities = PLZOrtSearchBoxVM.SearchByOrt(searchText);
                        break;

                    case SearchType.PLZ:
                        _availableEntities = PLZOrtSearchBoxVM.SearchByPLZ(searchText);
                        break;

                    default:
                        _availableEntities = PLZOrtSearchBoxVM.SearchByPLZ(searchText);
                        break;
                }

                if (_availableEntities.Count == 0)
                {
                    Utilities.MessageBox.ShowInfoMessageBox(Properties.Resources.KeineDatenGefunden);
                    ResetPLZValue();
                    ResetOrtValue();
                    return false;
                }

                if (_availableEntities.Count == 1)
                {
                    SelectedItem = _availableEntities[0];
                    return true;
                }

                var dlg = new KissButtonSearchBoxDialog(_availableEntities.ToList<object>(), SearchDialogColumns);

                var result = dlg.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    SelectedItem = (BaPLZ)dlg.SelectedItem;
                    dlg.Close();
                    return true;
                }

                ResetPLZValue();
                ResetOrtValue();
                dlg.Close();
                return false;
            }
            finally
            {
                _searching = false;
            }
        }

        private bool SearchIfOrtChanged()
        {
            // Only search if the value has changed
            string selectedItemOrt = null;
            if (SelectedItem != null)
            {
                selectedItemOrt = SelectedItem.Name;
            }
            if (_txtOrt.Text != selectedItemOrt)
            {
                return !Search(_txtOrt.Text, SearchType.Ort);
            }

            return false;
        }

        private bool SearchIfPlzChanged()
        {
            // Only search if the value has changed
            string selectedItemPLZ = null;
            if (SelectedItem != null)
            {
                selectedItemPLZ = SelectedItem.PLZ.ToString();
            }
            if (_txtPLZ.Text != selectedItemPLZ)
            {
                return !Search(_txtPLZ.Text, SearchType.PLZ);
            }

            return false;
        }

        private void SetEditMode()
        {
            if (!_isInitialized)
            {
                return;
            }

            // IsAuthorized ist stärker als IsReadOnly
            var isReadOnly = !IsAuthorized || IsReadOnly;
            //TODO: Ist in SetEditMode etwas zu machen?
        }

        private void txtOrt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                ResetOrtValue();
                e.Handled = true;
            }
            else if (e.Key == Key.Tab)
            {
                e.Handled = SearchIfOrtChanged();
            }
            else if (e.Key == Key.Down || e.Key == Key.Enter)
            {
                if (SearchIfOrtChanged())
                {
                    return;
                }

                var tr = new TraversalRequest(FocusNavigationDirection.Next);
                MoveFocus(tr);
            }
            else if (e.Key == Key.Up)
            {
                if (SearchIfOrtChanged())
                {
                    return;
                }

                var tr = new TraversalRequest(FocusNavigationDirection.Previous);
                MoveFocus(tr);
            }
        }

        private void txtOrt_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            e.Handled = SearchIfOrtChanged();
        }

        private void txtPLZ_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                ResetPLZValue();
                e.Handled = true;
            }
            else if (e.Key == Key.Down || e.Key == Key.Enter)
            {
                if (SearchIfPlzChanged())
                {
                    return;
                }

                var tr = new TraversalRequest(FocusNavigationDirection.Next);
                MoveFocus(tr);
            }
            else if (e.Key == Key.Up)
            {
                if (SearchIfPlzChanged())
                {
                    return;
                }

                var tr = new TraversalRequest(FocusNavigationDirection.Previous);
                MoveFocus(tr);
            }
        }

        private void txtPLZ_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            e.Handled = SearchIfPlzChanged();
        }
    }
}