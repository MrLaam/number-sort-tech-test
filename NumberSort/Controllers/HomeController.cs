using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NumberSort.Data;
using NumberSort.Models;
using NumberSort.Views.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NumberSort.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
            _db.Database.Migrate();
        }

        [HttpGet]
        public IActionResult Index(bool? isDownload)
        {
            if(isDownload == true)
            {
                IEnumerable<NumberSet> numberSets = _db.NumberSet;
                string jsonString = JsonSerializer.Serialize(numberSets);
                var fileName = "NumberSet.txt";
                var mimeType = "text/plain";
                var fileBytes = Encoding.ASCII.GetBytes(jsonString);

                return new FileContentResult(fileBytes, mimeType)
                {
                    FileDownloadName = fileName
                };
            }

            NumberSetViewModel numberSetViewModel = new NumberSetViewModel();
            numberSetViewModel.NumberSortForm = new NumberSortForm();
            numberSetViewModel.NumberSets = _db.NumberSet;
            return View(numberSetViewModel);
        }

        [HttpPost]
        public IActionResult Index(NumberSetViewModel obj)
        {
            if(ModelState.IsValid)
            {
                NumberSorter numberSorter = new NumberSorter();
                NumberSet numberSet = numberSorter.sortList(obj.NumberSortForm.unsortedList, obj.NumberSortForm.sortOrder);

                _db.NumberSet.Add(numberSet);
                _db.SaveChanges();

                TempData["Success"] = "Success";
            }
            
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
