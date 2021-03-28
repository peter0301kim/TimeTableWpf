using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.Lecturer
{
    public class LecturerMockService : ILecturerService
    {
        public async Task<List<Models.Lecturer>> GetAllLecturerAsync(string destUrl, string token)
        {
            return await Task.Run(() =>
            {
                List<Models.Lecturer> lecturers = new List<Models.Lecturer>() {
                    new Models.Lecturer(){LecturerId  = "L30001", GivenName = "Charlotte", LastName = "Smith", EmailAddress = "Charlotte@aaa.com"},
                    new Models.Lecturer(){LecturerId  = "L30002", GivenName = "Olivia", LastName = "Jones", EmailAddress = "Olivia@aaa.com"},
                    new Models.Lecturer(){LecturerId  = "L30003", GivenName = "Amelia", LastName = "Williams", EmailAddress = "Amelia@aaa.com"},
                };

                return lecturers;
            });
        }
    }
}
