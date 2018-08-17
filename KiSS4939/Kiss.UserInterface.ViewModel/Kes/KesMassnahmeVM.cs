using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Ba;
using Kiss.BusinessLogic.Ba.DTO;
using Kiss.BusinessLogic.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Kes;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Selectable;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.LocalResources.Kes;
using Kiss.UserInterface.ViewModel.SearchBox;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesMassnahmeVM : ViewModelSearchListCRUD<KesMassnahme, KesMassnahme, int, int>
    {
        public const string KEY_INCL_DELETED = "InclDeleted";
        public const string KEY_KES_MASSNAHME = "KesMassnahme";
        private const int TAB_INDEX_AUFTRAG = 3;
        private const int TAB_INDEX_BERICHTE = 2;
        private const int TAB_INDEX_DOKUMENTE = 4;
        private const int TAB_INDEX_ERFASSEN = 0;
        private const int TAB_INDEX_MANDATSFUEHRENDE_PERSON = 1;

        private int _baPersonId;
        private BaseCommand _duplicateKesMassnahmeCommand;
        private int _faLeistungId;
        private bool _fuersorgerischeUnterbringungIsReadOnly;
        private bool _istKESB;
        private IList<XLOVCode> _kesAenderungsgrundCode;
        private bool _kesAenderungsgrundCode_IsRequired;
        private IEnumerable<KesArtikel> _kesArtikelEs;
        private IEnumerable<KesArtikel> _kesArtikelKs;
        private SelectableList<XLOVCode> _kesAufgabenbereichCode;
        private IEnumerable<XLOVCode> _kesAufgabenbereichEsCodes;
        private IList<XLOVCode> _kesAufhebungsgrundCode;
        private IList<XLOVCode> _kesAufhebungsgrundEsCodes;
        private IList<XLOVCode> _kesAufhebungsgrundKsCodes;
        private KesDokumentVM _kesDokumentVM;
        private IList<XLOVCode> _kesElterlicheSorgeObhutCode_EtlicheSorge;
        private bool _kesElterlicheSorgeObhutCode_EtlicheSorge_IsReadOnly;
        private IList<XLOVCode> _kesElterlicheSorgeObhutCode_Obhut;
        private bool _kesElterlicheSorgeObhutCode_Obhut_IsReadOnly;
        private bool _kesGrundlageCode_IsReadOnly;
        private IList<XLOVCode> _kesGrundlageCodes;
        private SelectableList<XLOVCode> _kesIndikationCode;
        private IEnumerable<XLOVCode> _kesIndikationEsCodes;
        private IEnumerable<XLOVCode> _kesIndikationKsCodes;
        private KesMandatsfuehrendePersonVM _kesMandatsfuehrendePersonVM;
        private KesMassnahmeAuftragVM _kesMassnahmeAuftragVM;
        private KesMassnahmeBerichtVM _kesMassnahmeBerichtVM;
        private BaAdressatDTO _selectedBaInstitution;
        private int _selectedTabIndex;
        private KesBehoerde _selectedUebernahmeVon_KesBehoerde;
        private KesBehoerde _selectedUebertragungAn_KesBehoerde;
        private KesBehoerde _selectedZustaendig_KesBehoerde;
        private string _title;
        private SelectableList<KesArtikel> _zgbArtikel;
        private IEnumerable<KesArtikel> _zgbArtikelAll;

        public KesMassnahmeVM()
            : base(Container.Resolve<KesMassnahmeService>())
        {
            KesBehoerdeSearchBoxVM = new KesBehoerdeSearchBoxVM();
            BaInstitutionSearchBoxVM = new BaInstitutionSearchBoxVM();

            RequiredParameters = InitParameterValue.FaLeistungID | InitParameterValue.BaPersonID | InitParameterValue.Title;
        }

        public bool AufgabenBereich_IsRequired
        {
            get { return false; }
        }

        public BaInstitutionSearchBoxVM BaInstitutionSearchBoxVM { get; private set; }

        public BaseCommand DuplicateKesMassnahmeCommand
        {
            get
            {
                return _duplicateKesMassnahmeCommand ?? (_duplicateKesMassnahmeCommand = new BaseCommand(x => DuplicateKesMassnahme(), x => SelectedEntity != null));
            }
        }

        public bool FuersorgerischeUnterbringung_IsReadOnly
        {
            get { return _fuersorgerischeUnterbringungIsReadOnly; }
            set { SetProperty(ref _fuersorgerischeUnterbringungIsReadOnly, value, () => FuersorgerischeUnterbringung_IsReadOnly); }
        }

        public GridLength HeightListe
        {
            get
            {
                var height = new GridLength(1, GridUnitType.Star);
                if (SelectedTabIndex == TAB_INDEX_DOKUMENTE)
                {
                    height = new GridLength(1, GridUnitType.Auto);
                }

                return height;
            }
        }

        public GridLength HeightTabs
        {
            get
            {
                var height = new GridLength(1, GridUnitType.Auto);
                if (SelectedTabIndex == TAB_INDEX_DOKUMENTE)
                {
                    height = new GridLength(1, GridUnitType.Star);
                }

                return height;
            }
        }

        public override bool InclDeleted
        {
            get { return base.InclDeleted; }
            set
            {
                if (KesDokumentVM != null)
                {
                    KesDokumentVM.InclDeleted = value;
                }

                if (KesMandatsfuehrendePersonVM != null)
                {
                    KesMandatsfuehrendePersonVM.InclDeleted = value;
                }

                if (KesMassnahmeAuftragVM != null)
                {
                    KesMassnahmeAuftragVM.InclDeleted = value;
                }

                base.InclDeleted = value;
            }
        }

        public IList<XLOVCode> KesAenderungsgrundCode
        {
            get { return _kesAenderungsgrundCode; }
            set { SetProperty(ref _kesAenderungsgrundCode, value, () => KesAenderungsgrundCode); }
        }

        public bool KesAenderungsgrundCode_IsRequired
        {
            get { return _kesAenderungsgrundCode_IsRequired; }
            set { SetProperty(ref _kesAenderungsgrundCode_IsRequired, value, () => KesAenderungsgrundCode_IsRequired); }
        }

        public SelectableList<XLOVCode> KesAufgabenbereichCode
        {
            get { return _kesAufgabenbereichCode; }
            private set
            {
                SetProperty(ref _kesAufgabenbereichCode, value, () => KesAufgabenbereichCode);
                NotifyPropertyChanged.RaisePropertyChanged(() => AufgabenBereich_IsRequired);
            }
        }

        public bool KesAufgabenbereichSichtbar
        {
            get;
            private set;
        }

        public IList<XLOVCode> KesAufhebungsgrundCode
        {
            get { return _kesAufhebungsgrundCode; }
            set { SetProperty(ref _kesAufhebungsgrundCode, value, () => KesAufhebungsgrundCode); }
        }

        public KesBehoerdeSearchBoxVM KesBehoerdeSearchBoxVM
        {
            get;
            private set;
        }

        public KesDokumentVM KesDokumentVM
        {
            get { return _kesDokumentVM; }
            set { SetProperty(ref _kesDokumentVM, value, () => KesDokumentVM); }
        }

        public IList<XLOVCode> KesElterlicheSorgeObhutCode_EtlicheSorge
        {
            get { return _kesElterlicheSorgeObhutCode_EtlicheSorge; }
            set { SetProperty(ref _kesElterlicheSorgeObhutCode_EtlicheSorge, value, () => KesElterlicheSorgeObhutCode_EtlicheSorge); }
        }

        public bool KesElterlicheSorgeObhutCode_EtlicheSorge_IsReadOnly
        {
            get { return _kesElterlicheSorgeObhutCode_EtlicheSorge_IsReadOnly; }
            set { SetProperty(ref _kesElterlicheSorgeObhutCode_EtlicheSorge_IsReadOnly, value, () => KesElterlicheSorgeObhutCode_EtlicheSorge_IsReadOnly); }
        }

        public IList<XLOVCode> KesElterlicheSorgeObhutCode_Obhut
        {
            get { return _kesElterlicheSorgeObhutCode_Obhut; }
            set { SetProperty(ref _kesElterlicheSorgeObhutCode_Obhut, value, () => KesElterlicheSorgeObhutCode_Obhut); }
        }

        public bool KesElterlicheSorgeObhutCode_Obhut_IsReadOnly
        {
            get { return _kesElterlicheSorgeObhutCode_Obhut_IsReadOnly; }
            set { SetProperty(ref _kesElterlicheSorgeObhutCode_Obhut_IsReadOnly, value, () => KesElterlicheSorgeObhutCode_Obhut_IsReadOnly); }
        }

        public bool KesGrundlageCode_IsReadOnly
        {
            get { return _kesGrundlageCode_IsReadOnly; }
            set { SetProperty(ref _kesGrundlageCode_IsReadOnly, value, () => KesGrundlageCode_IsReadOnly); }
        }

        public IList<XLOVCode> KesGrundlageCodes
        {
            get { return _kesGrundlageCodes; }
            set { SetProperty(ref _kesGrundlageCodes, value, () => KesGrundlageCodes); }
        }

        public SelectableList<XLOVCode> KesIndikationCode
        {
            get { return _kesIndikationCode; }
            private set { SetProperty(ref _kesIndikationCode, value, () => KesIndikationCode); }
        }

        public bool KesIndikationSichtbar
        {
            get;
            private set;
        }

        public KesMandatsfuehrendePersonVM KesMandatsfuehrendePersonVM
        {
            get { return _kesMandatsfuehrendePersonVM; }
            set { SetProperty(ref _kesMandatsfuehrendePersonVM, value, () => KesMandatsfuehrendePersonVM); }
        }

        public KesMassnahmeAuftragVM KesMassnahmeAuftragVM
        {
            get { return _kesMassnahmeAuftragVM; }
            set { SetProperty(ref _kesMassnahmeAuftragVM, value, () => KesMassnahmeAuftragVM); }
        }

        public KesMassnahmeBerichtVM KesMassnahmeBerichtVM
        {
            get { return _kesMassnahmeBerichtVM; }
            set { SetProperty(ref _kesMassnahmeBerichtVM, value, () => KesMassnahmeBerichtVM); }
        }

        public BaAdressatDTO SelectedBaInstitution
        {
            get { return _selectedBaInstitution; }
            set
            {
                if (SelectedEntity != null && SetProperty(ref _selectedBaInstitution, value, () => SelectedBaInstitution))
                {
                    if (SelectedEntity.Platzierung_BaInstitutionID != null && SelectedEntity.BaInstitution != null)
                    {
                        SelectedEntity.BaInstitution.KesMassnahme.Remove(SelectedEntity);
                    }
                    SelectedEntity.Platzierung_BaInstitutionID = value != null ? value.BaInstitutionId : (int?)null;
                }
            }
        }

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                SetProperty(ref _selectedTabIndex, value, () => SelectedTabIndex);
                NotifyPropertyChanged.RaisePropertyChanged(() => Visible);
                NotifyPropertyChanged.RaisePropertyChanged(() => HeightListe);
                NotifyPropertyChanged.RaisePropertyChanged(() => HeightTabs);
            }
        }

        public KesBehoerde SelectedUebernahmeVon_KesBehoerde
        {
            get { return _selectedUebernahmeVon_KesBehoerde; }
            set
            {
                if (SelectedEntity != null && SetProperty(ref _selectedUebernahmeVon_KesBehoerde, value, () => SelectedUebernahmeVon_KesBehoerde))
                {
                    if (SelectedEntity.UebernahmeVon_KesBehoerde != null)
                    {
                        SelectedEntity.UebernahmeVon_KesBehoerde.KesMassnahme_UebernahmeVon.Remove(SelectedEntity);
                    }
                    SelectedEntity.UebernahmeVon_KesBehoerdeID = value != null ? value.KesBehoerdeID : (int?)null;
                }
            }
        }

        public KesBehoerde SelectedUebertragungAn_KesBehoerde
        {
            get { return _selectedUebertragungAn_KesBehoerde; }
            set
            {
                if (SelectedEntity != null && SetProperty(ref _selectedUebertragungAn_KesBehoerde, value, () => SelectedUebertragungAn_KesBehoerde))
                {
                    if (SelectedEntity.UebertragungAn_KesBehoerde != null)
                    {
                        SelectedEntity.UebertragungAn_KesBehoerde.KesMassnahme_UebertragungAn.Remove(SelectedEntity);
                    }
                    SelectedEntity.UebertragungAn_KesBehoerdeID = value != null ? value.KesBehoerdeID : (int?)null;
                }
            }
        }

        public KesBehoerde SelectedZustaendig_KesBehoerde
        {
            get { return _selectedZustaendig_KesBehoerde; }
            set
            {
                if (SelectedEntity != null && SetProperty(ref _selectedZustaendig_KesBehoerde, value, () => SelectedZustaendig_KesBehoerde))
                {
                    if (SelectedEntity.Zustaendig_KesBehoerde != null)
                    {
                        SelectedEntity.Zustaendig_KesBehoerde.KesMassnahme_Zustaendig.Remove(SelectedEntity);
                    }
                    SelectedEntity.Zustaendig_KesBehoerdeID = value != null ? value.KesBehoerdeID : (int?)null;
                }
            }
        }

        public bool SelectedZustaendig_KesBehoerde_IsRequired
        {
            get { return _istKESB; }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, () => Title); }
        }

        public Visibility Visible
        {
            get
            {
                var visible = Visibility.Visible;
                if (SelectedTabIndex == TAB_INDEX_DOKUMENTE)
                {
                    visible = Visibility.Collapsed;
                }

                return visible;
            }
        }

        public SelectableList<KesArtikel> ZgbArtikel
        {
            get
            {
                return _zgbArtikel;
            }
            private set { SetProperty(ref _zgbArtikel, value, () => ZgbArtikel); }
        }

        private KesMassnahmeService Service
        {
            get { return (KesMassnahmeService)ServiceCRUD; }
        }

        public override bool CanDeleteData()
        {
            if (SelectedTabIndex == TAB_INDEX_MANDATSFUEHRENDE_PERSON)
            {
                return KesMandatsfuehrendePersonVM != null && KesMandatsfuehrendePersonVM.CanDeleteData();
            }

            if (SelectedTabIndex == TAB_INDEX_BERICHTE)
            {
                return KesMassnahmeBerichtVM != null && KesMassnahmeBerichtVM.CanDeleteData();
            }

            if (SelectedTabIndex == TAB_INDEX_AUFTRAG)
            {
                return KesMassnahmeAuftragVM != null && KesMassnahmeAuftragVM.CanDeleteData();
            }

            if (SelectedTabIndex == TAB_INDEX_DOKUMENTE)
            {
                return KesDokumentVM != null && KesDokumentVM.CanDeleteData();
            }

            return base.CanDeleteData();
        }

        public override bool CanInsertData()
        {
            if (SelectedTabIndex == TAB_INDEX_MANDATSFUEHRENDE_PERSON)
            {
                return KesMandatsfuehrendePersonVM != null && KesMandatsfuehrendePersonVM.CanInsertData();
            }

            if (SelectedTabIndex == TAB_INDEX_BERICHTE)
            {
                return KesMassnahmeBerichtVM != null && KesMassnahmeBerichtVM.CanInsertData();
            }

            if (SelectedTabIndex == TAB_INDEX_AUFTRAG)
            {
                return KesMassnahmeAuftragVM != null && KesMassnahmeAuftragVM.CanInsertData();
            }

            if (SelectedTabIndex == TAB_INDEX_DOKUMENTE)
            {
                return KesDokumentVM != null && KesDokumentVM.CanInsertData();
            }

            return base.CanInsertData();
        }

        public override bool CanSaveData()
        {
            if (SelectedTabIndex == TAB_INDEX_MANDATSFUEHRENDE_PERSON)
            {
                return KesMandatsfuehrendePersonVM != null && KesMandatsfuehrendePersonVM.CanSaveData();
            }

            if (SelectedTabIndex == TAB_INDEX_BERICHTE)
            {
                return KesMassnahmeBerichtVM != null && KesMassnahmeBerichtVM.CanSaveData();
            }

            if (SelectedTabIndex == TAB_INDEX_AUFTRAG)
            {
                return KesMassnahmeAuftragVM != null && KesMassnahmeAuftragVM.CanSaveData();
            }

            if (SelectedTabIndex == TAB_INDEX_DOKUMENTE)
            {
                return KesDokumentVM != null && KesDokumentVM.CanSaveData();
            }

            return base.CanSaveData();
        }

        public override bool CanUndoChanges()
        {
            if (SelectedTabIndex == TAB_INDEX_MANDATSFUEHRENDE_PERSON)
            {
                return KesMandatsfuehrendePersonVM != null && KesMandatsfuehrendePersonVM.CanUndoChanges();
            }

            if (SelectedTabIndex == TAB_INDEX_BERICHTE)
            {
                return KesMassnahmeBerichtVM != null && KesMassnahmeBerichtVM.CanUndoChanges();
            }

            if (SelectedTabIndex == TAB_INDEX_AUFTRAG)
            {
                return KesMassnahmeAuftragVM != null && KesMassnahmeAuftragVM.CanUndoChanges();
            }

            if (SelectedTabIndex == TAB_INDEX_DOKUMENTE)
            {
                return KesDokumentVM != null && KesDokumentVM.CanUndoChanges();
            }

            return base.CanUndoChanges();
        }

        public override IServiceResult DeleteData()
        {
            IServiceResult result = ServiceResult.Ok();

            if (result.IsOk && SelectedTabIndex == TAB_INDEX_MANDATSFUEHRENDE_PERSON && KesMandatsfuehrendePersonVM != null)
            {
                result = KesMandatsfuehrendePersonVM.DeleteData();
            }

            if (result.IsOk && SelectedTabIndex == TAB_INDEX_BERICHTE && KesMassnahmeBerichtVM != null)
            {
                result = KesMassnahmeBerichtVM.DeleteData();
            }

            if (result.IsOk && SelectedTabIndex == TAB_INDEX_AUFTRAG && KesMassnahmeAuftragVM != null)
            {
                result = KesMassnahmeAuftragVM.DeleteData();
            }

            if (result.IsOk && SelectedTabIndex == TAB_INDEX_DOKUMENTE && KesDokumentVM != null)
            {
                result = KesDokumentVM.DeleteData();
            }

            if (result.IsOk && SelectedTabIndex == TAB_INDEX_ERFASSEN && SelectedEntity != null)
            {
                result = base.DeleteData();
            }

            return result;
        }

        public override IServiceResult InsertData()
        {
            // Massnahme speichern und Befehl an Sub-VM leiten, wenn ein anderer als der Massnahmen-Tab selektiert ist
            if (SelectedTabIndex != TAB_INDEX_ERFASSEN)
            {
                var result = base.SaveData();

                if (!result.IsOk)
                {
                    SelectedTabIndex = TAB_INDEX_ERFASSEN;
                    return result;
                }
            }

            if (SelectedTabIndex == TAB_INDEX_MANDATSFUEHRENDE_PERSON)
            {
                return KesMandatsfuehrendePersonVM.InsertData();
            }

            if (SelectedTabIndex == TAB_INDEX_BERICHTE)
            {
                return KesMassnahmeBerichtVM.InsertData();
            }

            if (SelectedTabIndex == TAB_INDEX_AUFTRAG)
            {
                return KesMassnahmeAuftragVM.InsertData();
            }

            if (SelectedTabIndex == TAB_INDEX_DOKUMENTE)
            {
                return KesDokumentVM.InsertData();
            }

            return base.InsertData();
        }

        public override bool JumpToPath(System.Collections.Specialized.HybridDictionary parameters)
        {
            var returnValue = base.JumpToPath(parameters);

            if (parameters.Contains(PARAMETER_SELECTED_TAB_INDEX))
            {
                string value = null;
                foreach (var param in parameters.Cast<DictionaryEntry>().Where(param => param.Key.Equals(PARAMETER_SELECTED_TAB_INDEX)))
                {
                    value = (string)param.Value;
                }

                SelectedTabIndex = Convert.ToInt32(value);
            }

            return returnValue;
        }

        public override void RefreshData()
        {
            base.RefreshData();

            if (KesMandatsfuehrendePersonVM != null)
            {
                KesMandatsfuehrendePersonVM.RefreshData();
            }

            if (KesMassnahmeAuftragVM != null)
            {
                KesMassnahmeAuftragVM.RefreshData();
            }

            if (KesMassnahmeBerichtVM != null)
            {
                KesMassnahmeBerichtVM.RefreshData();
            }

            if (KesDokumentVM != null)
            {
                KesDokumentVM.RefreshData();
            }
        }

        public override IServiceResult SaveData()
        {
            //Da das Register Dokumente nicht von der aktuellen Massnahme abhängt, kann dieses Register gespeichert werden, unabhängig der Tatsache ob                  SelectedEntity existiert oder nicht
            if (KesDokumentVM == null)
                return ServiceResult.Ok();

            var result = KesDokumentVM.SaveData();
            if (!result.IsOk)
            {
                SelectedTabIndex = TAB_INDEX_DOKUMENTE;
                return result;
            }

            if (SelectedEntity == null || SelectedEntity.KesMassnahme_KesArtikel == null)
            {
                return ServiceResult.Ok();
            }

            // Mussfelder prüfen
            if (AufgabenBereich_IsRequired && KesAufgabenbereichCode != null && KesAufgabenbereichCode.Any() && !KesAufgabenbereichCode.Any(c => c.IsSelected))
            {
                var aufgabenBereichRequiredError = ServiceResult.Error(KesMassnahmeVMRes.Aufgabenbereich_Required);
                ValidationResult.Add(aufgabenBereichRequiredError);
                return aufgabenBereichRequiredError;
            }

            if (SelectedZustaendig_KesBehoerde_IsRequired && _selectedZustaendig_KesBehoerde == null)
            {
                var kesBehoeredRequiredError = ServiceResult.Error(KesMassnahmeVMRes.KesBehoerde_Required);
                ValidationResult.Add(kesBehoeredRequiredError);
                return kesBehoeredRequiredError;
            }

            // Aufgabenbereichsliste vergleichen und zusammenfügen
            var aufgabenbereicheNew = KesAufgabenbereichCode.SelectedItems.Select(x => x.Code).OrderBy(x => x).ToList();
            var aufgabenbereicheOld = new List<int>();
            if (SelectedEntity.KesAufgabenbereichCodes != null)
            {
                aufgabenbereicheOld.AddRange(SelectedEntity.KesAufgabenbereichCodes.Select(code => (int)code).OrderBy(x => x).ToList());
            }

            if (!aufgabenbereicheNew.SequenceEqual(aufgabenbereicheOld))
            {
                SelectedEntity.KesAufgabenbereichCodes = String.Join(",", aufgabenbereicheNew.ToArray());
            }

            // Indikationsliste vergleichen und zusammenfügen
            var indikationNew = KesIndikationCode.SelectedItems.Select(x => x.Code).OrderBy(x => x).ToList();
            var indikationOld = new List<int>();
            if (SelectedEntity.KesIndikationCodes != null)
            {
                indikationOld.AddRange(SelectedEntity.KesIndikationCodes.Select(code => (int)code).OrderBy(x => x).ToList());
            }

            if (!indikationNew.SequenceEqual(indikationOld))
            {
                SelectedEntity.KesIndikationCodes = String.Join(",", indikationNew.ToArray());
            }

            // ZGB-Artikel vergleichen
            var zgbArtikelNew = ZgbArtikel.SelectedItems.Select(x => x.KesArtikelID).OrderBy(x => x).ToList();
            var zgbArtikelOld = new List<int>();
            if (SelectedEntity.ZgbArtikel != null)
            {
                zgbArtikelOld = SelectedEntity.ZgbArtikel.OrderBy(x => x).ToList();
            }

            if (!zgbArtikelNew.SequenceEqual(zgbArtikelOld))
            {
                SelectedEntity.ZgbArtikel = zgbArtikelNew;
                SelectedEntity.ZgbArtikelTextKurz = string.Join(", ", ZgbArtikel.SelectedItems.Select(art => art.ArtikelText).OrderBy(t => t).ToList());
            }

            if (!result.IsOk)
            {
                return result;
            }

            var modified = IsSelectedEntityTreeModified();
            result = base.SaveData();

            if (!result.IsOk)
            {
                return result;
            }

            // Mandatsführende Person
            modified = modified || KesMandatsfuehrendePersonVM.IsSelectedEntityTreeModified();
            result = KesMandatsfuehrendePersonVM.SaveData();

            if (!result.IsOk)
            {
                return result;
            }

            // Berichte
            modified = modified || KesMassnahmeBerichtVM.IsSelectedEntityTreeModified();
            result = KesMassnahmeBerichtVM.SaveData();

            if (!result.IsOk)
            {
                return result;
            }

            // Auftrag
            modified = modified || KesMassnahmeAuftragVM.IsSelectedEntityTreeModified();
            result = KesMassnahmeAuftragVM.SaveData();

            if (!result.IsOk)
            {
                return result;
            }

            Service.RefreshTree(modified);
            return result;
        }

        public override bool UndoDataChanges()
        {
            if (SelectedTabIndex == TAB_INDEX_MANDATSFUEHRENDE_PERSON)
            {
                return KesMandatsfuehrendePersonVM != null && KesMandatsfuehrendePersonVM.UndoDataChanges();
            }

            if (SelectedTabIndex == TAB_INDEX_BERICHTE)
            {
                return KesMassnahmeBerichtVM != null && KesMassnahmeBerichtVM.UndoDataChanges();
            }

            if (SelectedTabIndex == TAB_INDEX_AUFTRAG)
            {
                return KesMassnahmeAuftragVM != null && KesMassnahmeAuftragVM.UndoDataChanges();
            }

            if (SelectedTabIndex == TAB_INDEX_DOKUMENTE)
            {
                return KesDokumentVM != null && KesDokumentVM.UndoDataChanges();
            }

            return base.UndoDataChanges();
        }

        protected async override Task InitAsync(InitParameters? initParameters = null)
        {
            _faLeistungId = initParameters.Value.FaLeistungID.Value;
            _baPersonId = initParameters.Value.BaPersonID.Value;

            Title = initParameters.Value.Title;

            AddViewRightInterceptor(new KesMaskenrechtInterceptor(_faLeistungId));

            var configService = Container.Resolve<XConfigService>();
            KesIndikationSichtbar = configService.GetConfigValue(ConfigNodes.System_Kes_KesMassnahme_IndikationSichtbar);
            KesAufgabenbereichSichtbar = configService.GetConfigValue(ConfigNodes.System_Kes_KesMassnahme_AufgabenbereichSichtbar);
            _istKESB = configService.GetConfigValue(ConfigNodes.System_Kes_KesMassnahme_IstKESB);

            var xLovService = Container.Resolve<XLovService>();
            var artikelService = Container.Resolve<KesArtikelService>();

            _kesArtikelKs = artikelService.GetKsArtikel(true);
            _kesArtikelEs = artikelService.GetKsArtikel(false);

            _kesIndikationKsCodes = xLovService.GetLovCodesByLovName("KesIndikationKS", false, true);
            _kesIndikationEsCodes = xLovService.GetLovCodesByLovName("KesIndikationES", false, true);

            _kesAufgabenbereichEsCodes = xLovService.GetLovCodesByLovName("KesAufgabenbereichES", false, true);

            _kesAufhebungsgrundEsCodes = xLovService.GetLovCodesByLovName("KesAufhebungsgrundES", true, true);
            _kesAufhebungsgrundKsCodes = xLovService.GetLovCodesByLovName("KesAufhebungsgrundKS", true, true);

            _kesElterlicheSorgeObhutCode_EtlicheSorge = xLovService.GetLovCodesByLovName("KesElterlicheSorgeObhut", true, true);
            _kesElterlicheSorgeObhutCode_Obhut = xLovService.GetLovCodesByLovName("KesElterlicheSorgeObhut", true, true);

            _kesAenderungsgrundCode = xLovService.GetLovCodesByLovName("KesAenderungsgrund", true, true);

            _kesGrundlageCodes = xLovService.GetLovCodesByLovName("KesGrundlageKS", true, true);

            KesElterlicheSorgeObhutCode_EtlicheSorge_IsReadOnly = false;
            KesElterlicheSorgeObhutCode_Obhut_IsReadOnly = false;
            KesGrundlageCode_IsReadOnly = true;

            _kesAenderungsgrundCode_IsRequired = false;

            LoadDokumentVM();

            SearchParameters = _faLeistungId;
            SearchTask.StartCommand.Execute(_faLeistungId);
        }

        protected override void InitNewEntity(KesMassnahme entity)
        {
            base.InitNewEntity(entity);
            entity.FaLeistungID = _faLeistungId;
            entity.ZgbArtikel = new List<int>();
        }

        protected override void OnSelectedEntityChanged(KesMassnahme selectedEntity, KesMassnahme deselectedEntity)
        {
            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);

            // Kes Behörden setzen. Navigation Properties können nicht verwendet werden, weil sonst nicht gespeichert werden kann,
            // wenn in zwei Feldern die gleiche Behörde ausgewählt ist (EF versucht dann beide Objekte zu attachen, was nicht geht)
            var kesBehoerdeService = Container.Resolve<KesBehoerdeService>();
            if (selectedEntity != null && selectedEntity.UebernahmeVon_KesBehoerdeID != null)
            {
                SelectedUebernahmeVon_KesBehoerde = kesBehoerdeService.GetEntityById(selectedEntity.UebernahmeVon_KesBehoerdeID.Value);
            }
            else
            {
                SelectedUebernahmeVon_KesBehoerde = null;
            }

            if (selectedEntity != null && selectedEntity.UebertragungAn_KesBehoerdeID != null)
            {
                SelectedUebertragungAn_KesBehoerde = kesBehoerdeService.GetEntityById(selectedEntity.UebertragungAn_KesBehoerdeID.Value);
            }
            else
            {
                SelectedUebertragungAn_KesBehoerde = null;
            }

            if (selectedEntity != null && selectedEntity.Zustaendig_KesBehoerdeID != null)
            {
                SelectedZustaendig_KesBehoerde = kesBehoerdeService.GetEntityById(selectedEntity.Zustaendig_KesBehoerdeID.Value);
            }
            else
            {
                SelectedZustaendig_KesBehoerde = null;
            }

            var baInstitutionService = Container.Resolve<BaInstitutionService>();
            var baAdressatService = Container.Resolve<BaAdressatService>();
            if (selectedEntity != null && selectedEntity.Platzierung_BaInstitutionID != null)
            {
                //SelectedBaInstitution = baInstitutionService.GetEntityById(selectedEntity.Platzierung_BaInstitutionID.Value);
                SelectedBaInstitution = baAdressatService.GetAdressat(selectedEntity.Platzierung_BaInstitutionID, null);
            }
            else
            {
                SelectedBaInstitution = null;
            }

            KesAenderungsgrundCode_IsRequired = selectedEntity != null && (selectedEntity.AenderungVom_Datum != null);

            if (selectedEntity != null && selectedEntity.KesMassnahme_KesArtikel != null)
            {
                EsKsChanged(SelectedEntity.IsKS);

                // Aufgabenbereich selektieren
                foreach (var item in KesAufgabenbereichCode)
                {
                    item.IsSelected = selectedEntity.KesAufgabenbereichCodes != null && selectedEntity.KesAufgabenbereichCodes.Split(',').Contains(Convert.ToString(item.Item.Code));
                }

                // Indikation selektieren
                foreach (var item in KesIndikationCode)
                {
                    item.IsSelected = selectedEntity.KesIndikationCodes != null && selectedEntity.KesIndikationCodes.Split(',').Contains((Convert.ToString(item.Item.Code)));
                }

                // KesArtikel selektieren
                ZgbArtikel = new SelectableList<KesArtikel>(_zgbArtikelAll.Where(x => x.IsActive || (selectedEntity.ZgbArtikel != null && selectedEntity.ZgbArtikel.Contains(x.KesArtikelID))));
                foreach (var item in ZgbArtikel)
                {
                    item.IsSelected = selectedEntity.ZgbArtikel != null && selectedEntity.ZgbArtikel.Contains(item.Item.KesArtikelID);
                }
            }
            else if (KesAufgabenbereichCode != null && KesIndikationCode != null && ZgbArtikel != null)
            {
                KesAufgabenbereichCode.ClearSelection();
                KesIndikationCode.ClearSelection();
                ZgbArtikel.ClearSelection();
            }

            DuplicateKesMassnahmeCommand.EvaluateCanExecute();

            // refresh Child-VM
            RefreshChildVM(selectedEntity);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.IsKS) && SelectedEntity != null)
            {
                EsKsChanged(SelectedEntity.IsKS);
            }
            else if ((SelectedEntity != null && SelectedEntity.UebernahmeVon_Kanton != null)
                     && (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.UebernahmeVon_PLZ)
                         || propertyName == PropertyName.GetPropertyName(() => SelectedEntity.UebernahmeVon_Ort)
                         || propertyName == PropertyName.GetPropertyName(() => SelectedEntity.UebernahmeVon_Kanton)))
            {
                //Lookup auf KesBehoerde: gibt es nur eine KESB in diesem Kanton?
                var searchHandler = KesBehoerdeSearchBoxVM.SearchEventHandler;
                var result = searchHandler.Invoke("*", SelectedEntity.UebernahmeVon_Kanton);
                if (result.Count == 1)
                {
                    //ja: -> auswählen
                    SelectedUebernahmeVon_KesBehoerde = result[0] as KesBehoerde;
                }
                else
                {
                    //nein: -> KESB löschen
                    SelectedUebernahmeVon_KesBehoerde = null;
                }
            }
            else if ((SelectedEntity != null && SelectedEntity.UebernahmeVon_Kanton != null)
                     && (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.UebertragungAn_PLZ)
                         || propertyName == PropertyName.GetPropertyName(() => SelectedEntity.UebertragungAn_Ort)
                         || propertyName == PropertyName.GetPropertyName(() => SelectedEntity.UebertragungAn_Kanton)))
            {
                //Lookup auf KesBehoerde: gibt es nur eine KESB in diesem Kanton?
                var searchHandler = KesBehoerdeSearchBoxVM.SearchEventHandler;
                var result = searchHandler.Invoke("*", SelectedEntity.UebertragungAn_Kanton);
                if (result.Count == 1)
                {
                    //ja: -> auswählen
                    SelectedUebertragungAn_KesBehoerde = result[0] as KesBehoerde;
                }
                else
                {
                    //nein: -> KESB löschen
                    SelectedUebertragungAn_KesBehoerde = null;
                }
            }

            //Falls Feld ÄnderungVon hat Wert dann Änderungsgrund MussFeld
            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.AenderungVom_Datum) && SelectedEntity != null)
            {
                KesAenderungsgrundCode_IsRequired = SelectedEntity.AenderungVom_Datum != null;
            }

            base.OnSelectedEntityPropertyChanged(propertyName);
        }

        protected override IServiceResult<IEnumerable<KesMassnahme>> SearchInBackground(int faLeistungId, CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<KesMassnahme>>(Service.GetByFaLeistungId(faLeistungId, InclDeleted));
        }

        private IServiceResult DuplicateKesMassnahme()
        {
            var result = SaveData();

            if (result.IsOk)
            {
                var oldMassnahme = SelectedEntity;
                var newMassnahme = Service.GetCleanedCopyOfKesMassnahme(oldMassnahme);
                newMassnahme.KesMassnahmeID = 0;
                Service.SaveEntity(newMassnahme);

                var newSelectedEntity = Service.GetEntityById(newMassnahme.KesMassnahmeID);
                EntityList.Add(newSelectedEntity);
                EntityListView.MoveCurrentTo(newSelectedEntity);
                RefreshData();
            }

            return result;
        }

        private void EsKsChanged(bool isKs)
        {
            if (isKs)
            {
                if (KesIndikationSichtbar)
                {
                    KesIndikationCode = new SelectableList<XLOVCode>(_kesIndikationKsCodes);
                }

                KesAufgabenbereichCode = new SelectableList<XLOVCode>();

                _zgbArtikelAll = _kesArtikelKs;
                ZgbArtikel = new SelectableList<KesArtikel>(_zgbArtikelAll.Where(x => x.IsActive));

                SelectedEntity.KesGrundlageCode = null;
                SelectedEntity.FuersorgerischeUnterbringung = false;
            }
            else
            {
                if (KesIndikationSichtbar)
                {
                    KesIndikationCode = new SelectableList<XLOVCode>(_kesIndikationEsCodes);
                }

                if (KesAufgabenbereichSichtbar)
                {
                    KesAufgabenbereichCode = new SelectableList<XLOVCode>(_kesAufgabenbereichEsCodes);
                }

                _zgbArtikelAll = _kesArtikelEs;
                ZgbArtikel = new SelectableList<KesArtikel>(_zgbArtikelAll.Where(x => x.IsActive));

                SelectedEntity.KesElterlicheSorgeObhutCode_ElterlicheSorge = null;
                SelectedEntity.KesElterlicheSorgeObhutCode_Obhut = null;
                SelectedEntity.KesGrundlageCode = null;
            }

            KesAufhebungsgrundCode = GetKesAufhebungsgrundCodes(isKs);
            KesElterlicheSorgeObhutCode_EtlicheSorge_IsReadOnly = !isKs;
            KesElterlicheSorgeObhutCode_Obhut_IsReadOnly = !isKs;
            KesGrundlageCode_IsReadOnly = !isKs;
            FuersorgerischeUnterbringung_IsReadOnly = isKs;
        }

        private IList<XLOVCode> GetKesAufhebungsgrundCodes(bool isKs = true)
        {
            return (isKs) ? _kesAufhebungsgrundKsCodes : _kesAufhebungsgrundEsCodes;
        }

        private void LoadDokumentVM()
        {
            var customData = new Dictionary<string, object>();

            var initParameters = new InitParameters { FaLeistungID = _faLeistungId, BaPersonID = _baPersonId, CustomData = customData };

            KesDokumentVM = new KesDokumentVM(KesDokumentVM.DokumentControls.Dokumentart | KesDokumentVM.DokumentControls.Themen, KesDokumentTyp.Massnahmenfuehrung);
            KesDokumentVM.Init(initParameters);
        }

        private void RefreshChildVM(KesMassnahme selectedEntity)
        {
            var customData = new Dictionary<string, object>();
            customData.Add(KEY_KES_MASSNAHME, selectedEntity);
            customData.Add(KEY_INCL_DELETED, InclDeleted);

            var initParameters = new InitParameters { CustomData = customData, BaPersonID = _baPersonId };
            if (selectedEntity != null)
            {
                KesMandatsfuehrendePersonVM = new KesMandatsfuehrendePersonVM();
                KesMandatsfuehrendePersonVM.Init(initParameters);

                KesMassnahmeBerichtVM = new KesMassnahmeBerichtVM();
                KesMassnahmeBerichtVM.Init(initParameters);

                bool alleAnzeigen = KesMassnahmeAuftragVM != null && KesMassnahmeAuftragVM.AlleAnzeigen;
                KesMassnahmeAuftragVM = new KesMassnahmeAuftragVM(alleAnzeigen);
                KesMassnahmeAuftragVM.Init(initParameters);
            }
            else
            {
                KesMandatsfuehrendePersonVM = null;
                KesMassnahmeBerichtVM = null;
                KesMassnahmeAuftragVM = null;
            }
        }
    }
}