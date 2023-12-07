using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myta.Domain.Common
{
    public class ApiResultFormatter
    {
        public object Formatted { get; private set; }
        public ApiResultFormatter(ApiStatus status, ApiCodes code, string? message, object? data)
        {
            this.Formatted = new
            {
                Status = status.ToString().ToLower(),
                Code = code.ToString().ToLower(),
                Message = message,
                Data = data
            };
        }
    }
}
