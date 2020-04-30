Feature: Verify title and Recipientid textbox validation message on the claims received page 
	Background: Pre-Condition
	Given User is at the homepage
	When User click on the manage Schedules link
	When user click on the repoerter schedule link


@mytag
Scenario: Verify title and Recipientid textbox validation message on the claims received page
	When User click on the Short Term Disability Standard Reports
	Then Short Term Disability Standard Reports list should be open
	When User click on the claims received report
	Then User should be at Create Schedule:Claims Received report page 
	When user click on the title and Recipient textbox 
	Then Verify the title and Recipient textbox validation message 
