using GwOnlineLibrary.Domain;

namespace GwOnlineLibrary.Test;

[Trait("Category", "Domain")]
public class ShippingFacts
{
    [Fact(DisplayName = "Shipping: FirstName validation")]
    public void Verify_Name_Validation()
    {
        var shipping = new Shipping("FirstName", "LastName", "Street", "Number", "00000000", "11", "111111111");

        Assert.Throws<ArgumentNullException>(() => shipping.FirstName = null);
        Assert.Throws<ArgumentNullException>(() => shipping.FirstName = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.FirstName = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.FirstName = new string('x', 51));
    }

    [Fact(DisplayName = "Shipping: LastName validation")]
    public void Verify_LastName_Validation()
    {
        var shipping = new Shipping("FirstName", "LastName", "Street", "Number", "00000000", "11", "111111111");

        Assert.Throws<ArgumentNullException>(() => shipping.LastName = null);
        Assert.Throws<ArgumentNullException>(() => shipping.LastName = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.LastName = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.LastName = new string('x', 51));
    }

    [Fact(DisplayName = "Shipping: Street validation")]
    public void Verify_Street_Validation()
    {
        var shipping = new Shipping("FirstName", "LastName", "Street", "Number", "00000000", "11", "111111111");

        Assert.Throws<ArgumentNullException>(() => shipping.Street = null);
        Assert.Throws<ArgumentNullException>(() => shipping.Street = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Street = new string('x', 2));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Street = new string('x', 51));
    }

    [Fact(DisplayName = "Shipping: Number validation")]
    public void Verify_Number_Validation()
    {
        var shipping = new Shipping("FirstName", "LastName", "Street", "Number", "00000000", "11", "111111111");

        Assert.Throws<ArgumentNullException>(() => shipping.Number = null);
        Assert.Throws<ArgumentNullException>(() => shipping.Number = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Number = new string('x', 51));
    }

    [Fact(DisplayName = "Shipping: Country validation")]
    public void Verify_Country_Validation()
    {
        var shipping = new Shipping("FirstName", "LastName", "Street", "Number", "00000000", "11", "111111111");

        Assert.Equal(shipping.Country, "Brasil");
        Assert.Throws<ArgumentNullException>(() => shipping.Country = null);
        Assert.Throws<ArgumentNullException>(() => shipping.Country = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Country = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Country = new string('x', 61));
    }
    
    [Fact(DisplayName = "Shipping: ZipCode validation")]
    public void Verify_ZipCode_Validation()
    {
        var shipping = new Shipping("FirstName", "LastName", "Street", "Number", "00000000", "11", "111111111");

        Assert.Throws<ArgumentNullException>(() => shipping.ZipCode = null);
        Assert.Throws<ArgumentNullException>(() => shipping.ZipCode = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.ZipCode = new string('x', 7));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.ZipCode = new string('x', 9));
        
        Assert.Equal(shipping.ZipCode, "00000000");
    }

    [Fact(DisplayName = "Shipping: DDD validation")]
    public void Verify_Ddd_Validation()
    {
        var shipping = new Shipping("FirstName", "LastName", "Street", "Number", "00000000", "11", "111111111");

        Assert.Throws<ArgumentNullException>(() => shipping.ZipCode = null);
        Assert.Throws<ArgumentNullException>(() => shipping.ZipCode = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.ZipCode = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.ZipCode = new string('x', 2));
        
        Assert.Equal(shipping.Ddd, "11");
    }
    
    [Fact(DisplayName = "Shipping: Phone validation")]
    public void Verify_Phone_Validation()
    {
        var shipping = new Shipping("FirstName", "LastName", "Street", "Number", "00000000", "11", "111111111");

        Assert.Throws<ArgumentNullException>(() => shipping.Phone = null);
        Assert.Throws<ArgumentNullException>(() => shipping.Phone = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Phone = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Phone = new string('x', 12));
        
        Assert.Equal(shipping.Phone, "111111111");
    }
}