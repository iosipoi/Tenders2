using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tenders.Models;

namespace Tenders.Data
{
    public class TendersContext : DbContext
    {
        public TendersContext (DbContextOptions<TendersContext> options)
            : base(options)
        {
        }

        public DbSet<Tenders.Models.TenderDetails> TenderDetails { get; set; }

        public DbSet<Tenders.Models.OfferDetails> OfferDetails { get; set; }

        public DbSet<Tenders.Models.User> User { get; set; }
    }
}
