﻿using InvestmentPoint.Admin.App.IUtilitiesServices;

namespace InvestmentPoint.Admin.App.UtilitiesServices
{
    public class Response<T>
    {
        public Response()
        {

        }
        public Response(T data,string message = null)
        {
            Succeeded = false;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            Succeeded = true;   
            Message = message;
        }
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
