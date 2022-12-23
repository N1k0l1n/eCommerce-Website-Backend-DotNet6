using eCommerce.Enitites;

namespace eCommerce.Data
{
    public class DbInitializer
    {
        public static void Initialize (StoreContext context) 
        {
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                 new Product
                {
                   Name = "Angular Yellow Boots",
                   Description= "dadada",
                   Price = 13999,
                   PictureUrl="/images/new2.png",
                   Brand="Angular",
                   QuantityInStock=199,
                },
                new Product
                {
                   Name = "Angular Red Boots",
                   Description= "ggsdggsd",
                   Price = 15999,
                   PictureUrl="/images/new1.png",
                   Brand="Angular",
                   QuantityInStock=99,
                },
                new Product
                {
                   Name = "Angular Blue Boots",
                   Description= "gsigisugnsigsgisngingsig",
                   Price = 15550,
                   PictureUrl="/images/new.png",
                   Brand="Angular",
                   QuantityInStock=100,
                },
            };
             foreach (var product in products) 
            {
                context.Products.Add(product);
            }
             context.SaveChanges();
        }
    }
}
