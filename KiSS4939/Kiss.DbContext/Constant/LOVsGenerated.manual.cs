namespace Kiss.DbContext.Constant
{
    public partial class LOVsGenerated
    {
        public enum BaEinwohnerregisterEmpfangeneEreignisseRohdatenStatus
        {
            /// <summary>
            /// Pendent: 1
            /// </summary>
            Pendent = 1,

            /// <summary>
            /// Import fehlerhaft: 2
            /// </summary>
            ImportFehlerhaft = 2,

            /// <summary>
            /// Ignoriert: 3
            /// </summary>
            Ignoriert = 3,

            /// <summary>
            /// Import erfolgreich: 4
            /// </summary>
            ImportErfolgreich = 4,
        }

        public enum BgEinzahlungsschein
        {
            OrangerEinzahlungsschein = 1,
            RoterEinzahlungsscheinPost = 2,
            BankzahlungSchweiz = 3,
            BankzahlungAusland = 4,
            RoterEinzahlungsscheinBank = 5,
            Postmandat = 6
        }

        public enum DocFormat
        {
            Unbekannt = 0,
            Word = 1,
            Excel = 2,
            Pdf = 3,
        }

        public enum FaKategorisierungEksProduktFristTyp
        {
            /// <summary>
            /// Tag: 1
            /// </summary>
            Tag = 1,

            /// <summary>
            /// Monat: 2
            /// </summary>
            Monat = 2,

            /// <summary>
            /// Jahr: 3
            /// </summary>
            Jahr = 3
        }

        public enum FaProzess
        {
            Fallfuehrung = 200,
            Existenzsicherung = 10301,
            Platzierung = 10302
        }

        /// <summary>
        /// Alle Status die eine Weisung haben kann
        /// </summary>
        public enum FaWeisungStatus
        {
            /// <summary>
            ///Init: 0
            /// </summary>
            Init = 0,

            /// <summary>
            ///WeisungBearbeiten: 1
            /// </summary>
            WeisungBearbeiten = 1,

            /// <summary>
            ///PruefungRD: 2
            /// </summary>
            PruefungRD = 2,

            /// <summary>
            ///WeisungPruefen: 3
            /// </summary>
            WeisungPruefen = 3,

            /// <summary>
            ///Mahnung1Bearbeiten: 11
            /// </summary>
            Mahnung1Bearbeiten = 11,

            /// <summary>
            ///Mahnung1PruefungRD: 12
            /// </summary>
            Mahnung1PruefungRD = 12,

            /// <summary>
            ///Mahnung1Pruefen: 13
            /// </summary>
            Mahnung1Pruefen = 13,

            /// <summary>
            ///Mahnung2Bearbeiten: 21
            /// </summary>
            Mahnung2Bearbeiten = 21,

            /// <summary>
            ///Mahnung2PruefungRD: 22
            /// </summary>
            Mahnung2PruefungRD = 22,

            /// <summary>
            ///Mahnung2Pruefen: 23
            /// </summary>
            Mahnung2Pruefen = 23,

            /// <summary>
            ///Mahnung3Bearbeiten: 31
            /// </summary>
            Mahnung3Bearbeiten = 31,

            /// <summary>
            ///Mahnung3PruefungRD: 32
            /// </summary>
            Mahnung3PruefungRD = 32,

            /// <summary>
            ///Mahnung3Pruefen: 33
            /// </summary>
            Mahnung3Pruefen = 33,

            /// <summary>
            ///VerfuegungBearbeiten: 41
            /// </summary>
            VerfuegungBearbeiten = 41,

            /// <summary>
            ///VerfuegungPruefungRD: 42
            /// </summary>
            VerfuegungPruefungRD = 42,

            /// <summary>
            ///SanktionEinrichten: 55
            /// </summary>
            SanktionEinrichten = 55,

            /// <summary>
            ///SanktionErfassen: 56
            /// </summary>
            SanktionErfassen = 56,

            /// <summary>
            ///SanktionErfasst: 57
            /// </summary>
            SanktionErfasst = 57,

            /// <summary>
            ///Fertig: 99
            /// </summary>
            Fertig = 99
        }

        /// <summary>
        /// Gesuchverwaltung: Art der Antrag-Position
        /// </summary>
        public enum GvAntragPositionTyp
        {
            /// <summary>
            /// Kosten: 1
            /// </summary>
            Kosten = 1,

            /// <summary>
            /// beantragter Betrag: 2
            /// </summary>
            BeantragterBetrag = 2,

            /// <summary>
            /// Finanzierung: 3
            /// </summary>
            Finanzierung = 3,

            /// <summary>
            /// Eigenleistung: 4
            /// </summary>
            Eigenleistung = 4,
        }

        /// <summary>
        /// Art der Auflage
        /// </summary>
        public enum GvAuflageTyp
        {
            /// <summary>
            /// Rückerstattung: 1
            /// </summary>
            Rueckerstattung = 1,

            /// <summary>
            /// Abmachung: 2
            /// </summary>
            Abmachung = 2
        }

        /// <summary>
        /// Gesuchverwaltung: Auszahlungsart einer GvAuszahlungPosition
        /// </summary>
        public enum GvAuszahlungArt
        {
            /// <summary>
            /// Elektronische Auszahlung: 101
            /// </summary>
            ElektronischeAuszahlung = 101,

            /// <summary>
            /// Papierverfügung: 102
            /// </summary>
            Papierverfuegung = 102
        }

        /// <summary>
        /// Gesuchverwaltung: Status des GvAuszahlungPosition
        /// </summary>
        public enum GvAuszahlungPositionStatus
        {
            /// <summary>
            /// in Vorbereitung: 1
            /// </summary>
            InVorbereitung = 1,

            /// <summary>
            /// Bewilligung erteilt: 5
            /// </summary>
            BewilligungErteilt = 5,

            /// <summary>
            /// Importiert: 7
            /// </summary>
            Importiert = 7,

            /// <summary>
            /// Gesperrt: 9
            /// </summary>
            Gesperrt = 9
        }

        /// <summary>
        /// Art des Termins einer GvAuszahlung
        /// </summary>
        public enum GvAuszahlungTerminArt
        {
            /// <summary>
            /// Valuta: 1
            /// </summary>
            Valuta = 1,

            /// <summary>
            /// Individuell: 2
            /// </summary>
            Individuell = 2
        }

        /// <summary>
        /// Gesuchverwaltung: Aktion von GV Bewilligungen
        /// </summary>
        public enum GvBewilligung
        {
            /// <summary>
            /// Erfassung abschliessen: 1
            /// </summary>
            ErfassungAbschliessen = 1,

            /// <summary>
            /// Abschluss aufheben: 2
            /// </summary>
            AbschlussAufheben = 2,

            /// <summary>
            /// Bearbeitung abschliessen: 3
            /// </summary>
            BearbeitungAbschliessen = 3,

            /// <summary>
            /// Gesuch zurückweisen: 4
            /// </summary>
            GesuchZurueckweisen = 4,

            /// <summary>
            /// Prüfung abschliessen: 5
            /// </summary>
            PruefungAbschliessen = 5,

            /// <summary>
            /// Gesuch weiterleiten CH: 6
            /// </summary>
            GesuchWeiterleitenCh = 6,

            /// <summary>
            /// Zahlungen ausführen: 7
            /// </summary>
            ZahlungenAusfuehren = 7,

            /// <summary>
            /// Auflagen erledigen: 8
            /// </summary>
            AuflagenErledigen = 8,

            /// <summary>
            /// Gesuch abschliessen: 9
            /// </summary>
            GesuchAbschliessen = 9,
        }

        public enum GvFondsTyp
        {
            /// <summary>
            /// Intern: 1
            /// </summary>
            Intern = 1,

            /// <summary>
            /// Extern: 2
            /// </summary>
            Extern = 2,
        }

        /// <summary>
        /// Gesuchverwaltung: Werteliste für den Status eines Gesuchs
        /// </summary>
        public enum GvStatus
        {
            /// <summary>
            /// in Erfassung: 1
            /// </summary>
            InErfassung = 1,

            /// <summary>
            /// in Bearbeitung: 2
            /// </summary>
            InBearbeitung = 2,

            /// <summary>
            /// in Prüfung: 3
            /// </summary>
            InPruefung = 3,

            /// <summary>
            /// in Prüfung CH: 4
            /// </summary>
            InPruefungCh = 4,

            /// <summary>
            /// beurteilt: 5
            /// </summary>
            Beurteilt = 5,

            /// <summary>
            /// Auflagen hängig: 6
            /// </summary>
            AuflagenHaengig = 6,

            /// <summary>
            /// abgeschlossen : 7
            /// </summary>
            Abgeschlossen = 7,
        }

        /// <summary>
        /// Alle Status die eine Weisung haben kann
        /// </summary>
        public enum KbBuchungsStatus
        {
            /// <summary>
            ///vorbereitet:1
            /// </summary>
            Vorbereitet = 1,

            /// <summary>
            ///freigegeben:2
            /// </summary>
            Freigegeben = 2,

            /// <summary>
            ///ZahlauftragErstellt:3
            /// </summary>
            ZahlauftragErstellt = 3,

            /// <summary>
            ///Barbeleg ausgedruckt:4
            /// </summary>
            BarbelegAusgedruckt = 4,

            /// <summary>
            ///ZahlauftragFehlerhaft:5
            /// </summary>
            ZahlauftragFehlerhaft = 5,

            /// <summary>
            ///ausgeglichen:6
            /// </summary>
            Ausgeglichen = 6,

            /// <summary>
            ///gesperrt:7
            /// </summary>
            Gesperrt = 7,

            /// <summary>
            ///storniert:8
            /// </summary>
            Storniert = 8,

            /// <summary>
            ///Rückläufer:9
            /// </summary>
            Ruecklaeufer = 9,

            /// <summary>
            ///teilweise ausgeglichen:10
            /// </summary>
            TeilweiseAusgeglichen = 10,

            /// <summary>
            ///Barbezug:11
            /// </summary>
            Barbezug = 11,

            /// <summary>
            ///angefragt:12
            /// </summary>
            Angefragt = 12,

            /// <summary>
            ///verbucht:13
            /// </summary>
            Verbucht = 13,

            /// <summary>
            ///bewilligt:14
            /// </summary>
            Bewilligt = 14,

            /// <summary>
            ///abgelehnt:15
            /// </summary>
            Abgelehnt = 15,
        }

        public enum KesAuftragAbklaerungsart
        {
            Adoption = 1,
            AuftragNachArt392ZGB = 2,
            GefährdungsmeldungES = 3,
            GefährdungsmeldungKS = 4,
            GemeinsameElterlicheSorgeKS = 4,
            HilfestellungES = 6,
            HilfestellungKS = 7,
            SchutzInWohnPflegeeinrichtung = 8,
            Vorsorgeauftrag = 9,
            VaterschaftsUndUnterhaltsregelung = 10,
            Pflegeplatz = 11
        }

        public enum KesBeistandsart
        {
            Privatperson = 1,
            Berufsbeistand = 2,
            Fachbeistand = 3
        }

        public enum KesDokumentTyp
        {
            AuftragDokument = 1,
            MassnahmenfuehrungDokument = 2
        }

        public enum KesPflegeart
        {
            Familienpflege = 1,
            Tagespflege = 2
        }

        public enum KesVerlaufTyp
        {
            PriMaBegleitung = 1,
            Pflegekinderaufsicht = 2
        }

        /// <summary>
        /// Art der Zugehörigkeit eines Benutzers zu einer Benutzergruppe.
        /// </summary>
        public enum OrgUnitMember
        {
            LeiterIn = 1,
            Mitglied = 2,
            Gast = 3
        }

        public enum TaskReceiver
        {
            Person = 1,
            Gruppe = 2
        }

        public enum TaskResponse
        {
            Positiv = 1,
            Negativ = 2
        }

        public enum TaskSender
        {
            Person = 1,
            Regel = 3,
            Einwohnerregister = 4,
            DbScript = 5
        }

        public enum TaskStatus
        {
            /// <summary>
            /// Pendent: 1
            /// </summary>
            Pendent = 1,

            /// <summary>
            /// in Bearbeitung: 2
            /// </summary>
            InBearbeitung = 2,

            /// <summary>
            /// Erledigt: 3
            /// </summary>
            Erledigt = 3,

            /// <summary>
            /// Verfallen: 4
            /// </summary>
            Verfallen = 4
        }

        public enum TaskType
        {
            /// <summary>
            /// Einwohnerregister-Daten Meldung: 8
            /// </summary>
            EinwohnerregisterDatenMeldung = 8,

            /// <summary>
            /// 41
            /// </summary>
            FristablaufAbklaerungAuftragErledigungSd = 41,

            /// <summary>
            /// 42
            /// </summary>
            FristablaufAbklaerungAuftragErledigung = 42,

            /// <summary>
            /// 43
            /// </summary>
            FristablaufMassnahmenBerichtsUndRechnungsablageVersand = 43,

            /// <summary>
            /// 44
            /// </summary>
            FristablaufMassnahmenBerichtsUndRechnungsablageVerfuegungKesb = 44,

            /// <summary>
            /// 45
            /// </summary>
            FristablaufMassnahmenAuftraegeAntraegeVersand = 45,

            /// <summary>
            /// 46
            /// </summary>
            FristablaufMassnahmenAuftraegeAntraegeErledigung = 46,

            /// <summary>
            /// 51
            /// </summary>
            UnbefristesGastrechtErteilen = 51,

            /// <summary>
            /// 52
            /// </summary>
            BefristesGastrechtErteilen = 52
        }

        public enum VmPositionsartTyp
        {
            /// <summary>
            /// VmPositionsartTypCode ist leer: 0
            /// </summary>
            Empty = 0,

            /// <summary>
            /// Vermögen: Kasse + PC: 1
            /// </summary>
            VermKassePc = 1,

            /// <summary>
            /// Vermögen Betriebskonto: 2
            /// </summary>
            VermBetriebskonto = 2,

            /// <summary>
            /// Vermögen Depot BS: 3
            /// </summary>
            VermDepotBs = 3,

            /// <summary>
            /// Vermögen Total: 4
            /// </summary>
            VermTotal = 4,

            /// <summary>
            /// Vermögen EL-Freibetrag: 5
            /// </summary>
            VermElFreibetrag = 5,

            /// <summary>
            /// Vermögen EL-Berechnung: 6
            /// </summary>
            VermElBerechnung = 6,

            /// <summary>
            /// Einnahmen IV-Rente: 7
            /// </summary>
            EinnIvRente = 7,

            /// <summary>
            /// Einnahmen AHV-Rente: 8
            /// </summary>
            EinnAhvRente = 8,

            /// <summary>
            /// Einnahmen Anteil aus Vermögen: 9
            /// </summary>
            EinnAnteilAusVermoegen = 9,

            /// <summary>
            /// Ausgaben Krankenkassenprämien KVG: 10
            /// </summary>
            AusgKkPraemienKvg = 10,

            /// <summary>
            /// Ausgaben Krankenkassenprämien VVG: 1§
            /// </summary>
            AusgKkPraemienVvg = 11,

            /// <summary>
            /// Ausgaben Heimkosten: 12
            /// </summary>
            AusgHeimkosten = 12,

            /// <summary>
            /// Ausgaben Mietzins: 13
            /// </summary>
            AusgMietzins = 13,

            /// <summary>
            /// Ausgaben Heiz- und Nebenkosten: 14
            /// </summary>
            AusgHeizUndNebenkosten = 14,

            /// <summary>
            /// Ausgaben Energie: 15
            /// </summary>
            AusgEnergie = 15,

            /// <summary>
            /// Ausgaben AHV-Beiträge: 16
            /// </summary>
            AusgAhvBeitraege = 16
        }

        /// <summary>
        /// Mappt auf die Tabelle WshKategorie, Feld WshKategorieID.
        /// gelöscht worden ist.
        /// </summary>
        public enum WshKategorie
        {
            Ausgabe = 1,
            Einnahme = 2,
            Sanktion = 3,
            Verrechnung = 4,
            Rueckerstattung = 5,
            Abzahlung = 6,
            Kuerzung = 7,
            Vermoegen = 8,
            Vorabzug = 9,
            Unbekannt = 100,
        }

        public enum XTaskAutoGeneratedType
        {
            WarnungVorEndeFinanzplan = 0,
            Person18 = 1,
            Person25 = 2,
            PensionsalterFrau = 3,
            AhvVorbezugPensionFrau = 4,
            PensionsalterMann = 5,
            AHVVorbezugPensionMann = 6,
            AblaufEfbErwerbsaufnahme = 7,
            KontrolleAblaufDlp = 8,
            AuswertungBeratungsphase = 9,
            AuswertungIntakephase = 10,
            FristKategorisierung = 11,
            Person14 = 12,
            KesFrist = 13,
            UnbefristesGastrechtErteilen = 14,
            BefristesGastrechtErteilen = 15
        }
    }
}