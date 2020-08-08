using System.ComponentModel;

namespace test.Common.Enums
{
    /// <summary>
    /// State Enum
    /// </summary>
    public enum StateEnum
    {
        [Description("Active")]
        Active = 1,

        [Description("Canceled")]
        Canceled = 2,
    }
}
