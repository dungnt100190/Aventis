Feature: EditPendenzen
	Background:
	Given these UserAdmin for EditPendenzen feature
	| UserID | PermissionGroupID | GrantPermGroupID | LogonName    | PasswordHash | FirstName | LastName | ShortName | IsLocked | IsUserAdmin | IsUserBIAGAdmin | IsMandatsTraeger | GenderCode | KeinBDEExport | MigUserFix | VerID  |
	| USR1   | 9                 | 9                | test_admin_1 | kR9Y+JkxEwo= | CMC       | Global   | cg        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 257000 |
	| USR2   | 9                 | 9                | test_admin_2 | kR9Y+JkxEwo= | CMC       | Soft     | cs        | 0        | 1           | 1               | 0                | 1          | 0             | 0          | 257000 |
	
	And these Tasks for EditPendenzen feature
	| XTaskID | BaPersonID | TaskStatusCode | TaskTypeCode | Subject          | SenderID | ReceiverID | FaFallID | FaLeistungID | CreateDate              | ExpirationDate          | TaskDescription           | ResponseText          | TaskReceiverCode | 
	| TSK1    | 64807      | 1              | 4            | Task 20180817-01 | USR2     | USR1       | 64807    | 98766        | 2018-01-10 00:00:00.000 | 2020-01-10 00:00:00.000 | Task 20180817-1 autotest  | Task 20180817-1 text  | 1                | 

@servicetest
Scenario: Update Pendenzen
	Given EditPendenzen client has LogonName is test_admin_1, PasswordHash is 123456 
	And this new data for Pendenzen TSK1, [empfangerId] is USR2
	| status | pendenzTyp | betreff            | beschreibung               | empfangerId | falltrager | leistung | PersonId | antwort                | fallig                  |
	| 1      | 4          | Update 20180817-01 | Update 20180817-1 autotest | 1234        | 65134      | 98952    | 65088    | Update 20180817-1 text | 2019-01-10 00:00:00.000 |

	When call CreateUpdateTask for EditPendenzen feature
	Then the call UpdateTask should be return true
	And the updated Pendenzen should be
	| status | pendenzTyp | TaskTypeName | betreff            | beschreibung               | Ersteller                | empfangerName              | falltrager | FalltragerName       | leistung | LeistungModul                  | LeistungsverantName                    | PersonId | BetrifftPersonName | antwort                | fallig              | 
	| 1      | 4          | Fristablauf  | Update 20180817-01 | Update 20180817-1 autotest | test_admin_2 - Soft, CMC | test_admin_2 - Soft, CMC   | 65134      | Meier, Hans (65134)  | 98952    | F - Fallführung (21.04.2010 -) | afuchs - Fuchs, Andreas (Sozialdienst) | 65088    | Brunner, Renate    | Update 20180817-1 text | 10.01.2019 00:00:00 | 
