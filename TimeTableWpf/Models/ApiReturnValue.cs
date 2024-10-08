﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Models
{
    public class ApiReturnValue<T>
    {
        public bool IsSuccess { get; set; }
        public T Object { get; set; } = default;
        public ApiReturnError Error { get; set; } = null;
    }

    public class ApiReturnError
    {
        public string displayMessage { get; set; }
        public string errorMessage { get; set; }
    }
}
