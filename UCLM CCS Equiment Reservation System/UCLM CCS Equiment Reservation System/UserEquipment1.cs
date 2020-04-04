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
    public partial class UserEquipment1 : Form
    {
        public UserEquipment1()
        {
            InitializeComponent();
        }

     
        private void UserEquipment1_Load(object sender, EventArgs e)
        {
            try
            {

                String[] Array = { "Projector", "Extension Wire", "System Unit", "Projector Screen" };

                for (int i = 0; i < 4; i++)
                {
                    connection.connection.DB();

                    SqlCommand command = new SqlCommand("SELECT * FROM EquipmentDetails WHERE EquipmentName = '" + Array[i] + "'", connection.connection.conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (i == 0)
                        {
                            projectorQty.Text = reader.GetValue(1).ToString();
                            lblPorjectorStat.Text = reader.GetValue(2).ToString();
                        }
                        if (i == 1)
                        {
                            extensionQty.Text = reader.GetValue(1).ToString();
                            lblExtensionWireStat.Text = reader.GetValue(2).ToString();
                        }
                        if (i == 2)
                        {
                            systemUnitQty.Text = reader.GetValue(1).ToString();
                            lblSystemUnitStat.Text = reader.GetValue(2).ToString();
                        }
                        if (i == 3)
                        {
                            projectorScreenQty.Text = reader.GetValue(1).ToString();
                            lblProjectorScreenStat.Text = reader.GetValue(2).ToString();
                        }

                    }
                    connection.connection.conn.Close();

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

        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.Close();
            UserEquipment2 x = new UserEquipment2();
            x.Show();
        }
    }
}
