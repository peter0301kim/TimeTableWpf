﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Models
{
    public class Lecturers
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; } //It starts 1
        public int PageSize { get; set; }
        public List<Lecturer> Rows { get; set; }
    }
}
