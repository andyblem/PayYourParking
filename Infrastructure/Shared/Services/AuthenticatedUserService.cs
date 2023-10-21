using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public string UserId()
        {
            return "ToDo";
        }
    }
}
