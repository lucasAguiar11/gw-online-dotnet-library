using GwOnlineLibrary.Interfaces;
using GwOnlineLibrary.Utilities;

namespace GwOnlineLibrary;

public class GwOnline : IGwOnline
{
    private readonly string _user;
    private readonly string _password;

    private readonly string _url;

    public GwOnline(string user, string password, bool test = false)
    {
        _user = user;
        _password = password;
        _url = test ? Constants.UrlTest : Constants.UrlPrd;
    }
    
    
}