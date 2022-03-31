Feature: CreateUser

A short summary of the feature

@tag1
Scenario: To verify creation of user
	Given I input name "Mike"
	And I input job "QA"
	When I send create user request
	Then user is created successfully
	And the API Response status code is 201
	

