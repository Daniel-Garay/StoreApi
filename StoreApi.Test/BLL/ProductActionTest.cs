using StoreApi.BLL;
using StoreApi.DAL;
using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreApi.Test.BLL
{
    public class ProductActionTest
    {
       /* private readonly IProductActions _productActions;
        List<Models.ApiModels.Request.Product> ProductList = new List<Models.ApiModels.Request.Product>();

        public ProductActionTest()
        {
            Models.ApiModels.Response.Product product = new Models.ApiModels.Response.Product()
            {
                Category = "Computer",
                Name = "Computador XP",
                Description = "Computador para uso Personal"
            };

            Models.ApiModels.Response.FilterCatalog request = new Models.ApiModels.Response.FilterCatalog();

            ProductList.Add(product);

            var productMock = new Mock<IProduct>();
            productMock.Setup(p => p.GetCatalog(request)).Returns(Task.FromResult(ProductList));
            _productActions = new ProductActions(productMock.Object);
        }

        [Fact]
        public void GetCatalog()
        {
            Models.ApiModels.Response.FilterCatalog request = new Models.ApiModels.Response.FilterCatalog();
            var actualProductList = _productActions.GetCatalog(request).Result;
            Assert.Equal(ProductList, actualProductList);
        }
       */
    }
}
