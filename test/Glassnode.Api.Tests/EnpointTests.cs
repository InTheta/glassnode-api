using System;
using System.Linq;
using System.Threading.Tasks;
using Glassnode.Api.Types;
using NUnit.Framework;

namespace Glassnode.Api.Tests
{
    public class Tests
    {
        private string _key;
        private Client _client;
        private GlassnodeRestApi _api;

        [SetUp]
        public void Setup()
        {
            _key = "";
            _client = new Client(_key);
            _api = new GlassnodeRestApi(_client);
        }

        [Test]
        public async Task TestSoprA()
        {
            var symbol = "btc";
            var request = await _api.Request(Metric.SoprAdjusted, symbol,
                 "24h", DateTime.Now.AddHours(-24));
            var last = request.LastOrDefault();

            Assert.NotNull(last);
        }

        [Test]
        public async Task TestNupl()
        {
            var symbol = "btc";
            var request = await _api.Request(Metric.Nupl, symbol,
                 "24h", DateTime.Now.AddHours(-24));
            var last = request.LastOrDefault();

            Assert.NotNull(last);
        }
        
        public async Task TestMVRV()
        {
            var symbol = "btc";
            var request = await _api.Request(Metric.MvrvScore, symbol,
                 "24h", DateTime.Now.AddHours(-24));
            var last = request.LastOrDefault();

            Assert.NotNull(last);
        }
    }
}