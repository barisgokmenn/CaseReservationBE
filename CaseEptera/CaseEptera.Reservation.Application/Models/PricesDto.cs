using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Application.Models
{
    public class PricesDto
    {
        public Guid? RecId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public double Price { get; set; }
    }
}
