using GwOnlineLibrary.Domain;

namespace GwOnlineLibrary.Test;

[Trait("Category", "Domain")]
public class BillingFacts
{
    [Fact(DisplayName = "Billing: Street validation")]
    public void Verify_Street_Validation()
    {
        var billing = new Billing("street", "number", "neighborhood", "city", "SP", "00000000");

        Assert.Throws<ArgumentNullException>(() => billing.Street = null);
        Assert.Throws<ArgumentNullException>(() => billing.Street = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.Street = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.Street = new string('x', 51));

        billing.Street = "street";
        Assert.Equal("street", billing.Street);
    }

    [Fact(DisplayName = "Billing: Number validation")]
    public void Verify_Number_Validation()
    {
        var billing = new Billing("street", "number", "neighborhood", "city", "SP", "00000000");

        Assert.Throws<ArgumentNullException>(() => billing.Number = null);
        Assert.Throws<ArgumentNullException>(() => billing.Number = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.Number = new string('x', 51));

        billing.Number = "number";
        Assert.Equal("number", billing.Number);
    }

    [Fact(DisplayName = "Billing: Neighborhood validation")]
    public void Verify_Neighborhood_Validation()
    {
        var billing = new Billing("street", "number", "neighborhood", "city", "SP", "00000000");

        Assert.Throws<ArgumentNullException>(() => billing.Neighborhood = null);
        Assert.Throws<ArgumentNullException>(() => billing.Neighborhood = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.Street = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.Neighborhood = new string('x', 51));

        billing.Neighborhood = "neighborhood";
        Assert.Equal("neighborhood", billing.Neighborhood);
    }

    [Fact(DisplayName = "Billing: City validation")]
    public void Verify_City_Validation()
    {
        var billing = new Billing("street", "number", "neighborhood", "city", "SP", "00000000");

        Assert.Throws<ArgumentNullException>(() => billing.City = null);
        Assert.Throws<ArgumentNullException>(() => billing.City = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.City = new string('x', 61));

        billing.City = "city";
        Assert.Equal("city", billing.City);
    }

    [Fact(DisplayName = "Billing: State validation")]
    public void Verify_State_Validation()
    {
        var billing = new Billing("street", "number", "neighborhood", "city", "SP", "00000000");

        Assert.Throws<ArgumentNullException>(() => billing.State = null);
        Assert.Throws<ArgumentNullException>(() => billing.State = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.State = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.State = new string('x', 3));

        billing.State = "SP";
        Assert.Equal("SP", billing.State);
    }

    [Fact(DisplayName = "Billing: Country validation")]
    public void Verify_Country_Validation()
    {
        var billing = new Billing("street", "number", "neighborhood", "city", "SP", "00000000");

        Assert.Equal("Brasil", billing.Country);

        Assert.Throws<ArgumentNullException>(() => billing.Country = null);
        Assert.Throws<ArgumentNullException>(() => billing.Country = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.Country = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.Country = new string('x', 61));

        billing.Country = "country";
        Assert.Equal("country", billing.Country);

        billing.Country = "China";
        Assert.Equal("China", billing.Country);
    }

    [Fact(DisplayName = "Billing: ZipCode validation")]
    public void Verify_ZipCode_Validation()
    {
        var billing = new Billing("street", "number", "neighborhood", "city", "SP", "00000000");

        Assert.Throws<ArgumentNullException>(() => billing.ZipCode = null);
        Assert.Throws<ArgumentNullException>(() => billing.ZipCode = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.ZipCode = new string('x', 7));
        Assert.Throws<ArgumentOutOfRangeException>(() => billing.ZipCode = new string('x', 9));

        Assert.Equal("00000000", billing.ZipCode);
    }
}