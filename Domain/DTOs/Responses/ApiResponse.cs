using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Responses
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public object? Result { get; set; }
        public MesssageResponse? Message { get; set; }
        public MesssageResponse? Errors { get; set; }
    }
}
