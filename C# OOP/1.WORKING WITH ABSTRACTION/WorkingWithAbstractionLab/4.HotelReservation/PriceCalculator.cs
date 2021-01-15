using System;
using System.Collections.Generic;
using System.Text;

namespace _4.HotelReservation
{
    public static class PriceCalculator
    {
       public static decimal GetTotalPrice(decimal pricePerDay, int numberOfDays, Season season, Discount discountType) 
        {
            var price = pricePerDay * (int)season * numberOfDays;
            var discount = price * (int)discountType / 100;
            price -= discount;
            return price;
        }
    }
}
