using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class PotterShoppingCartTest
    {
        [TestMethod]
        public void Test_Buy_2_Different_Books_Will_Cost_190()
        {
            List<Book> BookSeries = new List<Book>
            {
                new Book{ Number = 1, Price = 100m},
                new Book{ Number = 2, Price = 100m},
                new Book{ Number = 3, Price = 100m},
                new Book{ Number = 4, Price = 100m},
                new Book{ Number = 5, Price = 100m}
            };

            List<Book> Basket = new List<Book>
            {
                new Book {Number = 3, Price = 100m},
                new Book {Number = 5, Price = 100m}
            };

            var target = new Cashier();
            var actual = target.GetTotalCostOf(Basket);

            var expected = 190;
            Assert.AreEqual(expected, actual);
        }
    }

    public class Cashier
    {
        public decimal GetTotalCostOf(List<Book> basket)
        {
            throw new NotImplementedException();
        }
    }

    public class Book
    {
        public int Number { get; set; }
        public decimal Price { get; set; }
    }
}
