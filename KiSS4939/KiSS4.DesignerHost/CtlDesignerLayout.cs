using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;
using Microsoft.CSharp;

namespace KiSS4.DesignerHost
{
    public class CtlDesignerLayout : KiSS4.Gui.KissUserControl
    {
        internal const string SelectClassReference = @"
			DECLARE @XClass TABLE (
			  ClassName  varchar(255) COLLATE DATABASE_DEFAULT PRIMARY KEY,
			  Level      int NOT NULL DEFAULT(0)
			)

			{0}

			WHILE @@RowCount > 0 BEGIN
			  INSERT INTO @XClass (ClassName)
			    SELECT DISTINCT REF.ClassName
			    FROM XClassReference  REF
			      INNER JOIN XClass   CLS ON CLS.ClassName = REF.ClassName AND CLS.Designer > 0
			      INNER JOIN @XClass  TMP ON TMP.ClassName = REF.ClassName_Ref
			    WHERE NOT EXISTS (SELECT * FROM @XClass WHERE ClassName = REF.ClassName)
			END

			DECLARE @Loop  int  SET @Loop = 0
			WHILE (1 = 1) BEGIN
			  SET @Loop = @Loop + 1

			  UPDATE CLS
			    SET Level = CLR.Level + 1
			  FROM @XClass                  CLS
			    INNER JOIN XClassReference  REF ON REF.ClassName = CLS.ClassName
			    INNER JOIN @XClass          CLR ON CLR.ClassName = REF.ClassName_Ref
			  WHERE CLR.Level >= CLS.Level

			  IF @@RowCount = 0 OR @Loop > 100 BREAK
			END

			SELECT CLS.*, DesignerCode = CONVERT(int, CLS.Designer), MOD.NameSpace
			FROM @XClass         TMP
			  INNER JOIN XClass  CLS ON CLS.ClassName = TMP.ClassName
			  INNER JOIN XModul  MOD ON MOD.ModulID = CLS.ModulID
			WHERE CLS.Designer > 0
			ORDER BY TMP.Level, CLS.ClassName";

        private Assembly asmBuild;
        private System.Windows.Forms.ComboBox cboElements;
        private ContextMenuStrip cntMenu;
        private System.ComponentModel.IContainer components = null;
        private KeystrokeMessageFilter filter;
        private ServiceContainer hostingServiceContainer;
        private System.Windows.Forms.ImageList imgToolbar;
        private MyCodeDomDesignerLoader loader;
        private ToolStripMenuItem mnuDescription;
        private ToolStripMenuItem mnuReset;
        private System.Windows.Forms.Panel panDesign;
        private System.Windows.Forms.Panel panMiddle;
        private System.Windows.Forms.Panel panRight;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private KiSS4.DB.SqlQuery qryXClass;
        private KiSS4.DB.SqlQuery qryXClassComponent;
        private KiSS4.DB.SqlQuery qryXClassControl;
        private KiSS4.Gui.KissSplitterCollapsible splitLeft;
        private KiSS4.Gui.KissSplitterCollapsible splitRight;
        private MyDesignSurface surface;
        private System.Windows.Forms.ToolBarButton tbnAlignBottoms;
        private System.Windows.Forms.ToolBarButton tbnAlignCenters;
        private System.Windows.Forms.ToolBarButton tbnAlignLefts;
        private System.Windows.Forms.ToolBarButton tbnAlignMiddles;
        private System.Windows.Forms.ToolBarButton tbnAlignRights;
        private System.Windows.Forms.ToolBarButton tbnAlignToGrid;
        private System.Windows.Forms.ToolBarButton tbnAlignTops;
        private System.Windows.Forms.ToolBarButton tbnBringToFront;
        private System.Windows.Forms.ToolBarButton tbnBuild;
        private System.Windows.Forms.ToolBarButton tbnCenterHorizontally;
        private System.Windows.Forms.ToolBarButton tbnCenterVertically;
        private System.Windows.Forms.ToolBarButton tbnDecreaseHorizontalSpacing;
        private System.Windows.Forms.ToolBarButton tbnDecreaseVerticalSpacing;
        private System.Windows.Forms.ToolBarButton tbnIncreaseHorizontalSpacing;
        private System.Windows.Forms.ToolBarButton tbnIncreaseVerticalSpacing;
        private System.Windows.Forms.ToolBarButton tbnMakeHorizontalSpacingEquals;
        private System.Windows.Forms.ToolBarButton tbnMakeSameHeight;
        private System.Windows.Forms.ToolBarButton tbnMakeSameSize;
        private System.Windows.Forms.ToolBarButton tbnMakeSameWidth;
        private System.Windows.Forms.ToolBarButton tbnMakeVerticalSpacingEquals;
        private System.Windows.Forms.ToolBarButton tbnRemoveHorizontalSpacing;
        private System.Windows.Forms.ToolBarButton tbnRemoveVerticalSpacing;
        private System.Windows.Forms.ToolBarButton tbnSendToBack;
        private System.Windows.Forms.ToolBarButton tbnTabOrder;
        private System.Windows.Forms.ToolBar tbrDesign;
        private System.Windows.Forms.ToolBarButton tbs0;
        private System.Windows.Forms.ToolBarButton tbs1;
        private System.Windows.Forms.ToolBarButton tbs2;
        private System.Windows.Forms.ToolBarButton tbs3;
        private System.Windows.Forms.ToolBarButton tbs4;
        private System.Windows.Forms.ToolBarButton tbs5;
        private System.Windows.Forms.ToolBarButton tbs6;
        private System.Windows.Forms.ToolBarButton tbs7;
        private System.Windows.Forms.ToolBarButton tbs8;
        private ToolboxPane toolbox;
        private ToolTip ttpDesignerLayout;

        public CtlDesignerLayout(SqlQuery qryXClass)
            : this(qryXClass,
                DBUtil.OpenSQL("SELECT * FROM XClassControl    WHERE ClassName = {0}", qryXClass["ClassName"]),
                DBUtil.OpenSQL("SELECT * FROM XClassComponent  WHERE ClassName = {0}", qryXClass["ClassName"]),
                null)
        { }

        public CtlDesignerLayout(SqlQuery qryXClass, SqlQuery qryXClassControl, SqlQuery qryXClassComponent, SqlQuery qryXClassRule)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            this.qryXClass = qryXClass;
            this.qryXClassControl = qryXClassControl;
            this.qryXClassComponent = qryXClassComponent;

            // Add any initialization after the InitializeComponent call
            hostingServiceContainer = new ServiceContainer();

            // Our ISelectionService looks for this and informs the grid
            // of selection changes.  In an environment such as Visual Studio, this
            // is all handled for you.
            //
            hostingServiceContainer.AddService(typeof(PropertyGrid), propertyGrid);

            // Our IToolboxService needs access to our toolbox.
            hostingServiceContainer.AddService(typeof(ToolboxPane), toolbox);

            // New KissUserControl
            CreateDesigner(new MyCodeDomDesignerLoader(this.qryXClass, this.qryXClassControl, this.qryXClassComponent, qryXClassRule));

