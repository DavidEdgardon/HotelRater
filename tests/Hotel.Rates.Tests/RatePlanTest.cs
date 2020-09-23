using Hotel.Rates.Api.Controllers;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hotel.Rates.Tests
{
    public class RatePlanTest
    {
        [Fact]
        public void GetRatePlans_Return200Ok()
        {
            //arrange
            var serviceMock = new Mock<InventoryContext>();


            var controller = new RatePlansController(serviceMock.Object);

            //act
            var response = controller.Get();

            //assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Theory]
        [InlineData(-1)]
        public void GetRatePlansbyId_Return200Ok(int id)
        {
            //arrange
            var serviceMock = new Mock<InventoryContext>();

            /* serviceMock.Setup(c => c.GetPlanbyId(It.IsAny<int>()))
                 .Returns(ServiceResult<IEnumerable<InventoryContext>>.SuccessResult(
                     Enumerable.Empty<InventoryContext>()));
            */

            var controller = new RatePlansController(serviceMock.Object);

            //act
            var response = controller.Get();

            //assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
