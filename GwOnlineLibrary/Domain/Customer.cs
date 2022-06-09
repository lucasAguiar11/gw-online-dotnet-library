using GwOnlineLibrary.Domain.Enums;
using GwOnlineLibrary.Utilities;

namespace GwOnlineLibrary.Domain;

public class Customer
{
    private string _name;
    private string _phone;
    private string _ddd;
    private string _email;
    private string _document;
    private string _ip;
    private Billing _billing;
    private Shipping _shipping;

    internal string Login { get; set; }

    internal string Password { get; set; }

    internal DocumentType DocumentType => Document.Length > 11 ? DocumentType.CNPJ : DocumentType.CPF;


    public Customer()
    {
        
    }
    
    public Customer(Billing billing, Shipping shipping, string name,  string ddd, string phone, string email,
        string document, string ip)
    {
        Name = name;
        Phone = phone;
        Ddd = ddd;
        Email = email;
        Document = document;
        Ip = ip;
        Shipping = shipping;
        Billing = billing;
    }

    /// <summary>
    /// Customer's gender acceptable values: "M" or "F"
    /// </summary>
    public Gender? Gender { get; set; }

    /// <summary>
    /// Customer's name
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    /// <exception cref="ArgumentOutOfRangeException">This field must have between 2 and 50 characters</exception>
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Name), "This field is required");

            if (value.Length is < 2 or > 50)
                throw new ArgumentOutOfRangeException(nameof(Name),
                    "This field must have between 2 and 50 characters");

            _name = value;
        }
    }

    /// <summary>
    /// Customer's phone DDD
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    /// <exception cref="ArgumentOutOfRangeException">This field must be 2 characters long</exception>
    public string Ddd
    {
        get => _ddd;
        set
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
    /// <exception cref="ArgumentNullException">This field is required</exception>
    /// <exception cref="ArgumentOutOfRangeException">This field must have between 2 and 60 characters</exception>
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
    /// Customer's email
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    /// <exception cref="ArgumentException">Invalid email format</exception>
    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Email), "This field is required");

            if (!value.ValidateEmailFormat())
                throw new ArgumentException("Invalid email format", nameof(Email));

            _email = value;
        }
    }

    /// <summary>
    /// Ip address of the customer
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    /// <exception cref="ArgumentException">Invalid ip format</exception>
    public string Ip
    {
        get => _ip;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Ip), "This field is required");

            if (!value.ValidateIp())
                throw new ArgumentException("Invalid ip format", nameof(Ip));

            _ip = value;
        }
    }

    /// <summary>
    /// Customer's document number
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    /// <exception cref="ArgumentOutOfRangeException">This field must have 11 or 14 characters</exception>
    public string Document
    {
        get => _document;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Document), "This field is required");

            if (value.Length is not 11 or > 14)
                throw new ArgumentOutOfRangeException(nameof(Document),
                    "This field must have 11 or 14 characters");

            _document = value;
        }
    }
    
    /// <summary>
    /// Billing information
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    public Billing Billing
    {
        get => _billing;
        set => _billing = value ?? throw new ArgumentNullException(nameof(Billing), "This field is required");
    }

    /// <summary>
    /// Shipping information
    /// </summary>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    public Shipping Shipping
    {
        get => _shipping;
        set => _shipping = value ?? throw new ArgumentNullException(nameof(Shipping), "This field is required");
    }

    /// <summary>
    /// Customer's birth date
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Customer's "FingerPrint"
    /// Information used to identify the customer device. This information must be used to generate the value assigned to the script field session id on the checkout page
    /// </summary>
    public string FingerPrint { get; set; }

    
    internal void Validate()
    {
        Name = Name ?? throw new ArgumentNullException(nameof(Name), "This field is required");
        Phone = Phone ?? throw new ArgumentNullException(nameof(Phone), "This field is required");
        Ddd = Ddd ?? throw new ArgumentNullException(nameof(Ddd), "This field is required");
        Email = Email ?? throw new ArgumentNullException(nameof(Email), "This field is required");
        Document = Document ?? throw new ArgumentNullException(nameof(Document), "This field is required");
        Ip = Ip ?? throw new ArgumentNullException(nameof(Ip), "This field is required");
        Billing = Billing ?? throw new ArgumentNullException(nameof(Billing), "This field is required");
        Shipping = Shipping ?? throw new ArgumentNullException(nameof(Shipping), "This field is required");
    }
}