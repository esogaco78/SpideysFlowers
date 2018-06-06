using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface INoteRepository
    {
        Note Get();
        int Insert(Note note);
        bool Update(Note note);
        bool Delete(int noteid);
    }
}
