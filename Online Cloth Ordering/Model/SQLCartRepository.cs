using Online_Cloth_Ordering.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Cloth_Ordering.Model
{
    public class SQLCartRepository : ICartRepository
    {
        AuthDbContext context = null;

        public SQLCartRepository(AuthDbContext _context) => context = _context;

        Cart ICartRepository.Add(Cart newcart)
        {
            context.Cart.Add(newcart);
            context.SaveChanges();
            return newcart;
        }

        Cart ICartRepository.Delete(int id)
        {
            Cart carttodetele = context.Cart.Find(id);
            if (carttodetele != null)
            {
                context.Cart.Remove(carttodetele);
                context.SaveChanges();
            }
            return carttodetele;

        }

        IEnumerable<Cart> ICartRepository.GetAllCarts(String Username)
        {
            List<Cart> all = context.Cart.Select(s => s).ToList();
            List<Cart> final = new List<Cart>();

            foreach(Cart cart in all)
            {
                if(cart.UserName == Username)
                {
                    final.Add(cart);
                }
            }

            return final;
        }

        Cart ICartRepository.GetCart(int Id)
        {
            return context.Cart.FirstOrDefault(m => m.CartId == Id);
        }

        Cart ICartRepository.Update(Cart CartChanges)
        {
            var cart = context.Cart.Attach(CartChanges);
            cart.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return CartChanges;
        }
          
        int ICartRepository.TotalPrices(List<Cart> listof)
        {
            int total = 0;
            foreach(Cart cart in listof)
            {
                total += (cart.Quantity * cart.ProductPrices);
            }
            return total;
        }

    }
}
