﻿using System;
using System.Collections.Generic;
using System.Linq;
using BillAppDDD.BuildingBlocks.Domain;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Shared.Contracts;

namespace BillAppDDD.Modules.Bills.Domain.Bills
{
    public class Bill : IAggregateRoot, ICreationDate
    {
        private DateTime date;
        private Store store;
        private StoreId storeId;

        private List<Purchase> purchases;
        private MoneyValue sum;

        public BillId Id { get; private set; }
        public ICollection<Purchase> Purchases { get => purchases.AsReadOnly();}
        public DateTime CreationDate { get; set; }

        private Bill()
        {

        }

        public Bill(
            DateTime date,
            Store store,
            List<Purchase> purchases
            )
        {
            Id = new BillId(Guid.NewGuid());
            this.date = date;
            this.store = store;
            this.purchases = purchases;
            CreationDate = DateTime.UtcNow;
            sum = new MoneyValue(0);
        }

        public Bill(
            DateTime date,
            Store store
            )
        {
            Id = new BillId(Guid.NewGuid());
            this.date = date;
            this.store = store;
            purchases = new List<Purchase>();
            CreationDate = DateTime.UtcNow;
            sum = new MoneyValue(0);
        }

        public float GetSum()
        {
            return sum.Value;
        }

        public void AddPurchaseBasedOnExistingProduct(Product product,float amount, float price)
        {
            var cost = price / amount;

            if(product.Price.Value != cost)
                product = product.Update("", null, new MoneyValue(price / amount) ,null);

            purchases.Add(new Purchase(product, this.date, amount, price));

            sum = new MoneyValue(sum.Value + cost);
        }

        public Purchase AddPurchaseBasedOnNewProduct(
            string name,
            string barcode,
            ProductCategory category,
            float amount,
            float price)
        {
            var newPurchase = new Purchase(
                    new Product(
                        name,
                        new ProductBarcode(barcode),
                        new MoneyValue(price / amount),
                        category
                        ),
                    this.date,
                    amount,
                    price
                    );

            purchases.Add(newPurchase);

            sum = new MoneyValue(sum.Value + price);

            return newPurchase;
        }
    }
}
