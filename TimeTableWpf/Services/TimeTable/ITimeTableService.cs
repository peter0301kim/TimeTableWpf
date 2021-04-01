using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.TimeTable
{
    public interface ITimeTableService
    {
        Task<List<Models.TimeTable>> GetAllTimeTableAsync(string token, string timeTableApiUrl, string param);
    }
}
