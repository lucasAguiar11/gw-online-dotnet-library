using GwOnlineLibrary.Utilities;

namespace GwOnlineLibrary.Domain;

public class Billing
{
    private string _street;
    private string _number;
    private string _neighborhood;
    private string _city;
    private string _state;
    private string _country;
    private string _zipCode;


    public Billing(string street, string number, string neighborhood, string city, string state, string country,
        string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }


    public Billing(string street, string number, string neighborhood, string city, string state,
        string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = Constants.DefaultCountry;
        ZipCode = zipCode;
    }

    
    /// <summary>
    /// Name of the street
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">This field must have between 4 and 50 characters</exception>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    public string Street
    {
        get => _street;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Street), "This field is required");

            if (value.Length is < 4 or > 50)
                throw new ArgumentOutOfRangeException(nameof(Street),
                    "This field must have between 4 and 50 characters");

            _street = value;
        }
    }

    /// <summary>
    /// Address number
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">The maximum value for this field is 50</exception>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    public string Number
    {
        get => _number;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Number), "This field is required");

            if (value.Length > 50)
                throw new ArgumentOutOfRangeException(nameof(Number),
                    "The maximum value for this field is 50");

            _number = value;
        }
    }

    /// <summary>
    /// Address neighborhood
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    /// <exception cref="ArgumentOutOfRangeException">This field must have between 4 and 50 characters</exception>
    public string Neighborhood
    {
        get => _neighborhood;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Neighborhood), "This field is required");

            if (value.Length is < 4 or > 50)
                throw new ArgumentOutOfRangeException(nameof(Street),
                    "This field must have between 4 and 50 characters");

            _neighborhood = value;
        }
    }

    /// <summary>
    /// Address city
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    /// <exception cref="ArgumentOutOfRangeException">This field must have between 1 and 60 characters</exception>
    public string City
    {
        get => _city;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(City), "This field is required");

            if (value.Length > 60)
                throw new ArgumentOutOfRangeException(nameof(City),
                    "This field must have between 1 and 60 characters");

            _city = value;
        }
    }

    /// <summary>
    /// Address state
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    /// <exception cref="ArgumentOutOfRangeException">This field must be 2 characters long</exception>
    public string State
    {
        get => _state;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(State), "This field is required");

            if (value.Length != 2)
                throw new ArgumentOutOfRangeException(nameof(State),
                    "This field must be 2 characters long");

            _state = value;
        }
    }


    /// <summary>
    /// Name of the country
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    /// <exception cref="ArgumentOutOfRangeException">This field must have between 2 and 60 characters</exception>
    public string Country
    {
        get => _country;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Country), "This field is required");

            if (value.Length is < 2 or > 60)
                throw new ArgumentOutOfRangeException(nameof(Country),
                    "This field must have between 2 and 60 characters");

            _country = value;
        }
    }

    /// <summary>
    /// Address zip code
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">This field must be 8 characters long</exception>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    public string ZipCode
    {
        get => _zipCode;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(ZipCode), "This field is required");

            if (value.Length != 8)
                throw new ArgumentOutOfRangeException(nameof(ZipCode),
                    "This field must be 8 characters long");

            _zipCode = value;
        }
    }
}