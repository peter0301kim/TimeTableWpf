using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.Subject
{
    public class SubjectMockService : ISubjectService
    {
        private ObservableCollection<Models.Subject> MockSubjects = new ObservableCollection<Models.Subject>()
        {
            new Models.Subject { SubjectId = "5C#W", SubjectName = "C# for Web Development" },
            new Models.Subject { SubjectId = "5DD",  SubjectName = "Database Design" },
            new Models.Subject { SubjectId = "5EWD", SubjectName = "E-Commerce Website Development" },
            new Models.Subject { SubjectId = "5JAW", SubjectName = "Java for Web - Basics" },
            new Models.Subject { SubjectId = "5TSD", SubjectName = "Team Software Development" }
        };

        public async Task<ObservableCollection<Models.Subject>> GetAllSubjectsAsync(string sId, string token)
        {
            await Task.Delay(10);

            if (!string.IsNullOrEmpty(token))
            {
                if (sId == "null")
                {
                    return MockSubjects;
                }
                else
                {
                    var tmpS = MockSubjects.Where(s => s.SubjectId.Contains(sId));
                    ObservableCollection<Models.Subject> subjects = new ObservableCollection<Models.Subject>(tmpS);
                    return subjects;
                }
            }
            else
                return new ObservableCollection<Models.Subject>();
        }

    }
}
