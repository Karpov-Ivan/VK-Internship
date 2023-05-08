using System;
using Azure;
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

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpPost("Adding")]
        public async Task<IActionResult> AddUserAsync(UserDto userDto)
        {
            IActionResult response;

            try
            {
                await new UserHandler().AddUserInDBAsync(userDto, _userRepository);

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
        public async Task<IActionResult> DeleteUserByModelAsync(UserDto userDto)
        {
            IActionResult response;

            try
            {
                await new UserHandler().DeleteUserByModelAsync(userDto, _userRepository);

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
        [HttpDelete("DeletingById{userId}")]
        public async Task<IActionResult> DeleteUserByIdAsync(long userId)
        {
            IActionResult response;

            try
            {
                await new UserHandler().DeleteUserByIdAsync(userId, _userRepository);

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
        public async Task<IActionResult> GetAllUserAsync()
        {
            IActionResult response;

            try
            {
                var all_user = await new UserHandler().GetAllUserAsync(_userRepository);

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

        [HttpGet("GettingMultiple{skip}/{count}")]
        public async Task<IActionResult> GetMultipleUserAsync(int skip, int count)
        {
            IActionResult response;

            try
            {
                var all_user = await new UserHandler().GetMultipleUserAsync(skip, count, _userRepository);

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

        [HttpGet("GettingMultiple{userId}")]
        public async Task<IActionResult> GetUserByIdAsync(int userId)
        {
            IActionResult response;

            try
            {
                var user = await new UserHandler().GetUserByIdAsync(userId, _userRepository);

                response = Ok(user);
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

