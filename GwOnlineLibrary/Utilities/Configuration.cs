namespace GwOnlineLibrary.Utilities;

public static class Configuration
{
    private static int _timeoutRequest = 100;
    private static string _urlTest = "http://52.168.167.13:8205/";

    #region URLs

    internal static string UrlPrd => "http://52.168.167.13:8205/";

    /// <summary>
    /// Default URL for the API http://52.168.167.13:8205/
    /// </summary>
    public static string UrlTest
    {
        get => _urlTest;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value), "URL cannot be null or empty");

            _urlTest = value;
        }
    }

    #endregion

    #region Default Values

    internal static int DefaultQuantity => 1;

    internal static decimal DefaultPrice => 0.01m;

    internal static string DefaultCountry => "Brasil";

    /// <summary>
    /// Timeout in seconds
    /// </summary>
    public static int TimeoutRequest
    {
        get => _timeoutRequest;
        set
        {
            if (_timeoutRequest < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Timeout must be greater than zero");

            _timeoutRequest = value;
        }
    }

    #endregion
}