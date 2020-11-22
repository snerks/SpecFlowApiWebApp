Feature: WeatherForecast
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
	In order to avoid silly mistakes
	As a math idiot
	I *want* to be told the **sum** of ***two*** numbers

Link to a feature: [Calculator](SpecFlowApiWebApp.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

Background: 
	Given the web server and client are running

@mytag
Scenario: Get weather forecasts
	When the weather forecasts are requested
	Then the result should be correct
		| Date       | TemperatureC | TemperatureF | Summary |
		| 2020-12-01 | 55           | 130          | Bracing |

Scenario: Get lottery numbers
	When the lottery numbers are requested
	Then the result should not be found

	#[{"date":"2020-11-23T14:47:04.1205193+00:00","temperatureC":-15,"temperatureF":6,"summary":"Hot"},{"date":"2020-11-24T14:47:04.1208851+00:00","temperatureC":32,"temperatureF":89,"summary":"Hot"},{"date":"2020-11-25T14:47:04.1208875+00:00","temperatureC":-17,"temperatureF":2,"summary":"Bracing"},{"date":"2020-11-26T14:47:04.120888+00:00","temperatureC":29,"temperatureF":84,"summary":"Scorching"},{"date":"2020-11-27T14:47:04.1208883+00:00","temperatureC":-9,"temperatureF":16,"summary":"Warm"}]