using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.Lecturer
{
    public interface ILecturerService
    {
        Task<List<Models.Lecturer>> GetAllLecturerAsync(string timeTableApiUrl, string token);
    }
}
