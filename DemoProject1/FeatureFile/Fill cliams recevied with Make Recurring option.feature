Feature: Fill cliams recevied with Make Recurring option
	Background: Pre-Condation 
	Background: Pre-Condition
	Given User is at the homepage
	When User click on the manage Schedules link
	When user click on the repoerter schedule link
	When User click on the Short Term Disability Standard Reports
	When User click on the claims received report
	When User Enter title, recipient 

@mytag
Scenario: Scenarios for Fill cliams recevied with Make Recurring option checkbox for claims received from 
	When User click on Make Recurring check box 
	Then User Should be able to see start date filter
	When User enter start date, end date, time and days 
	And User click on the create schedule 


