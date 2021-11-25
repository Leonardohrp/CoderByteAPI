using AutoMapper;
using CoderByteAPI.Dtos;
using CoderByteAPI.Models;
using CoderByteAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CoderByteAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Feature #01: User sign up
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUserWithAddress([FromBody] CreateUser createUser)
        {
            try
            {
                var userCreatedId = await _service.CreateUserWithAddress(createUser);

                return Ok(new { Success = true, Message = "Usuário criado com sucesso. Id inserido no campo Body.", Body = userCreatedId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        /// <summary>
        /// Feature #02: List user by its ID
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById([Required] int idUser)
        {
            try
            {
                var user = await _service.GetUserById(idUser);

                var userDto = _mapper.Map<UserDto>(user);

                return Ok(new { Success = true, Message = "Usuário encontrado com sucesso.", Body = userDto });
            }
            catch (Exception ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Feature #03: List user by its name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("userName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetListUsersByName([Required] string userName)
        {
            try
            {
                var userList = await _service.GetListUsersByName(userName);

                var userDtoList = _mapper.Map<List<UserDto>>(userList);

                return Ok(new { Success = true, Message = "Usuários encontrados com sucesso.", Body = userDtoList });
            }
            catch (Exception ex)
            {
                return NotFound(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Feature #04: Change user's information
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPut("idUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserById([FromBody] UpdateUser updateUser, [Required] int idUser)
        {
            try
            {
                var userUpdated = await _service.UpdateUserById(updateUser, idUser);

                var userUpdatedDto = _mapper.Map<UserUpdatedDto>(userUpdated);

                return Ok(new { Success = true, Message = "Usuário atualizado com sucesso.", Body = userUpdatedDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }

        /// <summary>
        /// Feature #05: Delete an user
        /// </summary>
        /// /// <param name="idUser"></param>
        /// <returns> </returns>
        [HttpDelete("idUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUserById([Required] int idUser)
        {
            try
            {
                await _service.DeleteUserById(idUser);

                return Ok(new { Success = true, Message = "Usuário deletado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Feature #06: List every address a user have
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("idUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAddressListByUserId([Required] int idUser)
        {
            try
            {
                var listOfAddress = await _service.GetAddressListByUserId(idUser);

                var addressListDto = _mapper.Map<List<AddressDto>>(listOfAddress);

                return Ok(new { Success = true, Message = "Endereços encontrados com sucesso.", Body = addressListDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }

        }
    }
}
