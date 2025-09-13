using Students.DAL;
using System.Data;

namespace Students.BLL
{
    public class Student
    {
        //Enums :-
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        //Properties :-
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }

        public StudentDTO studentDto
        {
            get { return (new StudentDTO(this.StudentID, this.Name, this.Age, this.Grade)); }
        }


        //Constructor :-
        public Student(StudentDTO studentDto, enMode eMode = enMode.AddNew)
        {
            this.StudentID = studentDto.StudentID;
            this.Name = studentDto.Name;
            this.Age = studentDto.Age;
            this.Grade = studentDto.Grade;

            Mode = eMode;
        }


        //Get All Students :-
        public static async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            return await StudentData.GetAllStudentsAsync();
        }


        //Get Passed Students :-
        public static async Task<List<StudentDTO>> GetPassedStudentsAsync()
        {
            return await StudentData.GetPassedStudentsAsync();
        }


        //Get Failed Students :-
        public static async Task<List<StudentDTO>> GetFailedStudentsAsync()
        {
            return await StudentData.GetFailedStudentsAsync();
        }


        //Get Average Grade :-
        public static async Task<double> GetAverageGradeAsync()
        {
            return await StudentData.GetAverageGradeAsync();
        }


        //Get Maximum Grade :-
        public static async Task<double> GetMaximumGradeAsync()
        {
            return await StudentData.GetMaximumGradeAsync();
        }


        //Get Minimum Grade :-
        public static async Task<double> GetMinimumGradeAsync()
        {
            return await StudentData.GetMinimumGradeAsync();
        }


        //Get Student By Id :-
        public static async Task<Student?> FindAsync(int StudentID)
        {
            StudentDTO studentDto = await StudentData.GetStudentByIdAsync(StudentID);

            if (studentDto != null)
                return new Student(studentDto, enMode.Update);
            else
                return null;
        }


        //Does Student Exist :-
        public static async Task<bool> DoesStudentExistAsync(int StudentID)
        {
            return await StudentData.DoesStudentExistAsync(StudentID);
        }


        //Add New Student :-
        private async Task<bool> _AddNewStudentAsync(StudentDTO studentDTO)
        {
            this.StudentID = await StudentData.AddNewStudentAsync(studentDTO);
            return (this.StudentID != -1);
        }


        //Update Student :-
        private async Task<bool> _UpdateStudentAsync()
        {
            return await StudentData.UpdateStudentAsync(this.studentDto);
        }


        //Save in (Add and Update) Mode :-
        public async Task<bool> Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (await _AddNewStudentAsync(this.studentDto))
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return await _UpdateStudentAsync();
                    }
            }
            return false;
        }


        //Delete Student :-
        public static async Task<bool> DeleteStudentAsync(int StudentID)
        {
            return await StudentData.DeleteStudentAsync(StudentID);
        }
    }
}