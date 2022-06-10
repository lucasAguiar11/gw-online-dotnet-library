using System.Text.Json;
using GwOnlineLibrary.Domain;
using GwOnlineLibrary.Domain.Enums;
using GwOnlineLibrary.Utilities;
using Xunit.Abstractions;

namespace GwOnlineLibrary.Test;

[Trait("Category", "Transaction")]
public class SaleFacts
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _user = "133195";
    private readonly string _pass = "A5AF0F05-F106-4915-8CA9-F990E1183F09";

    public SaleFacts(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact(DisplayName = "Sale: constructor")]
    public void Verify_Constructor()
    {
        Assert.Throws<ArgumentNullException>(() => new GwOnline("", "", true));
    }

    [Fact(DisplayName = "Sale: transaction validation")]
    public async Task Verify_Sale_Validation()
    {
        var gw = new GwOnline(_user, _pass, true);
        var request = new TransactionRequest();

        await Assert.ThrowsAsync<ArgumentNullException>(() => gw.SaleAsync(null));
        await Assert.ThrowsAsync<ArgumentNullException>(() => gw.SaleAsync(request));
    }

    [Fact(DisplayName = "Sale: transaction call")]
    public async Task Verify_Sale_Call()
    {
        var gw = new GwOnline(_user, _pass, true);
        var request = new TransactionRequest()
        {
            Pan = "123123123121",
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

        var result = await gw.SaleAsync(request);
        _testOutputHelper.WriteLine("Response Sale {0}", JsonSerializer.Serialize(result));
    }
}