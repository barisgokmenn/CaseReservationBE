using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Application.Models
{
    public class RoomTypeDto
    {
        public Guid? RecId { get; set; }
        public Guid? RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int RoomCount { get; set; }
        public int AvailableRoomCount { get; set; }
    }
}
