using System.ComponentModel;
namespace Core.Results.ComplexTypes
{
    public enum GearTypes:byte
    {
        [Description("Manuel")]
        Manuel=1,
        [Description("Automatic")]
        Automatic = 2,
        [Description("Half-Automatic")]
        HalfAutomatic = 3,
        [Description("Auto-Pilot")]
        AutoPilot = 4,
    }
}
