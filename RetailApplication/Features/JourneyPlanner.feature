Feature: JourneyPlanner
	Simple calculator for adding two numbers

@mytag
Scenario: Plan a Journey
	Given user is on TFL home page
	When user plans a jouney from London Victoria to London Bridge
	Then user should be presented with the Journey results page with the correct summary 
	And user can see the fastest route
	
Scenario: Edit a Journey
	Given user plans a jouney from London Victoria to London Bridge