﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace KiSS.KliBu.DA
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class KliBuContext : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new KliBuContext object using the connection string found in the 'KliBuContext' section of the application configuration file.
        /// </summary>
        public KliBuContext() : base("name=KliBuContext", "KliBuContext")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new KliBuContext object.
        /// </summary>
        public KliBuContext(string connectionString) : base(connectionString, "KliBuContext")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new KliBuContext object.
        /// </summary>
        public KliBuContext(EntityConnection connection) : base(connection, "KliBuContext")
        {
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<BaBank> BaBank
        {
            get
            {
                if ((_BaBank == null))
                {
                    _BaBank = base.CreateObjectSet<BaBank>("BaBank");
                }
                return _BaBank;
            }
        }
        private ObjectSet<BaBank> _BaBank;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the BaBank EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToBaBank(BaBank baBank)
        {
            base.AddObject("BaBank", baBank);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="KliBuModel", Name="BaBank")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class BaBank : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new BaBank object.
        /// </summary>
        /// <param name="baBankID">Initial value of the BaBankID property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="clearingNr">Initial value of the ClearingNr property.</param>
        /// <param name="filialeNr">Initial value of the FilialeNr property.</param>
        /// <param name="gueltigAb">Initial value of the GueltigAb property.</param>
        /// <param name="sicUpdated">Initial value of the SicUpdated property.</param>
        /// <param name="creator">Initial value of the Creator property.</param>
        /// <param name="created">Initial value of the Created property.</param>
        /// <param name="modifier">Initial value of the Modifier property.</param>
        /// <param name="modified">Initial value of the Modified property.</param>
        /// <param name="baBankTS">Initial value of the BaBankTS property.</param>
        public static BaBank CreateBaBank(global::System.Int32 baBankID, global::System.String name, global::System.String clearingNr, global::System.Int32 filialeNr, global::System.DateTime gueltigAb, global::System.Boolean sicUpdated, global::System.String creator, global::System.DateTime created, global::System.String modifier, global::System.DateTime modified, global::System.Byte[] baBankTS)
        {
            BaBank baBank = new BaBank();
            baBank.BaBankID = baBankID;
            baBank.Name = name;
            baBank.ClearingNr = clearingNr;
            baBank.FilialeNr = filialeNr;
            baBank.GueltigAb = gueltigAb;
            baBank.SicUpdated = sicUpdated;
            baBank.Creator = creator;
            baBank.Created = created;
            baBank.Modifier = modifier;
            baBank.Modified = modified;
            baBank.BaBankTS = baBankTS;
            return baBank;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 BaBankID
        {
            get
            {
                return _BaBankID;
            }
            set
            {
                if (_BaBankID != value)
                {
                    OnBaBankIDChanging(value);
                    ReportPropertyChanging("BaBankID");
                    _BaBankID = StructuralObject.SetValidValue(value, "BaBankID");
                    ReportPropertyChanged("BaBankID");
                    OnBaBankIDChanged();
                }
            }
        }
        private global::System.Int32 _BaBankID;
        partial void OnBaBankIDChanging(global::System.Int32 value);
        partial void OnBaBankIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> LandCode
        {
            get
            {
                return _LandCode;
            }
            set
            {
                OnLandCodeChanging(value);
                ReportPropertyChanging("LandCode");
                _LandCode = StructuralObject.SetValidValue(value, "LandCode");
                ReportPropertyChanged("LandCode");
                OnLandCodeChanged();
            }
        }
        private Nullable<global::System.Int32> _LandCode;
        partial void OnLandCodeChanging(Nullable<global::System.Int32> value);
        partial void OnLandCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false, "Name");
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Zusatz
        {
            get
            {
                return _Zusatz;
            }
            set
            {
                OnZusatzChanging(value);
                ReportPropertyChanging("Zusatz");
                _Zusatz = StructuralObject.SetValidValue(value, true, "Zusatz");
                ReportPropertyChanged("Zusatz");
                OnZusatzChanged();
            }
        }
        private global::System.String _Zusatz;
        partial void OnZusatzChanging(global::System.String value);
        partial void OnZusatzChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Strasse
        {
            get
            {
                return _Strasse;
            }
            set
            {
                OnStrasseChanging(value);
                ReportPropertyChanging("Strasse");
                _Strasse = StructuralObject.SetValidValue(value, true, "Strasse");
                ReportPropertyChanged("Strasse");
                OnStrasseChanged();
            }
        }
        private global::System.String _Strasse;
        partial void OnStrasseChanging(global::System.String value);
        partial void OnStrasseChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PLZ
        {
            get
            {
                return _PLZ;
            }
            set
            {
                OnPLZChanging(value);
                ReportPropertyChanging("PLZ");
                _PLZ = StructuralObject.SetValidValue(value, true, "PLZ");
                ReportPropertyChanged("PLZ");
                OnPLZChanged();
            }
        }
        private global::System.String _PLZ;
        partial void OnPLZChanging(global::System.String value);
        partial void OnPLZChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Ort
        {
            get
            {
                return _Ort;
            }
            set
            {
                OnOrtChanging(value);
                ReportPropertyChanging("Ort");
                _Ort = StructuralObject.SetValidValue(value, true, "Ort");
                ReportPropertyChanged("Ort");
                OnOrtChanged();
            }
        }
        private global::System.String _Ort;
        partial void OnOrtChanging(global::System.String value);
        partial void OnOrtChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ClearingNr
        {
            get
            {
                return _ClearingNr;
            }
            set
            {
                OnClearingNrChanging(value);
                ReportPropertyChanging("ClearingNr");
                _ClearingNr = StructuralObject.SetValidValue(value, false, "ClearingNr");
                ReportPropertyChanged("ClearingNr");
                OnClearingNrChanged();
            }
        }
        private global::System.String _ClearingNr;
        partial void OnClearingNrChanging(global::System.String value);
        partial void OnClearingNrChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ClearingNrNeu
        {
            get
            {
                return _ClearingNrNeu;
            }
            set
            {
                OnClearingNrNeuChanging(value);
                ReportPropertyChanging("ClearingNrNeu");
                _ClearingNrNeu = StructuralObject.SetValidValue(value, true, "ClearingNrNeu");
                ReportPropertyChanged("ClearingNrNeu");
                OnClearingNrNeuChanged();
            }
        }
        private global::System.String _ClearingNrNeu;
        partial void OnClearingNrNeuChanging(global::System.String value);
        partial void OnClearingNrNeuChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 FilialeNr
        {
            get
            {
                return _FilialeNr;
            }
            set
            {
                OnFilialeNrChanging(value);
                ReportPropertyChanging("FilialeNr");
                _FilialeNr = StructuralObject.SetValidValue(value, "FilialeNr");
                ReportPropertyChanged("FilialeNr");
                OnFilialeNrChanged();
            }
        }
        private global::System.Int32 _FilialeNr;
        partial void OnFilialeNrChanging(global::System.Int32 value);
        partial void OnFilialeNrChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HauptsitzBCL
        {
            get
            {
                return _HauptsitzBCL;
            }
            set
            {
                OnHauptsitzBCLChanging(value);
                ReportPropertyChanging("HauptsitzBCL");
                _HauptsitzBCL = StructuralObject.SetValidValue(value, true, "HauptsitzBCL");
                ReportPropertyChanged("HauptsitzBCL");
                OnHauptsitzBCLChanged();
            }
        }
        private global::System.String _HauptsitzBCL;
        partial void OnHauptsitzBCLChanging(global::System.String value);
        partial void OnHauptsitzBCLChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PCKontoNr
        {
            get
            {
                return _PCKontoNr;
            }
            set
            {
                OnPCKontoNrChanging(value);
                ReportPropertyChanging("PCKontoNr");
                _PCKontoNr = StructuralObject.SetValidValue(value, true, "PCKontoNr");
                ReportPropertyChanged("PCKontoNr");
                OnPCKontoNrChanged();
            }
        }
        private global::System.String _PCKontoNr;
        partial void OnPCKontoNrChanging(global::System.String value);
        partial void OnPCKontoNrChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime GueltigAb
        {
            get
            {
                return _GueltigAb;
            }
            set
            {
                OnGueltigAbChanging(value);
                ReportPropertyChanging("GueltigAb");
                _GueltigAb = StructuralObject.SetValidValue(value, "GueltigAb");
                ReportPropertyChanged("GueltigAb");
                OnGueltigAbChanged();
            }
        }
        private global::System.DateTime _GueltigAb;
        partial void OnGueltigAbChanging(global::System.DateTime value);
        partial void OnGueltigAbChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean SicUpdated
        {
            get
            {
                return _SicUpdated;
            }
            set
            {
                OnSicUpdatedChanging(value);
                ReportPropertyChanging("SicUpdated");
                _SicUpdated = StructuralObject.SetValidValue(value, "SicUpdated");
                ReportPropertyChanged("SicUpdated");
                OnSicUpdatedChanged();
            }
        }
        private global::System.Boolean _SicUpdated;
        partial void OnSicUpdatedChanging(global::System.Boolean value);
        partial void OnSicUpdatedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Creator
        {
            get
            {
                return _Creator;
            }
            set
            {
                OnCreatorChanging(value);
                ReportPropertyChanging("Creator");
                _Creator = StructuralObject.SetValidValue(value, false, "Creator");
                ReportPropertyChanged("Creator");
                OnCreatorChanged();
            }
        }
        private global::System.String _Creator;
        partial void OnCreatorChanging(global::System.String value);
        partial void OnCreatorChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Created
        {
            get
            {
                return _Created;
            }
            set
            {
                OnCreatedChanging(value);
                ReportPropertyChanging("Created");
                _Created = StructuralObject.SetValidValue(value, "Created");
                ReportPropertyChanged("Created");
                OnCreatedChanged();
            }
        }
        private global::System.DateTime _Created;
        partial void OnCreatedChanging(global::System.DateTime value);
        partial void OnCreatedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Modifier
        {
            get
            {
                return _Modifier;
            }
            set
            {
                OnModifierChanging(value);
                ReportPropertyChanging("Modifier");
                _Modifier = StructuralObject.SetValidValue(value, false, "Modifier");
                ReportPropertyChanged("Modifier");
                OnModifierChanged();
            }
        }
        private global::System.String _Modifier;
        partial void OnModifierChanging(global::System.String value);
        partial void OnModifierChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Modified
        {
            get
            {
                return _Modified;
            }
            set
            {
                OnModifiedChanging(value);
                ReportPropertyChanging("Modified");
                _Modified = StructuralObject.SetValidValue(value, "Modified");
                ReportPropertyChanged("Modified");
                OnModifiedChanged();
            }
        }
        private global::System.DateTime _Modified;
        partial void OnModifiedChanging(global::System.DateTime value);
        partial void OnModifiedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte[] BaBankTS
        {
            get
            {
                return StructuralObject.GetValidValue(_BaBankTS);
            }
            set
            {
                OnBaBankTSChanging(value);
                ReportPropertyChanging("BaBankTS");
                _BaBankTS = StructuralObject.SetValidValue(value, true, "BaBankTS");
                ReportPropertyChanged("BaBankTS");
                OnBaBankTSChanged();
            }
        }
        private global::System.Byte[] _BaBankTS;
        partial void OnBaBankTSChanging(global::System.Byte[] value);
        partial void OnBaBankTSChanged();

        #endregion

    }

    #endregion

}