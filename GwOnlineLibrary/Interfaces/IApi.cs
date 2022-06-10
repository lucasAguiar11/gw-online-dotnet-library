using GwOnlineLibrary.Domain;

namespace GwOnlineLibrary.Interfaces;

internal interface IApi
{
    Task<TokenGw> LogonAsync();
    Task<string> GetKeyAsync();
    Task<TransactionResult> TransactionAsync(TransactionRequest request);
    Task<StatusResult> TransactionStatusAsync(string nsu);
    Task<CancellationResult> CancellationAsync(string nsu);
}