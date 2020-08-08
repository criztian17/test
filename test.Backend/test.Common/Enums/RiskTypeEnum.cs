using System.ComponentModel;

namespace test.Common.Enums
{
    /// <summary>
    /// Risk Type Enum
    /// </summary>
    public enum RiskTypeEnum
    {
        [Description("LOW")]
        Low = 1,

        [Description("MID")]
        Mid = 2,

        [Description("MIDHIGH")]
        MidHigh = 3,

        [Description("HIGH")]
        High = 4,
    }
}
