Feature: Resistration for Demo Webpage
Background: Pre-Condition
Given User Is at Homepage

@mytag	
Scenario Outline: Registration Scenario of Demo Webpage
#steps: Give steps 
When User Provide the "<FirstName>", "<LastName>","<Phonenumber>" And Click On the Submit Button
Then User should be At Registration Page
Examples: 
| TestCase | FirstName | LastName | Phonenumber |
| 1        | Kapil     | Kumar    | 8527515427  |
| 2        | rahul    | Singh    | 8527515427  |


