using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Domain.Entities
{
    public class Reservationinfo
    {
        [Key]
        public Guid RecId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public bool Deleted { get; set; } = false;
        public string GuestName { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Child1 { get; set; }
        public int Child2 { get; set; }
        public int Child3 { get; set; }
        public Guid RoomTypeId { get; set; }
        public double Price { get; set; }
    }
}
