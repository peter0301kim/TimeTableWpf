using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableWpf.Services.LecturerTimeTable
{
    public class LecturerTimeTableMockService : ILecturerTimeTableService
    {
        public async Task<List<Models.TimeTable>> GetAllLecturerTimeTableAsync(string token, string timeTableApiUrl, string param)
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
