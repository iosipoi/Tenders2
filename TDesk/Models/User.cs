using System;
using System.Collections.Generic;
using System.Text;

namespace TDesk.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
