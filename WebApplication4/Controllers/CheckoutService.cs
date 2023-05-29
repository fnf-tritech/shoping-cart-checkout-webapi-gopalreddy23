using NUnit.Framework;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CheckoutService
    {
        private readonly List<Item> items;


       
        public CheckoutService()
        {
            items = new List<Item>
        {
            new Item { SKU = 'A', Price = 50, Offer = new Offer { Quantity = 3, OfferPrice = 130 } },
            new Item { SKU = 'B', Price = 30, Offer = new Offer { Quantity = 2, OfferPrice = 45 } },
            new Item { SKU = 'C', Price = 20 },
            new Item { SKU = 'D', Price = 15 }
        };
        }


        [Test]
        public decimal CalculateTotalPrice(string skus)
        {
            Dictionary<char, int> itemCounts = GetItemCounts(skus);



            decimal totalPrice = 0;



            foreach (var item in itemCounts)
            {
                var selectedItem = items.FirstOrDefault(i => i.SKU == item.Key);
                if (selectedItem != null)
                {
                    totalPrice += CalculateItemPrice(selectedItem, item.Value);
                }
            }



            return totalPrice;
        }



        private Dictionary<char, int> GetItemCounts(string skus)
        {
            var itemCounts = new Dictionary<char, int>();



            foreach (char sku in skus)
            {
                if (itemCounts.ContainsKey(sku))
                {
                    itemCounts[sku]++;
                }
                else
                {
                    itemCounts[sku] = 1;
                }
            }



            return itemCounts;
        }

        [Test]
        private decimal CalculateItemPrice(Item item, int quantity)
        {
            decimal totalPrice = 0;



            if (item.Offer != null)
            {
                int offerQuantity = item.Offer.Quantity;
                int regularPriceQuantity = quantity % offerQuantity;
                int offerPriceQuantity = quantity / offerQuantity;



                totalPrice += offerPriceQuantity * item.Offer.OfferPrice;
                totalPrice += regularPriceQuantity * item.Price;
            }
            else
            {
                totalPrice = quantity * item.Price;
            }



            return totalPrice;
        }
    }
}
