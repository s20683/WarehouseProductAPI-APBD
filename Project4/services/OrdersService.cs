using Project4.model;
using Project4.repositories;

namespace Project4.services;

public class OrdersService : IOrdersService
{
    private IOrdersRepository _ordersRepository;

    public OrdersService(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public Order checkOrderForProductExist(int productId, int amount, DateTime createdAt)
    {
        return _ordersRepository.checkOrderForProductExist(productId, amount, createdAt);
    }

    public int cancelOrder(int orderId)
    {
        return _ordersRepository.cancelOrder(orderId);
    }
}