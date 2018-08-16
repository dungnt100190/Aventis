Feature: Pendenzen
	#Background:
	#Given these Tasks
	#| XTaskID | BaPersonID | TaskStatusCode | TaskTypeCode | Subject | SenderID | ReceiverID | FaFallID | FaLeistungID | CreateDate | ExpirationDate | StartDate | DoneDate | UserID_InBearbeitung | TaskDescription | ResponseText |
	#| XTaskID | BaPersonID | TaskStatusCode | TaskTypeCode | Subject | SenderID | 3343       | FaFallID | FaLeistungID | CreateDate | ExpirationDate | StartDate | DoneDate | UserID_InBearbeitung | TaskDescription | ResponseText |

@servicetest
Scenario: Get count of navbar items
	When Call LoadNavBarItems
	Then the NavBarItems should be
	| ItmMeineFaellig | ItmMeineOffen | ItmMeineInBearbeitung | ItmMeineErstellt | ItmMeineErhalten | ItmMeineZuVisieren | ItmVersandteFaellig | ItmVersandteZuVisieren | ItmVersandteAllgemein | ItmVersandteOffen |
	| 3               | 28            | 9                     | 27               | 0                | 0                  | 74                  | 0                      | 164                   | 164               |

#
#@servicetest
#Scenario: Get count of navbar items