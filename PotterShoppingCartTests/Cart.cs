using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCartTests
{
    internal class Cart
    {
        public Cart()
        {
        }

        public decimal Checkout(IEnumerable<Book> books)
        {
            decimal amount = books.Sum(x => 100);
            if (books.Count() == 2)
            {
                amount = amount * 0.95m;
            }

            return amount;
        }
    }
}