using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Наименование должно быть в пределах 5 - 50 символов")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Производитель")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [Display(Name = "Цена")]
        [Column(TypeName = "money")]
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }
    }
}