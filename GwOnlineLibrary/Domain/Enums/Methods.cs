using System.ComponentModel;

namespace GwOnlineLibrary.Domain.Enums;

public enum Methods
{
    [Description("Same day delivery method")]
    SameDay,

    [Description("Next day delivery method")]
    NextDay,

    [Description("Delivery method in two days")]
    TwoDay,

    [Description("Delivery method in three days")]
    ThreeDay,

    [Description("Low cost delivery method")]
    LowCost,

    [Description("Pick up in store")]
    Pickup,

    [Description("Other means of delivery")]
    Other,

    [Description("No means of delivery as it is a service or subscription")]
    None
}