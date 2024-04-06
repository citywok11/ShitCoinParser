using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Cms;
using ShitCoinParser.Models;
using ShitCoinParser.Services.Interfaces;

namespace ShitCoinParser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShitCoinMetaDataController : Controller
    {
        private readonly IShitCoinMetaDataService _metaDataService;
        private readonly ILogger<ShitCoinMetaDataController> _logger;

        public ShitCoinMetaDataController(IShitCoinMetaDataService shitCoinMetaDataService, ILogger<ShitCoinMetaDataController> logger)
        {
            _metaDataService = shitCoinMetaDataService ?? throw new ArgumentNullException(nameof(shitCoinMetaDataService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("AllMetaData")]
        public async Task<ActionResult<List<ShitCoinMetaData>>> GetAllShitCoinMetaData()
        {
            try
            {
                var metaData = await _metaDataService.GetAllShitCoinMetaData();
                if (metaData == null || metaData.Count == 0)
                {
                    return NotFound("No ShitCoin metadata found.");
                }
                return Ok(metaData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching ShitCoin metadata.");
                return StatusCode(500, "An error occurred while fetching ShitCoin metadata.");
            }
        }

        [HttpGet]
        [Route("AllIds")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllIds()
        {
            try
            {
                var ids = await _metaDataService.GetAllShitCoinMetaDataIds();
                if (ids == null || ids.Count() == 0)
                {
                    return NotFound("No ShitCoin ids found.");
                }
                return Ok(ids);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching ShitCoin ids.");
                return StatusCode(500, "An error occurred while fetching ShitCoin ids.");
            }
        }
    }
}