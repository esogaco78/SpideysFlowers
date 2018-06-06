using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Business
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string ContactName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Code { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
    }
}
