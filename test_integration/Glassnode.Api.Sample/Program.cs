using System;
using System.Linq;
using System.Threading.Tasks;
using Glassnode;
using Glassnode.Api.Responses;
using Glassnode.Api.Types;

namespace Glassnode.Api.Sample
{
    class Program
    {
        private static string _apiKey = "xxx";
        private static Client _glassnodeClient;
        private static GlassnodeRestApi _glassnodeApi;

        static async Task Main(string[] args)
        {
            _glassnodeClient = new Client(_apiKey);
            _glassnodeApi = new GlassnodeRestApi(_glassnodeClient);

            Console.WriteLine("Loading glassnode data..");

            await GetGlassnodeData("btc");
        }

        private static async Task GetGlassnodeData(string symbol)
        {
            var endpoints = await GetEndpoints();
            //var assets = await GetAssets();

            var adjustedSopr = await GetMetric(Metric.SoprAdjusted, symbol, "24hr");
            var entityAdjustedSopr = await GetMetric(Metric.SoprEntityAdjusted, symbol, "24hr");
            var lthSopr = await GetMetric(Metric.LthSopr, symbol, "24hr");
            var nupl = await GetMetric(Metric.Nupl, symbol, "24hr");

            var meanFundingRates = await GetMetric(Metric.FuturesPerpetualFundingRateAll, symbol, "24h",
                DateTime.Now.AddDays(-1), DateTime.Now);

            foreach (var item in meanFundingRates.Data)
                Console.WriteLine($"{item.Key} rate: {item.Value:F5}");
        }

        private static async Task<Response> GetMetric(
            Metric metric,
            string symbol,
            string interval,
            DateTime from = default,
            DateTime to = default,
            string currency = default,
            string exchange = default)
        {
            var request = await _glassnodeApi.Request(metric, symbol,
                interval, from, to, currency, exchange);

            return request.LastOrDefault();
        }

        private static async Task<Endpoints[]> GetEndpoints()
        {
            var request = await _glassnodeApi.RequestEndpoints();
            return request;
        }

        private async Task<FuturesTerm> GetFuturesTerm(string symbol)
        {
            var request = await _glassnodeApi.RequestFuturesTerm(symbol);
            return request;
        }

        private async Task<FuturesTerm[]> GetFuturesTermByExchange(string symbol)
        {
            var request = await _glassnodeApi.RequestFuturesTermByExchange(symbol);
            return request;
        }

        private static async Task<Assets[]> GetAssets()
        {
            var request = await _glassnodeApi.RequestAssets();
            return request;
        }
    }
}