using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

using Kiss.Interfaces.UI;

using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Class for translation of control
    /// </summary>
    public class KissTranslation
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// The insert/update sql for components
        /// </summary>
        public const string SQL_INSERT_X_CLASS = @"
            DECLARE @ClassName VARCHAR(100)
            DECLARE @ModulID INT
            DECLARE @ClassCode INT

            SET @ClassName = {0}

            SELECT @ModulID = ModulID
            FROM dbo.XModul WITH (READUNCOMMITTED)
            WHERE NameSpace = {1}

            SELECT @ClassCode = Code
            FROM dbo.XLOVCode WITH (READUNCOMMITTED)
            WHERE LOVName = 'Class'
              AND Value1 = {2}

            IF (NOT EXISTS(SELECT TOP 1 1
                           FROM dbo.XClass WITH (READUNCOMMITTED)
                           WHERE ClassName = @ClassName))
            BEGIN
              INSERT INTO dbo.XClass (ClassName, ModulID, BaseType, ClassCode, PropertiesXML)
                SELECT {0}, ISNULL(@ModulID, 0), {2}, @ClassCode, {3}
            END
            ELSE IF (EXISTS (SELECT TOP 1 1
                             FROM dbo.XClass WITH (READUNCOMMITTED)
                             WHERE ClassName = @ClassName
                               AND PropertiesXML IS NULL))
            BEGIN
              UPDATE CLS
              SET CLS.ModulID       = ISNULL(@ModulID, CLS.ModulID),
                  CLS.BaseType      = {2},
                  CLS.ClassCode     = ISNULL(@ClassCode, CLS.ClassCode),
                  CLS.PropertiesXML = {3}
              FROM dbo.XClass CLS
              WHERE CLS.ClassName = @ClassName
            END";

        #endregion

        #region Private Static Fields

        private static BindingFlags _flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly ContainerControl _container;

        #endregion

        #region Private Fields

        private bool _fillDBWithControls = true; // TODO irgendwo setzen (Systemeinstellung?)

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissTranslation"/> class.
        /// </summary>
        /// <param name="ctl">The container control to parse</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if parameter are invalid</exception>
        public KissTranslation(ContainerControl ctl)
        {
            // validate
            if (Session.User == null)
            {
                return;
            }

            if (ctl == null)
            {
                throw new ArgumentOutOfRangeException("ctl", "Invalid instance of container control received, cannot create instance of KissTranslation.");
            }

            Components = new Hashtable();

            // apply members
            _container = ctl;

            // get flag if class was already added into database
            bool insertIntoDB = !Session.CacheManager.ClassTranslation.IsClassInsertedIntoDB(ctl.GetType().FullName, Session.User.LanguageCode);

            // form title
            if (_container is KissForm)
            {
                Components[_container.Name] = KissCompPropDescriptor.Create(_container);
            }
            else
            {
                // find form if complex control
                Control c = ctl;

                while (c.Parent != null && !(c is KissForm))
                {
                    c = c.Parent;
                }

                if (c.GetType().FullName == "KiSS4.Common.DlgKissUserControl")
                {
                    Components[_container.Name] = KissCompPropDescriptor.Create(c);
                }
            }

            // get all components of the container control
            FillComponents(ctl);

            // fill controls and components into database
            if (_fillDBWithControls && insertIntoDB)
            {
                FillDBWithControls();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The hashtable with all found components on container control
        /// </summary>
        public Hashtable Components
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Translate components to defined language
        /// </summary>
        /// <param name="languageCode">The language code to use for translation</param>
        public void Translate(int languageCode)
        {
            // get all controls, component and the class itself for current container control including the translation for desired language
            SqlQuery qry = Session.CacheManager.ClassTranslation.GetTranslationQuery(_container.GetType().Name, Session.User.LanguageCode);

            // translate all components found in hashtable with text found in translation
            foreach (DataRow row in qry.DataTable.Rows)
            {
                KissCompPropDescriptor kcpd = Components[row["ControlName"]] as KissCompPropDescriptor;

                if (kcpd != null)
                {
                    try
                    {
                        kcpd.Value = row["Text"];
                    }
                    catch { }
                }
            }

            // handle DropDowns/Checkboxlookups (LOV)
            foreach (string controlName in Components.Keys)
            {
                if (controlName != string.Empty)
                {
                    if (Components[controlName] is KissLookUpEdit)
                    {
                        ((KissLookUpEdit)Components[controlName]).Translate(languageCode);
                    }
                    else if (Components[controlName] is KissCheckedLookupEdit)
                    {
                        ((KissCheckedLookupEdit)Components[controlName]).Translate(languageCode);
                    }
                }
            }
        }

        #endregion

        #region Private Static Methods

        private static string PropertiesXmlAppendProperty(string propertiesXml, string propertyName, object value, object defaultValue)
        {
            if (defaultValue != value && (defaultValue == null || !defaultValue.Equals(value)))
            {
                return PropertiesXmlAppendProperty(propertiesXml, propertyName, value);
            }
            else
            {
                return propertiesXml;
            }
        }

        private static string PropertiesXmlAppendProperty(string propertiesXml, string propertyName, object value)
        {
            return string.Format("{0}  <Property name=\"{1}\">{2}</Property>\r\n</Object>", propertiesXml.Substring(0, propertiesXml.Length - 9),
                                                                                            propertyName,
                                                                                            value);
        }

        private static string PropertiesXmlAppendPropertyReference(string propertiesXml, string propertyName, string refName)
        {
            if (refName == null)
            {
                return propertiesXml;
            }

            return PropertiesXmlAppendProperty(propertiesXml, propertyName, string.Format("\r\n    <Reference name=\"{0}\" />\r\n", refName));
        }

        #endregion

        #region Private Methods

        private bool AddComponent(Component cmp)
        {
            return AddComponent(cmp, cmp.GetType());
        }

        private bool AddComponent(Component cmp, Type type)
        {
            foreach (FieldInfo fi in _container.GetType().GetFields(_flags))
            {
                if (fi.FieldType == type && cmp.Equals(fi.GetValue(_container)))
                {
                    Components[fi.Name] = KissCompPropDescriptor.Create(cmp);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Fill hashtable with components found on control (recursive)
        /// </summary>
        /// <param name="control">The control to parse</param>
        private void FillComponents(Control control)
        {
            // check if we have a container control (Form, ...)
            if (control is IContainerControl || control is IContainer)
            {
                try
                {
                    // get all components within the container
                    object comps = null;

                    // check if control has the property "components"
                    FieldInfo fi = control.GetType().GetField("components", BindingFlags.NonPublic | BindingFlags.Instance);

                    if (fi != null)
                    {
                        comps = fi.GetValue(control);
                    }

                    // validate
                    if (comps != null && comps is Container)
                    {
                        // convert to real components-list
                        Container components = (Container)comps;

                        // loop and get all sql-queries
                        foreach (Component comp in components.Components)
                        {
                            // check if we have a query that is not yet in the hashtable
                            if (comp is SqlQuery && !Components.ContainsValue(comp))
                            {
                                AddComponent(comp);
                            }
                        }
                    }
                }
                catch { }
            }

            // loop controls
            foreach (Control ctl in control.Controls)
            {
                SqlQuery qry = null;

                if (ctl is IKissBindableEdit)
                {
                    qry = ((IKissBindableEdit)ctl).DataSource;
                }
                else if (ctl is KissGrid)
                {
                    qry = ((KissGrid)ctl).DataSource as SqlQuery;
                }
                else if (ctl is KissTree)
                {
                    qry = ((KissTree)ctl).DataSource as SqlQuery;
                }

                if (qry != null && !Components.ContainsValue(qry))
                {
                    AddComponent(qry);
                }

                // add component or KissCompPropDescriptor for component to hashtable
                Components[ctl.Name] = KissCompPropDescriptor.Create(ctl);

                // check type to handle special cases
                DevExpress.XtraBars.BarManager barManager = null;

                if (ctl is KissGrid)
                {
                    // add all columns of all views on grid
                    foreach (DevExpress.XtraGrid.Views.Grid.GridView gv in ((KissGrid)ctl).Views)
                    {
                        Components[gv.Name] = gv;

                        foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gv.Columns)
                        {
                            Components[gc.Name] = KissCompPropDescriptor.Create(gc);
                        }
                    }

                    // get menumanager used for grid
                    barManager = ((KissGrid)ctl).MenuManager as DevExpress.XtraBars.BarManager;
                }
                else if (ctl is KissTree)
                {
                    // add all columns of the tree
                    foreach (DevExpress.XtraTreeList.Columns.TreeListColumn col in ((KissTree)ctl).Columns)
                    {
                        Components[col.Name] = KissCompPropDescriptor.Create(col);
                    }

                    // get menumanager used for tree
                    barManager = ((KissTree)ctl).MenuManager as DevExpress.XtraBars.BarManager;
                }

                // if we have a barManager, add all menuItems (except: btnExcel and btnPrint) to hashtable
                if (barManager != null)
                {
                    AddComponent(barManager);

                    DevExpress.XtraBars.PopupMenu popupMenu = barManager.GetPopupContextMenu(ctl);

                    if (popupMenu != null)
                    {
                        AddComponent(popupMenu);
                    }

                    foreach (DevExpress.XtraBars.BarItem barItem in barManager.Items)
                    {
                        AddComponent(barItem);
                    }
                }

                // check if component has children
                if (ctl.HasChildren && (ctl is KissContainerControl || !(ctl is KissComplexControl)))
                {
                    // recursive call to get all child-components of current component
                    FillComponents(ctl);
                }
            }
        }

        /// <summary>
        /// Insert controls into database
        /// </summary>
        private void FillDBWithControls()
        {
            if (_container.Name != "CtlDynaMask")
            {
                Type containerType = _container.GetType();
                SqlQuery qryComponent = DBUtil.OpenSQL(@"
                    DECLARE @ClassName  varchar(100)
                    SET @ClassName = {0}

                    SELECT ControlName = CTL.ControlName,
                           TypeName    = CTL.TypeName
                    FROM dbo.XClassControl CTL WITH (READUNCOMMITTED)
                    WHERE CTL.ClassName = @ClassName

                    UNION ALL

                    SELECT ControlName = CMP.ComponentName,
                           TypeName    = CMP.TypeName
                    FROM dbo.XClassComponent CMP WITH (READUNCOMMITTED)
                    WHERE CMP.ClassName = @ClassName", containerType.Name);

                string propertiesXml = "<Object>\r\n</Object>";

                if (_container is Form)
                {
                    propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Text", _container.Text);
                    propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "ClientSize", string.Format("{0}, {1}", _container.ClientSize.Width,
                                                                                                                        _container.ClientSize.Height));
                }
                else
                {
                    propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Size", string.Format("{0}, {1}", _container.Size.Width,
                                                                                                                  _container.Size.Height));
                }

                // Active SQL-Query
                IKissActiveSQLQuery iKissActiveSQLQuery = _container as IKissActiveSQLQuery;

                if (iKissActiveSQLQuery != null && iKissActiveSQLQuery.ActiveSQLQuery != null)
                {
                    propertiesXml = PropertiesXmlAppendPropertyReference(propertiesXml, "ActiveSQLQuery", iKissActiveSQLQuery.ActiveSQLQuery);
                }

                SqlQuery qryXClass = DBUtil.OpenSQL(SQL_INSERT_X_CLASS,
                                                    containerType.Name,
                                                    containerType.Namespace,
                                                    containerType.BaseType.FullName,
                                                    propertiesXml);

                foreach (string controlName in Components.Keys)
                {
                    if (controlName != string.Empty)
                    {
                        KissCompPropDescriptor kcpd = Components[controlName] as KissCompPropDescriptor;
                        Component cmp = kcpd == null ? Components[controlName] as Component : kcpd.Component;

                        if (cmp is KissForm ||
                            qryComponent.DataTable.Select(string.Format("ControlName = '{0}' AND TypeName = '{1}'", controlName, cmp.GetType().FullName)).Length == 1)
                        {
                            continue;
                        }

                        propertiesXml = "<Object>\r\n</Object>";

                        if (kcpd != null)
                        {
                            propertiesXml = PropertiesXmlAppendProperty(propertiesXml, kcpd.PropertyName, kcpd.Value);
                        }

                        Control ctl = cmp as Control;

                        if (ctl != null)
                        {
                            string dataSource = null;
                            string dataMember = null;

                            #region Special Properties

                            if (cmp is KissLabel)
                            {
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "LabelStyle", ((KissLabel)cmp).LabelStyle);
                            }
                            else if (cmp is KissButton)
                            {
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "IconID", ((KissButton)cmp).IconID, -1);
                            }
                            else if (cmp is KissGrid)
                            {
                                KissGrid grid = (KissGrid)cmp;

                                if (grid.DataSource != null && grid.DataSource is Component)
                                {
                                    dataSource = GetRefObjectName((Component)grid.DataSource);
                                    propertiesXml = PropertiesXmlAppendPropertyReference(propertiesXml, "DataSource", (Component)grid.DataSource);
                                }

                                string viewCollection = "";

                                foreach (DevExpress.XtraGrid.Views.Base.BaseView vw in grid.ViewCollection)
                                {
                                    if (vw.Name != string.Empty)
                                    {
                                        viewCollection += string.Format("\r\n    <Item type=\"{0}\">\r\n      <Reference name=\"{1}\" />\r\n    </Item>", vw.GetType().FullName, vw.Name);
                                    }
                                }

                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "ViewCollection", viewCollection);

                                propertiesXml = PropertiesXmlAppendPropertyReference(propertiesXml, "MainView", grid.MainView.Name);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "GridStyle", grid.GridStyle);
                            }
                            else if (cmp is KissTree)
                            {
                                KissTree tree = (KissTree)cmp;

                                if (tree.DataSource != null && tree.DataSource is Component)
                                {
                                    dataSource = GetRefObjectName((Component)tree.DataSource);
                                    propertiesXml = PropertiesXmlAppendPropertyReference(propertiesXml, "DataSource", (Component)tree.DataSource);
                                }

                                string columns = "";

                                foreach (DevExpress.XtraTreeList.Columns.TreeListColumn col in tree.Columns)
                                {
                                    columns += string.Format("\r\n    <Item type=\"{0}\">\r\n      <Reference name=\"{1}\" />\r\n    </Item>", col.GetType().FullName, col.Name);
                                }

                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Columns", columns);
                            }
                            else if (cmp is KissTabControlEx)
                            {
                                KissTabControlEx tabControl = (KissTabControlEx)cmp;
                                string tabPages = "";

                                foreach (SharpLibrary.WinControls.TabPageEx tabPage in tabControl.TabPages)
                                {
                                    tabPages += string.Format("\r\n    <Item type=\"{0}\">\r\n      <Reference name=\"{1}\" />\r\n    </Item>", tabPage.GetType().FullName, tabPage.Name);
                                }

                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "TabPages", tabPages);
                            }
                            else if (cmp is KissLookUpEdit)
                            {
                                KissLookUpEdit kissLookUpEdit = (KissLookUpEdit)cmp;

                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "LOVName", kissLookUpEdit.LOVName, string.Empty);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "LOVFilterWhereAppend", kissLookUpEdit.LOVFilterWhereAppend, false);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "LOVFilter", kissLookUpEdit.LOVFilter, string.Empty);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "AllowNull", kissLookUpEdit.AllowNull, true);
                            }
                            else if (cmp is KissCheckedLookupEdit)
                            {
                                KissCheckedLookupEdit kissCheckedLookupEdit = (KissCheckedLookupEdit)cmp;

                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "LOVName", kissCheckedLookupEdit.LOVName, string.Empty);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "LOVFilter", kissCheckedLookupEdit.LOVFilter, string.Empty);
                            }
                            else if (cmp is KissTabControlEx)
                            {
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "TabsLocation", ((KissTabControlEx)cmp).TabsLocation);
                            }

                            if (cmp is DevExpress.XtraEditors.BaseEdit)
                            {
                                DevExpress.XtraEditors.BaseEdit baseEdit = (DevExpress.XtraEditors.BaseEdit)cmp;

                                string properies = string.Empty;

                                if (baseEdit.Properties.EditFormat.FormatType != DevExpress.Utils.FormatType.None && baseEdit.Properties.EditFormat.FormatString != "")
                                {
                                    properies += string.Format(@"
                                        <Property name=""EditFormat"">
                                          <Property name=""FormatType"">{0}</Property>
                                          <Property name=""FormatString"">{1}</Property>
                                        </Property>", baseEdit.Properties.EditFormat.FormatType, baseEdit.Properties.EditFormat.FormatString);
                                }

                                if (baseEdit.Properties.DisplayFormat.FormatType != DevExpress.Utils.FormatType.None && baseEdit.Properties.DisplayFormat.FormatString != "")
                                {
                                    properies += string.Format(@"
                                        <Property name=""DisplayFormat"">
                                          <Property name=""FormatType"">{0}</Property>
                                          <Property name=""FormatString"">{1}</Property>
                                        </Property>", baseEdit.Properties.DisplayFormat.FormatType, baseEdit.Properties.DisplayFormat.FormatString);
                                }

                                if (baseEdit.Properties.NullText != "")
                                {
                                    properies += string.Format(@"
                                        <Property name=""NullText"">{0}</Property>", baseEdit.Properties.NullText);
                                }

                                DevExpress.XtraEditors.ButtonEdit buttonEdit = cmp as DevExpress.XtraEditors.ButtonEdit;

                                if (buttonEdit != null && buttonEdit.Properties.Buttons.Count > 0)
                                {
                                    properies += "\r\n    <Property name=\"Buttons\">";

                                    foreach (DevExpress.XtraEditors.Controls.EditorButton btn in buttonEdit.Properties.Buttons)
                                    {
                                        properies += string.Format(@"
                                          <Item type=""{0}"">
                                            <InstanceDescriptor type=""{0}"">
                                              <Property name=""Kind"">{1}</Property>
                                            </InstanceDescriptor>
                                          </Item>", btn.GetType().FullName, btn.Kind);
                                    }

                                    properies += "\r\n    </Property>";
                                }

                                if (properies != "")
                                {
                                    propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Properties", properies);
                                }
                            }
                            #endregion

                            // RightToLeft
                            propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "RightToLeft", ctl.RightToLeft, RightToLeft.No);

                            // Anchor
                            propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Anchor", ctl.Anchor, (AnchorStyles.Top | AnchorStyles.Left));

                            // Docking
                            propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Dock", ctl.Dock, DockStyle.None);

                            // EditMode
                            IKissEditable iKissEditable = cmp as IKissEditable;

                            if (iKissEditable != null && iKissEditable.EditMode != EditModeType.Normal)
                            {
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "EditMode", iKissEditable.EditMode);
                            }

                            // Databinding
                            IKissBindableEdit iKissBindableEdit = cmp as IKissBindableEdit;

                            if (iKissBindableEdit != null && !DBUtil.IsEmpty(iKissBindableEdit.DataMember))
                            {
                                if (iKissBindableEdit.DataSource != null)
                                {
                                    dataSource = GetRefObjectName(iKissBindableEdit.DataSource);
                                }

                                dataMember = iKissBindableEdit.DataMember;
                            }

                            if (propertiesXml == "<Object>\r\n</Object>")
                            {
                                propertiesXml = null;
                            }

                            DBUtil.OpenSQL(@"
                                DELETE FROM dbo.XClassComponent
                                WHERE ClassName = {0}
                                  AND ComponentName = {1}

                                DELETE FROM dbo.XClassControl
                                WHERE ClassName = {0}
                                  AND ControlName = {1}

                                INSERT INTO dbo.XClassControl (ClassName, ControlName, ParentControl, TypeName, TabIndex, X, Y, Width, Height, DataSource, DataMember, PropertiesXML)
                                  VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})", containerType.Name,
                                                                                                          controlName,
                                                                                                          ctl.Parent == _container ? null : ctl.Parent.Name,
                                                                                                          cmp.GetType().ToString(),
                                                                                                          ctl.TabIndex,
                                                                                                          ctl.Location.X,
                                                                                                          ctl.Location.Y,
                                                                                                          ctl.Width,
                                                                                                          ctl.Height,
                                                                                                          dataSource,
                                                                                                          dataMember,
                                                                                                          propertiesXml);
                        }
                        else
                        {
                            // ctl is null!

                            // setup vars
                            string selectStatement = null;
                            string tableName = null;

                            if (cmp is SqlQuery)
                            {
                                SqlQuery qry = (SqlQuery)cmp;

                                selectStatement = qry.SelectStatement;
                                tableName = qry.TableName;

                                if (qry.HostControl != null)
                                {
                                    propertiesXml = PropertiesXmlAppendPropertyReference(propertiesXml, "HostControl", qry.HostControl.Name);
                                }

                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "AutoApplyUserRights", qry.AutoApplyUserRights, true);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "CanInsert", qry.CanInsert, false);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "CanUpdate", qry.CanUpdate, false);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "CanDelete", qry.CanDelete, false);
                            }
                            else if (cmp is DevExpress.XtraGrid.Views.Grid.GridView)
                            {
                                DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)cmp;
                                propertiesXml = PropertiesXmlAppendPropertyReference(propertiesXml, "GridControl", gridView.GridControl.Name);
                                string columns = "";

                                if (gridView.OptionsView.ShowFooter)
                                {
                                    propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "OptionsView", "<Property name=\"ShowFooter\" type=\"System.Boolean\">True</Property>");
                                }

                                foreach (DevExpress.XtraGrid.Columns.GridColumn col in ((DevExpress.XtraGrid.Views.Grid.GridView)cmp).Columns)
                                {
                                    columns += string.Format("\r\n    <Item type=\"{0}\">\r\n      <Reference name=\"{1}\" />\r\n    </Item>", col.GetType().FullName, col.Name);
                                }

                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Columns", columns);
                            }
                            else if (cmp is DevExpress.XtraGrid.Columns.GridColumn)
                            {
                                DevExpress.XtraGrid.Columns.GridColumn gridColumn = (DevExpress.XtraGrid.Columns.GridColumn)cmp;
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "VisibleIndex", gridColumn.VisibleIndex);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Width", gridColumn.Width);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "FieldName", gridColumn.FieldName);

                                if (gridColumn.DisplayFormat.FormatType != DevExpress.Utils.FormatType.None && gridColumn.DisplayFormat.FormatString != "")
                                {
                                    propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "DisplayFormat", string.Format(@"
                                          <Property name=""FormatType"">{0}</Property>
                                          <Property name=""FormatString"">{1}</Property>
                                        ", gridColumn.DisplayFormat.FormatType, gridColumn.DisplayFormat.FormatString));
                                }

                                if (gridColumn.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                                {
                                    propertiesXml = PropertiesXmlAppendProperty(propertiesXml,
                                                                                 "SummaryItem",
                                                                                 string.Format("<Property name=\"DisplayFormat\">{0}</Property><Property name=\"SummaryType\" type=\"DevExpress.Data.SummaryItemType\">{1}</Property>", gridColumn.SummaryItem.DisplayFormat, gridColumn.SummaryItem.SummaryType));
                                }
                            }
                            else if (cmp is DevExpress.XtraTreeList.Columns.TreeListColumn)
                            {
                                DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn = (DevExpress.XtraTreeList.Columns.TreeListColumn)cmp;
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "VisibleIndex", treeListColumn.VisibleIndex);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Width", treeListColumn.Width);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "FieldName", treeListColumn.FieldName);
                            }
                            else if (cmp is DevExpress.XtraBars.BarManager)
                            {
                                DevExpress.XtraBars.BarManager barManager = (DevExpress.XtraBars.BarManager)cmp;
                                string items = string.Empty;

                                foreach (DevExpress.XtraBars.BarItem barItem in barManager.Items)
                                {
                                    items += string.Format("\r\n    <Item type=\"{0}\">\r\n      <Reference name=\"{1}\" />\r\n    </Item>", barItem.GetType().FullName, barItem.Name);
                                }

                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Items", items);
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "MaxItemId", barManager.MaxItemId);
                            }
                            else if (cmp is DevExpress.XtraBars.BarItem)
                            {
                                DevExpress.XtraBars.BarItem barItem = (DevExpress.XtraBars.BarItem)cmp;
                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "Id", barItem.Id, -1);

                                if (KissImageList.SmallImageList.Equals(barItem.Manager.Images))
                                {
                                    propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "ImageIndex", KissImageList.GetXIconID(barItem.ImageIndex), -1);
                                }
                            }
                            else if (cmp is DevExpress.XtraBars.PopupMenu)
                            {
                                string linkPersistInfo = string.Empty;

                                foreach (DevExpress.XtraBars.LinkPersistInfo item in ((DevExpress.XtraBars.PopupMenu)cmp).LinksPersistInfo)
                                {
                                    linkPersistInfo += string.Format(@"
                                        <Item type=""{0}"">
                                          <InstanceDescriptor type=""{0}"">
                                            <Argument name=""item"" type=""{2}"">
                                              <Reference name=""{1}"" />
                                            </Argument>
                                            <Property name=""BeginGroup"">{3}</Property>
                                          </InstanceDescriptor>
                                        </Item>", item.GetType().FullName, item.Item.Name, item.Item.GetType().FullName, item.BeginGroup);
                                }

                                propertiesXml = PropertiesXmlAppendProperty(propertiesXml, "LinksPersistInfo", linkPersistInfo, string.Empty);
                            } // [if (cmp is ...)]

                            // check if need to reset propertiesxml
                            if (propertiesXml == "<Object>\r\n</Object>")
                            {
                                propertiesXml = null;
                            }

                            // do some db-stuff (TODO: why??)
                            DBUtil.OpenSQL(@"
                                DELETE FROM dbo.XClassComponent
                                WHERE ClassName = {0}
                                  AND ComponentName = {1}

                                DELETE FROM dbo.XClassControl
                                WHERE ClassName = {0}
                                  AND ControlName = {1}

                                INSERT INTO dbo.XClassComponent (ClassName, ComponentName, TypeName, SelectStatement, TableName, PropertiesXML)
                                VALUES ({0}, {1}, {2}, {3}, {4}, {5})", containerType.Name,
                                                                        controlName,
                                                                        cmp.GetType().ToString(),
                                                                        selectStatement,
                                                                        tableName,
                                                                        propertiesXml);
                        }
                    }
                }
            }
        }

        private string GetRefObjectName(Component refObject)
        {
            foreach (string key in Components.Keys)
            {
                if (Components[key].Equals(refObject))
                {
                    return key;
                }
            }

            return null;
        }

        private string PropertiesXmlAppendPropertyReference(string propertiesXml, string propertyName, Component refObject)
        {
            return PropertiesXmlAppendPropertyReference(propertiesXml, propertyName, GetRefObjectName(refObject));
        }

        #endregion

        #endregion
    }
}