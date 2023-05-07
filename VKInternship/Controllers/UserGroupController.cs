using System;
using DBCore;
using DTOModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project;

namespace VKInternship.Controllers
{
    //[Authorize]
    [ApiController]
    [Route(template: "api/[controller]")]
    public class UserGroupController : Controller
    {
        private readonly IUserGroupRepository _userGroupRepository;

        private readonly UserStateHandler _userStateHandler;

        public UserGroupController(IUserGroupRepository userGroupRepository,
                                   UserStateHandler userStateHandler)
		{
            _userGroupRepository = userGroupRepository;
            _userStateHandler = userStateHandler;
		}

        [HttpPost("Adding")]
        public async Task<IActionResult> AddUserGroup(UserGroupDto userGroupDto)
        {
            IActionResult response;

            try
            {
                _userStateHandler.AddUserGroupInDB(userGroupDto, _userGroupRepository);

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
    }
}

