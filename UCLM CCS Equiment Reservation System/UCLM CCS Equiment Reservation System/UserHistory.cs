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
    public partial class UserHistory : Form
    {
        public UserHistory()
        {
            InitializeComponent();
        }

     
        int IDNo;
        private void CmbHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
             retrieveAccount();

            String s = "";
            if (cmbHistory.Text.Equals("My Completed Reservations"))
            {
                dgvHistory.Visible = true;
                s = "SELECT * FROM ReturnedEquipment WHERE IDNumber = " + IDNo +" order by DateReturned asc";
                function.function.datagridfill(s, dgvHistory);
            }
            if (cmbHistory.Text.Equals("My Pending Reservations"))
            {
                dgvHistory.Visible = true;
                s = "SELECT * FROM Pending WHERE IDNumber = "+ IDNo +" order by IDNumber asc";
                function.function.datagridfill(s, dgvHistory);
            }
            if (cmbHistory.Text.Equals("My Cancelled Reservations"))
            {
                dgvHistory.Visible = true;
                s = "SELECT * FROM CancelledReservations WHERE IDNumber = " + IDNo + " order by IDNumber asc";
                function.function.datagridfill(s, dgvHistory);
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
            /*if (cmbHistory.Text.Equals("My Pending Reservations"))
            {
                try
                {
                    connection.connection.DB();
                    String a = "SELECT * FROM Pending WHERE IDNumber = " + IDNo + "and FirstName LIKE'" + txtSearch.Text + "%' or LastName LIKE'" + txtSearch.Text + "%' or IDNumber LIKE'" + txtSearch.Text + "%' or Equipment LIKE'" + txtSearch.Text + "%' or QuantityPending LIKE'" + txtSearch.Text + "%' or EquipmentCondition LIKE'" + txtSearch.Text + "%' or TransactionID LIKE'" + txtSearch.Text + "%'";
                    function.function.datagridfill(a, dgvHistory);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (cmbHistory.Text.Equals("My Completed Reservations"))
            {
                try
                {
                    connection.connection.DB();
                    String a = "SELECT * FROM ReturnedEquipment WHERE IDNumber = " + IDNo + "and FirstName LIKE'" + txtSearch.Text + "%' or LastName LIKE'" + txtSearch.Text + "%' or IDNumber LIKE'" + txtSearch.Text + "%' or Equipment LIKE'" + txtSearch.Text + "%' or ReserveDate LIKE'" + txtSearch.Text + "%' or Date LIKE'" + txtSearch.Text + "%' or ReturnedTo LIKE'" + txtSearch.Text + "%' or QuantityReturned LIKE'" + txtSearch.Text + "%' or TransactionID LIKE'" + txtSearch.Text + "%'";
                    function.function.datagridfill(a, dgvHistory);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }*/
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashboard userDashboard = new UserDashboard();
            userDashboard.Show();
        }
    }
}
