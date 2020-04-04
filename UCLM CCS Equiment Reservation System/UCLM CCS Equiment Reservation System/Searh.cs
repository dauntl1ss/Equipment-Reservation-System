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
    public partial class Searh : Form
    {
        public Searh()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard x = new Dashboard();
            x.Show();
        }

   

        public int index;
        public void BtnEdit_Click(object sender, EventArgs e)
        {
            index = dgv.CurrentRow.Index;
            Edit x = new Edit();
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

  
        private void CmbReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s = "";
            if (cmbReservations.Text.Equals("Approved Reservations"))
            {
                s = "SELECT * FROM ApprovedReservations order by Date asc";
                function.function.datagridfill(s, dgv);
            }
            if (cmbReservations.Text.Equals("Reservation Requests"))
            {
                s = "SELECT * FROM Reservations order by Date asc";
                function.function.datagridfill(s, dgv);
            }
            if (cmbReservations.Text.Equals("Reservations Today"))
            {

                String date = DateTime.Now.ToShortDateString();
                s = "SELECT * FROM ApprovedReservations WHERE ReserveDate = '" + date + "'";

                function.function.datagridfill(s, dgv);
                
            
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbReservations.Text.Equals("Reservation Requests"))
            {
                try
                {
                    connection.connection.DB();
                    String a = "SELECT * FROM Reservations WHERE FirstName LIKE'" + txtSearch.Text + "%' or LastName LIKE'" + txtSearch.Text + "%' or IDNumber LIKE'" + txtSearch.Text + "%' or Equipment LIKE'" + txtSearch.Text + "%' or Date LIKE'" + txtSearch.Text + "%' or ReserveDate LIKE'" + txtSearch.Text + "%' or Reserve_Time LIKE'" + txtSearch.Text + "%' or Room LIKE'" + txtSearch.Text + "%'";
                    function.function.datagridfill(a, dgv);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (cmbReservations.Text.Equals("Approved Reservations"))
            {
                try
                {
                    connection.connection.DB();
                    String a = "SELECT * FROM ApprovedReservations WHERE FirstName LIKE'" + txtSearch.Text + "%' or LastName LIKE'" + txtSearch.Text + "%' or IDNumber LIKE'" + txtSearch.Text + "%' or Equipment LIKE'" + txtSearch.Text + "%' or Timespan LIKE'" + txtSearch.Text + "%' or Reserved_Time LIKE'" + txtSearch.Text + "%' or Expected_ReturnTime LIKE'" + txtSearch.Text + "%' or Quantity LIKE'" + txtSearch.Text + "%' or Date LIKE'" + txtSearch.Text + "%' or ReserveDate LIKE'" + txtSearch.Text + "%' or Room LIKE'" + txtSearch.Text + "%' or CompletedBy LIKE'" + txtSearch.Text + "%' or Status LIKE'" + txtSearch.Text + "%'";
                    function.function.datagridfill(a, dgv);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Searh_Load(object sender, EventArgs e)
        {

        }
    }
}

