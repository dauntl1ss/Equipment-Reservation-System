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
    public partial class UserDashboard : Form
    {
        public UserDashboard()
        {
            InitializeComponent();
        }
        
        private void UserDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();

                SqlCommand command = new SqlCommand("SELECT * FROM AccDetails ", connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FirstName.Text = reader.GetValue(0).ToString();
                    LastName.Text = reader.GetValue(1).ToString();
                    IDNo.Text = reader.GetValue(2).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserReservation x = new UserReservation();
            x.Show();
        }

     
 
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin x = new frmLogin();
            x.Show();
        }

        private void BtnMyReservations_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyReservations myReservations = new MyReservations();
            myReservations.Show();
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHistory userHistory = new UserHistory();
            userHistory.Show();
        }

     

        private void BtnNotifications_Click(object sender, EventArgs e)
        {
            this.Hide();
            Notifications notifications = new Notifications();
            notifications.Show();

        }

        private void BtnEquipment_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserEquipment1 userEquipment1 = new UserEquipment1();
            userEquipment1.Show();
        }
    }
}
