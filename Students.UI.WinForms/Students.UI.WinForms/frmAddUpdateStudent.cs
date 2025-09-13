using Newtonsoft.Json;
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

namespace Students.UI.WinForms
{
    public partial class frmAddUpdateStudent : Form
    {
        //Enums :-
        private enum enFormMode { AddNew = 0, Update = 1 };
        enFormMode Mode = enFormMode.AddNew;


        //Properties :-
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5238/api/Students/")
        };
        private int StudentID;
        private StudentDTO _StudentDTO;


        //Private Methods :-
        private void SetFormTitle(string Title)
        {
            this.Text = Title;
            lblTitle.Text = Title;
        }
        private void ResetControls()
        {
            lblStudentID.Text = "N/A";
            txtName.Text = null;
            txtAge.Text = null;
            txtGrade.Text = null;
        }
        private void InitializeAddMode()
        {
            SetFormTitle("Add New Student");
            ResetControls();
        }
        //
        private void PopulateControls()
        {
            lblStudentID.Text = _StudentDTO.StudentID.ToString();
            txtName.Text = _StudentDTO.Name.ToString();
            txtAge.Text = _StudentDTO.Age.ToString();
            txtGrade.Text = _StudentDTO.Grade.ToString();
        }
        private void InitializeUpdateMode()
        {
            SetFormTitle("Update Student");
            PopulateControls();
        }
        private void InitializeForm()
        {
            if (Mode == enFormMode.AddNew)
            {
                InitializeAddMode();
                return;
            }
            InitializeUpdateMode();
        }
        private void SwitchToUpdateMode(StudentDTO StudentDto)
        {
            Mode = enFormMode.Update;
            lblStudentID.Text = StudentDto.StudentID.ToString();
            SetFormTitle("Update Student");
        }
        private async Task<StudentDTO> AddNewStudent(StudentDTO newStudentDto)
        {
            try
            {
                //Serialize object to json :-
                string jsonContent = JsonConvert.SerializeObject(newStudentDto);

                //prepare request conent :-
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                //Post request :-
                HttpResponseMessage response = await _httpClient.PostAsync($"", content);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var student = JsonConvert.DeserializeObject<StudentDTO>(responseContent);

                    return student ?? new StudentDTO();
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return new StudentDTO();
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return new StudentDTO();
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return new StudentDTO();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return new StudentDTO();
            }
        }
        private async Task<StudentDTO> UpdateStudent(int StudentID, StudentDTO updatedStudentDto)
        {
            try
            {
                //Serialize object to json :-
                string jsonContent = JsonConvert.SerializeObject(updatedStudentDto);

                //prepare request conent :-
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                //Post request :-
                HttpResponseMessage response = await _httpClient.PutAsync($"{StudentID}", content);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var student = JsonConvert.DeserializeObject<StudentDTO>(responseContent);

                    return student ?? new StudentDTO();
                }
                else
                {
                    MessageBox.Show($"{response.StatusCode} : {responseContent}");
                    return new StudentDTO();
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("HTTP error: " + httpEx.Message);
                return new StudentDTO();
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out.");
                return new StudentDTO();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return new StudentDTO();
            }
        }
        private StudentDTO GetStudentDTO()
        {
            StudentDTO studentDto = new StudentDTO();

            _StudentDTO.StudentID = (Mode == enFormMode.AddNew) ? -1 : _StudentDTO.StudentID;
            _StudentDTO.Name = txtName.Text;
            _StudentDTO.Age = Convert.ToInt32(txtAge.Text);
            _StudentDTO.Grade = Convert.ToInt32(txtGrade.Text);

            return _StudentDTO;
        }
        private async Task SaveStudentData()
        {
            StudentDTO StudentDto = GetStudentDTO();

            if (Mode == enFormMode.AddNew)
            {
                StudentDTO newStudentDto = await AddNewStudent(StudentDto);

                if (newStudentDto != null)
                {
                    MessageBox.Show($"Student addded Successfuly with Id [{newStudentDto.StudentID}]");
                    SwitchToUpdateMode(newStudentDto);
                    return;
                }
            }
            else
            {
                StudentDTO updatedStudentDto = await UpdateStudent(StudentID, StudentDto);

                if (updatedStudentDto != null)
                {
                    MessageBox.Show($"Studnet Updated Successfuly.");
                }
            }
        }


        //Constructor :-
        public frmAddUpdateStudent()
        {
            InitializeComponent();

            this.StudentID = -1;
            this._StudentDTO = new StudentDTO();
            this.Mode = enFormMode.AddNew;
        }
        public frmAddUpdateStudent(StudentDTO studentDTO)
        {
            InitializeComponent();

            this.StudentID = studentDTO.StudentID;
            this._StudentDTO = studentDTO;
            Mode = enFormMode.Update;
        }
        private void frmAddUpdateStudent_Load(object sender, EventArgs e)
        {
            InitializeForm();

            //Address Of Students.APIs :- 
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        //Save Data :-
        private async void btnSaveData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(txtGrade.Text))
                return;

            await SaveStudentData();
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}