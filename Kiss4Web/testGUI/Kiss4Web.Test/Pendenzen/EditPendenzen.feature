Feature: Edit Pendenzen
	Edit a task
	Background:
	Given these XUsers
	| UserID | PermissionGroupID | GrantPermGroupID | LogonName    | PasswordHash | FirstName | LastName | ShortName | IsLocked | IsUserAdmin | IsUserBIAGAdmin | IsMandatsTraeger | GenderCode | KeinBDEExport | MigUserFix | VerID  |
	| USR1   | 9                 | 9                | test_admin_1 | kR9Y+JkxEwo= | CMC       | Global   | cg        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 257000 |
	| USR2   | 9                 | 9                | test_admin_2 | kR9Y+JkxEwo= | CMC       | Soft     | cs        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 258000 |

	And these BaPersons
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

	And these FaLeistungs
	| FaLeistungID | BaPersonID | FaFallID | ModulID | UserID | IkHatUnterstuetzung | IkIstRentenbezueger | IkSchuldnerMahnen | WiederholteSpezifischeErmittlungEAF | DatumVon                |
	| LEI1         | BPS1       | BPS1     | 2       | USR1   | 0                   | 0                   | 1                 | 0                                   | 2018-01-10 00:00:00.000 |
	| LEI2         | BPS1       | BPS2     | 7       | USR1   | 0                   | 0                   | 1                 | 0                                   | 2018-02-10 00:00:00.000 |
	| LEI3         | BPS2       | BPS1     | 7       | USR2   | 0                   | 0                   | 1                 | 0                                   | 2018-03-10 00:00:00.000 |
	| LEI4         | BPS2       | BPS2     | 2       | USR2   | 0                   | 0                   | 1                 | 0                                   | 2018-04-10 00:00:00.000 |
	
	And these XTasks
	| XTaskID | BaPersonID | TaskStatusCode | TaskTypeCode | Subject          | SenderID | ReceiverID | FaFallID | FaLeistungID | CreateDate              | ExpirationDate          | StartDate               | DoneDate | TaskDescription           | ResponseText          | TaskReceiverCode | TaskSenderCode |
	| TSK1    | BPS1       | 1              | 4            | Task 20180817-01 | USR2     | USR1       | BPS1     | LEI1         | 2018-01-10 00:00:00.000 | 2020-01-10 00:00:00.000 |                         | NULL     | Task 20180817-1 autotest  | Task 20180817-1 text  | 1                |                |
	| TSK2    | BPS1       | 2              | 4            | Task 20180817-08 | USR1     | USR1       | BPS1     | LEI3         | 2018-01-10 00:00:00.000 | 2018-10-10 00:00:00.000 | 2018-05-10 00:00:00.000 | NULL     | Task 20180817-8 autotest  | Task 20180817-8 text  | 1                | 1              |

@EditPendenzen
Scenario: 01 Switch to edit mode of status in Bearbeitung 
	Given User has logon with username is test_admin_1, password is 123456
	And Page Pendenzen is redirected to
	And User choose row 2 on Grid Task
	When User click on button Bearbeiten 
	Then These items are disabled: NavbarMenu, SearchArea, GridTask
	And The Detail area switches to edit mode of status in Bearbeitung

@EditPendenzen
Scenario: 02 Edit Pendenzen of status in Bearbeitung 
	Given User has logon with username is test_admin_1, password is 123456
	And Page Pendenzen is redirected to
	And User choose row 2 on Grid Task
	And User clicked on button Bearbeiten
	When User choose F - Fallführung (10.01.2018 -) in dropdown Leistung 
	And User input Update 20180817-8 text into textbox Antwort
	And User click on button Speichern
	Then These items are enabled: NavbarMenu, SearchArea, GridTask
	And The Detail area switches to view mode
	And content of Detail area should be
	| status         | pendenzTyp  | betreff          | beschreibung             | ersteller                  | empfanger                  | falltrager               | leistung                       | leistungsverantw           | betrifftPerson    | antwort                | erfasst    | fallig     | bearbeitung | erledigt |
	| status         | pendenzTyp  | betreff          | beschreibung             | Ersteller                  | empfanger                  | falltrager               | leistung                       | leistungsverantw           | betrifftPerson    | antwort                | erfasst    | fallig     | Bearbeitung | Erledigt |
	| in Bearbeitung | Fristablauf | Task 20180817-08 | Task 20180817-8 autotest | test_admin_1 - Global, CMC | test_admin_1 - Global, CMC | Person test-1, NT (BPS1) | F - Fallführung (10.01.2018 -) | test_admin_1 - Global, CMC | Person test-1, NT | Update 20180817-8 text | 10.05.2018 | 10.10.2018 | NULL        | NULL     |
