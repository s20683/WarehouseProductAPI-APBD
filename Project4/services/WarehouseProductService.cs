using Project4.model;
using Project4.repositories;

namespace Project4.services;

public class WarehouseProductService : IWarehouseProductService
{
    private IProductsService _productsService;
    private IWarehousesService _warehousesService;
    private IOrdersService _ordersService;
    private IProductWarehouseRepository _productWarehouseRepository;

    public WarehouseProductService(IProductsService productsService, IWarehousesService warehousesService, IOrdersService ordersService, IProductWarehouseRepository productWarehouseRepository)
    {
        _productsService = productsService;
        _warehousesService = warehousesService;
        _ordersService = ordersService;
        _productWarehouseRepository = productWarehouseRepository;
    }

    public string handleProduct(WarehouseProduct warehouseProduct)
    {
        Product product = _productsService.checkProductExist(warehouseProduct.IdProduct);
        if (product == null)
        {
            return "Product does not exist";
        }

        if (!_warehousesService.checkWarehouseExist(warehouseProduct.IdWarehouse))
        {
            return "Warehouse does not exist";
        }

        if (warehouseProduct.Amount <= 0)
        {
            return "Amount must be greater than 0";
        }

        var order = _ordersService.checkOrderForProductExist(warehouseProduct.IdProduct, warehouseProduct.Amount,
            warehouseProduct.CreatedAt);
        if (order == null)
        {
            return "Order for this values does not exist";
        }

        if (_productWarehouseRepository.checkOrderExist(order.IdOrder))
        {
            return "Order is proceeding..";
        }

        _ordersService.cancelOrder(order.IdOrder);
        var generatedId = _productWarehouseRepository.insertProductWarehouse(new ProductWarehouse(
            warehouseProduct.IdWarehouse,
            warehouseProduct.IdProduct,
            order.IdOrder,
            warehouseProduct.Amount,
            warehouseProduct.Amount * product.Price,
            DateTime.Now
            ));

        return "Ok " + generatedId;
    }
}