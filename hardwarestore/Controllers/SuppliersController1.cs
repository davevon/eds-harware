using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using hardwarestore.Contracts;
using hardwarestore.Data;
using hardwarestore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hardwarestore.Controllers
{
 
    public class SuppliersController1 : Controller
    {
        private readonly ISuppliersRepository _repos;
        private readonly IMapper _mapper;

        public SuppliersController1(ISuppliersRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }
            // GET: SuppliersController1
        public ActionResult Index()
        {
            var typesofsuppliers = _repos.FindAll().ToList();
            var mappingtolist=_mapper.Map <List<Supplier>,  List < SupplierViewModel >> (typesofsuppliers);

            return View(mappingtolist);
        }

        // GET: SuppliersController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SuppliersController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuppliersController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var suppliers = _mapper.Map<Supplier>(model);
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

        // GET: SuppliersController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repos.isExist(id))
            {
                return NotFound();
            }
            var leavetypes = _repos.FindById(id);
            var model = _mapper.Map<SupplierViewModel>(leavetypes);
            return View(model);
        }

        // POST: SuppliersController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplierViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leavetype = _mapper.Map<Supplier>(model);
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

        // GET: SuppliersController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuppliersController1/Delete/5
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
