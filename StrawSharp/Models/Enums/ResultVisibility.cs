using System.Runtime.Serialization;

namespace StrawSharp.Models.Enums
{
    public enum ResultVisibility
    {
        [EnumMember(Value = "always")]
        Always,
        [EnumMember(Value = "after_deadline")]
        AfterDeadline,
        [EnumMember(Value = "hidden")]
        Never
    }
}