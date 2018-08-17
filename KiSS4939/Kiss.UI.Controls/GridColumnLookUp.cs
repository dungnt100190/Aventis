using System.Collections;
using System.Windows;

using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.LookUp;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// GridColumn mit LookUpEditSettings. Es muss nur noch ItemsSource gesetzt werden und ggf ValueMember oder DisplayMember.
    /// <example>
    /// <code>
    /// <!-- LookUp auf LOV, ValueMember: Code und DisplayMember: Text sind defaultmässig gesetzt -->
    /// <Controls:GridColumnLookUp Header="Kategorie" FieldName="WshKategorieID" 
    ///     ItemsSource="{Binding Path=Kategorie}"/>
    /// <!-- LookUp auf eine andere Tabelle, ValueMember und DisplayMember müssen noch gesetzt werden -->
    /// <Controls:GridColumnLookUp Header="betrifft" FieldName="BaPersonID" 
    ///     ItemsSource="{Binding Path=PersonenHaushalt}" DisplayMember="NameVorname" ValueMember="BaPersonID" />
    /// </code>
    /// </example>
    /// </summary>
    public class GridColumnLookUp : GridColumn
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty AllowNullInputProperty = LookUpEditSettingsBase.AllowNullInputProperty.AddOwner(
            typeof(GridColumnLookUp), new PropertyMetadata(AllowNullInputPropertyChanged));
        public static readonly DependencyProperty DisplayMemberProperty = LookUpEditSettingsBase.DisplayMemberProperty.AddOwner(
            typeof(GridColumnLookUp), new PropertyMetadata(DisplayMemberPropertyChanged));
        public static readonly DependencyProperty ItemsSourceProperty = LookUpEditSettingsBase.ItemsSourceProperty.AddOwner(
            typeof(GridColumnLookUp), new PropertyMetadata(ItemsSourcePropertyChanged));
        public static readonly DependencyProperty NullTextProperty = LookUpEditSettingsBase.NullTextProperty.AddOwner(
            typeof(GridColumnLookUp), new PropertyMetadata(NullTextPropertyChanged));
        public static readonly DependencyProperty ValueMemberProperty = LookUpEditSettingsBase.ValueMemberProperty.AddOwner(
            typeof(GridColumnLookUp), new PropertyMetadata(ValueMemberPropertyChanged));

        #endregion

        #endregion

        #region Constructors

        public GridColumnLookUp()
        {
            EditSettings = new LookUpEditSettings
            {
                DisplayMember = "Text",
                ValueMember = "Code"
            };
        }

        #endregion

        #region Properties

        public bool AllowNullInput
        {
            get { return (bool)GetValue(AllowNullInputProperty); }
            set { SetValue(AllowNullInputProperty, value); }
        }

        public string DisplayMember
        {
            get { return (string)GetValue(DisplayMemberProperty); }
            set { SetValue(DisplayMemberProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (string)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public string NullText
        {
            get { return (string)GetValue(NullTextProperty); }
            set { SetValue(NullTextProperty, value); }
        }

        public string ValueMember
        {
            get { return (string)GetValue(ValueMemberProperty); }
            set { SetValue(ValueMemberProperty, value); }
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static void AllowNullInputPropertyChanged(DependencyObject controlInstance, DependencyPropertyChangedEventArgs args)
        {
            GridColumnLookUp column = (GridColumnLookUp)controlInstance;

            // Forward the value to the column's edit properties
            var lookupEditSettings = column.EditSettings as LookUpEditSettings;
            if (lookupEditSettings != null)
            {
                lookupEditSettings.AllowNullInput = args.NewValue is bool && (bool)args.NewValue;
            }
        }

        private static void DisplayMemberPropertyChanged(DependencyObject controlInstance, DependencyPropertyChangedEventArgs args)
        {
            GridColumnLookUp column = (GridColumnLookUp)controlInstance;

            // Forward the value to the column's edit properties
            var lookupEditSettings = column.EditSettings as LookUpEditSettings;
            if (lookupEditSettings != null)
            {
                lookupEditSettings.DisplayMember = args.NewValue as string;
            }
        }

        private static void ItemsSourcePropertyChanged(DependencyObject controlInstance, DependencyPropertyChangedEventArgs args)
        {
            GridColumnLookUp column = (GridColumnLookUp)controlInstance;

            // Forward the value to the column's edit properties
            var lookupEditSettings = column.EditSettings as LookUpEditSettings;
            if (lookupEditSettings != null)
            {
                lookupEditSettings.ItemsSource = args.NewValue as IEnumerable;
            }
        }

        private static void NullTextPropertyChanged(DependencyObject controlInstance, DependencyPropertyChangedEventArgs args)
        {
            GridColumnLookUp column = (GridColumnLookUp)controlInstance;

            // Forward the value to the column's edit properties
            var lookupEditSettings = column.EditSettings as LookUpEditSettings;
            if (lookupEditSettings != null)
            {
                lookupEditSettings.NullText = args.NewValue as string;
            }
        }

        private static void ValueMemberPropertyChanged(DependencyObject controlInstance, DependencyPropertyChangedEventArgs args)
        {
            GridColumnLookUp column = (GridColumnLookUp)controlInstance;

            // Forward the value to the column's edit properties
            var lookupEditSettings = column.EditSettings as LookUpEditSettings;
            if (lookupEditSettings != null)
            {
                lookupEditSettings.ValueMember = args.NewValue as string;
            }
        }

        #endregion

        #endregion
    }
}