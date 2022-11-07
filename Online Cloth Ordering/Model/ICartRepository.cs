using Online_Cloth_Ordering.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Cloth_Ordering.Model
{
    public interface ICartRepository
    {
        Cart GetCart(int Id);

        IEnumerable<Cart> GetAllCarts(String Username);

        Cart Add(Cart Student);


        Cart Update(Cart StudentChanges);

        Cart Delete(int id);

        int TotalPrices(List<Cart> listof);
    }
}
