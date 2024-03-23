using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Toys_Payroll_System__Saviska
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        //Exit Button
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Employee Button
        private void EmployeeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeForm M = new EmployeeForm();
            M.ShowDialog();
        }

        //Salary Button
        private void SalaryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalaryForm M = new SalaryForm();
            M.ShowDialog();
        }

        //Settings Button
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SettingsForm M = new SettingsForm();
            M.ShowDialog();
        }
    }
}
