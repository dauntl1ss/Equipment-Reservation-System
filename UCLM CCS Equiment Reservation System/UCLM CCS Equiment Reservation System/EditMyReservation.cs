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
    public partial class EditMyReservation : Form
    {
        public EditMyReservation()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnEditDetails_Click(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                String a = "UPDATE Reservations SET Equipment = '" + cmbReserveEquipment.Text + "', Quantity = " + txtQty.Text + ", ReserveDate = '" + dateReserveDate.Value.ToShortDateString().ToString() + "', Timespan ='" + cmbTimeSpan.Text + "', Reserve_Time = '" + txtReserveTime.Text + "', Expected_ReturnTime = '" + txtExpectedReturnTime.Text + "', Room = '" + txtRoom.Text + "' WHERE TransactionID = " + txtTransaction.Text + "";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
