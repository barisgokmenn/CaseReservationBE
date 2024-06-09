using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEptera.Reservation.Domain.Entities
{
    public class Roomquota
    {
        [Key]
        public Guid RecId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public bool Deleted { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid RoomTypeId { get; set; }
        public int AvailableRoomCount { get; set; }
    }
}
