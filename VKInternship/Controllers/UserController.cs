﻿using System;
using DBCore;
using DBCore.Converters;
using DTOModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project;
using ProjectEnum;

namespace VKInternship.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        private readonly UserHandler _userHandler;

        public UserController(IUserRepository userRepository,
                              UserHandler userHandler)
        {
            _userRepository = userRepository;
            _userHandler = userHandler;
        }

        [Authorize]
        [HttpPost("Adding")]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            IActionResult response;

            try
            {
                await _userHandler.AddUserInDB(userDto, _userRepository);

                response = Ok();
            }
            catch (DuplicateWaitObjectException exception)
            {
                response = StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (ArgumentNullException exception)
            {
                response = StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [Authorize]
        [HttpDelete("DeletingByModel")]
        public async Task<IActionResult> DeleteUserByModel(UserDto userDto)
        {
            IActionResult response;

            try
            {
                await _userHandler.DeleteUserByModel(userDto, _userRepository);

                response = Ok();
            }
            catch (ArgumentNullException exception)
            {
                throw new ArgumentNullException(exception.Message);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

            return response;
        }

        [Authorize]
        [HttpDelete("DeletingById")]
        public async Task<IActionResult> DeleteUserById(long userId)
        {
            IActionResult response;

            try
            {
                await _userHandler.DeleteUserById(userId, _userRepository);

                response = Ok();
            }
            catch (ArgumentNullException exception)
            {
                response = StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpGet("GettingAll")]
        public async Task<IActionResult> GetAllUser()
        {
            IActionResult response;

            try
            {
                var all_user = await _userHandler.GetAllUser(_userRepository);

                response = Ok(all_user);
            }
            catch (ArgumentNullException exception)
            {
                response = StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpGet("GettingMultiple")]
        public async Task<IActionResult> GetMultipleUser(int count)
        {
            IActionResult response;

            try
            {
                var all_user = await _userHandler.GetMultipleUser(count, _userRepository);

                response = Ok(all_user);
            }
            catch (ArgumentNullException exception)
            {
                response = StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception exception)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }
    }
}
