﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApi.Models.ApiModels.Response
{
    public class Error
    {
        public string Message { get; set; }
        public string Reference { get; set; }
        public int ErrorCode { get; set; }
        
    }
}