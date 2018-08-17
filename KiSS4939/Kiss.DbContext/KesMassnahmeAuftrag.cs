//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kiss.DbContext
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(KesMassnahme))]
    [KnownType(typeof(XDocument))]
    public partial class KesMassnahmeAuftrag : PocoEntity, IAutoIdentityEntity<int>, IAuditableEntity, ILogischesLoeschenEntity
    {
        public int AutoIdentityID 
        {
            get{ return KesMassnahmeAuftragID; } 
        }
    
        [DataMember]
        private int _kesMassnahmeAuftragID;
        public int KesMassnahmeAuftragID
        {
            get { return _kesMassnahmeAuftragID; }
            set
            {
                if (_kesMassnahmeAuftragID != value)
                {
                    _kesMassnahmeAuftragID = value;
                    RaisePropertyChanged("KesMassnahmeAuftragID");
                }
            }
        }
    
        [DataMember]
        private int _kesMassnahmeID;
        public int KesMassnahmeID
        {
            get { return _kesMassnahmeID; }
            set
            {
                if (_kesMassnahmeID != value)
                {
                    _kesMassnahmeID = value;
                    RaisePropertyChanged("KesMassnahmeID");
                    if (KesMassnahme != null && KesMassnahme.KesMassnahmeID != value)
                    {
                        KesMassnahme = null;
                    }
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _documentID_Beschluss;
        public Nullable<int> DocumentID_Beschluss
        {
            get { return _documentID_Beschluss; }
            set
            {
                if (_documentID_Beschluss != value)
                {
                    _documentID_Beschluss = value;
                    RaisePropertyChanged("DocumentID_Beschluss");
                    if (XDocumentBeschluss != null && XDocumentBeschluss.DocumentID != value)
                    {
                        XDocumentBeschluss = null;
                    }
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _beschlussVom;
        public Nullable<System.DateTime> BeschlussVom
        {
            get { return _beschlussVom; }
            set
            {
                if (_beschlussVom != value)
                {
                    _beschlussVom = value;
                    RaisePropertyChanged("BeschlussVom");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _erledigungBis;
        public Nullable<System.DateTime> ErledigungBis
        {
            get { return _erledigungBis; }
            set
            {
                if (_erledigungBis != value)
                {
                    _erledigungBis = value;
                    RaisePropertyChanged("ErledigungBis");
                }
            }
        }
    
        [DataMember]
        private string _auftrag;
        public string Auftrag
        {
            get { return _auftrag; }
            set
            {
                if (_auftrag != value)
                {
                    _auftrag = value;
                    RaisePropertyChanged("Auftrag");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _kesMassnahmeGeschaeftsartCode;
        public Nullable<int> KesMassnahmeGeschaeftsartCode
        {
            get { return _kesMassnahmeGeschaeftsartCode; }
            set
            {
                if (_kesMassnahmeGeschaeftsartCode != value)
                {
                    _kesMassnahmeGeschaeftsartCode = value;
                    RaisePropertyChanged("KesMassnahmeGeschaeftsartCode");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _documentID_Bericht;
        public Nullable<int> DocumentID_Bericht
        {
            get { return _documentID_Bericht; }
            set
            {
                if (_documentID_Bericht != value)
                {
                    _documentID_Bericht = value;
                    RaisePropertyChanged("DocumentID_Bericht");
                    if (XDocumentBericht != null && XDocumentBericht.DocumentID != value)
                    {
                        XDocumentBericht = null;
                    }
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _documentID_Versand;
        public Nullable<int> DocumentID_Versand
        {
            get { return _documentID_Versand; }
            set
            {
                if (_documentID_Versand != value)
                {
                    _documentID_Versand = value;
                    RaisePropertyChanged("DocumentID_Versand");
                    if (XDocumentVersand != null && XDocumentVersand.DocumentID != value)
                    {
                        XDocumentVersand = null;
                    }
                }
            }
        }
    
        [DataMember]
        private string _creator;
        public string Creator
        {
            get { return _creator; }
            set
            {
                if (_creator != value)
                {
                    _creator = value;
                    RaisePropertyChanged("Creator");
                }
            }
        }
    
        [DataMember]
        private System.DateTime _created;
        public System.DateTime Created
        {
            get { return _created; }
            set
            {
                if (_created != value)
                {
                    _created = value;
                    RaisePropertyChanged("Created");
                }
            }
        }
    
        [DataMember]
        private string _modifier;
        public string Modifier
        {
            get { return _modifier; }
            set
            {
                if (_modifier != value)
                {
                    _modifier = value;
                    RaisePropertyChanged("Modifier");
                }
            }
        }
    
        [DataMember]
        private System.DateTime _modified;
        public System.DateTime Modified
        {
            get { return _modified; }
            set
            {
                if (_modified != value)
                {
                    _modified = value;
                    RaisePropertyChanged("Modified");
                }
            }
        }
    
        [DataMember]
        private byte[] _kesMassnahmeAuftragTS;
        public byte[] KesMassnahmeAuftragTS
        {
            get { return _kesMassnahmeAuftragTS; }
            set
            {
                if (_kesMassnahmeAuftragTS != value)
                {
                    _kesMassnahmeAuftragTS = value;
                    RaisePropertyChanged("KesMassnahmeAuftragTS");
                }
            }
        }
    
        [DataMember]
        private Nullable<int> _documentID_VerfuegungKESB;
        public Nullable<int> DocumentID_VerfuegungKESB
        {
            get { return _documentID_VerfuegungKESB; }
            set
            {
                if (_documentID_VerfuegungKESB != value)
                {
                    _documentID_VerfuegungKESB = value;
                    RaisePropertyChanged("DocumentID_VerfuegungKESB");
                    if (XDocumentVerfuegungKesb != null && XDocumentVerfuegungKesb.DocumentID != value)
                    {
                        XDocumentVerfuegungKesb = null;
                    }
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _datumVerfuegungKESB;
        public Nullable<System.DateTime> DatumVerfuegungKESB
        {
            get { return _datumVerfuegungKESB; }
            set
            {
                if (_datumVerfuegungKESB != value)
                {
                    _datumVerfuegungKESB = value;
                    RaisePropertyChanged("DatumVerfuegungKESB");
                }
            }
        }
    
        [DataMember]
        private bool _isDeleted;
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                if (_isDeleted != value)
                {
                    _isDeleted = value;
                    RaisePropertyChanged("IsDeleted");
                }
            }
        }
    
        [DataMember]
        private Nullable<System.DateTime> _datumVersand;
        public Nullable<System.DateTime> DatumVersand
        {
            get { return _datumVersand; }
            set
            {
                if (_datumVersand != value)
                {
                    _datumVersand = value;
                    RaisePropertyChanged("DatumVersand");
                }
            }
        }
    
    
        [DataMember]
        private KesMassnahme _kesMassnahme;
        public virtual KesMassnahme KesMassnahme
        {
            get { return _kesMassnahme; }
            set
            {
                if (_kesMassnahme != value)
                {
                    _kesMassnahme = value;
                    RaisePropertyChanged("KesMassnahme");
    
                    if (value != null)
                    {
                        KesMassnahmeID = value.KesMassnahmeID;
                    }
                }
            }
        }
        [DataMember]
        private XDocument _xDocumentBericht;
        public virtual XDocument XDocumentBericht
        {
            get { return _xDocumentBericht; }
            set
            {
                if (_xDocumentBericht != value)
                {
                    _xDocumentBericht = value;
                    RaisePropertyChanged("XDocumentBericht");
    
                    if (value != null)
                    {
                        DocumentID_Bericht = value.DocumentID;
                    }
                }
            }
        }
        [DataMember]
        private XDocument _xDocumentBeschluss;
        public virtual XDocument XDocumentBeschluss
        {
            get { return _xDocumentBeschluss; }
            set
            {
                if (_xDocumentBeschluss != value)
                {
                    _xDocumentBeschluss = value;
                    RaisePropertyChanged("XDocumentBeschluss");
    
                    if (value != null)
                    {
                        DocumentID_Beschluss = value.DocumentID;
                    }
                }
            }
        }
        [DataMember]
        private XDocument _xDocumentVerfuegungKesb;
        public virtual XDocument XDocumentVerfuegungKesb
        {
            get { return _xDocumentVerfuegungKesb; }
            set
            {
                if (_xDocumentVerfuegungKesb != value)
                {
                    _xDocumentVerfuegungKesb = value;
                    RaisePropertyChanged("XDocumentVerfuegungKesb");
    
                    if (value != null)
                    {
                        DocumentID_VerfuegungKESB = value.DocumentID;
                    }
                }
            }
        }
        [DataMember]
        private XDocument _xDocumentVersand;
        public virtual XDocument XDocumentVersand
        {
            get { return _xDocumentVersand; }
            set
            {
                if (_xDocumentVersand != value)
                {
                    _xDocumentVersand = value;
                    RaisePropertyChanged("XDocumentVersand");
    
                    if (value != null)
                    {
                        DocumentID_Versand = value.DocumentID;
                    }
                }
            }
        }
    }
    
}
