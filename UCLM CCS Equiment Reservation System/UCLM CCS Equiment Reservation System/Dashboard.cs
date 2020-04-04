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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

        }

        private void BtnReservation_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservation x = new Reservation();
            x.Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            Searh x = new Searh();
            x.Show();
        }

        private void BtnEquipment_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipment x = new Equipment();
            x.Show();
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            History x = new History();
            x.Show();
        }


        public void Dashboard_Load(object sender, EventArgs e)
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

        private void BtnReturnEquipment_Click(object sender, EventArgs e)
        {
            PopUpTransactionID x = new PopUpTransactionID();
            x.Show();
            this.Hide();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            frmLogin x = new frmLogin();
            this.Hide();
            x.Show();
        }
    }
}
