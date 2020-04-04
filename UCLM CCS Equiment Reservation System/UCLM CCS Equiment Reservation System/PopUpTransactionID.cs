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
namespace UCLM_CCS_Equiment_Reservation_System
{
    public partial class PopUpTransactionID : Form
    {
        public PopUpTransactionID()
        {
            InitializeComponent();
        }

        private void BtnReturnedEquipment_Click(object sender, EventArgs e)
        {

            try
            {
                connection.connection.DB();
                String a = "SELECT * FROM ApprovedReservations WHERE IDNumber = " + txtIDNumber.Text + "";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    ReturnEquipment y = new ReturnEquipment();
                    y.idNumber = txtIDNumber.Text;
                    //ReturnPopUp y = new ReturnPopUp();
                    y.Show();
                    this.Hide();
                }
                else
                {

                    MessageBox.Show("Transaction Not Found.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard x = new Dashboard();
            x.Show();
        }

        private void PopUpTransactionID_Load(object sender, EventArgs e)
        {

        }

        private void PopUpTransactionID_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dashboard x = new Dashboard();
            x.Close();
        }
    }
}
