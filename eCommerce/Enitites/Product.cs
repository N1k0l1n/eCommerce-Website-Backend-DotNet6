using System.ComponentModel.DataAnnotations;

namespace eCommerce.Enitites
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public string PictureUrl { get; set; }

        public string Type { get; set; }

        public string Brand { get; set; }

        public int QuantityInStock { get; set; }

    }
}
