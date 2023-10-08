using Application.Contracts.Persistence;
using Application.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Queries.GetUserInfo
{
    public class GetUserInfoHandler : IRequestHandler<GetUserInfoQuery, BaseResponse<GetUserInfoDto?>>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserInfoHandler(
            IAppUserRepository appUserRepository,
            IUserService userService,
            IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetUserInfoDto?>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var user = await _appUserRepository.GetById(_userService.GetUserId() ?? Guid.Empty);

            if (user == null)
                return new BaseResponse<GetUserInfoDto?>(false, "User not found");

            return new BaseResponse<GetUserInfoDto?>(
                _mapper.Map<GetUserInfoDto>(user), true);
        }
    }
}
