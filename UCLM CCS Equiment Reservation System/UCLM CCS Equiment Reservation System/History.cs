using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCLM_CCS_Equiment_Reservation_System
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void BtnCompleted_Click(object sender, EventArgs e)
        {
            dgvHistory.Visible = true;
            String s = "";
            s = "SELECT * FROM ReturnedEquipment order by DateReturned asc";
            function.function.datagridfill(s, dgvHistory);
        }


        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard x = new Dashboard();
            x.Show();
        }

     
        private void CmbHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s = "";
            if (cmbHistory.Text.Equals("Completed Reservations"))
            {
                dgvHistory.Visible = true;
                s = "SELECT * FROM ReturnedEquipment order by DateReturned asc";
                function.function.datagridfill(s, dgvHistory);
            }
            if(cmbHistory.Text.Equals("Pending Reservations"))
            {
                dgvHistory.Visible = true;
                s = "SELECT * FROM Pending order by IDNumber asc";
                function.function.datagridfill(s, dgvHistory);
            }
            if(cmbHistory.Text.Equals("Incident Reports"))
            {
                dgvHistory.Visible = true;
                s = "SELECT * FROM IncidentReports order by IncidentDate asc";
                function.function.datagridfill(s,dgvHistory);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbHistory.Text.Equals("Pending Reservations"))
            {
                try
                {
                    connection.connection.DB();
                    String a = "SELECT * FROM Pending WHERE FirstName LIKE'" + txtSearch.Text + "%' or LastName LIKE'" + txtSearch.Text + "%' or IDNumber LIKE'" + txtSearch.Text + "%' or Equipment LIKE'" + txtSearch.Text + "%' or QuantityPending LIKE'" + txtSearch.Text + "%' or EquipmentCondition LIKE'" + txtSearch.Text + "%' or TransactionID LIKE'" + txtSearch.Text + "%'";
                    function.function.datagridfill(a, dgvHistory);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (cmbHistory.Text.Equals("Completed Reservations"))
            {
                try
                {
                    connection.connection.DB();
                    String a = "SELECT * FROM ReturnedEquipment WHERE FirstName LIKE'" + txtSearch.Text + "%' or LastName LIKE'" + txtSearch.Text + "%' or IDNumber LIKE'" + txtSearch.Text + "%' or Equipment LIKE'" + txtSearch.Text + "%' or ReserveDate LIKE'" + txtSearch.Text + "%' or Date LIKE'" + txtSearch.Text + "%' or ReturnedTo LIKE'" + txtSearch.Text + "%' or QuantityReturned LIKE'" + txtSearch.Text + "%' or TransactionID LIKE'" + txtSearch.Text + "%'";
                    function.function.datagridfill(a, dgvHistory);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (cmbHistory.Text.Equals("Incident Reports"))
            {
                try
                {
                    connection.connection.DB();
                    String a = "SELECT * FROM IncidentReports WHERE FirstName LIKE'" + txtSearch.Text + "%' or LastName LIKE'" + txtSearch.Text + "%' or QuantityPending LIKE'" + txtSearch.Text + "%' or Equipment LIKE'" + txtSearch.Text + "%' or ReserveDate LIKE'" + txtSearch.Text + "%' or ReserveTime LIKE'" + txtSearch.Text + "%' or EquipmentLocation LIKE'" + txtSearch.Text + "%' or RepairOrReplacementCost LIKE'" + txtSearch.Text + "%' or TransactionID LIKE'" + txtSearch.Text + "%' or IncidentDate LIKE'" + txtSearch.Text + "%' or IncidentTime LIKE'" + txtSearch.Text + "%' or ReportedOn LIKE'" + txtSearch.Text + "%' or TimeReported LIKE'" + txtSearch.Text + "%' or ReportedBy_Employee LIKE'" + txtSearch.Text + "%' or ReportedBy_ID LIKE'" + txtSearch.Text + "%'";
                    function.function.datagridfill(a, dgvHistory);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

      
    }
}
