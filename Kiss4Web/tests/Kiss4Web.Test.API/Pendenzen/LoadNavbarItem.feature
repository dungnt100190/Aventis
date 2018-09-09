Feature: LoadNavbarItem
	Get count of item types in left menu 
	Background:
	Given these XUser
	| UserID | PermissionGroupID | GrantPermGroupID | LogonName    | PasswordHash | FirstName | LastName | ShortName | IsLocked | IsUserAdmin | IsUserBIAGAdmin | IsMandatsTraeger | GenderCode | KeinBDEExport | MigUserFix | VerID  |
	| USR1   | 9                 | 9                | test_admin_1 | kR9Y+JkxEwo= | CMC       | Global   | cg        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 257000 |
	| USR2   | 9                 | 9                | test_admin_2 | kR9Y+JkxEwo= | CMC       | Soft     | cs        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 258000 |

	And these BaPerson
	| BaPersonID | Name          |
	| BPS1       | Person test-1 |
	| BPS2       | Person test-2 |

	#And these XModul
	#| ModulID | ShortName | 
	#| 3       | S         | 
	#| 21      | PEN       | 

	And these FaLeistung
	| FaLeistungID | BaPersonID | FaFallID | ModulID | UserID | IkHatUnterstuetzung | IkIstRentenbezueger | IkSchuldnerMahnen | WiederholteSpezifischeErmittlungEAF | DatumVon |
	| LEI1         | BPS1       | BPS1     | 3       | USR1   | 0                   | 0                   | 1                 | 0                                   | 2018-01-10 00:00:00.000 |
	| LEI2         | BPS1       | BPS2     | 21      | USR1   | 0                   | 0                   | 1                 | 0                                   | 2018-02-10 00:00:00.000 |
	| LEI3         | BPS2       | BPS1     | 21      | USR2   | 0                   | 0                   | 1                 | 0                                   | 2018-03-10 00:00:00.000 |
	| LEI4         | BPS2       | BPS2     | 3       | USR2   | 0                   | 0                   | 1                 | 0                                   | 2018-04-10 00:00:00.000 |
	
	And these XTask
	| XTaskID | BaPersonID | TaskStatusCode | TaskTypeCode | Subject          | SenderID | ReceiverID | FaFallID | FaLeistungID | CreateDate              | ExpirationDate          | StartDate               | DoneDate | TaskDescription           | ResponseText          | TaskReceiverCode | TaskSenderCode |
	| TSK1    | BPS1       | 1              | 4            | Task 20180817-01 | USR2     | USR1       | BPS1     | LEI1         | 2018-01-10 00:00:00.000 | 2020-01-10 00:00:00.000 |                         |          | Task 20180817-1 autotest  | Task 20180817-1 text  | 1                |                |
	| TSK2    | BPS2       | 1              | 4            | Task 20180817-02 | USR2     | USR1       | BPS2     | LEI2         | 2018-01-10 00:00:00.000 | 2018-05-10 00:00:00.000 |                         |          | Task 20180817-2 autotest  | Task 20180817-2 text  | 1                |                |
	| TSK3    | BPS1       | 2              | 6            | Task 20180817-03 | USR2     | USR1       | BPS2     | LEI4         | 2018-01-10 00:00:00.000 | 2018-10-10 00:00:00.000 | 2018-04-10 00:00:00.000 |          | Task 20180817-3 autotest  | Task 20180817-3 text  | 1                |                |
	| TSK4    | BPS2       | 2              | 4            | Task 20180817-04 | USR2     | USR1       | BPS1     | LEI3         | 2018-01-10 00:00:00.000 | 2018-07-10 00:00:00.000 | 2018-06-10 00:00:00.000 |          | Task 20180817-4 autotest  | Task 20180817-4 text  | 1                |                |
	| TSK5    | BPS2       | 1              | 6            | Task 20180817-05 | USR1     | USR2       | BPS1     | LEI1         | 2018-01-10 00:00:00.000 | 2019-02-10 00:00:00.000 |                         |          | Task 20180817-5 autotest  | Task 20180817-5 text  | 1                | 1              |
	| TSK6    | BPS2       | 2              | 6            | Task 20180817-06 | USR1     | USR2       | BPS1     | LEI1         | 2018-01-10 00:00:00.000 | 2018-06-10 00:00:00.000 | 2018-03-10 00:00:00.000 |          | Task 20180817-6 autotest  | Task 20180817-6 text  | 1                | 1              |
	| TSK7    | BPS2       | 2              | 2            | Task 20180817-07 | USR1     | USR2       | BPS2     | LEI2         | 2018-01-10 00:00:00.000 | 2018-09-10 00:00:00.000 | 2018-05-10 00:00:00.000 |          | Task 20180817-7 autotest  | Task 20180817-7 text  | 1                | 1              |
	| TSK8    | BPS1       | 2              | 4            | Task 20180817-08 | USR1     | USR1       | BPS1     | LEI3         | 2018-01-10 00:00:00.000 | 2018-10-10 00:00:00.000 | 2018-05-10 00:00:00.000 |          | Task 20180817-8 autotest  | Task 20180817-8 text  | 1                | 1              |
	| TSK9    | BPS1       | 1              | 4            | Task 20180817-09 | USR2     | USR1       | BPS2     | LEI4         | 2018-01-10 00:00:00.000 | 2018-11-10 00:00:00.000 |                         |          | Task 20180817-9 autotest  | Task 20180817-9 text  | 1                | 2              |
	| TSK10   | BPS2       | 1              | 2            | Task 20180817-10 | USR2     | USR1       | BPS2     | LEI4         | 2018-01-10 00:00:00.000 | 2018-12-10 00:00:00.000 |                         |          | Task 20180817-10 autotest | Task 20180817-10 text | 1                | 2              |

@servicetest
Scenario: 01 Get count of navbar items
	Given init client with username is 'test_admin_1', password is '123456' 
	When call API LoadNavBarItems
	Then the call is successful
	And the return data of API LoadNavBarItems should be
	| ItmMeineFaellig | ItmMeineOffen | ItmMeineInBearbeitung | ItmMeineErstellt | ItmMeineErhalten | ItmMeineZuVisieren | ItmVersandteFaellig | ItmVersandteZuVisieren | ItmVersandteAllgemein | ItmVersandteOffen |
	| 2               | 7             | 3                     | 1                | 6                | 1                  | 1                   | 1                      | 3                     | 4                 |
