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
            var suites = GetSuites(books);

            var fiveBooksOfSuite = suites.Where(x => x.Value.Count() == 5).ToList();

            var threeBooksOfSuite = suites.Where(x => x.Value.Count() == 3).ToList();


            var threeAndFivePairs = fiveBooksOfSuite.Zip(threeBooksOfSuite, (five, three) =>
            {
                return new { five, three };
            });

            decimal chooseCheaperDiscountTotal = 0;
            foreach (var threeAndFivePair in threeAndFivePairs)
            {
                chooseCheaperDiscountTotal += 640;
                suites.Remove(threeAndFivePair.five.Key);
                suites.Remove(threeAndFivePair.three.Key);
            }

            return chooseCheaperDiscountTotal + suites.Sum(s => AmountOfEachSuite(s.Value));
        }

        private Dictionary<int, IEnumerable<Book>> GetSuites(IEnumerable<Book> books)
        {
            var index = 0;
            var result = new Dictionary<int, IEnumerable<Book>>();

            var unCheckedoutBooks = books;

            while (unCheckedoutBooks.Any())
            {
                var suite = unCheckedoutBooks.GroupBy(b => b.ISBN).Select(x => x.First());
                result.Add(index, suite);
                unCheckedoutBooks = unCheckedoutBooks.Except(suite);
                index++;
            }

            return result;
        }

        private decimal AmountOfEachSuite(IEnumerable<Book> suiteOfBooks)
        {
            decimal amount = suiteOfBooks.Sum(x => price);
            var discount = GetSuiteDiscount(suiteOfBooks);

            return amount * discount;
        }

        private decimal GetSuiteDiscount(IEnumerable<Book> books)
        {
            var count = books.Count();
            return this._discount[count];
        }
    }

    internal class BooksComparer : IEqualityComparer<IEnumerable<Book>>
    {
        public bool Equals(IEnumerable<Book> x, IEnumerable<Book> y)
        {
            throw new System.NotImplementedException();
        }

        public int GetHashCode(IEnumerable<Book> obj)
        {
            throw new System.NotImplementedException();
        }
    }
}