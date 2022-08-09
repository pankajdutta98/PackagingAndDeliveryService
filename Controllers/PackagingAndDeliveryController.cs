using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackagingAndDeliveryService.Repository.IRepository;
using System;

namespace PackagingAndDeliveryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class PackagingAndDeliveryController : ControllerBase
    {
        private readonly IPackagingAndDeliveryRepo _repo;

        public PackagingAndDeliveryController(IPackagingAndDeliveryRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("GetPackagingDeliveryCharge")]
        public IActionResult getPackagingDeliveryCharge([FromQuery] char ItemType, [FromQuery] int Qty)
        {
            try
            {
                if (Qty == 0)
                {
                    return BadRequest(new { message = "Invalid Request" });
                }

                if (ItemType == 'I' || ItemType == 'A')
                {
                    double PackagingAndDeliveryCharge = 0;
                    PackagingAndDeliveryCharge = _repo.CalculatePackagingAndDeliveryCharges(ItemType, Qty);
                    return Ok(PackagingAndDeliveryCharge);
                }
                else
                {
                    return BadRequest(new { message = "Invalid Request" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
