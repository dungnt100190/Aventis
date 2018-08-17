namespace Kiss.Infrastructure.Constant
{
    public partial class LOVsGenerated
    {
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

        /// <summary>
        /// Art der Zugehörigkeit eines Benutzers zu einer Benutzergruppe.
        /// </summary>
        public enum OrgUnitMember
        {
            LeiterIn = 1,
            Mitglied = 2,
            Gast = 3
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
            Ueberpruefung = 1,
            Bearbeitung = 3,
            Fristablauf = 4,
            Rueckmeldung = 5,
            Anfrage = 6,
            Auftragserteilung = 7,
            NewodDatenMeldung = 8,
            Diverses = 10,
            Gespraechvorbereiten = 12,
            KontrolleAnfangszustandBfs = 14,
            Kontrolle = 15,
            FristablaufPerson14 = 20,
            FristablaufPerson18 = 21,
            FristablaufPerson25 = 22,
            AblaufEfbErwerbsaufnahme = 25,
            AHVVorbezugPensionFrau = 26,
            AHVVorbezugPensionMann = 27,
            BeratungAusstattungVertragAuswertungAm = 28,
            FristKategorisierung = 29,
            IntakeAusstattungVertragAuswertungAm = 30,
            PensionsalterFrau = 31,
            PensionsalterMann = 32,
            WarnungVorEndeFinanzplan = 33,
            AblaufDienstleistungspaket = 40,
            FristablaufAbklaerungAuftragErledigungSd = 41,
            FristablaufAbklaerungAuftragErledigung = 42,
            FristablaufMassnahmenBerichtsUndRechnungsablageVersand = 43,
            FristablaufMassnahmenBerichtsUndRechnungsablageVerfuegungKesb = 44,
            FristablaufMassnahmenAuftraegeAntraegeVersand = 45,
            UnbefristetesGastrechtErteilen = 51,
            BefristetesGastrechtErteilen = 52,
        }

        public enum VmKategorie
        {
            Vermoegen = 1,
            Einnahmen = 2,
            FixeKosten = 3,
            VariableKosten = 4
        }

        public enum VmKlientenbudgetStatus
        {
            /// <summary>
            /// in Bearbeitung: 1
            /// </summary>
            InBearbeitung = 1,

            /// <summary>
            /// in Ordnung: 2
            /// </summary>
            InOrdnung = 2,

            /// <summary>
            /// Archiviert: 3
            /// </summary>
            Archiviert = 3
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

        public enum XTaskTypeActionType
        {
            /// <summary>
            /// Bewilligen: 1
            /// </summary>
            Bewilligen = 1,

            /// <summary>
            /// Ablehnen: 2
            /// </summary>
            Ablehnen = 2,

            /// <summary>
            /// Anfangszustand erstellen: 3
            /// </summary>
            AnfangszustandErstellen = 3
        }
    }
}