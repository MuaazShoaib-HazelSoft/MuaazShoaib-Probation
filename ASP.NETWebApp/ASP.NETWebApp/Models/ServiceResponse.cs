﻿namespace ASP.NETWebApp.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; } = " ";
        public bool Success { get; set; } = true;
        public int httpCode { get; set; } = 0;
    }
}
