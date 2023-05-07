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
        public async Task<IActionResult> AddUserState(UserStateDto userStateDto)
        {
            IActionResult response;

            try
            {
                await _userStateHandler.AddUserStateInDB(userStateDto, _userStateRepository);

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
        public async Task<IActionResult> DeleteUserStateByModel(UserStateDto userStateDto)
        {
            IActionResult response;

            try
            {
                await _userStateHandler.DeleteUserStateByModel(userStateDto, _userStateRepository);

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
        public async Task<IActionResult> DeleteUserStateByCode(EnumState enumState)
        {
            IActionResult response;

            try
            {
                await _userStateHandler.DeleteUserStateByCode(enumState, _userStateRepository);

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
        public async Task<IActionResult> DeleteUserStateById(long userStateId)
        {
            IActionResult response;

            try
            {
                await _userStateHandler.DeleteUserStateById(userStateId, _userStateRepository);

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
        public async Task<IActionResult> ChangeUserState(UserStateDto userStateDto)
        {
            IActionResult response;

            try
            {
                await _userStateHandler.ChangeUserState(userStateDto, _userStateRepository);

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
        public async Task<IActionResult> GetAllUserState()
        {
            IActionResult response;

            try
            {
                var all_user_state = await _userStateHandler.GetAllUserState(_userStateRepository);

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

