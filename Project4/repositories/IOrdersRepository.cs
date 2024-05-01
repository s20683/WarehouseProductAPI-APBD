using Project4.model;

namespace Project4.repositories;

public interface IOrdersRepository
{
    Order checkOrderForProductExist(int productId, int amount, DateTime createdAt);
    int cancelOrder(int orderId);
}