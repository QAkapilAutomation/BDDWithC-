Feature: Login To Application


Background: Pre-Condition
 # Given step
 Given I am at login page



Scenario: Login successful 
	When User enter valid userid and password and click on logon button 
	Then User should be at the home page

 Scenario:  Login unsuccessful   
	When  the User inputs wrong credentials   
	Then  the system should not allow User to log-in with error message

 
             

	
