using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Worker.Web.Data;
using Worker.Web.Data.Entities;
using Worker.Web.Models;

namespace Worker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WorkerDataContext _context;

        public HomeController(ILogger<HomeController> logger, WorkerDataContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Index()
        {
            var query = _context.tblCustomer.ToList();
             
            return View(query);
        }

        [HttpGet]
        public IActionResult Create()
        {
        return View( new Customer());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (customer == null)
            {
                return View("Index");
            }
            customer.CreateDate = DateTime.Now;
            customer.CreatedBy = "test1";
            _context.tblCustomer.Add(customer);
            _context.SaveChanges();
            return View("Index");
        }
        public IActionResult Details()
        {
          
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}