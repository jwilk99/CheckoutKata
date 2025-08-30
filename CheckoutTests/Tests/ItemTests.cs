using CheckoutKata.Class;
using CheckoutKata;

namespace CheckoutTests.Tests
{
    public class ItemTests
    {
        [Fact]
        public void NewItemNoSpecialPrice_ShouldCreate()
        {
            var item = new Item("A", 50);
            Assert.NotNull(item);
            Assert.Equal("A", item.Sku);
            Assert.Equal(50, item.UnitPrice);
        }

        [Fact]
        public void NewItemWithSpecialPrice_ShouldCreate()
        {
            var item = new Item("A", 50, new SpecialPrice(3, 130));

            Assert.NotNull(item);
            Assert.Equal("A", item.Sku);
            Assert.Equal(50, item.UnitPrice);

            Assert.NotNull(item.SpecialPrice);
            Assert.Equal(3, item.SpecialPrice.quantity); 
            Assert.Equal(130, item.SpecialPrice.price);
        }

        [Fact]
        public void NewItemNoUnitPrice_ShouldThrowArgumentError()
        {
            var exception = Assert.Throws<ArgumentException>(() => new Item("A", 0));
            Assert.Equal("UnitPrice must be greater than 0", exception.Message);
        }
    }
}