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
    public partial class Equipment3 : Form
    {
        public Equipment3()
        {
            InitializeComponent();
        }

     

        
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipment2 x = new Equipment2();
            x.Show();
            
        }

        private void Equipment3_Load(object sender, EventArgs e)
        {

            try
            {

                String[] Array = { "Computer Switch", "Hub", "LAN Ethernet Cable", "Cable Modem" };

                for (int i = 0; i < 4; i++)
                {
                    connection.connection.DB();

                    SqlCommand command = new SqlCommand("SELECT * FROM EquipmentDetails WHERE EquipmentName = '" + Array[i] + "'", connection.connection.conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (i == 0)
                        {
                            switchQty.Text = reader.GetValue(1).ToString();
                            lblSwitchStat.Text = reader.GetValue(2).ToString();
                        }
                        if (i == 1)
                        {
                            hubQty.Text = reader.GetValue(1).ToString();
                            lblHubStat.Text = reader.GetValue(2).ToString();
                        }
                        if (i == 2)
                        {
                            ethernetQty.Text = reader.GetValue(1).ToString();
                            lblEthernetStat.Text = reader.GetValue(2).ToString();
                        }
                        if (i == 3)
                        {
                            modemQty.Text = reader.GetValue(1).ToString();
                            lblModemStat.Text = reader.GetValue(2).ToString();
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
    }
}
