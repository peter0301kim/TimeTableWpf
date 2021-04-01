using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTableWpf.Models;

namespace TimeTableWpf.Services.TimeTable
{
    public class TimeTableMockService : ITimeTableService
    {

        public async Task<List<Models.TimeTable>> GetAllTimeTableAsync(string token, string timeTableApiUrl, string param)
        {
            return await Task.Run(() =>
            {
                List<Models.TimeTable> timeTables = new List<Models.TimeTable>() {
                    new Models.TimeTable()
                    {
                        Crn = "CR10001", DayOfWeek = "Mon", ClassTime = "11:00-13:00", Campus = "City Campus", SubjectCode = "IT-1000000001", SubjectDesc = "The Complete 2021 Web Development Bootcamp",
                        ClassRoom = "C101", LecturerId = "LE-97898",LecturerName = "Lee",StartTerm = "1",EndTerm = "4"
                    },
                    new Models.TimeTable(){
                        Crn = "CR10002", DayOfWeek = "Tue", ClassTime = "14:00-16:00", Campus = "City East Campus", SubjectCode = "DE-3600000002", SubjectDesc = "Complete Blender Creator: Learn 3D Modelling for Beginners",
                        ClassRoom = "C305", LecturerId = "LE-20098",LecturerName = "Williams",StartTerm = "1",EndTerm = "4"
                    },
                    new Models.TimeTable() {
                        Crn = "CR10003", DayOfWeek = "Wed", ClassTime = "10:00-12:00", Campus = "City Campus", SubjectCode = "IT-1000000003", SubjectDesc = "Python for Data Science and Machine Learning",
                        ClassRoom = "A205", LecturerId = "LE-30989",LecturerName = "Ted",StartTerm = "1",EndTerm = "4"
                    },
                };

                return timeTables;

            });
        }
    }
}
