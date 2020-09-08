Feature: CreateNewWordTemplate
	A Word template needs to be created, so that it can be used while merging document and downloading
Background: Pre-Condition
       # Given Step
       Given I am at the Home Page with url

Scenario: Word Template Properties without Attachement
	When I click on create Word by hovering the cursor to new template option
	Then I should be on Word template page
	When I enter the required information in word Template field
	When I Click On SAVE Button
	Then i should see the success messgage
	

Scenario: Word Template Properties with Attachement
	When I click on create Word by hovering the cursor to new template option
	Then I should be on Word template page
	When I enter the required information in word Template field
	When I attach  File using Attach option
	When I Click On SAVE Button
	Then i should see the success messgage