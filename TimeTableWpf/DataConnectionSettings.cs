using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf
{
    public class DataConnectionSettings
    {
        public DataConnectionMode DataConnectionMode { get; set; }
        public string ConnectionString { get; set; }
    }


    public enum DataConnectionMode
    {
        Mock,
        WebAPI,
    }
}
