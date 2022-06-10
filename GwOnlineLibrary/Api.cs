using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using GwOnlineLibrary.Domain;
using GwOnlineLibrary.Interfaces;
using GwOnlineLibrary.Utilities;

namespace GwOnlineLibrary;

internal class Api : IApi
{
    private readonly string _baseUrl;
    private readonly string _user;
    private readonly string _password;
    private HttpClient _client;
    private JsonSerializerOptions _jsonOptions;

    internal Api(string baseUrl, string user, string password)
    {
        _baseUrl = string.IsNullOrEmpty(baseUrl)
            ? throw new ArgumentNullException(nameof(baseUrl), "This field is required")
            : baseUrl;

        _user = string.IsNullOrEmpty(user)
            ? throw new ArgumentNullException(nameof(user), "This field is required")
            : user;

        _password = string.IsNullOrEmpty(password)
            ? throw new ArgumentNullException(nameof(password), "This field is required")
            : password;

        ConfigClient();
        _jsonOptions = new JsonSerializerOptions()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };
    }

    private void ConfigClient()
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri(_baseUrl),
            Timeout = TimeSpan.FromSeconds(Configuration.TimeoutRequest),
        };
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        _client = client;
    }

    private string EncryptKey(string key)
    {
        var rsaPublicKey = RSA.Create();
        rsaPublicKey.ImportFromPem(key);
        var encrypt = rsaPublicKey.Encrypt(Encoding.ASCII.GetBytes(_password), RSAEncryptionPadding.Pkcs1);
        var pass = Convert.ToBase64String(encrypt);
        return pass;
    }

    public async Task<TokenGw> LogonAsync()
    {
        var key = await GetKeyAsync();
        var pass = EncryptKey(key);

        var json = JsonSerializer.Serialize(new { user = _user, password = pass });

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        content.Headers.Remove("Content-Type");
        content.Headers.Add("Content-Type", "application/json");

        var response = await _client.PostAsync("/v1/logon", content);

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var gwToken = JsonSerializer.Deserialize<TokenGw>(responseString, _jsonOptions);

        if(gwToken == null)
            throw new Exception("Invalid response from gw");
        
        _client.DefaultRequestHeaders.Add("x-access-token", gwToken.Token);

        return gwToken;
    }

    public async Task<string> GetKeyAsync()
    {
        var response = await _client.GetAsync("/v1/getKey");

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException("Can't get public key from gw");

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<PublicKey>(json, _jsonOptions);

        if (result == null)
            throw new ArgumentNullException(nameof(result), "Invalid response from gw");

        return result.Key;
    }

    public async Task<TransactionResult> TransactionAsync(TransactionRequest request)
    {
        var content = new StringContent(request.ToJson(), Encoding.UTF8, "application/json");
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await _client.PostAsync("/v2/transaction", content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<TransactionResult>(json, _jsonOptions);

        return result;
    }

    public async Task<StatusResult> TransactionStatusAsync(string nsu)
    {
        var request = JsonSerializer.Serialize(new { tid = nsu });
        var content = new StringContent(request, Encoding.UTF8, "application/json");
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await _client.PostAsync("/v1/verify", content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<StatusResult>(json, _jsonOptions);

        return result;
    }
}