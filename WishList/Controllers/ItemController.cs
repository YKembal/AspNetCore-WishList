using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var model = _context.Items.ToList();
            return View("Index",model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Item i)
        {
            _context.Items.Add(i);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var i = _context.Items.FirstOrDefault(it => it.Id == id);
            _context.Items.Remove(i);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
