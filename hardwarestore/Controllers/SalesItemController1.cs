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

            var model = new SalesItemViewModel
            {
                SalesId=int.Parse(mappingtolist.ToString()),
                CustomerNAme = mappingtolist.ToString(),

                ProductName = mappingtolist.ToString(),
                ProductPrice = int.Parse(mappingtolist.ToString()),
                Quantity= int.Parse(mappingtolist.ToString()),
                Total= int.Parse(mappingtolist.ToString())

         
            };
          
            /*Include(q=> q.CustomerNAme)
                .Include(q=>q.ProductPrice)
              
                */


            return View(model);


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
            var customername = Customers.Select(q => new SelectListItem
            {
                Text = q.CustomerNAme,
                Value = q.CustomerId.ToString()
            }); 

            

            var Products = _ProdRepo.FindAll();
            var productItems = Products.Select(q => new SelectListItem
            {
                Text = $"{q.ProductName} - ${q.ProductPrice}",
                Value = q.ProductId.ToString()


            }); 
            var model = new SalesItemViewModel
            {
                ProductDetails = productItems,
                Customers= customername

            };

            return View(model);
        }

        // POST: SalesItemController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesItemViewModel model)
        {
           // var Customers = _custumRepo.FindAll();
              try
                  {
                //customer making the purchase and getting the user who is sign in.

                //   getting if the person is inside of the data base
                // var customer = _custumRepo.GetCustomerByID(customerIdentity.Id);
                //var customerIdentity = _userManager.GetUserAsync(User).Result;
                var Customers = _custumRepo.FindAll();
                var customername = Customers.Select(q => new SelectListItem
                {
                    Text = q.CustomerNAme,
                    Value = q.CustomerId.ToString()
                });

                var Products = _ProdRepo.FindAll();
                var productItems = Products.Select(q => new SelectListItem
                {
                    Text = $"{q.ProductName} - ${q.ProductPrice}",
                    Value = q.ProductId.ToString()


                });
                model.Customers = customername;
                model.ProductDetails = productItems;
                
                var product = _ProdRepo.FindById(model.ProductId);
                  var  totalcost = model.Total;

                if (product.Quantity >model.Quantity )
                {
                   // ModelState.AddModelError("", "Please  place quantity value");
               //   totalcost = salesonitem.ProductPrice * salesonitem.Quantity;
                    totalcost = product.ProductPrice * model.Quantity;
               
                }
                else if (model.Quantity<=0)
                {
                    ModelState.AddModelError("", "please enter a value for the quantity");
                   
                    return View(model);
                }
                
                model.Total=totalcost;
                var calculation = new SalesItemViewModel
                {//objects
                    CustomerId=model.CustomerId,
                  CustomerNAme=model.CustomerNAme,
                    Customers= model.Customers,
                    ProductDetails= model.ProductDetails,
                    ProductName=model.ProductName,
                    ProductPrice = model.ProductPrice,
                   Quantity = model.Quantity,
                   SalesId= model.SalesId,
                   Total = model.Total,
                    ProductId=model.ProductId
                   




                };

                var salesproduct = _mapper.Map<SalesItem> (calculation);
              
                var issuccessful = _Salesrepos.Create(salesproduct);
                if (!issuccessful)//if the insertion failed
                {
                    ModelState.AddModelError("", "Something Went wrong submitting your record......");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Something Went wrong submitting your record......");
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
