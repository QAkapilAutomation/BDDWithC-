Feature: CreatScriptTemplate 
		An Script template need to be created,
	so that it can be used while composing Merging and Emailing.

	Background: Pre-Condition
       # Given Step
      Given I am at the Home Page with url

	Scenario: ScriptTemplate Properties without Attachement
	When I click on create Script by hovering the cursor to new template option
	Then I should be on Script template page
	When I enter the required information in Script Template field
	When I Click On SAVE Button
	Then i should see the script has been saved