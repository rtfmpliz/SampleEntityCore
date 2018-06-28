using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleEntityCore.DAL;
using SampleEntityCore.Models;

namespace SampleEntityCore.Controllers
{
    public class CategoryController : Controller
    {
        private ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }
        // GET: Category
        public ActionResult Index()
        {
            if (TempData["Pesan"] != null)
                ViewBag.Pesan = TempData["Pesan"];
            else
                ViewBag.Pesan = string.Empty;

            var results = _category.GetAll();
            return View(results);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var result = _category.GetById(id.ToString());
            return View(result);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            
            try
            {
                // TODO: Add insert logic here
                _category.Create(category);
                TempData["Pesan"] = "<span class='alert alert-success'>Data " + category.CategoryName + " berhasil ditambah !</span>";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "<span class='alert alert-danger'>Kesalahan " + ex.Message + "</Span>";
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _category.GetById(id.ToString());
            return View(result);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category   category)
        {
            ViewBag.Error = string.Empty;
            try
            {
                // TODO: Add update logic here
                _category.Edit(id.ToString(), category);
                TempData["Pesan"] = "<span class='alert alert-success'>Data " + category.CategoryName + " berhasil diupdate !</span>";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "<span class='alert alert-danger'>Kesalahan " + ex.Message + "</Span>";
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _category.GetById(id.ToString());
            return View(result);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                _category.Delete(id.ToString());
                // TODO: Add delete logic here
                TempData["Pesan"] = "<span class='alert alert-success'>Data " + category.CategoryName + " berhasil didelte !</span>";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "<span class='alert alert-danger'>Kesalahan " + ex.Message + "</Span>";
                return View();
            }
        }
    }
}