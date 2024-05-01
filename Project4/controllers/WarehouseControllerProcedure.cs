using Microsoft.AspNetCore.Mvc;
using Project4.model;
using Project4.services;

namespace Project4.controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehouseControllerProcedure : ControllerBase
{
    private IProcedureService _procedureService;

    public WarehouseControllerProcedure(IProcedureService procedureService)
    {
        _procedureService = procedureService;
    }

    [HttpPost]
    public IActionResult addProductToWarehouse(WarehouseProduct warehouseProduct)
    {
        try
        {
            var status = _procedureService.AddProductToWarehouse(
                warehouseProduct.IdWarehouse,
                warehouseProduct.IdProduct,
                warehouseProduct.Amount,
                warehouseProduct.CreatedAt
            );
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