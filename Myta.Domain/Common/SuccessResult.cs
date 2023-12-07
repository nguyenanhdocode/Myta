using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myta.Domain.Common
{
    public class SuccessResult : ApiResult
    {
        public SuccessResult()
            : base(ApiStatus.SUCCESS, ApiCodes.NONE, null, null) { }

        public SuccessResult(string message)
            : base(ApiStatus.SUCCESS, ApiCodes.NONE, message, null) { }

        public SuccessResult(object data)
            : base(ApiStatus.SUCCESS, ApiCodes.NONE, null, data) { }

        public SuccessResult(object data, string message)
            : base(ApiStatus.SUCCESS, ApiCodes.NONE, message, data) { }
    }
}
