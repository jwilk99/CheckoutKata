using CheckoutKata;
using CheckoutKata.Class;

namespace CheckoutTests.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void CheckoutScanItem_ShouldAddItemToList()
        {
            var checkout = new Checkout();
            var item = new Item("A", 50);
            checkout.Scan(item);

            Assert.NotEmpty(checkout.items);
            
        }
    }
}