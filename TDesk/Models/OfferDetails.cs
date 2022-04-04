using System;
using System.Collections.Generic;
using System.Text;

namespace TDesk.Models
{
    public class OfferDetails
    {
        public int Id { get; set; }
        public int OfferPrice { get; set; }
        public int TenderId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
