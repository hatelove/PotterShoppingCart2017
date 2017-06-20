using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCartTests
{
    internal class Cart
    {
        private const int price = 100;

        private Dictionary<int, decimal> _discount = new Dictionary<int, decimal>()
        {
            {0, 0},
            {1, 1},
            {2, 0.95m},
            {3, 0.9m},
            {4, 0.8m },
            {5, 0.75m },
        };

        public Cart()
        {
        }

        public decimal Checkout(IEnumerable<Book> books)
        {
            decimal amount = books.Sum(x => price);
            var discount = GetDiscount(books);

            return amount * discount;
        }

        private decimal GetDiscount(IEnumerable<Book> books)
        {
            var count = books.Count();
            return this._discount[count];
        }
    }
}