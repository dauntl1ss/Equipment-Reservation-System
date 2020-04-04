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
    public partial class Equipment2 : Form
    {
        public Equipment2()
        {
            InitializeComponent();
        }
       

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipment x = new Equipment();
            x.Show();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipment3 x = new Equipment3();
            x.Show();
        }

        private void Equipment2_Load(object sender, EventArgs e)
        {
            

            try
            {

                String[] Array = { "HDMI Cable", "VGA Cable", "Adaptor", "Router" };

                for (int i = 0; i < 4; i++)
                {
                    connection.connection.DB();

                    SqlCommand command = new SqlCommand("SELECT * FROM EquipmentDetails WHERE EquipmentName = '" + Array[i] + "'", connection.connection.conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        if (i == 0)
                        {
                            hdmiQty.Text = reader.GetValue(1).ToString();
                            lblHDMIStat.Text = reader.GetValue(2).ToString();
                        }
                        if (i == 1)
                        {
                            vgaQty.Text = reader.GetValue(1).ToString();
                            lblVGAStat.Text = reader.GetValue(2).ToString();
                        }
                        if (i == 2)
                        {
                            adaptorQty.Text = reader.GetValue(1).ToString();
                            lblAdaptorStat.Text = reader.GetValue(2).ToString();
                        }
                        if (i == 3)
                        {
                            routerQty.Text = reader.GetValue(1).ToString();
                            lblRouterStat.Text = reader.GetValue(2).ToString();
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
