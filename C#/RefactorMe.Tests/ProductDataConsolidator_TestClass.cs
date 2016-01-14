using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RefactorMe.Tests
{
    [TestClass]
    public class ProductDataConsolidator_TestClass
    {
        [TestMethod]
        public void GetAllProducts()
        {
            var productDataBuilderMock = new Mock<IProductDataBuilder>();
            var data = PopulateData();
            productDataBuilderMock.Setup(x => x.GetProductList())
                .Returns(data);

            var consolidator = new ProductDataConsolidator(productDataBuilderMock.Object);

            var allProducts = consolidator.Get();
            Assert.AreEqual(3, allProducts.Count);
            productDataBuilderMock.Verify(x => x.GetProductList(), Times.Once);
            CheckAsserts(allProducts, data);
        }

        [TestMethod]
        public void GetAllProductsInUSD()
        {
            var productDataBuilderMock = new Mock<IProductDataBuilder>();
            var data = PopulateData();
            productDataBuilderMock.Setup(x => x.GetProductList())
                .Returns(data);

            var consolidator = new ProductDataConsolidator(productDataBuilderMock.Object);

            var allProducts = consolidator.GetInUSDollars();
            Assert.AreEqual(3, allProducts.Count);
            productDataBuilderMock.Verify(x => x.GetProductList(), Times.Once);
            CheckAsserts(allProducts, data, .76);
        }

        [TestMethod]
        public void GetAllProductsInEuros()
        {
            var productDataBuilderMock = new Mock<IProductDataBuilder>();
            var data = PopulateData();
            productDataBuilderMock.Setup(x => x.GetProductList())
                .Returns(data);

            var consolidator = new ProductDataConsolidator(productDataBuilderMock.Object);

            var allProducts = consolidator.GetInEuros();
            Assert.AreEqual(3, allProducts.Count);
            productDataBuilderMock.Verify(x => x.GetProductList(), Times.Once);
            CheckAsserts(allProducts, data, .67);
        }



        private void CheckAsserts(List<Product> allProducts, ProductData data, double currencyRate = 1)
        {
            Assert.AreEqual(allProducts[0].Id, data.LawnMowers.First().Id);
            Assert.AreEqual(allProducts[0].Name, data.LawnMowers.First().Name);
            Assert.AreEqual(allProducts[0].Price, data.LawnMowers.First().Price * currencyRate);
            Assert.AreEqual(allProducts[0].Type, "Lawnmower");

            Assert.AreEqual(allProducts[1].Id, data.PhoneCases.First().Id);
            Assert.AreEqual(allProducts[1].Name, data.PhoneCases.First().Name);
            Assert.AreEqual(allProducts[1].Price, data.PhoneCases.First().Price * currencyRate);
            Assert.AreEqual(allProducts[1].Type, "Phone Case");

            Assert.AreEqual(allProducts[2].Id, data.TShirts.First().Id);
            Assert.AreEqual(allProducts[2].Name, data.TShirts.First().Name);
            Assert.AreEqual(allProducts[2].Price, data.TShirts.First().Price * currencyRate);
            Assert.AreEqual(allProducts[2].Type, "T-Shirt");

        }

        private ProductData PopulateData()
        {
            return new ProductData
            {
                LawnMowers = new List<Lawnmower>
                    {
                        new Lawnmower {
                            Id = Guid.NewGuid(),
                            IsVehicle = true,
                            FuelEfficiency = "a",
                            Name = "LM1",
                            Price = 20 }
                    }.AsQueryable(),
                TShirts = new List<TShirt>
                    {
                        new TShirt {
                            Id = Guid.NewGuid(),
                            Name = "LM1",
                            Price = 30,
                        Colour = "Red",
                        ShirtText = "Me"
                        }
                    }.AsQueryable(),
                PhoneCases = new List<PhoneCase>
                    {
                        new PhoneCase {
                            Id = Guid.NewGuid(),
                            Name = "LM1",
                            Price = 40,
                        Colour = "Red",
                        Material = "Cloth",
                        TargetPhone = "Samsung"
                        }
                    }.AsQueryable()
            };
        }
    }
}
