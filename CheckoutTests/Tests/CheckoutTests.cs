using CheckoutKata;
using CheckoutKata.Class;

namespace CheckoutTests.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void CheckoutScanItem_ShouldAddItemToList()
        {
            var item = new Item("A", 50);

            var checkout = new Checkout();
            checkout.Scan(item);

            Assert.NotEmpty(checkout.Items);
            Assert.Single(checkout.Items);

        }
        [Fact]
        public void CheckoutScanTwoItems_ShouldHaveALengthOfTwo()
        {
            var item = new Item("A", 50);
            var itemTwo = new Item("B", 30);

            var checkout = new Checkout();

            checkout.Scan(item);
            checkout.Scan(itemTwo);

            Assert.Equal(2, checkout.Items.Count);

        }

        [Fact]
        public void CheckoutGetTotalPriceOneItem_ShouldEqual50()
        {
            var a = new Item("A", 50);

            var checkout = new Checkout();
            checkout.Scan(a);

            var total = checkout.GetTotalPrice();

            Assert.Equal(50, total);
        }

        [Fact]
        public void CheckoutGetTotalPriceTwoItem_ShouldEqual80()
        {
            var a = new Item("A", 50);
            var b = new Item("B", 30);

            var checkout = new Checkout();
            checkout.Scan(a);
            checkout.Scan(b);

            var total = checkout.GetTotalPrice();

            Assert.Equal(80, total);
        }

        [Fact]
        public void CreateCheckoutWithSpecialPrice()
        {
            var checkout = new Checkout();
            checkout.AddSpecialPrice(new SpecialPrice("A", 3, 130));

            Assert.NotEmpty(checkout.Offers);
            Assert.Single(checkout.Offers);
        }

        [Fact]
        public void CheckoutGetTotalPriceThreeOfSameItem_ShouldEqual130()
        {
            var a = new Item("A", 50);

            var checkout = new Checkout();
            checkout.AddSpecialPrice(new SpecialPrice("A", 3, 130));
            checkout.Scan(a);
            checkout.Scan(a);
            checkout.Scan(a);

            var total = checkout.GetTotalPrice();

            Assert.Equal(130, total);
        }

        [Fact]
        public void CheckoutGetTotalPriceTwoSameItemOneDifferent_ShouldEqual95()
        {
            var a = new Item("A", 50);
            var b = new Item("B", 30);
            var checkout = new Checkout();
            checkout.AddSpecialPrice(new SpecialPrice("A", 3, 130));
            checkout.AddSpecialPrice(new SpecialPrice("B", 2, 45));
            checkout.Scan(b);
            checkout.Scan(b);
            checkout.Scan(a);

            var total = checkout.GetTotalPrice();

            Assert.Equal(95, total);
        }

        [Fact]
        public void CheckoutGetTotalPrice3SameItemOneDifferent_ShouldEqual160()
        {
            var a = new Item("A", 50);
            var b = new Item("B", 30);
            var checkout = new Checkout();
            checkout.AddSpecialPrice(new SpecialPrice("A", 3, 130));
            checkout.AddSpecialPrice(new SpecialPrice("B", 2, 45));
            checkout.Scan(a);
            checkout.Scan(a);
            checkout.Scan(b);
            checkout.Scan(a);

            var total = checkout.GetTotalPrice();

            Assert.Equal(160, total);
        }

        [Fact]
        public void CheckoutGetTotalPrice2SpecialOffers_ShouldEqual175()
        {
            var a = new Item("A", 50);
            var b = new Item("B", 30);
            var checkout = new Checkout();
            checkout.AddSpecialPrice(new SpecialPrice("A", 3, 130));
            checkout.AddSpecialPrice(new SpecialPrice("B", 2, 45));
            checkout.Scan(a);
            checkout.Scan(a);
            checkout.Scan(b);
            checkout.Scan(a);
            checkout.Scan(b);

            var total = checkout.GetTotalPrice();

            Assert.Equal(175, total);
        }

        [Fact]
        public void CheckoutGetTotalPrice2OfSameSpecialOffer_ShouldEqual90()
        {
            var a = new Item("A", 50);
            var b = new Item("B", 30);
            var checkout = new Checkout();
            checkout.AddSpecialPrice(new SpecialPrice("A", 3, 130));
            checkout.AddSpecialPrice(new SpecialPrice("B", 2, 45));
            checkout.Scan(b);
            checkout.Scan(b);
            checkout.Scan(b);
            checkout.Scan(b);

            var total = checkout.GetTotalPrice();

            Assert.Equal(90, total);
        }
    }
}