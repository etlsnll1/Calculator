using Calculator.InterfaceSpecifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayCalcController : ControllerBase
    {
        private readonly ILogger<ArrayCalcController> _logger;
        private readonly IArrayService _arrayService;

        public ArrayCalcController(IArrayService arrayService, ILogger<ArrayCalcController> logger)
        {
            _arrayService = arrayService;
            _logger = logger;
        }

        [HttpGet("Reverse")]
        public ActionResult Reverse([FromQuery] int[] productIds)
        {
            try 
            {
                var result = _arrayService.Reverse(productIds);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception thrown processing: Reverse");
                return Error500();
            }
        }

        [HttpGet("DeletePart")]
        public ActionResult DeletePart([FromQuery] int[] productIds, [FromQuery] int position)
        {
            try
            {
                var result = _arrayService.DeletePart(productIds, position);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception thrown processing: DeletePart");
                return Error500();
            }
        }

        private StatusCodeResult Error500()
        {
            return StatusCode(500);
        }
    }
}
