using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using hardwarestore.Contracts;
using hardwarestore.Data;
using hardwarestore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hardwarestore.Controllers
{
    public class SalesItemController1 : Controller
    {
        private readonly ISalesRepository _Salesrepos;
        private readonly IProductDetailsRepository _ProdRepo;
        private readonly ICustomerRepository _custumRepo;

        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public SalesItemController1(ISalesRepository repos, IMapper mapper,
             IProductDetailsRepository ProdRepos,ICustomerRepository custumRepo, UserManager<IdentityUser> userManager)
        {
            _Salesrepos = repos;
            _ProdRepo = ProdRepos;
            _custumRepo = custumRepo;
            _mapper = mapper;
            _userManager = userManager;
        }
        // GET: SalesItemController1
        public ActionResult Index()
        {
            var typesofdetails = _Salesrepos.FindAll().ToList();
            var mappingtolist = _mapper.Map<List<SalesItem>, List<SalesItemViewModel>>(typesofdetails);

            return View(mappingtolist);


        }

        // GET: SalesItemController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalesItemController1/Create
        public ActionResult Create()
        {
            var Customers = _custumRepo.FindAll();
            var Products = _ProdRepo.FindAll();
            var productItems = Products.Select(q => new SelectListItem
            {
                Text = q.ProductName,
                Value = q.ToString()


            }); ;
            var model = new SalesItemViewModel
            {
                ProductDetails = productItems

            };

            return View(model);
        }

        // POST: SalesItemController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesItemViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var product = _mapper.Map<SalesItem>(model);
                var issuccessful = _Salesrepos.Create(product);
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

        // GET: SalesItemController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalesItemController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesItemController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalesItemController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
