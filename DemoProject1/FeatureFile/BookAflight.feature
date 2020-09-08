Feature: BookAflight feature for DemoWebsite
Background: Pre-Condition
Given User Is at Homepage 

@ignore 
Scenario: BookAFlight Scenario for the DemoWebPage
	When User Click On the flight link
	Then User Should be at Book a flight page
	When User click on the Oneway radio button, select passengers dropdown, click on the Service class radio button and click on the findflight button
	Then User should be at find flights page
