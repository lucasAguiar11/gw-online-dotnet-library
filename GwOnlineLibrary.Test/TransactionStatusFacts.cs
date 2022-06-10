using System.Text.Json;
using GwOnlineLibrary.Domain;
using GwOnlineLibrary.Domain.Enums;
using Xunit.Abstractions;

namespace GwOnlineLibrary.Test;

[Trait("Category", "Transaction")]
public class TransactionStatusFacts
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _user = "133195";
    private readonly string _pass = "A5AF0F05-F106-4915-8CA9-F990E1183F09";

    public TransactionStatusFacts(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact(DisplayName = "Status: transaction status success")]
    public async Task TransactionStatus_Verify_Success()
    {
        var gw = new GwOnline(_user, _pass, true);
        var result = await gw.TransactionStatusAsync("16548846062971171");
        _testOutputHelper.WriteLine("transaction status {0}", JsonSerializer.Serialize(result));
        Assert.True(result.Status);
    }

    [Fact(DisplayName = "Status: transaction status err")]
    public async Task TransactionStatus_Without_Parameter()
    {
        var gw = new GwOnline(_user, _pass, true);
        await Assert.ThrowsAsync<ArgumentNullException>(() => gw.TransactionStatusAsync(null));
    }

    [Fact(DisplayName = "Status: new transaction status")]
    public async Task TransactionStatus_Verify_New_Transaction()
    {
        var gw = new GwOnline(_user, _pass, true);
        var request = new TransactionRequest()
        {
            Pan = "5313267307199790",
            CardHolderName = "Lucas A C Abreu",
            Amount = 1.0m,
            Brand = Brand.MASTERCARD,
            Cvv = "123",
            Date = DateTime.Now,
            Installments = 2,
            Site = "SPLITONLINE",
            CvvStatus = CvvStatus.E,
            ExpirationDate = "11/30",
            PaymentType = PaymentType.V,
            Customer = new Customer()
            {
                FingerPrint = Guid.NewGuid().ToString(),
                Ddd = "11",
                Phone = "946830885",
                Email = "l@g.com",
                Document = "48903772806",
                Ip = "123.123.123.123",
                BirthDate = new DateTime(1999, 11, 11),
                Name = "Teste",
                Billing = new Billing()
                {
                    City = "Cotia",
                    Neighborhood = "Rio Cotia",
                    Number = "305",
                    State = "SP",
                    Street = "Rua Teste",
                    ZipCode = "06715825"
                },
                Shipping = new Shipping()
                {
                    FirstName = "Lucas",
                    LastName = "Aguiar",
                    Ddd = "11",
                    Phone = "946830885",
                    Methods = Methods.Other,
                    Number = "12312",
                    Street = "Rua Teste",
                    ZipCode = "06715825",
                    State = "SP",
                    Neighborhood = "Rio Cotia",
                }
            },
            Products = new List<Product>()
            {
                new Product("Teste")
            }
        };

        var transactionResult = await gw.SaleAsync(request);
        _testOutputHelper.WriteLine("new transaction => {0}", JsonSerializer.Serialize(transactionResult));

        var result = await gw.TransactionStatusAsync(transactionResult.Tid);
        _testOutputHelper.WriteLine("status transaction ({0}) => {1}", transactionResult.Tid,
            JsonSerializer.Serialize(result));
        Assert.True(result.Status);
    }
}