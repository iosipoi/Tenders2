﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TDesk.Models
{
    public class Tender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double StartPrice { get; set; }
        public double FinalPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string CPVCode { get; set; }
        public int Status { get; set; }
    }
}
