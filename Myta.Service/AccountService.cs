using Myta.Domain.Common;
using Myta.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myta.Service
{
    public class AccountService : IAccountService
    {
        public async Task<ApiResult> SignUp(string email, string firstName, string lastName
            , string password)
        {
            return null;
        }
    }
}
