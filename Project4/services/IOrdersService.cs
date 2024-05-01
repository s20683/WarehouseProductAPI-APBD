using Project4.model;

namespace Project4.services;

public interface IOrdersService
{
    Order checkOrderForProductExist(int productId, int amount, DateTime createdAt);
    int cancelOrder(int orderId);

}