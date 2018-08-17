using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

using Microsoft.CSharp;

using KiSS4.DB;
using KiSS4.Gui;

using DevExpress.Utils;

namespace KiSS4.DesignerHost
{
    public class MyCodeDomDesignerLoader : CodeDomDesignerLoader
    {
        #region Fields

        #region Internal Constant/Read-Only Fields

        internal const string SQLqryXClassReference = @"
            DECLARE @XClass TABLE (ClassName varchar(255) COLLATE DATABASE_DEFAULT PRIMARY KEY)

            INSERT INTO @XClass (ClassName) VALUES ({0})

            WHILE @@RowCount > 0 BEGIN
              INSERT INTO @XClass
                SELECT DISTINCT REF.ClassName_Ref
                FROM XClassReference  REF
                  INNER JOIN @XClass  TMP ON TMP.ClassName = REF.ClassName
                  INNER JOIN XClass   CLS ON CLS.ClassName = REF.ClassName_Ref AND CLS.Designer > 0
                WHERE NOT EXISTS (SELECT * FROM @XClass WHERE ClassName = REF.ClassName_Ref)
            END

            SELECT SortKey = CASE WHEN CLS.ClassName = {0} THEN 0 ELSE 2 END,
              MOD.NameSpace, CLS.ClassName, FullName = MOD.NameSpace + IsNull('.' + CLS.NamespaceExtension, '') + '.' + CLS.ClassName,
              CLS.CodeGenerated, CLS.Resource
            FROM @XClass         TMP
              INNER JOIN XClass  CLS ON CLS.ClassName = TMP.ClassName
              INNER JOIN XModul  MOD ON MOD.ModulID   = CLS.ModulID
            WHERE CLS.CodeGenerated IS NOT NULL
            UNION ALL
            SELECT CASE WHEN EXISTS (SELECT * FROM XClassRule WHERE ClassName = {0} AND XRuleID = RUL.XRuleID) THEN 1 ELSE 3 END,
              NULL, RuleName, NULL,
              csCode, NULL
            FROM XRule   RUL
            WHERE RUL.RuleCode = 1 AND RUL.csCode IS NOT NULL
              AND XRuleID IN (SELECT XRuleID
                              FROM @XClass             TMP
                                INNER JOIN XClassRule  CLR ON CLR.ClassName = TMP.ClassName AND CLR.Active = 1)
            ORDER BY 1, 3";
        internal const string SQLqryXClassRule = @"
            SELECT CLR.XClassRuleID, CLR.SortKey, CLR.Active,
              MOD.NameSpace, CLS.ClassName,
              CLR.ControlName, CTL.DataSource, CTL.DataMember,
              CMP.ComponentName,
              RUL.*,
              RuleType       = XLC.Text,
              EventComponent = REPLACE(REPLACE(REPLACE(XLC.Value1, '<ClassName>', CLR.ClassName), '<ControlName>', IsNull(CLR.ControlName, '<ControlName>')), '<ComponentName>', COALESCE(CMP.ComponentName, CTL.DataSource, '<ComponentName>')),
              EventName      = XLC.Value2,
              EventParams    = XLC.Value3
            FROM XClassRule               CLR
              INNER JOIN XRule            RUL ON RUL.XRuleID = CLR.XRuleID
              LEFT  JOIN XLOVCode         XLC ON XLC.LOVName = 'Rule' AND XLC.Code = RUL.RuleCode
              INNER JOIN XClass           CLS ON CLS.ClassName = CLR.ClassName
              INNER JOIN XModul           MOD ON MOD.ModulID = CLS.ModulID
              LEFT  JOIN XClassControl    CTL ON CTL.ClassName = CLR.ClassName AND CTL.ControlName = CLR.ControlName
              LEFT  JOIN XClassComponent  CMP ON CMP.ClassName = CLR.ClassName AND CMP.ComponentName = CLR.ComponentName
            WHERE CLR.ClassName = {0}
            ORDER BY CASE WHEN XLC.Value1 IS NULL OR XLC.Value1 = '<ClassName>' THEN 1 ELSE 2 END,
              EventComponent, XLC.SortKey, EventName, CLR.SortKey, RUL.RuleCode, CLR.ControlName, RUL.RuleName, CLR.XClassRuleID";

        #endregion

        #region Internal Fields

        internal ArrayList errors = new ArrayList();

        #endregion

        #region Private Static Fields

        private static readonly Attribute[] propertyAttributes = new Attribute[] { DesignOnlyAttribute.No };

