using GwOnlineLibrary.Domain;
using GwOnlineLibrary.Interfaces;
using GwOnlineLibrary.Utilities;

namespace GwOnlineLibrary;

public class GwOnline : IGwOnline
{
    private DateTimeOffset? _lastTokenUpdate;

    private readonly Api _api;

    public GwOnline(string user, string password, bool test = false)
    {
        if (string.IsNullOrEmpty(user))
            throw new ArgumentNullException(nameof(user), "User cannot be null or empty");

        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password), "Password cannot be null or empty");

        _api = new Api(test ? Constants.UrlTest : Constants.UrlPrd, user, password);
    }


    /// <summary>
    /// 
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
}