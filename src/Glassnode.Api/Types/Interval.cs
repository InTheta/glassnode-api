using System.Runtime.Serialization;

namespace Glassnode.Api.Types
{
    public enum Interval
    {
        [EnumMember(Value = "1h")]Hour,
        [EnumMember(Value = "24h")]Day,
        [EnumMember(Value = "10m")]TenMinute
    }
}