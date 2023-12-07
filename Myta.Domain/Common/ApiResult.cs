using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myta.Domain.Common
{
    public class ApiResult
    {
        public ApiResult(ApiStatus status, ApiCodes code, string message, object data)
        {
            Status = status;
            Code = code;
            Message = message;
            Data = data;
        }

        public static List<ApiCodes> SuccessCodes = new List<ApiCodes>
        {
            ApiCodes.NONE
        };

        public ApiStatus Status { get; set; }
        public ApiCodes Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool IsSuccess { get => SuccessCodes.IndexOf(Code) != -1; }

        public ObjectResult Result
        {
            get => new ObjectResult(new ApiResultFormatter(Status, Code, Message, Data).Formatted);
        }

        public T? GetData<T>() where T : class
        {
            return this.Data != null ? this.Data as T : null;
        }
    }
}
