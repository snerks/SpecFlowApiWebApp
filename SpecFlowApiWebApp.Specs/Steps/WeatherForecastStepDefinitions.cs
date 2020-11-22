using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
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

        [Given(@"the web server and client are running")]
        public async Task GivenTheWebServerAndClientAreRunning()
        {
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
            var httpClient = host.GetTestClient();

            _scenarioContext.Set<HttpClient>(httpClient);
        }

        [When("the weather forecasts are requested")]
        public async Task WhenTheWeatherForecastsAreRequested()
        {
            var httpClient = _scenarioContext.Get<HttpClient>();

            var response = await httpClient.GetAsync("/weatherforecast");

            var responseString = await response.Content.ReadAsStringAsync();

            _scenarioContext.Set(responseString);
        }

        [Then("the result should be correct")]
        public void ThenTheResultShouldBe(Table expectedResults)
        {
            var responseString = _scenarioContext.Get<string>();

            var actualResults =
                JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseString);

            expectedResults.CompareToSet<WeatherForecast>(actualResults);
        }

        [When(@"the lottery numbers are requested")]
        public async Task WhenTheLotteryNumbersAreRequested()
        {
            var httpClient = _scenarioContext.Get<HttpClient>();

            var response = await httpClient.GetAsync("/lotterynumbers");

            //var responseString = await response.Content.ReadAsStringAsync();

            _scenarioContext.Set<HttpResponseMessage>(response);
        }

        [Then(@"the result should not be found")]
        public void ThenTheResultShouldNotBeFound()
        {
            var response = _scenarioContext.Get<HttpResponseMessage>();

            var actual = response.StatusCode;

            actual.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
