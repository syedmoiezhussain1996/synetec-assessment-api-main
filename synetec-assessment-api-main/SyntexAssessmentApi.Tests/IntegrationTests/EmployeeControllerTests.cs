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
	public class EmployeeControllerTests
	{
		private Mock<IEmployeeService> _employeeServiceMock;
		private EmployeeController _employeeController;
		public EmployeeControllerTests()
		{
			//Arrange
			_employeeServiceMock = new Mock<IEmployeeService>();
			_employeeController = new EmployeeController(_employeeServiceMock.Object);
		}
		#region Gets
		[Fact]
		public async Task GetAllEmployeesAsync_ErrorOccurred_ShouldFail()
		{
			//Act			
			_employeeServiceMock.Setup(p => p.GetEmployeesAsync()).Returns(
			async () =>
			{
				throw new Exception();
			});
			var apiResponse = await _employeeController.GetAll().ConfigureAwait(false);
			// Assert
		
			Assert.IsType<BadRequestObjectResult>(apiResponse);
		}
		[Fact]
		public async Task GetAllEmployeesAsync_ShouldPass()
		{
			//Act
			_employeeServiceMock.Setup(p => p.GetEmployeesAsync()).Returns(
		async () => new List<EmployeeDto>()
		{
				new EmployeeDto(),
				new EmployeeDto(),
				new EmployeeDto(),
				new EmployeeDto(),
				new EmployeeDto(),
		});
			var apiResponse = await _employeeController.GetAll().ConfigureAwait(false);
			// Assert

			Assert.IsType<OkObjectResult>(apiResponse);
		}
		#endregion
	}
}
