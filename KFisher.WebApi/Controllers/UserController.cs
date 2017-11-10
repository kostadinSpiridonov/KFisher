using AutoMapper;
using KFisher.Library.DTOs;
using KFisher.WebApi.Models.InputModels;
using KFisher.WebApi.Models.OutputModels;
using KFishers.Managers;
using System.Threading.Tasks;
using System.Web.Http;

namespace KFisher.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedModel = Mapper.Map<UserDto>(model);
            var result = await userManager.Add(mappedModel);
            if (result == null)
            {
                return InternalServerError();
            }

            return Ok(Mapper.Map<BaseUserModel>(result));
        }
    }
}