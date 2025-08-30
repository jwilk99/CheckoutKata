namespace CheckoutKata.Class
{
    public class Item
    {
        public string Sku { get; set; }
        public int UnitPrice { get; set; }
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

            this.UnitPrice = unitPrice;
            this.Sku = sku;

        }
    }
}