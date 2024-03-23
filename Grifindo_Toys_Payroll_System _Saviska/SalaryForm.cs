using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Grifindo_Toys_Payroll_System__Saviska
{
    public partial class SalaryForm : Form
    {
        public SalaryForm()
        {
            InitializeComponent();
            
          
            FirstNameText.ReadOnly = true;
            LastNameText.ReadOnly = true;
            PassportNoText.ReadOnly = true;
            ContactNoText.ReadOnly = true;
            MonthlySalaryText.ReadOnly = true;
            OTRateHourlyText.ReadOnly = true;
            AllowanceText.ReadOnly = true;
            GovTaxText.ReadOnly = true;
            SalaryCycleStartDatePicker.Enabled = false; 
            SalaryCycleEndDatePicker.Enabled = false; 
            NoOfLeavesForAYearText.ReadOnly = true;
            DateRangeText.ReadOnly = true;
            NoPayText.ReadOnly = true;
            BaseSalaryText.ReadOnly = true;
            OTText.ReadOnly = true;
            GrossPayText.ReadOnly = true;
            OverallAttendanceText.ReadOnly = true;


        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PNEJN8R;Initial Catalog=The_Grifindo_Toys_SMJ;Integrated Security=True");



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

        //Search Button
        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                int EmployeeID = int.Parse(EmployeeIDText.Text);
                string SearchQuery = "Select * From Employee_Info Where EmployeeID=" + EmployeeIDText.Text + "";
                SqlCommand cmnd = new SqlCommand(SearchQuery, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                SqlDataReader R = cmnd.ExecuteReader();
                if (R.HasRows)
                {

                    while (R.Read())
                    {
                        EmployeeIDText.Text = R[0].ToString();
                        FirstNameText.Text = R[1].ToString();
                        LastNameText.Text = R[2].ToString();
                        PassportNoText.Text = R[5].ToString();
                        ContactNoText.Text = R[7].ToString();
                        MonthlySalaryText.Text = R[8].ToString();
                        OTRateHourlyText.Text = R[9].ToString();
                        AllowanceText.Text = R[10].ToString();
                        GovTaxText.Text = R[11].ToString();
                    }
                    con.Close();

                    string SalaryCycleQuery = "Select * From Settings";
                    SqlCommand comnd = new SqlCommand(SalaryCycleQuery, con);
                    con.Open();
                    cmnd.ExecuteNonQuery();
                    SqlDataReader Z = comnd.ExecuteReader();

                    while (Z.Read())
                    {
                        SalaryCycleStartDatePicker.Text = Z[0].ToString();
                        SalaryCycleEndDatePicker.Text = Z[1].ToString();
                        NoOfLeavesForAYearText.Text = Z[2].ToString();
                        DateRangeText.Text = Z[3].ToString();

                    }



                }
                else
                {
                    MessageBox.Show("No employee with the provided EmployeeID was found ! Check The Employee ID.", "Nothing Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EmployeeIDText.Text = "";
                    FirstNameText.Text = "";
                    LastNameText.Text = "";
                    PassportNoText.Text = "";
                    ContactNoText.Text = "";
                    MonthlySalaryText.Text = "";
                    OTRateHourlyText.Text = "";
                    AllowanceText.Text = "";
                    GovTaxText.Text = "";

                    SalaryCycleStartDatePicker.Text = "";
                    SalaryCycleEndDatePicker.Text = "";
                    NoOfLeavesForAYearText.Text = "";
                    DateRangeText.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Error While Searching Employee Infomation ! ");
            }
            finally
            {
                con.Close();
            
            }

            }

        //Calculate Button
        private void SalaryCalculateButton_Click(object sender, EventArgs e)
        {
            try
            {

                float OT, NoPay, MonthlySalary, OverallAttendance, DateRange, AbsentDays, Basepay, Allowance, OTRate, OTHours, GrossPay, GovTaxRate, Tax;
                OverallAttendance = float.Parse(OverallAttendanceText.Text);
                DateRange = float.Parse(DateRangeText.Text);
                AbsentDays = float.Parse(DaysAbsentText.Text);
                MonthlySalary = float.Parse(MonthlySalaryText.Text);

                //NoPay
                if (OverallAttendance < DateRange)
                {
                    NoPay = (MonthlySalary / DateRange) * AbsentDays;
                    NoPayText.Text = NoPay.ToString();
                }


                //BasePay
                Allowance = float.Parse(AllowanceText.Text);
                OTRate = float.Parse(OTRateHourlyText.Text);
                OTHours = float.Parse(OTHoursText.Text);

                OT = OTHours * OTRate;
                Basepay = MonthlySalary + Allowance + OT;
                BaseSalaryText.Text = Basepay.ToString();
                OTText.Text = OT.ToString();

                //GrossPay
                GovTaxRate = float.Parse(GovTaxText.Text);
                NoPay = float.Parse(NoPayText.Text);
                Tax = Basepay * GovTaxRate / 100;
                GrossPay = Basepay - (NoPay + Tax);
                GrossPayText.Text = GrossPay.ToString();

            }
            catch (Exception ex)

            {
                MessageBox.Show("Error While Calculating Salary ! "+ex);
            
            }
        }

       
        private void SalaryForm_Load(object sender, EventArgs e)
        {

        }


        //Save Salary Button
        private void ConfirmSaveSalaryButton_Click(object sender, EventArgs e)
        {
            try
            {
                int SalaryID = int.Parse(SalaryIDText.Text);
                int EmployeeID = int.Parse(EmployeeIDText.Text);
                string PaymentDate = PaymentDatePicker.Text;
                float BaseSalary = float.Parse(BaseSalaryText.Text);
                float OT = float.Parse(OTText.Text);
                float NoPay = float.Parse(NoPayText.Text);
                float GrossPay = float.Parse(GrossPayText.Text);
                string SaveSalaryQuery = "Insert Into Salary_Info (SalaryID,EmployeeID,PaymentDate,BaseSalary,OT,NoPay,GrossPay) Values(" + SalaryID + "," + EmployeeID + ",'" + PaymentDate + "'," + BaseSalary + "," + OT + "," + NoPay + "," + GrossPay + ") ";
                SqlCommand cmnd = new SqlCommand(SaveSalaryQuery, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Salary Information Saved Successfully  !", "Saved !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Error While Saving Salary Infomation ! ");
            }
            finally
            {
                con.Close();
            }
        }

        //View Report Button
        private void ViewReportButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalaryReport M = new SalaryReport();
            M.ShowDialog();
        }

        private void CalculateAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                float OverallAttendanceZ, DateRangeZ, AbsentDaysZ, LeavesZ, HolidaysZ;
                DateRangeZ = float.Parse(DateRangeText.Text);
                LeavesZ = float.Parse(LeavesTakenText.Text);
                AbsentDaysZ = float.Parse(DaysAbsentText.Text);
                HolidaysZ = float.Parse(HolidaysTakenText.Text);
                OverallAttendanceZ = DateRangeZ - (LeavesZ + AbsentDaysZ + HolidaysZ);
                OverallAttendanceText.Text = OverallAttendanceZ.ToString();
            }
            catch
            {
                MessageBox.Show("Error While Calculating Attendance ! " );
            }

        }

        private void DateRangeText_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
