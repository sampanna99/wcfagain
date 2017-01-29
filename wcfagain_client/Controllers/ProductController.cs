using System.Web.Mvc;
using wcfagain_client.Models;
using wcfagain_client.ViewModels;

namespace wcfagain_client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductServiceClient psc = new ProductServiceClient();
            ViewBag.listProducts = psc.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel pvm)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.Create(pvm.Product);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.delete(psc.find(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductServiceClient psc = new ProductServiceClient();
            ProductViewModel pvm = new ProductViewModel();
            pvm.Product = psc.find(id);
            return View("Edit", pvm);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel pvm)
        {
            ProductServiceClient psc = new ProductServiceClient();
            psc.edit(pvm.Product);
            return RedirectToAction("Index");
        }
    }
}