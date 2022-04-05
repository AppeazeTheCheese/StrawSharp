using System.Runtime.Serialization;

namespace StrawSharp.Models.Enums
{
    public enum ForceAppearance
    {
        [EnumMember(Value = "light")]
        Light,
        [EnumMember(Value = "dark")]
        Dark,
        [EnumMember(Value = "auto")]
        Auto
    }
}
