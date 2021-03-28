using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.Subject
{
    public interface ISubjectService
    {
        Task<ObservableCollection<Models.Subject>> GetAllSubjectsAsync(string subjectId, string token);
    }
}
