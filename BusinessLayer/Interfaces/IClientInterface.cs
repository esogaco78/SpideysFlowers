using BusinessLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IClientInterface
    {
        List<Client> GetAll();
    }
}
