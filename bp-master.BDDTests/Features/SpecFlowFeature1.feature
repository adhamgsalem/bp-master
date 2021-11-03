Feature: SpecFlowFeature1
	

@mytag
Scenario: Low BP Category
	Given the systolic number is 50
	And the diastolic number is 70
	When the we calculate category
	Then the result should be low