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
    public partial class DenyReservation : Form
    {
        public DenyReservation()
        {
            InitializeComponent();
        }
        Edit edit;
        public DenyReservation(Edit edit)
        {
            this.edit = edit;
            InitializeComponent();
        }

        private void DenyReservation_Load(object sender, EventArgs e)
        {
            txtTransaction.Text = edit.txtTransaction.Text;
            txtIDNumber.Text = edit.txtReserveIDNo.Text;
            txtTo.Text = edit.txtReserveFName.Text;
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                String a = "INSERT INTO UserNotifications VALUES(" + txtTransaction.Text + "," +txtIDNumber.Text + ",'" + txtTo.Text + "','" + txtMessage.Text + "')";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
                deleteReservation();
                MessageBox.Show("Successfully sent!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void deleteReservation()
        {
            try
            {
                connection.connection.DB();
                String a = "DELETE FROM Reservations WHERE TransactionID = " + txtTransaction.Text + "";
                SqlCommand command = new SqlCommand(a, connection.connection.conn); 
                command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
