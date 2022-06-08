using GwOnlineLibrary.Domain.Enums;
using GwOnlineLibrary.Utilities;

namespace GwOnlineLibrary.Domain;

public class Shipping
{
    private string _firstName;
    private string _lastName;
    private string _street;
    private string _number;
    private string _country;
    private string _zipCode;
    private string _ddd;
    private string _phone;

    public Shipping(string firstName, string lastName, string street, string number, string zipCode, string ddd,
        string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Street = street;
        Number = number;
        ZipCode = zipCode;
        Ddd = ddd;
        Phone = phone;
        Country = Constants.DefaultCountry;
        Methods = Methods.Other;
    }

    public Shipping(string firstName, string lastName, string street, string number, string zipCode, string ddd,
        string phone, string country)
    {
        FirstName = firstName;
        LastName = lastName;
        Street = street;
        Number = number;
        ZipCode = zipCode;
        Ddd = ddd;
        Phone = phone;
        Country = country;
        Methods = Methods.Other;
    }


    public Shipping(string firstName, string lastName, string street, string number, string zipCode, string ddd,
        string phone, Methods method)
    {
        FirstName = firstName;
        LastName = lastName;
        Street = street;
        Number = number;
        ZipCode = zipCode;
        Ddd = ddd;
        Phone = phone;
        Country = Constants.DefaultCountry;
        Methods = method;
    }

    public Shipping(string firstName, string lastName, string street, string number, string zipCode, string ddd,
        string phone, string country, Methods method)
    {
        FirstName = firstName;
        LastName = lastName;
        Street = street;
        Number = number;
        ZipCode = zipCode;
        Ddd = ddd;
        Phone = phone;
        Country = Constants.DefaultCountry;
        Methods = method;
        Country = country;
    }


    /// <summary>
    /// Customer's first name
    /// </summary>
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(FirstName), "This field is required");

            if (value.Length is < 2 or > 50)
                throw new ArgumentOutOfRangeException(nameof(FirstName),
                    "This field must have between 2 and 50 characters");

            _firstName = value;
        }
    }

    /// <summary>
    /// Customer's last name
    /// </summary>
    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(LastName), "This field is required");

            if (value.Length is < 2 or > 50)
                throw new ArgumentOutOfRangeException(nameof(LastName),
                    "This field must have between 2 and 50 characters");

            _lastName = value;
        }
    }

    /// <summary>
    /// Name of the street
    /// </summary>
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
    public string Number
    {
        get => _number;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Number), "This field is required");

            if (value.Length > 50)
                throw new ArgumentOutOfRangeException(nameof(Number),
                    "The maximum value for this field is 100");

            _number = value;
        }
    }

    /// <summary>
    /// Name of the country
    /// </summary>
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

    /// <summary>
    /// Customer's phone DDD
    /// </summary>
    public string Ddd
    {
        get => _ddd;
        init
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Ddd), "This field is required");

            if (value.Length != 2)
                throw new ArgumentOutOfRangeException(nameof(Ddd),
                    "This field must be 2 characters long");
            _ddd = value;
        }
    }

    /// <summary>
    /// Customer's phone number
    /// </summary>
    public string Phone
    {
        get => _phone;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Phone), "This field is required");

            if (value.Length is < 8 or > 11)
                throw new ArgumentOutOfRangeException(nameof(Phone),
                    "This field must have between 2 and 60 characters");

            _phone = value;
        }
    }

    /// <summary>
    /// Delivery method
    /// </summary>
    public Methods Methods { get; set; }
}