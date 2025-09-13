using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students.UI.WinForms
{
    public partial class frmStudentRecords : Form
    {
        //Private Properties :-
        private List<StudentDTO> _StudentRecords = new List<StudentDTO>();


        //Constructor :-
        public frmStudentRecords(StudentDTO student)
        {
            InitializeComponent();

            _StudentRecords = new List<StudentDTO> { student };
        }
        public frmStudentRecords(List<StudentDTO> students)
        {
            InitializeComponent();

            _StudentRecords = students;
        }
        private void frmStudentRecords_Load(object sender, EventArgs e)
        {
            dgvStudentRecords.DataSource = _StudentRecords;
        }


        //Close Form :-
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}