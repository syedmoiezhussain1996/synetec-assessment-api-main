using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        public IBonusPoolService _bonusPoolService;
        public BonusPoolController(
            IBonusPoolService bonusPoolService
            )
        {
            _bonusPoolService = bonusPoolService;
        }

        [HttpPost()]
        public async Task<IActionResult> CalculateBonus([FromBody] CalculateBonusDto request)
        {
            try
            {
                if (request == null)
                    return BadRequest("Invalid object");

                var response = await _bonusPoolService.CalculateAsync(
                    request.TotalBonusPoolAmount,
                    request.SelectedEmployeeId);

                if (response == null)
                    return BadRequest("Invalid Employee Id");

                return Ok(response);
            }
            catch
            {
                return BadRequest("An error occurred.");
            }

        }
    }
}
