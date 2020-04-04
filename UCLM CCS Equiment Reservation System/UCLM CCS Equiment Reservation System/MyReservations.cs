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
    public partial class MyReservations : Form
    {
        public MyReservations()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashboard userDashboard = new UserDashboard();
            userDashboard.Show();
        }

        int IDNo;
        private void CmbReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            retrieveAccount();
            String s = "";
            if (cmbReservations.Text.Equals("My Reservation Requests"))
            {
                s = "SELECT * FROM Reservations WHERE IDNumber = " + IDNo + " order by Date asc";
                function.function.datagridfill(s, dgv);

            }
            if (cmbReservations.Text.Equals("My Approved Reservations"))
            {
                s = "SELECT * FROM ApprovedReservations WHERE IDNumber = " + IDNo + " order by Date asc";
                function.function.datagridfill(s, dgv);
            }
        }
        public void retrieveAccount()
        {
            try
            {
                connection.connection.DB();

                SqlCommand command = new SqlCommand("SELECT * FROM AccDetails ", connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IDNo = Int32.Parse(reader.GetValue(2).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            /*if (cmbReservations.Text.Equals("My Reservation Requests"))
            {
                try
                {
                    connection.connection.DB();
                    String a = "SELECT ReserveDate FROM Reservations WHERE IDNumber = " + IDNo + " and ReserveDate LIKE'" + txtSearch.Text + "%'";
                    
                    function.function.datagridfill(a, dgv);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (cmbReservations.Text.Equals("My Approved Reservations"))
            {
                try
                {
                    connection.connection.DB();
                    String a = "SELECT * FROM ApprovedReservations WHERE IDNumber = "+ IDNo +"and FirstName LIKE'" + txtSearch.Text + "%' or LastName LIKE'" + txtSearch.Text + "%' or IDNumber LIKE'" + txtSearch.Text + "%' or Equipment LIKE'" + txtSearch.Text + "%' or Timespan LIKE'" + txtSearch.Text + "%' or Reserved_Time LIKE'" + txtSearch.Text + "%' or Expected_ReturnTime LIKE'" + txtSearch.Text + "%' or Quantity LIKE'" + txtSearch.Text + "%' or Date LIKE'" + txtSearch.Text + "%' or ReserveDate LIKE'" + txtSearch.Text + "%' or Room LIKE'" + txtSearch.Text + "%' or CompletedBy LIKE'" + txtSearch.Text + "%' or Status LIKE'" + txtSearch.Text + "%'";
                    SqlCommand command = new SqlCommand(a, connection.connection.conn);
                    command.ExecuteNonQuery();
                    function.function.datagridfill(a, dgv);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }*/
        }

        public int index;
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (cmbReservations.Text.Equals("My Reservation Requests"))
            {
                try
                {
                    index = dgv.CurrentRow.Index;
                    EditMyReservation x = new EditMyReservation();
                    x.Show();
                    foreach (DataGridViewRow row in dgv.SelectedRows)
                    {
                        x.txtTransaction.Text = row.Cells[0].Value.ToString();
                        x.txtReserveFName.Text = row.Cells[1].Value.ToString();
                        x.txtReserveLName.Text = row.Cells[2].Value.ToString();
                        x.txtReserveIDNo.Text = row.Cells[3].Value.ToString();
                        x.cmbReserveEquipment.Text = row.Cells[4].Value.ToString();
                        x.cmbTimeSpan.Text = row.Cells[5].Value.ToString();
                        x.txtReserveTime.Text = row.Cells[6].Value.ToString();
                        x.txtExpectedReturnTime.Text = row.Cells[7].Value.ToString();
                        x.txtQty.Text = row.Cells[8].Value.ToString();
                        x.dateReserveToday.Text = row.Cells[9].Value.ToString();
                        x.dateReserveDate.Text = row.Cells[10].Value.ToString();
                        x.txtRoom.Text = row.Cells[11].Value.ToString();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            if (cmbReservations.Text.Equals("My Approved Reservations"))
            {
                MessageBox.Show("Sorry, you cannot edit a reservation if it was already approved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        int qty;
        String equipment;
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            if (cmbReservations.Text.Equals("My Reservation Requests"))
            {
                try
                {
                    connection.connection.DB();

                    DialogResult result = MessageBox.Show("Are you sure you want to cancel your Reservation Request?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        int id = 0;
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            id = Int32.Parse(row.Cells[0].Value.ToString());

                        }
                        String a = "DELETE FROM Reservations WHERE TransactionID = " + id + "";
                        command = new SqlCommand(a, connection.connection.conn);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Reservation Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            if (cmbReservations.Text.Equals("My Approved Reservations"))
            {
                DialogResult result = MessageBox.Show("Your Reservation is already approved. Are you sure you want to cancel your Reservation?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        connection.connection.DB();
                        int id = 0;
                        foreach (DataGridViewRow row in dgv.SelectedRows)
                        {
                            id = Int32.Parse(row.Cells[0].Value.ToString());
                            qty = Int32.Parse(row.Cells[8].Value.ToString());
                            equipment = row.Cells[4].Value.ToString();
                        }
                        insertCancelledReservation();

                        String a = "DELETE FROM ApprovedReservations WHERE TransactionID = " + id + "";
                        command = new SqlCommand(a, connection.connection.conn);
                        command.ExecuteNonQuery();
                        updateQty();
                        MessageBox.Show("Reservation Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        int qtyRetrieve;
        private void updateQty()
        {
            try
            {
                connection.connection.DB();
                int total;
                String b = "SELECT * FROM EquipmentDetails  WHERE EquipmentName = '" + equipment + "'"; ;
                SqlCommand command1 = new SqlCommand(b, connection.connection.conn);
                SqlDataReader reader = command1.ExecuteReader();

                while (reader.Read())
                {
                    qtyRetrieve = Int32.Parse(reader.GetValue(1).ToString());
                }
                total = qtyRetrieve + qty;
                reader.Close();

                String a = "UPDATE EquipmentDetails SET Quantity = " + total + "WHERE EquipmentName = '" + equipment + "'"; ;
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void insertCancelledReservation()
        {
            int transactionid = 0, idnumber = 0, quantity = 0;
            String fname = "", lname = "", equipment = "", timespan = "", reserve_time = "", expected_returntime = "", date = "", reserve_date = "", room = "";
            try
            {
                connection.connection.DB();
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    transactionid = Int32.Parse(row.Cells[0].Value.ToString());
                    fname = row.Cells[1].Value.ToString();
                    lname = row.Cells[2].Value.ToString();
                    idnumber = Int32.Parse(row.Cells[3].Value.ToString());
                    equipment = row.Cells[4].Value.ToString();
                    timespan = row.Cells[5].Value.ToString();
                    reserve_time = row.Cells[6].Value.ToString();
                    expected_returntime = row.Cells[7].Value.ToString();
                    quantity = Int32.Parse(row.Cells[8].Value.ToString());
                    date = row.Cells[9].Value.ToString();
                    reserve_date = row.Cells[10].Value.ToString();
                    room = row.Cells[11].Value.ToString(); 
                }
                String insert = "INSERT INTO CancelledReservations VALUES(" + transactionid + ",'" + fname + "','" + lname + "'," + idnumber + ",'" + equipment + "','" + timespan + "','" + reserve_time + "','" + expected_returntime + "'," +quantity + ",'" + date + "','" + reserve_date + "','" + room + "')";

                SqlCommand reserve = new SqlCommand(insert, connection.connection.conn);

                reserve.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MyReservations_Load(object sender, EventArgs e)
        {

        }
    }
}
