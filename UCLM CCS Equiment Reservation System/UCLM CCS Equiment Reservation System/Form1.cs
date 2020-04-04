using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using System.Data.SqlClient;

namespace UCLM_CCS_Equiment_Reservation_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        String fname, lname, idno;
        SqlCommand command;
        SqlDataReader reader;
        public void BtnLogin_Click(object sender, EventArgs e)
        {
            Dashboard x = new Dashboard();

            try
            {
                connection.connection.DB();

                command = new SqlCommand("SELECT * FROM AdminAccounts where Username = '" + txtUser.Text + "' and Password = '" + txtPassword.Text + "'", connection.connection.conn);
                 reader = command.ExecuteReader();

                  
                    if (reader.HasRows)
                    {
                    MessageBox.Show("Welcomeback Admin!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (reader.Read())
                        {
                            fname = reader.GetValue(0).ToString();
                            lname = reader.GetValue(1).ToString();
                            idno = reader.GetValue(2).ToString();
                           
                        }
                    this.Hide();
                    updateAccDetails();
                    x.Show();


                    reader.Close();
                    }
                    else
                    {
                    reader.Close();
                        command = new SqlCommand("SELECT * FROM Accounts where Username = '" + txtUser.Text + "' and Password = '" + txtPassword.Text + "'", connection.connection.conn);
                         reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                        MessageBox.Show("Welcomeback User!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        while (reader.Read())
                            {
                                fname = reader.GetValue(0).ToString();
                                lname = reader.GetValue(1).ToString();
                                idno = reader.GetValue(2).ToString();
                               
                            }
                        this.Hide();
                        updateAccDetails();
                        UserDashboard user = new UserDashboard();
                        user.Show();
                        reader.Close();
                        }
                        else
                        {
                        MessageBox.Show("Account not found!", "Log-in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reader.Close();
                        }
                    }
                
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SignUp signup = new SignUp();
            signup.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void FrmLogin_Load(object sender, EventArgs e)
        {
            txtLogIn.BackColor = Color.FromArgb(30,0,0,0);            
           
        }
          public void updateAccDetails()
        {

            try
            {
                connection.connection.DB();

                SqlCommand command = new SqlCommand("UPDATE  AccDetails SET FirstName= '" + fname + "', LastName = '" + lname + "', IDNo = " + Int32.Parse(idno), connection.connection.conn);
                command.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        

    }
}
