using System.Diagnostics.CodeAnalysis;
using GwOnlineLibrary.Domain;

namespace GwOnlineLibrary.Interfaces;

internal interface IGwOnline
{
    Task<TransactionResult> SaleAsync([NotNull] TransactionRequest request);
    Task<StatusResult> TransactionStatusAsync([NotNull] string tid);
}