Feature: Add Appliances for England Country
	
Background: 
	Given I am resident from England
	  |Url                                                                                                                                               |BrowserName |
	  |https://www.citizensadvice.org.uk/consumer/energy/energy-supply/get-help-paying-your-bills/check-how-much-your-electrical-appliances-cost-to-use/ |Chrome      |

@England
Scenario: Home Appliances For England
	Given I am on Compare how much electrical appliances cost to use screen
	When I select country as "England"
    And I enter the below list of appliances and click on Add appliance to your list
    	|Appliance  |Hours |Minutes |KWH |
    	|Air Friyer | 1    |10      |34  |
        |Dishwasher | 0    |30      |	 |
        |Fan heater | 1    |30      |    |
        |Iron 		| 1    |00      |    |
        |Oven 		| 1    |30      |    |
        |TV 		| 2    |10      |    |
        |Towel rail | 1    |10      |    |
        |Toaster 	| 1    |10      |    |
    Then all the "8" appliances list should be displayed in the table below.
    
    
	Scenario: Home Appliances For Scotland
		Given I am on Compare how much electrical appliances cost to use screen
		When I select country as "Scotland"
		And I enter the below list of appliances and click on Add appliance to your list
		  |Appliance  |Hours |Minutes |KWH |
		  |Air Friyer | 1    |30      |54  |
		  |Dishwasher | 1    |30      |	   |
		  |Fan heater | 2    |30      |    |
		  |Iron       | 3    |00      |    |
		  |Oven       | 1    |30      |    |
		  |TV         | 2    |10      |    |
		  |Towel rail | 1    |10      |    |
		  |Toaster    | 1    |10      |    |
		Then all the "8" appliances list should be displayed in the table below.