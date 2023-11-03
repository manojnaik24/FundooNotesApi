using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class UserTicket
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string token { get; set; }

        public DateTime DateTime { get; set; }
    }
}
