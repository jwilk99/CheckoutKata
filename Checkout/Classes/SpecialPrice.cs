namespace CheckoutKata
{
    public class SpecialPrice
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public SpecialPrice(string sku, int quantity, int price)
        {
            if (string.IsNullOrEmpty(sku))
                throw new ArgumentException("SKU cannot be empty");
            if (quantity == 0)
                throw new ArgumentException("Quantity cannot be 0");
            if (price == 0)
                throw new ArgumentException("Price cannot be 0");

            this.Quantity = quantity;
            this.Price = price;
            this.Sku = sku;
        }
    }
}