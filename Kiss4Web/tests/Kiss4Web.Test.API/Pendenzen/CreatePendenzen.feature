Feature: CreatePendenzen
	Background:
	Given these XUser
	| UserID | PermissionGroupID | GrantPermGroupID | LogonName    | PasswordHash | FirstName | LastName | ShortName | IsLocked | IsUserAdmin | IsUserBIAGAdmin | IsMandatsTraeger | GenderCode | KeinBDEExport | MigUserFix | VerID  |
	| USR1   | 9                 | 9                | test_admin_1 | kR9Y+JkxEwo= | CMC       | Global   | cg        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 257000 |
	| USR2   | 9                 | 9                | test_admin_2 | kR9Y+JkxEwo= | CMC       | Soft     | cs        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 257000 |
	
	And these BaPerson
	| BaPersonID | Name     | Vorname |
	| BPS1       | Person-1 | NT      |
	| BPS2       | Person 2 | NULL    |

	#And these XModul
	#| ModulID | ShortName | 
	#| 3       | S         | 
	#| 21      | PEN       | 

	And these FaLeistung
	| FaLeistungID | BaPersonID | FaFallID | ModulID | UserID | IkHatUnterstuetzung | IkIstRentenbezueger | IkSchuldnerMahnen | WiederholteSpezifischeErmittlungEAF | DatumVon                |
	| LEI1         | BPS1       | BPS1     | 3       | USR1   | 0                   | 0                   | 1                 | 0                                   | 2018-01-10 00:00:00.000 |
	| LEI2         | BPS1       | BPS2     | 21      | USR1   | 0                   | 0                   | 1                 | 0                                   | 2018-02-10 00:00:00.000 |
	| LEI3         | BPS2       | BPS1     | 21      | USR2   | 0                   | 0                   | 1                 | 0                                   | 2018-03-10 00:00:00.000 |
	| LEI4         | BPS2       | BPS2     | 3       | USR2   | 0                   | 0                   | 1                 | 0                                   | 2018-04-10 00:00:00.000 |
	
	And these XTask
	| XTaskID | BaPersonID | TaskStatusCode | TaskTypeCode | Subject          | SenderID | ReceiverID | FaFallID | FaLeistungID | CreateDate              | ExpirationDate          | StartDate               | DoneDate | TaskDescription           | ResponseText          | TaskReceiverCode | TaskSenderCode |
	| TSK1    | BPS1       | 1              | 4            | Task 20180817-01 | USR2     | USR1       | BPS1     | LEI1         | 2018-01-10 00:00:00.000 | 2020-01-10 00:00:00.000 |                         |          | Task 20180817-1 autotest  | Task 20180817-1 text  | 1                | 2              |

@servicetest
Scenario: 01 Create new Pendenzen
	Given init client with username is 'test_admin_1', password is '123456' 
	When call API CreateUpdateTask in CreatePendenzen with input data as below
	| id   | status | pendenzTyp | betreff            | beschreibung               | empfangerId | falltrager | leistung | PersonId | antwort                | fallig              | erfasst             |
	| NULL | 1      | 2          | Insert 20180817-01 | Insert 20180817-1 autotest | USR2        | BPS1       | LEI3     | BPS2     | Insert 20180817-1 text | 06/10/2019 00:00:00 | 06/10/2018 00:00:00 |
	Then the call is successful
	And the return value of API CreateUpdateTask should be true
	And the record of the inputted info is inserted into table XTask in database