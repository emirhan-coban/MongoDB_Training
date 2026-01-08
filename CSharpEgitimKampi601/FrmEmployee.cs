using System;
using System.Data;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;port=5432;Database=CustomerDB;User Id=postgres;Password=postgres123;";
        void EmployeeList()
        {
            var connection = new Npgsql.NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Employees";
            var command = new Npgsql.NpgsqlCommand(query, connection);
            var adapter = new Npgsql.NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        void DepartmentList()
        {
            var connection = new Npgsql.NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Departments";
            var command = new Npgsql.NpgsqlCommand(query, connection);
            var adapter = new Npgsql.NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbEmployeeDepartment.DisplayMember = "DepartmentName";
            cmbEmployeeDepartment.ValueMember = "DepartmentID";
            cmbEmployeeDepartment.DataSource = dataTable;
            connection.Close();
        }
        private void FrmEmployee_Load(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            EmployeeList();
            DepartmentList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string employeeName = txtEmployeeName.Text;
            string employeeSurname = txtEmployeeSurname.Text;
            decimal employeeSalary = decimal.Parse(txtEmployeeSalary.Text);
            int departmentId = int.Parse(cmbEmployeeDepartment.SelectedValue.ToString());

            var connection = new Npgsql.NpgsqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Employees (EmployeeName, EmployeeSurname, EmployeeSalary, DepartmentID) " +
                           "VALUES (@name, @surname, @salary, @deptId)";
            var command = new Npgsql.NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", employeeName);
            command.Parameters.AddWithValue("@surname", employeeSurname);
            command.Parameters.AddWithValue("@salary", employeeSalary);
            command.Parameters.AddWithValue("@deptId", departmentId);
            command.ExecuteNonQuery();
            connection.Close();
            EmployeeList();
            MessageBox.Show("Employee added successfully.");
        }
    }
}
