using System.ComponentModel;

namespace GwOnlineLibrary.Domain.Enums;

public enum Methods
{
    [Description("Delivery at the same day")]
    SameDay,

    [Description("Delibery at the next day")]
    NextDay,

    [Description("Delivery in 2 days")]
    TwoDay,

    [Description("Delivery in 3 days")]
    ThreeDay,

    [Description("Low cost delivery method")]
    LowCost,

    [Description("Receive in the store")]
    Pickup,

    [Description("Other means of delivery")]
    Other,

    [Description("No means of delivery as it is a service or subscription")]
    None
}