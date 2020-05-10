using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearComApi.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public async Task GetDevicesCapabilitiesTest()
        {
            using var source = new CancellationTokenSource(TimeSpan.FromMinutes(1));

            using var client = ApiClient.New("http://clearcomtest.net/api/1/", "admin", "4Mercury@62");

            var capabilities = await client.GetDevicesCapabilitiesAsync(source.Token);

            foreach (var capability in capabilities)
            {
                Console.WriteLine($"Capability. {capability?.Type}");
                foreach (var @event in capability?.Events ?? new List<Events>())
                {
                    Console.WriteLine($"Event. Type: {@event?.Type}. Value: {@event?.Value}");
                }
            }
        }
    }
}
