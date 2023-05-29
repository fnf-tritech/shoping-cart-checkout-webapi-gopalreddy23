using NUnit.Framework;
using Xunit;
using WebApplication4.Controllers;

namespace WebApplication4.Controllers
{
    public class CheckoutTests
    {
        [Fact]
        public void Test_EmptyCart_ReturnsZero()
        {
            // Arrange
            var checkout = new CheckoutController();
            string items = ".";

            // Act
            int totalPrice = checkout.CalculateTotalPrice(items);

            // Assert
            Assert.Equals(0, totalPrice);
        }

        [Fact]
        public void Test_SingleItem_ReturnsCorrectPrice()
        {
            // Arrange
            var checkout = new CheckoutController();
            string items = "A";

            // Act
            int totalPrice = checkout.CalculateTotalPrice(items);

            // Assert
            Assert.Equals(50, totalPrice);
        }

        [Fact]
        public void Test_MultipleItems_ReturnsCorrectPrice()
        {
            // Arrange
            var checkout = new CheckoutController();
            string items = "AB";

            // Act
            int totalPrice = checkout.CalculateTotalPrice(items);

            // Assert
            Assert.Equals(80, totalPrice);
        }
        [Fact]
        public void Test_DifferentItems_ReturnsCorrectPrice()
        {
            // Arrange
            var checkout = new CheckoutController();
            string items = "AABCD";

            // Act
            int totalPrice = checkout.CalculateTotalPrice(items);

            // Assert
            Assert.Equals(165, totalPrice);
        }
        [Fact]
        public void Test_DifferentItems_ReturnsCorrectPrice()
        {
            // Arrange
            var checkout = new CheckoutController();
            string items = "AAAAD";

            // Act
            int totalPrice = checkout.CalculateTotalPrice(items);

            // Assert
            Assert.Equals(195, totalPrice);
        }


    }
}
