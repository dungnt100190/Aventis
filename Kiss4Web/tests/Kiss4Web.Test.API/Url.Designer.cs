﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kiss4Web.Test.API {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Url {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Url() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Kiss4Web.Test.API.Url", typeof(Url).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /api/Pendenzen/CreateUpdateTask.
        /// </summary>
        internal static string CreateUpdateTask {
            get {
                return ResourceManager.GetString("CreateUpdateTask", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /api/Pendenzen/GetPendenzenData/{0}.
        /// </summary>
        internal static string GetPendenzenData {
            get {
                return ResourceManager.GetString("GetPendenzenData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /api/Pendenzen/GetPendenzenDetail/{0}.
        /// </summary>
        internal static string GetPendenzenDetail {
            get {
                return ResourceManager.GetString("GetPendenzenDetail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /api/Pendenzen/LoadNavBarItems.
        /// </summary>
        internal static string LoadNavBarItems {
            get {
                return ResourceManager.GetString("LoadNavBarItems", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /api/Pendenzen/Search.
        /// </summary>
        internal static string SearchPendenzen {
            get {
                return ResourceManager.GetString("SearchPendenzen", resourceCulture);
            }
        }
    }
}
