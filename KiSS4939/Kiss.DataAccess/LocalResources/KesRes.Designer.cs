﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kiss.DataAccess.LocalResources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class KesRes {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal KesRes() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Kiss.DataAccess.LocalResources.KesRes", typeof(KesRes).Assembly);
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
        ///   Looks up a localized string similar to Das Abschlussdatum muss nach dem Auftragsdatum sein..
        /// </summary>
        internal static string AbschlussDatumGroesserDatumAuftrag {
            get {
                return ResourceManager.GetString("AbschlussDatumGroesserDatumAuftrag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Datum Auftrag.
        /// </summary>
        internal static string DatumAuftrag {
            get {
                return ResourceManager.GetString("DatumAuftrag", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Das Datum ist früher als das KES-Eröffnungsdatum ({0:dd.MM.yyyy})..
        /// </summary>
        internal static string ErrorKesMandatVorEroeffnung {
            get {
                return ResourceManager.GetString("ErrorKesMandatVorEroeffnung", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Beschluss vom.
        /// </summary>
        internal static string MassnahmeAuftragBeschlussVom {
            get {
                return ResourceManager.GetString("MassnahmeAuftragBeschlussVom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erledigung bis.
        /// </summary>
        internal static string MassnahmeAuftragErledigungBis {
            get {
                return ResourceManager.GetString("MassnahmeAuftragErledigungBis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Der Kanton der KES-Behörde bei der Übernahme stimmt nicht mit dem Kanton des Ortes überein..
        /// </summary>
        internal static string UebernahmeKantonOrtBehoerdeNichtUebereinstimmend {
            get {
                return ResourceManager.GetString("UebernahmeKantonOrtBehoerdeNichtUebereinstimmend", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bei einer Übernahme muss ein Ort oder eine KES-Behörde angegeben werden..
        /// </summary>
        internal static string UebernahmeOrtBehoerdeFehlt {
            get {
                return ResourceManager.GetString("UebernahmeOrtBehoerdeFehlt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Der Kanton der KES-Behörde bei der Übertragung stimmt nicht mit dem Kanton des Ortes überein..
        /// </summary>
        internal static string UebertragungKantonOrtBehoerdeNichtUebereinstimmend {
            get {
                return ResourceManager.GetString("UebertragungKantonOrtBehoerdeNichtUebereinstimmend", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bei einer Übertragung muss ein Ort oder eine KES-Behörde angegeben werden..
        /// </summary>
        internal static string UebertragungOrtBehoerdeFehlt {
            get {
                return ResourceManager.GetString("UebertragungOrtBehoerdeFehlt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to VerfasserIn.
        /// </summary>
        internal static string VerlaufUndDokumentUser {
            get {
                return ResourceManager.GetString("VerlaufUndDokumentUser", resourceCulture);
            }
        }
    }
}
