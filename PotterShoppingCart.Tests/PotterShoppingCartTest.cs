using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class PotterShoppingCartTest
    {
        private List<Book> _BookSeries = new List<Book>
        {
            new Book{ Volume = 1, Price = 100m},
            new Book{ Volume = 2, Price = 100m},
            new Book{ Volume = 3, Price = 100m},
            new Book{ Volume = 4, Price = 100m},
            new Book{ Volume = 5, Price = 100m}
        };

        [TestMethod]
        public void Test_Buy_2_Different_Volumes_Will_Cost_190()
        {
            List<Book> Basket = new List<Book>
            {
                new Book {Volume = 3, Price = 100m},
                new Book {Volume = 5, Price = 100m}
            };

            var target = new Cashier();
            var actual = target.GetTotalCostOf(Basket);

            var expected = 190m;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_2_Copies_Of_Same_Volume_Will_Cost_200()
        {

            List<Book> Basket = new List<Book>
            {
                new Book {Volume = 3, Price = 100m},
                new Book {Volume = 3, Price = 100m}
            };

            var target = new Cashier();
            var actual = target.GetTotalCostOf(Basket);

            var expected = 200m;
            Assert.AreEqual(expected, actual);
        }
    }

    public class Cashier
    {
        public decimal GetTotalCostOf(List<Book> basket)
        {
            return basket.Sum(x => x.Price)*(100 - 5) / 100;
        }
    }

    public class Book
    {
        public int Volume { get; set; }
        public decimal Price { get; set; }
    }
}
