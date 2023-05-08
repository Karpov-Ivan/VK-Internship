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

        public UserStateController(IUserStateRepository userStateRepository)
        {
            _userStateRepository = userStateRepository;
        }

        [Authorize]
        [HttpPost("Adding")]
        public async Task<IActionResult> AddUserStateAsync(UserStateDto userStateDto)
        {
            IActionResult response;

            try
            {
                await new UserStateHandler().AddUserStateInDBAsync(userStateDto, _userStateRepository);

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
                await new UserStateHandler().DeleteUserStateByModelAsync(userStateDto, _userStateRepository);

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
        [HttpDelete("DeletingByCode{enumState}")]
        public async Task<IActionResult> DeleteUserStateByCodeAsync(EnumState enumState)
        {
            IActionResult response;

            try
            {
                await new UserStateHandler().DeleteUserStateByCodeAsync(enumState, _userStateRepository);

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
        [HttpDelete("DeletingById{userStateId}")]
        public async Task<IActionResult> DeleteUserStateByIdAsync(long userStateId)
        {
            IActionResult response;

            try
            {
                await new UserStateHandler().DeleteUserStateByIdAsync(userStateId, _userStateRepository);

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
                await new UserStateHandler().ChangeUserStateAsync(userStateDto, _userStateRepository);

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
                var all_user_state = await new UserStateHandler().GetAllUserStateAsync(_userStateRepository);

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

