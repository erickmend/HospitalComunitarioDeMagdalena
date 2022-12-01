using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs.Responses
{
    public class Response<T>
    {

        public Response(InternalStatusCodes statusCode, T? data)
        {
            InternalStatusCode = statusCode;
            StatusCode = GetStatusCode();
            Success = IsOk();

            if (!Success)
            {
                Errors = new MesssageResponse(statusCode);
            }
            else
            {
                Result = data;
                Message = new MesssageResponse(statusCode);
            }
        }
        public Response(InternalStatusCodes statusCode, T data, object entity)
        {
            InternalStatusCode = statusCode;
            StatusCode = GetStatusCode();
            Success = IsOk();
            Entity = entity;
            if (!Success)
            {
                Errors = new MesssageResponse(statusCode);
            }
            else
            {
                Result = data;
                Message = new MesssageResponse(statusCode);
            }
        }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public T? Result { get; set; }
        public MesssageResponse? Message { get; set; }

        public MesssageResponse? Errors { get; set; }


        [JsonIgnore]
        public InternalStatusCodes InternalStatusCode { get; set; }
        [JsonIgnore]
        public object? Entity { get; set; }

        private bool IsOk()
        {
            int statusCodeInt = (int)InternalStatusCode;
            return (statusCodeInt >= 600 && statusCodeInt <= 699) ? false : true;
        }
        private int GetStatusCode()
        {
            switch (InternalStatusCode)
            {
                case InternalStatusCodes.CreateEntity_Ok:
                    return StatusCodes.Status201Created;

                case InternalStatusCodes.UpdateEntity_Ok:
                case InternalStatusCodes.DeleteEntity_Ok:
                    return StatusCodes.Status202Accepted;

                case InternalStatusCodes.GetEntity_Ok:
                case InternalStatusCodes.GetList_Ok:
                    return StatusCodes.Status200OK;


                case InternalStatusCodes.CreateEntity_ERROR:
                    return StatusCodes.Status400BadRequest;
                case InternalStatusCodes.UpdateEntity_ERROR:
                case InternalStatusCodes.DeleteEntity_ERROR:
                    return StatusCodes.Status304NotModified;

                case InternalStatusCodes.GetEntity_ERROR:
                case InternalStatusCodes.GetList_ERROR:
                    return StatusCodes.Status404NotFound;

                case InternalStatusCodes.Unknown_ERROR:
                default:
                    return StatusCodes.Status500InternalServerError;
            }
        }
    }
}
