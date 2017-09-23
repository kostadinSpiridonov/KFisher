using KFisher.Library.DTOs;
using KFishers.Managers;
using System.Threading.Tasks;
using System.Web.Http;

namespace KFisher.WebApi.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAuthenticationManager authenticationManager;

        public AccountController(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserDto userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var result = await authenticationManager.Create(userModel);
            var result = new UserDto();

            if (result != null)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}