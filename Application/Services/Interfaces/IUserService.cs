using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        public Guid? GetUserId();
        public string? GetUserName();
        public ClaimsPrincipal GetUser();
        public bool IsAuthenticated();
    }
}
