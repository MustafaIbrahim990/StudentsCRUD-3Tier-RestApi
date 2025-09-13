using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.UI.WinForms
{
    public class StudentDTO
    {
        //Properties :-
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }


        //Constructor :-
        public StudentDTO()
        {
            this.StudentID = -1;
            this.Name = "";
            this.Age = 0;
            this.Grade = 0;
        }
        public StudentDTO(int studentID, string name, int age, int grade)
        {
            this.StudentID = studentID;
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
    }
}