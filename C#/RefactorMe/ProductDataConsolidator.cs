using RefactorMe.DontRefactor.Models;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe
{
    public class ProductDataConsolidator
    {
        private IProductDataBuilder _productBuilder;

        public ProductDataConsolidator(IProductDataBuilder productBuilder
            )
        {
            _productBuilder = productBuilder;
        }

        public List<Product> Get() {
            var productData = _productBuilder.GetProductList();

            var productList = new List<Product>();

            AddLawnMowersToProductList(productList, productData.LawnMowers);
            AddPhoneCasesToProductList(productList, productData.PhoneCases);
            AddTShirtsToProductList(productList, productData.TShirts);

            return productList;
        }

        public List<Product> GetInUSDollars()
        {
            var productData = _productBuilder.GetProductList();

            var productList = new List<Product>();

            AddLawnMowersToProductList(productList, productData.LawnMowers, 0.76);
            AddPhoneCasesToProductList(productList, productData.PhoneCases, 0.76);
            AddTShirtsToProductList(productList, productData.TShirts, 0.76);

            return productList;
        }

        public List<Product> GetInEuros()
        {
            var productData = _productBuilder.GetProductList();

            var productList = new List<Product>();

            AddLawnMowersToProductList(productList, productData.LawnMowers, 0.67);
            AddPhoneCasesToProductList(productList, productData.PhoneCases, 0.67);
            AddTShirtsToProductList(productList, productData.TShirts, 0.67);

            return productList;
        }

        private static void AddLawnMowersToProductList(List<Product> productList,
        IQueryable<Lawnmower> lawnMowers, double exchangeRate = 1)
        {
            foreach (var lawnMower in lawnMowers)
            {
                productList.Add(new Product()
                {
                    Id = lawnMower.Id,
                    Name = lawnMower.Name,
                    Price = lawnMower.Price * exchangeRate,
                    Type = "Lawnmower"
                });
            }
        }

        private static void AddPhoneCasesToProductList(List<Product> productList, 
            IQueryable<PhoneCase> phoneCases, double exchangeRate = 1)
    {
        foreach (var phoneCase in phoneCases)
        {
                productList.Add(new Product()
            {
                Id = phoneCase.Id,
                Name = phoneCase.Name,
                Price = phoneCase.Price * exchangeRate,
                Type = "Phone Case"
            });
        }
    }

        private static void AddTShirtsToProductList(List<Product> productList, 
            IQueryable<TShirt> tShirts, double exchangeRate = 1)
        {
            foreach (var tShirt in tShirts)
            {
                productList.Add(new Product()
                {
                    Id = tShirt.Id,
                    Name = tShirt.Name,
                    Price = tShirt.Price * exchangeRate,
                    Type = "T-Shirt"
                });
            }
        } 
    }
}
