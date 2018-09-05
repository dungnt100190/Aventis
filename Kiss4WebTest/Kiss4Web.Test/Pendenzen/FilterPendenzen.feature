Feature: Pendenzen - Filter Pendenzen
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
	| TSK1    | BPS1       | 1              | 4            | Task 20180817-01 | USR2     | USR1       | BPS1     | LEI1         | 2018-01-10 00:00:00.000 | 2020-01-10 00:00:00.000 |                         | NULL     | Task 20180817-1 autotest  | Task 20180817-1 text  | 1                |                |
	| TSK2    | BPS1       | 2              | 4            | Task 20180817-08 | USR1     | USR1       | BPS1     | LEI3         | 2018-01-10 00:00:00.000 | 2018-10-10 00:00:00.000 | 2018-05-10 00:00:00.000 | NULL     | Task 20180817-8 autotest  | Task 20180817-8 text  | 1                | 1              |
	
@FilterPendenzen
Scenario: 01 Check Filter by 'Fällig' field
	Given logon with username is 'test_admin_1', password is '123456'
	And go to page Pendenzen
	When on grid Pendenzen: click button search in field 'Fällig', choose option 'Ist nicht gleich' and input '10.01.2020'
	Then data of grid Pendenzen should be
	| Fällig     | Betreff          | Leistung | Fallträger               | Fallnummer | Person            | Ersteller                  | Empfänger                  | Status         | Erfasst    | Bearbeitung | Erledigt | Antwort               |
	| 10.10.2018 | Task 20180817-08 | K        | Person test-2 (BPS1)     | BPS1       | Person test-1, NT | test_admin_1 - Global, CMC | test_admin_1 - Global, CMC | in Bearbeitung | 10.01.2018 | 10.05.2018  | NULL     | Task 20180817-8 text  |

@FilterPendenzen
Scenario: 02 Check Filter by 'Fällig' field
	Given logon with username is 'test_admin_1', password is '123456'
	And go to page Pendenzen
	When on grid Pendenzen: click button search in field 'Fällig', choose option 'Kleiner als' and input '10.10.2018'
	Then grid Pendenzen does not have data

@FilterPendenzen
Scenario: 03 Check Filter by 'Fällig' field
	Given logon with username is 'test_admin_1', password is '123456'
	And go to page Pendenzen
	When on grid Pendenzen: click button search in field 'Fällig', choose option 'Größer als' and input '10.10.2018'
	Then data of grid Pendenzen should be
	| Fällig     | Betreff          | Leistung | Fallträger               | Fallnummer | Person            | Ersteller                  | Empfänger                  | Status         | Erfasst    | Bearbeitung | Erledigt | Antwort               |
	| 10.01.2020 | Task 20180817-01 | F        | Person test-1, NT (BPS1) | BPS1       | Person test-1, NT | NULL                       | test_admin_1 - Global, CMC | Pendent        | 10.01.2018 | NULL        | NULL     | Task 20180817-1 text  |
		
@FilterPendenzen
Scenario: 04 Check Filter by 'Fällig' field
	Given logon with username is 'test_admin_1', password is '123456'
	And go to page Pendenzen
	When on grid Pendenzen: click button search in field 'Fällig', choose option 'Ist gleich' and input '10.10.2018'
	Then data of grid Pendenzen should be
	| Fällig     | Betreff          | Leistung | Fallträger               | Fallnummer | Person            | Ersteller                  | Empfänger                  | Status         | Erfasst    | Bearbeitung | Erledigt | Antwort               |
	| 10.10.2018 | Task 20180817-08 | K        | Person test-2 (BPS1)     | BPS1       | Person test-1, NT | test_admin_1 - Global, CMC | test_admin_1 - Global, CMC | in Bearbeitung | 10.01.2018 | 10.05.2018  | NULL     | Task 20180817-8 text  |
