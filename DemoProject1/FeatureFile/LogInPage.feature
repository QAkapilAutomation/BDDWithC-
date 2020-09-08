Feature: login feature for Demo Website
Background: Pre-Condition
Given User Is at Homepage 
@ignore 
Scenario: Login Scenario of Demo Webpage
	When User click on the signon link
	Then User should be at login page
	When User Provide UserName,Password and click on submit button
	| UserName    | Password   |
	| kapil.kumar | Devtes@12 |
	Then User Should be at loged in to webpage


	
