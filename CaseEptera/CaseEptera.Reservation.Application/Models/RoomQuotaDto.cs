using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Application.Models
{
    public class RoomQuotaDto
    {
        public Guid? RecId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid RoomTypeId { get; set; }
        public int AvailableRoomCount { get; set; }
    }
}
