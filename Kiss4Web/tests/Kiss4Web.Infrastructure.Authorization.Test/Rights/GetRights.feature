@ref:[KiSS4.DB.Session.Open][Line:933-948]
@servicetest
Feature: GetRights
	Background:
	Given these Benutzer
	| UserID | LogonName | PasswordHash                                 | FirstName | LastName | IsLocked |
	| USR1   | tst       | 8YQQYCmL9A6bGNbxJkAxS6q/IIQoJx+3OoEP4FJ/7bc= | Test      | User     | 0        |
	And these Benutzergruppen
	| UserGroupID | UserGroupName |
	| UGR1        | TestUserGroup |
	And these BenutzerInBenutzergruppen
	| UserGroupID | UserID |
	| UGR1        | USR1   |
	And these Klassen
	| XClassID | ClassName   | BaseType                  |
	| CLS1     | CtlUnitTest | KiSS4.Gui.KissUserControl |
	And these Rechte
	| RightID | XClassID | ClassName   | RightName     | Description              | UserText                       |
	| RGT1    | CLS1     | CtlUnitTest | TestRightName | Just a little test right | And the corresponding UserText |
	And these RechteInBenutzergruppen
	| UserGroupID | RightID | XClassID | ClassName   | MayInsert | MayUpdate | MayDelete |
	| UGR1        | NULL    | CLS1     | CtlUnitTest | true      | true      | false     |
	| UGR1        | RGT1    | CLS1     | CtlUnitTest | false     | false     | false     |

@servicetest
Scenario: Get rights of logged in user	
	When I get my own rights
	Then the call should be successful
	And the received rights should be
	| ClassName   | RightName     | MayInsert | MayUpdate | MayDelete |
	| CtlUnitTest | CtlUnitTest   | true      | true      | false     |
	| CtlUnitTest | TestRightName | false     | false     | false     |

