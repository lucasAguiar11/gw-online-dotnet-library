using GwOnlineLibrary.Domain;
using GwOnlineLibrary.Interfaces;
using GwOnlineLibrary.Utilities;

namespace GwOnlineLibrary;

public class GwOnline : IGwOnline
{
    private DateTimeOffset? _lastTokenUpdate;

    private readonly IApi _api;

    public GwOnline(string user, string password, bool test = false)
    {
        if (string.IsNullOrEmpty(user))
            throw new ArgumentNullException(nameof(user), "User cannot be null or empty");

        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password), "Password cannot be null or empty");

        _api = new Api(test ? Configuration.UrlTest : Configuration.UrlPrd, user, password);
    }

    private async Task GetTokenAsync()
    {
        if (_lastTokenUpdate?.AddMinutes(25) > DateTimeOffset.Now)
            return;

        var gwToken = await _api.LogonAsync();

        if (gwToken == null)
            throw new ArgumentNullException(nameof(gwToken), "This field is required");

        if (string.IsNullOrEmpty(gwToken.Token))
            throw new ArgumentException("Invalid token", nameof(gwToken));

        _lastTokenUpdate = DateTimeOffset.Now;
    }

    /// <summary>
    /// The Celer Network is prepared to work with a single transaction for card acceptance (the authorization and capture use the same transaction).
    /// Therefore, it's not necessary send any additional transaction to process the sale.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<TransactionResult> SaleAsync(TransactionRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request), "This field is required");

        request.Verify();
        await GetTokenAsync();

        var result = await _api.TransactionAsync(request);

        return result;
    }

    /// <summary>
    /// This service was designed as an option to verify the transaction situation,
    /// in case of any situation that is not possible to receive the normal transaction result (like connectivity problems).
    /// </summary>
    /// <param name="tid"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<StatusResult> TransactionStatusAsync(string tid)
    {
        if (string.IsNullOrEmpty(tid))
            throw new ArgumentNullException(nameof(tid), "This field is required");

        await GetTokenAsync();

        var result = await _api.TransactionStatusAsync(tid);

        return result;
    }

    /// <summary>
    /// Considering that Celer works with single transaction, we also work with just one kind of message to totally cancel the original sale.
    /// </summary>
    /// <param name="tid"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CancellationResult> CancellationAsync(string tid)
    {
        if (string.IsNullOrEmpty(tid))
            throw new ArgumentNullException(nameof(tid), "This field is required");

        await GetTokenAsync();

        var result = await _api.CancellationAsync(tid);

        return result;
    }
}