        static CodeCommentStatement commentDispose = new CodeCommentStatement(@"<summary>
         Clean up any resources being used.
         </summary>", true);
        static CodeCommentStatement commentInitializeComponent = new CodeCommentStatement(@"<summary>
         Required method for Designer support - do not modify
         the contents of this method with the code editor.
         </summary>", true);
        private static Regex regExUsingNameSpace = new Regex(@"^\s*?using\s+?(?<NameSpace>(\w|\.)+)\s*?;", RegexOptions.Multiline);

        #endregion

        #region Private Constant/Read-Only Fields

        const string nsSchemaInstance = "http://www.w3.org/2001/XMLSchema-instance";

        #endregion

        #region Private Fields

        private ArrayList alLateReference;
        private Type baseType = typeof(KiSS4.Gui.KissUserControl);
        private string className = "CtlUserControl";
        private CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
        private CSharpCodeProvider csCodeProvider = new CSharpCodeProvider();
        private IDesignerHost host;
        private Hashtable htReference;
        Hashtable htRename = new Hashtable();
        private Control mainControl;
        private string nameSpace = "KiSS4.DynaMask";
        private SqlQuery qryXClass;
        private SqlQuery qryXClassComponent;
        private SqlQuery qryXClassControl;
        private SqlQuery qryXClassReference = new SqlQuery();
        private SqlQuery qryXClassRule;
        private bool successful = false;
        private MyTypeResolutionService trService = new MyTypeResolutionService();

        #endregion

        #endregion

        #region Constructors

        public MyCodeDomDesignerLoader(SqlQuery qryXClass, SqlQuery qryXClassControl, SqlQuery qryXClassComponent, SqlQuery qryXClassRule)
        {
            this.qryXClass = qryXClass;

            if (this.qryXClass.Count > 0)
            {
                this.baseType = AssemblyLoader.GetType((string)this.qryXClass["BaseType"]);
                this.nameSpace = (string)this.qryXClass["NameSpace"];
                this.className = (string)this.qryXClass["ClassName"];
            }
            this.qryXClassControl = qryXClassControl;
            this.qryXClassComponent = qryXClassComponent;
            this.qryXClassRule = qryXClassRule;
        }

        #endregion

        #region Dispose

        public override void Dispose()
        {
            // Always remove attached event handlers in Dispose.
            IComponentChangeService cs = host.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (cs != null)
                cs.ComponentRename -= new ComponentRenameEventHandler(OnComponentRename);

            base.Dispose();
        }

        #endregion

        #region Properties

        protected override System.CodeDom.Compiler.CodeDomProvider CodeDomProvider
        {
            get { return csCodeProvider; }
        }

        protected override System.ComponentModel.Design.ITypeResolutionService TypeResolutionService
        {
            get { return trService; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Called by the host when we load a document.
        /// </summary>
        /// <param name="host"></param>
        public override void BeginLoad(IDesignerLoaderHost host)
        {
            this.host = host;
            base.BeginLoad(host);
            host.AddService(typeof(INameCreationService), new MyNameCreationService(host));

            if (host == null)
            {
                throw new ArgumentNullException("MyDesignerLoader.BeginLoad: Invalid designerLoaderHost.");
            }

            this.host = host;

            // The loader will put error messages in here.
            //
            errors = new ArrayList();

            // The loader is responsible for providing certain services to the host.
            //
            // host.AddService(typeof(IDesignerSerializationManager), new MyDesignerSerializationManager(this));
            host.AddService(typeof(IEventBindingService), new MyEventBindingService(host));
            // host.AddService(typeof(ITypeResolutionService), trService);
            host.AddService(typeof(IResourceService), new MyResourceService(host));

            // If no filename was passed in, just create a form and be done with it.  If a file name
            // was passed, read it.
            ReadObject(errors);
            successful = errors.Count == 0;

            // Now that we are done with the load work, we need to begin to listen to events.
            // Listening to event notifications is how a designer "Loader" can also be used
            // to save data.  If we wanted to integrate this loader with source code control,
            // we would listen to the "ing" events as well as the "ed" events.
            IComponentChangeService cs = host.GetService(typeof(IComponentChangeService)) as IComponentChangeService;

            if (cs != null)
            {
                cs.ComponentRename += new ComponentRenameEventHandler(OnComponentRename);
            }

            // autoarrange components if possible
            System.Windows.Forms.Design.ComponentTray tray = host.GetService(typeof(System.Windows.Forms.Design.ComponentTray)) as System.Windows.Forms.Design.ComponentTray;

            if (tray != null)
            {
                tray.AutoArrange = true;
            }

            // Let the host know we are done loading.
            host.EndLoad(this.baseType.FullName, successful, errors);
        }

        /// <summary>
        /// This method is called by the designer host whenever it wants the
        /// designer loader to flush any pending changes.  Flushing changes
        /// does not mean the same thing as saving to disk.  For example,
        /// In Visual Studio, flushing changes causes new code to be generated
        /// and inserted into the text editing window.  The user can edit
        /// the new code in the editing window, but nothing has been saved
        /// to disk.  This sample adheres to this separation between flushing
        /// and saving, since a flush occurs whenever the code windows are
        /// displayed or there is a build. Neither of those items demands a save.
        /// </summary>
        public override void Flush()
        {
            if (this.qryXClassRule != null)
            {
                this.qryXClassRule.Post();
            }

            SqlQuery qryXClassRule = DBUtil.OpenSQL(SQLqryXClassRule, className);

            const string filter = "Active = 1 AND EventComponent IS NOT NULL AND EventName IS NOT NULL AND csCode IS NOT NULL";

            // Register EventMethode
            foreach (DataRow row in qryXClassRule.DataTable.Select(filter, "SortKey"))
            {
                this.GetEventMethod(row, true);
            }

            base.Flush();

            // Unregister EventMethode
            foreach (DataRow row in qryXClassRule.DataTable.Select(filter, "SortKey"))
            {
                this.GetEventMethod(row, false);
            }
        }

        /// <summary>
        /// Save controls and components of designerhost to kiss database
        /// </summary>
        /// <returns>true if success, false if exception occured</returns>
        public bool Save()
        {
            if (!successful)
                return false;
            if (this.qryXClass.CanUpdate == false)
                return false;

            SqlQuery qry = DBUtil.OpenSQL("SELECT * FROM XClass WHERE ClassName = {0}", this.className);
            foreach (DataColumn col in qry.DataTable.Columns)
                qryXClass[col.ColumnName] = qry[col.ColumnName];
            qryXClass.Row.AcceptChanges();

            Hashtable nametable = new Hashtable(host.Container.Components.Count);

            this.qryXClassReference.Fill(SQLqryXClassReference, this.className);

            // save class
            this.qryXClass["PropertiesXML"] = WritePropertiesXML(nametable, (Control)host.RootComponent);
            bool bitSuccessfullyDone = this.qryXClass.Post("XClass");
            // Cascaded-Update: Verändert Timestamp
            this.qryXClassControl.Refresh();

            // save controls if no exception occured
            bitSuccessfullyDone = bitSuccessfullyDone && WriteControls((Control)host.RootComponent, nametable);

            // save components if no exception occured
            if (bitSuccessfullyDone)
            {
                // Cascaded-Update: Verändert Timestamp
                this.qryXClassComponent.Refresh();

                IComponent root = (IComponent)host.RootComponent;

                //loop each non-root component
                foreach (IComponent comp in host.Container.Components)
                {
                    if (comp != root && !nametable.ContainsKey(comp))
                    {
                        if (!qryXClassComponent.Find(string.Format("ComponentName = '{0}'", comp.Site.Name)))
                        {
                            this.qryXClassComponent.Insert("XClassComponent");
                            this.qryXClassComponent["ClassName"] = this.className;
                        }
                        this.qryXClassComponent["ComponentName"] = comp.Site.Name;
                        this.qryXClassComponent["TypeName"] = comp.GetType().FullName;

                        qry = comp as SqlQuery;
                        if (qry != null)
                        {
                            this.qryXClassComponent["TableName"] = qry.TableName;
                            this.qryXClassComponent["SelectStatement"] = qry.SelectStatement;
                        }

                        this.qryXClassComponent["PropertiesXML"] = WritePropertiesXML(nametable, comp);
                        foreach (DataColumn col in this.qryXClassComponent.DataTable.Columns)
                        {
                            if (qryXClassComponent.ColumnModified(col.ColumnName))
                            {
                                bitSuccessfullyDone = bitSuccessfullyDone && this.qryXClassComponent.Post("XClassComponent");
                                break;
                            }
                        }

                        this.qryXClassComponent.Row.AcceptChanges();
                        this.qryXClassComponent.RowModified = false;
                    }
                }
            }

            if (bitSuccessfullyDone)
            {
                foreach (string key in htRename.Keys)
                {
                    DBUtil.ExecSQL(@"
                        UPDATE XClassRule SET ControlName = {2}   WHERE ClassName = {0} AND ControlName = {1}
                        UPDATE XClassRule SET ComponentName = {2} WHERE ClassName = {0} AND ComponentName = {1}"
                        , this.className, key, htRename[key]);
                }
                htRename.Clear();

                this.qryXClassControl.DeleteQuestion = null;
                this.qryXClassControl.First();
                while (qryXClassControl.Count > 0)
                {
                    if (!nametable.ContainsValue(this.qryXClassControl["ControlName"]))
                    {
                        DBUtil.ExecSQL("DELETE FROM XClassRule WHERE ClassName = {0} AND ControlName = {1}", this.className, this.qryXClassControl["ControlName"]);
                        qryXClassControl.Delete("XClassControl");
                    }
                    else if (!this.qryXClassControl.Next())
                        break;
                }

                this.qryXClassComponent.DeleteQuestion = null;
                this.qryXClassComponent.First();
                while (qryXClassComponent.Count > 0)
                {
                    if (!nametable.ContainsValue(this.qryXClassComponent["ComponentName"])
                        || nametable[this.qryXClassComponent["ComponentName"]] is Control)
                    {
                        DBUtil.ExecSQL("DELETE FROM XClassRule WHERE ClassName = {0} AND ComponentName = {1}", this.className, this.qryXClassComponent["ComponentName"]);
                        qryXClassComponent.Delete("XClassComponent");
                    }
                    else if (!this.qryXClassComponent.Next())
                        break;
                }
            }

            // Generate SourceCode
            this.Flush();

            CodeNamespace ns = codeCompileUnit.Namespaces[1];
            CodeTypeDeclaration td = ns.Types[0];

            for (int i = td.Members.Count - 1; i >= 0; i--)
            {
                CodeTypeMember ctm = td.Members[i];

                if (ctm is CodeMemberMethod && ((CodeMemberMethod)ctm).Name == "InitializeComponent")
                {
                    ctm.Comments.Clear();
                    ctm.Comments.Add(commentInitializeComponent);
                    ctm.StartDirectives.Clear();
                    ctm.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "Designer generated code"));
                    ctm.EndDirectives.Clear();
                    ctm.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
                }
                else if (ctm is CodeConstructor || ctm is CodeSnippetTypeMember || ctm is CodeMemberMethod)
                    td.Members.Remove(ctm);
            }

            // We need a constructor that will call the InitializeComponent()
            // that we just generated.
            CodeConstructor con = new CodeConstructor();
            con.Attributes = MemberAttributes.Public;
            con.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "InitializeComponent")));

            // Add Constructor Rule
            SqlQuery qryXClassRule = DBUtil.OpenSQL(SQLqryXClassRule, className);

            foreach (DataRow row in qryXClassRule.DataTable.Select("Active = 1 AND RuleCode = 2 AND csCode IS NOT NULL", "SortKey"))
                con.Statements.Add(new CodeSnippetStatement(FormatCsCode(row)));

            td.Members.Add(con);

            // Add Dispose Rule
            bool hasComponents = false;

            foreach (CodeTypeMember m in td.Members)
            {
                CodeMemberField cmf = m as CodeMemberField;
                if ((cmf != null && cmf.Name.Equals("components") && cmf.Type.BaseType.Equals("System.ComponentModel.IContainer")))
                {
                    hasComponents = true;
                    break;
                }
            }

