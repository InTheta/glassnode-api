using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Glassnode.Api.Responses;
using Glassnode.Api.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Glassnode.Api
{
    public class GlassnodeRestApi
    {
        private const string Url = "https://api.glassnode.com";
        private readonly Client _client;
        private readonly HttpClient _httpClient;

        public GlassnodeRestApi(Client client)
        {
            _client = client;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(Url),
                Timeout = TimeSpan.FromMinutes(10)
            };
        }

        public async Task<Endpoints[]> RequestEndpoints()
        {
            var endpoint = new Metrics(Metric.Endpoints).MetricEnpoint;
            var request = BuildRequest(endpoint, default, default, default);
            return await GetEndpoints(request);
        }

        public async Task<Assets[]> RequestAssets()
        {
            var endpoint = new Metrics(Metric.Assets).MetricEnpoint;
            var request = BuildRequest(endpoint, default, default, default);
            return await GetAssets(request);
        }

        public async Task<FuturesTerm> RequestFuturesTerm(string symbol)
        {
            var endpoint = new Metrics(Metric.FuturesTermStructure).MetricEnpoint;
            var request = BuildRequest(endpoint, symbol, default, default);
            return await GetFuturesTerm(request);
        }

        public async Task<FuturesTerm[]> RequestFuturesTermByExchange(string symbol)
        {
            var endpoint = new Metrics(Metric.FuturesTermStructureByExchange).MetricEnpoint;
            var request = BuildRequest(endpoint, symbol, default, default);
            return await GetFuturesTermByExchange(request);
        }

        public async Task<Response[]> Request(Metric metric, string symbol, string interval,
            DateTime from = default, DateTime to = default, string currency = null, string exchange = null)
        {
            var endpoint = new Metrics(metric).MetricEnpoint;
            var request = CreateRequest(endpoint, symbol, currency, exchange, interval, from, to);
            return await GetResult(request);
        }

        private async Task<string> CallAsync(HttpMethod method, string endpoint, string body = null)
        {
            var request = new HttpRequestMessage(method, endpoint);

            if (body != null)
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            request.Headers.Add("X-Api-Key", _client.ApiKey);

            var cts = new CancellationTokenSource();

            try
            {
                var response =
                    await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cts.Token);
                return await response.Content.ReadAsStringAsync(cts.Token);
            }
            // If the token has been canceled, it is not a timeout.
            catch (TaskCanceledException ex) when (cts.IsCancellationRequested)
            {
                // Handle cancellation.
                //Log.Debug("Canceled: " + ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                // Handle timeout.
                //Log.Debug("Timed out: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle timeout.
                //Log.Debug("Timed out: " + ex.Message);
            }

            return null;
        }

        private string BuildRequest(string endpoint, string symbol, string interval,
            DateTime from = default)
        {
            string result;
            if (from != default)
            {
                var fromStr = ConvertToUnix(from);
                result = $"{endpoint}?a={symbol}&i={interval}&s={fromStr}";
            }
            else
                result = $"{endpoint}?a={symbol}&i={interval}";

            return result;
        }

        private string CreateRequest(string endpoint, string symbol, string currency, string exchange, string interval,
            DateTime from = default, DateTime to = default)
        {
            var uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "api.glassnode.com";
            uriBuilder.Path = endpoint;

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (symbol != default)
                query["a"] = symbol;

            if (from != default)
                query["s"] = ConvertToUnix(from);

            if (to != default)
                query["u"] = ConvertToUnix(to);

            if (exchange != default)
                query["e"] = exchange;

            if (currency != default)
                query["c"] = currency;

            if (interval != default)
            {
                var intervalCheck = interval.Equals("1month") ||
                                    interval.Equals("1w") ||
                                    interval.Equals("24h") ||
                                    interval.Equals("1h") ||
                                    interval.Equals("10m");

                if (intervalCheck)
                    query["i"] = interval;
            }

            uriBuilder.Query = query.ToString();
            return uriBuilder.Uri.ToString();
        }

        private string ConvertToUnix(DateTime dateTime)
        {
            var roundDt = dateTime.TruncateToHourStart();
            var ts = (int)roundDt.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return ts.ToString(CultureInfo.InvariantCulture);
        }

        private async Task<Response[]> GetResult(string endpoint)
        {
            var result = await CallAsync(HttpMethod.Get, endpoint);
            return result != null
                ? JsonConvert.DeserializeObject<Response[]>(result, Converter.Settings)
                : Array.Empty<Response>();
        }

        private async Task<Endpoints[]> GetEndpoints(string endpoint)
        {
            var result = await CallAsync(HttpMethod.Get, endpoint);
            return result != null
                ? JsonConvert.DeserializeObject<Endpoints[]>(result, Converter.Settings)
                : Array.Empty<Endpoints>();
        }

        private async Task<Assets[]> GetAssets(string endpoint)
        {
            var result = await CallAsync(HttpMethod.Get, endpoint);
            return result != null
                ? JsonConvert.DeserializeObject<Assets[]>(result, Converter.Settings)
                : Array.Empty<Assets>();
        }

        private async Task<FuturesTerm> GetFuturesTerm(string endpoint)
        {
            var result = await CallAsync(HttpMethod.Get, endpoint);
            return result != null
                ? JsonConvert.DeserializeObject<FuturesTerm>(result, Converter.Settings)
                : new FuturesTerm();
        }

        private async Task<FuturesTerm[]> GetFuturesTermByExchange(string endpoint)
        {
            var result = await CallAsync(HttpMethod.Get, endpoint);
            return result != null
                ? JsonConvert.DeserializeObject<FuturesTerm[]>(result, Converter.Settings)
                : Array.Empty<FuturesTerm>();
        }

        private static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings()
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.DateTime,
                Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    }
}