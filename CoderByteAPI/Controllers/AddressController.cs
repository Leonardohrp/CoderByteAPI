using CoderByteAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// <param name="zipCode">Formatação: 99999-999</param>      
        /// <returns> </returns>
        [HttpDelete("{idUser}/{zipCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAddressByUserIdAndZipCode([Required] int idUser, [Required] string zipCode)
        {
            try
            {
                await _service.DeleteAddressByUserIdAndZipCode(idUser, zipCode);

                return Ok(new { Success = true, Message = "Endereço deletado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }
    }
}
