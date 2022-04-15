using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}