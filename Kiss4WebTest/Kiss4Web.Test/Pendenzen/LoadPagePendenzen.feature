Feature: Load page Pendenzen
	Load page Pendenzen
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
	| TSK2    | BPS2       | 1              | 4            | Task 20180817-02 | USR2     | USR1       | BPS2     | LEI2         | 2018-01-10 00:00:00.000 | 2018-05-10 00:00:00.000 |                         | NULL     | Task 20180817-2 autotest  | Task 20180817-2 text  | 1                |                |
	| TSK3    | BPS1       | 2              | 6            | Task 20180817-03 | USR2     | USR1       | BPS2     | LEI4         | 2018-01-10 00:00:00.000 | 2018-10-10 00:00:00.000 | 2018-04-10 00:00:00.000 | NULL     | Task 20180817-3 autotest  | Task 20180817-3 text  | 1                |                |
	| TSK4    | BPS2       | 2              | 4            | Task 20180817-04 | USR2     | USR1       | BPS1     | LEI3         | 2018-01-10 00:00:00.000 | 2018-07-10 00:00:00.000 | 2018-06-10 00:00:00.000 | NULL     | Task 20180817-4 autotest  | Task 20180817-4 text  | 1                |                |
	| TSK5    | BPS2       | 1              | 6            | Task 20180817-05 | USR1     | USR2       | BPS1     | LEI1         | 2018-01-10 00:00:00.000 | 2019-02-10 00:00:00.000 |                         | NULL     | Task 20180817-5 autotest  | Task 20180817-5 text  | 1                | 1              |
	| TSK6    | BPS2       | 2              | 6            | Task 20180817-06 | USR1     | USR2       | BPS1     | LEI1         | 2018-01-10 00:00:00.000 | 2018-06-10 00:00:00.000 | 2018-03-10 00:00:00.000 | NULL     | Task 20180817-6 autotest  | Task 20180817-6 text  | 1                | 1              |
	| TSK7    | BPS2       | 2              | 2            | Task 20180817-07 | USR1     | USR2       | BPS2     | LEI2         | 2018-01-10 00:00:00.000 | 2018-09-10 00:00:00.000 | 2018-05-10 00:00:00.000 | NULL     | Task 20180817-7 autotest  | Task 20180817-7 text  | 1                | 1              |
	| TSK8    | BPS1       | 2              | 4            | Task 20180817-08 | USR1     | USR1       | BPS1     | LEI3         | 2018-01-10 00:00:00.000 | 2018-10-10 00:00:00.000 | 2018-05-10 00:00:00.000 | NULL     | Task 20180817-8 autotest  | Task 20180817-8 text  | 1                | 1              |
	| TSK9    | BPS1       | 1              | 4            | Task 20180817-09 | USR2     | USR1       | BPS2     | LEI4         | 2018-01-10 00:00:00.000 | 2018-11-10 00:00:00.000 |                         | NULL     | Task 20180817-9 autotest  | Task 20180817-9 text  | 1                | 2              |
	| TSK10   | BPS2       | 1              | 2            | Task 20180817-10 | USR2     | USR1       | BPS2     | LEI4         | 2018-01-10 00:00:00.000 | 2018-12-10 00:00:00.000 |                         | NULL     | Task 20180817-10 autotest | Task 20180817-10 text | 1                | 2              |

@LoadPendenzen
Scenario: 01 Get count of navbar items
	Given User has logon with username is test_admin_1, password is 123456
	And Page Pendenzen is redirected to
	Then the count of navbar items should be
	| Meine fällige | Meine offene | Meine in Bearbeitung | Meine selber erstellte | Meine erhaltene | Meine zu visierende | Erstellte fällige | Erstellte offene | Erstellte allgemeine | Erstellte zu visierende | 
	| fällige (2)   | offene (7)   | in Bearbeitung (3)   | selber erstellte (1)   | erhaltene (6)   | zu visierende (1)   | fällige (1)       | offene (4)       | allgemeine (3)       | zu visierende (1)       | 

@LoadPendenzen
Scenario: 02 Get Pendenzen data
	Given User has logon with username is test_admin_1, password is 123456
	And Page Pendenzen is redirected to
	Then data of grid view Task should be
	| Fällig     | Betreff          | Leistung | Fallträger               | Fallnummer | Person            | Ersteller                  | Empfänger                  | Status         | Erfasst    | Bearbeitung | Erledigt | Antwort               |
	| 10.01.2020 | Task 20180817-01 | F        | Person test-1, NT (BPS1) | BPS1       | Person test-1, NT | NULL                       | test_admin_1 - Global, CMC | Pendent        | 10.01.2018 | NULL        | NULL     | Task 20180817-1 text  |
	| 10.05.2018 | Task 20180817-02 | K        | Person test-1, NT (BPS2) | BPS2       | Person test-2     | NULL                       | test_admin_1 - Global, CMC | Pendent        | 10.01.2018 | NULL        | NULL     | Task 20180817-2 text  |
	| 10.10.2018 | Task 20180817-03 | F        | Person test-2 (BPS2)     | BPS2       | Person test-1, NT | NULL                       | test_admin_1 - Global, CMC | in Bearbeitung | 10.01.2018 | 10.04.2018  | NULL     | Task 20180817-3 text  |
	| 10.07.2018 | Task 20180817-04 | K        | Person test-2 (BPS1)     | BPS1       | Person test-2     | NULL                       | test_admin_1 - Global, CMC | in Bearbeitung | 10.01.2018 | 10.06.2018  | NULL     | Task 20180817-4 text  |
	| 10.10.2018 | Task 20180817-08 | K        | Person test-2 (BPS1)     | BPS1       | Person test-1, NT | test_admin_1 - Global, CMC | test_admin_1 - Global, CMC | in Bearbeitung | 10.01.2018 | 10.05.2018  | NULL     | Task 20180817-8 text  |
	| 10.11.2018 | Task 20180817-09 | F        | Person test-2 (BPS2)     | BPS2       | Person test-1, NT | NULL                       | test_admin_1 - Global, CMC | Pendent        | 10.01.2018 | NULL        | NULL     | Task 20180817-9 text  |
	| 10.12.2018 | Task 20180817-10 | F        | Person test-2 (BPS2)     | BPS2       | Person test-2     | NULL                       | test_admin_1 - Global, CMC | Pendent        | 10.01.2018 | NULL        | NULL     | Task 20180817-10 text |
