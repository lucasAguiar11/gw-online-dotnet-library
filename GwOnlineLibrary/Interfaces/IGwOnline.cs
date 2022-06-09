using System.Diagnostics.CodeAnalysis;
using GwOnlineLibrary.Domain;

namespace GwOnlineLibrary.Interfaces;

public interface IGwOnline
{
    Task<TransactionResult> SaleAsync([NotNull] TransactionRequest request);
}