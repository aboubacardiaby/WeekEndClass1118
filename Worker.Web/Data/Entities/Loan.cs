using Worker.Web.Data;
using System.ComponentModel.DataAnnotations;

namespace Worker.Web.Data.Entities
{
    public partial class Loan : BaseEntity
    {
        [Key]
        public string LoanNumber { get; set; }
        public string LoanName { get; set; }
        public string LoanType { get; set; }
        public string LoanAmount { get; set; }

        private ICollection<Payment> Payments { get; set; }

    }
}
