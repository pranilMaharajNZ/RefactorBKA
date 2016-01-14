using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMe.DontRefactor.Models;
using RefactorMe.DontRefactor.Data;
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RefactorMe.Tests
{
    [TestClass]
    public class ProductDataBuilder_TestClass
    {
        [TestMethod]
        public void GetProductList_CheckPropertiesPopulated()
        {
            var lawnMowerData = LawnMowerData();
            var tShirtData = TShirtData();
            var phoneCaseData = PhoneCaseData();

            var lawnMowerRepoMock = new
                Mock<IReadOnlyRepository<Lawnmower>>();
            lawnMowerRepoMock.Setup(x => x.GetAll())
                .Returns(lawnMowerData);
            var phoneCaseRepoMock = new
                Mock<IReadOnlyRepository<PhoneCase>>();
            phoneCaseRepoMock.Setup(x => x.GetAll())
                .Returns(phoneCaseData);
            var tShirtRepoMock = new
                Mock<IReadOnlyRepository<TShirt>>();
            tShirtRepoMock.Setup(x => x.GetAll())
                .Returns(tShirtData);

            var builder = new ProductDataBuilder(lawnMowerRepoMock.Object,
                phoneCaseRepoMock.Object, tShirtRepoMock.Object);

            var productList = builder.GetProductList();

            Assert.AreEqual(2, productList.LawnMowers.Count());
            Assert.AreEqual(1, productList.PhoneCases.Count());
            Assert.AreEqual(1, productList.TShirts.Count());
        }

        private IQueryable<TShirt> TShirtData()
        {
            return new List<TShirt>
            {
                new TShirt
                {
                    Colour = "Red",
                    Id = Guid.NewGuid(),
                    Name = "NoName",
                    Price = 20,
                    ShirtText = "Mytext"
                }
            }.AsQueryable();
        }

        private IQueryable<PhoneCase> PhoneCaseData()
        {
            return new List<PhoneCase>
            {
                new PhoneCase
                {
                    Colour = "Red",
                    Id = Guid.NewGuid(),
                    Name = "NoName",
                    Price = 20,
                    Material = "Plastic",
                    TargetPhone = "Samsung"
                }
            }.AsQueryable();
        }

        private IQueryable<Lawnmower> LawnMowerData()
        {
            return new List<Lawnmower>
            {
                new Lawnmower
                {
                    Id = Guid.NewGuid(),
                    Name = "NoName",
                    Price = 20,
                    FuelEfficiency = "A",
                    IsVehicle = false
                },
                                new Lawnmower
                {
                    Id = Guid.NewGuid(),
                    Name = "NoName2",
                    Price = 20,
                    FuelEfficiency = "A",
                    IsVehicle = false
                }
            }.AsQueryable();
        }
    }
}
