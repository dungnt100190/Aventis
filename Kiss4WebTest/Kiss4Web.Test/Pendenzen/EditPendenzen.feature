Feature: Pendenzen - Edit Pendenzen
	Edit a task
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

@EditPendenzen
Scenario: 01 Switch to edit mode of status in Bearbeitung 
	Given logon with username is 'test_admin_1', password is '123456'
	And go to page Pendenzen
	And choose row 2 on grid Pendenzen
	When click on button Bearbeiten 
	Then these items are disabled: LeftNavMenu, SearchArea, GridTask
	And Pendenzen detail area switches to edit mode of status in Bearbeitung
	# disable status of elements as below:
	| Status | Pendenz Typ | Betreff | Beschreibung | Ersteller | Empfänger | Fallträger | Leistung | Leistungsverantw. | betrifft Person | Antwort | Erfasst | Fällig | 
	| true   | true        | true    | true         | true      | true      | true       | false    | true              | true            | false   | true    | true   | 

@EditPendenzen
Scenario: 02 Edit Pendenzen of status in Bearbeitung 
	Given logon with username is 'test_admin_1', password is '123456'
	And go to page Pendenzen
	And choose row 2 on grid Pendenzen
	And click on button Bearbeiten
	When choose 'F - Fallführung (10.01.2018 -)' in dropdown Leistung 
	And input 'Update 20180817-8 text' into textarea Antwort
	And click on button Speichern
	Then these items are enabled: LeftNavMenu, SearchArea, GridTask
	And Pendenzen detail area switches to view mode
	And content of Pendenzen detail area should be
	| Status         | Pendenz Typ | Betreff          | Beschreibung             | Ersteller                  | Empfänger                  | Fallträger               | Leistung                       | Leistungsverantw.          | betrifft Person   | Antwort                | Erfasst    | Fällig     | Bearbeitung | Erledigt |
	| in Bearbeitung | Fristablauf | Task 20180817-08 | Task 20180817-8 autotest | test_admin_1 - Global, CMC | test_admin_1 - Global, CMC | Person test-1, NT (BPS1) | F - Fallführung (10.01.2018 -) | test_admin_1 - Global, CMC | Person test-1, NT | Update 20180817-8 text | 10.05.2018 | 10.10.2018 | NULL        | NULL     |

@EditPendenzen 
Scenario: 03 Edit Un-Successfully
	Given logon with username is 'test_admin_1', password is '123456'
	And go to page Pendenzen
	And choose row 1 on grid Pendenzen
	And click on button Bearbeiten
	When clear data in textbox Betreff
	And click on button Speichern
	Then display error message at below of textbox Betreff with content is: 'Das Feld 'Betreff' darf nicht leer bleiben ! '