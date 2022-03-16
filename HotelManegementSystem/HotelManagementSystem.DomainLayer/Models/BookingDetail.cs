using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagementSystem.DomainLayer.Models
{
    public partial class BookingDetail
    {
        public int Bookingid { get; set; }
        public int? Roomnumber { get; set; }
        public string Bookingstatus { get; set; }
        public DateTime? Bookingdate { get; set; }
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public int? Custid { get; set; }

        public virtual CustomerDetail Cust { get; set; }
        public virtual RoomDetail RoomnumberNavigation { get; set; }
    }
}
