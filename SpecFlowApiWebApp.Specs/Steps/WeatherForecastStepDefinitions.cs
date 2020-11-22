using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using Xunit;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowApiWebApp.Specs.Steps
{
    [Binding]
    public sealed class WeatherForecastStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public WeatherForecastStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        //[Given("the first number is (.*)")]
        //public void GivenTheFirstNumberIs(int number)
        //{
        //    //TODO: implement arrange (precondition) logic
        //    // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
        //    // To use the multiline text or the table argument of the scenario,
        //    // additional string/Table parameters can be defined on the step definition
        //    // method. 

        //    _scenarioContext.Pending();
        //}

        //[Given("the second number is (.*)")]
        //public void GivenTheSecondNumberIs(int number)
        //{
        //    //TODO: implement arrange (precondition) logic
        //    // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
        //    // To use the multiline text or the table argument of the scenario,
        //    // additional string/Table parameters can be defined on the step definition
        //    // method. 

        //    _scenarioContext.Pending();
        //}

        [When("the weather forecasts are requested")]
        public async Task WhenTheWeatherForecastsAreRequested()
        {
            //TODO: implement act (action) logic

            //_scenarioContext.Pending();

            //var webHostBuilder =
            //    Program
            //    .CreateHostBuilder(Array.Empty<string>());
            //// .UseContentRoot(contentRootPath);

            //var server = new TestServer(webHostBuilder);
            //var client = server.CreateClient();

            //// Act
            //var response = await client.GetAsync("/api/eventInfos");

            //var contentString = await response.Content.ReadAsStringAsync();

            //// Assert
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Arrange
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();
                    webHost.UseStartup<SpecFlowApiWebApp.Startup>();
                });

            // Create and start up the host
            var host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            var client = host.GetTestClient();

            // Act
            var response = await client.GetAsync("/weatherforecast");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            _scenarioContext.Set(responseString);

            //responseString.Should().Be("This is a test");
        }

        [Then("the result should be correct")]
        public void ThenTheResultShouldBe(Table expectedResults)
        {
            //TODO: implement assert (verification) logic
            //_scenarioContext.Pending();

            var responseString = _scenarioContext.Get<string>();

            var actualResults = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseString);

            expectedResults.CompareToSet<WeatherForecast>(actualResults);
        }
    }
}
