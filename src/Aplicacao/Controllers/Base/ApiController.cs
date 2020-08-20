using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers.Base
{
    public class ApiController : ControllerBase
    {
        protected new IActionResult Response(object result = null, string message = "")
        {
            if (result != null)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = message
            });
        }

        protected IActionResult ResponseError(object error)
        {
            return BadRequest(new
            {
                success = false,
                errors = error
            });
        }
    }
}
