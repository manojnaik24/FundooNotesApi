using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class ResponseModel<T>
    {
        public bool status {  get; set; }

        public string message { get; set; }

        public T data { get; set; }
    }
}
