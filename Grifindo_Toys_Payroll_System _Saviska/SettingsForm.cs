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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            DateRangeText.ReadOnly = true;
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

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        //Save Settings Button
        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string SalaryCycleStartDate = SalaryCycleStartDatePicker.Text;
                string SalaryCycleEndDate = SalaryCycleEndDatePicker.Text;
                int NoOfLeavesForAYear = (int)NoOfLeavesForAYearNnumericUpDown.Value;
                int DateRange = int.Parse(DateRangeText.Text);
                string SettingsSaveQuery = "Insert Into Settings (SalaryCycleStartDate,SalaryCycleEndDate,NoOfLeavesForAYear,DateRange) Values ('"+SalaryCycleStartDate+"','"+SalaryCycleEndDate+"',"+NoOfLeavesForAYear+","+DateRange+")";
                SqlCommand cmd = new SqlCommand(SettingsSaveQuery, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Settings Saved Successfully  !", "Saved !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Error While Saving Settings ! " );
            }
            finally
            {
                con.Close();
            }

        }

        //Reset Settings Button
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ResetSettingsQuery = "DELETE FROM Settings" ;
                SqlCommand cmnd = new SqlCommand(ResetSettingsQuery, con);
                con.Open();
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Settings Reseted Sucessfully ! ", "Reseted !", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Error While Resetting Settings ! ");
            }
            finally
            {
                con.Close();
            }
        }

        //Days Calculate Button
        private void DateCalculateButton_Click(object sender, EventArgs e)
        {
            DateTime StartDate = SalaryCycleStartDatePicker.Value;
            DateTime EndDate = SalaryCycleEndDatePicker.Value;
            TimeSpan DateRange = EndDate - StartDate;
            int TotalDays = (int)DateRange.TotalDays;
            DateRangeText.Text = TotalDays.ToString();
        }
    }
}
