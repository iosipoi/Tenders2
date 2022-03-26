using System;

namespace Tenders.Models
{
    public class OfferDetails
    {
        public int Id { get; set; }
        public int OfferPrice { get; set; }
        public int TenderId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Date { get; set; }
    }
}
