Feature: ClaimDetails
Background: Pre-Condition
Given I am at login page
When User enter valid userid and password and click on logon button
Then User should be at the home page


Scenario:  View Claim Details 
When the User selects view for a claim
Then the system should show claim details related to that claim
	