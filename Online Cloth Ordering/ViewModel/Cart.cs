using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Online_Cloth_Ordering.ViewModel
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int ProductIdInCart { get; set; }

        public string ProductName { get; set; }

        public int ProductPrices { get; set; }

        public string UserName { get; set; }

        public int Quantity { get; set; }

       

    }
}
