using System.ComponentModel;

namespace test.Common.Enums
{
    public enum RiskTypeEnum
    {
        [Description("BAJO")]
        Bajo = 1,

        [Description("MEDIO")]
        Medio = 2,

        [Description("MEDIOALTO")]
        MedioAlto = 3,

        [Description("ALTO")]
        Alto = 4,
    }
}
