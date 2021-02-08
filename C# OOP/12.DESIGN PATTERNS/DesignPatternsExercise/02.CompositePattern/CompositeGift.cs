using System;
using System.Collections.Generic;
using System.Text;

namespace _02.CompositePattern
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> gifts;
        public CompositeGift(string name, int price) 
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;
            Console.WriteLine($"{name} contains the following products with prices: ");
            foreach (var gift in gifts)
            {
                total += gift.CalculateTotalPrice();
            }
            return total;
        }
    }
}
