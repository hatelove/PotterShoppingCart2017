using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCartTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void CheckoutTest_0_books_amount_should_be_0()
        {
            var books = new List<Book>();
            var target = new Cart();

            decimal actual = target.Checkout(books);

            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}
