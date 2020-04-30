Feature: Fill cliams recevied form and verify data in Schedule List table for claims received form
	Background: Pre-Condition
	Given User is at the homepage
	When User click on the manage Schedules link
	When user click on the repoerter schedule link
	When User click on the Short Term Disability Standard Reports
	When User click on the claims received report

@mytag
Scenario: Fill cliams recevied form and verify data in Schedule List table for claims received form
	When User Enter title, recipient 
	And select ApplicationRCDVDate filter,Leave Start Date, Location Code, Division,Department and click on the Run Now button
	Then User should be at Schedule List table 
