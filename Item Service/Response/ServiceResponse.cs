﻿namespace Item_Service.Response
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Succcess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }

}
