Feature: Pendenzen - Create Pendenzen
	Create a new Task
	Background:
	Given these XUser
	| UserID | PermissionGroupID | GrantPermGroupID | LogonName    | PasswordHash | FirstName | LastName | ShortName | IsLocked | IsUserAdmin | IsUserBIAGAdmin | IsMandatsTraeger | GenderCode | KeinBDEExport | MigUserFix | VerID  |
	| USR1   | 9                 | 9                | test_admin_1 | kR9Y+JkxEwo= | CMC       | Global   | cg        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 257000 |
	| USR2   | 9                 | 9                | test_admin_2 | kR9Y+JkxEwo= | CMC       | Soft     | cs        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 258000 |

	And these BaPerson
	| BaPersonID | Name          | Vorname |
	| BPS1       | Person test-1 | NT      |
	| BPS2       | Person test-2 | NULL    |

	#And these XModul
	#| ModulID | ShortName | 
	#| MOD1    | M1        | 
	#| MOD2    | M2        | 
	#| 2       | F         | 
	#| 7       | K         | 

	#And these FaFall
	#| FaFallID | UserID | BaPersonID |
	#| BPS1     | USR1   | BPS1       |
	#| BPS2     | USR2   | BPS2       |

	And these FaLeistung
	| FaLeistungID | BaPersonID | FaFallID | ModulID | UserID | IkHatUnterstuetzung | IkIstRentenbezueger | IkSchuldnerMahnen | WiederholteSpezifischeErmittlungEAF | DatumVon                |
	| LEI1         | BPS1       | BPS1     | 2       | USR1   | 0                   | 0                   | 1                 | 0                                   | 2018-01-10 00:00:00.000 |
	| LEI2         | BPS1       | BPS2     | 7       | USR1   | 0                   | 0                   | 1                 | 0                                   | 2018-02-10 00:00:00.000 |
	| LEI3         | BPS2       | BPS1     | 7       | USR2   | 0                   | 0                   | 1                 | 0                                   | 2018-03-10 00:00:00.000 |
	| LEI4         | BPS2       | BPS2     | 2       | USR2   | 0                   | 0                   | 1                 | 0                                   | 2018-04-10 00:00:00.000 |
	
	And these XTask
	| XTaskID | BaPersonID | TaskStatusCode | TaskTypeCode | Subject          | SenderID | ReceiverID | FaFallID | FaLeistungID | CreateDate              | ExpirationDate          | StartDate               | DoneDate | TaskDescription           | ResponseText          | TaskReceiverCode | TaskSenderCode |
	| TSK1    | BPS1       | 1              | 4            | Task 20180817-01 | USR2     | USR1       | BPS1     | LEI1         | 2018-10-01 00:00:00.000 | 2020-10-01 00:00:00.000 |                         | NULL     | Task 20180817-1 autotest  | Task 20180817-1 text  | 1                |                |
	| TSK2    | BPS1       | 2              | 4            | Task 20180817-08 | USR1     | USR1       | BPS1     | LEI3         | 2018-10-01 00:00:00.000 | 2018-10-01 00:00:00.000 | 2018-05-10 00:00:00.000 | NULL     | Task 20180817-8 autotest  | Task 20180817-8 text  | 1                | 1              |
	
