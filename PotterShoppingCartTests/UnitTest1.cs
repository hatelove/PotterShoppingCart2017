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

        [TestMethod]
        public void CheckoutTest_1_book_amount_should_be_100()
        {
            var books = new List<Book> { new Book { ISBN = "1" } };
            CheckoutAmountShouldBe(100, books);
        }

        [TestMethod]
        public void CheckoutTest_2_different_books_amount_should_be_190()
        {
            var books = new List<Book>()
            {
                new Book() { ISBN = "1"},
                new Book() { ISBN = "2" },
            };

            CheckoutAmountShouldBe(190, books);
        }

        [TestMethod]
        public void CheckoutTest_3_differnet_books_amount_should_be_270()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
            };

            CheckoutAmountShouldBe(270, books);
        }

        private static void CheckoutAmountShouldBe(decimal expected, List<Book> books)
        {
            var target = new Cart();

            decimal actual = target.Checkout(books);

            Assert.AreEqual(expected, actual);
        }
    }
}
