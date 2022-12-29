using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Enitites
{
    // Data Annotations
    [Table("BasketItems")]
    public class BasketItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        // Cardinal Entity Relationship + Navigation Properties

        public int ProductId { get; set; }

        //One to One , Basket - Product
        public Product Product{ get; set; }

        public int BasketId { get; set; }
        
        public Basket Basket { get; set; } 
    }
}
