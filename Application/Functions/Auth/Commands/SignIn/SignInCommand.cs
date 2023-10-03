using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignIn
{
    public class SignInCommand : IRequest<BaseResponse<string?>>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
