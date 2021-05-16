Feature: UpdatePersonalDetails
	Test script to validate Amend Personal details for existing customer

@mytag
Scenario: Update Personal Details
	Given I launch the Retails application using below details
	  |Url                           |BrowserName |
	  |http://automationpractice.com |Chrome      |
	Then I should be displayed with "Home" screen
	When I click on "Sign In" link
	Then I should be displayed with "Authentication" screen
	When I login using below details
	  |EmailAddress              |Password   |
	  |sudani.saikumar@gmail.com |Siva052021 |
	And I click on "Sign In" button
	Then I should be displayed with "My Account" screen
	When I click on "My Personal Information" button
	Then I should be displayed with "Your Personal Information" screen
	When I update the below details
		|FirstName|CurrentPassword|
		|Sai	  |Siva052021     |
	And I click on "Save" button
	Then I should be displayed with message "Your personal information has been successfully updated."