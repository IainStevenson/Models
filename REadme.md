# Models

A simple POCO class with unit tests to research how to use OpenCover and ReportGenerator and fit them into the development cycle.

# Write your tests.
* Write your clasess to fufil the tests
* Manually run tests until all are green
* Run Coverage.bat
* Read the Coverage report.

## Coverage.Bat

To run this easily; click on the solution in Solution explorer, then either 
* right click and select Open in Terminal 
* or press Ctrl+'
* ./coverage
	* Sets up the necessary variables
	* executes the tests in the console runner, and outputs the coverage XML data.
	* Then passes the coverage XML data to the report generator to write the report.
	* Then views the report in a browser.

