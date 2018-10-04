using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using jarvis_lite.server;
using jarvis_lite.server.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace jarvis_lite.tests.Controllers
{
    public class HomesControllerTests
    {
        //private readonly HomesController _homesController;
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public HomesControllerTests()
        {
            //_homesController = new HomesController();
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public void TestThatServerAndClientAreNotNull()
        {
            Assert.NotNull(_server);
            Assert.NotNull(_client);
        }

        [Fact]
        public async void TestThatServerReturnsCorrectNumberOfHomes()
        {
            HttpResponseMessage response = await _client.GetAsync("/homes/");
            response.EnsureSuccessStatusCode();
            string message = await response.Content.ReadAsStringAsync();

            List<House> homes = JsonConvert.DeserializeObject<List<House>>(message);
            Assert.True(homes.Count == 2);
        }

        [Fact]
        public async void TestWhenRequestingRoomValuesThenResponseIsNotNull()
        {
            HttpResponseMessage response = await _client.GetAsync("/homes/hus1/data");
            response.EnsureSuccessStatusCode();
            string message = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(message);
        }

        [Fact]
        public async void TestWhenRequestingInvalidRoomValuesThenReturn404()
        {
            HttpResponseMessage response = await _client.GetAsync("/homes/hus764/data");
            string message = await response.Content.ReadAsStringAsync();

            Assert.False(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.True(response.StatusCode.Equals(HttpStatusCode.NotFound));
            Assert.Empty(message);
        }
    }
}