using Microsoft.AspNetCore.Mvc;
using Project4.model;
using Project4.services;

namespace Project4.controllers;
[Route("api/[controller]")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private IWarehouseProductService _warehouseProductService;
    public WarehouseController(IWarehouseProductService warehouseProductService)
    {
        _warehouseProductService = warehouseProductService;
    }

    [HttpPost]
    public IActionResult addProductToWarehouse(WarehouseProduct warehouseProduct)
    {
        try
        {
            var status = _warehouseProductService.handleProduct(warehouseProduct);
            if (status.Contains("Ok"))
            {
                return Ok();
            }

            return StatusCode(400, status);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Błąd serwera " + ex.Message);
        }
    }
    
}