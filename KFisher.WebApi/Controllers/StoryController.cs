using AutoMapper;
using KFisher.Library.DTOs;
using KFisher.WebApi.Models.InputModels;
using KFishers.Managers;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using KFisher.WebApi.Extensions;
using KFisher.WebApi.Models.OutputModels;

namespace KFisher.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/story")]
    public class StoryController : ApiController
    {
        private IStoryManager storyManager;

        public StoryController(IStoryManager storyManager)
        {
            this.storyManager = storyManager;
        }

        [AllowAnonymous]
        [Route("add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add(AddStoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedModel = Mapper.Map<StoryDto>(model);
            mappedModel.UserId = this.GetUserId();

            var result = await storyManager.Add(mappedModel);
            if (result == null)
            {
                return InternalServerError();
            }

            return Ok(Mapper.Map<BaseStoryModel>(result));
        }

        [AllowAnonymous]
        [Route("add")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAll(PaginationRequestModel model)
        {
            var mappedModel = Mapper.Map<PaginationRequestDto>(model);
            var result = await storyManager.GetAll(mappedModel);
            if (result == null)
            {
                return InternalServerError();
            }

            return Ok(Mapper.Map<BaseStoryModel>(result));
        }
    }
}
