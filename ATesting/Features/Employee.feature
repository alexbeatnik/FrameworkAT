Feature: Employee

A short summary of the feature

    @smoke
    Scenario: Create Employee with all details
        Given I navigate to aplication
        And I check app opened
        And I click the login link
        And I enter username and password
          | UserName | Password |
          | admin    | password |
        And I click login button
        And I click the employeeList link
        And I click createNew button
        And I enter following details
          | Name    | Salary | DurationWorked | Grade | Email          |
          | NewUser | 3000   | 20             | 1     | newuser@ea.com |
        And I click create button