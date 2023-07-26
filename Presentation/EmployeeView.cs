using Service;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class EmployeeView : Form
    {
        IEmployee employee;

        public EmployeeView()
        {
            InitializeComponent();
        }

        private void EmployeeView_Load(object sender, EventArgs e)
        {
            EmployeeList();
        }

        void EmployeeList()
        {
            employee = new Employee();
            var result = employee.employees("Select * from Employee");

            dataGridEmployeeList.DataSource = result;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            EmployeeList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                employee = new Employee();
                employee.insert("insert into Employee (Name,Surname,DateOfRegistration) values('" + txtName.Text + "','" + txtSurname.Text + "','" + Convert.ToDateTime(dateTimeOfRegistration.Text).ToString("MM-dd-yyyy") + "')");

                EmployeeList();
                MessageBox.Show("Registration Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var chosen = (EmployeeDTO)dataGridEmployeeList.SelectedRows[0].DataBoundItem;
                employee = new Employee();
                employee.delete("Delete from Employee where Id=" + chosen.Id + "");

                MessageBox.Show("Delete Successful!");
                EmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var chosen = (EmployeeDTO)dataGridEmployeeList.SelectedRows[0].DataBoundItem;

                employee = new Employee();
                employee.update("Update Employee set Name = '" + txtName.Text + "', Surname = '" + txtSurname.Text + "', DateOfRegistration = '" + Convert.ToDateTime(dateTimeOfRegistration.Text).ToString("MM-dd-yyyy") + "' where Id = '" + chosen.Id + "'");

                MessageBox.Show("Update Successful!");
                EmployeeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void dataGridEmployeeList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridEmployeeList.SelectedRows.Count != 0)
            {
                var chosen = (EmployeeDTO)dataGridEmployeeList.SelectedRows[0].DataBoundItem;
                txtName.Text = chosen.Name;
                txtSurname.Text = chosen.Surname;
                dateTimeOfRegistration.Value = chosen.DateOfRegistration;
            }
        }
    }
}
