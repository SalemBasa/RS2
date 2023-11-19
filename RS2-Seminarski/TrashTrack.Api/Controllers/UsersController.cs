using Microsoft.AspNetCore.Mvc;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using AutoMapper;
using TrashTrack.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TrashTrack.Api.Controllers
{
    public class UsersController : BaseCrudController<UserDto, UserUpsertDto, UserSearchObject, IUsersService>
    {
        private readonly IMapper _mapper;

        public UsersController(IUsersService service, IMapper mapper, ILogger<UsersController> logger) : base(service, logger)
        {
            _mapper = mapper;
        }

        [HttpGet("GetCountByRole")]
        public async Task<IActionResult> GetCountByRole(Role role, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await Service.GetCountByRoleAsync(role, cancellationToken);
                return Ok(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error while getting total users");
                return BadRequest();
            }
        }

        [NonAction]
        public override Task<IActionResult> Post(UserUpsertDto upsertDto, CancellationToken cancellationToken = default) => base.Post(upsertDto, cancellationToken);

        [NonAction]
        public override Task<IActionResult> Put(UserUpsertDto upsertDto, CancellationToken cancellationToken = default) => base.Put(upsertDto, cancellationToken);

        [Authorize]
        [HttpPut("PutUser")]
        public async Task<IActionResult> PutUser([FromBody] UserUpdateModel model, CancellationToken cancellationToken = default)
        {
            var userDto = _mapper.Map<UserUpsertDto>(model);
            var user = await Service.UpdateUserAsync(userDto, cancellationToken);

            return Ok(user);
        }

        [HttpGet("UserCount")]
        public async Task<IActionResult> GetUserCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await Service.GetUserCountAsync(cancellationToken);

            return Ok(count);
        }

        [HttpGet("DriverCount")]
        public async Task<IActionResult> GetDriverCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await Service.GetDriverCountAsync(cancellationToken);

            return Ok(count);
        }

        [HttpGet("AdministratorCount")]
        public async Task<IActionResult> GetAdministratorCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await Service.GetAdministratorCountAsync(cancellationToken);

            return Ok(count);
        }
    }
}
