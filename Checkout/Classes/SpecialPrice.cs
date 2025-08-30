namespace CheckoutKata
{
    public class SpecialPrice
    {
        public int quantity { get; set; }
        public int price { get; set; }
        public SpecialPrice(int quantity, int price)
        {
            if (quantity == 0)
                throw new ArgumentException("Quantity cannot be 0");
            if (price == 0)
                throw new ArgumentException("Price cannot be 0");

            this.quantity = quantity;
            this.price = price;
        }
    }
}