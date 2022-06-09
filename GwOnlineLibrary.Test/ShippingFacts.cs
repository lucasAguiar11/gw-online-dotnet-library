﻿using GwOnlineLibrary.Domain;
using GwOnlineLibrary.Domain.Enums;

namespace GwOnlineLibrary.Test;

[Trait("Category", "Domain")]
public class ShippingFacts
{
    [Fact(DisplayName = "Shipping: FirstName validation")]
    public void Verify_Name_Validation()
    {
        var shipping = new Shipping
        {
            FirstName = "Teste"
        };

        Assert.Throws<ArgumentNullException>(() => shipping.FirstName = null);
        Assert.Throws<ArgumentNullException>(() => shipping.FirstName = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.FirstName = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.FirstName = new string('x', 51));
    }

    [Fact(DisplayName = "Shipping: LastName validation")]
    public void Verify_LastName_Validation()
    {
        var shipping = new Shipping
        {
            LastName = "Teste"
        };
        Assert.Throws<ArgumentNullException>(() => shipping.LastName = null);
        Assert.Throws<ArgumentNullException>(() => shipping.LastName = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.LastName = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.LastName = new string('x', 51));
    }

    [Fact(DisplayName = "Shipping: Street validation")]
    public void Verify_Street_Validation()
    {
        var shipping = new Shipping
        {
            Street = "Teste"
        };
        Assert.Throws<ArgumentNullException>(() => shipping.Street = null);
        Assert.Throws<ArgumentNullException>(() => shipping.Street = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Street = new string('x', 2));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Street = new string('x', 51));
    }

    [Fact(DisplayName = "Shipping: Number validation")]
    public void Verify_Number_Validation()
    {
        var shipping = new Shipping
        {
            Number = "1223"
        };
        Assert.Throws<ArgumentNullException>(() => shipping.Number = null);
        Assert.Throws<ArgumentNullException>(() => shipping.Number = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Number = new string('x', 51));
    }

    [Fact(DisplayName = "Shipping: Country validation")]
    public void Verify_Country_Validation()
    {
        var shipping = new Shipping();

        Assert.Equal("Brasil", shipping.Country);
        Assert.Throws<ArgumentNullException>(() => shipping.Country = null);
        Assert.Throws<ArgumentNullException>(() => shipping.Country = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Country = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Country = new string('x', 61));

        shipping.Country = "China";
        Assert.Equal("China", shipping.Country);
    }

    [Fact(DisplayName = "Shipping: ZipCode validation")]
    public void Verify_ZipCode_Validation()
    {
        var shipping = new Shipping
        {
            ZipCode = "00000000"
        };
        Assert.Throws<ArgumentNullException>(() => shipping.ZipCode = null);
        Assert.Throws<ArgumentNullException>(() => shipping.ZipCode = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.ZipCode = new string('x', 7));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.ZipCode = new string('x', 9));

        Assert.Equal("00000000", shipping.ZipCode);
    }

    [Fact(DisplayName = "Shipping: DDD validation")]
    public void Verify_Ddd_Validation()
    {
        var shipping = new Shipping
        {
            Ddd = "11"
        };
        Assert.Throws<ArgumentNullException>(() => shipping.Ddd = null);
        Assert.Throws<ArgumentNullException>(() => shipping.Ddd = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Ddd = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Ddd = new string('x', 3));

        Assert.Equal("11", shipping.Ddd);
    }

    [Fact(DisplayName = "Shipping: Phone validation")]
    public void Verify_Phone_Validation()
    {
        var shipping = new Shipping
        {
            Phone = "111111111"
        };

        Assert.Throws<ArgumentNullException>(() => shipping.Phone = null);
        Assert.Throws<ArgumentNullException>(() => shipping.Phone = "");
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Phone = new string('x', 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => shipping.Phone = new string('x', 12));

        Assert.Equal("111111111", shipping.Phone);
    }

    [Fact(DisplayName = "Shipping: Methods validation")]
    public void Verify_Methods_Validation()
    {
        var shipping = new Shipping();

        Assert.Equal(Methods.Other, shipping.Methods);

        shipping.Methods = Methods.LowCost;
        Assert.Equal(Methods.LowCost, shipping.Methods);
    }
}