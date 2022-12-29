
using System.Collections;

namespace eCommerce.Enitites
{
    public class Basket
    {
        public int Id { get; set; }

        public string BuyerId { get; set; }

        //One to Many , Basket many Items
        public List<BasketItem> Items { get; set; } = new  ();


        //Helping in CRUD Operations

        public void AddItem(Product product, int quantity)
        {
            if (Items.All(item=>item.ProductId != product.Id))
            {
                Items.Add(new BasketItem { Product = product, Quantity = quantity });
            }


            //Adjusting the quantity

            var existingItem = Items.FirstOrDefault(item=>item.ProductId==product.Id);

            if (existingItem != null) existingItem.Quantity += quantity;
           
        }

        public void RemoveItem(int productId , int quantity)
        {
            var item = Items.FirstOrDefault(item => item.ProductId == productId);

            if (item == null) return;
            item.Quantity -= quantity;

            if(item.Quantity == 0) Items.Remove(item);

        }

    }
}
