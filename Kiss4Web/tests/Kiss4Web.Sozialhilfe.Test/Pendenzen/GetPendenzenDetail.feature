Feature: GetPendenzenDetail
	Get detail data of a Pendenzen 
	Background:
	Given these UserAdmin for GetPendenzenDetail feature
	| UserID | PermissionGroupID | GrantPermGroupID | LogonName    | PasswordHash | FirstName | LastName | ShortName | IsLocked | IsUserAdmin | IsUserBIAGAdmin | IsMandatsTraeger | GenderCode | KeinBDEExport | MigUserFix | VerID  |
	| USR1   | 9                 | 9                | test_admin_1 | kR9Y+JkxEwo= | CMC       | Global   | cg        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 257000 |
	| USR2   | 9                 | 9                | test_admin_2 | kR9Y+JkxEwo= | CMC       | Soft     | cs        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 258000 |

	And these BaPerson for GetPendenzenDetail feature
	| BaPersonID | Name     | Vorname |
	| BPS1       | Person-1 | NT      |

	And these BaPerson for GetPendenzenDetail feature
	| BaPersonID | Name     | 
	| BPS2       | Person 2 | 

	And these FaLeistung for GetPendenzenDetail feature
	| FaLeistungID | BaPersonID | FaFallID | ModulID | UserID | IkHatUnterstuetzung | IkIstRentenbezueger | IkSchuldnerMahnen | WiederholteSpezifischeErmittlungEAF | DatumVon |
	| LEI1         | BPS1       | BPS1     | 3       | USR1   | 0                   | 0                   | 1                 | 0                                   | 2018-01-10 00:00:00.000 |
	| LEI2         | BPS1       | BPS2     | 21      | USR1   | 0                   | 0                   | 1                 | 0                                   | 2018-02-10 00:00:00.000 |
	| LEI3         | BPS2       | BPS1     | 21      | USR2   | 0                   | 0                   | 1                 | 0                                   | 2018-03-10 00:00:00.000 |
	| LEI4         | BPS2       | BPS2     | 3       | USR2   | 0                   | 0                   | 1                 | 0                                   | 2018-04-10 00:00:00.000 |
	
	And these Tasks for GetPendenzenDetail feature
	| XTaskID | BaPersonID | TaskStatusCode | TaskTypeCode | Subject          | SenderID | ReceiverID | FaFallID | FaLeistungID | CreateDate              | ExpirationDate          | StartDate               | DoneDate | TaskDescription           | ResponseText          | TaskReceiverCode | TaskSenderCode |
	| TSK1    | BPS1       | 1              | 4            | Task 20180817-01 | USR2     | USR1       | BPS1     | LEI1         | 2018-01-10 00:00:00.000 | 2020-01-10 00:00:00.000 |                         |          | Task 20180817-1 autotest  | Task 20180817-1 text  | 1                |                |
	| TSK2    | BPS2       | 1              | 4            | Task 20180817-02 | USR2     | USR1       | BPS2     | LEI2         | 2018-01-10 00:00:00.000 | 2018-05-10 00:00:00.000 |                         |          | Task 20180817-2 autotest  | Task 20180817-2 text  | 1                |                |
	| TSK3    | BPS1       | 2              | 6            | Task 20180817-03 | USR2     | USR1       | BPS2     | LEI4         | 2018-01-10 00:00:00.000 | 2018-10-10 00:00:00.000 | 2018-04-10 00:00:00.000 |          | Task 20180817-3 autotest  | Task 20180817-3 text  | 1                |                |

@servicetest
Scenario: Get Pendenzen detail
	Given GetPendenzenDetail client has LogonName is test_admin_1, PasswordHash is 123456 
	When call GetPendenzenDetail of Task TSK1
	Then the detail data of Task should be
	| status | pendenzTyp | TaskTypeName | betreff          | beschreibung             | Ersteller                | empfangerName              | LeistungModul                  | LeistungsverantName        | BetrifftPersonName | antwort              | erfasst | fallig              | BearbeitungName | ErledigtName |
	| 1      | 4          | Fristablauf  | Task 20180817-01 | Task 20180817-1 autotest | test_admin_2 - Soft, CMC | test_admin_1 - Global, CMC | S - Sozialhilfe (10.01.2018 -) | test_admin_1 - Global, CMC | Person-1, NT       | Task 20180817-1 text | NULL    | 10.01.2020 00:00:00 | NULL            | NULL         |
