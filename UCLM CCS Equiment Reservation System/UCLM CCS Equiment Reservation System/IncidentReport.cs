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
    public partial class IncidentReport : Form
    {
        public IncidentReport()
        {
            InitializeComponent();
        }
        ReturnEquipment x;
        public IncidentReport(ReturnEquipment x)
        {
            this.x = x;
            InitializeComponent();
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();
                String a = "INSERT INTO IncidentReports VALUES(" + txtTransactionID.Text + ",'" + txtEquipment.Text + "'," + txtQtyPending.Text + ",'" + txtFName.Text + "','" + txtLName.Text + "','" + txtReserveDate.Text + "','" + txtReserveTime.Text + "','" + txtEquipmentLoc.Text + "','" + txtDamageDesc.Text + "'," + txtCost.Text + ",'" + dateIncidentDate.Value.ToShortDateString().ToString() + "','" + txtIncidentTime.Text + "','" + dateReportedDate.Value.ToShortDateString().ToString() + "','" + txtTimeReported.Text + "','" + txtEmployeeName.Text + "','" + txtEmployeeNumber.Text + "','" + lblDept.Text + "')";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Incident Report Added!", "Incident Report", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IncidentReport_Load(object sender, EventArgs e)
        {
            /*txtTransactionID.Text = x.txtTransaction.Text;
            txtEquipment.Text = x.txtEquipment.Text;
            txtQtyPending.Text = x.txtQtyPending.Text;
            txtFName.Text = x.txtReserveFName.Text;
            txtLName.Text = x.txtReserveLName.Text;
            txtReserveDate.Text = x.txtReserveDate.Text;
            txtReserveTime.Text = x.txtReserveTime.Text;
            txtEquipmentLoc.Text = x.txtRoom.Text;*/

            dateReportedDate.Text = DateTime.Now.ToString();

            try
            {
                connection.connection.DB();

                SqlCommand command = new SqlCommand("SELECT * FROM AccDetails ", connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtEmployeeName.Text = reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString();
                    txtEmployeeNumber.Text = reader.GetValue(2).ToString();
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
            x.Show();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            printDetails print = new printDetails();
            print.PrintPanel(pnlPrintIncidentReport);

        }
    }
}
