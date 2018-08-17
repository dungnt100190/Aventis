Feature: Pendenzen
	Background:
	Given these Tasks
	| BaPersonID | TaskStatusCode | TaskTypeCode | Subject          | SenderID | ReceiverID | FaFallID | FaLeistungID | CreateDate              | ExpirationDate          | StartDate               | DoneDate | UserID_InBearbeitung | TaskDescription           | ResponseText          | TaskReceiverCode | TaskSenderCode |
	| 64807      | 1              | 4            | Task 20180817-01 | 2091     | 3343       | 64807    | 98766        | 2018-01-10 00:00:00.000 | 2020-01-10 00:00:00.000 |                         |          |                      | Task 20180817-1 autotest  | Task 20180817-1 text  | 1                |                |
	| 65134      | 1              | 4            | Task 20180817-02 | 2091     | 3343       | 64807    | 99137        | 2018-01-10 00:00:00.000 | 2018-05-10 00:00:00.000 |                         |          |                      | Task 20180817-2 autotest  | Task 20180817-2 text  | 1                |                |
	| 64807      | 2              | 6            | Task 20180817-03 | 2092     | 3343       | 65134    | 99153        | 2018-01-10 00:00:00.000 | 2018-10-10 00:00:00.000 | 2018-04-10 00:00:00.000 |          |                      | Task 20180817-3 autotest  | Task 20180817-3 text  | 1                |                |
	| 65134      | 2              | 4            | Task 20180817-04 | 2092     | 3343       | 64807    | 98766        | 2018-01-10 00:00:00.000 | 2018-07-10 00:00:00.000 | 2018-06-10 00:00:00.000 |          |                      | Task 20180817-4 autotest  | Task 20180817-4 text  | 1                |                |
	| 65134      | 1              | 6            | Task 20180817-05 | 3343     | 2091       | 65659    | 99153        | 2018-01-10 00:00:00.000 | 2019-02-10 00:00:00.000 |                         |          |                      | Task 20180817-5 autotest  | Task 20180817-5 text  | 1                | 1              |
	| 65139      | 2              | 6            | Task 20180817-06 | 3343     | 2091       | 65659    | 98960        | 2018-01-10 00:00:00.000 | 2018-06-10 00:00:00.000 | 2018-03-10 00:00:00.000 |          |                      | Task 20180817-6 autotest  | Task 20180817-6 text  | 1                | 1              |
	| 65139      | 2              | 2            | Task 20180817-07 | 3343     | 2093       | 65659    | 98960        | 2018-01-10 00:00:00.000 | 2018-09-10 00:00:00.000 | 2018-05-10 00:00:00.000 |          |                      | Task 20180817-7 autotest  | Task 20180817-7 text  | 1                | 1              |
	| 64807      | 2              | 4            | Task 20180817-08 | 3343     | 3343       | 65134    | 99137        | 2018-01-10 00:00:00.000 | 2018-10-10 00:00:00.000 | 2018-05-10 00:00:00.000 |          |                      | Task 20180817-8 autotest  | Task 20180817-8 text  | 1                | 1              |
	| 64807      | 1              | 4            | Task 20180817-09 | 2093     | 3343       | 65134    | 99137        | 2018-01-10 00:00:00.000 | 2018-11-10 00:00:00.000 |                         |          |                      | Task 20180817-9 autotest  | Task 20180817-9 text  | 1                | 2              |
	| 65139      | 1              | 2            | Task 20180817-10 | 2075     | 3343       | 64805    | 98761        | 2018-01-10 00:00:00.000 | 2018-12-10 00:00:00.000 |                         |          |                      | Task 20180817-10 autotest | Task 20180817-10 text | 1                | 2              |

@servicetest
Scenario: Get count of navbar items
	When call LoadNavBarItems
	Then the count of navbar items should be
	| ItmMeineFaellig | ItmMeineOffen | ItmMeineInBearbeitung | ItmMeineErstellt | ItmMeineErhalten | ItmMeineZuVisieren | ItmVersandteFaellig | ItmVersandteZuVisieren | ItmVersandteAllgemein | ItmVersandteOffen |
	| 2               | 7             | 3                     | 1                | 6                | 1                  | 1                   | 1                      | 3                     | 4                 |

@servicetest
Scenario: Get Pendenzen data
	Given id of menu item
	When call GetPendenzenData
	Then the list of Task should be
	| ExpirationDate | Subject | LeistungModul | FaFall | Fallnummer | PersonBP | Sender | Receiver | TaskStatusCode | CreateDate | StartDate | DoneDate | ResponseText |

@servicetest
Scenario: Get Pendenzen detail
	Given Task Id 
	When call GetPendenzenDetail
	Then the detail data of Task should be
	| status | pendenzTyp | betreff | beschreibung | empfangerId | falltrager | leistung | 

@servicetest
Scenario: Search Pendenzen
	Given id of menu item
	And search condition
	| IdStatus | IdPendenzTyp | Betreff | IdErsteller | IdEmpfanger | NameKlientIn | VornameKlientIn | Fallnummer | IdLeistungsverantw | IdOrganisationseinheit | FromErfasst | ToErfasst | FromFallig | ToFallig | FromBearbeitung | ToBearbeitung | FromErledigt | ToErledigt | 
	When call SearchPendenzen
	Then the list of Task should be
	| ExpirationDate | Subject | LeistungModul | FaFall | Fallnummer | PersonBP | Sender | Receiver | TaskStatusCode | CreateDate | StartDate | DoneDate | ResponseText |