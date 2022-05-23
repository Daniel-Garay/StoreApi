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
        private readonly IProductActions _productActions;
        List<Models.ApiModels.Response.Product> ProductList = new List<Models.ApiModels.Response.Product>();

        public ProductActionTest()
        {
            Models.ApiModels.Response.Product product = new Models.ApiModels.Response.Product()
            {
                Category = "Computer",
                Name = "Computador XP",
                Description = "Computador para uso Personal"
            };           
            ProductList.Add(product);

            Models.ApiModels.Request.FilterCatalog request = new Models.ApiModels.Request.FilterCatalog();


            var productMock = new Mock<IProduct>();
            productMock.Setup(p => p.GetCatalog(request)).Returns(ProductList);
            _productActions = new ProductActions(productMock.Object);
        }

        [Fact]
        public void GetCatalog()
        {
            Models.ApiModels.Request.FilterCatalog request = new Models.ApiModels.Request.FilterCatalog();
            var actualProductList = _productActions.GetCatalog(request);
            Assert.Equal(ProductList, actualProductList);
        }
       
    }
}
