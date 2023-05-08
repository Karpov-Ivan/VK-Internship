using System;
using Azure;
using DBCore;
using DBCore.Converters;
using DBModels;
using DTOModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project;
using ProjectEnum;

namespace VKInternship.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class UserGroupController : Controller
    {
        private readonly IUserGroupRepository _userGroupRepository;

        private readonly UserGroupHandler _userGroupHandler;

        public UserGroupController(IUserGroupRepository userGroupRepository,
                                   UserGroupHandler userStateHandler)
		{
            _userGroupRepository = userGroupRepository;
            _userGroupHandler = userStateHandler;
		}

        [Authorize]
        [HttpPost("Adding")]
        public async Task<IActionResult> AddUserGroupAsync(UserGroupDto userGroupDto)
        {
            IActionResult response;

            try
            {
                await _userGroupHandler.AddUserGroupInDBAsync(userGroupDto, _userGroupRepository);

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
        public async Task<IActionResult> DeleteUserGroupByModelAsync(UserGroupDto userGroupDto)
        {
            IActionResult response;

            try
            {
                await _userGroupHandler.DeleteUserGroupByModelAsync(userGroupDto, _userGroupRepository);

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
        public async Task<IActionResult> DeleteUserGroupByCodeAsync(EnumGroup enumGroup)
        {
            IActionResult response;

            try
            {
                await _userGroupHandler.DeleteUserGroupByCodeAsync(enumGroup, _userGroupRepository);

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
        public async Task<IActionResult> DeleteUserGroupByIdAsync(long userGroupId)
        {
            IActionResult response;

            try
            {
                await _userGroupHandler.DeleteUserGroupByIdAsync(userGroupId, _userGroupRepository);

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
        public async Task<IActionResult> ChangeUserGroupAsync(UserGroupDto userGroupDto)
        {
            IActionResult response;

            try
            {
                await _userGroupHandler.ChangeUserGroupAsync(userGroupDto, _userGroupRepository);

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
        public async Task<IActionResult> GetAllUserGroupAsync()
        {
            IActionResult response;

            try
            {
                var all_user_group = await _userGroupHandler.GetAllUserGroupAsync(_userGroupRepository);

                response = Ok(all_user_group);
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

