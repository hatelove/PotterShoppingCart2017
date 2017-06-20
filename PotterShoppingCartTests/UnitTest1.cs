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
            CheckoutAmountShouldBe(0, books);
        }

        private static void CheckoutAmountShouldBe(decimal expected, List<Book> books)
        {
            var target = new Cart();

            decimal actual = target.Checkout(books);

            Assert.AreEqual(expected, actual);
        }
    }
}
