using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public int PersonCount { get; set; }
        public int DestinationID { get; set; }
        public Destination Destination { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
