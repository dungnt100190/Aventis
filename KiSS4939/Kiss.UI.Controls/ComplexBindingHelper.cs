using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

using DevExpress.Xpf.Grid;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Helper-Klasse, welche es erlaubt, komplexe Bindings auf eine Liste oder ein Dictionary zu verwenden.
    /// Von DevExpress-Support: http://www.devexpress.com/Support/Center/p/S136096.aspx
    /// </summary>
    /// <example>
    ///     <dxg:GridControl local:CompmlexBindingHelper.ItemsSource="{Binding Rows}" Grid.Row="1">
    ///         <dxg:GridControl.Columns>
    ///             <dxg:GridColumn local:ComplexBindingHelper.ComplexFieldName="Properties[0].Value" UnboundType="String" Header="Text coming from List"/>
    ///             <dxg:GridColumn local:ComplexBindingHelper.ComplexFieldName="Dictionary(Text).Value" UnboundType="String" Header="Text coming from Dictionary"/>
    ///             [...]
    ///         </dxg:GridControl.Columns>
    ///     </dxg:GridControl>
    /// </example>
    public class ComplexBindingHelper
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty ComplexFieldNameProperty =
            DependencyProperty.RegisterAttached("ComplexFieldName", typeof(string), typeof(ComplexBindingHelper), new PropertyMetadata(null, OnComplexFieldNameChanged));

        public static readonly DependencyProperty ComplexPathProperty =
            DependencyProperty.RegisterAttached("ComplexPath", typeof(ComplexPath), typeof(ComplexPath), new PropertyMetadata(null));

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.RegisterAttached("ItemsSource", typeof(IEnumerable), typeof(ComplexBindingHelper), new PropertyMetadata(null, OnItemsSourceChanged));

        #endregion

        #endregion

        #region EventHandlers

        private static void grid_CustomUnboundColumnData(object sender, GridColumnDataEventArgs e)
        {
            if (string.IsNullOrEmpty(GetComplexFieldName(e.Column)))
                return;
            ComplexPath complexPath = GetComplexPath(e.Column);
            GridControl grid = (GridControl)sender;
            try
            {
                if (e.IsGetData)
                    e.Value = complexPath.CalcValue(grid.GetRowByListIndex(e.ListSourceRowIndex));
                if (e.IsSetData)
                    complexPath.SetValue(grid.GetRowByListIndex(e.ListSourceRowIndex), e.Value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("Exception during ComplexBinding: {0}", ex.Message));
                Debug.Write(ex.StackTrace);
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static string GetComplexFieldName(GridColumn obj)
        {
            return (string)obj.GetValue(ComplexFieldNameProperty);
        }

        public static IEnumerable GetItemsSource(GridControl obj)
        {
            return (IEnumerable)obj.GetValue(ItemsSourceProperty);
        }

        public static void SetComplexFieldName(GridColumn obj, string value)
        {
            obj.SetValue(ComplexFieldNameProperty, value);
        }

        public static void SetItemsSource(GridControl obj, IEnumerable value)
        {
            obj.SetValue(ItemsSourceProperty, value);
        }

        #endregion

        #region Private Static Methods

        private static ComplexPath GetComplexPath(GridColumn obj)
        {
            return (ComplexPath)obj.GetValue(ComplexPathProperty);
        }

        private static void OnComplexFieldNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GridColumn column = (GridColumn)d;
            if (!string.IsNullOrEmpty((string)e.OldValue))
                column.ClearValue(ComplexPathProperty);
            column.FieldName = (string)e.NewValue;
            if (!string.IsNullOrEmpty(column.FieldName))
                SetComplexPath(column, new ComplexPath(column.FieldName));
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            GridControl grid = (GridControl)d;

            if (e.OldValue != null)
            {
                grid.CustomUnboundColumnData -= grid_CustomUnboundColumnData;
            }

            grid.ItemsSource = e.NewValue;

            if (e.NewValue != null)
            {
                grid.CustomUnboundColumnData += grid_CustomUnboundColumnData;
            }
        }

        private static void SetComplexPath(GridColumn obj, ComplexPath value)
        {
            obj.SetValue(ComplexPathProperty, value);
        }

        #endregion

        #endregion

        #region Nested Types

        private class ComplexPath
        {
            #region Fields

            #region Private Constant/Read-Only Fields

            private readonly List<PathPartSimple> _pathParts = new List<PathPartSimple>();

            #endregion

            #endregion

            #region Constructors

            public ComplexPath(string complexPath)
            {
                string[] paths = complexPath.Split('.');

                for (int i = 0; i < paths.Length; i++)
                {
                    string path = paths[i];
                    bool isListIndex = false;
                    int listBraceIndex = path.IndexOf("[");
                    int dictBraceIndex = path.IndexOf("(");
                    string index = null;

                    int braceIndex = 0;
                    if (listBraceIndex > 0)
                    {
                        braceIndex = listBraceIndex;
                        isListIndex = true;
                    }
                    else
                    {
                        braceIndex = dictBraceIndex;
                    }

                    if (braceIndex >= 0)
                    {
                        index = path.Substring(braceIndex + 1, path.Length - braceIndex - 2);
                        path = path.Substring(0, braceIndex);
                    }

                    PathPartSimple pathPart;

                    if (!string.IsNullOrEmpty(index) && isListIndex)
                    {
                        pathPart = new PathPartList(path, int.Parse(index));
                    }
                    else if (!string.IsNullOrEmpty(index))
                    {
                        pathPart = new PathPartDictionary(path, index);
                    }
                    else
                    {
                        pathPart = new PathPartSimple(path);
                    }

                    _pathParts.Add(pathPart);
                }
            }

            #endregion

            #region Methods

            #region Public Methods

            public object CalcValue(object row)
            {
                return CalcValueCore(row, false);
            }

            public void SetValue(object row, object value)
            {
                object lastValue = CalcValueCore(row, true);
                if (lastValue == null)
                    return;
                _pathParts[_pathParts.Count - 1].SetValue(lastValue, value);
            }

            #endregion

            #region Private Methods

            private object CalcValueCore(object row, bool skipLastPath)
            {
                for (int i = 0; i < _pathParts.Count - (skipLastPath ? 1 : 0); i++)
                {
                    row = _pathParts[i].CalcValue(row);
                    if (row == null)
                        break;
                }
                return row;
            }

            #endregion

            #endregion

            #region Nested Types

            private class PathPartDictionary : PathPartSimple
            {
                #region Fields

                #region Private Constant/Read-Only Fields

                private readonly string _index;
                private readonly int? _intIndex;

                #endregion

                #endregion

                #region Constructors

                public PathPartDictionary(string propertyName, string index)
                    : base(propertyName)
                {
                    _index = index;
                    int tmp;

                    if (int.TryParse(index, out tmp))
                    {
                        _intIndex = tmp;
                    }
                }

                #endregion

                #region Methods

                #region Internal Methods

                internal override object CalcValue(object row)
                {
                    IDictionary dict = GetDictionary(row);

                    if (dict == null)
                    {
                        return null;
                    }

                    if (_intIndex.HasValue)
                    {
                        return dict[_intIndex.Value];
                    }

                    return dict[_index];
                }

                internal override void SetValue(object row, object value)
                {
                    IDictionary dict = GetDictionary(row);

                    if (dict == null)
                    {
                        return;
                    }

                    if (_intIndex.HasValue)
                    {
                        dict[_intIndex.Value] = value;
                    }

                    dict[_index] = value;
                }

                #endregion

                #region Private Methods

                private IDictionary GetDictionary(object row)
                {
                    return base.CalcValue(row) as IDictionary;
                }

                #endregion

                #endregion
            }

            private class PathPartList : PathPartSimple
            {
                #region Fields

                #region Private Constant/Read-Only Fields

                private readonly int _index;

                #endregion

                #endregion

                #region Constructors

                public PathPartList(string propertyName, int index)
                    : base(propertyName)
                {
                    _index = index;
                }

                #endregion

                #region Methods

                #region Internal Methods

                internal override object CalcValue(object row)
                {
                    IList list = GetList(row);

                    if (list == null)
                    {
                        return null;
                    }

                    return list[_index];
                }

                internal override void SetValue(object row, object value)
                {
                    IList list = GetList(row);

                    if (list == null)
                    {
                        return;
                    }

                    list[_index] = value;
                }

                #endregion

                #region Private Methods

                private IList GetList(object row)
                {
                    return base.CalcValue(row) as IList;
                }

                #endregion

                #endregion
            }

            private class PathPartSimple
            {
                #region Fields

                #region Private Constant/Read-Only Fields

                private readonly string _propertyName;

                #endregion

                #endregion

                #region Constructors

                public PathPartSimple(string propertyName)
                {
                    _propertyName = propertyName;
                }

                #endregion

                #region Methods

                #region Internal Methods

                internal virtual object CalcValue(object row)
                {
                    PropertyInfo propertyInfo = GetPropertyInfo(row);

                    if (propertyInfo == null)
                    {
                        return null;
                    }

                    return propertyInfo.GetValue(row, null);
                }

                internal virtual void SetValue(object row, object value)
                {
                    PropertyInfo propertyInfo = GetPropertyInfo(row);

                    if (propertyInfo == null)
                    {
                        return;
                    }

                    propertyInfo.SetValue(row, value, null);
                }

                #endregion

                #region Private Methods

                private PropertyInfo GetPropertyInfo(object row)
                {
                    return row.GetType().GetProperty(_propertyName, BindingFlags.Public | BindingFlags.Instance);
                }

                #endregion

                #endregion
            }

            #endregion
        }

        #endregion
    }
}