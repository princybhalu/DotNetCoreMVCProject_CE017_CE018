using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Online_Cloth_Ordering.Model;
using Online_Cloth_Ordering.ViewModel;

namespace Online_Cloth_Ordering.Controllers
{
    public class ProductsController : Controller
    {
        
        private IProductRepository _productRepo;
        private ISessionsRepro _sess;
        private ICartRepository _cartRepo;
        private readonly SignInManager<IdentityUser> signInManager;

        public ProductsController(IProductRepository productRepo , ISessionsRepro sess , ICartRepository cartrepo , SignInManager<IdentityUser> signInManager)
        {
            _productRepo = productRepo;
            _sess = sess;
            _cartRepo = cartrepo;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var model = _productRepo.GetAllProducts();
            String uname = _sess.GetUsername();
            this.ViewBag.result = "Welcome " + uname ;
            return View(model);
        }

        public ViewResult Details(int id)
        {
            Products product = _productRepo.GetProduct(id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return View("productsNotFound", id);
            }
            return View(product);
        }

        public IActionResult AddToCart(int id)
        {
            // var username = HttpContext.Session.GetString("Username");
            var username = _sess.GetUsername();
            Products add = _productRepo.GetProduct(id);
            if (add == null)
            {
                Response.StatusCode = 404;
                return View("productsNotFound", id);
            }

            _productRepo.AddToCart(id , add, username);

            this.ViewBag.result = "Add Successfully";
            return RedirectToAction("index");
        }

        public IActionResult viewCart()
        {
            String uname = _sess.GetUsername();
            var model = _cartRepo.GetAllCarts(uname);
            this.ViewBag.result = "";

            if (model == null)
            {
                this.ViewBag.result = "Your Cart Is Empty";
            }
            return View(model); ;
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Cart student = _cartRepo.GetCart(id);
            return View(student);
        }


        [HttpPost]
        public IActionResult Edit(Cart model)
        {
            if (ModelState.IsValid)
            {
                Cart student = _cartRepo.GetCart(model.CartId);

                student.Quantity = model.Quantity;

                Cart updatedStudent = _cartRepo.Update(student);

                this.ViewBag.result = "";
                return RedirectToAction("viewCart");
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            Cart cart = _cartRepo.GetCart(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var cart = _cartRepo.GetCart(id);
            _cartRepo.Delete(cart.CartId);

            this.ViewBag.result = "";
            return RedirectToAction("viewCart");

        }

        public IActionResult buy()
        {
            String uname = _sess.GetUsername();
            List<Cart> listof = _cartRepo.GetAllCarts(uname).ToList();
            int total = _cartRepo.TotalPrices(listof);
            if(total == 0)
            {
                this.ViewBag.result = "Your Cart Is Empty";
                return RedirectToAction("viewCart");

            }
            buyList add = new buyList();
            add.total = total;
            add.name = uname;
            add.listof = listof;
            List<buyList> tosave = new List<buyList>();
            tosave.Add(add);
           
            this.ViewBag.UserName = tosave;
           
            foreach(Cart temp in listof)
            {
                var cart = _cartRepo.GetCart(temp.CartId);
                _cartRepo.Delete(cart.CartId);
            }
            return View();
        }

        public IActionResult Profile()
        {
            String uname = _sess.GetUsername();
            this.ViewBag.UserName = uname;
            return View();
        }


    }  
}

public class buyList{

public  int total;
    public String name;
    public List<Cart> listof;
   
}
