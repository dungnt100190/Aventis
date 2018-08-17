Feature: Pendenzen

@servicetest
Scenario: Login
	Given User is on Login page
	When user login as administrator
	Then redirect to page Pendenzen