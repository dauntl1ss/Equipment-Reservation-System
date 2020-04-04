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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        int total;
        int update = 0;
        int retrievetotalQty;
        int quantity;
       // bool checkTime = false;
        //bool checkDate = false;
        //bool count = false;
        String[] arrayOfEquipment = { "Projector", "Extension Wire", "System Unit", "Projector Screen", "HDMI Cable", "VGA Cable", "Adaptor", "Router", "Computer Switch", "Hub", "Lan Ethernet Cable", "Cable Modem" };
        private void BtnApprovedReservation_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < arrayOfEquipment.Length; ++i)
            {
                if (cmbStatus.Text.Equals("Approved"))
                {
                    if (cmbReserveEquipment.Text.Equals(arrayOfEquipment[i]))
                    {
                         quantity = Int32.Parse(txtQty.Text);
                        retrieveQty();
                        update = total - quantity;
                        //checkAvailabilityTime();//same time
                        //checkFirstDate();//first reserve
                        //countReservations();

                        /*if (count == true)
                        {
                            update = total;
                        }
                        else
                        {
                            if (checkTime || checkDate)
                            {
                                update = total - quantity;
                                checkTime = false;
                                checkDate = false;

                            }
                        }*/
                        insertEquipment();
                        updateQty();
                        editStatus();
                        deleteFromRequest();
                        MessageBox.Show("Success!", "Reservation Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            if (cmbStatus.Text.Equals("Deny"))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to deny this Reservation?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DenyReservation denyReservation = new DenyReservation(this);
                    denyReservation.Show();
                }
            }
        }
        private void retrieveQty()
        {
            try
            {
                connection.connection.DB();
                String s = "SELECT * FROM EquipmentDetails WHERE EquipmentName = '" + cmbReserveEquipment.Text + "'";
                SqlCommand command = new SqlCommand(s, connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    total = Int32.Parse(reader.GetValue(1).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateQty()
        {
            try
            {
                connection.connection.DB();

                String a = "UPDATE EquipmentDetails SET Quantity =" + update + "WHERE EquipmentName = '" + cmbReserveEquipment.Text + "'";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void insertEquipment()
        {
            try
            {
                connection.connection.DB();
                String insert = "INSERT INTO ApprovedReservations VALUES(" + txtTransaction.Text + ",'" + txtReserveFName.Text + "','" + txtReserveLName.Text + "'," + txtReserveIDNo.Text + ",'" + cmbReserveEquipment.Text + "','" + cmbTimeSpan.Text + "','" + txtReserveTime.Text + "','" + txtExpectedReturnTime.Text + "'," + txtQty.Text + ",'" + dateReserveToday.Value.Date.ToString() + "','" + dateReserveDate.Value.ToShortDateString().ToString() + "','" + txtRoom.Text + "','" + txtCompletedBy.Text + "','" + cmbStatus.Text + "')";

                SqlCommand reserve = new SqlCommand(insert, connection.connection.conn);

                reserve.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void editStatus()
        {
            try
            {
                connection.connection.DB();
                String a = "SELECT * FROM EquipmentDetails WHERE EquipmentName = '" + cmbReserveEquipment.Text + "'";
                SqlCommand cmd = new SqlCommand(a, connection.connection.conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                     retrievetotalQty = Int32.Parse(reader.GetValue(1).ToString());
                    if (retrievetotalQty == 0)
                    {
                        statusNA();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void statusNA()
        {
            try
            {
                connection.connection.DB();
                String b = "UPDATE EquipmentDetails SET Status = " + "'Not Available'" + " WHERE EquipmentName = '" + cmbReserveEquipment.Text + "'";
                SqlCommand command = new SqlCommand(b, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void deleteFromRequest()
        {
            try
            {
                connection.connection.DB();
                String a = "DELETE FROM Reservations WHERE TransactionID = " + txtTransaction.Text + "";
                SqlCommand cmd = new SqlCommand(a, connection.connection.conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void Edit_Load(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();

                SqlCommand command = new SqlCommand("SELECT * FROM AccDetails ", connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtCompletedBy.Text = reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvRetrieve();

        }
        public void dgvRetrieve()
        {
            try
            {
                connection.connection.DB();
                String a = "SELECT Equipment, ReserveDate, Reserved_Time FROM ApprovedReservations WHERE Equipment = '" + cmbReserveEquipment.Text + "'";
                function.function.datagridfill(a, dgvSchedules);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        /* private void checkAvailabilityTime()//same reserve time and day
{
try
{
connection.connection.DB();
String a = "SELECT * From ApprovedReservations WHERE Reserved_Time = '" + txtReserveTime.Text + "' and Equipment = '" + cmbReserveEquipment.Text + "'";
SqlCommand command = new SqlCommand(a, connection.connection.conn);
SqlDataReader reader = command.ExecuteReader();

while (reader.Read())
{
if (reader.HasRows)
{
checkTime = true;
}
else
checkTime = false;
}
}
catch (Exception ex)
{
MessageBox.Show(ex.Message);
}
}

private void checkFirstDate()//first reserve in a day
{
try
{
connection.connection.DB();
String a = "SELECT * From ApprovedReservations WHERE ReserveDate = '" + dateReserveDate.Value.ToShortDateString().ToString() + "' and Equipment = '" + cmbReserveEquipment.Text + "'";
SqlCommand command = new SqlCommand(a, connection.connection.conn);
SqlDataReader reader = command.ExecuteReader();


if (reader.HasRows)
{
}
else
checkDate = true;

}
catch (Exception ex)
{
MessageBox.Show(ex.Message);
}
}

private void countReservations()
{
try
{
connection.connection.DB();
String a = "SELECT * FROM ApprovedReservations WHERE ReserveDate = '" + dateReserveDate.Value.ToShortDateString().ToString() + "' and Equipment = '" + cmbReserveEquipment.Text + "' and Quantity = " + txtQty.Text + "";
SqlCommand command = new SqlCommand(a, connection.connection.conn);
SqlDataReader reader = command.ExecuteReader();

if(reader.HasRows)
{
count = true;
}
else
{
count = false;
}


}
catch (Exception ex)
{
MessageBox.Show(ex.Message);
}
}*/

    }
   }

