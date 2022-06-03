using System.ComponentModel.DataAnnotations;

namespace FDNS.Domain.Models.Base
{
    public abstract class BasePrice : BaseEntity<uint>
    {
        [Required, MaxLength(50)]
        public string ProductCategoryName { get; set; }

        [Required, MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required, MaxLength(20)]
        public string DurationType { get; set; }

        [Required]
        public double UserPrice { get; set; }

        [Required]
        public double RegularPrice { get; set; }

        [Required]
        public double AdditionalCost { get; set; }
    }
}