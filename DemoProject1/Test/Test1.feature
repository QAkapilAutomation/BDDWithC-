Feature: AddEligiblity
    An Admin Add the User and an Admin with right credentials logs into the system

 

Background: Pre-Condition  

   # Given Step
    Given I am at the Admin page with url "http://adminfronendsandbox.s3-website-us-east-1.amazonaws.com/"

 

Scenario: Create eligibility data
    Given the Admin is at eligibility data screen
    When the Admin saves all the required information related to the eligibility of client’s employee, by adding them in different fields
    Then the system should create new eligibility data with confirmation message as “New Eligibility Data Added”