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
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
        }
   
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard x = new Dashboard();
            x.Show();

        }
         int number = 0;
        public void Reservation_Load(object sender, EventArgs e)
        {
            try
            {
                connection.connection.DB();

                SqlCommand command = new SqlCommand("SELECT * FROM AccDetails ", connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    txtApprovedBy.Text = reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //COMBO BOX REASON
            pnlEquipmentdetails.Visible = false;

            //for transaction number
            Random random = new Random();
            List<int> listNumbers = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                do
                {
                    number = random.Next(1, 99999999);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
            txtTransaction.Text = (number.ToString());
            
        }

        public void BtnPlus_Click(object sender, EventArgs e)
        {

            try
            {
                int val = Int32.Parse(txtQty.Text);
                int qty = Int32.Parse(lblTotalQty.Text);
                if (val >= qty)
                {
                    MessageBox.Show("Invalid Quantity");
                }
                else
                {
                    val++;
                    txtQty.Text = val.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Invalid! Choose an equipment first.", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BtnMinus_Click(object sender, EventArgs e)
        {
            int val = Int32.Parse(txtQty.Text);
            if (val > 0)
            {
                val--;
                txtQty.Text = val.ToString();
            }
            else
            {
                MessageBox.Show("Invalid!", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CmbReserveEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            String path;
            pnlEquipmentdetails.Visible = true;
            Equipment a = new Equipment();

            try
            {
                connection.connection.DB();

                SqlCommand command = new SqlCommand("SELECT * FROM EquipmentDetails WHERE EquipmentName = '" + cmbReserveEquipment.Text + "'", connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();

                if (cmbReserveEquipment.SelectedItem.Equals("Projector"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Projector.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Extension Wire"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\ExtensionWire.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Projector Screen"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Projector Screen.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("System Unit"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\System Unit.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }

                if (cmbReserveEquipment.SelectedItem.Equals("HDMI Cable"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\HDMI.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("VGA Cable"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\VGA.jpeg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Adaptor"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Adaptor.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Router"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Router.jpeg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }

                if (cmbReserveEquipment.SelectedItem.Equals("Computer Switch"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Switch.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Hub"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Hub.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("LAN Ethernet Cable"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\EthernetCable.jpeg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Cable Modem"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"C:\Users\dauntl1ss\source\repos\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Modem.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);
                }
                if (reader.Read())
                {
                    lblName.Text = reader.GetValue(0).ToString();
                    lblTotalQty.Text = reader.GetValue(1).ToString();
                    lblStatus.Text = reader.GetValue(2).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int total;
        int update = 0;
        int retrievetotalQty;
        int quantity;
        public void BtnSubmitReservation_Click(object sender, EventArgs e)
        {
            dateReserveToday.Value = DateTime.Now;
            String[] arrayOfEquipment = { "Projector", "Extension Wire", "System Unit", "Projector Screen", "HDMI Cable", "VGA Cable", "Adaptor", "Router", "Computer Switch", "Hub", "Lan Ethernet Cable", "Cable Modem" };

            if (lblTotalQty.Text.Equals("0") || txtQty.Text.Equals("0"))
            {
                MessageBox.Show("Invalid", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connection.connection.DB();

                    for (int i = 0; i < arrayOfEquipment.Length; ++i)
                    {
                        if (cmbReserveEquipment.SelectedItem.Equals(arrayOfEquipment[i]))
                        {
                            quantity = Int32.Parse(txtQty.Text);
                            retrieveQty();
                            update = total - quantity;
                            insertEquipment();
                            updateQty();
                            editStatus();
                            MessageBox.Show("Reservation Success!", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            printDetails print = new printDetails(this);
                            print.Show();
                            connection.connection.conn.Close();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void retrieveQty()
        {
            try
            {
                connection.connection.DB();
                String s = "SELECT * FROM EquipmentDetails WHERE EquipmentName = '" + cmbReserveEquipment.Text + "'";
                SqlCommand command = new SqlCommand(s, connection.connection.conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    total = Int32.Parse(reader.GetValue(1).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void insertEquipment()
        {
            try
            {
                connection.connection.DB();
                String insert = "INSERT INTO ApprovedReservations VALUES(" + txtTransaction.Text + ",'" + txtReserveFName.Text + "','" + txtReserveLName.Text + "'," + txtReserveIDNo.Text + ",'" + cmbReserveEquipment.Text + "','" + cmbTimeSpan.Text + "','" + txtReserveTime.Text + "','" + txtExpectedReturnTime.Text + "'," + txtQty.Text + ",'" + dateReserveToday.Value.ToString() + "','" + dateReserveDate.Value.ToShortDateString().ToString() + "','" + txtRoom.Text + "','" + txtApprovedBy.Text +"','" + "Approved" + "')";

                SqlCommand reserve = new SqlCommand(insert, connection.connection.conn);

                reserve.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateQty()
        {
            try
            {
                connection.connection.DB();

                String a = "UPDATE EquipmentDetails SET Quantity =" + update + "WHERE EquipmentName = '" + cmbReserveEquipment.Text + "'";
                SqlCommand command = new SqlCommand(a, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void editStatus()
        {
            try
            {
                connection.connection.DB();
                String a = "SELECT * FROM EquipmentDetails WHERE EquipmentName = '" + cmbReserveEquipment.Text + "'";
                SqlCommand cmd = new SqlCommand(a, connection.connection.conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    retrievetotalQty = Int32.Parse(reader.GetValue(1).ToString());
                    if (retrievetotalQty == 0)
                    {
                        statusNA();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void statusNA()
        {
            try
            {
                connection.connection.DB();
                String b = "UPDATE EquipmentDetails SET Status = " + "'Not Available'" + " WHERE EquipmentName = '" + cmbReserveEquipment.Text + "'";
                SqlCommand command = new SqlCommand(b, connection.connection.conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
