namespace CheckoutKata.Class
{
    public class Item
    {
        public string Sku { get; set; }
        public int UnitPrice { get; set; }
        public SpecialPrice? SpecialPrice { get; set; }
        public Item(string sku, int unitPrice)
        {
            if (string.IsNullOrEmpty(sku))
                throw new ArgumentException("SKU is required");
            if (unitPrice <= 0)
                throw new ArgumentException("UnitPrice must be greater than 0");

            this.UnitPrice = unitPrice;
            this.Sku = sku;

        }
        public Item(string sku, int unitPrice, SpecialPrice specialPrice)
        {
            if (string.IsNullOrEmpty(sku))
                throw new ArgumentException("SKU is required");
            if (unitPrice <= 0)
                throw new ArgumentException("UnitPrice must be greater than 0");
            if (specialPrice.quantity == 0)
                throw new ArgumentException("Special Price Quantity cannot be 0");
            if (specialPrice.price == 0)
                throw new ArgumentException("Special Price Price cannot be 0");


            this.UnitPrice = unitPrice;
            this.Sku = sku;

                this.SpecialPrice = specialPrice;
        }
        public void SetSpecialPrice(SpecialPrice specialPrice)
        {
            if (specialPrice.price == 0)
                throw new ArgumentException("Price cannot be 0");
            if (specialPrice.quantity == 0)
                throw new ArgumentException("Quantity cannot be 0");

            this.SpecialPrice = specialPrice;
        }

    }
}