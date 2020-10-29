using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorMovie.Shared.Model.OA
{
    public class ProductOA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public Decimal Price { get; set; }

        [Required]
        public int ProductDescriptionOAId { get; set; }
        public ProductDescriptionOA ProductDescriptionOA { get; set; }

        public List<SaleOA> SaleOA { get; set; }
    }
}
