@ref:[KiSS4.DB.SqlQuery.Fill][Line:1094-1271]
@servicetest
Feature: SozialHilfe_CtlWhSpezialkonto_GetAusgabekonti
	Background:
	Given these Personen
	| BaPersonID | Name          | Vorname   | Geburtsdatum |
	| PRS1       | Schmid        | Patrick   | 1981-04-04   |
	| PRS2       | Nguyen        | Kien      | 1982-01-01   |
	| PRS3       | Schmid        | Loan Nora | 2004-12-01   |
	And these Leistungen
	| FaLeistungID | BaPersonID | UserID | ModulID | FaProzesscode |
	| LEI1         | PRS1       | 2091   | 2       | 200           |
	| LEI2         | PRS1       | 2091   | 3       | 300           |
	And these Finanzpläne
	| BgFinanzplanID | FaLeistungID | BgBewilligungStatusCode | WhHilfeTypCode | GeplantVon | GeplantBis |
	| FIP1           | LEI2         | 5                       | 3              | 2018-03-01 | 2018-04-30 |
	| FIP2           | LEI2         | 1                       | 3              | 2018-05-01 | 2018-11-30 |
	And these Finanzplanmitglieder
	| BgFinanzplanID | BaPersonID | IstUnterstuetzt |
	| FIP1           | PRS1        | true            |
	| FIP1           | PRS2        | true            |
	| FIP1           | PRS3        | true            |
	| FIP2           | PRS1        | true            |
	| FIP2           | PRS2        | true            |
	| FIP2           | PRS3        | true            |
	And these Budgets
	| BgBudgetID | BgFinanzplanID | Jahr | Monat | MasterBudget | BgBewilligungStatusCode |
	| BUD1       | FIP1           | 2018 | 03    | true         | 5                       |
	| BUD2       | FIP1           | 2018 | 03    | false        | 1                       |
	| BUD3       | FIP1           | 2018 | 04    | false        | 1                       |
	| BUD4       | FIP2           | 2018 | 05    | true         | 1                       |
	And these Spezialkonti
	| BgSpezkontoID | FaLeistungID | BgSpezkontoTypCode | NameSpezkonto  | BgKostenartID | BgPositionsartID | BaPersonID | DatumVon   | DatumBis   | Bemerkung   | Inaktiv |
	| SPZ1          | LEI2         | Ausgabekonti       | Ausgabekonto 1 | 10            | 32121            | PRS1       | 2018-02-01 | 2018-02-28 | Test VP1111 | true    |
	| SPZ2          | LEI2         | Ausgabekonti       | Ausgabekonto 2 | 10            | 32121            | PRS1       | 2018-03-01 | 2018-03-31 | Test VP1112 | false   |
	| SPZ3          | LEI2         | Ausgabekonti       | Ausgabekonto 3 | 10            | 32121            | PRS1       | 2018-03-01 | 2018-04-30 | Test VP1113 | false   |


@scenarioid:get_ausgabekonti_valid_001 @line:1094-1271
@servicetest
Scenario: G001_Get aktive Ausgabekonti
	Given current month is 03.2018
	When getting Ausgabekonti of Leistung LEI2, [nur aktive] is true
	Then the call should be successful
	And the received Spezialkonti should be
	| BgSpezkontoID | FaLeistungID | BgSpezkontoTypCode | NameSpezkonto  | BgKostenartID | BaPersonID | DatumVon   | DatumBis   | Bemerkung   |Inaktiv |
	| SPZ2          | LEI2         | 1                  | Ausgabekonto 2 | 10            | PRS1       | 2018-03-01 | 2018-03-31 | Test VP1112 |false   |
	| SPZ3          | LEI2         | 1                  | Ausgabekonto 3 | 10            | PRS1       | 2018-03-01 | 2018-04-30 | Test VP1113 |false   |
	

@scenarioid:get_ausgabekonti_valid_002 @line:1094-1271
@servicetest
Scenario: G002_Get inaktive Ausgabekonti
	Given current month is 03.2018
	When getting Ausgabekonti of Leistung LEI2, [nur aktive] is false
	Then the call should be successful
	And the received Spezialkonti should be
	| BgSpezkontoID | FaLeistungID | BgSpezkontoTypCode | NameSpezkonto  | BgKostenartID | BgPositionsartID | BaPersonID | DatumVon   | DatumBis   | Bemerkung   | Inaktiv |
	| SPZ2          | LEI2         | 1                  | Ausgabekonto 2 | 10            | 32121            | PRS1       | 2018-03-01 | 2018-03-31 | Test VP1112 | false   |
	| SPZ3          | LEI2         | 1                  | Ausgabekonto 3 | 10            | 32121            | PRS1       | 2018-03-01 | 2018-04-30 | Test VP1113 | false   |
	| SPZ1          | LEI2         | 1                  | Ausgabekonto 1 | 10            | 32121            | PRS1       | 2018-02-01 | 2018-02-28 | Test VP1111 | true    |