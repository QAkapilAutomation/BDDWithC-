Feature: MergeAndComposeEmail
	merge and compose Email template

    Background: Pre-Condition
       # Given Step
       Given I am at the Home Page with url

Scenario:Template listing should get displayed

    Given the template page is open
    When a user selects Email template option
    Then all list of the Email template appears
 

Scenario: Template Listing with Sorting and Filtering

Given the template page is open
When user selects Email Template option
Then template listing along with Filter and Sorting option appear.
 

 

Scenario: Ability to Select a Template from Email Template List

Given the template page is open
When the desired list is selected
Then template should be selected from Template List
 

Scenario: Email Composer page should display with Merged Data and Filled Properties

Given the template page is open
When a user selects Merge and Email option
Then the Email Composer page appears with Merged Data and Filled Properties
 
Scenario: Ability to Change/Edit the pre-filled information/data

Given the Merge And Email Composer page is open
When user selects any of the given properties
Then user can change or Edit the pre-filled data.
 

Scenario: Ability to Attach file(s) for email attachment

Given the Email Composer page is open
When a user selects Add Attachment option
Then the file is attached.