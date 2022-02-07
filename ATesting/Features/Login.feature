Feature: Login

	Check if login functionality works

@smoke @positive
Scenario: Login to application
	Given I navigate to aplication
	And I check app opened
	And I click the login link
	And I enter username and password
		| UserName | Password |
		| admin    | password |
	And I click login
	Then I should see username with hello
