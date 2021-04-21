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
using Microsoft.AspNetCore.Mvc;

namespace hardwarestore.Controllers
{[Authorize(Roles = "Administrator")]
    public class CustomerController1 : Controller
    {
        
        private readonly ICustomerRepository _repos;
        private readonly IMapper _mapper;

        public CustomerController1(ICustomerRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }
        // GET: CustomerController1
        public ActionResult Index()
        {
            var typesofsuppliers = _repos.FindAll().ToList();
            var mappingtolist = _mapper.Map<List<Customer>, List<CustomerViewModel>>(typesofsuppliers);

            return View(mappingtolist);
        }

        // GET: CustomerController1/Details/5
        public ActionResult Details(int id)
        {
            if (!_repos.isExist(id))
            {
                return NotFound();
            }
            var typesofsupplier = _repos.FindById(id);
            var Mappingtolist = _mapper.Map<CustomerViewModel>(typesofsupplier);
            return View(Mappingtolist);
        }

        // GET: CustomerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var suppliers = _mapper.Map<Customer>(model);
                var issuccessful = _repos.Create(suppliers);
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

        // GET: CustomerController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repos.isExist(id))
            {
                return NotFound();
            }
            var leavetypes = _repos.FindById(id);
            var model = _mapper.Map<CustomerViewModel>(leavetypes);
            return View(model);
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leavetype = _mapper.Map<Customer>(model);
                var isSucess = _repos.Update(leavetype);
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

        // GET: CustomerController1/Delete/5
        public ActionResult Delete(int id)
        {
            var leavetype = _repos.FindById(id);
            var isSucess = _repos.Delete(leavetype);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,CustomerViewModel model)
        {
            try
            {
                var leavetype = _repos.FindById(id);
                var isSucess = _repos.Delete(leavetype);
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
