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
            return View("Index",_context.Items.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Item it)
        {
            _context.Items.Add(it);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult delete(int id)
        {
            var i = _context.Items.FirstOrDefault(it => it.Id == id);
            _context.Items.Remove(i);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
