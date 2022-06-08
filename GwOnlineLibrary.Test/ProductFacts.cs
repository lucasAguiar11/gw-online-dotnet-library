using GwOnlineLibrary.Domain;

namespace GwOnlineLibrary.Test;

[Trait("Category", "Domain")]
public class ProductFacts
{
    [Fact(DisplayName = "Product: Name validation")]
    public void Verify_Name_Validation()
    {
        Assert.Throws<ArgumentNullException>(() => new Product(null));

        Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Prd"));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Product(new string('x', 101)));

        var product = new Product("Product");
        Assert.Equal("Product", product.Name);

        var name = new string('x', 100);
        product.Name = name;
        Assert.Equal(name, product.Name);
    }

    [Fact(DisplayName = "Product: Price validation")]
    public void Verify_Price_Validation()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Product", 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Product", -1));

        var product = new Product("Product", 0.01m);
        Assert.Equal(0.01m, product.Price);
    }

    [Fact(DisplayName = "Product: Quantity validation")]
    public void Verify_Quantity_Validation()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Product", 100, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Product", 100, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Product", 100, 1000000));

        var product = new Product("Product", 0.01m, 2);
        Assert.Equal(2, product.Quantity);
    }

    [Fact(DisplayName = "Product: Sku validation")]
    public void Verify_Sku_Validation()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Product("Product", 100, 2, new string('x', 101)));

        var product = new Product("Product", 100, 2, "SKU");
        Assert.Equal("SKU", product.Sku);

        var product2 = new Product("Product", 100, 2);
        Assert.Null(product2.Sku);
    }
}