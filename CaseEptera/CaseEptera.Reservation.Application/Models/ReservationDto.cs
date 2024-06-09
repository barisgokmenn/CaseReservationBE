using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Application.Models
{
    public class ReservationDto
    {
        public Guid? RecId { get; set; }
        public string GuestName { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Child1 { get; set; }
        public int Child2 { get; set; }
        public int Child3 { get; set; }
        public Guid RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public double Price { get; set; }
    }
}
