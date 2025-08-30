using CheckoutKata.Class;
using CheckoutKata.Interfaces;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public List<Item> Items { get; private set; }
        public List<SpecialPrice> Offers { get; set; }

        public Checkout()
        {
            Items = new List<Item>();
            Offers = new List<SpecialPrice>();
        }

        public void AddSpecialPrice(SpecialPrice offer)
        {
            if (Offers.Any(o => o.Sku == offer.Sku))
                throw new Exception("This item already has a special price");
            Offers.Add(offer);
        }

        public void Scan(Item item)
        {
            Items.Add(item);
        }
        public int GetTotalPrice()
        {
            if (Items.Count == 0)
                throw new ArgumentException("You have not scanned any items");

            int total = 0;
            var groupedItems = Items.GroupBy(i => i.Sku).ToList();
            foreach (var group in groupedItems)
            {
                var count = group.Count();
                var item = group.First();

                if (count > 1)
                {
                    var offerForItem = Offers.FirstOrDefault(o => o.Sku == item.Sku);
                    if (offerForItem == null)
                        continue;

                    var specialPriceTimes = count / offerForItem.Quantity;
                    var remainder = count % offerForItem.Quantity;
                    if (specialPriceTimes > 0)
                    {
                        total += specialPriceTimes * offerForItem.Price;
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