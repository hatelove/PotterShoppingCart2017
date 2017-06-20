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
            return books.Sum(x => 100);
        }
    }
}