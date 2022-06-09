using System.ComponentModel;

namespace GwOnlineLibrary.Domain.Enums;

public enum CvvStatus
{
    [Description("Existing CVV")] 
    E,
    [Description("No existing CVV")] 
    NE,
    [Description("Unreadable")] 
    U,
    [Description("Disregarded")] 
    NR
}