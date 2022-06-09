using GwOnlineLibrary.Domain;

namespace GwOnlineLibrary.Test;

[Trait("Category", "Domain")]
public class CustomerFacts
{
    [Fact(DisplayName = "Customer: Name validation")]
    public void Verify_Name_Validation()
    {
        var customer = new Customer()
        {
            Name = "Teste"
        };

        Assert.Throws<ArgumentNullException>(() => customer.Name = null);
        Assert.Throws<ArgumentNullException>(() => customer.Name = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => customer.Name = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => customer.Name = new string('x', 51));
    }

    [Fact(DisplayName = "Customer: Ddd validation")]
    public void Verify_Ddd_Validation()
    {
        var customer = new Customer()
        {
            Ddd = "11"
        };

        Assert.Throws<ArgumentNullException>(() => customer.Ddd = null);
        Assert.Throws<ArgumentNullException>(() => customer.Ddd = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => customer.Ddd = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => customer.Ddd = new string('x', 3));
    }

    [Fact(DisplayName = "Customer: Phone validation")]
    public void Verify_Customer_Validation()
    {
        var customer = new Customer()
        {
            Phone = "123123123"
        };

        Assert.Throws<ArgumentNullException>(() => customer.Phone = null);
        Assert.Throws<ArgumentNullException>(() => customer.Phone = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => customer.Phone = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => customer.Phone = new string('x', 12));
    }

    [Fact(DisplayName = "Customer: Email validation")]
    public void Verify_Email_Validation()
    {
        var customer = new Customer()
        {
            Email = "l@g.com"
        };

        Assert.Throws<ArgumentNullException>(() => customer.Email = null);
        Assert.Throws<ArgumentNullException>(() => customer.Email = "");
        Assert.Throws<ArgumentException>(() => customer.Email = "teste");
    }

    [Fact(DisplayName = "Customer: Ip validation")]
    public void Verify_Ip_Validation()
    {
        var customer = new Customer()
        {
            Ip = "123.123.123.123"
        };

        Assert.Throws<ArgumentNullException>(() => customer.Ip = null);
        Assert.Throws<ArgumentNullException>(() => customer.Ip = "");
        Assert.Throws<ArgumentException>(() => customer.Ip = "teste");
    }
}