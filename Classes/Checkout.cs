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

        }
        int ICheckout.GetTotalPrice()
        {
            return 0;
        }

    }
}