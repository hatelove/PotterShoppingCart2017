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
            return Calculate(books, 0);
        }

        private decimal Calculate(IEnumerable<Book> books, decimal amount)
        {
            if (!books.Any())
            {
                return amount;
            }

            var groupBooksByIsbn = books.GroupBy(b => b.ISBN);

            var suite = groupBooksByIsbn.Select(x => x.First());
            var totalAmount = amount + AmountOfEachSuite(suite);
            var unSuiteBooks = books.Except(suite);
            return Calculate(unSuiteBooks, totalAmount);
        }

        private decimal AmountOfEachSuite(IEnumerable<Book> books)
        {
            decimal amount = books.Sum(x => price);
            var discount = GetDiscount(books);

            amount = amount * discount;
            return amount;
        }

        private decimal GetDiscount(IEnumerable<Book> books)
        {
            var count = books.Count();
            return this._discount[count];
        }
    }
}