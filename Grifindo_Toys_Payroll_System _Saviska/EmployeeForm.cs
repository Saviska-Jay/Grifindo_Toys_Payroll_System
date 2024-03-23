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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PNEJN8R;Initial Catalog=The_Grifindo_Toys_SMJ;Integrated Security=True");

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

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

        //Save Button
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int EmployeeID = int.Parse(EmployeeIDText.Text);
                string FirstName = FirstNameText.Text;
                string LastName = LastNameText.Text;
                string Address = AddressText.Text;
                string Gender;
                if (MaleRB.Checked)
                {
                    Gender = "Male";
                }
                else if (FemaleRB.Checked)
                {
                    Gender = "Female";
                }
                else
                {
                    Gender = "Other";
                
                }
                Int64 PassportNo = int.Parse(PassportNoText.Text);
                string DOB= (DOBPicker.Text);
                Int64 ContactNO= int.Parse(ContactNoText.Text);
                float MonthlySalary = float.Parse(MonthlySalaryText.Text);
                float OTRateHourly = float.Parse(OTRateHourlyText.Text);
                float Allowance = float.Parse(AllowanceText.Text);
                float GovTaxRate = float.Parse(GovTaxText.Text);
                string SaveQuery = "Insert Into Employee_Info (EmployeeID,FirstName,LastName,Address,Gender,PassportNo,DOB,ContactNo,MonthlySalary,OTRateHourly,Allowance,GovTaxRate) Values(" + EmployeeID + ",'" + FirstName + "','" + LastName + "','" + Address + "','" + Gender + "'," + PassportNo + ",'" + DOB + "'," + ContactNO + "," + MonthlySalary + "," + OTRateHourly + "," + Allowance + "," + GovTaxRate + "  ) ";
                SqlCommand cmnd = new SqlCommand(SaveQuery, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Employee Information Saved Successfully  !", "Saved !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error While Saving Employee Infomation ! " + ex);
            }
            finally
            {
                con.Close();
            }

        }

        //Search Button
        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 EmployeeID = int.Parse(EmployeeIDText.Text);
                string SearchQuery = "Select * From Employee_Info Where EmployeeID="+EmployeeIDText.Text+"";
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
                        AddressText.Text = R[3].ToString();
                        string Gender = R[4].ToString();
                        if (Gender == "Male")
                        {
                            MaleRB.Checked = true;
                        }
                        else if (Gender == "Female")
                        {
                            FemaleRB.Checked = true;
                        }
                        else
                        {
                            OtherRB.Checked = true;
                        }
                        PassportNoText.Text = R[5].ToString();
                        DOBPicker.Text = R[6].ToString();
                        ContactNoText.Text = R[7].ToString();
                        MonthlySalaryText.Text = R[8].ToString();
                        OTRateHourlyText.Text = R[9].ToString();
                        AllowanceText.Text = R[10].ToString();
                        GovTaxText.Text = R[11].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No employee with the provided EmployeeID was found ! Check The Employee ID.", "Nothing Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch 
            {
                MessageBox.Show("Error While Searching Employee Infomation ! " );
            }
            finally
            {
                con.Close();
            }
            
        }

        //Update Button
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                int EmployeeID = int.Parse(EmployeeIDText.Text);
                string FirstName = FirstNameText.Text;
                string LastName = LastNameText.Text;
                string Address = AddressText.Text;
                string Gender;
                if (MaleRB.Checked)
                {
                    Gender = "Male";
                }
                else if (FemaleRB.Checked)
                {
                    Gender = "Female";
                }
                else
                {
                    Gender = "Other";

                }
                Int64 PassportNo = int.Parse(PassportNoText.Text);
                string DOB = (DOBPicker.Text);
                Int64 ContactNO = int.Parse(ContactNoText.Text);
                float MonthlySalary = float.Parse(MonthlySalaryText.Text);
                float OTRateHourly = float.Parse(OTRateHourlyText.Text);
                float Allowance = float.Parse(AllowanceText.Text);
                float GovTaxRate = float.Parse(GovTaxText.Text);
                string UpdateQuery = "UPDATE Employee_Info SET FirstName = '" + FirstName + "', LastName = '" + LastName + "', Address = '" + Address + "', Gender = '" + Gender + "', PassportNo = " + PassportNo + ", DOB = '" + DOB + "', ContactNo = " + ContactNO + ", MonthlySalary = " + MonthlySalary + ", OTRateHourly = " + OTRateHourly + ", Allowance = " + Allowance + ", GovTaxRate = " + GovTaxRate + " WHERE EmployeeID = " + EmployeeID;
                SqlCommand cmnd = new SqlCommand(UpdateQuery, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Employee Information Updated Successfully  !", "Updated !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch 
            {
                MessageBox.Show("Error While Updating Employee Infomation ! " );
            }
            finally
            {
                con.Close();
            }
        }

        //Delete Button
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete the employee information?", "Delete Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                {
                    try
                    {
                        int EmployeeID = int.Parse(EmployeeIDText.Text);
                        string DeleteQuery = "DELETE FROM Employee_Info WHERE EmployeeID = " + EmployeeID;
                        SqlCommand cmnd = new SqlCommand(DeleteQuery, con);
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        MessageBox.Show("Employee Infomation Deleted Sucessfully ! ", "Deleted !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EmployeeIDText.Text = "";
                        FirstNameText.Text = "";
                        LastNameText.Text = "";
                        AddressText.Text = "";
                        MaleRB.Checked = false;
                        FemaleRB.Checked = false;
                        OtherRB.Checked = false;
                        PassportNoText.Text = "";
                        DOBPicker.Text = "";
                        ContactNoText.Text = "";
                        MonthlySalaryText.Text = "";
                        OTRateHourlyText.Text = "";
                        AllowanceText.Text = "";
                        GovTaxText.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("Error While Deleting Employee Infomation ! ");
                    }
                    finally
                    {
                        con.Close();
                    }



                }

            }



        }

        //Clear Button
        private void ClearButton_Click(object sender, EventArgs e)
        {
            EmployeeIDText.Text = "";
            FirstNameText.Text = "";
            LastNameText.Text = "";
            AddressText.Text = "";
            MaleRB.Checked = false;
            FemaleRB.Checked = false;
            OtherRB.Checked = false; 
            PassportNoText.Text = "";
            DOBPicker.Text = "";
            ContactNoText.Text = "";
            MonthlySalaryText.Text = "";
            OTRateHourlyText.Text = "";
            AllowanceText.Text = "";
            GovTaxText.Text = "";

        }

        //View All Button
        private void ViewAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                string ViewAllQuery = "SELECT * FROM Employee_Info";
                con.Open();
                SqlCommand cmnd = new SqlCommand(ViewAllQuery, con);
                SqlDataReader r = cmnd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(r);
                AllEmployeeTable.DataSource = dt;
            }

            catch 
            {
                MessageBox.Show("Error While Viewing Employee Infomation ! ");
            }

            finally
            {
                con.Close();
            }
        }
        

    }
}
