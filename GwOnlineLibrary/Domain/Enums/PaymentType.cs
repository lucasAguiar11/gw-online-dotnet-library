using System.ComponentModel;

namespace GwOnlineLibrary.Domain.Enums;

public enum PaymentType
{
    [Description("Normal Credit")]
    V,
    [Description("Instalment by Issuer")]
    E,
    [Description("Instalment by merchant")]
    L
}