﻿using BillAppDDD.Modules.Bills.Domain.Bills;
using System;
using System.Collections.Generic;
using Xunit;

namespace BillAppDDD.Modules.Bills.Tests.Bills.BillTests
{

    public class SumTests
    {
        [Fact]
        public void Return_sum_of_cost_of_all_purchases()
        {
            var purchases = new List<Purchase>
            {
                new Purchase(null,new DateTime(),0,10),
                new Purchase(null,new DateTime(),0,15)
            };

            var bill = new BillBuilder()
                .WithPurchases(purchases)
                .Build();

            var summaryCost = bill.GetSum();

            Assert.Equal(25, summaryCost);
        }

    }
}