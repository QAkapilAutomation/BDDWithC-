Feature: Template Listing With Filters and Pagination
	List of Templates needs to be searched by Name and by Group

Background: Pre-Condition
       # Given Step
      Given I am at the Home Page with url

Scenario: List of template searched by Name
    When  user type a template by name
    Then  list of by name template should be displayed

Scenario: List of template searched by Group
     When  user type a template by group
     Then  list of by group template should be displayed
