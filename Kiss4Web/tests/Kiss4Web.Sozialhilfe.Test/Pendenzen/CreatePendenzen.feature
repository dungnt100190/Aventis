Feature: CreatePendenzen
	Background:
	Given these UserAdmin for CreatePendenzen feature
	| UserID | PermissionGroupID | GrantPermGroupID | LogonName    | PasswordHash | FirstName | LastName | ShortName | IsLocked | IsUserAdmin | IsUserBIAGAdmin | IsMandatsTraeger | GenderCode | KeinBDEExport | MigUserFix | VerID  |
	| USR1   | 9                 | 9                | test_admin_1 | kR9Y+JkxEwo= | CMC       | Global   | cg        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 257000 |
	| USR2   | 9                 | 9                | test_admin_2 | kR9Y+JkxEwo= | CMC       | Soft     | cs        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 257000 |
	
	And these Tasks for CreatePendenzen feature
	| XTaskID | BaPersonID | TaskStatusCode | TaskTypeCode | Subject          | SenderID | ReceiverID | FaFallID | FaLeistungID | CreateDate              | ExpirationDate          | TaskDescription           | ResponseText          | TaskReceiverCode | 
	| TSK1    | 64807      | 1              | 4            | Task 20180817-01 | USR2     | USR1       | 64807    | 98766        | 2018-01-10 00:00:00.000 | 2020-01-10 00:00:00.000 | Task 20180817-1 autotest  | Task 20180817-1 text  | 1                | 

@servicetest
Scenario: Create new Pendenzen
	Given CreatePendenzen client has LogonName is test_admin_1, PasswordHash is 123456 
	And this new Pendenzen, [empfangerId] is USR1, [SenderId] is USR2
	| status | pendenzTyp | betreff            | beschreibung               | falltrager | leistung | PersonId | antwort                | fallig              | erfasst             |
	| 1      | 2          | Insert 20180817-01 | Insert 20180817-1 autotest | 65134      | 98952    | 65088    | Insert 20180817-1 text | 06/10/2019 00:00:00 | 06/10/2018 00:00:00 |

	When call CreateUpdateTask for CreatePendenzen feature
	Then the call CreateTask should be return true
	And the created Pendenzen is after TSK1 and should be
	| status | pendenzTyp | betreff            | beschreibung               | Ersteller                | empfangerName              | falltrager | FalltragerName       | leistung | LeistungModul                  | LeistungsverantName                    | PersonId | BetrifftPersonName | antwort                | fallig              | 
	| 1      | 2          | Insert 20180817-01 | Insert 20180817-1 autotest | test_admin_2 - Soft, CMC | test_admin_1 - Global, CMC | 65134      | Meier, Hans (65134)  | 98952    | F - Fallführung (21.04.2010 -) | afuchs - Fuchs, Andreas (Sozialdienst) | 65088    | Brunner, Renate    | Insert 20180817-1 text | 10.06.2019 00:00:00 | 
