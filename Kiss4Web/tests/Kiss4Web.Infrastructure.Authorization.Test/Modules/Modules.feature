@servicetest
Feature: GetLicensedModules

@servicetest
@existingdata
Scenario: Get licensed modules
	When I get the licensed modules
	Then the received modules should be
	| KissModul   |
	| Basis       |
	| Sozialhilfe |
	| Fibu        |

