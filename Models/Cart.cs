using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingWebsite.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Image { get; set; }

        [Required]
        [MaxLength(32)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [NotMapped]
        public int Quantity { get; set; }

        [Required] //foreign key pointing to Product model
        public int ProductId { get; set; }

        //Fetches a Product object during a query
        //whose Primary Key matches ProductId
        public virtual Product product { get; set; }

    }
}
