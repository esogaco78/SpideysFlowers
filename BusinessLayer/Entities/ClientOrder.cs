using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class ClientOrder
    {
            public int OrderId { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime DeliveryDate { get; set; }
            public string Recipient { get; set; }
            public string RecipientCity { get; set; }
            public short NumberOfLillies { get; set; }
    }
}
