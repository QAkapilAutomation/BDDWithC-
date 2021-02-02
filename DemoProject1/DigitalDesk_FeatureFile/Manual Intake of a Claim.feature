Feature: Manual Intake of a Claim
	Background: Pre-Condition
 # Given step
Given I am at login page
When User enter valid userid and password and click on logon button 
Then User should be at the home page

 Scenario: Add Claim related information     
Given the User is at Claims page 
When the User fills all the claim related information and saves  
Then the system should add the new claim with a success message as “Claim Added Successfully”


Scenario:  Upload Claims in bulk  
Given the User is at Claims page
When the User uploads a file containing claims in bulk
Then the system should redirect to the Home Page 
And the system should add those new claims under new claims with a message as “Claims Added Successfully.”
