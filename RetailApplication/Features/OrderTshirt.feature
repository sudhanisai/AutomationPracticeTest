Feature: OrderTshirt
	Test script to validate sucessful T-shirt Order palcement.

@mytag
Scenario: Order T-Shirt
	Given I launch the Retails application using below details
		|Url								 |BrowserName|
		|http://automationpractice.com|Chrome	 |
	Then I should be displayed with "Home" screen
	When I click on "Sign In" link
	Then I should be displayed with "Authentication" screen
	When I login using below details
		|EmailAddress			  |Password	 |
		|sudani.saikumar@gmail.com|Siva052021|
	And I click on "Sign In" button
	Then I should be displayed with "My Account" screen
	When I click on "TShirts" link
	Then I should be displayed with "Tshirts" screen
	When I move the cursor on to Tshirt image and click on "Add To Cart" button
	And I click on "Proceed To Checkout" button
	Then I should be displayed with "Shopping Cart Summary" screen
	When I click on "Proceed To Checkout" button
	Then I should be displayed with "Address" screen
	When I click on "Proceed To Checkout" button
	Then I should be displayed with "Shipping" screen
	When I click on Agree "Terms of Services" checkbox
	And I click on "Proceed To Checkout" button
	Then I should be displayed with "Payment Method" screen
	When I click on "Pay By Bank Wire" link
	Then I should be displayed with "Order Summary" screen
	When I click on "Confirm My Order" button
	Then I should be displayed with "Order Confirmation" screen
	And I should be dispalyed with Order Confirmation details
	When I click on "Back To Orders" link
	Then I should be displayed with "Order History" screen
	When I verify the Order Reference generated and click on the same
	Then I should be displayed with Order Status Step by Step


	
	

	