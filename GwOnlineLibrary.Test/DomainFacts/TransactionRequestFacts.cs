using GwOnlineLibrary.Domain;

namespace GwOnlineLibrary.Test.DomainFacts;

[Trait("Category", "Domain")]
public class TransactionRequestFacts
{
    [Fact(DisplayName = "TransactionRequest: Pan validation")]
    public void Verify_Pan_Validation()
    {
        var request = new TransactionRequest()
        {
            Pan = "123123123121"
        };

        Assert.Throws<ArgumentNullException>(() => request.Pan = null);
        Assert.Throws<ArgumentNullException>(() => request.Pan = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => request.Pan = new string('x', 11));
        Assert.Throws<ArgumentOutOfRangeException>(() => request.Pan = new string('x', 20));
    }

    [Fact(DisplayName = "TransactionRequest: CardHolderName validation")]
    public void Verify_CardHolderName_Validation()
    {
        var request = new TransactionRequest()
        {
            CardHolderName = "Teste Teste Teste"
        };

        Assert.Throws<ArgumentNullException>(() => request.Pan = null);
        Assert.Throws<ArgumentNullException>(() => request.Pan = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => request.Pan = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => request.Pan = new string('x', 51));
    }

    [Fact(DisplayName = "TransactionRequest: ExpirationDate validation")]
    public void Verify_ExpirationDate_Validation()
    {
        var request = new TransactionRequest()
        {
            ExpirationDate = "12/20"
        };

        Assert.Throws<ArgumentNullException>(() => request.ExpirationDate = null);
        Assert.Throws<ArgumentNullException>(() => request.ExpirationDate = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => request.ExpirationDate = new string('x', 3));
        Assert.Throws<ArgumentOutOfRangeException>(() => request.ExpirationDate = new string('x', 6));
    }

    [Fact(DisplayName = "TransactionRequest: Cvv validation")]
    public void Verify_Cvv_Validation()
    {
        var request = new TransactionRequest()
        {
            Cvv = "123"
        };

        Assert.Throws<ArgumentOutOfRangeException>(() => request.Cvv = new string('x', 2));
        Assert.Throws<ArgumentOutOfRangeException>(() => request.Cvv = new string('x', 5));
    }

    [Fact(DisplayName = "TransactionRequest: Amount validation")]
    public void Verify_Amount_Validation()
    {
        var request = new TransactionRequest()
        {
            Amount = 0.01m
        };

        Assert.Throws<ArgumentOutOfRangeException>(() => request.Amount = 0);
    }

    [Fact(DisplayName = "TransactionRequest: Installment validation")]
    public void Verify_Installment_Validation()
    {
        var request = new TransactionRequest()
        {
            Installments = 2
        };

        Assert.Throws<ArgumentOutOfRangeException>(() => request.Installments = 0);
        Assert.Throws<ArgumentOutOfRangeException>(() => request.Installments = 19);
    }

    [Fact(DisplayName = "TransactionRequest: Site validation")]
    public void Verify_Site_Validation()
    {
        var request = new TransactionRequest()
        {
            Site = "www.teste.com"
        };

        Assert.Throws<ArgumentNullException>(() => request.ExpirationDate = null);
        Assert.Throws<ArgumentNullException>(() => request.ExpirationDate = "");
    }


    [Fact(DisplayName = "TransactionRequest: Customer validation")]
    public void Verify_Customer_Validation()
    {
        var request = new TransactionRequest()
        {
            Customer = new Customer()
        };

        Assert.Throws<ArgumentNullException>(() => request.Customer = null);
    }


    [Fact(DisplayName = "TransactionRequest: Products validation")]
    public void Verify_Products_Validation()
    {
        var request = new TransactionRequest()
        {
            Products = new List<Product>() { new Product("Teste", 1, 1) }
        };

        Assert.Throws<ArgumentNullException>(() => request.Products = null);
        Assert.Throws<InvalidOperationException>(() => request.Products = new List<Product>());
    }
}