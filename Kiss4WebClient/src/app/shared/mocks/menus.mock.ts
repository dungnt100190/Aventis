import { MenuModel } from './../models';

export const MenusMock: MenuModel[] = [
    {
        id: '1',
        name: 'Datei',
        items: [
            {
                id: '1_1',
                name: 'Drucken',
                sort: 1,
                iconSrc: 'assets/icon/item-menu.png',
                url: '/persons',
            }, {
                id: '1_2',
                name: 'Anmelden',
                iconSrc: 'assets/icon/item-menu.png',
                url: '/dossier',
                sort: 2
            }, {
                id: '1_3',
                name: 'Abmelden',
                iconSrc: 'assets/icon/item-menu.png',
                url: '/pendenzen',
                sort: 3
            }, {
                id: '1_4',
                name: 'Passwort ändern',
                iconSrc: 'assets/icon/item-menu.png',
                url: '/pendenzen',
                sort: 4
            }, {
                id: '1_5',
                name: 'Sprache wechseln',
                iconSrc: 'assets/icon/item-menu.png',
                url: '/pendenzen',
                sort: 5
            }, {
                id: '1_6',
                name: 'Beenden',
                iconSrc: 'assets/icon/item-menu.png',
                url: '/pendenzen',
                sort: 6
            }
        ]
    },
    {
        id: '2',
        name: 'Bearbeiten',
        items: [
            {
                id: '2_1',
                name: 'Neu',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 1
            }, {
                id: '2_2',
                name: 'Speichern',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 2
            }, {
                id: '2_3',
                name: 'Rückgängig',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 3
            }, {
                id: '2_4',
                name: 'Löschen',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 4
            }, {
                id: '2_5',
                name: 'Anfang',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 5
            }, {
                id: '2_6',
                name: 'Vorheriger',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 6
            }, {
                id: '2_7',
                name: 'Nächster',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 7
            }, {
                id: '2_8',
                name: 'Ende',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 8
            }, {
                id: '2_9',
                name: 'Aktualisieren',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 9
            }, {
                id: '2_10',
                name: 'Ausschneiden',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 10
            }, {
                id: '2_11',
                name: 'Kopieren',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 11
            }, {
                id: '2_12',
                name: 'Einfügen',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 12
            }, {
                id: '2_13',
                name: 'Suche',
                iconSrc: 'assets/icon/item-menu.png',
                url: '',
                sort: 13
            }
        ]
    },
    {
        id: '3',
        name: 'Anwendung',
        items: [{
            id: '3_1',
            name: 'Fall-Navigator',
            iconSrc: 'assets/icon/item-menu.png',
            url: 'dossier',
            sort: 1
        }, {
            id: '3_2',
            name: 'Daten-Explorer',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 2
        }, {
            id: '3_3',
            name: 'Gehe zu',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 3
        }, {
            id: '3_4',
            name: 'Fallsteuerung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 4
        }, {
            id: '3_5',
            name: 'Zeiterfassung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 5
        }, {
            id: '3_6',
            name: 'Pendenz erfassen',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 6
        }, {
            id: '3_7',
            name: 'Pendenzenverwaltung',
            iconSrc: 'assets/icon/item-menu.png',
            url: 'pendenzen',
            sort: 7
        }, {
            id: '3_8',
            name: 'Mandatsbuchhaltung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 8
        }, {
            id: '3_9',
            name: 'Klientenbuchhaltung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 9
        }, {
            id: '3_10',
            name: 'Kontenabfrage aus KiSS',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 10
        }, {
            id: '3_11',
            name: 'SH - Auszahlungen',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 11
        }, {
            id: '3_12',
            name: 'SH - Krankenkassenprämien',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 12
        }, {
            id: '3_13',
            name: 'SH - Kasse',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 13
        }, {
            id: '3_14',
            name: 'AY - Kasse',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 14
        }, {
            id: '3_15',
            name: 'VM - Kasse',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 15
        }, {
            id: '3_16',
            name: 'VM Fallgewichtung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 16
        }, {
            id: '3_17',
            name: 'NEWOD Schnittstelle',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 17
        }]
    },
    {
        id: '4',
        name: 'KA',
        items: [{
            id: '4_1',
            name: 'Präsenzzeiterfassung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 1
        }, {
            id: '4_2',
            name: 'Sequenzen',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 2
        }, {
            id: '4_3',
            name: 'AMM Bescheinigung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 3
        }, {
            id: '4_4',
            name: 'KA Einsatzorte',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 4
        }, {
            id: '4_5',
            name: 'Einsatzplatz',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 5
        }, {
            id: '4_6',
            name: 'Kurse',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 6
        }, {
            id: '4_7',
            name: 'Kurserfassung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 7
        }, {
            id: '4_8',
            name: 'Lehrberufe',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 8
        }, {
            id: '4_9',
            name: 'Externe Berater',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 9
        }]
    },
    {
        id: '5',
        name: 'Stammdaten',
        items: [{
            id: '5_1',
            name: 'Personen-Stamm',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 1
        }, {
            id: '5_2',
            name: 'Institutionen-Stamm',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 2
        }]
    },
    {
        id: '6',
        name: 'System',
        items: [{
            id: '6_1',
            name: 'Benutzerverwaltung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 1
        }, {
            id: '6_2',
            name: 'Archivverwaltung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 2
        }, {
            id: '6_3',
            name: 'Vorlagenverwaltung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 3
        }, {
            id: '6_4',
            name: 'Pendenzenadministration',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 4
        }, {
            id: '6_5',
            name: 'Reportsdefinition',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 5
        }, {
            id: '6_6',
            name: 'Linkverwaltung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 6
        }, {
            id: '6_7',
            name: 'Konfiguration',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 7
        }, {
            id: '6_8',
            name: 'Modul Konfiguration',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 8
        }, {
            id: '6_9',
            name: 'Meldungen',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 9
        }, {
            id: '6_10',
            name: 'Eigene Maske',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 10
        }, {
            id: '6_11',
            name: 'Business Designer',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 11
        }, {
            id: '6_12',
            name: 'Dateneditor',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 12
        }, {
            id: '6_13',
            name: 'Datenbereinigung',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 13
        }, {
            id: '6_14',
            name: 'SOSTAT',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 14
        }, {
            id: '6_15',
            name: 'KOKES',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 15
        }, {
            id: '6_16',
            name: 'ASV Export',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 16
        }]
    },
    {
        id: '7',
        name: 'Favoriten',
        items: [{
            id: '7_1',
            name: '&Speichern',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 1
        }, {
            id: '7_2',
            name: 'Speichern &unter...',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 2
        }, {
            id: '7_3',
            name: '&Favoritenverwaltung...',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 3
        }, {
            id: '7_4',
            name: 'Aktuelle Suche &zurücksetzen',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 4
        }]
    },
    {
        id: '8',
        name: 'Links',
        items: [{
            id: '8_1',
            name: 'DummyLink',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 1
        }]
    },
    {
        id: '9',
        name: 'Fenster',
        items: [{
            id: '9_1',
            name: '&Alle schliessen',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 1
        }, {
            id: '9_2',
            name: 'Startlayout festlegen',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 2
        }, {
            id: '9_3',
            name: 'Alle Fenstereinstellungen löschen',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 3
        }]
    },
    {
        id: '10',
        name: 'Hilfe',
        items: [{
            id: '10_1',
            name: 'KiSS Handbücher',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 1
        }, {
            id: '10_2',
            name: 'TeamViewer starten (Fernwartung)',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 2
        }, {
            id: '10_3',
            name: 'Mantis starten (Wartungsprotokoll)',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 3
        }, {
            id: '10_4',
            name: 'Über',
            iconSrc: 'assets/icon/item-menu.png',
            url: '',
            sort: 4
        }]
    }
];
