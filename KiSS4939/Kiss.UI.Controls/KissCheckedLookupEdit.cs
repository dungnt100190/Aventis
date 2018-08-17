using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for KissCheckedLookupEdit.xaml
    /// </summary>
    [TemplatePart(Name = ELEMENT_CHECKED_LOOKUPEDIT, Type = typeof(KissCheckedLookupEdit))]
    public class KissCheckedLookupEdit : Control, IKissEdit
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty IsAuthorizedProperty;
        public static readonly DependencyProperty IsReadOnlyProperty;
        public static readonly DependencyProperty IsRequiredProperty;
        public static readonly DependencyProperty SelectableItemsProperty;
        public static readonly DependencyProperty TitleProperty;
        public static readonly DependencyProperty DisplayMemberPathProperty;
        public static readonly DependencyProperty ItemTextBindingProperty;

        #endregion

        #region Private Constant/Read-Only Fields

        private const string ELEMENT_CHECKED_LOOKUPEDIT = "PART_ItemsControl";

        #endregion

        #endregion

        #region Constructors

        static KissCheckedLookupEdit()
        {
            IsAuthorizedProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissCheckedLookupEdit>(x => x.IsAuthorized),
                    typeof(bool),
                    typeof(KissCheckedLookupEdit),
                    new UIPropertyMetadata(true));
            IsReadOnlyProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissCheckedLookupEdit>(x => x.IsReadOnly),
                    typeof(bool),
                    typeof(KissCheckedLookupEdit),
                    new UIPropertyMetadata(false));
            IsRequiredProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissCheckedLookupEdit>(x => x.IsRequired),
                    typeof(bool),
                    typeof(KissCheckedLookupEdit),
                    new PropertyMetadata(false));
            SelectableItemsProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissCheckedLookupEdit>(x => x.SelectableItems),
                    typeof(IEnumerable),
                    typeof(KissCheckedLookupEdit), 
                    new PropertyMetadata(null));
            TitleProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissCheckedLookupEdit>(x => x.Title),
                    typeof(string),
                    typeof(KissCheckedLookupEdit),
                    new PropertyMetadata(null));
            DisplayMemberPathProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissCheckedLookupEdit>(x => x.DisplayMemberPath),
                    typeof(string),
                    typeof(KissCheckedLookupEdit),
                    new PropertyMetadata(null));
            ItemTextBindingProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissCheckedLookupEdit>(x => x.ItemTextBinding),
                    typeof(Binding),
                    typeof(KissCheckedLookupEdit),
                    new PropertyMetadata(new Binding("Item.Text"))); // default for XLOVCode
        }

        #endregion

        #region Properties

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

        public IEnumerable SelectableItems
        {
            get { return (IEnumerable)GetValue(SelectableItemsProperty); }
            set { SetValue(SelectableItemsProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }
        public Binding ItemTextBinding
        {
            get { return (Binding)GetValue(ItemTextBindingProperty); }
            set { SetValue(ItemTextBindingProperty, value); }
        }
        
        #endregion

    }
}