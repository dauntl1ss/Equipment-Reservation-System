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
    public partial class ReturnPopUp : Form
    {
        ReturnEquipment x;
        public ReturnPopUp()
        {
            InitializeComponent();
        }
        public ReturnPopUp(ReturnEquipment x)
        {
            this.x = x;
            InitializeComponent();
        }

        private void BtnReturnedEquipment_Click(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                String a = "INSERT INTO ReturnedEquipment VALUES(" + x.txtTransaction.Text + ",'" + x.txtReserveFName.Text + "','" + x.txtReserveLName.Text + "'," + x.txtReserveIDNo.Text + ",'" + x.txtEquipment.Text + "'," + x.txtQty.Text + ",'" + x.txtDate.Text + "','" + x.txtReserveDate.Text + "','" + x.txtTimeSpan.Text + "','" + x.txtReserveTime.Text + "','" + x.txtExpectedReturnTime.Text + "','" + x.txtRoom.Text + "','" + x.txtCompletedBy.Text + "','" + txtReturnTime.Text + "','" + txtSanction.Text + "','" + txtReturnedTo.Text + "','" + cmbStatus.Text + "','" + cmbCondition.Text + "'," + txtQtyReturned.Text + "," + txtPending.Text + ",'" + dateReturnedDate.Value.ToShortDateString().ToString() + "')";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
                returnEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ReturnPopUp_Load(object sender, EventArgs e)
        {
            dateReturnedDate.Text = DateTime.Now.ToString();
            try
            {
                connection.connection.DB();

                SqlCommand command = new SqlCommand("SELECT * FROM AccDetails ", connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtReturnedTo.Text = reader.GetValue(0).ToString() + reader.GetValue(1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int total_qty = 0;
        public void returnEquipment()
        {
            int qty;
            try
            {
                connection.connection.DB();
                String a = "SELECT * FROM EquipmentDetails WHERE EquipmentName = '" + x.txtEquipment.Text + "'";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int returned_qty = Int32.Parse(txtQtyReturned.Text);
                    qty = Int32.Parse(reader.GetValue(1).ToString());
                    total_qty = returned_qty + qty;

                    /*if (Int32.Parse(txtPending.Text) == Int32.Parse(txtQtyReturned.Text))
                    {
                        deleteFromReservation();
                    }*/

                    updateTotalQty();
                    editStatus();

                    MessageBox.Show("Success!", "Return Equipment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteFromReservation()
        {
            try
            {
                connection.connection.DB();
                String a = "DELETE FROM ApprovedReservations WHERE TransactionID = " + x.txtTransaction.Text + "";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateTotalQty()
        {
            try
            {
                connection.connection.DB();
                String a = "UPDATE EquipmentDetails SET Quantity = " + total_qty + "WHERE EquipmentName = '" + x.txtEquipment.Text + "'";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void editStatus()
        {
            try
            {
                connection.connection.DB();
                String b = "SELECT * FROM EquipmentDetails  WHERE EquipmentName = '" + x.txtEquipment.Text + "'";
                SqlCommand command = new SqlCommand(b, connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int qty = Int32.Parse(reader.GetValue(1).ToString());
                    if (qty > 0)
                    {
                        statusA();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void statusA()
        {
            try
            {
                connection.connection.DB();
                String b = "UPDATE EquipmentDetails SET Status = " + "'Available'" + " WHERE EquipmentName = '" + x.txtEquipment.Text + "'";
                SqlCommand command = new SqlCommand(b, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
