using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kiss.DbContext
{
    partial class KesMassnahme
    {
        [DataMember]
        private IEnumerable<int> _zgbArtikel;

        public IEnumerable<int> ZgbArtikel
        {
            get
            {
                return _zgbArtikel;
            }
            set
            {
                if (_zgbArtikel != value)
                {
                    _zgbArtikel = value;
                    RaisePropertyChanged("ZgbArtikel");
                }
            }
        }

        [DataMember]
        private string _zgbArtikelTextKurz;

        public string ZgbArtikelTextKurz
        {
            get
            {
                return _zgbArtikelTextKurz;
            }
            set
            {
                if (_zgbArtikelTextKurz != value)
                {
                    _zgbArtikelTextKurz = value;
                    RaisePropertyChanged("ZgbArtikelTextKurz");
                }
            }
        }
    }
}