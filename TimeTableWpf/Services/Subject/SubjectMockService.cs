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
        private List<Models.Subject> MockSubjects = new List<Models.Subject>()
        {
            new Models.Subject { SubjectId = "5C#W", SubjectName = "C# for Web Development" },
            new Models.Subject { SubjectId = "5DD",  SubjectName = "Database Design" },
            new Models.Subject { SubjectId = "5EWD", SubjectName = "E-Commerce Website Development" },
            new Models.Subject { SubjectId = "5JAW", SubjectName = "Java for Web - Basics" },
            new Models.Subject { SubjectId = "5TSD", SubjectName = "Team Software Development" }
        };

        public async Task<List<Models.Subject>> GetAllSubjectsAsync(string token, string destUrl, string subjectName)
        {
            await Task.Delay(10);

            if (!string.IsNullOrEmpty(token))
            {
                if (subjectName == "null")
                {
                    return MockSubjects;
                }
                else
                {
                    var returnValue = (from s in MockSubjects
                                       where s.SubjectId.Contains(subjectName)
                                       select s).ToList();
                    return returnValue;
                }
            }
            else
                return new List<Models.Subject>();
        }

    }
}
