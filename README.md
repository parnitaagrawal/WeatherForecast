Development Environment

Framework: .net 6

Language: c#

Database: SQL express

Unit test: Xunit,Moq,Fluent Assertion



Introduction to the solution:


The solution has six projects.Project is based on onion layer architecture. 

There are four projects which are described below-
1. WeatherForecast.Domain- It has Domain project which has entities, exceptions and Define Interface for the repository.

2. WeatherForecast.Application- It has all the services folder- which has the core logic and do mapping between dtos and entities model, services.Abstraction- Define the Service Interface
Contracts folder- has all the Model Dtos

3.WeatherForecast.Infrastructure- It has the Dbcontext ,migration, Implentation of the repository.

4.WeatherForecast.API- it is the presentation layer- which has controllers with endpoints for the get weekly weather and add weather forecast.

There are two unit test project

1.WeatherForecast.API.Tests- It has all the unit test for the controller 

2. WeatherApplication.Tests- it as all the unit test for the service class - which has the core logic 
The assertion is done by Fluent assertions also in some places traditional assertions are used.
number of the unit test: 8

Assumption:

The solution does not include any frontend however swagger endpoint can be used to test the functionality. 
There is no model validation included on the Dtos.
The solution does not Include any Infrastructure as a code at the moment.
The solution depends on SQL express to be installed on the local machine.

For GetWeeklyweatherforecast- use the correct date format- "yyyy-MM-dd". No validation done for date formating.

Initial EF migration needs to be executed manually 

using the below command 

dotnet tool install --global 
dotnet-ef
dotnet ef migrations add InitialCreate 