@CreatePendenzen
Scenario: 01 Create a new task successfully
	Given logon with username is 'test_admin_1', password is '123456'
	And go to page Pendenzen
	And click on button Neus Pendenz
	When input into Pendenzen detail area as below
	| Pendenz Typ | Betreff         | Beschreibung             | Empfänger                            | Fallträger | Leistung | betrifft Person | Fällig                |
	| Anfrage     | Insert 20180830 | Insert 20180830 autotest | Kurzel=test_admin_1/Name=Global, CMC | NULL       | NULL     | NULL            | 01.11.2120 dd.MM.yyyy |
	And click on button Speichern
	And on grid Pendenzen: click button search in field 'Fällig', choose option 'Ist gleich' and input '01.11.2120'
	And choose row 1 on grid Pendenzen
	Then the record of the inputted info is inserted into table XTask in database
	And data of grid Pendenzen should be
	| Fällig     | Betreff         | Leistung | Fallträger | Fallnummer | Person | Ersteller                  | Empfänger                  | Status         | Erfasst          | Bearbeitung | Erledigt | Antwort |
	| 01.11.2120 | Insert 20180830 | NULL     | NULL       | NULL       | NULL   | test_admin_1 - Global, CMC | test_admin_1 - Global, CMC | Pendent        | TODAY dd.MM.yyyy | NULL        | NULL     | NULL    |
	And Pendenzen detail area switches to view mode
	And content of Pendenzen detail area should be
	| Status  | Pendenz Typ | Betreff         | Beschreibung             | Ersteller                  | Empfänger                  | Fallträger | Leistung | Leistungsverantw. | betrifft Person | Antwort | Erfasst          | Fällig     | Bearbeitung | Erledigt |
	| Pendent | Anfrage     | Insert 20180830 | Insert 20180830 autotest | test_admin_1 - Global, CMC | test_admin_1 - Global, CMC | NULL       | NULL     | NULL              | NULL            | NULL    | TODAY dd.MM.yyyy | 01.11.2120 | NULL        | NULL     |
	And on tree LeftNavMenu: value of Meine Pendenzen/offene is 'offene (3)'
	And on tree LeftNavMenu: value of Erstellte Pendenzen/offene is 'offene (2)'
	
@CreatePendenzen
Scenario: 02 Create new a task unsuccessfully when no input into Betreff field
	Given logon with username is 'test_admin_1', password is '123456'
	And go to page Pendenzen
	And click on button Neus Pendenz
	When input into Pendenzen detail area as below
	| Pendenz Typ | Betreff | Beschreibung             | Empfänger                            | Fallträger | Leistung | betrifft Person | Fällig |
	| Anfrage     | NULL    | Insert 20180830 autotest | Kurzel=test_admin_1/Name=Global, CMC | NULL       | NULL     | NULL            | NULL   |
	And click on button Speichern
	Then display error message at top of page content with content is: 'Das Feld 'Betreff' darf nicht leer bleiben !'
	
@CreatePendenzen
Scenario: 03 Create new a task unsuccessfully when cancel 
	Given logon with username is 'test_admin_1', password is '123456'
	And go to page Pendenzen
	And click on button Neus Pendenz
	When input into Pendenzen detail area as below
	| Pendenz Typ | Betreff         | Beschreibung             | Empfänger                            | Fallträger | Leistung | betrifft Person | Fällig                |
	| Anfrage     | Insert 20180830 | Insert 20180830 autotest | Kurzel=test_admin_1/Name=Global, CMC | NULL       | NULL     | NULL            | 01.11.2020 dd.MM.yyyy |
	And click on button Abbrechen
	And click on button Ja
	Then the record of the inputted info is not inserted into table XTask in database
	And Pendenzen detail area switches to view mode
	And data of grid Pendenzen should be
	| Fällig     | Betreff          | Leistung | Fallträger               | Fallnummer | Person            | Ersteller                  | Empfänger                  | Status         | Erfasst    | Bearbeitung | Erledigt | Antwort               |
	| 01.10.2020 | Task 20180817-01 | F        | Person test-1, NT (BPS1) | BPS1       | Person test-1, NT | NULL                       | test_admin_1 - Global, CMC | Pendent        | 01.10.2018 | NULL        | NULL     | Task 20180817-1 text  |
	| 01.10.2018 | Task 20180817-08 | K        | Person test-2 (BPS1)     | BPS1       | Person test-1, NT | test_admin_1 - Global, CMC | test_admin_1 - Global, CMC | in Bearbeitung | 01.10.2018 | 10.05.2018  | NULL     | Task 20180817-8 text  |
	And on tree LeftNavMenu: value of Meine Pendenzen/offene is 'offene (2)'
	And on tree LeftNavMenu: value of Erstellte Pendenzen/offene is 'offene (1)'