            this.tbnBuild.Enabled = qryXClass.CanUpdate;
            if (!qryXClass.CanUpdate) this.splitLeft.ToggleState();
        }

        public static bool Build(SqlQuery qryXClass)
        {
            DlgProgressLog.AddLine(string.Format("Maske \"{0}\"", qryXClass["ClassName"]));

            CodeDomProvider cdp = new CSharpCodeProvider();

            #region CompilerParameters

            CompilerParameters cpParam = new CompilerParameters();

            Gui.AssemblyLoader.LoadProgramAssembly();
            try { cpParam.ReferencedAssemblies.Add(Assembly.GetAssembly(typeof(KiSS4.Messages.DlgError)).Location); }
            catch { }
            try { cpParam.ReferencedAssemblies.Add(Assembly.GetAssembly(typeof(KiSS4.Gui.KissUserControl)).Location); }
            catch { }
            try { cpParam.ReferencedAssemblies.Add(Assembly.GetAssembly(typeof(KiSS4.Common.KissModulTree)).Location); }
            catch { }
            try { cpParam.ReferencedAssemblies.Add(Assembly.GetAssembly(typeof(KiSS4.DB.DBUtil)).Location); }
            catch { }

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                try { cpParam.ReferencedAssemblies.Add(asm.Location); }
                catch { }

            try { cpParam.ReferencedAssemblies.Remove(Assembly.GetAssembly(typeof(CtlDesignerLayout)).Location); }
            catch { }

            cpParam.GenerateExecutable = false;
            cpParam.GenerateInMemory = false;
            cpParam.IncludeDebugInformation = true;
            cpParam.WarningLevel = 1;

            if (!System.Diagnostics.Debugger.IsAttached)
            {
                cpParam.CompilerOptions = "/optimize";
            }

            Directory.CreateDirectory(cpParam.TempFiles.BasePath);
            cpParam.OutputAssembly = string.Format(@"{0}\{1}.dll", cpParam.TempFiles.BasePath, qryXClass["ClassName"]);

            #endregion

            ArrayList alSourceFile = new ArrayList();
            Hashtable htSourceFile = new Hashtable();

            #region Class Reference

            SqlQuery qryXClassReference = DBUtil.OpenSQL(MyCodeDomDesignerLoader.SQLqryXClassReference, qryXClass["ClassName"]);

            if (qryXClassReference.Find(string.Format("ClassName = '{0}'", qryXClass["ClassName"])))
            {
                qryXClassReference["CodeGenerated"] = qryXClass["CodeGenerated"];
                qryXClassReference["Resource"] = qryXClass["Resource"];
            }

            string csFileName = string.Format("{0}\\AssemblyInfo.cs", cpParam.TempFiles.BasePath);
            File.WriteAllText(csFileName, string.Format(@"
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyTitle(""KiSS4.DynamicCompiled.{0}"")]
[assembly: AssemblyDescription(""KiSS4 dynamic compiled extension"")]
[assembly: AssemblyCompany(""Diartis AG"")]
[assembly: AssemblyProduct(""KiSS4.DynamicCompiled.{0}"")]
[assembly: AssemblyCopyright(""(c) Diartis AG"")]
[assembly: AssemblyVersion(""4.0.*"")]
", qryXClass["ClassName"]), Encoding.Default);
            cpParam.TempFiles.AddFile(csFileName, false);
            alSourceFile.Add(csFileName);

            foreach (DataRow row in qryXClassReference.DataTable.Rows)
            {
                csFileName = string.Format("{0}\\{1}.cs", cpParam.TempFiles.BasePath, row["ClassName"]);
                if ((int)row["SortKey"] < 2)
                    htSourceFile[csFileName.ToLower()] = row["ClassName"];
                else
                    htSourceFile[string.Format("E{0}", csFileName.ToLower())] = row["ClassName"];

                File.WriteAllText(csFileName, (string)row["CodeGenerated"], Encoding.Default);
                cpParam.TempFiles.AddFile(csFileName, true);
                alSourceFile.Add(csFileName);

                if (row["Resource"] != DBNull.Value)
                {
                    string resFileName = string.Format("{0}\\{1}.resources", cpParam.TempFiles.BasePath, row["FullName"]);
                    File.WriteAllBytes(resFileName, (byte[])row["Resource"]);
                    cpParam.TempFiles.AddFile(resFileName, false);

                    cpParam.EmbeddedResources.Add(resFileName);
                }
            }

            #endregion

            CompilerResults cr = cdp.CompileAssemblyFromFile(cpParam, (string[])alSourceFile.ToArray(typeof(string)));
            if (cr.Errors.HasErrors)
            {
                foreach (CompilerError err in cr.Errors)
                {
                    if (!err.IsWarning)
                        DlgProgressLog.AddError(string.Format(" - ERROR ({0}{1}, {2}, {3}): {4} - {5}",
                            htSourceFile[err.FileName.ToLower()], htSourceFile["E" + err.FileName.ToLower()],
                            err.Line, err.Column, err.ErrorNumber, err.ErrorText));
                }

                Directory.Delete(cpParam.TempFiles.BasePath, true);
                return false;
            }
            else
            {
                foreach (CompilerError err in cr.Errors)
                {
                    if (htSourceFile.ContainsKey(err.FileName.ToLower()))
                        DlgProgressLog.AddError(string.Format(" - Warning ({0}, {1}, {2}): {3} - {4}",
                            htSourceFile[err.FileName.ToLower()],
                            err.Line, err.Column, err.ErrorNumber, err.ErrorText));
                }

                byte[] assembly = File.ReadAllBytes(cr.PathToAssembly);
                File.Delete(cr.PathToAssembly);

                // qryXClass["Assembly"] = assembly;
                qryXClass["Assembly"] = AssemblyLoader.GZipCompress(assembly);
                qryXClass.Post();

                Assembly asm = Assembly.Load(assembly, File.ReadAllBytes(cr.PathToAssembly.Replace(".dll", ".pdb")));
                File.Delete(cr.PathToAssembly.Replace(".dll", ".pdb"));

                AssemblyLoader.UpdateAssembly(asm.GetType((string)qryXClassReference["FullName"]));

                if (System.Diagnostics.Debugger.IsAttached)
                {
                    PendingChanges.AddTempDirectory(qryXClass["ClassName"] as string, cpParam.TempFiles.BasePath);
                }
                else
                {
                    Directory.Delete(cpParam.TempFiles.BasePath, true);
                }
                return true;
            }
        }

        public Assembly Build()
        {
            asmBuild = null;

            DlgProgressLog.Show(
                KissMsg.GetMLMessage("FrmDesigner", "Build", "Fortschritt: Build"),
                new ProgressEventHandler(StartBuild),
                null,
                Session.MainForm);

            return asmBuild;
        }

        public Assembly Build(bool buildReference)
        {
            try
            {
                loader.Save();

                #region Resource

                MyResourceService rs = (MyResourceService)surface.GetService(typeof(IResourceService));
                string resFileName = System.IO.Path.GetTempFileName();
                if (rs.SaveToFile(resFileName))
                {
                    using (Stream sr = File.OpenRead(resFileName))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            AssemblyLoader.StreamCopy(sr, ms);
                            qryXClass["Resource"] = ms.ToArray();
                            ms.Close();
                        }
                        sr.Close();
                    }

                    System.IO.File.Delete(resFileName);
                }
                else
                    qryXClass["Resource"] = null;

                #endregion

                if (!Build(this.qryXClass)) return null;

                if (Session.User.UserID.Equals(qryXClass["CheckOut_UserID"]))
                {
                    qryXClass["Branch"] = Session.Connection.Database;
                    qryXClass["BuildNr"] = (int)qryXClass["BuildNr"] + 1;
                    qryXClass.Post();
                }

                if (buildReference)
                {
                    SqlQuery qryClassReference = DBUtil.OpenSQL(string.Format(SelectClassReference, @"--SQLCHECK_IGNORE--
                        INSERT INTO @XClass (ClassName)
                          SELECT REF.ClassName
                          FROM XClassReference     REF
                            INNER JOIN XClass      CLS ON CLS.ClassName = REF.ClassName AND CLS.Designer > 0
                          WHERE REF.ClassName_Ref = {0}"),
                        this.qryXClass["ClassName"]);

                    qryClassReference.TableName = "XClass";
                    qryClassReference.CanUpdate = qryXClass.CanUpdate;

                    while (qryClassReference.Count > 0)
                    {
                        Build(qryClassReference);
                        if (!qryClassReference.Next()) break;
                    }
                }

                Type type = AssemblyLoader.GetType((string)qryXClass["ClassName"]);
                if (type != null) return type.Assembly;
            }
            catch (CancelledByUserException)
            {
                throw;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
            return null;
        }

        internal bool IsSystemComponent(string componentName)
        {
            DataRow[] rows = this.qryXClassControl.DataTable.Select(string.Format("ControlName = '{0}'", componentName));
            if (rows.Length == 0) rows = this.qryXClassComponent.DataTable.Select(string.Format("ComponentName = '{0}'", componentName));
            return rows.Length == 1 && rows[0]["System"].Equals(true);
        }

        internal void ShowPreview()
        {
            Assembly asm = this.Build();
            if (asm == null) return;
            System.Type type = asm.GetType(string.Format("{0}.{1}", this.qryXClass["NameSpace"], this.qryXClass["ClassName"]));

            Gui.AssemblyLoader.UpdateAssembly(type);

            ConstructorInfo ci = type.GetConstructor(new System.Type[] { });
            if (ci == null)
            {
                KissMsg.ShowError("CtlDesignerLayout", "NoDefaultConstructorFound", "Kein Default-Konstruktor für Typ {0} gefunden!", null, null, 0, 0, type.FullName);
                return;
            }
            try
            {
                object instance = ci.Invoke(new object[] { });
                if (instance is KissUserControl)
                {
                    KiSS4.Common.DlgKissUserControl dlg = new KiSS4.Common.DlgKissUserControl("Vorschau", (KissUserControl)instance);
                    dlg.FormBorderStyle = FormBorderStyle.Sizable;  // allow resizing of this dialog
                    dlg.Show();
                }
                else if (instance is KissDialog)
                {
                    ((KissDialog)instance).ShowDialog(this);
                }
                else if (instance is KissChildForm)
                {
                    KissChildForm frm = (KissChildForm)instance;
                    frm.MdiParent = GetKissMainForm();
                    frm.Show();
                }
                else if (instance is KissForm)
                {
                    ((KissForm)instance).Show();
                }
            }
            catch (TargetInvocationException ex)
            {
                KissMsg.ShowError("CtlDesignerLayout", "ConstructorInvocationFailed", "Es konnte kein Objekt vom Typ {0} erstellt werden!", ex.Message, ex, 0, 0, type.FullName);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlDesignerLayout", "ConstructorInvocationFailedCommon", "Fehler beim Erstellen eines Objekts vom Typ {0}!", ex.Message, ex, 0, 0, type.FullName);
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            if (loader != null) loader.Dispose();
            if (surface != null && surface.IsLoaded) try { surface.Dispose(); }
                catch { }     // there was an error when disposing surface...
            if (hostingServiceContainer != null) try { hostingServiceContainer.Dispose(); }
                catch { }

            Application.RemoveMessageFilter(filter);
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlDesignerLayout));
            this.panMiddle = new System.Windows.Forms.Panel();
            this.panDesign = new System.Windows.Forms.Panel();
            this.tbrDesign = new System.Windows.Forms.ToolBar();
            this.tbnAlignToGrid = new System.Windows.Forms.ToolBarButton();
            this.tbs0 = new System.Windows.Forms.ToolBarButton();
            this.tbnAlignLefts = new System.Windows.Forms.ToolBarButton();
            this.tbnAlignCenters = new System.Windows.Forms.ToolBarButton();
            this.tbnAlignRights = new System.Windows.Forms.ToolBarButton();
            this.tbs1 = new System.Windows.Forms.ToolBarButton();
            this.tbnAlignTops = new System.Windows.Forms.ToolBarButton();
            this.tbnAlignMiddles = new System.Windows.Forms.ToolBarButton();
            this.tbnAlignBottoms = new System.Windows.Forms.ToolBarButton();
            this.tbs2 = new System.Windows.Forms.ToolBarButton();
            this.tbnMakeSameWidth = new System.Windows.Forms.ToolBarButton();
            this.tbnMakeSameHeight = new System.Windows.Forms.ToolBarButton();
            this.tbnMakeSameSize = new System.Windows.Forms.ToolBarButton();
            this.tbs3 = new System.Windows.Forms.ToolBarButton();
            this.tbnMakeHorizontalSpacingEquals = new System.Windows.Forms.ToolBarButton();
            this.tbnIncreaseHorizontalSpacing = new System.Windows.Forms.ToolBarButton();
            this.tbnDecreaseHorizontalSpacing = new System.Windows.Forms.ToolBarButton();
            this.tbnRemoveHorizontalSpacing = new System.Windows.Forms.ToolBarButton();
            this.tbs4 = new System.Windows.Forms.ToolBarButton();
            this.tbnMakeVerticalSpacingEquals = new System.Windows.Forms.ToolBarButton();
            this.tbnIncreaseVerticalSpacing = new System.Windows.Forms.ToolBarButton();
            this.tbnDecreaseVerticalSpacing = new System.Windows.Forms.ToolBarButton();
            this.tbnRemoveVerticalSpacing = new System.Windows.Forms.ToolBarButton();
            this.tbs5 = new System.Windows.Forms.ToolBarButton();
            this.tbnCenterHorizontally = new System.Windows.Forms.ToolBarButton();
            this.tbnCenterVertically = new System.Windows.Forms.ToolBarButton();
            this.tbs6 = new System.Windows.Forms.ToolBarButton();
            this.tbnBringToFront = new System.Windows.Forms.ToolBarButton();
            this.tbnSendToBack = new System.Windows.Forms.ToolBarButton();
            this.tbs7 = new System.Windows.Forms.ToolBarButton();
            this.tbnTabOrder = new System.Windows.Forms.ToolBarButton();
            this.tbs8 = new System.Windows.Forms.ToolBarButton();
            this.tbnBuild = new System.Windows.Forms.ToolBarButton();
            this.imgToolbar = new System.Windows.Forms.ImageList(this.components);
            this.panRight = new System.Windows.Forms.Panel();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.cboElements = new System.Windows.Forms.ComboBox();
            this.qryXClass = new KiSS4.DB.SqlQuery(this.components);
            this.qryXClassControl = new KiSS4.DB.SqlQuery(this.components);
            this.qryXClassComponent = new KiSS4.DB.SqlQuery(this.components);
            this.splitRight = new KiSS4.Gui.KissSplitterCollapsible();
            this.ttpDesignerLayout = new System.Windows.Forms.ToolTip(this.components);
            this.cntMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.splitLeft = new KiSS4.Gui.KissSplitterCollapsible();
            this.toolbox = new KiSS4.DesignerHost.ToolboxPane();
            this.mnuDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.panMiddle.SuspendLayout();
            this.panRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryXClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXClassControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXClassComponent)).BeginInit();
            this.cntMenu.SuspendLayout();
            this.SuspendLayout();
            //
            // panMiddle
            //
            this.panMiddle.Controls.Add(this.panDesign);
            this.panMiddle.Controls.Add(this.tbrDesign);
            this.panMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMiddle.Location = new System.Drawing.Point(200, 0);
            this.panMiddle.Name = "panMiddle";
            this.panMiddle.Size = new System.Drawing.Size(618, 606);
            this.panMiddle.TabIndex = 2;
            //
            // panDesign
            //
            this.panDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDesign.Location = new System.Drawing.Point(0, 28);
            this.panDesign.Name = "panDesign";
            this.panDesign.Size = new System.Drawing.Size(618, 578);
            this.panDesign.TabIndex = 1;
            //
            // tbrDesign
            //
            this.tbrDesign.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbnAlignToGrid,
            this.tbs0,
            this.tbnAlignLefts,
            this.tbnAlignCenters,
            this.tbnAlignRights,
            this.tbs1,
            this.tbnAlignTops,
            this.tbnAlignMiddles,
            this.tbnAlignBottoms,
            this.tbs2,
            this.tbnMakeSameWidth,
            this.tbnMakeSameHeight,
            this.tbnMakeSameSize,
            this.tbs3,
            this.tbnMakeHorizontalSpacingEquals,
            this.tbnIncreaseHorizontalSpacing,
            this.tbnDecreaseHorizontalSpacing,
            this.tbnRemoveHorizontalSpacing,
            this.tbs4,
            this.tbnMakeVerticalSpacingEquals,
            this.tbnIncreaseVerticalSpacing,
            this.tbnDecreaseVerticalSpacing,
            this.tbnRemoveVerticalSpacing,
            this.tbs5,
            this.tbnCenterHorizontally,
            this.tbnCenterVertically,
            this.tbs6,
            this.tbnBringToFront,
            this.tbnSendToBack,
            this.tbs7,
            this.tbnTabOrder,
            this.tbs8,
            this.tbnBuild});
            this.tbrDesign.DropDownArrows = true;
            this.tbrDesign.ImageList = this.imgToolbar;
            this.tbrDesign.Location = new System.Drawing.Point(0, 0);
            this.tbrDesign.Name = "tbrDesign";
            this.tbrDesign.ShowToolTips = true;
            this.tbrDesign.Size = new System.Drawing.Size(618, 28);
            this.tbrDesign.TabIndex = 0;
            this.tbrDesign.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbrDesign_ButtonClick);
            //
            // tbnAlignToGrid
            //
            this.tbnAlignToGrid.ImageIndex = 0;
            this.tbnAlignToGrid.Name = "tbnAlignToGrid";
            this.tbnAlignToGrid.ToolTipText = "Align to Grid";
            //
            // tbs0
            //
            this.tbs0.Name = "tbs0";
            this.tbs0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnAlignLefts
            //
            this.tbnAlignLefts.ImageIndex = 1;
            this.tbnAlignLefts.Name = "tbnAlignLefts";
            this.tbnAlignLefts.ToolTipText = "Align Lefts";
            //
            // tbnAlignCenters
            //
            this.tbnAlignCenters.ImageIndex = 2;
            this.tbnAlignCenters.Name = "tbnAlignCenters";
            this.tbnAlignCenters.ToolTipText = "Align Centers";
            //
            // tbnAlignRights
            //
            this.tbnAlignRights.ImageIndex = 3;
            this.tbnAlignRights.Name = "tbnAlignRights";
            this.tbnAlignRights.ToolTipText = "Align Rights";
            //
            // tbs1
            //
            this.tbs1.Name = "tbs1";
            this.tbs1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnAlignTops
            //
            this.tbnAlignTops.ImageIndex = 4;
            this.tbnAlignTops.Name = "tbnAlignTops";
            this.tbnAlignTops.ToolTipText = "Align Tops";
            //
            // tbnAlignMiddles
            //
            this.tbnAlignMiddles.ImageIndex = 5;
            this.tbnAlignMiddles.Name = "tbnAlignMiddles";
            this.tbnAlignMiddles.ToolTipText = "Align Middles";
            //
            // tbnAlignBottoms
            //
            this.tbnAlignBottoms.ImageIndex = 6;
            this.tbnAlignBottoms.Name = "tbnAlignBottoms";
            this.tbnAlignBottoms.ToolTipText = "Align Bottoms";
            //
            // tbs2
            //
            this.tbs2.Name = "tbs2";
            this.tbs2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnMakeSameWidth
            //
            this.tbnMakeSameWidth.ImageIndex = 7;
            this.tbnMakeSameWidth.Name = "tbnMakeSameWidth";
            this.tbnMakeSameWidth.ToolTipText = "Make same Width";
            //
            // tbnMakeSameHeight
            //
            this.tbnMakeSameHeight.ImageIndex = 8;
            this.tbnMakeSameHeight.Name = "tbnMakeSameHeight";
            this.tbnMakeSameHeight.ToolTipText = "Make same Height";
            //
            // tbnMakeSameSize
            //
            this.tbnMakeSameSize.ImageIndex = 9;
            this.tbnMakeSameSize.Name = "tbnMakeSameSize";
            this.tbnMakeSameSize.ToolTipText = "Make same Size";
            //
            // tbs3
            //
            this.tbs3.Name = "tbs3";
            this.tbs3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnMakeHorizontalSpacingEquals
            //
            this.tbnMakeHorizontalSpacingEquals.ImageIndex = 10;
            this.tbnMakeHorizontalSpacingEquals.Name = "tbnMakeHorizontalSpacingEquals";
            this.tbnMakeHorizontalSpacingEquals.ToolTipText = "Make Horizontal Spacing Equals";
            //
            // tbnIncreaseHorizontalSpacing
            //
            this.tbnIncreaseHorizontalSpacing.ImageIndex = 11;
            this.tbnIncreaseHorizontalSpacing.Name = "tbnIncreaseHorizontalSpacing";
            this.tbnIncreaseHorizontalSpacing.ToolTipText = "Increase Horizontal Spacing";
            //
            // tbnDecreaseHorizontalSpacing
            //
            this.tbnDecreaseHorizontalSpacing.ImageIndex = 12;
            this.tbnDecreaseHorizontalSpacing.Name = "tbnDecreaseHorizontalSpacing";
            this.tbnDecreaseHorizontalSpacing.ToolTipText = "Decrease Horizontal Spacing";
            //
            // tbnRemoveHorizontalSpacing
            //
            this.tbnRemoveHorizontalSpacing.ImageIndex = 13;
            this.tbnRemoveHorizontalSpacing.Name = "tbnRemoveHorizontalSpacing";
            this.tbnRemoveHorizontalSpacing.ToolTipText = "Remove Horizontal Spacing";
            //
            // tbs4
            //
            this.tbs4.Name = "tbs4";
            this.tbs4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnMakeVerticalSpacingEquals
            //
            this.tbnMakeVerticalSpacingEquals.ImageIndex = 14;
            this.tbnMakeVerticalSpacingEquals.Name = "tbnMakeVerticalSpacingEquals";
            this.tbnMakeVerticalSpacingEquals.ToolTipText = "Make Vertical Spacing Equals";
            //
            // tbnIncreaseVerticalSpacing
            //
            this.tbnIncreaseVerticalSpacing.ImageIndex = 15;
            this.tbnIncreaseVerticalSpacing.Name = "tbnIncreaseVerticalSpacing";
            this.tbnIncreaseVerticalSpacing.ToolTipText = "Increase Vertical Spacing";
            //
            // tbnDecreaseVerticalSpacing
            //
            this.tbnDecreaseVerticalSpacing.ImageIndex = 16;
            this.tbnDecreaseVerticalSpacing.Name = "tbnDecreaseVerticalSpacing";
            this.tbnDecreaseVerticalSpacing.ToolTipText = "Decrease Vertical Spacing";
            //
            // tbnRemoveVerticalSpacing
            //
            this.tbnRemoveVerticalSpacing.ImageIndex = 17;
            this.tbnRemoveVerticalSpacing.Name = "tbnRemoveVerticalSpacing";
            this.tbnRemoveVerticalSpacing.ToolTipText = "Remove Vertical Spacing";
            //
            // tbs5
            //
            this.tbs5.Name = "tbs5";
            this.tbs5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnCenterHorizontally
            //
            this.tbnCenterHorizontally.ImageIndex = 18;
            this.tbnCenterHorizontally.Name = "tbnCenterHorizontally";
            this.tbnCenterHorizontally.ToolTipText = "Center Horizontally";
            //
            // tbnCenterVertically
            //
            this.tbnCenterVertically.ImageIndex = 19;
            this.tbnCenterVertically.Name = "tbnCenterVertically";
            this.tbnCenterVertically.ToolTipText = "Center Vertically";
            //
            // tbs6
            //
            this.tbs6.Name = "tbs6";
            this.tbs6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnBringToFront
            //
            this.tbnBringToFront.ImageIndex = 20;
            this.tbnBringToFront.Name = "tbnBringToFront";
            this.tbnBringToFront.ToolTipText = "Bring to Front";
            //
            // tbnSendToBack
            //
            this.tbnSendToBack.ImageIndex = 21;
            this.tbnSendToBack.Name = "tbnSendToBack";
            this.tbnSendToBack.ToolTipText = "Send to Back";
            //
            // tbs7
            //
            this.tbs7.Name = "tbs7";
            this.tbs7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnTabOrder
            //
            this.tbnTabOrder.ImageIndex = 22;
            this.tbnTabOrder.Name = "tbnTabOrder";
            this.tbnTabOrder.ToolTipText = "Tab Order";
            //
            // tbs8
            //
            this.tbs8.Name = "tbs8";
            this.tbs8.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            //
            // tbnBuild
            //
            this.tbnBuild.ImageIndex = 23;
            this.tbnBuild.Name = "tbnBuild";
            this.tbnBuild.ToolTipText = "Build / Preview";
            //
            // imgToolbar
            //
            this.imgToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgToolbar.ImageStream")));
            this.imgToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgToolbar.Images.SetKeyName(0, "");
            this.imgToolbar.Images.SetKeyName(1, "");
            this.imgToolbar.Images.SetKeyName(2, "");
            this.imgToolbar.Images.SetKeyName(3, "");
            this.imgToolbar.Images.SetKeyName(4, "");
            this.imgToolbar.Images.SetKeyName(5, "");
            this.imgToolbar.Images.SetKeyName(6, "");
            this.imgToolbar.Images.SetKeyName(7, "");
            this.imgToolbar.Images.SetKeyName(8, "");
            this.imgToolbar.Images.SetKeyName(9, "");
            this.imgToolbar.Images.SetKeyName(10, "");
            this.imgToolbar.Images.SetKeyName(11, "");
            this.imgToolbar.Images.SetKeyName(12, "");
            this.imgToolbar.Images.SetKeyName(13, "");
            this.imgToolbar.Images.SetKeyName(14, "");
            this.imgToolbar.Images.SetKeyName(15, "");
            this.imgToolbar.Images.SetKeyName(16, "");
            this.imgToolbar.Images.SetKeyName(17, "");
            this.imgToolbar.Images.SetKeyName(18, "");
            this.imgToolbar.Images.SetKeyName(19, "");
            this.imgToolbar.Images.SetKeyName(20, "");
            this.imgToolbar.Images.SetKeyName(21, "");
            this.imgToolbar.Images.SetKeyName(22, "");
            this.imgToolbar.Images.SetKeyName(23, "");
            //
            // panRight
            //
            this.panRight.Controls.Add(this.propertyGrid);
            this.panRight.Controls.Add(this.cboElements);
            this.panRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panRight.Location = new System.Drawing.Point(826, 0);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(200, 606);
            this.panRight.TabIndex = 5;
            //
            // propertyGrid
            //
            this.propertyGrid.CommandsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.propertyGrid.ContextMenuStrip = this.cntMenu;
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid.Location = new System.Drawing.Point(0, 21);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid.Size = new System.Drawing.Size(200, 585);
            this.propertyGrid.TabIndex = 1;
            this.propertyGrid.SelectedObjectsChanged += new System.EventHandler(this.propertyGrid_SelectedObjectsChanged);
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            //
            // cboElements
            //
            this.cboElements.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboElements.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboElements.DropDownHeight = 306;
            this.cboElements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboElements.IntegralHeight = false;
            this.cboElements.Location = new System.Drawing.Point(0, 0);
            this.cboElements.Name = "cboElements";
            this.cboElements.Size = new System.Drawing.Size(200, 21);
            this.cboElements.Sorted = true;
            this.cboElements.TabIndex = 0;
            this.cboElements.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cboElements_DrawItem);
            this.cboElements.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.cboElements_MeasureItem);
            this.cboElements.SelectedIndexChanged += new System.EventHandler(this.cboElements_SelectedIndexChanged);
            //
            // qryXClass
            //
            this.qryXClass.HostControl = this;
            this.qryXClass.SelectStatement = "SELECT * FROM XClass";
            this.qryXClass.TableName = "XClass";
            //
            // qryXClassControl
            //
            this.qryXClassControl.HostControl = this;
            this.qryXClassControl.SelectStatement = "SELECT * FROM XClassControl WHERE ClassName = {0}";
            this.qryXClassControl.TableName = "XClassControl";
            //
            // qryXClassComponent
            //
            this.qryXClassComponent.HostControl = this;
            this.qryXClassComponent.SelectStatement = "SELECT * FROM XClassComponent WHERE ClassName = {0}";
            this.qryXClassComponent.TableName = "XClassComponent";
            //
            // splitRight
            //
            this.splitRight.AnimationDelay = 20;
            this.splitRight.AnimationStep = 20;
            this.splitRight.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitRight.ControlToHide = this.panRight;
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitRight.ExpandParentForm = false;
            this.splitRight.Location = new System.Drawing.Point(818, 0);
            this.splitRight.Name = "splitRight";
            this.splitRight.TabIndex = 0;
            this.splitRight.TabStop = false;
            this.splitRight.UseAnimations = false;
            this.splitRight.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // cntMenu
            //
            this.cntMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReset,
            this.mnuDescription});
            this.cntMenu.Name = "cntMenu";
            this.cntMenu.Size = new System.Drawing.Size(153, 70);
            this.cntMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cntMenu_Opening);
            //
            // mnuReset
            //
            this.mnuReset.Name = "mnuReset";
            this.mnuReset.Size = new System.Drawing.Size(152, 22);
            this.mnuReset.Text = "Reset";
            this.mnuReset.Click += new System.EventHandler(this.mnuReset_Click);
            //
            // splitLeft
            //
            this.splitLeft.AnimationDelay = 20;
            this.splitLeft.AnimationStep = 20;
            this.splitLeft.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitLeft.ControlToHide = this.toolbox;
            this.splitLeft.ExpandParentForm = false;
            this.splitLeft.Location = new System.Drawing.Point(192, 0);
            this.splitLeft.Name = "splitLeft";
            this.splitLeft.TabIndex = 0;
            this.splitLeft.TabStop = false;
            this.splitLeft.UseAnimations = false;
            this.splitLeft.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // toolbox
            //
            this.toolbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolbox.Location = new System.Drawing.Point(0, 0);
            this.toolbox.Name = "toolbox";
            this.toolbox.Size = new System.Drawing.Size(192, 606);
            this.toolbox.TabIndex = 0;
            //
            // mnuDescription
            //
            this.mnuDescription.Name = "mnuDescription";
            this.mnuDescription.Size = new System.Drawing.Size(152, 22);
            this.mnuDescription.Text = "Description";
            this.mnuDescription.Click += new System.EventHandler(this.mnuDescription_Click);
            //
            // CtlDesignerLayout
            //
            this.Controls.Add(this.panMiddle);
            this.Controls.Add(this.splitRight);
            this.Controls.Add(this.splitLeft);
            this.Controls.Add(this.toolbox);
            this.Controls.Add(this.panRight);
            this.Name = "CtlDesignerLayout";
            this.Size = new System.Drawing.Size(1026, 606);
            this.SaveData += new System.EventHandler(this.CtlDesignerLayout_SaveData);
            this.MoveNext += new System.EventHandler(this.CtlDesignerLayout_MoveNext);
            this.UndoDataChanges += new System.EventHandler(this.CtlDesignerLayout_UndoDataChanges);
            this.DeleteData += new System.EventHandler(this.CtlDesignerLayout_DeleteData);
            this.MovePrevious += new System.EventHandler(this.CtlDesignerLayout_MovePrevious);
            this.panMiddle.ResumeLayout(false);
            this.panMiddle.PerformLayout();
            this.panRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryXClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXClassControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXClassComponent)).EndInit();
            this.cntMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private void cntMenu_Opening(object sender, CancelEventArgs e)
        {
            if (propertyGrid.SelectedObjects.Length != 1) return;

            GridItem item = propertyGrid.SelectedGridItem;
            mnuReset.Enabled = item.PropertyDescriptor.CanResetValue(propertyGrid.SelectedObject);

            mnuDescription.Checked = propertyGrid.HelpVisible;
        }

        /// This method is called whenever we create a new designer or
        /// load one from existing XML.
        private void CreateDesigner(DesignerLoader loader)
        {
            // Our loader will handle loading the file (or creating a blank one).
            surface = new MyDesignSurface(hostingServiceContainer);
            propertyGrid.Enabled = this.qryXClass.CanUpdate;

            // The limited events tab functionality we have requires a special kind of
            // property grid site.
            //
            propertyGrid.Site = new PropertyGridSite((IServiceProvider)surface, this);
            propertyGrid.PropertyTabs.AddTabType(typeof(EventsTab));

            surface.BeginLoad(loader);
            this.loader = (MyCodeDomDesignerLoader)loader;

            if (this.loader.errors.Count > 0)
            {
                KiSS4.Gui.KissMemoEdit memo = new KiSS4.Gui.KissMemoEdit();

                foreach (object err in this.loader.errors)
                    memo.Text += string.Format("{0}{1}{1}----------------------------------------------------------{1}", err, Environment.NewLine);

                memo.Dock = DockStyle.Fill;
                memo.ProportionalFont = false;
                memo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
                memo.Properties.ReadOnly = true;

                panDesign.Controls.Add(memo);

                return;
            }

            // The toolbox needs access to the IToolboxService and the designers.
            toolbox.DesignSurface = surface;

            // Initialize our document window.
            Control view = (Control)surface.View;
            if (this.qryXClass.CanUpdate)
                view.BackColor = Color.White;
            else
                view.BackColor = Gui.GuiConfig.EditColorReadOnly;
            view.Dock = DockStyle.Fill;
            view.Visible = true;
            panDesign.Controls.Add(view);

            // This IMessageFilter is used to intercept and decipher keyboard presses
            // that might be instructions for our designer. We have to do it this way
            // since we can't have our designer raise KeyPress events.
            //
            filter = new KeystrokeMessageFilter(surface);
            Application.AddMessageFilter(filter);

            IComponentChangeService ccs = (IComponentChangeService)surface.GetService(typeof(IComponentChangeService));
            ccs.ComponentAdded += new ComponentEventHandler(OnComponentAddedRemoved);
            ccs.ComponentRemoved += new ComponentEventHandler(OnComponentAddedRemoved);
            ccs.ComponentRename += new ComponentRenameEventHandler(OnComponentRename);

            ISelectionService selectionService = (ISelectionService)surface.GetService(typeof(ISelectionService));
            selectionService.SelectionChanged += new EventHandler(OnSelectionChanged);
            // Enable / disable the toolbox items
            OnSelectionChanged(null, null);

            SetSelectableObjects(surface.ComponentContainer.Components);
            toolbox.FillToolbox((string)this.qryXClass["ClassName"]);
            RefreshToolBox();
        }

        private void CtlDesignerLayout_DeleteData(object sender, System.EventArgs e)
        {
            IServiceContainer sc = surface as IServiceContainer;
            ISelectionService ss = sc.GetService(typeof(ISelectionService)) as ISelectionService;

            foreach (Component cmp in ss.GetSelectedComponents())
                if (this.IsSystemComponent(cmp.Site.Name)) return;

            IMenuCommandService mcs = sc.GetService(typeof(IMenuCommandService)) as IMenuCommandService;
            mcs.GlobalInvoke(StandardCommands.Delete);
        }

        private void CtlDesignerLayout_MoveNext(object sender, System.EventArgs e)
        {
            IServiceContainer sc = surface as IServiceContainer;
            IMenuCommandService mcs = sc.GetService(typeof(IMenuCommandService)) as IMenuCommandService;

            mcs.GlobalInvoke(MenuCommands.KeyNudgeDown);
        }

        private void CtlDesignerLayout_MovePrevious(object sender, System.EventArgs e)
        {
            IServiceContainer sc = surface as IServiceContainer;
            IMenuCommandService mcs = sc.GetService(typeof(IMenuCommandService)) as IMenuCommandService;

            mcs.GlobalInvoke(MenuCommands.KeyNudgeUp);
        }

        private void CtlDesignerLayout_SaveData(object sender, System.EventArgs e)
        {
            loader.Save();
        }

        private void CtlDesignerLayout_UndoDataChanges(object sender, System.EventArgs e)
        {
            IServiceContainer sc = surface as IServiceContainer;
            IMenuCommandService mcs = sc.GetService(typeof(IMenuCommandService)) as IMenuCommandService;

            mcs.GlobalInvoke(MenuCommands.Undo);
        }

        private void mnuDescription_Click(object sender, EventArgs e)
        {
            propertyGrid.HelpVisible = !propertyGrid.HelpVisible;

            mnuDescription.Checked = propertyGrid.HelpVisible;
        }

        private void mnuReset_Click(object sender, EventArgs e)
        {
            GridItem item = propertyGrid.SelectedGridItem;
            item.PropertyDescriptor.ResetValue(propertyGrid.SelectedObject);
            propertyGrid.Refresh();
        }

        private void StartBuild()
        {
            try
            {
                asmBuild = Build(true);

                DlgProgressLog.EndProgress();
                if (DlgProgressLog.HasErrors)
                    DlgProgressLog.ShowTopMost();
                else
                    DlgProgressLog.CloseDialog();
            }
            catch (CancelledByUserException)
            {
                try
                {
                    DlgProgressLog.AddLine(KissMsg.GetMLMessage("CtlDesignerLayout", "BuildAbgebrochen", "Build abgebrochen durch Benutzer/-in"));
                }
                catch { };
            }
        }

        private void tabControl_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // If the tab is changing, that means we'd better let the loader know it needs
            // to flush changes that have been made and update the code windows.
            loader.Flush();
        }

        #region cboElements

        private bool inUpdate = false;

        private void cboElements_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= cboElements.Items.Count)
            {
                return;
            }
            Graphics g = e.Graphics;
            Brush stringColor = SystemBrushes.ControlText;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                {
                    g.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                    stringColor = SystemBrushes.HighlightText;
                }
                else
                {
                    g.FillRectangle(SystemBrushes.Window, e.Bounds);
                }
            }
            else
            {
                g.FillRectangle(SystemBrushes.Window, e.Bounds);
            }

            object item = cboElements.Items[e.Index];
            int xPos = e.Bounds.X;

            if (item is IComponent)
            {
                ISite site = ((IComponent)item).Site;
                if (site != null)
                {
                    string name = site.Name;
                    using (Font f = new Font(cboElements.Font, FontStyle.Bold))
                    {
                        g.DrawString(name, f, stringColor, xPos, e.Bounds.Y);
                        xPos += (int)g.MeasureString(name + "-", f).Width;
                    }
                }
            }

            string typeString = item.GetType().ToString();
            g.DrawString(typeString, cboElements.Font, stringColor, xPos, e.Bounds.Y);
        }

        private void cboElements_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= cboElements.Items.Count)
            {
                e.ItemHeight = cboElements.Font.Height;
                return;
            }
            object item = cboElements.Items[e.Index];
            SizeF size = e.Graphics.MeasureString(item.GetType().ToString(), cboElements.Font);

            e.ItemHeight = (int)size.Height;
            e.ItemWidth = (int)size.Width;

            if (item is IComponent)
            {
                ISite site = ((IComponent)item).Site;
                if (site != null)
                {
                    string name = site.Name;
                    using (Font f = new Font(cboElements.Font, FontStyle.Bold))
                    {
                        e.ItemWidth += (int)e.Graphics.MeasureString(name + "-", f).Width;
                    }
                }
            }
        }

        private void cboElements_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!inUpdate)
            {
                if (surface != null)
                {
                    ISelectionService selectionService = (ISelectionService)surface.GetService(typeof(ISelectionService));
                    if (cboElements.SelectedIndex >= 0)
                    {
                        selectionService.SetSelectedComponents(new object[] { cboElements.Items[cboElements.SelectedIndex] });
                    }
                }
            }
        }

        private void OnComponentAddedRemoved(object sender, System.ComponentModel.Design.ComponentEventArgs e)
        {
            //update combo for items
            SetSelectableObjects(surface.ComponentContainer.Components);

            if (e.Component is SqlQuery)
                RefreshToolBox();
        }

        private void OnComponentRename(object sender, ComponentRenameEventArgs e)
        {
            //update combo for items
            SetSelectableObjects(surface.ComponentContainer.Components);
        }

        private void propertyGrid_SelectedObjectsChanged(object sender, System.EventArgs e)
        {
            SelectedObjectsChanged();
        }

        private void SelectedObjectsChanged()
        {
            if (propertyGrid.SelectedObjects != null && propertyGrid.SelectedObjects.Length == 1)
            {
                for (int i = 0; i < cboElements.Items.Count; ++i)
                {
                    if (propertyGrid.SelectedObject == cboElements.Items[i])
                    {
                        cboElements.SelectedIndex = i;
                        ttpDesignerLayout.SetToolTip(cboElements, cboElements.Text);
                        break;
                    }
                }
            }
            else
            {
                cboElements.SelectedIndex = -1;
                ttpDesignerLayout.SetToolTip(cboElements, "");
            }
        }

        private void SetDesignableObject(object obj)
        {
            inUpdate = true;
            propertyGrid.SelectedObject = obj;
            SelectedObjectsChanged();
            inUpdate = false;
        }

        private void SetSelectableObjects(ICollection coll)
        {
            inUpdate = true;
            try
            {
                cboElements.Items.Clear();
                cboElements.BeginUpdate();

                if (coll != null)
                {
                    foreach (object obj in coll)
                    {
                        cboElements.Items.Add(obj);
                    }
                }

                // reset flags and update selection
                cboElements.EndUpdate();
                SelectedObjectsChanged();
            }
            finally
            {
                // reset flags if not yet done
                cboElements.EndUpdate();
                inUpdate = false;
            }
        }

        #endregion

        #region ToolBox

        private void propertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "TableName")
                RefreshToolBox();
        }

        private void RefreshToolBox()
        {
            ListBox lstDataField = toolbox.lstDataField;
            lstDataField.Items.Clear();
            lstDataField.Items.Add(toolbox.pointer);

            ToolboxPane.AddToolboxItem(lstDataField, typeof(KiSS4.DB.SqlQuery));

            foreach (Component cmp in surface.ComponentContainer.Components)
            {
                SqlQuery qry = cmp as SqlQuery;

                if (qry != null && !DBUtil.IsEmpty(qry.TableName))
                {
                    lstDataField.Items.Add(new MyToolboxItem(qry));

                    SqlQuery qryColumns = DBUtil.OpenSQL(@"
						SELECT COL.*, UserText = IsNull(DisplayText, ColumnName), TypeName = FLD.Value3
						FROM XTableColumn    COL
						  LEFT JOIN XLOVCode  FLD ON FLD.LOVName = 'FieldCode' AND FLD.Code = COL.FieldCode
						WHERE TableName = {0}", qry.TableName);

                    foreach (DataRow row in qryColumns.DataTable.Rows)
                        lstDataField.Items.Add(new MyToolboxItem(qry, row));
                }
            }
        }

        #endregion

        #region ToolBar

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (surface == null)
            {
                return;
            }

            ISelectionService ss = (ISelectionService)surface.GetService(typeof(ISelectionService));
            // we get a list of selected IComponents, now find out how many of these are Controls
            int selectedControls = 0;
            foreach (IComponent component in ss.GetSelectedComponents())
            {
                if (component != null && component is Control)
                {
                    selectedControls++;
                }
            }

            bool bNoControlSelected = selectedControls == 0;
            bool bOneOrMoreControlSelected = selectedControls > 0;
            bool bTwoOrMoreControlsSelected = selectedControls > 1;
            tbnAlignToGrid.Enabled = !bNoControlSelected;

            tbnAlignLefts.Enabled = bTwoOrMoreControlsSelected;
            tbnAlignCenters.Enabled = bTwoOrMoreControlsSelected;
            tbnAlignRights.Enabled = bTwoOrMoreControlsSelected;

            tbnAlignTops.Enabled = bTwoOrMoreControlsSelected;
            tbnAlignMiddles.Enabled = bTwoOrMoreControlsSelected;
            tbnAlignBottoms.Enabled = bTwoOrMoreControlsSelected;

            tbnMakeSameWidth.Enabled = bTwoOrMoreControlsSelected;
            tbnMakeSameHeight.Enabled = bTwoOrMoreControlsSelected;
            tbnMakeSameSize.Enabled = bTwoOrMoreControlsSelected;

            tbnMakeHorizontalSpacingEquals.Enabled = bTwoOrMoreControlsSelected;
            tbnIncreaseHorizontalSpacing.Enabled = bTwoOrMoreControlsSelected;
            tbnDecreaseHorizontalSpacing.Enabled = bTwoOrMoreControlsSelected;
            tbnRemoveHorizontalSpacing.Enabled = bTwoOrMoreControlsSelected;

            tbnMakeVerticalSpacingEquals.Enabled = bTwoOrMoreControlsSelected;
            tbnIncreaseVerticalSpacing.Enabled = bTwoOrMoreControlsSelected;
            tbnDecreaseVerticalSpacing.Enabled = bTwoOrMoreControlsSelected;
            tbnRemoveVerticalSpacing.Enabled = bTwoOrMoreControlsSelected;

            tbnCenterHorizontally.Enabled = bOneOrMoreControlSelected;
            tbnCenterVertically.Enabled = bOneOrMoreControlSelected;

            tbnBringToFront.Enabled = bOneOrMoreControlSelected;
            tbnSendToBack.Enabled = bOneOrMoreControlSelected;
        }

        private void tbrDesign_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            IServiceContainer sc = surface as IServiceContainer;
            IMenuCommandService mcs = sc.GetService(typeof(IMenuCommandService)) as IMenuCommandService;

            switch (e.Button.ImageIndex)
            {
                case 0: mcs.GlobalInvoke(StandardCommands.AlignToGrid); break;

                case 1: mcs.GlobalInvoke(StandardCommands.AlignLeft); break;
                case 2: mcs.GlobalInvoke(StandardCommands.AlignHorizontalCenters); break;
                case 3: mcs.GlobalInvoke(StandardCommands.AlignRight); break;

                case 4: mcs.GlobalInvoke(StandardCommands.AlignTop); break;
                case 5: mcs.GlobalInvoke(StandardCommands.AlignVerticalCenters); break;
                case 6: mcs.GlobalInvoke(StandardCommands.AlignBottom); break;

                case 7: mcs.GlobalInvoke(StandardCommands.SizeToControlWidth); break;
                case 8: mcs.GlobalInvoke(StandardCommands.SizeToControlHeight); break;
                case 9: mcs.GlobalInvoke(StandardCommands.SizeToControl); break;

                case 10: mcs.GlobalInvoke(StandardCommands.HorizSpaceMakeEqual); break;
                case 11: mcs.GlobalInvoke(StandardCommands.HorizSpaceIncrease); break;
                case 12: mcs.GlobalInvoke(StandardCommands.HorizSpaceDecrease); break;
                case 13: mcs.GlobalInvoke(StandardCommands.HorizSpaceConcatenate); break;

                case 14: mcs.GlobalInvoke(StandardCommands.VertSpaceMakeEqual); break;
                case 15: mcs.GlobalInvoke(StandardCommands.VertSpaceIncrease); break;
                case 16: mcs.GlobalInvoke(StandardCommands.VertSpaceDecrease); break;
                case 17: mcs.GlobalInvoke(StandardCommands.VertSpaceConcatenate); break;

                case 18: mcs.GlobalInvoke(StandardCommands.CenterVertically); break;
                case 19: mcs.GlobalInvoke(StandardCommands.CenterHorizontally); break;

                case 20: mcs.GlobalInvoke(StandardCommands.BringToFront); break;
                case 21: mcs.GlobalInvoke(StandardCommands.SendToBack); break;

                case 22:
                    mcs.GlobalInvoke(StandardCommands.TabOrder);
                    e.Button.Pushed = !e.Button.Pushed;
                    break;

                case 23: this.ShowPreview(); break;
            }
        }

        #endregion

        private class PendingChanges : KiSS4.Gui.IKissPersistentObject
        {
            private static Dictionary<string, string> dicClassName;

            private PendingChanges()
            {
            }

            bool IKissPersistentObject.ObjectDisposed
            {
                get { return true; }
            }

            string IKissPersistentObject.ObjectName
            {
                get { return ""; }
            }

            bool IKissPersistentObject.PendingChanges
            {
                get
                {
                    foreach (string directory in dicClassName.Values)
                    {
                        try
                        {
                            Directory.Delete(directory, true);
                        }
                        catch { }
                    }
                    dicClassName.Clear();

                    return false;
                }
            }

            public static void AddTempDirectory(string className, string directoryName)
            {
                if (dicClassName == null)
                {
                    dicClassName = new Dictionary<string, string>();
                    ((KissMainForm)Session.MainForm).PersistentObjects.Add(new PendingChanges());
                }
                else
                {
                    try
                    {
                        if (dicClassName.ContainsKey(className))
                            Directory.Delete(dicClassName[className], true);
                    }
                    catch { }
                }

                dicClassName[className] = directoryName;
            }
        }
    }
}