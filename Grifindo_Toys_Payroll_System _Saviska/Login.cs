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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-PNEJN8R;Initial Catalog=The_Grifindo_Toys_SMJ;Integrated Security=True");


        //Login Button
        private void LoginButton_Click(object sender, EventArgs e)
        {
            con.Open();
            String LoginQuery = "Select Username, Password From Login_Info Where Username='" + UsernameText.Text + "' And Password='" + PasswordText.Text + "' ";
            SqlCommand cmd = new SqlCommand(LoginQuery,con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Success !", "Login Success !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainMenu M = new MainMenu();
                M.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Login! Try Again!", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        //Cancel Button
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
