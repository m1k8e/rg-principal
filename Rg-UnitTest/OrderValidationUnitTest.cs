using Rg_Business;
using Rg_Business.Interfaces;
using Rg_Domain.Models;

namespace Rg_UnitTest
{
    public class OrderValidationUnitTest
    {
        private IOrderValidation orderValidation;

        private readonly Product fries = new Product() { ProductId = 5, Price = 100, ProductName = "MyFries", Type = 2 };
        private readonly Product soda = new Product() { ProductId = 6, Price = 100, ProductName = "Pepsi", Type = 3 };

        [Fact]
        public void ReturnDiscount_WhenProductsHasFries_ThenReturns10()
        {
            //Arrange
            orderValidation = new OrderValidation();
            var products = new List<Product>()
            {
                fries,
            };

            //Act
            var discount = orderValidation.ReturnDiscount(products);

            //Assert
            Assert.Equal(10, discount);
        }

        [Fact]
        public void ReturnDiscount_WhenProductsHasFriesAndSoda_ThenReturns20()
        {
            //Arrange
            orderValidation = new OrderValidation();
            var products = new List<Product>()
            {
                fries,
                soda
            };

            //Act
            var discount = orderValidation.ReturnDiscount(products);

            //Assert
            Assert.Equal(20, discount);
        }

        [Fact]
        public void ReturnDiscount_WhenProductsHasSoda_ThenReturns15()
        {
            //Arrange
            orderValidation = new OrderValidation();
            var products = new List<Product>()
            {
                soda
            };

            //Act
            var discount = orderValidation.ReturnDiscount(products);

            //Assert
            Assert.Equal(15, discount);
        }
    }
}