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
    //[Authorize]
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
        public async Task<IActionResult> AddUserGroup(UserGroupDto userGroupDto)
        {
            IActionResult response;

            try
            {
                await _userGroupHandler.AddUserGroupInDB(userGroupDto, _userGroupRepository);

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
        public async Task<IActionResult> DeleteUserGroupByModel(UserGroupDto userGroupDto)
        {
            IActionResult response;

            try
            {
                await _userGroupHandler.DeleteUserGroupByModel(userGroupDto, _userGroupRepository);

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
        public async Task<IActionResult> DeleteUserGroupByCode(EnumGroup enumGroup)
        {
            IActionResult response;

            try
            {
                await _userGroupHandler.DeleteUserGroupByCode(enumGroup, _userGroupRepository);

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
        public async Task<IActionResult> DeleteUserGroupById(long userGroupId)
        {
            IActionResult response;

            try
            {
                await _userGroupHandler.DeleteUserGroupById(userGroupId, _userGroupRepository);

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
        public async Task<IActionResult> ChangeUserGroup(UserGroupDto userGroupDto)
        {
            IActionResult response;

            try
            {
                await _userGroupHandler.ChangeUserGroup(userGroupDto, _userGroupRepository);

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
        public async Task<IActionResult> GetAllUserGroup()
        {
            IActionResult response;

            try
            {
                var all_user_group = await _userGroupHandler.GetAllUserGroup(_userGroupRepository);

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

