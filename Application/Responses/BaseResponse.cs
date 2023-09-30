using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public BaseResponse(bool success, string? message = null, ValidationResult? validationResult = null) 
        { 
            Success = success;
            Message = message;
            ValidationResult = validationResult ?? new ValidationResult();
        }
    }

    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public T? Data { get; set; }

        public BaseResponse(bool success, string? message = null, ValidationResult? validationResult = null)
        {
            Success = success;
            Message = message;
            ValidationResult = validationResult ?? new ValidationResult();
        }

        public BaseResponse(T data, bool success, string? message = null, ValidationResult? validationResult = null)
        {
            Success = success;
            Message = message;
            ValidationResult = validationResult ?? new ValidationResult();
            Data = data;
        }
    }
}
