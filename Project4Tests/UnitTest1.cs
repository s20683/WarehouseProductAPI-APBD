using Microsoft.AspNetCore.Mvc;
using Moq;
using Project4.controllers;
using Project4.model;
using Project4.services;

namespace Project4Tests;

public class UnitTest1
{
  [Fact]
public void AddProductToWarehouse_ReturnsOk_WhenServiceReturnsOk()
{
    // Arrange
    var mockService = new Mock<IWarehouseProductService>();
    mockService.Setup(service => service.handleProduct(It.IsAny<WarehouseProduct>()))
               .Returns("Ok");

    var controller = new WarehouseController(mockService.Object);
    var product = new WarehouseProduct(1, 2, 100, DateTime.Now);

    // Act
    var result = controller.addProductToWarehouse(product);

    // Assert
    var okResult = Assert.IsType<OkResult>(result);
    Assert.Equal(200, okResult.StatusCode);
}

[Fact]
public void AddProductToWarehouse_ReturnsBadRequest_WhenServiceReturnsError()
{
    // Arrange
    var errorMessage = "Error: Invalid data";
    var mockService = new Mock<IWarehouseProductService>();
    mockService.Setup(service => service.handleProduct(It.IsAny<WarehouseProduct>()))
               .Returns(errorMessage);

    var controller = new WarehouseController(mockService.Object);
    var product = new WarehouseProduct(1, 2, 100, DateTime.Now);

    // Act
    var result = controller.addProductToWarehouse(product);

    // Assert
    var badRequestResult = Assert.IsType<ObjectResult>(result);
    Assert.Equal(400, badRequestResult.StatusCode);
    Assert.Equal(errorMessage, badRequestResult.Value);
}

[Fact]
public void AddProductToWarehouse_ReturnsInternalServerError_WhenExceptionIsThrown()
{
    // Arrange
    var mockService = new Mock<IWarehouseProductService>();
    mockService.Setup(service => service.handleProduct(It.IsAny<WarehouseProduct>()))
               .Throws(new Exception("Internal server error"));

    var controller = new WarehouseController(mockService.Object);
    var product = new WarehouseProduct(1, 2, 100, DateTime.Now);

    // Act
    var result = controller.addProductToWarehouse(product);

    // Assert
    var statusCodeResult = Assert.IsType<ObjectResult>(result);
    Assert.Equal(500, statusCodeResult.StatusCode);
    Assert.StartsWith("Błąd serwera", statusCodeResult.Value.ToString());
}

}