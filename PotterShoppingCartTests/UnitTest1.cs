using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

        [TestMethod]
        public void CheckoutTest_4_diff_books_amount_should_be_320()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "4"},
            };

            CheckoutAmountShouldBe(320, books);
        }

        [TestMethod]
        public void CheckoutTest_5_diff_books_amount_should_be_375()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "4"},
                new Book() {ISBN = "5"},
            };

            CheckoutAmountShouldBe(375, books);
        }

        [TestMethod]
        public void CheckoutTest_buy_first_1_book_second_1_book_third_2_book_amount_should_be_370()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "3"},
            };

            CheckoutAmountShouldBe(370, books);
        }

        [TestMethod]
        public void CheckoutTest_buy_first_1_book_second_2_book_third_2_book_amount_should_be_460()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "3"},
            };

            CheckoutAmountShouldBe(460, books);
        }

        [TestMethod]
        public void CheckoutTest_BooksOfSuite_has_5_and_3_should_consolidate_to_4_and_4()
        {
            var books = new List<Book>
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "4"},
                new Book() {ISBN = "5"},
            };

            CheckoutAmountShouldBe(640, books);
        }

        private static void CheckoutAmountShouldBe(decimal expected, List<Book> books)
        {
            var target = new Cart();

            decimal actual = target.Checkout(books);

            Assert.AreEqual(expected, actual);
        }
    }
}