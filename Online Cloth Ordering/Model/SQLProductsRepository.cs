using Online_Cloth_Ordering.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Cloth_Ordering.Model
{
    public class SQLProductsRepository : IProductRepository
    {
        AuthDbContext context = null ;
        private ICartRepository _cartRepo;
        

        public SQLProductsRepository(AuthDbContext _context, ICartRepository cartRepo )
        {
            context = _context;
            _cartRepo = cartRepo;
          
        }

        IEnumerable<Products> IProductRepository.GetAllProducts()
        {
            IEnumerable<Products> temp = (context != null) ? context.Products : null;

            return (context.Products.Select(s => s).ToList());
        }

        Products IProductRepository.GetProduct(int id)
        {
            return context.Products.FirstOrDefault(m => m.ProductId == id);
        }

        void IProductRepository.AddToCart( int ProductId , Products add , string Username)
        {
            Cart cart = new Cart();
            cart.ProductIdInCart = ProductId;
            cart.ProductName = add.ProductName;
            cart.ProductPrices = add.ProductPrices;
            cart.UserName = Username;
            cart.Quantity = 1;

            Cart newCart =  _cartRepo.Add(cart);


        }

    }
}
