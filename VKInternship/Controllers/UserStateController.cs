using System;
using DBCore;
using DTOModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project;
using ProjectEnum;

namespace VKInternship.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class UserStateController : Controller
    {
        private readonly IUserStateRepository _userStateRepository;

        private readonly UserStateHandler _userStateHandler;

        public UserStateController(IUserStateRepository userStateRepository,
                                   UserStateHandler userStateHandler)
        {
            _userStateRepository = userStateRepository;
            _userStateHandler = userStateHandler;
        }

        [Authorize]
        [HttpPost("Adding")]
        public async Task<IActionResult> AddUserStateAsync(UserStateDto userStateDto)
        {
            IActionResult response;

            try
            {
                await _userStateHandler.AddUserStateInDBAsync(userStateDto, _userStateRepository);

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
        public async Task<IActionResult> DeleteUserStateByModelAsync(UserStateDto userStateDto)
        {
            IActionResult response;

            try
            {
                await _userStateHandler.DeleteUserStateByModelAsync(userStateDto, _userStateRepository);

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
        [HttpDelete("DeletingByCode")]
        public async Task<IActionResult> DeleteUserStateByCodeAsync(EnumState enumState)
        {
            IActionResult response;

            try
            {
                await _userStateHandler.DeleteUserStateByCodeAsync(enumState, _userStateRepository);

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

        [Authorize]
        [HttpDelete("DeletingById")]
        public async Task<IActionResult> DeleteUserStateByIdAsync(long userStateId)
        {
            IActionResult response;

            try
            {
                await _userStateHandler.DeleteUserStateByIdAsync(userStateId, _userStateRepository);

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

        [Authorize]
        [HttpPatch("Changing")]
        public async Task<IActionResult> ChangeUserStateAsync(UserStateDto userStateDto)
        {
            IActionResult response;

            try
            {
                await _userStateHandler.ChangeUserStateAsync(userStateDto, _userStateRepository);

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

        [HttpGet("Getting")]
        public async Task<IActionResult> GetAllUserStateAsync()
        {
            IActionResult response;

            try
            {
                var all_user_state = await _userStateHandler.GetAllUserStateAsync(_userStateRepository);

                response = Ok(all_user_state);
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

