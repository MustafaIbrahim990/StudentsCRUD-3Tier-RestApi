using Azure;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Students.DAL
{
    //Student DTO Class:-
    public class StudentDTO
    {
        //Properties :-
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }


        //Constructor :-
        public StudentDTO(int studentID, string name, int age, int grade)
        {
            this.StudentID = studentID;
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
    }


    //Student Data Class :-
    public static class StudentData
    {
        //Private Methods :-
        private static async Task<List<StudentDTO>> GetStudentsListAsync(string storedProcedureName)
        {
            var StudentsList = new List<StudentDTO>();

            try
            {
                await using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    await using(SqlCommand command = new SqlCommand(storedProcedureName, connection)) 
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                StudentsList.Add(new StudentDTO
                                (
                                     reader.GetInt32(reader.GetOrdinal("studentID")),
                                     reader.GetString(reader.GetOrdinal("name")),
                                     reader.GetInt32(reader.GetOrdinal("age")),
                                     reader.GetInt32(reader.GetOrdinal("grade"))
                                ));
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql error while fetching Students : " + sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error while featching Students : " + ex.Message, ex);
            }
            return StudentsList;
        }
        public static async Task<double> GetScalarValueAsync(string storedProcedureName)
        {
            try
            {
                await using(SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    await using(SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        await connection.OpenAsync();

                        object result = await command.ExecuteScalarAsync();

                        return (result != DBNull.Value) ? Convert.ToDouble(result) : 0;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql error while featching Students : " + sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error while featching Students : " + ex.Message, ex);
            }
        }


        //Get All Students :-
        public static async Task<List<StudentDTO>> GetAllStudentsAsync() => await GetStudentsListAsync("dbo.SP_GetAllStudents");


        //Get Passed Students :-
        public static async Task<List<StudentDTO>> GetPassedStudentsAsync() => await GetStudentsListAsync("dbo.SP_GetPassedStudents");


        //Get Failed Students :-
        public static async Task<List<StudentDTO>> GetFailedStudentsAsync() => await GetStudentsListAsync("dbo.SP_GetFailedStudents");


        //Get Average Grade :-
        public static async Task<double> GetAverageGradeAsync() => await GetScalarValueAsync("dbo.SP_GetAverageGrade");


        //Get Maximum Grade :-
        public static async Task<double> GetMaximumGradeAsync() => await GetScalarValueAsync("dbo.SP_GetMaximumGrade");


        //Get Minimum Grade :-
        public static async Task<double> GetMinimumGradeAsync() => await GetScalarValueAsync("dbo.SP_GetMinimumGrade");


        //Does Student Exist :-
        public static async Task<bool> DoesStudentExistAsync(int StudentID)
        {
            try
            {
                await using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("dbo.SP_DoesStudentExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //Input Parameters :-
                        command.Parameters.AddWithValue("@StudentID", StudentID);

                        //Output Parameters :-
                        var isExist = new SqlParameter("@IsExist", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(isExist);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        return (bool)isExist.Value;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql error while featching Students : " + sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error while featching Students : " + ex.Message, ex);
            }
        }


        //Get Student Info By StudentID :-
        public static async Task<StudentDTO?> GetStudentByIdAsync(int StudentID)
        {
            try
            {
                await using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("dbo.SP_GetStudentById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentID", StudentID);
                        await connection.OpenAsync();

                        await using(var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return (new StudentDTO
                                (
                                     reader.GetInt32(reader.GetOrdinal("studentID")),
                                     reader.GetString(reader.GetOrdinal("name")),
                                     reader.GetInt32(reader.GetOrdinal("age")),
                                     reader.GetInt32(reader.GetOrdinal("grade"))
                                ));
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql error while featching Students : " + sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error while featching Students : " + ex.Message, ex);
            }
        }


        //Add New Student :-
        public static async Task<int> AddNewStudentAsync(StudentDTO studentDTO)
        {
            try
            {
                await using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("dbo.SP_AddNewStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //Input Parameters :-
                        command.Parameters.AddWithValue("@Name", studentDTO.Name);
                        command.Parameters.AddWithValue("@Age", studentDTO.Age);
                        command.Parameters.AddWithValue("@Grade", studentDTO.Grade);

                        //Output Parameters :-
                        var OutputIdParameter = new SqlParameter("@NewStudentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(OutputIdParameter);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        return (int)OutputIdParameter.Value;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql error while featching Students : " + sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error while featching Students : " + ex.Message, ex);
            }
        }


        //Update Student :-
        public static async Task<bool> UpdateStudentAsync(StudentDTO updatedStudentDto)
        {
            try
            {
                await using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("dbo.SP_UpdateStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //Input Parameters :-
                        command.Parameters.AddWithValue("@StudentID", updatedStudentDto.StudentID);
                        command.Parameters.AddWithValue("@Name", updatedStudentDto.Name);
                        command.Parameters.AddWithValue("@Age", updatedStudentDto.Age);
                        command.Parameters.AddWithValue("@Grade", updatedStudentDto.Grade);

                        //Output Parameters :-
                        var IsUpdated = new SqlParameter("@IsUpdated", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(IsUpdated);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        return (bool)IsUpdated.Value;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql error while featching Students : " + sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error while featching Students : " + ex.Message, ex);
            }
        }


        //Delete Student :-
        public static async Task<bool> DeleteStudentAsync(int StudentID)
        {
            try
            {
                await using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
                {
                    await using (SqlCommand command = new SqlCommand("dbo.SP_DeleteStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        //Input Parameters :-
                        command.Parameters.AddWithValue("@StudentID", StudentID);

                        //Output Parameters :-
                        var IsDeleted = new SqlParameter("@IsDeleted", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(IsDeleted);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        return (bool)IsDeleted.Value;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Sql error while featching Students : " + sqlex.Message, sqlex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error while featching Students : " + ex.Message, ex);
            }
        }
    }
}