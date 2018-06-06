using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Note
    {
        public int NoteId { get; set; }
        public int OrderId { get; set; }
        public string Text { get; set; }
    }
}