            // Dispose
            if (hasComponents || qryXClassRule.DataTable.Select("Active = 1 AND RuleCode = 6 AND csCode IS NOT NULL").Length > 0)
            {
                CodeMemberMethod mthDispose = new CodeMemberMethod();
                mthDispose.Comments.Add(commentDispose);
                mthDispose.Attributes = MemberAttributes.Overloaded | MemberAttributes.Override | MemberAttributes.Family;
                mthDispose.Name = "Dispose";

                CodeParameterDeclarationExpression expr = new CodeParameterDeclarationExpression(typeof(bool), "disposing");
                expr.Direction = FieldDirection.In;
                mthDispose.Parameters.Add(expr);

                CodeArgumentReferenceExpression aD = new CodeArgumentReferenceExpression("disposing");

                // add: business rules
                foreach (DataRow row in qryXClassRule.DataTable.Select("Active = 1 AND RuleCode = 6 AND csCode IS NOT NULL", "SortKey"))
                    mthDispose.Statements.Add(new CodeSnippetStatement(FormatCsCode(row)));

                if (hasComponents)
                {
                    CodeVariableReferenceExpression vC = new CodeVariableReferenceExpression("components");

                    // if( disposing )
                    // {
                    //      if(components != null)
                    //      {
                    //          components.Dispose();
                    //      }
                    // }
                    CodeConditionStatement stmt = new CodeConditionStatement(
                        aD, new CodeStatement[] {
                                                new CodeConditionStatement(new CodeBinaryOperatorExpression(vC,	CodeBinaryOperatorType.IdentityInequality, new CodePrimitiveExpression()),
                                                new CodeStatement[] { new CodeExpressionStatement(new CodeMethodInvokeExpression(vC, "Dispose")) })
                                            });

                    mthDispose.Statements.Add(stmt);
                }

                // base.Dispose( disposing )
                mthDispose.Statements.Add(new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), "Dispose", aD));

