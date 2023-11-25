using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
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
        public IActionResult Edit( int? Id)
        {
            var customer = _context.tblCustomer.Where(b => b.Id == Id).FirstOrDefault();
            if( customer == null) {
                return NotFound();
            }



            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            
            if (customer == null)
            {
                return View("Index");
            }

            Object[] paramItems = new object[]
                            {
                                new SqlParameter("@FirstName", customer.FirstName),
                                new SqlParameter("@LastName", customer.LastName),
                                 new SqlParameter("@EmailPhoneNumber", customer.Email),
                                new SqlParameter("@Address", customer.Address),
                                new SqlParameter("@City", customer.City),
                                new SqlParameter("@State", customer.State),
                                 new SqlParameter("@Id", customer.Id)

                            };

            var customers = _context.Database.ExecuteSqlRaw(@"UPDATE [dbo].[tblCustomer]
                                                               SET
                                                                  [FirstName] = @firstName
                                                                  ,[LastName] = @LastName
                                                                  ,[Email] = @EmailPhoneNumber
                                                                  ,[Address] = @Address
                                                                  ,[City] = @City
                                                                  ,[State] = @State
                                                                 
                                                             WHERE Id = @Id", paramItems);


                    
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (customer == null)
            {
                return View("Index");
            }
            var rand = new Random();
            var uid = rand.Next(100000, 1000000);
            customer.CustId = uid.ToString();
            customer.CreateDate = DateTime.Now;
            customer.CreatedBy = "test1";
            _context.tblCustomer.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //return View( new Customer());
        //}

        //[HttpPost]
        //public IActionResult Create(Customer customer)
        //{
        //    if (customer == null)
        //    {
        //        return View("Index");
        //    }
        //    var rand = new Random();
        //    var uid = rand.Next(100000, 1000000);
        //    customer.CustId = uid.ToString();
        //    customer.CreateDate = DateTime.Now;
        //    customer.CreatedBy = "test1";
        //    _context.tblCustomer.Add(customer);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index)); 
        //}
        public IActionResult Details(int  Id)
        {
              var customer = _context.tblCustomer.Where(b=>b.Id == Id).FirstOrDefault();
          
            return View(customer);
        }

        public IActionResult Delete(int Id)
        {
            var customer = _context.tblCustomer.Where(b => b.Id == Id).FirstOrDefault();
            _context.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
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