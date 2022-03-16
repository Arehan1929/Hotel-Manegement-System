using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagementSystem.DomainLayer.Models
{
    public partial class RoomDetail
    {
        public RoomDetail()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int Roomnumber { get; set; }
        public string Roomtype { get; set; }
        public string Roomstatus { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
