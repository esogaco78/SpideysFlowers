using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool IsDelivery { get; set; }
        public string Recipient { get; set; }
        public string RecipientStreetAddress { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientRegion { get; set; }
        public string RecipientCode { get; set; }
        public string RecipientPhoneNumber { get; set; }
        public string RecipientEmail { get; set; }
        public int NumberOfLilies { get; set; }
        public int? CustomerId { get; set; }
        public int? BusinessId { get; set; }
        public bool IsBusiness { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public string Text { get; set; }
    }
}
