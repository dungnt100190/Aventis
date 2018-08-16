Feature: Pendenzen

@servicetest
Scenario: Get count of navbar items
	When Call LoadNavBarItems
	Then the NavBarItems should be
	| ItmMeineFaellig | ItmMeineOffen | ItmMeineInBearbeitung | ItmMeineErstellt | ItmMeineErhalten | ItmMeineZuVisieren | ItmVersandteFaellig | ItmVersandteZuVisieren | ItmVersandteAllgemein | ItmVersandteOffen |
	| 13              | 46            | 7                     | 45               | 0                | 0                  | 82                  | 0                      | 182                   | 182               |
