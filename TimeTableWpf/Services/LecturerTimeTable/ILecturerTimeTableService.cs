using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.LecturerTimeTable
{
    public interface ILecturerTimeTableService
    {
        Task<List<Models.TimeTable>> GetAllLecturerTimeTableAsync(string token, string timeTableApiUrl, string param);
    }
}
