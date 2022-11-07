using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Online_Cloth_Ordering.ViewModel
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrices { get; set; }
        public string ProductBrand { get; set; }
    }
}
