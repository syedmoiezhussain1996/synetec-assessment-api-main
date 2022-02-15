using Microsoft.AspNetCore.Mvc;
using Moq;
using SynetecAssessmentApi.Controllers;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SyntexAssessmentApi.Tests.IntegrationTests
{
	public class BonusPoolControllerTests
	{
        private Mock<IBonusPoolService> _bonusPoolServiceMock;
        private BonusPoolController _bonusPoolController;
        public BonusPoolControllerTests()
		{
            //Arrange
            _bonusPoolServiceMock = new Mock<IBonusPoolService>();
            _bonusPoolController = new BonusPoolController(_bonusPoolServiceMock.Object);
        }
        #region Posts
        [Fact]
        public async Task CalculateBonusAsync_MissingBody_ShouldFail()
        {
            //Act & Assert
           var apiResponse= await _bonusPoolController.CalculateBonus(null).ConfigureAwait(false);
            Assert.IsType<BadRequestObjectResult>(apiResponse);
        }

        [Theory]
        [InlineData("test string")]
        [InlineData("")]
        public async Task CalculateBonusAsync_InValidBody_ShouldFail(dynamic body)
        {
           
            //Act & Assert
            Assert.ThrowsAsync<ArgumentException>( async () => await _bonusPoolController.CalculateBonus(body).ConfigureAwait(false));
        }

        [Fact]
        public async Task CalculateBonusAsync_InValidData_ShouldFail()
        {
            
            var dto = new CalculateBonusDto();

            // Act
            var apiResponse = await _bonusPoolController.CalculateBonus(dto).ConfigureAwait(false);

            // Assert
            Assert.IsType<BadRequestObjectResult>(apiResponse);
        }

        [Fact]
        public async Task CalculateBonusAsync_ValidData_ShouldPass()
        {
            var dto = new CalculateBonusDto();
            //Arrange			
            _bonusPoolServiceMock.Setup(p => p.CalculateAsync(0,0)).Returns(
          async () => new BonusPoolCalculatorResultDto());
           

            // Act
            var apiResponse = await _bonusPoolController.CalculateBonus(dto).ConfigureAwait(false);

            // Assert
            Assert.IsType<OkObjectResult>(apiResponse);
        }

        #endregion

    }
}
