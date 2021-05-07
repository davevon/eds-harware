using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using hardwarestore.Contracts;
using hardwarestore.Data;
using hardwarestore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hardwarestore.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class productdetailsController : Controller

    {
        private readonly ISuppliersRepository _Suppliersrepos;
          private readonly IProductDetailsRepository _repos;

        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public productdetailsController(IProductDetailsRepository repos, IMapper mapper,

             ISuppliersRepository Suppliersrepos, UserManager<IdentityUser> userManager)
        {
            _repos = repos;
            _Suppliersrepos = Suppliersrepos;
            _mapper = mapper;
            _userManager = userManager;
        }
        // GET: productdetails
        public ActionResult Index()
        {
            var typesofdetails = _repos.FindAll().ToList();
            var mappingtolist = _mapper.Map<List<ProductDetail>, List<ProductDetailsViewModel>>(typesofdetails);
            
            return View(mappingtolist);
          
        }

       /* public ActionResult SetSuppliers(int id)
        {
            var employee = _userManager.GetUsersInRoleAsync("EMployee").Result;
        
        }
*/
        // GET: productdetails/Details/5
        public ActionResult Details(int id)
        {
            if (!_repos.isExist(id))
            {
                return NotFound();
            }
            var typesofproducts = _repos.FindById(id);
            var Mappingtolist = _mapper.Map<ProductDetailsViewModel>(typesofproducts);
            return View(Mappingtolist);
        }

        // GET: productdetails/Create
        public ActionResult Create()
        {//var Customers = _Suppliersrepos.FindAll();
            var suppliers = _Suppliersrepos.FindAll();
            var supplierItems = suppliers.Select(q => new SelectListItem
            {
                Text = q.SupplierName,
                Value = q.Id.ToString()


            }); 
            var model = new ProductDetailsViewModel
            {
                Suppliers = supplierItems

            };

            return View(model);
        }

        // POST: productdetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDetailsViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var product = _mapper.Map<ProductDetail>(model);
                var issuccessful = _repos.Create(product);
                if (!issuccessful)
                {
                    ModelState.AddModelError("", "Something Went wrong......");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went wrong......");
                return View(model);
            }
        }

        // GET: productdetails/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repos.isExist(id))
            {
                return NotFound();
            }
            var leavetypes = _repos.FindById(id);
            var model = _mapper.Map<ProductDetailsViewModel>(leavetypes);
            return View(model);
        }

        // POST: productdetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductDetailsViewModel model)
        {
           try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var productsdet = _mapper.Map<ProductDetail>(model);
                var isSucess = _repos.Update(productsdet);
                if (!isSucess)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: productdetails/Delete/5
        public ActionResult Delete(int id)
        {

            var productDetails = _repos.FindById(id);
            var isSucess = _repos.Delete(productDetails);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: productdetails/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductDetailsViewModel model)
        {
            try
            {
                var productDetails = _repos.FindById(id);
                var isSucess = _repos.Delete(productDetails);
                if (!isSucess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
