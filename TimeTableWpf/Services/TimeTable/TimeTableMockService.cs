using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeTableWpf.Models;

namespace TimeTableWpf.Services.TimeTable
{
    public class TimeTableMockService : ITimeTableService
    {

        public async Task<List<Models.TimeTable>> GetAllTimeTableAsync(string timeTableApiUrl, string token)
        {
            return await Task.Run(() =>
            {
                List<Models.TimeTable> timeTables = new List<Models.TimeTable>() {
                    new Models.TimeTable()
                    {
                        Crn = "CR10001", DayOfWeek = "", ClassTime = "", Campus = "", SubjectCode = "", SubjectDesc = "",
                        ClassRoom = "", LecturerId = "",LecturerName = "",StartTerm = "1",EndTerm = "4"
                    },
                    new Models.TimeTable(){
                        Crn = "CR10002", DayOfWeek = "", ClassTime = "", Campus = "", SubjectCode = "", SubjectDesc = "",
                        ClassRoom = "", LecturerId = "",LecturerName = "",StartTerm = "1",EndTerm = "4"
                    },
                    new Models.TimeTable() {
                        Crn = "CR10003", DayOfWeek = "", ClassTime = "", Campus = "", SubjectCode = "", SubjectDesc = "",
                        ClassRoom = "", LecturerId = "",LecturerName = "",StartTerm = "1",EndTerm = "4"
                    },
                };

                return timeTables;

            });
        }
    }
}
