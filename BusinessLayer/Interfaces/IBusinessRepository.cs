using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBusinessRepository
    {
        List<Business> GetAll();
        Business GetById(int id);
        int Insert(Business business);
        bool Update(Business business);
        bool Delete(int businessid);
    }
}
