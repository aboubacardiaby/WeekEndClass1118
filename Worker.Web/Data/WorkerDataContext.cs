using Microsoft.EntityFrameworkCore;
using Worker.Web.Data.Entities;

namespace Worker.Web.Data
{
    public class WorkerDataContext:DbContext
    {
        public WorkerDataContext(DbContextOptions<WorkerDataContext> options)
      : base(options)
        {

        }

        public DbSet<Customer> tblCustomer { get; set; }
        public DbSet<Loan> tblloan { get; set; }
        public DbSet<Logger> tblLogger { get; set; }
        public DbSet<Payment> tblPayment { get; set; }

    }
}
