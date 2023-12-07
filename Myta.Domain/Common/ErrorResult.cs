using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myta.Domain.Common
{
    public class ErrorResult : ApiResult
    {
        public ErrorResult(ApiCodes code)
            : base(ApiStatus.ERROR, code, null, null) { }

        public ErrorResult(ApiCodes code, string message)
            : base(ApiStatus.ERROR, code, message, null) { }

        public ErrorResult(ApiCodes code, string message, object data)
            : base(ApiStatus.ERROR, code, message, data) { }
    }
}
