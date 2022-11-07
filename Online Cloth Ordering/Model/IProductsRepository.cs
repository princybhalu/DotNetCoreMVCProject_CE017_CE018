using Online_Cloth_Ordering.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Online_Cloth_Ordering.Model
{
    public interface IProductRepository
    {
        public Products GetProduct(int Id);
        public IEnumerable<Products> GetAllProducts() ;

        public void AddToCart(int ProductId, Products add , string Username);

    }
}
