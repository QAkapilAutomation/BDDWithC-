Feature: DeleteWordAndEmail
	Delete word and email template from database

    Background: Pre-Condition
       # Given Step
     Given I am at the Home Page with url

Scenario:1  Ability to delete a email template
              When I click on create Email  by hovering the cursor to new template option
	          When I enter the required information 
	          And I verify that Attachment Container checkbox is unchecked
              When I Click On SAVE Button
	          Then i should see the success messgage
              When I search the same email template by name on email template page
              Then The email template should be present  
              When I delete the email template by clicking on delete button
              Then The email template should be deleted from the database 

Scenario:2  Ability to delete a word template
             When I click on create Word by hovering the cursor to new template option
	         Then I should be on Word template page
	         When I enter the required information in word Template field
	         When I attach  File using Attach option
	         When I Click On SAVE Button
	         Then i should see the success messgage
		     When I search the same word template by name on home page
             Then The word template should be present 
             When I delete the word template by clicking on delete button
             Then The word template should be deleted from the database 