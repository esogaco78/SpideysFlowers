using BusinessLayer.Entities;
using BusinessLayer.Enums;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IClientOrderRepository
    {
        List<ClientOrder> GetClientOrders(int id, ClientType type);
    }
}
