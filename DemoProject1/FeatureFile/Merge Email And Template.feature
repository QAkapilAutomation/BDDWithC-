Feature: Merge Email And Template

Given the template page is open
	
Scenario: Template listing should get displayed
Given the template page is open
When a user selects Email template option
Then all list of the Email template appears

Scenario: Template Listing with Sorting and Filtering
Given the template page is open
Given the Email template page is open
When a user selects Email template option
Then template listing along with Filter and Sorting option appear.

Scenario: Email Composer page should display with Merged Data and Filled Properties
Given the template page is open
When a user selects Merge and Email option
Then the Email Composer page appears with Merged Data and Filled Properties
Scenario: Test for Edit
Given the template page is open
Given the Merge And Email Composer page is open
When user selects any of the given properties
Then user can change or Edit the pre-filled data.