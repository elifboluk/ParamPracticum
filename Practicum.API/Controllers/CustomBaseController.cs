using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practicum.Core.DTOs;

namespace Practicum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
                return new OkObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            return new OkObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
