﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Glassnode.Api.Responses;
//
//    var endpoints = Endpoints.FromJson(jsonString);

namespace Glassnode.Api.Responses
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Endpoints
    {
        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("tier", NullValueHandling = NullValueHandling.Ignore)]
        public long? Tier { get; set; }

        [JsonProperty("assets", NullValueHandling = NullValueHandling.Ignore)]
        public Asset[] Assets { get; set; }

        [JsonProperty("currencies", NullValueHandling = NullValueHandling.Ignore)]
        public Currency[] Currencies { get; set; }

        [JsonProperty("resolutions", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Resolutions { get; set; }

        [JsonProperty("formats", NullValueHandling = NullValueHandling.Ignore)]
        public Format[] Formats { get; set; }
    }

    public partial class Asset
    {
        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public Tag[] Tags { get; set; }

        [JsonProperty("exchanges", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Exchanges { get; set; }
    }

    public enum Exchange { Aggregated, Bibox, Bigone, Binance, Bitfinex, Bitflyer, Bithumb, Bitmex, Bitstamp, Bittrex, Bybit, Cme, Cobinhood, Coinbase, Coincheck, Coinex, Deribit, Ftx, GateIo, Gemini, Hitbtc, Huobi, Kraken, Kucoin, Luno, Okex, Poloniex, ZbCom };

    public enum Tag { Bundle, Defi, DefiToken, Erc20, ExchangeToken, Stablecoin, TokenizedAsset, Top };

    public enum Currency { Native, Usd };

    public enum Format { Csv, Json };

    public enum Resolution { The10M, The1H, The1Month, The1W, The24H };

    public partial class Endpoints
    {
        public static Endpoints[] FromJson(string json) => JsonConvert.DeserializeObject<Endpoints[]>(json, Glassnode.Api.Responses.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Endpoints[] self) => JsonConvert.SerializeObject(self, Glassnode.Api.Responses.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ExchangeConverter.Singleton,
                TagConverter.Singleton,
                CurrencyConverter.Singleton,
                FormatConverter.Singleton,
                ResolutionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ExchangeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Exchange) || t == typeof(Exchange?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "aggregated":
                    return Exchange.Aggregated;
                case "bibox":
                    return Exchange.Bibox;
                case "bigone":
                    return Exchange.Bigone;
                case "binance":
                    return Exchange.Binance;
                case "bitfinex":
                    return Exchange.Bitfinex;
                case "bitflyer":
                    return Exchange.Bitflyer;
                case "bithumb":
                    return Exchange.Bithumb;
                case "bitmex":
                    return Exchange.Bitmex;
                case "bitstamp":
                    return Exchange.Bitstamp;
                case "bittrex":
                    return Exchange.Bittrex;
                case "bybit":
                    return Exchange.Bybit;
                case "cme":
                    return Exchange.Cme;
                case "cobinhood":
                    return Exchange.Cobinhood;
                case "coinbase":
                    return Exchange.Coinbase;
                case "coincheck":
                    return Exchange.Coincheck;
                case "coinex":
                    return Exchange.Coinex;
                case "deribit":
                    return Exchange.Deribit;
                case "ftx":
                    return Exchange.Ftx;
                case "gate.io":
                    return Exchange.GateIo;
                case "gemini":
                    return Exchange.Gemini;
                case "hitbtc":
                    return Exchange.Hitbtc;
                case "huobi":
                    return Exchange.Huobi;
                case "kraken":
                    return Exchange.Kraken;
                case "kucoin":
                    return Exchange.Kucoin;
                case "luno":
                    return Exchange.Luno;
                case "okex":
                    return Exchange.Okex;
                case "poloniex":
                    return Exchange.Poloniex;
                case "zb.com":
                    return Exchange.ZbCom;
            }
            throw new Exception("Cannot unmarshal type Exchange");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Exchange)untypedValue;
            switch (value)
            {
                case Exchange.Aggregated:
                    serializer.Serialize(writer, "aggregated");
                    return;
                case Exchange.Bibox:
                    serializer.Serialize(writer, "bibox");
                    return;
                case Exchange.Bigone:
                    serializer.Serialize(writer, "bigone");
                    return;
                case Exchange.Binance:
                    serializer.Serialize(writer, "binance");
                    return;
                case Exchange.Bitfinex:
                    serializer.Serialize(writer, "bitfinex");
                    return;
                case Exchange.Bitflyer:
                    serializer.Serialize(writer, "bitflyer");
                    return;
                case Exchange.Bithumb:
                    serializer.Serialize(writer, "bithumb");
                    return;
                case Exchange.Bitmex:
                    serializer.Serialize(writer, "bitmex");
                    return;
                case Exchange.Bitstamp:
                    serializer.Serialize(writer, "bitstamp");
                    return;
                case Exchange.Bittrex:
                    serializer.Serialize(writer, "bittrex");
                    return;
                case Exchange.Bybit:
                    serializer.Serialize(writer, "bybit");
                    return;
                case Exchange.Cme:
                    serializer.Serialize(writer, "cme");
                    return;
                case Exchange.Cobinhood:
                    serializer.Serialize(writer, "cobinhood");
                    return;
                case Exchange.Coinbase:
                    serializer.Serialize(writer, "coinbase");
                    return;
                case Exchange.Coincheck:
                    serializer.Serialize(writer, "coincheck");
                    return;
                case Exchange.Coinex:
                    serializer.Serialize(writer, "coinex");
                    return;
                case Exchange.Deribit:
                    serializer.Serialize(writer, "deribit");
                    return;
                case Exchange.Ftx:
                    serializer.Serialize(writer, "ftx");
                    return;
                case Exchange.GateIo:
                    serializer.Serialize(writer, "gate.io");
                    return;
                case Exchange.Gemini:
                    serializer.Serialize(writer, "gemini");
                    return;
                case Exchange.Hitbtc:
                    serializer.Serialize(writer, "hitbtc");
                    return;
                case Exchange.Huobi:
                    serializer.Serialize(writer, "huobi");
                    return;
                case Exchange.Kraken:
                    serializer.Serialize(writer, "kraken");
                    return;
                case Exchange.Kucoin:
                    serializer.Serialize(writer, "kucoin");
                    return;
                case Exchange.Luno:
                    serializer.Serialize(writer, "luno");
                    return;
                case Exchange.Okex:
                    serializer.Serialize(writer, "okex");
                    return;
                case Exchange.Poloniex:
                    serializer.Serialize(writer, "poloniex");
                    return;
                case Exchange.ZbCom:
                    serializer.Serialize(writer, "zb.com");
                    return;
            }
            throw new Exception("Cannot marshal type Exchange");
        }

        public static readonly ExchangeConverter Singleton = new ExchangeConverter();
    }

    internal class TagConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Tag) || t == typeof(Tag?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "bundle":
                    return Tag.Bundle;
                case "defi":
                    return Tag.Defi;
                case "defiToken":
                    return Tag.DefiToken;
                case "erc20":
                    return Tag.Erc20;
                case "exchangeToken":
                    return Tag.ExchangeToken;
                case "stablecoin":
                    return Tag.Stablecoin;
                case "tokenizedAsset":
                    return Tag.TokenizedAsset;
                case "top":
                    return Tag.Top;
            }
            throw new Exception("Cannot unmarshal type Tag");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Tag)untypedValue;
            switch (value)
            {
                case Tag.Bundle:
                    serializer.Serialize(writer, "bundle");
                    return;
                case Tag.Defi:
                    serializer.Serialize(writer, "defi");
                    return;
                case Tag.DefiToken:
                    serializer.Serialize(writer, "defiToken");
                    return;
                case Tag.Erc20:
                    serializer.Serialize(writer, "erc20");
                    return;
                case Tag.ExchangeToken:
                    serializer.Serialize(writer, "exchangeToken");
                    return;
                case Tag.Stablecoin:
                    serializer.Serialize(writer, "stablecoin");
                    return;
                case Tag.TokenizedAsset:
                    serializer.Serialize(writer, "tokenizedAsset");
                    return;
                case Tag.Top:
                    serializer.Serialize(writer, "top");
                    return;
            }
            throw new Exception("Cannot marshal type Tag");
        }

        public static readonly TagConverter Singleton = new TagConverter();
    }

    internal class CurrencyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Currency) || t == typeof(Currency?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "NATIVE":
                    return Currency.Native;
                case "USD":
                    return Currency.Usd;
            }
            throw new Exception("Cannot unmarshal type Currency");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Currency)untypedValue;
            switch (value)
            {
                case Currency.Native:
                    serializer.Serialize(writer, "NATIVE");
                    return;
                case Currency.Usd:
                    serializer.Serialize(writer, "USD");
                    return;
            }
            throw new Exception("Cannot marshal type Currency");
        }

        public static readonly CurrencyConverter Singleton = new CurrencyConverter();
    }

    internal class FormatConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Format) || t == typeof(Format?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CSV":
                    return Format.Csv;
                case "JSON":
                    return Format.Json;
            }
            throw new Exception("Cannot unmarshal type Format");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Format)untypedValue;
            switch (value)
            {
                case Format.Csv:
                    serializer.Serialize(writer, "CSV");
                    return;
                case Format.Json:
                    serializer.Serialize(writer, "JSON");
                    return;
            }
            throw new Exception("Cannot marshal type Format");
        }

        public static readonly FormatConverter Singleton = new FormatConverter();
    }

    internal class ResolutionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Resolution) || t == typeof(Resolution?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "10m":
                    return Resolution.The10M;
                case "1h":
                    return Resolution.The1H;
                case "1month":
                    return Resolution.The1Month;
                case "1w":
                    return Resolution.The1W;
                case "24h":
                    return Resolution.The24H;
            }
            throw new Exception("Cannot unmarshal type Resolution");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Resolution)untypedValue;
            switch (value)
            {
                case Resolution.The10M:
                    serializer.Serialize(writer, "10m");
                    return;
                case Resolution.The1H:
                    serializer.Serialize(writer, "1h");
                    return;
                case Resolution.The1Month:
                    serializer.Serialize(writer, "1month");
                    return;
                case Resolution.The1W:
                    serializer.Serialize(writer, "1w");
                    return;
                case Resolution.The24H:
                    serializer.Serialize(writer, "24h");
                    return;
            }
            throw new Exception("Cannot marshal type Resolution");
        }

        public static readonly ResolutionConverter Singleton = new ResolutionConverter();
    }
}
