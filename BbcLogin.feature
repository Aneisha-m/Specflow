Feature: BbcLogin
	In order to Login to my account 
	As a user
	I want to see my account page


Scenario: Invalid password
	Given I am on the login page
	And I entered a valid username
	And I have entered a invalid password
	When I press login
	Then I shlould see the appropriate error
