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
            return View("Index",_context.Items);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult Create(Item it)
        {
            _context.Items.Add(it);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            Item i = _context.Items.SingleOrDefault(it => it.Id == Id);
            _context.Items.Remove(i);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
