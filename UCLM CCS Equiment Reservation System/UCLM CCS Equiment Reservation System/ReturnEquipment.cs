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
    public partial class ReturnEquipment : Form
    {
        public ReturnEquipment()
        {
            InitializeComponent();
            
        }
        public string idNumber;

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard x = new Dashboard();
            x.Show();
        }

        int total_qty = 0;

        /*private void BtnReturnedEquipment_Click(object sender, EventArgs e)
        {
            Reservation x = new Reservation();
                int qty;
            try
            {
                connection.connection.DB();
                String a = "SELECT * FROM EquipmentDetails WHERE EquipmentName = '" + txtEquipment.Text + "'";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int returned_qty = Int32.Parse(txtQtyReturned.Text);
                        qty = Int32.Parse(reader.GetValue(1).ToString());
                        total_qty = returned_qty + qty;
                        insertReturned();

                        if(Int32.Parse(txtPending.Text) == Int32.Parse(txtQtyReturned.Text))
                        {
                            deleteFromReservation();
                        }
         
                        updateTotalQty();
                        editStatus();

                        MessageBox.Show("Success!", "Return Equipment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
                if(pnlPending.Visible == true)
                {
                    deleteFromReservation();
                    insertPending();
                    MessageBox.Show("Added to Pending!", "Pending Equipment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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
                String b = "SELECT * FROM EquipmentDetails  WHERE EquipmentName = '" + txtEquipment.Text + "'";
                SqlCommand command = new SqlCommand(b, connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int qty = Int32.Parse(reader.GetValue(1).ToString());
                    if(qty > 0)
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
                String b = "UPDATE EquipmentDetails SET Status = " + "'Available'" + " WHERE EquipmentName = '" + txtEquipment.Text + "'";
                SqlCommand command = new SqlCommand(b, connection.connection.conn);
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
                String a = "UPDATE EquipmentDetails SET Quantity = " + total_qty + "WHERE EquipmentName = '" + txtEquipment.Text + "'";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

      /*  public void insertPending()
        {
            try
            {
                connection.connection.DB();
                String a = "INSERT INTO Pending VALUES(" + txtTransaction.Text + "," + txtReserveIDNo.Text + ",'" + txtReserveFName.Text + "','" + txtReserveLName.Text + "','" + txtEquipment.Text + "'," + txtQtyPending.Text + ",'" + cmbConditionPending.Text + "','" + txtReserveDate.Text + "','" + txtReserveTime.Text + "')";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       /* public void insertReturned()
        {
            try
            {
                connection.connection.DB();
                String a = "INSERT INTO ReturnedEquipment VALUES(" + txtTransaction.Text + ",'" + txtReserveFName.Text + "','" + txtReserveLName.Text + "'," + txtReserveIDNo.Text + ",'" + txtEquipment.Text + "'," + txtQty.Text + ",'" + txtDate.Text + "','" + txtReserveDate.Text + "','" + txtTimeSpan.Text + "','" + txtReserveTime.Text + "','" + txtExpectedReturnTime.Text + "','" + txtRoom.Text + "','" + txtCompletedBy.Text + "','" + txtReturnTime.Text + "','" + txtSanction.Text + "','" + txtReturnedTo.Text + "','" + cmbStatus.Text + "','" + cmbCondition.Text + "'," + txtQtyReturned.Text + "," + txtPending.Text + ",'" + dateReturnedDate.Value.ToShortDateString().ToString() + "')";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
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
                String a = "DELETE FROM ApprovedReservations WHERE TransactionID = " + txtTransaction.Text + "";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                 command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnPopUp returnPop = new ReturnPopUp(this);
            returnPop.Show();

        }

        private void BtnPending_Click(object sender, EventArgs e)
        {
  
            
        }

        private void BtnIncidentReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            IncidentReport x = new IncidentReport(this);
            x.Show();
        }

        private void ReturnEquipment_Load(object sender, EventArgs e)
        {
            String s = "SELECT * FROM ApprovedReservations WHERE IDNumber = " + idNumber + " order by ReserveDate desc";
            
            function.function.datagridfill(s, dgvTransactions);
        }

        private void DgvTransactions_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           int index = dgvTransactions.CurrentRow.Index;
     
            foreach (DataGridViewRow row in dgvTransactions.SelectedRows)
            {
                txtTransaction.Text = row.Cells[0].Value.ToString();
                txtReserveFName.Text = row.Cells[1].Value.ToString();
                txtReserveLName.Text = row.Cells[2].Value.ToString();
                txtReserveIDNo.Text = row.Cells[3].Value.ToString();
                txtEquipment.Text = row.Cells[4].Value.ToString();
                txtTimeSpan.Text = row.Cells[5].Value.ToString();
                txtReserveTime.Text = row.Cells[6].Value.ToString();
                txtExpectedReturnTime.Text = row.Cells[7].Value.ToString();
                txtQty.Text = row.Cells[8].Value.ToString();
                txtDate.Text = row.Cells[9].Value.ToString();
                txtReserveDate.Text = row.Cells[10].Value.ToString();
                txtRoom.Text = row.Cells[11].Value.ToString();
                txtCompletedBy.Text = row.Cells[12].Value.ToString();

                

            }

            
        }

        private void BtnReturnedEquipment_Click(object sender, EventArgs e)
        {

        }
    }
}
