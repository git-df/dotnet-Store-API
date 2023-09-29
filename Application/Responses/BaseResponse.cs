using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public BaseResponse(bool success, string? message = null) 
        { 
            Success = success;
            Message = message;
        }
    }

    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public BaseResponse(bool success, string? message = null)
        {
            Success = success;
            Message = message;
        }

        public BaseResponse(T data, bool success, string? message = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
