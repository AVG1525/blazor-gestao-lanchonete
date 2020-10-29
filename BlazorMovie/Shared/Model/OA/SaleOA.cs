using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorMovie.Shared.Model.OA
{
    public class SaleOA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserOAId { get; set; }
        public UserOA UserOA { get; set; }

        public int ProductOAId { get; set; }
        public ProductOA ProductOA { get; set; }

        public int ProductPurchaseStatusOAId { get; set; }
        public ProductPurchaseStatusOA ProductPurchaseStatusOA { get; set; }
    }
}
