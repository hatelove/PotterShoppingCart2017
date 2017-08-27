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

        public decimal Checkout(IEnumerable<Book> books)
        {
            var suites = GetSuites(books);
            return suites.Sum(s => AmountOfEachSuite(s.Value));
        }

        private Dictionary<int, List<Book>> GetSuites(IEnumerable<Book> books)
        {
            var suites = GetSuitesByDefault(books);

            Convert3And5PairTo4And4Pair(suites);

            return suites;
        }

        private static Dictionary<int, List<Book>> GetSuitesByDefault(IEnumerable<Book> books)
        {
            var index = 0;
            var result = new Dictionary<int, List<Book>>();

            var unCheckedoutBooks = books;

            while (unCheckedoutBooks.Any())
            {
                var suite = unCheckedoutBooks.GroupBy(b => b.ISBN).Select(x => x.First()).ToList();
                result.Add(index, suite);

                unCheckedoutBooks = unCheckedoutBooks.Except(suite);
                index++;
            }

            return result;
        }

        private static void Convert3And5PairTo4And4Pair(Dictionary<int, List<Book>> suites)
        {
            var fiveBooksOfSuite = suites.Where(x => x.Value.Count() == 5).ToList();

            var threeBooksOfSuite = suites.Where(x => x.Value.Count() == 3).ToList();

            var threeAndFivePairs = fiveBooksOfSuite.Zip(threeBooksOfSuite, (five, three) => new { five, three });

            foreach (var pair in threeAndFivePairs)
            {
                var firstDiffBetween3And5 = pair.five.Value.Except(pair.three.Value).First();
                suites[pair.five.Key].Remove(firstDiffBetween3And5);
                suites[pair.three.Key].Add(firstDiffBetween3And5);
            }
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
}