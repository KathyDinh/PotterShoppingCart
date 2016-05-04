using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void Test_Buy_3_Different_Volumes_Will_Cost_270()
        {
            List<Book> Basket = new List<Book>
            {
                new Book {Volume = 1, Price = 100m},
                new Book {Volume = 3, Price = 100m},
                new Book {Volume = 5, Price = 100m}
            };

            var target = new Cashier();
            var actual = target.GetTotalCostOf(Basket);

            var expected = 270m;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_4_Different_Volumes_Will_Cost_320()
        {
            List<Book> Basket = new List<Book>
            {
                new Book {Volume = 1, Price = 100m},
                new Book {Volume = 3, Price = 100m},
                new Book {Volume = 4, Price = 100m},
                new Book {Volume = 5, Price = 100m}
            };

            var target = new Cashier();
            var actual = target.GetTotalCostOf(Basket);

            var expected = 320m;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_5_Different_Volumes_Will_Cost_375()
        {
            List<Book> Basket = new List<Book>
            {
                new Book {Volume = 1, Price = 100m},
                new Book {Volume = 2, Price = 100m},
                new Book {Volume = 3, Price = 100m},
                new Book {Volume = 4, Price = 100m},
                new Book {Volume = 5, Price = 100m}
            };

            var target = new Cashier();
            var actual = target.GetTotalCostOf(Basket);

            var expected = 375m;
            Assert.AreEqual(expected, actual);
        }
    }

    public class Cashier
    {
        public decimal GetTotalCostOf(List<Book> basket)
        {
            var distinctVolumes = basket.Select(x => x.Volume).Distinct();
            var differentVolumeCount = distinctVolumes.Count();
            var discount = GetDiscount(differentVolumeCount);
            return basket.Sum(x => x.Price) * (100 - discount) / 100;
        }

        private int GetDiscount(int differentVolumeCount)
        {
            int discount;
            if (differentVolumeCount == 2)
            {
                discount = 5;
            }
            else if (differentVolumeCount == 3)
            {
                discount = 10;
            }
            else if (differentVolumeCount == 4)
            {
                discount = 20;
            }
            else
            {
                discount = 0;
            }
            return discount;
        }
    }

    public class Book
    {
        public int Volume { get; set; }
        public decimal Price { get; set; }
    }
}