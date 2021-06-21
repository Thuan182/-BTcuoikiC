namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public decimal UnitCost { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Description { get; set; }

        public bool Status { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
