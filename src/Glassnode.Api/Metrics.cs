using System;
using Glassnode.Api.Types;

namespace Glassnode.Api
{
    public class Metrics
    {
        private readonly Metric _metric;

        public Metrics(Metric metric)
        {
            _metric = metric;
            MetricEnpoint = GetMetric();
        }

        public string MetricEnpoint { get; set; }

        private string GetMetric()
        {
            return _metric switch
            {
                Metric.Endpoints => "v2/metrics/endpoints",
                Metric.Assets => "v1/metrics/assets",
                Metric.Nupl => "v1/metrics/indicators/net_unrealized_profit_loss",
                Metric.EntityAdjustedNupl => "v1/metrics/indicators/net_unrealized_profit_loss_account_based",
                Metric.SoprAdjusted => "v1/metrics/indicators/sopr_adjusted",
                Metric.SoprEntityAdjusted => "v1/metrics/indicators/sopr_account_based",
                Metric.MvrvScore => "v1/metrics/market/mvrv_z_score",
                Metric.StockToFlowRatio => "v1/metrics/indicators/stock_to_flow_ratio",
                Metric.PriceDrawdownRelative => "v1/metrics/market/price_drawdown_relative",
                Metric.ReserveRisk => "v1/metrics/indicators/reserve_risk",
                Metric.FuturesLongLiquidationsTotal => "v1/metrics/derivatives/futures_liquidated_volume_long_sum",
                Metric.FuturesShortLiquidationsTotal => "v1/metrics/derivatives/futures_liquidated_volume_short_sum",
                Metric.FuturesLongLiquidationsMean => "v1/metrics/derivatives/futures_liquidated_volume_long_mean",
                Metric.FuturesShortLiquidationsMean => "v1/metrics/derivatives/futures_liquidated_volume_short_mean",
                Metric.FuturesLongLiquidationsDomiance => "v1/metrics/derivatives/futures_liquidated_volume_long_relative",
                Metric.FuturesShortLiquidationsDomiance => "v1/metrics/derivatives/futures_liquidated_volume_short_relative",
                Metric.StableCoinSupplyRatio => "v1/metrics/indicators/ssr",
                Metric.UtxoProfitRelative => "v1/metrics/blockchain/utxo_profit_relative",
                Metric.RealizedPnLRatio => "v1/metrics/indicators/realized_profit_loss_ratio",
                Metric.FuturesPerpetualFundingRate => "v1/metrics/derivatives/futures_funding_rate_perpetual",
                Metric.FuturesPerpetualFundingRateAll => "v1/metrics/derivatives/futures_funding_rate_perpetual_all",
                Metric.FuturesOpenInterest => "v1/metrics/derivatives/futures_open_interest_sum",
                Metric.FuturesOpenInterestPerpetual => "v1/metrics/derivatives/futures_open_interest_perpetual_sum",
                Metric.CashMarginedFuturesOpenInterest => "v1/metrics/derivatives/futures_open_interest_cash_margin_sum",
                Metric.CryptoMarginedFuturesOpenInterest => "v1/metrics/derivatives/futures_open_interest_crypto_margin_sum",
                Metric.PercentCryptoMarginedFuturesOpenInterest => "v1/metrics/derivatives/futures_open_interest_crypto_margin_relative",
                Metric.FuturesVolume => "v1/metrics/derivatives/futures_volume_daily_latest",
                Metric.FuturesEstimatedLeverageRatio => "v1/metrics/derivatives/futures_estimated_leverage_ratio",
                Metric.ExchangeNetflowTotal => "v1/metrics/transactions/transfers_volume_exchanges_net",
                Metric.ExchangeOutflowTotal => "v1/metrics/transactions/transfers_volume_from_exchanges_sum",
                Metric.LiquidSupplyChange => "v1/metrics/supply/liquid_change",
                Metric.EntitiesNetGrowth => "v1/metrics/entities/net_growth_count",
                Metric.EntitiesMinOneThousandCount => "v1/metrics/entities/min_1k_count",
                Metric.StockToFlowDeflection => "v1/metrics/indicators/stock_to_flow_deflection",
                Metric.MinersToExchangesTotal => "v1/metrics/transactions/transfers_volume_miners_to_exchanges",
                Metric.EntityAdjustedSthNupl => "v1/metrics/indicators/nupl_less_155_account_based",
                Metric.EntityAdjustedLthNupl => "v1/metrics/indicators/nupl_more_155_account_based",
                Metric.LthSopr => "v1/metrics/indicators/sopr_more_155",
                Metric.SthNupl => "v1/metrics/indicators/nupl_less_155",
                Metric.PercentAddressesInProfit => "v1/metrics/addresses/profit_relative",
                Metric.BalancedPrice => "v1/metrics/indicators/balanced_price_usd",
                Metric.Price => "v1/metrics/market/price_usd_close",
                Metric.HashRibbon => "v1/metrics/indicators/hash_ribbon",
                Metric.OptionsOpenInterest => "v1/metrics/derivatives/options_open_interest_sum",
                Metric.OptionsOpenInterestByStrikePrice => "v1/metrics/derivatives/options_open_interest_distribution",
                Metric.OptionsAtmIvAll => "v1/metrics/derivatives/options_atm_implied_volatility_1_all",
                Metric.OptionsAtmIvWeek => "v1/metrics/derivatives/options_atm_implied_volatility_1_week",
                Metric.OptionsAtmIvMonth => "v1/metrics/derivatives/options_atm_implied_volatility_1_month",
                Metric.OptionsAtmIv3Months => "v1/metrics/derivatives/options_atm_implied_volatility_3_months",
                Metric.OptionsAtmIv6Months => "v1/metrics/derivatives/options_atm_implied_volatility_6_months",
                Metric.FuturesTermStructure => "v1/metrics/derivatives/futures_term_structure",
                Metric.FuturesTermStructureByExchange => "v1/metrics/derivatives/futures_term_structure_by_exchange",
                Metric.FuturesAnnualizedRollingBasis => "v1/metrics/derivatives/futures_annualized_basis_3m",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}