﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmBL.Model
{
    public class ShopComputerModel
    {
        Generator generator = new Generator();
        Random rnd = new Random();
        public List<CashDesk> CashDesks { get; set; } = new List<CashDesk>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();
        public ShopComputerModel()
        {
            var sellers = generator.GetNewSellers(20);
            generator.GetNewProducts(1000);
            generator.GetNewCustomers(100);
            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }
            for (int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }
        public void Start()
        {
            var customers = generator.GetNewCustomers(10);
            var carts = new Queue<Cart>();
            foreach (var customer in customers)
            {
                var cart = new Cart(customer);
                foreach (var product in generator.GetRandomProducts(10, 30))
                {
                    cart.Add(product);
                }
                carts.Enqueue(cart);
            }
            while (carts.Count > 0)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                cash.Enqueue(carts.Dequeue());
            }
            var counter = 0;
            while (counter < 100) //TODO :
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                var money = cash.Dequeue();
                counter++;
            }
        }
    }
}
