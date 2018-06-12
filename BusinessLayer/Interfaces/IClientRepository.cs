using BusinessLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IClientRepository
    {
        List<Client> GetAll();
    }
}
