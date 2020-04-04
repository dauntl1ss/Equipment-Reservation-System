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
    public partial class Notifications : Form
    {
        public Notifications()
        {
            InitializeComponent();
        }

        int IDNo;
        private void Notifications_Load(object sender, EventArgs e)
        {
            retriveIDNo();
            String s = "SELECT * FROM UserNotifications WHERE IDNumber = " + IDNo +" order by TransactionID asc";
            function.function.datagridfill(s, dgvNotifications);
        }
        private void retriveIDNo()
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashboard userDashboard = new UserDashboard();
            userDashboard.Show();
        }
    }
}