                // add method to code
                td.Members.Add(mthDispose);
            }

            Hashtable htEventMethod = new Hashtable();

            // remove Interface
            while (td.BaseTypes.Count > 1)
                td.BaseTypes.RemoveAt(1);

            // Add Constructor Rule
            foreach (DataRow row in qryXClassRule.DataTable.Select("Active = 1 AND RuleCode > 2 AND csCode IS NOT NULL", "SortKey"))
            {
                switch (GetRuleCode(row))
                {
                    case 3: // CodeCollection
                    case 10: // CodeCollection
                        td.Members.Add(new CodeSnippetTypeMember(FormatCsCode(row)));
                        break;

                    case 4: // Interface
                        td.BaseTypes.Add(row["csCode"] as string);
                        break;

                    case 5: // using ...;
                        CodeNamespace nsNameSpace = codeCompileUnit.Namespaces[0];

                        foreach (Match match in regExUsingNameSpace.Matches(row["csCode"] as string))
                            nsNameSpace.Imports.Add(new CodeNamespaceImport(match.Groups["NameSpace"].ToString()));
                        break;

                    case 6: // protected override void Dispose( bool disposing )
                        break;

                    case 100: // Events
                    default: // (private | (public | protected | private) override) void <EventComponent>_<EventName>(<EventParams>)
                        if (!(DBUtil.IsEmpty(row["EventComponent"]) || DBUtil.IsEmpty(row["EventName"])))
                        {
                            // get the name of the event method
                            string eventMethodName = GetEventMethod(row, false);

                            // check if we have a valid event-method-name (used later as key in hashtable)
                            if (eventMethodName == null)
                            {
                                throw new NullReferenceException(String.Format("Could not get event method name for EventComponent='{0}' and EventName='{1}' in MyCodeDomDesignerLoader.", row["EventComponent"], row["EventName"]));
                            }

                            CodeMemberMethod eventMethod = htEventMethod[eventMethodName] as CodeMemberMethod;
                            if (eventMethod == null)
                            {
                                eventMethod = new CodeMemberMethod();
                                eventMethod.Name = eventMethodName;
                                if (!DBUtil.IsEmpty(row["EventParams"]))
                                {
                                    foreach (string eventParam in ((string)row["EventParams"]).Split(','))
                                    {
                                        string[] eventParams = eventParam.Trim().Split(' ');
                                        switch (eventParams[0] as string)
                                        {
                                            case "object":
                                                eventMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(object), eventParams[eventParams.Length - 1]));
                                                break;

                                            default:
                                                eventMethod.Parameters.Add(new CodeParameterDeclarationExpression(eventParams[0], eventParams[eventParams.Length - 1]));
                                                break;
                                        }
                                    }
                                }

                                MethodInfo mi = this.baseType.GetMethod(eventMethodName, AssemblyLoader.BindingFlags);
                                if (mi != null && (mi.IsVirtual || mi.IsAbstract) && !mi.IsFinal && !mi.IsStatic)
                                {
                                    eventMethod.Attributes = MemberAttributes.Override;

                                    if (mi.IsPrivate)
                                        eventMethod.Attributes |= MemberAttributes.Private;
                                    else if (mi.IsFamily)
                                        eventMethod.Attributes |= MemberAttributes.Family;
                                    else if (mi.IsPublic)
                                        eventMethod.Attributes |= MemberAttributes.Public;
                                }

                                htEventMethod.Add(eventMethodName, eventMethod);
                                td.Members.Add(eventMethod);
                            }

                            eventMethod.Statements.Add(new CodeSnippetStatement(FormatCsCode(row)));
                        }
                        break;
                }
            }

            // The options for our code generation.
            CodeGeneratorOptions o = new CodeGeneratorOptions();
            o.BlankLinesBetweenMembers = true;
            o.BracingStyle = "C";
            o.ElseOnClosing = false;
            o.IndentString = "\t";

            // CSharp Code Generation
            StringWriter sw = new StringWriter();
            CSharpCodeProvider cs = new CSharpCodeProvider();
            cs.GenerateCodeFromCompileUnit(codeCompileUnit, sw, o);
            this.qryXClass["CodeGenerated"] = sw.ToString();
            sw.Close();

            return bitSuccessfullyDone && this.qryXClass.Post();
        }

        #endregion

        #region Internal Static Methods

        internal static string ReplacePlaceholder(DataRow row, string input)
        {
            if (row == null)
                return input;

            foreach (string fieldName in new string[] { "NameSpace", "ClassName", "ComponentName", "ControlName", "DataSource", "DataMember", "EventComponent", "EventName", "EventParams" })
            {
                if (row.Table.Columns.Contains(fieldName) && !DBUtil.IsEmpty(row[fieldName]))
                {
                    input = input.Replace(string.Format("<{0}>", fieldName), (string)row[fieldName]);
                    if (fieldName == "DataSource")
                        input = input.Replace(string.Format("<ComponentName>", fieldName), (string)row[fieldName]);
                }
            }
            return input;
        }

        #endregion

        #region Protected Methods

        protected override System.CodeDom.CodeCompileUnit Parse()
        {
            IDesignerSerializationManager manager = host.GetService(typeof(IDesignerSerializationManager)) as IDesignerSerializationManager;

            CodeCompileUnit code = new CodeCompileUnit();

            CodeNamespace ns = new CodeNamespace("");
            code.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("System.Collections"));
            ns.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel"));
            ns.Imports.Add(new CodeNamespaceImport("System.Data"));
            ns.Imports.Add(new CodeNamespaceImport("System.Drawing"));
            ns.Imports.Add(new CodeNamespaceImport("System.Text"));
            ns.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));

            ns.Imports.Add(new CodeNamespaceImport("KiSS4.DB"));
            ns.Imports.Add(new CodeNamespaceImport("KiSS4.Gui"));
            ns.Imports.Add(new CodeNamespaceImport("KiSS4.Common"));
            ns.Imports.Add(new CodeNamespaceImport("KiSS4.Messages"));

            ns = new CodeNamespace(nameSpace);
            code.Namespaces.Add(ns);

            CodeTypeDeclaration td = new CodeTypeDeclaration(this.className);
            td.BaseTypes.Add(this.baseType.FullName);
            ns.Types.Add(td);

            codeCompileUnit = code;
            return codeCompileUnit;
        }

        /// <summary>
        /// When the Loader is Flushed this method is called. The base class
        /// (CodeDomDesignerLoader) creates the CodeCompileUnit. We
        /// simply cache it and use this when we need to generate code from it.
        /// To generate the code we use CodeProvider.
        /// </summary>
        protected override void Write(System.CodeDom.CodeCompileUnit unit)
        {
            codeCompileUnit = unit;
        }

        #endregion

        #region Private Static Methods

        private static string FormatCsCode(DataRow row)
        {
            ArrayList alProperties = new ArrayList();
            foreach (string fieldName in new string[] { "ControlName", "ComponentName", "RuleType", "SortKey", "RuleName" })
            {
                if (!DBUtil.IsEmpty(row[fieldName])
                    && !(fieldName == "RuleType" && row[fieldName].Equals("CodeCollection"))
                    && !(fieldName == "SortKey" && (row[fieldName].Equals(100) || row[fieldName].Equals(row["DefaultSortKey"])))
                    )
                {
                    alProperties.Add(string.Format("{0}: {1}", fieldName, row[fieldName]));
                }
            }

            string code = string.Format(@"
            // Begin Rule{1}
            {0}
            // End Rule"
                , ReplacePlaceholder(row, (string)row["csCode"])
                , alProperties.Count == 0 ? string.Empty : "\r\n// " + string.Join(", ", (string[])alProperties.ToArray(typeof(string))));

            switch (GetRuleCode(row))
            {
                case 1: // Class
                case 4: // Interface
                case 5: // Using
                default:
                    throw new Exception();

                case 3: // CodeCollection
                case 10: // CodeCollection
                    return code.Replace(Environment.NewLine, Environment.NewLine + "\t\t");

                case 2: // Constructor
                case 6: // Dispose
                case 100: // Events
                    return code.Replace(Environment.NewLine, Environment.NewLine + "\t\t\t");
            }
        }

        private static int GetRuleCode(DataRow row)
        {
            int ruleCode = (int)row["RuleCode"];

            if (!DBUtil.IsEmpty(row["EventComponent"]) && !DBUtil.IsEmpty(row["EventName"]))
                return 100; // Event
            else if (ruleCode > 10)
                return 10; // CodeCollection
            else
                return ruleCode;
        }

        private static XmlAttribute GetTypeAttribute(XmlNode node)
        {
            XmlAttribute typeAttr = node.Attributes["xsi:type"];
            if (typeAttr == null)
                typeAttr = node.Attributes["type"];
            return typeAttr;
        }

        private static void RemoveXMLNode(XmlNode node)
        {
            if (node == null)
                return;
            if (node is XmlAttribute)
                ((XmlAttribute)node).OwnerElement.RemoveAttributeNode((XmlAttribute)node);
            else
                node.ParentNode.RemoveChild(node);
        }

        private static XmlAttribute SetXmlAttribute(XmlDocument xmlDoc, XmlNode node, string attrName, string attrValue)
        {
            XmlAttribute xmlAttr = node.Attributes[attrName];
            if (xmlAttr == null)
            {
                xmlAttr = xmlDoc.CreateAttribute(attrName);

                if (node.Attributes.Count > 0 && attrName == "name")
                    node.Attributes.InsertBefore(xmlAttr, node.Attributes[0]);
                else
                    node.Attributes.Append(xmlAttr);
            }

            xmlAttr.Value = attrValue;

            return xmlAttr;
        }

        /// <summary>
        /// This method writes a given byte[] into the XML document, returning the node that
        /// it just created.  Byte arrays have the following XML:
        /// 
        /// <c>
        /// <Binary>
        ///		64 bit encoded string representing binary data
        /// </Binary>
        /// </c>
        /// </summary>
        private static XmlNode WriteBinary(XmlDocument document, byte[] value)
        {
            XmlNode node = document.CreateElement("Binary");
            node.InnerText = Convert.ToBase64String(value);
            return node;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Simple helper method that returns true if the given type converter supports
        /// two-way conversion of the given type.
        /// </summary>
        /// <param name="converter"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        private bool GetConversionSupported(TypeConverter converter, Type conversionType)
        {
            return (converter.CanConvertFrom(conversionType) && converter.CanConvertTo(conversionType));
        }

        private string GetEventMethod(DataRow row, bool registerEvent)
        {
            if (DBUtil.IsEmpty(row["EventComponent"]))
                return null;

            string componentName = ReplacePlaceholder(row, (string)row["EventComponent"]);

            foreach (Component cmp in host.Container.Components)
            {
                if (componentName.Equals(cmp.Site.Name))
                {
                    try
                    {
                        string eventMethod = string.Format("{0}_{1}", componentName, row["EventName"]);

                        MethodInfo mi = this.baseType.GetMethod(eventMethod, AssemblyLoader.BindingFlags);
                        if (mi != null && (mi.IsVirtual || mi.IsAbstract) && !mi.IsFinal && !mi.IsStatic)
                            return eventMethod;

                        IEventBindingService bindings = host.GetService(typeof(IEventBindingService)) as IEventBindingService;
                        EventDescriptor evt = TypeDescriptor.GetEvents(cmp)[row["EventName"] as string];

                        PropertyDescriptor prop = bindings.GetEventProperty(evt);

                        if (registerEvent)
                            prop.SetValue(cmp, eventMethod);
                        else
                            prop.SetValue(cmp, null);

                        return eventMethod;
                    }
                    catch { }
                    break;
                }
            }

            return null;
        }

        private void OnComponentRename(object sender, ComponentRenameEventArgs e)
        {
            foreach (string key in htRename.Keys)
            {
                if (htRename[key].Equals(e.OldName))
                {
                    htRename[key] = e.NewName;
                    return;
                }
            }
            htRename[e.OldName] = e.NewName;
        }

        private void ReadControl(object parent, string parentName, IList errors)
        {
            DataRow[] childs;
            if (parentName == null)
                childs = this.qryXClassControl.DataTable.Select("ParentControl IS NULL", "TabIndex");
            else
                childs = this.qryXClassControl.DataTable.Select(string.Format("ParentControl = '{0}'", parentName), "TabIndex");

            if (childs.Length > 0)
            {
                PropertyDescriptor childProp = TypeDescriptor.GetProperties(parent)["Controls"];
                if (childProp == null)
                    errors.Add(string.Format("The children attribute lists {0} as the child collection but this is not a property on {1}", "Controls", parent.GetType().FullName));
                else
                {
                    IList childList = childProp.GetValue(parent) as IList;

                    if (childList == null)
                    {
                        errors.Add(string.Format("The property {0} was found but did not return a valid IList", childProp.Name));
                    }
                    else
                    {
                        foreach (DataRow row in childs)
                        {
                            try
                            {
                                Control ctl = ReadObject((string)row["TypeName"], (string)row["ControlName"], errors) as Control;

                                if (!childList.Contains(ctl))
                                {
                                    childList.Add(ctl);
                                }

                                ReadObjectPropertiesXML(ctl, row["PropertiesXML"] as string, errors);

                                if (ctl.Dock == DockStyle.Right || ctl.Dock == DockStyle.Bottom)
                                {
                                    ctl.SendToBack();
                                }
                                else
                                {
                                    ctl.BringToFront();
                                }

                                ctl.Location = new System.Drawing.Point((int)row["X"], (int)row["Y"]);
                                ctl.Width = (int)row["Width"];
                                ctl.Height = (int)row["Height"];
                                ctl.TabIndex = (int)row["TabIndex"];

                                if (ctl is IKissBindableEdit)
                                {
                                    if (!DBUtil.IsEmpty(row["DataSource"]))
                                    {
                                        this.alLateReference.Add(new Reference(ctl, "DataSource", row["DataSource"] as string));
                                        ((IKissBindableEdit)ctl).DataMember = row["DataMember"] as string;
                                    }
                                }

                                ReadControl(ctl, (string)row["ControlName"], errors);
                            }
                            catch
                            {
                                switch ((string)row["TypeName"])
                                {
                                    case "DevExpress.XtraGrid.GridControlNavigator": // Kein Konstruktor vorhanden
                                        break;

                                    default:
                                        throw;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Reads an Event node and binds the event.
        /// </summary>
        /// <param name="childNode"></param>
        /// <param name="instance"></param>
        /// <param name="errors"></param>
        private void ReadEvent(XmlNode childNode, object instance, IList errors)
        {
            IEventBindingService bindings = host.GetService(typeof(IEventBindingService)) as IEventBindingService;
            if (bindings == null)
            {
                errors.Add("Unable to contact event binding service so we can't bind any events");
                return;
            }

            XmlAttribute nameAttr = childNode.Attributes["name"];
            if (nameAttr == null)
            {
                errors.Add("No event name");
                return;
            }

            XmlText methodText = childNode.FirstChild as XmlText;
            if (methodText == null || methodText.Value == null || methodText.Value.Length == 0)
            {
                errors.Add(string.Format("Event {0} has no method bound to it", nameAttr.Value));
                return;
            }

            EventDescriptor evt = TypeDescriptor.GetEvents(instance)[nameAttr.Value];
            if (evt == null)
            {
                errors.Add(string.Format("Event {0} does not exist on {1}", nameAttr.Value, instance.GetType().FullName));
                return;
            }

            PropertyDescriptor prop = bindings.GetEventProperty(evt);
            Debug.Assert(prop != null, "Bad event binding service");

            try
            {
                prop.SetValue(instance, methodText.Value);
            }
            catch (Exception ex)
            {
                errors.Add(string.Format("Bind event '{0}' to methode '{1}' : throw {2}", nameAttr.Value, methodText.Value, ex.Message));
            }
        }

        private object ReadInstanceDescriptor(XmlNode node, IList errors)
        {
            // First, need to deserialize the member
            XmlAttribute memberAttr = node.Attributes["member"];
            XmlAttribute typeAttr = GetTypeAttribute(node);
            if (memberAttr == null && typeAttr == null)
            {
                errors.Add("No Member attribute on instance descriptor");
                return null;
            }

            MemberInfo mi;

            ArrayList alParameterType = new ArrayList();

            if (memberAttr == null)
            {
                Type type = Gui.AssemblyLoader.GetType(typeAttr.Value, this.baseType.Assembly);

                foreach (XmlNode child in node.SelectNodes("Argument"))
                    alParameterType.Add(AssemblyLoader.GetType(GetTypeAttribute(child).Value));

                mi = type.GetConstructor((System.Type[])alParameterType.ToArray(typeof(System.Type)));
            }
            else
            {
                byte[] data = Convert.FromBase64String(memberAttr.Value);
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream(data);
                mi = (MemberInfo)formatter.Deserialize(stream);
            }

            object[] args = null;

            // Check to see if this member needs arguments. If so, gather them from the XML.
            if (mi is MethodBase)
            {
                ParameterInfo[] paramInfos = ((MethodBase)mi).GetParameters();
                args = new object[paramInfos.Length];
                int idx = 0;

                foreach (XmlNode child in node.SelectNodes("Argument"))
                {
                    object value;
                    if (!ReadValue(child, TypeDescriptor.GetConverter(paramInfos[idx].ParameterType), errors, out value, null, null))
                        return null;

                    args[idx++] = value;
                }

                if (idx != paramInfos.Length)
                {
                    errors.Add(string.Format("Member {0} requires {1} arguments, not {2}.", mi.Name, args.Length, idx));
                    return null;
                }
            }

            InstanceDescriptor id = new InstanceDescriptor(mi, args);
            object instance = id.Invoke();

            // Ok, we have our object.  Now, check to see if there are any properties, and if there are, set them.
            foreach (XmlNode prop in node.SelectNodes("Property"))
                ReadProperty(prop, instance, errors);

            return instance;
        }

        private object ReadObject(IList errors)
        {
            this.htReference = new Hashtable(this.qryXClassControl.Count + this.qryXClassComponent.Count + 1);
            this.alLateReference = new ArrayList();

            mainControl = ReadObject((string)this.qryXClass.Row["BaseType"], (string)this.qryXClass.Row["ClassName"], errors) as Control;
            ReadObjectPropertiesXML(mainControl, this.qryXClass.Row["PropertiesXML"] as string, errors);
            mainControl.Site.Name = (string)this.qryXClass.Row["ClassName"];
            ReadControl(mainControl, null, errors);

            if (!this.qryXClassComponent.DataTable.Columns.Contains("colSort"))
                this.qryXClassComponent.DataTable.Columns.Add(new DataColumn("colSort", typeof(string), @"
                    IIF(TypeName = 'DevExpress.XtraBars.BarButtonItem', 0, 99) +
                    IIF(TypeName = 'DevExpress.XtraBars.BarManager',    0, 98) +
                    IIF(TypeName = 'DevExpress.XtraBars.PopupMenu',     0, 97) +

                    IIF(TypeName = 'DevExpress.XtraNavBar.NavBarGroup', 100, 0)
                    "));

            foreach (DataRow row in this.qryXClassComponent.DataTable.Select("", "colSort"))
            {
                object instance = ReadObject((string)row["TypeName"], (string)row["ComponentName"], errors);
                ReadObjectPropertiesXML(instance, row["PropertiesXML"] as string, errors);

                if (instance is SqlQuery)
                {
                    ((SqlQuery)instance).SelectStatement = row["SelectStatement"] as string;
                    ((SqlQuery)instance).TableName = row["TableName"] as string;
                }
            }

            foreach (Reference objRef in alLateReference)
                objRef.SetValue(htReference[objRef.TagetName]);

            this.htReference = null;
            this.alLateReference = null;

            foreach (Component cmp in this.host.Container.Components)
                if (cmp is ISupportInitialize)
                    ((ISupportInitialize)cmp).EndInit();

            return mainControl;
        }

        private object ReadObject(string typeName, string name, IList errors)
        {
            Type type = AssemblyLoader.GetType(typeName, this.baseType.Assembly);
            if (type == null)
            {
                errors.Add(string.Format("Type {0} could not be loaded.", typeName));
                return null;
            }

            object instance = null;
            if (this.mainControl != null)
            {
                FieldInfo fi = this.baseType.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (fi != null && fi.IsFamily)
                    instance = fi.GetValue(this.mainControl) as Component;
            }

            if (host is IContainer && ((IContainer)host).Components[name] != null)
            {
                instance = ((IContainer)host).Components[name];
            }
            else if (instance == null || ((Component)instance).Site == null)
            {
                if (typeof(IComponent).IsAssignableFrom(type))
                {
                    if (name == null)
                        instance = host.CreateComponent(type);
                    else
                        instance = host.CreateComponent(type, name);
                }
                else
                {
                    instance = Activator.CreateInstance(type);
                }
            }
            else if (!((Component)instance).Site.Name.Equals(name))
            {
                htRename[((Component)instance).Site.Name] = name;
            }

            this.htReference[name] = instance;

            if (instance is ISupportInitialize)
                ((ISupportInitialize)instance).BeginInit();

            return instance;
        }

        private void ReadObjectPropertiesXML(object instance, string propertiesXML, IList errors)
        {
            if (propertiesXML == null)
                return;

            XmlDocument xmlProperties = new XmlDocument();
            try
            {
                xmlProperties.LoadXml(propertiesXML);

                foreach (XmlNode childNode in xmlProperties.DocumentElement.ChildNodes)
                {
                    if (childNode.Name.Equals("Property"))
                        ReadProperty(childNode, instance, errors);
                    else if (childNode.Name.Equals("Event"))
                        ReadEvent(childNode, instance, errors);
                }
            }
            catch (Exception ex)
            {
                errors.Add(string.Format("Exception occured in MyCodeDomDesignerLoader.ReadObjectPropertiesXML():{2}{2}{0}{2}{2}PropertiesXML:{2}{1}", ex.Message, propertiesXML, Environment.NewLine));
            }
        }

        /// <summary>
        /// Parses the given XML node and sets the resulting property value.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="instance"></param>
        /// <param name="errors"></param>
        private void ReadProperty(XmlNode node, object instance, IList errors)
        {
            XmlAttribute nameAttr = node.Attributes["name"];
            if (nameAttr == null)
            {
                errors.Add("Property has no name");
                return;
            }

            PropertyDescriptor prop = TypeDescriptor.GetProperties(instance)[nameAttr.Value];
            if (prop == null)
            {
                errors.Add(string.Format("Property {0} does not exist on {1}", nameAttr.Value, instance.GetType().FullName));
                return;
            }

            // Get the type of this property.  We have three options:
            // 1.  A normal read/write property.
            // 2.  A "Content" property.
            // 3.  A collection.

            object oldValue = prop.GetValue(instance);
            object newValue = null;

            if (oldValue is IList && (node.FirstChild == null || node.FirstChild.Name.Equals("Item"))) // Collection
            {
                if (((IList)oldValue).Count > 0)
                    ((IList)oldValue).Clear();

                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name.Equals("Item"))
                    {
                        XmlAttribute typeAttr = GetTypeAttribute(child);
                        if (typeAttr == null)
                        {
                            errors.Add(string.Format("Exception occured in MyCodeDomDesignerLoader.ReadProperty():{0}Item has no type attribute - on object '{1}' and value '{2}'", Environment.NewLine, instance, oldValue));
                            continue;
                        }

                        Type type = AssemblyLoader.GetType(typeAttr.Value, this.baseType.Assembly);
                        if (type == null)
                        {
                            errors.Add(string.Format("Exception occured in MyCodeDomDesignerLoader.ReadProperty():{0}Item type '{1}' could not be found - on object '{2}' and value '{3}'", Environment.NewLine, typeAttr.Value, instance, oldValue));
                            continue;
                        }

                        if (ReadValue(child, TypeDescriptor.GetConverter(type), errors, out newValue, instance, prop))
                        {
                            try { ((IList)oldValue).Add(newValue); }
                            catch (Exception ex) { if (newValue != null) errors.Add(string.Format("Exception occured in MyCodeDomDesignerLoader.ReadProperty():{0}'{1}' - on object '{2}' and value '{3}'", Environment.NewLine, ex.Message, instance, oldValue)); }
                        }
                    }
                    else
                        errors.Add(string.Format("Only Item elements are allowed in collections, not {0} elements.", child.Name));
                }
            }
            else if (oldValue != null && prop.Attributes.Contains(DesignerSerializationVisibilityAttribute.Content))
            {
                // Handle the case of a content property that consists of child properties.
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name.Equals("Property"))
                        ReadProperty(child, oldValue, errors);
                    else
                        errors.Add(string.Format("Only Property elements are allowed in content properties, not {0} elements.", child.Name));
                }
            }
            else
            {
                if (ReadValue(node, prop.Converter, errors, out newValue, instance, prop))
                {
                    // ReadValue succeeded.  Fill in the property value.
                    try
                    {
                        if (newValue == null || !newValue.Equals(oldValue))
                            prop.SetValue(instance, newValue);
                    }
                    catch (Exception ex)
                    {
                        errors.Add(string.Format("Set Property '{0}' to value '{1}' : throw {2}", prop.Name, newValue, ex.Message));
                    }
                }
            }
        }

        private object ReadReference(XmlNode node, object instance, PropertyDescriptor property, IList errors)
        {
            XmlAttribute nameAttr = node.Attributes["name"];
            if (nameAttr == null)
            {
                errors.Add("No name attribute on reference");
                return null;
            }

            object ret = this.htReference[nameAttr.Value];
            if (ret != null)
                return ret;

            if (instance != null && property != null)
                this.alLateReference.Add(new Reference(instance, property, nameAttr.Value));
            return null;
        }

        /// <summary>
        /// Generic function to read an object value.  Returns true if the read succeeded.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="converter"></param>
        /// <param name="errors"></param>
        /// <param name="value"></param>
        /// <param name="instance"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private bool ReadValue(XmlNode node, TypeConverter converter, IList errors, out object value, object instance, PropertyDescriptor property)
        {
            try
            {
                if (node.Attributes["xsi:nil"] != null && bool.Parse(node.Attributes["xsi:nil"].Value))
                {
                    value = null;
                    return true;
                }

                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.NodeType == XmlNodeType.Text)
                    {
                        XmlAttribute typeAttr = GetTypeAttribute(child.ParentNode);
                        if (!converter.CanConvertFrom(typeof(string)) || typeAttr != null && property != null && property.PropertyType == typeof(object))
                        {
                            try
                            {
                                value = Convert.ChangeType(node.InnerText, AssemblyLoader.GetType(typeAttr.Value));
                            }
                            catch
                            {
                                if (System.Diagnostics.Debugger.IsAttached)
                                    System.Diagnostics.Debugger.Break();
                                value = node.InnerText;
                            }
                        }
                        else
                            value = converter.ConvertFromInvariantString(node.InnerText);

                        return true;
                    }
                    else if (child.Name.Equals("Binary"))
                    {
                        byte[] data = Convert.FromBase64String(child.InnerText);

                        // Binary blob.  Now, check to see if the type converter
                        // can convert it.  If not, use serialization.
                        //
                        if (GetConversionSupported(converter, typeof(byte[])))
                        {
                            value = converter.ConvertFrom(null, CultureInfo.InvariantCulture, data);
                            return true;
                        }
                        else
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            MemoryStream stream = new MemoryStream(data);
                            value = formatter.Deserialize(stream);
                            return true;
                        }
                    }
                    else if (child.Name.Equals("InstanceDescriptor"))
                    {
                        value = ReadInstanceDescriptor(child, errors);
                        return (value != null);
                    }
                    else if (child.Name.Equals("Reference"))
                    {
                        value = ReadReference(child, instance, property, errors);
                        return (value != null);
                    }
                    else
                    {
                        errors.Add(string.Format("Unexpected element type '{0}' found in defined xml.{2}{2}OuterXml:{2}{1}{2}{2}Exception occured in MyCodeDomDesignerLoader.ReadValue().", child.Name, node == null ? "unknown" : node.OuterXml, Environment.NewLine));
                        value = null;
                        return false;
                    }
                }

                // If we get here, it is because there were no nodes.  No nodes and no inner
                // text is how we signify null.
                if (node.GetNamespaceOfPrefix("xsi") == string.Empty)
                    value = null;
                else
                    value = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errors.Add(string.Format("Exception occured in MyCodeDomDesignerLoader.ReadValue():{2}{2}{0}{2}{2}OuterXml:{2}{1}", ex.Message, node == null ? "unknown" : node.OuterXml, Environment.NewLine));
                value = null;
                return false;
            }
        }

        private XmlAttribute SetTypeAttribute(XmlDocument xmlDoc, XmlNode node, Type type)
        {
            XmlAttribute typeAttr = GetTypeAttribute(node);
            if (typeAttr == null)
            {
                typeAttr = xmlDoc.CreateAttribute("xsi", "type", nsSchemaInstance);
                switch (type.Assembly.ManifestModule.Name)
                {
                    case "mscorlib.dll":
                    case "System.Drawing.dll":
                    case "System.Windows.Forms.dll":
                        typeAttr.Value = type.FullName;
                        break;

                    case "KiSS4.DB.dll":
                    case "KiSS4.Gui.dll":
                    case "KiSS4.Common.dll":
                    case "KiSS4.Dokument.dll":
                        typeAttr.Value = type.FullName;
                        break;

                    default:
                        if (this.qryXClassReference.Find(string.Format("FullName = '{0}'", type.FullName.Replace("'", "''"))))
                            typeAttr.Value = type.FullName;
                        else
                            typeAttr.Value = type.AssemblyQualifiedName;
                        break;
                }
                node.Attributes.Append(typeAttr);
            }

            return typeAttr;
        }

        /// <summary>
        /// Writes the given IList contents into the given parent node.
        /// </summary>
        /// <param name="document"></param>
        /// <param name="list"></param>
        /// <param name="parent"></param>
        private void WriteCollection(XmlDocument document, IList list, XmlNode parent)
        {
            foreach (object obj in list)
            {
                XmlNode node = document.CreateElement("Item");

                SetTypeAttribute(document, node, obj.GetType());

                if (WriteValue(document, obj, node))
                    parent.AppendChild(node);
            }
        }

        /// <summary>
        /// Save all controls to database
        /// </summary>
        /// <returns>true if success, false if exception occured</returns>
        private bool WriteControls(Control parent, IDictionary nametable)
        {
            foreach (Control child in parent.Controls)
            {
                if (child.Site != null && child.Site.Container == host.Container)
                {
                    if (!qryXClassControl.Find(string.Format("ControlName = '{0}'", child.Site.Name)))
                    {
                        this.qryXClassControl.Insert("XClassControl");
                        this.qryXClassControl["ClassName"] = this.className;
                    }
                    this.qryXClassControl["ControlName"] = child.Site.Name;
                    this.qryXClassControl["ParentControl"] = parent == host.RootComponent ? null : parent.Site.Name;

                    IKissBindableEdit iKissBindableEdit = child as IKissBindableEdit;
                    if (iKissBindableEdit != null)
                    {
                        if (iKissBindableEdit.DataSource == null)
                            this.qryXClassControl["DataSource"] = null;
                        else if (((IComponent)iKissBindableEdit.DataSource).Site != null)
                            this.qryXClassControl["DataSource"] = ((IComponent)iKissBindableEdit.DataSource).Site.Name;

                        this.qryXClassControl["DataMember"] = iKissBindableEdit.DataMember;
                    }

                    this.qryXClassControl["TypeName"] = child.GetType().FullName;
                    this.qryXClassControl["X"] = child.Location.X;
                    this.qryXClassControl["Y"] = child.Location.Y;
                    this.qryXClassControl["Width"] = child.Width;
                    this.qryXClassControl["Height"] = child.Height;
                    this.qryXClassControl["TabIndex"] = child.TabIndex;

                    this.qryXClassControl["PropertiesXML"] = WritePropertiesXML(nametable, child);

                    foreach (DataColumn col in this.qryXClassControl.DataTable.Columns)
                    {
                        if (qryXClassControl.ColumnModified(col.ColumnName))
                        {
                            this.qryXClassControl.Post("XClassControl");
                            break;
                        }
                    }
                    this.qryXClassControl.Row.AcceptChanges();
                    this.qryXClassControl.RowModified = false;

                    if (child.Controls.Count > 0)
                        WriteControls(child, nametable);
                }
            }

            return true;
        }

        /// <summary>
        /// This method writes a given instance descriptor into the XML document, returning a node
        /// that it just created.  Instance descriptors have the following XML:
        /// 
        /// <c>
        /// <InstanceDescriptor xsi:type="">
        ///		<Argument name="" xsi:type=""></Argument>
        ///     <Property name=""></Property>
        /// </InstanceDescriptor>
        /// </c>
        /// 
        /// Here, member is a 64 bit encoded string representing the member, and there is one Parameter
        /// tag for each parameter of the descriptor.
        /// </summary>
        private XmlNode WriteInstanceDescriptor(XmlDocument document, InstanceDescriptor desc, object value)
        {
            XmlNode node = document.CreateElement("InstanceDescriptor");
            SetTypeAttribute(document, node, desc.MemberInfo.DeclaringType);

            ParameterInfo[] paramInfo = ((MethodBase)desc.MemberInfo).GetParameters();

            int i = 0;
            foreach (object arc in desc.Arguments)
            {
                XmlNode argNode = document.CreateElement("Argument");
                if (WriteValue(document, arc, argNode))
                {
                    SetXmlAttribute(document, argNode, "name", paramInfo[i].Name);
                    SetTypeAttribute(document, argNode, paramInfo[i].ParameterType);

                    node.AppendChild(argNode);
                }
                i++;
            }

            // Instance descriptors also support "partial" creation, where
            // properties must also be persisted.
            if (!desc.IsComplete)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(value, propertyAttributes);
                WriteProperties(document, props, value, node, "Property");
            }

            return node;
        }

        /// <summary>
        /// This method writes the given object out to the XML document.  Objects have
        /// the following XML:
        /// 
        /// <c>
        /// <Object type="<object type>" name="<object name>" children="<child property name>">
        /// 
        /// </Object>
        /// </c>
        /// 
        /// Here, Object is the element that defines a custom object.  Type is required
        /// and specifies the data type of the object.  Name is optional.  If present, it names
        /// this object, adding it to the container if the object is an IComponent.
        /// Finally, the children attribute is optional.  If present, this object can have
        /// nested objects, and those objects will be added to the given property name.  The
        /// property must be a collection property that returns an object that implements IList.
        /// 
        /// Inside the object tag there can be zero or more of the following subtags:
        /// 
        ///		InstanceDescriptor -- describes how to create an instance of the object.
        ///		Property -- a property set on the object
        ///		Event -- an event binding
        ///		Binary -- binary data
        /// </summary>
        private XmlNode WriteObject(XmlDocument document, IDictionary nametable, object value)
        {
            Debug.Assert(value != null, "Should not invoke WriteObject with a null value");

            XmlNode node = document.CreateElement("Object");
            SetTypeAttribute(document, node, value.GetType());

            // Does this object have a name?
            //
            IComponent component = value as IComponent;
            if (component != null && component.Site != null && component.Site.Name != null)
            {
                Debug.Assert(nametable[component] == null, "WriteObject should not be called more than once for the same object.  Use WriteReference instead");
                nametable[value] = component.Site.Name;

                SetXmlAttribute(document, node, "name", component.Site.Name);
            }

            // Special case:  We want Windows Forms controls to "nest", so child
            // elements are child controls on the form.  This requires either an
            // extensible serialization mechanism (like the existing CodeDom
            // serialization scheme), or it requires special casing in the
            // serialization code.  We choose the latter in order to make
            // this example easier to understand.
            //
            bool isControl = (value is Control);

            if (component != null)
            {
                // Now do our own properties.
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);

                // We have a component.  Write out the definition for the component here.  If the
                // component is also a control, recurse so we build up the parent hierarchy.
                //
                if (isControl)
                {
                    // If we are a control and we can locate the control property, we should remove
                    // the property from the collection. The collection that comes back from TypeDescriptor
                    // is read-only, however, so we must clone it first.
                    //
                    PropertyDescriptor controlProp = properties["Controls"];
                    if (controlProp != null)
                    {
                        PropertyDescriptor[] propArray = new PropertyDescriptor[properties.Count - 1];
                        int idx = 0;
                        foreach (PropertyDescriptor p in properties)
                        {
                            if (p != controlProp)
                                propArray[idx++] = p;
                        }

                        properties = new PropertyDescriptorCollection(propArray);
                    }
                }

                WriteProperties(document, properties, value, node, "Property");

                EventDescriptorCollection events = TypeDescriptor.GetEvents(value, propertyAttributes);
                IEventBindingService bindings = host.GetService(typeof(IEventBindingService)) as IEventBindingService;
                if (bindings != null)
                {
                    properties = bindings.GetEventProperties(events);
                    WriteProperties(document, properties, value, node, "Event");
                }
            }
            else
            {
                // Not a component, so we just write out the value.
                WriteValue(document, value, node);
            }

            return node;
        }

        /// <summary>
        /// This method writes zero or more property elements into the given parent node.  
        /// </summary>
        private void WriteProperties(XmlDocument document, PropertyDescriptorCollection properties, object value, XmlNode parent, string elementName)
        {
            foreach (PropertyDescriptor prop in properties)
            {
                if ((prop.Attributes[typeof(DesignOnlyAttribute)] == DesignOnlyAttribute.No || prop.DisplayName == "Modifiers") && prop.ShouldSerializeValue(value))
                {
                    XmlNode node = document.CreateElement(elementName);
                    SetXmlAttribute(document, node, "name", prop.Name);

                    DesignerSerializationVisibilityAttribute visibility = (DesignerSerializationVisibilityAttribute)prop.Attributes[typeof(DesignerSerializationVisibilityAttribute)];
                    switch (visibility.Visibility)
                    {
                        case DesignerSerializationVisibility.Hidden:
                            if (prop.DisplayName == "Modifiers")
                                goto case DesignerSerializationVisibility.Visible;
                            break;

                        case DesignerSerializationVisibility.Visible:
                            if (!prop.IsReadOnly && WriteValue(document, prop.GetValue(value), node))
                            {
                                if (value is DevExpress.Utils.FormatInfo && prop.Name == "FormatType" && parent.ChildNodes.Count > 0)
                                    parent.InsertBefore(node, parent.FirstChild);
                                else
                                    parent.AppendChild(node);
                            }
                            break;

                        case DesignerSerializationVisibility.Content:
                            // A "Content" property needs to have its properties stored here, not the actual value.  We
                            // do another special case here to account for collections.  Collections are content properties
                            // that implement IList and are read-only.
                            //
                            object propValue = prop.GetValue(value);

                            if (typeof(IList).IsAssignableFrom(prop.PropertyType))
                            {
                                WriteCollection(document, (IList)propValue, node);
                            }
                            else
                            {
                                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(propValue, propertyAttributes);
                                WriteProperties(document, props, propValue, node, elementName);
                            }

                            if (node.ChildNodes.Count > 0)
                            {
                                parent.AppendChild(node);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private string WritePropertiesXML(IDictionary nametable, IComponent value)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("xsi", nsSchemaInstance);

            xmlDoc.AppendChild(WriteObject(xmlDoc, nametable, value));

            RemoveXMLNode(xmlDoc.SelectSingleNode("/Object/@name"));

            if (value == host.RootComponent)
            {
                RemoveXMLNode(xmlDoc.SelectSingleNode("/Object/Property[@name='AutoScaleBaseSize']"));
            }
            else if (value is Control)
            {
                RemoveXMLNode(xmlDoc.SelectSingleNode("/Object/Property[@name='Name']"));
                RemoveXMLNode(xmlDoc.SelectSingleNode("/Object/Property[@name='Location']"));
                RemoveXMLNode(xmlDoc.SelectSingleNode("/Object/Property[@name='Size']"));
                RemoveXMLNode(xmlDoc.SelectSingleNode("/Object/Property[@name='TabIndex']"));
            }
            if (value is IKissBindableEdit)
            {
                RemoveXMLNode(xmlDoc.SelectSingleNode("/Object/Property[@name='DataSource']"));
                RemoveXMLNode(xmlDoc.SelectSingleNode("/Object/Property[@name='DataMember']"));
            }
            else if (value is SqlQuery)
            {
                RemoveXMLNode(xmlDoc.SelectSingleNode("/Object/Property[@name='TableName']"));
                RemoveXMLNode(xmlDoc.SelectSingleNode("/Object/Property[@name='SelectStatement']"));
            }

            StringWriter sw = new StringWriter();
            XmlTextWriter xtw = new XmlTextWriter(sw);
            xtw.Formatting = Formatting.Indented;
            xmlDoc.WriteTo(xtw);
            string xml = sw.ToString();
            sw.Close();

            return xml;
        }

        /// <summary>
        /// Writes a reference to the given component.  Emits the following
        /// XML:
        /// 
        /// <c>
        /// <Reference name="component name"></Reference>
        /// </c>
        /// </summary>
        private XmlNode WriteReference(XmlDocument document, IComponent value)
        {
            Debug.Assert(value != null && value.Site != null && value.Site.Container == host.Container, "Invalid component passed to WriteReference");

            XmlNode node = document.CreateElement("Reference");
            SetXmlAttribute(document, node, "name", value.Site.Name);

            return node;
        }

        /// <summary>
        /// This method writes the given object into the given parent node.  It returns
        /// true if it was successful, or false if it was unable to convert the object
        /// to XML.
        /// </summary>
        private bool WriteValue(XmlDocument document, object value, XmlNode parent)
        {
            // For empty values, we just return.  This creates an empty node.
            if (value == null)
            {
                XmlAttribute nilAttr = parent.OwnerDocument.CreateAttribute("xsi", "nil", nsSchemaInstance);
                nilAttr.Value = true.ToString();
                parent.Attributes.Append(nilAttr);

                return true;
            }

            TypeConverter converter = TypeDescriptor.GetConverter(value);

            if (value is IComponent && ((IComponent)value).Site != null && ((IComponent)value).Site.Container == host.Container)
            {
                // IComponent.  Treat this as a reference.
                //
                parent.AppendChild(WriteReference(document, (IComponent)value));
            }
            else if (GetConversionSupported(converter, typeof(string)))
            {
                // Strings have the most fidelity.  If this object
                // supports being converted to a string, do so, and then
                // we're done.
                //
                SetTypeAttribute(parent.OwnerDocument, parent, value.GetType());
                parent.InnerText = (string)converter.ConvertTo(null, CultureInfo.InvariantCulture, value, typeof(string));
            }
            else if (GetConversionSupported(converter, typeof(InstanceDescriptor)))
            {
                // InstanceDescriptors are encoded as an InstanceDescriptor element.
                //
                InstanceDescriptor id = (InstanceDescriptor)converter.ConvertTo(null, CultureInfo.InvariantCulture, value, typeof(InstanceDescriptor));
                XmlNode nodeObject = parent.AppendChild(WriteInstanceDescriptor(document, id, value));

                if (value is DevExpress.XtraBars.LinkPersistInfo)
                {
                    DevExpress.XtraBars.LinkPersistInfo linkPersistInfo = (DevExpress.XtraBars.LinkPersistInfo)value;

                    XmlNode nodeProperty = parent.OwnerDocument.CreateElement("Property");
                    SetXmlAttribute(parent.OwnerDocument, nodeProperty, "name", "Item");
                    if (WriteValue(document, linkPersistInfo.Item, nodeProperty))
                        nodeObject.AppendChild(nodeProperty);

                    nodeProperty = parent.OwnerDocument.CreateElement("Property");
                    SetXmlAttribute(parent.OwnerDocument, nodeProperty, "name", "Link");
                    if (WriteValue(document, linkPersistInfo.Link, nodeProperty))
                        nodeObject.AppendChild(nodeProperty);
                }
            }
            else if (GetConversionSupported(converter, typeof(byte[])))
            {
                // Binary blobs are converted by encoding as a binary element.
                //
                byte[] data = (byte[])converter.ConvertTo(null, CultureInfo.InvariantCulture, value, typeof(byte[]));
                parent.AppendChild(WriteBinary(document, data));
            }
            else if (value.GetType().IsSerializable)
            {
                // Finally, check to see if this object is serializable.  If it is, we serialize it here
                // and then write it as a binary.
                //
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();
                formatter.Serialize(stream, value);
                XmlNode binaryNode = WriteBinary(document, stream.ToArray());
                parent.AppendChild(binaryNode);
            }
            else if (value is KeyShortcut && (KeyShortcut)value == KeyShortcut.Empty)
            {
                XmlNode nodeObject = parent.OwnerDocument.CreateElement("InstanceDescriptor");
                SetTypeAttribute(parent.OwnerDocument, nodeObject, value.GetType());

                parent.AppendChild(nodeObject);
            }
            else if (value.GetType().GetConstructor(new Type[] { }) != null)
            {
                XmlNode nodeObject = parent.OwnerDocument.CreateElement("InstanceDescriptor");
                SetTypeAttribute(parent.OwnerDocument, nodeObject, value.GetType());

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
                WriteProperties(document, properties, value, nodeObject, "Property");

                parent.AppendChild(nodeObject);
            }
            else
                return false;

            return true;
        }

        #endregion

        #endregion

        #region Nested Types

        private class Reference
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public readonly string TagetName;

            #endregion

            #region Private Constant/Read-Only Fields

            private readonly object instance;
            private readonly PropertyDescriptor property;

            #endregion

            #endregion

            #region Constructors

            public Reference(object instance, string propertyName, string targetName)
                : this(instance, TypeDescriptor.GetProperties(instance)[propertyName], targetName)
            {
            }

            public Reference(object instance, PropertyDescriptor property, string targetName)
            {
                this.instance = instance;
                this.property = property;
                this.TagetName = targetName;
            }

            #endregion

            #region Methods

            #region Public Methods

            public override bool Equals(object obj)
            {
                if (obj is Reference)
                {
                    if (((Reference)obj).instance == this.instance
                        && ((Reference)obj).property == this.property
                        && ((Reference)obj).TagetName == this.TagetName)
                        return true;
                }

                return false;
            }

            public override int GetHashCode()
            {
                return instance.GetHashCode() | this.TagetName.GetHashCode();
            }

            public void SetValue(object value)
            {
                if (value == null)
                    return;
                object propValue = property.GetValue(instance);

                // Handle the case of a content property that is a collection.
                if (propValue is IList && !(value is IList))
                {
                    if (instance is DevExpress.XtraGrid.GridControl && property.Name == "ViewCollection" && ((IList)propValue).Contains(value))
                        return;
                    ((IList)propValue).Add(value);
                }
                else
                    property.SetValue(instance, value);
            }

            #endregion

            #endregion
        }

        #endregion
    }
}