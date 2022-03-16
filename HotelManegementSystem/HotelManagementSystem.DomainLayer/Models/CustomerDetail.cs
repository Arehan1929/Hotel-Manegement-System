using System;
using System.Collections.Generic;

#nullable disable

namespace HotelManagementSystem.DomainLayer.Models
{
    public partial class CustomerDetail
    {
        public CustomerDetail()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int Custid { get; set; }
        public string Custname { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}
