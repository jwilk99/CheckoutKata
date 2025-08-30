using CheckoutKata.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Interfaces
{
    internal interface ICheckout
    {
        public void Scan(Item item);
        public int GetTotalPrice();
    }
}
