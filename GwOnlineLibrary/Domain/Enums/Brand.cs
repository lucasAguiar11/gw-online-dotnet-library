using System.ComponentModel;

namespace GwOnlineLibrary.Domain.Enums;

public enum Brand
{
    [Description("Mastercard")]
    MASTERCARD,
    [Description("Visa")]
    VISA,
    [Description("Elo Crédito")]
    ELO_CREDITO,
    [Description("Dinners Club")]
    DINERS,
    [Description("Hipercard")]
    HIPERCARD,
    [Description("American Express")]
    AMEX
}