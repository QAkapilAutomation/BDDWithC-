Feature: CreateNewEmailTemplate 
		An Email template need to be created,
	so that it can be used while composing Merging and Emailing.

	Background: Pre-Condition
       # Given Step
      Given I am at the Home Page with url

Scenario: Email Template Properties without Attachment 
	When I click on create Email  by hovering the cursor to new template option
	When I enter the required information 
	And I verify that Attachment Container checkbox is unchecked
    When I Click On SAVE Button
	Then i should see the success messgage

Scenario: Email Template Properties with Attachment 
	When I click on create Email  by hovering the cursor to new template option
	When I enter the required information 
	When I attach Multiple File using Add Attachement option
    When I Click On SAVE Button
	Then i should see the success messgage
	
Scenario:3 Merge Fields selection ability from Merge Fields list in Template Body and Subject
    When I click on create Email  by hovering the cursor to new template option
	When I enter the required information 
	When a user drag desired fields from the merge field list and drop in template body
	When I attach Multiple File using Add Attachement option
    When I Click On SAVE Button
	Then i should see the success messgage
