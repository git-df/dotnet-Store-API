﻿using Application.Functions.Auth.Commands.SignIn;
using Application.Functions.Auth.Commands.SignUp;
using Application.Functions.Auth.Queries.GetUserInfo;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<BaseResponse<string?>> SignIn([FromBody] SignInCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<BaseResponse> SignUp([FromBody] SignUpCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserInfo")]
        public async Task<BaseResponse<GetUserInfoDto?>> GetUserInfo()
        {
            return await _mediator.Send(new GetUserInfoQuery());
        }
    }
}
