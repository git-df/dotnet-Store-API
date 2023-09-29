using Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("SignIn")]
        public async Task<BaseResponse> SignIn()
        {
            return new BaseResponse(true);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<BaseResponse> SignUp()
        {
            return new BaseResponse(true);
        }
    }
}
