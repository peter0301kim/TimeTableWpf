using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTableWpf.Models
{
    public class Lecturer
    {
        public string LecturerId { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public const string DEF_LECTURER_ID = "DEF_SUBJECT_ID";
        public const string DEF_GIVEN_NAME = "DEF_GIVEN_NAME";
        public const string DEF_LAST_NAME = "DEF_LAST_NAME";
        public const string DEF_EMAIL_ADDRESS = "DEF_EMAIL_ADDRESS";
        public Lecturer(string lecturerId, string givenName, string lastName, string emailAddress)
        {
            this.LecturerId = lecturerId;
            this.GivenName = givenName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
        }
        public Lecturer() : this(DEF_LECTURER_ID, DEF_GIVEN_NAME, DEF_LAST_NAME, DEF_EMAIL_ADDRESS)
        {

        }
    }
}
