using GwOnlineLibrary.Utilities;

namespace GwOnlineLibrary.Domain;

public class Product
{
    private string _name;
    private readonly decimal _price;
    private readonly int _quantity;
    private readonly string _sku;

    public Product(string name)
    {
        Name = name;
        Price = Constants.DefaultPrice;
        Quantity = Constants.DefaultQuantity;
    }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
        Quantity = Constants.DefaultQuantity;
    }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public Product(string name, decimal price, int quantity, string sku)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Sku = sku;
    }

    /// <summary>
    /// Product name
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">This field must have between 4 and 100 characters</exception>
    /// <exception cref="ArgumentNullException">This field is required</exception>
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(Name), "This field is required");

            if (value.Length is > 100 or < 4)
                throw new ArgumentOutOfRangeException(nameof(Name),
                    "This field must have between 4 and 100 characters");

            _name = value;
        }
    }

    /// <summary>
    /// Preço unitário do produto
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">The minimum value for this field is 0.01</exception>
    public decimal Price
    {
        get => _price;
        init
        {
            if (value < 0.01m)
                throw new ArgumentOutOfRangeException(nameof(Price), "The minimum value for this field is 0.01");

            _price = value;
        }
    }

    /// <summary>
    /// Quantidade do produto. Valor mínimo de 1.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">This field must have a value between 1 and 999999</exception>
    public int Quantity
    {
        get => _quantity;
        init
        {
            if (value is < 1 or > 999999)
                throw new ArgumentOutOfRangeException(nameof(Quantity),
                    "This field must have a value between 1 and 999999");

            _quantity = value;
        }
    }

    /// <summary>
    /// Unidade de Controle de Estoque (Stock Keeping Unit)
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">The maximum value for this field is 100</exception>
    public string? Sku
    {
        get => _sku;
        init
        {
            if (value?.Length > 100)
                throw new ArgumentOutOfRangeException(nameof(Sku), "The maximum value for this field is 100");

            _sku = value;
        }
    }
}