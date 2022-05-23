using StoreApi.BLL;
using StoreApi.DAL;
using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreApi.Test.BLL
{
    /// <summary>
    /// Clase para la verificación de la capa de BLL, nos ayuda a verificar que lo que se espera sea lo que el método retorne
    /// </summary>
    public class ProductActionTest
    {
        private readonly IProductActions _productActions;

        //getCatalog
        List<Models.ApiModels.Response.Product> ProductList = new List<Models.ApiModels.Response.Product>();
        ///create
        public StoreApi.Models.ApiModels.Response.Product productCreateReqMock = new StoreApi.Models.ApiModels.Response.Product();
        //update
        public StoreApi.Models.ApiModels.Response.Product productUpdateReqMock = new StoreApi.Models.ApiModels.Response.Product();
        //delete
        bool ProductDeleteMock = true;


        //getCatalog
        Models.ApiModels.Request.FilterCatalog requestGetCatalog = new Models.ApiModels.Request.FilterCatalog();
        ///create
        Models.ApiModels.Request.ProductCreate productCreate = new Models.ApiModels.Request.ProductCreate();
        //update
        Models.ApiModels.Request.ProductUpdate productUpdate = new Models.ApiModels.Request.ProductUpdate();
        int productId = 1;


        public ProductActionTest()
        {
            //Get Catalog
            Models.ApiModels.Response.Product product = new Models.ApiModels.Response.Product()
            {
                Category = "Computer",
                Name = "Computador XP",
                Description = "Computador para uso Personal"
            };
            ProductList.Add(product);

            var productMock = new Mock<IProduct>();

            //Create Product
            productCreateReqMock.Id = 1;
            productCreateReqMock.Name = "Arroz con Leche";
            productCreateReqMock.Description = "Arroz muy delicioso";


            //Create Product
            productUpdateReqMock.Id = 1;
            productUpdateReqMock.Name = "Arroz con Leche";
            productUpdateReqMock.Description = "Arroz muy delicioso";



            productMock.Setup(p => p.GetCatalog(requestGetCatalog)).Returns(ProductList);
            productMock.Setup(p => p.CreateProduct(productCreate)).Returns(productCreateReqMock);
            productMock.Setup(p => p.UpdateProduct(productUpdate, productId)).Returns(productUpdateReqMock);
            productMock.Setup(p => p.DeleteProduct(productId)).Returns(ProductDeleteMock);


            _productActions = new ProductActions(productMock.Object);
        }
        /// <summary>
        /// Test para el método GetCatalog
        /// </summary>
        [Fact]
        public void GetCatalog()
        {
            var actualProductList = _productActions.GetCatalog(requestGetCatalog);
            Assert.Equal(ProductList, actualProductList);
        }
        /// <summary>
        ///  Test para el método CreateProduct
        /// </summary>
        [Fact]
        public void CreateProduct()
        {
            var actualCreateProduct = _productActions.CreateProduct(productCreate);
            Assert.Equal(productCreateReqMock, actualCreateProduct);
        }

        /// <summary>
        ///  Test para el método UpdateProduct
        /// </summary>
        [Fact]
        public void UpdateProduct()
        {
            var actualUpdateProduct = _productActions.UpdateProduct(productUpdate, productId);
            Assert.Equal(productUpdateReqMock, actualUpdateProduct);
        }
        /// <summary>
        ///  Test para el método DeleteProduct
        /// </summary>
        [Fact]
        public void DeleteProduct()
        {
            var actualDeleteProduct = _productActions.DeleteProduct(productId);
            Assert.Equal(ProductDeleteMock, actualDeleteProduct);
        }
    }
}