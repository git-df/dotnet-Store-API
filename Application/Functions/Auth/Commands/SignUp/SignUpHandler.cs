using Application.Contracts.Persistence;
using Application.Functions.Offer.Commands.AddOffer;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignUp
{
    public class SignUpHandler : IRequestHandler<SignUpCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;

        public SignUpHandler(
            IMapper mapper,
            IAppUserRepository userRepository,
            UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<BaseResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignUpValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(false, null, validationResult);

            var existUser = await _userRepository.GetByEmail(request?.Email?.ToLower() ?? "");

            if (existUser != null)
                return new BaseResponse(false, "User exist");

            var appUser = _mapper.Map<AppUser>(request);

            var identityResult = await _userManager.CreateAsync(appUser, request?.Password ?? "");

            if (identityResult.Succeeded)
            {
                identityResult = await _userManager.AddToRoleAsync(appUser, "User");

                if (identityResult.Succeeded)
                    return new BaseResponse(true, "User created");
            }

            return new BaseResponse(false, "Something went wrong :(");
        }
    }
}
