﻿using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCartTests
{
    internal class Cart
    {
        private const int price = 100;

        public Cart()
        {
        }

        public decimal Checkout(IEnumerable<Book> books)
        {
            decimal amount = books.Sum(x => price);
            var discount = GetDiscount(books);

            return amount * discount;
        }

        private static decimal GetDiscount(IEnumerable<Book> books)
        {
            var count = books.Count();
            if (count == 2)
            {
                return 0.95m;
            }
            else if (count == 3)
            {
                return 0.9m;
            }

            return 1;
        }
    }
}