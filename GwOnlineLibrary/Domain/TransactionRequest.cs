using System.Text.Json;
using System.Text.Json.Serialization;
using GwOnlineLibrary.Domain.Enums;

namespace GwOnlineLibrary.Domain;

public class TransactionRequest
{
    private string _pan;
    private string _cardHolderName;
    private string _expirationDate;
    private string _cvv;
    private decimal _amount;
    private int _installments;
    private string _site;
    private Customer _customer;
    private List<Product> _products;

    public TransactionRequest()
    {
    }

    public TransactionRequest(Customer customer, List<Product> products, string pan, string cardHolderName,
        string expirationDate, string cvv, decimal amount, int installments, string site)
    {
        Customer = customer;
        Products = products;
        Pan = pan;
        CardHolderName = cardHolderName;
        ExpirationDate = expirationDate;
        Cvv = cvv;
        Amount = amount;
        Installments = installments;
        Site = site;
    }

    /// <summary>
    /// Card number
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [JsonPropertyName("pan")]
    public string Pan
    {
        get => _pan;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Pan), "This field is required");

            if (value.Length is < 12 or > 19)
                throw new ArgumentOutOfRangeException(nameof(Pan),
                    "This field must have between 12 and 19 characters");

            _pan = value;
        }
    }

    /// <summary>
    /// Indicates the use of capture
    /// </summary>
    [JsonPropertyName("capture")]
    public bool Capture { get; set; } = true;

    /// <summary>
    /// Cardholder name embossed on the card
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [JsonPropertyName("cardholderName")]
    public string CardHolderName
    {
        get => _cardHolderName;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(CardHolderName), "This field is required");

            if (value.Length is < 2 or > 50)
                throw new ArgumentOutOfRangeException(nameof(CardHolderName),
                    "This field must have between 2 and 50 characters");

            _cardHolderName = value;
        }
    }

    /// <summary>
    /// Expiration card date. Format: "MM/AA"
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [JsonPropertyName("expirationDate")]
    public string ExpirationDate
    {
        get => _expirationDate;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(ExpirationDate), "This field is required");

            if (value.Length != 5)
                throw new ArgumentOutOfRangeException(nameof(ExpirationDate),
                    "This field must be 5 characters long");

            _expirationDate = value;
        }
    }

    /// <summary>
    /// Indication of availability of CVV. Available values: "E"(present), "NE"(absent), "U"(illegible) or "NR"(unconsidered)
    /// </summary>
    [JsonPropertyName("cvvStatus")]
    public CvvStatus CvvStatus { get; set; }

    /// <summary>
    /// Card Code Verification
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [JsonPropertyName("cvv")]
    public string Cvv
    {
        get => _cvv;
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length is not 3 or 4)
                    throw new ArgumentOutOfRangeException(nameof(ExpirationDate),
                        "This field must be 3 or 4 characters long");
            }

            _cvv = value;
        }
    }

    /// <summary>
    /// Card Association. Acceptable values: "MASTERCARD", "VISA", "ELO CREDITO", "DINERS", "HIPERCARD" or "AMEX"
    /// </summary>
    [JsonPropertyName("brand")]
    public Brand Brand { get; set; }

    /// <summary>
    /// Transaction amount
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [JsonPropertyName("amount")]
    public decimal Amount
    {
        get => _amount;
        set
        {
            if (value < 0.01m)
                throw new ArgumentOutOfRangeException(nameof(Amount), "The minimum value for this field is 0.01");

            _amount = value;
        }
    }

    /// <summary>
    /// Transaction date. Format: "AAAA-MM-DDTHH:mm:ss"
    /// </summary>
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// Payment type. Acceptable values: "V"(normal credit), "E"(Instalment by Issuer) or "L"(Instalment by merchant)
    /// </summary>
    [JsonPropertyName("paymentType")]
    public PaymentType PaymentType { get; set; }

    /// <summary>
    /// Number of installments
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [JsonPropertyName("installments")]
    public int Installments
    {
        get => _installments;
        set
        {
            if (value is < 1 or > 18)
                throw new ArgumentOutOfRangeException(nameof(Installments),
                    "This field must have a value between 1 and 18");

            _installments = value;
        }
    }

    /// <summary>
    /// Connection source
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    [JsonPropertyName("site")]
    public string Site
    {
        get => _site;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Site), "This field is required");

            _site = value;
        }
    }

    /// <summary>
    /// Flag to be setup as split
    /// </summary>
    [JsonPropertyName("splitMode")]
    public bool SplitMode { get; set; }

    /// <summary>
    /// Sale channel
    /// </summary>
    [JsonPropertyName("sellerChannel")]
    public string SellerChannel { get; set; }

    /// <summary>
    /// Product type
    /// </summary>
    [JsonPropertyName("productsCategory")]
    public string ProductsCategory { get; set; }

    /// <summary>
    /// Transaction Customer
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    [JsonPropertyName("customer")]
    public Customer Customer
    {
        get => _customer;
        set => _customer = value ?? throw new ArgumentNullException(nameof(Customer), "This field is required");
    }

    /// <summary>
    /// Transaction Products
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    [JsonPropertyName("products")]
    public List<Product> Products
    {
        get => _products;
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(Products), "This field is required");

            if (!value.Any())
                throw new InvalidOperationException("This field must have at least one product");

            _products = value;
        }
    }

    internal void Verify()
    {
        Pan = Pan ?? throw new ArgumentNullException(nameof(Pan), "This field is required");
        CardHolderName = CardHolderName ??
                         throw new ArgumentNullException(nameof(CardHolderName), "This field is required");
        ExpirationDate = ExpirationDate ??
                         throw new ArgumentNullException(nameof(ExpirationDate), "This field is required");
        Site = Site ?? throw new ArgumentNullException(nameof(Site), "This field is required");
        Customer = Customer ?? throw new ArgumentNullException(nameof(Customer), "This field is required");
        Products = Products ?? throw new ArgumentNullException(nameof(Products), "This field is required");

        Customer.Verify();
    }

    internal string ToJson()
    {
        var options = new JsonSerializerOptions { Converters = { new JsonStringEnumConverter() } };
        return JsonSerializer.Serialize(this, options);
    }
}