using Worker.Web.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Worker.Web.Data.Entities
{ 
    public partial class Customer : BaseEntity
    {

        [Key]
        public string CustId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public List<Loan> Loans { get; set; }
    }
}