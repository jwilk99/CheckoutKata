using CheckoutKata.Class;
using CheckoutKata.Interfaces;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public List<Item> items { get; private set; }

        public Checkout()
        {
            items = new List<Item>();
        }

        void ICheckout.Scan(Item item)
        {
            if (string.IsNullOrEmpty(item.Sku))
                throw new ArgumentException("SKU is required");
            if (item.UnitPrice == 0)
                throw new ArgumentException("UnitPrice cannot be 0");
            items.Add(item);
        }
        int ICheckout.GetTotalPrice()
        {
            if (items.Count == 0)
                throw new ArgumentException("You have not scanned any items");

            int total = 0;
            var groupedItems = items.GroupBy(i => i.Sku).ToList();
            foreach (var group in groupedItems)
            {
                var count = group.Count();
                var item = group.First();

                if (count > 1 && item.SpecialPrice != null)
                {
                    var specialPriceTimes = count / item.SpecialPrice.quantity;
                    var remainder = count % item.SpecialPrice.quantity;
                    if (specialPriceTimes > 0)
                    {
                        total += specialPriceTimes * item.SpecialPrice.price;
                        total += (item.UnitPrice * remainder);
                    }
                    else
                    {
                        total += item.UnitPrice * count;
                    }
                }
                else
                {
                    total += item.UnitPrice;
                }

            }

            return total;
        }
    }
}