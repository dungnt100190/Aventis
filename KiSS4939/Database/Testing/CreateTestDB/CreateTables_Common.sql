{DISPATCHER}
BaGemeinde
XPermissionGroup
XModul
XProfile
XProfileTag
XProfile_XProfileTag
Hist_XUser
XUser
Rxxxx_Drop_HistoryTrigger_XUser:IFNSE=ZH  -- only ZH
Hist_XUserStundenansatz
XUserStundenansatz
XArchive
XUser_Archive
XUserGroup
Hist_XOrgUnit
XOrgUnit
Rxxxx_Drop_HistoryTrigger_XOrgUnit:IFNSE=ZH  -- only ZH
BaInstitution
BaInstitutionKontakt
BaLand
BaPerson
Rxxxx_Drop_HistoryTrigger_BaPerson:IFNSE=ZH  -- only ZH
BaPraemienverbilligung
BaPLZ
BaRelation
BaBank
BaZahlungsweg
Hist_BaPerson
HistoryVersion
FaFall:IFNSE=ZH -- Ausnahme: FaLeistung hat bei ZH FK auf FaFall
fnGetDefaultGemeindeCode
FaLeistung
FaLeistungUserHist
FaLeistungArchiv
fnFaCKFaLeistungZugriffFaLeistungUserIntegrity
FaLeistungZugriff
FsDienstleistungspaket
FaPhase
XDBVersion
XDocContext
XDocContextType
XHyperlink
XHyperlinkContext
XHyperlinkContext_Hyperlink
XIcon
XLangText
XLog
XMessage
XPermissionValue:IFNSE=PI -- STD/ZH haben FK auf BgPositionsart
XQuery
XRule
XTable
XTableColumn
BaPerson_Relation
DynaMask
XBookmark
XClass
MigXClassFrmToCtl
XClassComponent
XClassControl
XClassReference
XClassRule
XNamespaceExtension
XConfig
fnXConfig
XDocTemplate:IFNSE=!ZH -- Hat FK auf FaDokKatalog
XLOV
XLOVCode
XMenuItem
XModulTree
Hist_XOrgUnit_User
XOrgUnit_User
Rxxxx_Drop_HistoryTrigger_XOrgUnit_User:IFNSE=ZH  -- only ZH
XRight
XSearchControlTemplate
XSearchControlTemplateField
XUser_UserGroup
XUserGroup_Right
KaBetrieb
KaBetriebKontakt
KaEafSozioberuflicheBilanz
KaEafSpezifischeErmittlung
VmMandant
VmPriMa
Hist_BaAdresse
BaAdresse -- Hat FK auf KaBetrieb
Rxxxx_Drop_HistoryTrigger_BaAdresse:IFNSE=ZH  -- only ZH
DynaField
DynaValue
FaAktennotizen
FaDokumente:IFNSE=PI -- Hat im STD FK auf VmPriMa und bei ZH auf XTask
XDocContext_Template:IFNSE=!ZH -- FK auf XDocTemplate
XDocument
XTypeConfig
FaDokumentAblage
FaDokumentAblage_BaPerson
BgKostenart
BaEinwohnerregisterPersonStatus

-- BDE - Betriebsdatenerfassung/Zeiterfassung
Hist_BDEFerienkuerzungen_XUser
Hist_BDELeistung
Hist_BDELeistungsart
Hist_BDESollStundenProJahr_XUser
BDEAusbezahlteUeberstunden_XUser
BDEFerienanspruch_XUser
BDEFerienkuerzungen_XUser
BDELeistungsart
BDELeistung
BDEPensum_XUser
BDESollProTag_XUser
BDESollStundenProJahr_XUser
BDEUserGroup
BDEUserGroup_BDELeistungsart
BDEZeitrechner
XUser_BDEUserGroup

-- X - System
XDBServerVersion
XDeleteRule
XTaskTypeAction

-- FS - Fallsteuerung
--FsDienstleistungspaket --> FaPhase depends on this table
FsDienstleistung
FsDienstleistung_FsDienstleistungspaket
FsReduktion
FsReduktionMitarbeiter

-- IK
IkLandesindex
IkLandesindexWert

-- Kb
KbZahlungskonto
KbZahlungskonto_XOrgUnit

-- GV
GvFonds
GvFonds_XOrgUnit
GvGesuch
GvAntragPosition
GvAuflage
GvPositionsart
GvAuszahlungPosition
GvAuszahlungPositionValuta
GvBewilligung
GvDocument
GvDokumenteInformation
GvAbklaerendeStelle

-- KBU
KbuKontoGruppe
KbuKonto

-- WSH
WshHaushaltPerson
WshKategorie
WshGrundbudgetPosition
WshGrundbudgetPositionDebitor
WshGrundbudgetPositionKreditor
WshAbzug
WshAbzugDetail
WshPosition
WshPositionDebitor
WshPositionKreditor

-- KBU
KbuKonto_KbuKontoTyp
KbuZahlungseingang
KbuBeleg
KbuBelegPosition
KbuBelegDebitor
KbuBelegKreditor
KbuBelegKreis
KbuErwarteteEinnahmeAusgleich
KbuTransferlauf
KbuTransferlauf_KbuBeleg

-- KES
KesAuftrag
KesAuftrag_BaPerson
KesBehoerde
KesDokument
KesPraevention
KesArtikel
KesMassnahme
KesMassnahme_KesArtikel
KesMandatsfuehrendePerson
KesMassnahmeBericht
KesMassnahmeAuftrag
KesVerlauf
KesPflegekinderaufsicht

-- log
UserSession
BaEinwohnerregisterPersonAnAbmeldung
BaEinwohnerregisterEmpfangeneEreignisseRohdaten
BaEinwohnerregisterEmpfangeneEreignisse
ServiceCall
ServiceProcessError
ServiceProcessErrorMessage
