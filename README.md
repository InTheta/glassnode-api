# Glassnode api client

Make a request using:

List endpoints
var request = await _glassnodeApi.RequestEndpoints();

List assets
var request = await _glassnodeApi.RequestAssets();

var request = await _glassnodeApi.Request(metric, symbol, interval, from, to, currency, exchange);

eg.
var nupl = await GetMetric(Metric.Nupl, symbol, "24hr");


Some end points are incomplete.
Some end points have issues on Glassnode end (eg Short liquidations domination does not work)

Please feel free to add any new end points.

Todo:

Refactor the end points into their respective groups

Derivative, addresses, network etc
