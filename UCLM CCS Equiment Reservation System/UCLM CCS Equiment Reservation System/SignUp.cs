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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            txtFName.Clear();
            txtLName.Clear();
            txtIDNo.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtConfirmPass.Clear();
        }


        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin x = new frmLogin();
            x.Show();
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();

                if (txtPassword.Text.Equals(txtConfirmPass.Text))
                {

                    String insert = "INSERT into Accounts Values('" + txtFName.Text + "'," + "'" + txtLName.Text + "'," + txtIDNo.Text + ",'" + txtUserName.Text + "'," + "'" + txtPassword.Text + "')";

                    SqlCommand command = new SqlCommand(insert, connection.connection.conn);

                    command.ExecuteNonQuery();


                    MessageBox.Show("Registration Success!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                        connection.connection.conn.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Password");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
