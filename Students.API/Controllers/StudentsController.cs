using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StudentApi.Data_Simulation;
using StudentApi.Model;
using Students.BLL;
using Students.DAL;
using System.Data;

namespace StudentApi.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //Private Methods :-
        private ActionResult HandleException(Exception ex)
        {
            return ex switch
            {
                SqlException sqlex => StatusCode(StatusCodes.Status500InternalServerError, $"Database error : {sqlex.Message}"),
                _=> StatusCode(StatusCodes.Status500InternalServerError, $"Unexpected error : {ex.Message}")
            };
        }


        //Get All Students :-
        [HttpGet("All", Name = "GetAllStudentsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudentsAsync()
        {
            try
            {
                List<StudentDTO> StudentsList = await Students.BLL.Student.GetAllStudentsAsync();

                if (StudentsList.Count == 0)
                    return NotFound("No Students Found!");

                return Ok(StudentsList);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        //Get Passed Students :-
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Passed", Name = "GetPassedStudentsAsync")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetPassedStudentsAsync()
        {
            try
            {
                List<StudentDTO> PassedStudentsList = await Students.BLL.Student.GetPassedStudentsAsync();

                if (PassedStudentsList.Count == 0)
                    return NotFound("No Students Found!");

                return Ok(PassedStudentsList);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        //Get Failed Students :-
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Failed", Name = "GetFailedStudentsAsync")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetFailedStudentsAsync()
        {
            try
            {
                List<StudentDTO> FailedStudentsList = await Students.BLL.Student.GetFailedStudentsAsync();

                if (FailedStudentsList.Count == 0)
                    return NotFound("No Students Found!");

                return Ok(FailedStudentsList);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        //Get Average Grade :-
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("AverageGrade", Name = "GetAverageGradeAsync")]
        public async Task<ActionResult<double>> GetAverageGradeAsync()
        {
            try
            {
                double? AverageGrade = await Students.BLL.Student.GetAverageGradeAsync();

                if (AverageGrade == null || AverageGrade == 0) 
                {
                    return NotFound("No Students Found!");
                }

                return Ok(AverageGrade);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        //Get Maximum Grade :-
        [HttpGet("MaximumGrade", Name = "GetMaximumGradeAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<double>> GetMaximumGradeAsync()
        {
            try
            {
                double? MaximumGrade = await Students.BLL.Student.GetMaximumGradeAsync();

                if (MaximumGrade == null || MaximumGrade == 0)
                {
                    return NotFound("No Students Found!");
                }

                return Ok(MaximumGrade);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        //Get Minmum Grade :-
        [HttpGet("MinimumGrade", Name = "GetMinimumGradeAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<double>> GetMinimumGradeAsync()
        {
            try
            {
                double? MinmumGrade = await Students.BLL.Student.GetMinimumGradeAsync();

                if (MinmumGrade == null || MinmumGrade == 0) 
                {
                    return NotFound("No Students Found!");
                }

                return Ok(MinmumGrade);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        //Get Does Student Exist :-
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("Exist", Name = "DoesStudentExistAsync")]
        public async Task<ActionResult<bool>> DoesStudentExistAsync(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest($"Not accepted ID : [{id}]!");
                }

                bool isExist = await Students.BLL.Student.DoesStudentExistAsync(id);
                return isExist;
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        //Get Student Info By ID :-
        [HttpGet("{id}", Name = "GetStudentByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> GetStudentByIdAsync(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest($"Not accepted ID : [{id}]!");
                }

                Students.BLL.Student student = await Students.BLL.Student.FindAsync(id);

                if (student == null)
                {
                    return NotFound($"Studnet With ID [{id}] Not Found!");
                }

                //Here we get Student DTOs Object to send to Client side as DTOs Object (because The Relationship between Server and Client is StateLess).
                StudentDTO studentDto = student.studentDto;

                //Here we send DTOs object not student object.
                return Ok(studentDto);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        [HttpPost(Name = "AddNewStudentAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> AddNewStudentAsync(StudentDTO newStudentDto)
        {
            try
            {
                if (newStudentDto == null || string.IsNullOrEmpty(newStudentDto.Name) || newStudentDto.Age <= 0 || newStudentDto.Grade < 0 || newStudentDto.Grade > 100)
                {
                    return BadRequest($"Invalid Student data!");
                }

                Students.BLL.Student student = new Students.BLL.Student(new StudentDTO(newStudentDto.StudentID, newStudentDto.Name, newStudentDto.Age, newStudentDto.Grade), Student.enMode.AddNew);
                await student.Save();

                newStudentDto.StudentID = student.StudentID;

                //we return Student DTOs Object not full student Object. 
                return CreatedAtRoute("GetStudentByIdAsync", new { id = newStudentDto.StudentID }, newStudentDto);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        //Delete Student :-
        [HttpDelete("{id}", Name = "DeleteStudentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteStudentAsync(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest($"Not accepted ID : [{id}]!");
                }

                if (!await Students.BLL.Student.DoesStudentExistAsync(id))
                {
                    return NotFound($"Student with ID [{id}] not found!");
                }

                bool isDeleted = await Students.BLL.Student.DeleteStudentAsync(id);
                return isDeleted;
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        //Update Student :-
        [HttpPut("{id}", Name = "UpdateStudentAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> UpdateStudentAsync(int id, StudentDTO Updatedstudent)
        {
            try
            {
                if (id < 1 || Updatedstudent == null || string.IsNullOrEmpty(Updatedstudent.Name) || Updatedstudent.Age <= 0 || Updatedstudent.Grade < 0 || Updatedstudent.Grade > 100)
                {
                    return BadRequest($"Invalid Student data!");
                }

                if (!await Students.BLL.Student.DoesStudentExistAsync(id)) 
                {
                    return NotFound($"Student with ID [{id}] not found!");
                }

                Updatedstudent.StudentID = id;
                Students.BLL.Student student = new Students.BLL.Student(Updatedstudent, Student.enMode.Update);

                //Save Update Student :-
                if (await student.Save())
                {
                    return Ok(student.studentDto);
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Failed to update student record!" });
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}