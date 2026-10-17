
## Reports

- What was the problem?

The three report classes has the same code Each class load the data and check it and formatt it and save it
but The only main difference is the report format

- What did you change?

I create an abstract class call ReportExporter and move the common steps into it I make Format() an abstract method and implement
it in the three classes CSV, JSON, and Text.

- Why did you choose that approach?

I chose the Template pattern because it keeps the common steps in one place and allows each class to format the report differently
This reduces code duplication and make the code easier to maintain.


## Enrollment

- What was the problem?

The Program.cs file was creating and calling all the services directly so This made the main program responsible for too many details

- What did you change?

 after searching for a better solution I create an EnrollmentFacade class that handles the enrollment 
 process by calling the payment, seat reservation, invoice, and email services
 In Program.cs I replaced the separate service calls with one call to the facade

- Why did you choose that approach?

I chose the Facade Pattern because it provides one simple way to perform the enrollment process
and It also makes Program.cs readable and hide the details of the services