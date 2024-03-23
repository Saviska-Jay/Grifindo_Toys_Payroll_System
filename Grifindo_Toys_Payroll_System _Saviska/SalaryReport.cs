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
    public partial class SalaryReport : Form
    {
        public SalaryReport()
        {
            InitializeComponent();
        }

        private void SalaryReport_Load(object sender, EventArgs e)
        {
            this.Salary_InfoTableAdapter.Fill(this.The_Grifindo_Toys_SMJDataSet.Salary_Info);

            this.reportViewer1.RefreshReport();
        }

        //Menu Button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu M = new MainMenu();
            M.ShowDialog();
        }

        //Exit Button
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
