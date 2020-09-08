Feature: CreateNewCategory
	A Category needs to be created, so that it can be used while creating template
Background: Pre-Condition
       # Given Step
       Given I am at the Home Page with url

Scenario: Create new category
	When I click on create category by hovering the cursor to new template option
	Then I should be on category popup
	When I enter the category name in the category text box
	When I Click On Create Button
	Then Category should be added in listing page
	