using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.Subject
{
    public interface ISubjectService
    {
        Task<List<Models.Subject>> GetAllSubjectsAsync(string token, string destUrl, string subjectName);
    }
}
