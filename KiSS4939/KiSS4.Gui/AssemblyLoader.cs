using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Windows.Forms;
using Kiss.Infrastructure.IoC;
using KiSS4.DB;
using log4net;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for AssemblyLoader.
    /// </summary>
    public class AssemblyLoader
    {
        #region Fields

        #region Public Static Fields

        /// <summary>
        /// <c>BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance</c>
        /// </summary>
        public static BindingFlags BindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        #endregion

        #region Private Static Fields

        private static readonly Hashtable _loadedAssemblies = new Hashtable();
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly Hashtable _typeCache = new Hashtable();

        private static bool _assemblyLoaded;
        private static SqlQuery _qryXClass;

        #endregion

        #endregion

        #region Constructors

        private AssemblyLoader()
        {
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Removes all elements from KiSS-Assemblycache
        /// </summary>
        public static void Clear()
        {
            _typeCache.Clear();
            _qryXClass = null;
        }

        /// <summary>
        /// Create new Instance of Object
        /// </summary>
        /// <param name="className">Name of Type</param>
        /// <param name="args">Constructor Parameters</param>
        /// <returns>Instance of object</returns>
        public static object CreateInstance(string className, params object[] args)
        {
            return CreateInstance(GetType(className, Assembly.GetCallingAssembly()), args);
        }

        /// <summary>
        /// Create new Instance of Object
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="args">Constructor Parameters</param>
        /// <returns>Instance of object</returns>
        public static object CreateInstance(Type type, params object[] args)
        {
            if (type == null) return null;

            ConstructorInfo ci = type.GetConstructor(GetTypeList(args));

            if (ci == null)
            {
                throw new ArgumentException(type.FullName + " has no matching public instance constructor.");
            }

            try
            {
                return ci.Invoke(args);
            }
            catch (TargetInvocationException ex)
            {
                throw PrepareException(ex);
            }
        }

        /// <summary>
        /// Compress the byte array with GZip.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static byte[] GZipCompress(byte[] input)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (GZipStream gZipStream = new GZipStream(ms, CompressionMode.Compress, true))
                    {
                        gZipStream.Write(input, 0, input.Length);
                        gZipStream.Close();
                    }

                    if (input.Length > ms.ToArray().Length)
                        return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
            }

            return input;
        }

        /// <summary>
        /// Decompress the data with GZip.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static byte[] GZipDecompress(byte[] input)
        {
            try
            {
                using (GZipStream gZipStream = new GZipStream(new MemoryStream(input), CompressionMode.Decompress))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        StreamCopy(gZipStream, ms);
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Debug(ex);
            }
            return input;
        }

        public static string GetKissModulTreeClassName(int modulID)
        {
            if (QryXClassFind(string.Format("ModulID = {0} AND BaseType = 'KiSS4.Common.KissModulTree'", modulID)))
            {
                return _qryXClass["ClassName"] as string;
            }
            return null;
        }

        /// <summary>
        /// Create new Instance of KiSS4.Common.KissModulTree for ModulID
        /// </summary>
        /// <param name="modulID">MdoulID</param>
        /// <param name="baPersonID">BaPersonID</param>
        /// <param name="faFallID">FaFallID</param>
        /// <param name="pnlDetail">Target Panel</param>
        /// <returns></returns>
        public static KissUserControl GetKissModulTree(int modulID, int baPersonID, int faFallID, Panel pnlDetail)
        {
            var className = GetKissModulTreeClassName(modulID);
            if (className != null)
            {
                try
                {
                    return CreateInstance(className, baPersonID, faFallID, pnlDetail) as KissUserControl;
                }
                catch
                {
                    return CreateInstance(className, baPersonID, pnlDetail) as KissUserControl;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the kiss modul tree.
        /// </summary>
        /// <param name="modulID">The modul ID.</param>
        /// <param name="baPersonID">The ba person ID.</param>
        /// <param name="pnlDetail">The PNL detail.</param>
        /// <returns></returns>
        [Obsolete("Use GetKissModulTree(modulID, baPersonID, faFallID, pnlDetail)")]
        public static KissUserControl GetKissModulTree(int modulID, int baPersonID, Panel pnlDetail)
        {
            return GetKissModulTree(modulID, baPersonID, -1, pnlDetail);
        }

        /// <summary>
        /// Dynamic Get of Property or Member value
        /// </summary>
        /// <param name="instance">Reference to Objectinstance</param>
        /// <param name="name">Name of Property or Member</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        public static object GetPropertyValue(object instance, string name)
        {
            try
            {
                Type t = GetType(ref instance);

                PropertyInfo pi = t.GetProperty(name, BindingFlags);

                if (pi != null)
                {
                    return pi.GetValue(instance, new object[0]);
                }

                FieldInfo fi = GetFieldInfo(t, name);

                if (fi != null)
                {
                    return fi.GetValue(instance);
                }

                throw new ArgumentException(string.Format("Property / Member '{0}.{1}' not found", t, name), "name");
            }
            catch (TargetInvocationException ex)
            {
                throw PrepareException(ex);
            }
        }

        /// <summary>
        /// Return Type of TypeName (without or with Namespace)
        /// </summary>
        /// <param name="typeName">Name as Type</param>
        /// <returns>Type</returns>
        public static Type GetType(Type typeName)
        {
            return GetType(typeName, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// Return Type of TypeName (without or with Namespace)
        /// </summary>
        /// <param name="typeName">Name of Type</param>
        /// <returns>Type</returns>
        public static Type GetType(string typeName)
        {
            return GetType(typeName, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// Return Type of TypeName (without or with Namespace)
        /// </summary>
        /// <param name="typeName">Name as Type</param>
        /// <param name="primaryAsm">Search first in this Assembly</param>
        /// <returns>Type</returns>
        public static Type GetType(Type typeName, Assembly primaryAsm)
        {
            Type type = GetType(typeName.FullName, primaryAsm);

            return type ?? typeName;
        }

        /// <summary>
        /// Return Type of TypeName (without or with Namespace)
        /// </summary>
        /// <param name="typeName">Name of Type</param>
        /// <param name="primaryAsm">Search first in this Assembly</param>
        /// <returns>Type</returns>
        public static Type GetType(string typeName, Assembly primaryAsm)
        {
            return GetType(typeName, primaryAsm, false, false);
        }

        /// <summary>
        /// Return Type of TypeName (without or with Namespace)
        /// </summary>
        /// <param name="typeName">Name of Type</param>
        /// <param name="throwOnError"></param>
        /// <param name="ignoreCase"></param>
        /// <returns>Type</returns>
        public static Type GetType(string typeName, bool throwOnError, bool ignoreCase)
        {
            return GetType(typeName, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// Return Type of TypeName (without or with Namespace)
        /// </summary>
        /// <param name="typeName">Name of Type</param>
        /// <param name="primaryAsm">Search first in this Assembly</param>
        /// <param name="throwOnError"></param>
        /// <param name="ignoreCase"></param>
        /// <returns>Type</returns>
        public static Type GetType(string typeName, Assembly primaryAsm, bool throwOnError, bool ignoreCase)
        {
            if (typeName == null || typeName.Trim() == string.Empty)
            {
                return null;
            }

            Type type = null;

            if (typeName.IndexOf(',') > 0)
            {
                type = GetType(typeName.Substring(0, typeName.IndexOf(',')), primaryAsm, false, ignoreCase);

                if (type != null)
                {
                    return type;
                }
            }

            // HACK: für WPF-Control
            // Damit hier ein WPF-Control geladen werden kann,
            // muss hier zwischen den alten KissUserControls und WPF-Controls unterschieden werden.
            // Wir benutzen hierzu den Klassennamen aus XClass (z.B. "Kiss.UI.View.Fs.FsDienstleistungen.xaml").
            if (typeName.EndsWith(".xaml"))
            {
                string typeNameWithNamespace = typeName.Replace(".xaml", "");

                //Die dynamisch zu ladenden Views sind immer im Assembly Kiss.UI.View.
                //Klassen aus Kiss.UI.Compoments werden nicht hier instanziert.

                //Aufteilen in Klassennamen und Namespacenamen.
                string typeNameWithoutNameSpace = typeNameWithNamespace.Substring(typeNameWithNamespace.LastIndexOf(".") + 1);
                string nameSpace = typeName.Substring(0, typeNameWithNamespace.LastIndexOf("."));

                try
                {
                    type = TypeLoader.GetType(typeNameWithoutNameSpace, nameSpace, "Kiss.UI.View");
                }
                catch (Exception) { }

                if (type == null)
                {
                    type = TypeLoader.GetType(typeNameWithoutNameSpace, nameSpace, "Kiss.UserInterface.View");
                }

                return type;
            }

            // Resolve Typename
            if (Session.SupportDynaMask && typeName == "CtlDynaMask")
            {
                typeName = "KiSS4.Common.CtlDynaMask";
            }
            else if (typeName.IndexOf(".") == -1)
            {
                if (QryXClassFind(string.Format("ClassName = '{0}'", typeName)))
                {
                    typeName = (string)_qryXClass["TypeName"];
                }
                else
                {
                    return null;
                }
            }

            /*
            // Dynamic Type
            if (typeName.ToUpper().StartsWith("KISS4.") || typeName.ToUpper().StartsWith("KISS."))
            {
                string className = typeName.Substring(typeName.LastIndexOf(".") + 1);

                type = _typeCache[className] as Type;
                if (type != null) return type;

                if (QryXClassFind(string.Format("TypeName = '{0}'", typeName)) && (bool)_qryXClass["Assembly"])
                {
                    byte[] assembly = DBUtil.ExecuteScalarSQL(@"
                        SELECT Assembly
                        FROM XClass
                        WHERE ClassName = CONVERT(varchar(255), {0})", className) as byte[];

                    if (assembly != null)
                    {
                        Assembly asm = Assembly.Load(GZipDecompress(assembly));

                        foreach (Type t in asm.GetTypes())
                        {
                            if (t.Name.Equals(className))
                            {
                                UpdateAssembly(t);
                                return t;
                            }
                        }
                    }
                }
            }
            */

            // Type in same Assembly
            if (primaryAsm != null)
            {
                type = primaryAsm.GetType(typeName, false, ignoreCase);

                if (type != null)
                {
                    return type;
                }
            }

            // Fully qualified Typename
            type = Type.GetType(typeName, false, ignoreCase);

            if (type != null)
            {
                return type;
            }

            // Type in KiSS4.Gui Assembly
            type = typeof(AssemblyLoader).Assembly.GetType(typeName, false, ignoreCase);

            if (type != null)
            {
                return type;
            }

            // Search Type in all loaded Assembly
            do
            {
                foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    type = asm.GetType(typeName, false, ignoreCase);

                    if (type != null)
                    {
                        return type;
                    }
                }
            }
            while (!_assemblyLoaded && LoadProgramAssembly());

            if (throwOnError)
            {
                throw new TypeLoadException();
            }

            return null;
        }

        /// <summary>
        /// Dynamic invoke a Methode
        /// </summary>
        /// <param name="instance">Reference to Objectinstance or Type for static Methodes</param>
        /// <param name="name">Name of Methode</param>
        /// <param name="args">Parametervalue of call</param>
        /// <returns>Returnvalue</returns>
        public static object InvokeMethode(object instance, string name, params object[] args)
        {
            Type t = GetType(ref instance);

            MethodInfo mi = GetMethodInfo(t, name, ref args);

            if (mi == null)
            {
                throw new ArgumentException(t.FullName + " has no matching public method.");
            }

            try
            {
                return mi.Invoke(instance, args);
            }
            catch (TargetInvocationException ex)
            {
                throw PrepareException(ex);
            }
        }

        /// <summary>
        /// Force load DLL "KiSS4.*.dll" in Programdirectory
        /// </summary>
        /// <returns></returns>
        public static bool LoadProgramAssembly()
        {
            if (_assemblyLoaded) return true;
            _assemblyLoaded = true;

            Type type = GetType("KiSS4.UnitTest.BaseTest") ?? GetType("KiSS4.Main.FrmMain");

            DirectoryInfo dir = new FileInfo(type.Assembly.Location).Directory;

            foreach (string dll in Directory.GetFiles(dir.FullName, "KiSS4.*.dll"))
            {
                try
                {
                    LoadReferencedAssemblies(Assembly.LoadFile(dll));
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }

            foreach (string dll in Directory.GetFiles(dir.FullName, "KiSS.*.dll"))
            {
                try
                {
                    LoadReferencedAssemblies(Assembly.LoadFile(dll));
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }

            return true;
        }

        /// <summary>
        /// Remove ClassName from KiSS-Assemblycache
        /// </summary>
        /// <param name="className">Name of the Class without Namespace</param>
        public static void Remove(string className)
        {
            _typeCache.Remove(className);
        }

        /// <summary>
        /// Dynamic Set of Property or Member value
        /// </summary>
        /// <param name="instance">Reference to Objectinstance</param>
        /// <param name="name">Name of Property or Member</param>
        /// <param name="value">new Propertyvalue</param>
        public static void SetPropertyValue(object instance, string name, object value)
        {
            try
            {
                Type t = GetType(ref instance);
                PropertyInfo pi = t.GetProperty(name, BindingFlags);

                if (pi != null)
                {
                    pi.SetValue(instance, value, new object[0]);

                    Control ctl = instance as Control;

                    if (ctl != null && ctl.DataBindings[name] != null)
                    {
                        ctl.DataBindings[name].BindingManagerBase.EndCurrentEdit();
                    }

                    return;
                }

                FieldInfo fi = GetFieldInfo(t, name);

                if (fi != null)
                {
                    fi.SetValue(instance, value);
                    return;
                }

                throw new ArgumentException(string.Format("Property / Member '{0}.{1}' not found", t, name), "name");
            }
            catch (TargetInvocationException ex)
            {
                throw PrepareException(ex);
            }
        }

        /// <summary>
        /// Copy the stream.
        /// </summary>
        /// <param name="srcStream">The SRC stream.</param>
        /// <param name="dstStream">The DST stream.</param>
        /// TODO: Why is the size fixed? Change or comment.
        public static void StreamCopy(Stream srcStream, Stream dstStream)
        {
            byte[] buffer = new byte[32768];
            int read;

            while ((read = srcStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                dstStream.Write(buffer, 0, read);
            }

            dstStream.Flush();
        }

        /// <summary>
        /// Add or Update Class in KiSS-Assemblycache
        /// </summary>
        /// <param name="type"></param>
        public static void UpdateAssembly(Type type)
        {
            if (type == null)
            {
                return;
            }

            _typeCache[type.Name] = type;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Gets the field info.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private static FieldInfo GetFieldInfo(Type type, string name)
        {
            FieldInfo fi = null;

            while (fi == null && type != null)
            {
                fi = type.GetField(name, BindingFlags);
                type = type.BaseType;
            }

            return fi;
        }

        /// <summary>
        /// Gets the method info.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        private static MethodInfo GetMethodInfo(Type type, string name, ref object[] args)
        {
            Type[] types = GetTypeList(args);

            foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags | BindingFlags.InvokeMethod))
            {
                if (methodInfo.Name == name)
                {
                    int i = 0;
                    bool isArray = false;

                    foreach (ParameterInfo param in methodInfo.GetParameters())
                    {
                        isArray = param.ParameterType.IsArray && param.ParameterType.Equals(typeof(object[]));

                        if (!isArray && !(types.Length > i && (types[i] == null || param.ParameterType.IsAssignableFrom(types[i]))))
                        {
                            i++;
                            break;
                        }

                        i++;
                    }

                    if (types.Length == i)
                    {
                        if (isArray && !(args[--i] is object[]))
                        {
                            args[i] = new[] { args[i] };
                        }

                        return methodInfo;
                    }

                    if (isArray)
                    {
                        ArrayList alArgs = new ArrayList(args);

                        if (alArgs.Count < i--)
                        {
                            alArgs.Add(new object[] { });
                        }
                        else
                        {
                            ArrayList alParams = new ArrayList();

                            while (alArgs.Count > i)
                            {
                                alParams.Add(alArgs[i]);
                                alArgs.RemoveAt(i);
                            }

                            alArgs.Add(alParams.ToArray());
                        }

                        args = alArgs.ToArray();

                        return methodInfo;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        private static Type GetType(ref object instance)
        {
            Type t = instance as Type;

            if (t == null)
            {
                t = instance.GetType();
            }
            else
            {
                instance = null;
            }

            return t;
        }

        /// <summary>
        /// Gets the type list.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        private static Type[] GetTypeList(object[] args)
        {
            if (args.Length == 0)
            {
                return new Type[0];
            }

            Type[] types = new Type[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)
                {
                    types[i] = null;
                }
                else
                {
                    types[i] = args[i].GetType();
                }
            }

            return types;
        }

        private static void LoadReferencedAssemblies(Assembly asm)
        {
            if (_loadedAssemblies.Contains(asm.FullName))
            {
                return;
            }

            _loadedAssemblies.Add(asm.FullName, asm.Location);

            foreach (AssemblyName asmName in asm.GetReferencedAssemblies())
            {
                if (!_loadedAssemblies.Contains(asmName.FullName))
                {
                    try
                    {
                        LoadReferencedAssemblies(Assembly.Load(asmName));
                    }
                    catch (Exception ex)
                    {
                        _log.Debug(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Prepares the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        private static Exception PrepareException(TargetInvocationException ex)
        {
            SetPropertyValue(ex.InnerException, "_remoteStackTraceString", ex.InnerException.StackTrace + Environment.NewLine);

            return ex.InnerException;
        }

        private static bool QryXClassFind(string searchExpression)
        {
            if (_qryXClass == null || !_qryXClass.Find(searchExpression))
            {
                _qryXClass = DBUtil.OpenSQL(@"
                    SELECT CLS.ClassName, CLS.ModulID, CLS.BaseType,
                      TypeName = MOD.NameSpace + IsNull('.' + CLS.NamespaceExtension, '') + '.' + CLS.ClassName
                    FROM XClass          CLS
                      INNER JOIN XModul  MOD ON MOD.ModulID = CLS.ModulID");

                if (!_qryXClass.Find(searchExpression))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #endregion
    }
}