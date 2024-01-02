Feature: TestScenarios

A short summary of the feature

@tag1
Scenario: Dealing with iframe
	Given  I navigate to the page 
	When   I complete the form in frame and submit
	Then   I shuld see a successful message 

Scenario: Dealing with windows
	Given I navigate to the  window page 
	When I click on the newPage Button
	Then a new page window should open with Title "LetCode - Testing Hub"
	And I switch back to parent window with title "ttile" and closed window






