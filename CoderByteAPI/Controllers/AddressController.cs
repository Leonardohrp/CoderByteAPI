using CoderByteAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;
        public AddressController(IAddressService service)
        {
            _service = service;
        }

        /// <summary>
        /// Feature #05: Delete an user
        /// </summary>
        /// <returns> </returns>
        [HttpDelete("idUser/ziCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAddressById(int idUser, string ziCode)
        {
            try
            {
                bool isAddressrDeleted = await _service.DeleteAddressById(idUser, ziCode);

                return Ok(new { Success = isAddressrDeleted, Message = "Endereço deletado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
    }
}
