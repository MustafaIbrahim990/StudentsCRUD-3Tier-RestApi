using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Students.UI.WinForms
{
    public partial class Form1 : Form
    {
        //Private Properties :-
        private static readonly HttpClient _httpClient = new HttpClient()
        {
            //Address of student Api.
            BaseAddress = new Uri("http://localhost:5238/api/Students/")
        };


        //Private Methods :-
        private void InitializeAPI()
        {
            //Initialize Of Students.APIs :- 
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("All");
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var students = JsonConvert.DeserializeObject<List<StudentDTO>>(responseContent);

                    if (students == null || students.Count == 0)
                    {
                        return null;
                    }
                    return students;
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return null;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return null;
            }
        }
        private async Task<List<StudentDTO>> GetPassedStudentsAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("Passed");
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var students = JsonConvert.DeserializeObject<List<StudentDTO>>(responseContent);

                    if (students == null || students.Count == 0)
                    {
                        return null;
                    }
                    return students;
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return null;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return null;
            }
        }
        private async Task<List<StudentDTO>> GetFailedStudentsAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("Failed");
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var students = JsonConvert.DeserializeObject<List<StudentDTO>>(responseContent);

                    if (students == null || students.Count == 0)
                    {
                        return null;
                    }
                    return students;
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return null;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return null;
            }
        }
        private async Task<double?> GetAverageGradeAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("AverageGrade");
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    double AverageGrade = JsonConvert.DeserializeObject<double>(responseContent);
                    return AverageGrade;
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return null;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return null;
            }
        }
        private async Task<double?> GetMaximumGradeAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("MaximumGrade");
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    double MaximumGrade = JsonConvert.DeserializeObject<double>(responseContent);
                    return MaximumGrade;
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return null;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return null;
            }
        }
        private async Task<double?> GetMinimumGradeAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("MinimumGrade");
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    double MinimumGrade = JsonConvert.DeserializeObject<double>(responseContent);
                    return MinimumGrade;
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return null;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return null;
            }
        }
        private async Task<bool> DoesStudentExistAsync(int StudentID)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"Exist?id={StudentID}");
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    bool isExist = JsonConvert.DeserializeObject<bool>(responseContent);
                    return isExist;
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return false;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return false;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return false;
            }
        }
        private async Task<StudentDTO> GetStudentByIdAsync(int StudentID)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{StudentID}");
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var student = JsonConvert.DeserializeObject<StudentDTO>(responseContent);
                    return student ?? null;
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return null;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return null;
            }
        }
        private async Task<bool> DeleteStudentAsync(int StudentID)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{StudentID}");
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    bool result = JsonConvert.DeserializeObject<bool>(responseContent);
                    return result;
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return false;
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return false;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return false;
            }
        }


        //Constructor :-
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeAPI();
        }


        //Get All Students :-
        private async void btnGetAllStudents_Click(object sender, EventArgs e)
        {
            List<StudentDTO> students = await GetAllStudentsAsync();

            if (students == null || students.Count == 0)
            {
                MessageBox.Show("No Students Found!", "No Students", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmStudentRecords frm = new frmStudentRecords(students);
            frm.ShowDialog();
        }


        //Get Passed Students :-
        private async void btnGetPassedStudents_Click(object sender, EventArgs e)
        {
            List<StudentDTO> students = await GetPassedStudentsAsync();

            if (students == null || students.Count == 0)
            {
                MessageBox.Show("No Students Found!", "No Students", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmStudentRecords frm = new frmStudentRecords(students);
            frm.ShowDialog();
        }


        //Get Failed Students :-
        private async void btnGetFailedStudents_Click(object sender, EventArgs e)
        {
            List<StudentDTO> students = await GetFailedStudentsAsync();

            if (students == null || students.Count == 0)
            {
                MessageBox.Show("No Students Found!", "No Students", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmStudentRecords frm = new frmStudentRecords(students);
            frm.ShowDialog();
        }


        //Get Average Grade :-
        private async void btnGetAverageGrade_Click(object sender, EventArgs e)
        {
            double? AverageGrade = await GetAverageGradeAsync();

            if (AverageGrade == null || AverageGrade == 0) 
            {
                MessageBox.Show("No Students Found!", "No Students", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Average Grade : {AverageGrade}", "Average Grade", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Get Maximum Grade :-
        private async void btnGetMaximumGrade_Click(object sender, EventArgs e)
        {
            double? MaximumGrade = await GetMaximumGradeAsync();

            if (MaximumGrade == null || MaximumGrade == 0)
            {
                MessageBox.Show("No Students Found!", "No Students", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Maximum Grade : {MaximumGrade}", "Maximum Grade", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Get Minimum Grade :-
        private async void btnGetMinimumGrade_Click(object sender, EventArgs e)
        {
            double? MinimumGrade = await GetMinimumGradeAsync();

            if (MinimumGrade == null || MinimumGrade == 0) 
            {
                MessageBox.Show("No Students Found!", "No Students", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Minimum Grade : {MinimumGrade}", "Minimum Grade", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Does Student Exist :-
        private async void btnDoesStudentExist_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID1.Text))
            {
                txtStudentID1.Focus();
                return;
            }

            int StudentID = Convert.ToInt32(txtStudentID1.Text);

            if (await DoesStudentExistAsync(StudentID))
            {
                MessageBox.Show($"Student with ID [{StudentID}] is found", "Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show($"Student with ID [{StudentID}] is not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Get Student By Id :-
        private async void btnGetStudentById_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID2.Text))
            {
                txtStudentID2.Focus();
                return;
            }

            int StudentID = Convert.ToInt32(txtStudentID2.Text);
            StudentDTO student = await GetStudentByIdAsync(StudentID);

            if (student == null)
            {
                MessageBox.Show($"Student with ID [{StudentID}] is not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmStudentRecords frm = new frmStudentRecords(student);
            frm.ShowDialog();
        }


        //Add New Student :-
        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            frmAddUpdateStudent frm = new frmAddUpdateStudent();
            frm.ShowDialog();
        }


        //Update Student :-
        private async void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID3.Text))
            {
                txtStudentID3.Focus();
                return;
            }

            int StudentID = Convert.ToInt32(txtStudentID3.Text);
            StudentDTO student = await GetStudentByIdAsync(StudentID);

            if (student == null)
            {
                MessageBox.Show($"Student with ID [{StudentID}] is not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmAddUpdateStudent frm = new frmAddUpdateStudent(student);
            frm.ShowDialog();
        }


        //Delete Student :- 
        private async void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID4.Text))
            {
                txtStudentID4.Focus();
                return;
            }

            int StudentID = Convert.ToInt32(txtStudentID4.Text);

            if (MessageBox.Show($"Are you Sure you want to delete this student?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!await DoesStudentExistAsync(StudentID))
            {
                MessageBox.Show($"Student with ID [{StudentID}] is not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (await DeleteStudentAsync(StudentID))
            {
                MessageBox.Show($"Student with ID [{StudentID}] has been deleted successfuly.");
                return;
            }

            MessageBox.Show($"Student with ID [{StudentID}] could not deleted!");
        }
    }
}