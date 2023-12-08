using Myta.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myta.Domain.Services
{
    public interface IAccountService
    {
        public Task<ApiResult> SignUp(string email, string firstName, string lastName
            , string password);
    }
}
