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
    public partial class UserReservation : Form
    {
        public UserReservation()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashboard x = new UserDashboard();
            x.Show();
        }

        int number = 0;
        Reservation x = new Reservation();
        private void UserReservation_Load(object sender, EventArgs e)
        {
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
            retrieveID();
        }

        private void BtnPlus_Click(object sender, EventArgs e)
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

        private void BtnMinus_Click(object sender, EventArgs e)
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

        private void CmbReserveEquipment_SelectedIndexChanged(object sender, EventArgs e)
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
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Projector.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Extension Wire"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\ExtensionWire.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Projector Screen"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Projector Screen.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("System Unit"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\System Unit.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }

                if (cmbReserveEquipment.SelectedItem.Equals("HDMI Cable"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\HDMI.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("VGA Cable"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\VGA.jpeg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Adaptor"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Adaptor.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Router"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Router.jpeg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }

                if (cmbReserveEquipment.SelectedItem.Equals("Computer Switch"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Switch.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Hub"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Hub.jpg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("LAN Ethernet Cable"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\EthernetCable.jpeg";
                    pbEquipment.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbEquipment.Image = Image.FromFile(path);

                }
                if (cmbReserveEquipment.SelectedItem.Equals("Cable Modem"))
                {
                    pbEquipment.BorderStyle = BorderStyle.FixedSingle;
                    path = @"D:\Documents\SECONDYEAR\APPSDEV\UCLM CCS Equipment Reservation FINAL\UCLM CCS Equiment Reservation System\UCLM CCS Equiment Reservation System\Resources\Modem.jpg";
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

        private void BtnSubmitReservation_Click(object sender, EventArgs e)
        {
            dateReserveToday.Value = DateTime.Now;
            String[] arrayOfEquipment = { "Projector", "Extension Wire", "System Unit", "Projector Screen", "HDMI Cable", "VGA Cable", "Adaptor", "Router", "Computer Switch", "Hub", "Lan Ethernet Cable", "Cable Modem" };

            if (lblTotalQty.Text.Equals("0") || txtQty.Text.Equals("0"))
            {
                MessageBox.Show("Invalid");
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
                            insertEquipment();
                            MessageBox.Show("Success Reservation!", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void insertEquipment()
        {
            try
            {
                connection.connection.DB();
                String insert = "INSERT INTO Reservations VALUES(" + txtTransaction.Text + ",'" + txtReserveFName.Text + "','" + txtReserveLName.Text + "'," + txtReserveIDNo.Text + ",'" + cmbReserveEquipment.Text + "','" + cmbTimeSpan.Text + "','" + txtReserveTime.Text + "','" + txtExpectedReturnTime.Text + "'," + txtQty.Text + ",'" + dateReserveToday.Value.ToString() + "','" + dateReserveDate.Value.ToShortDateString().ToString() + "','" + txtRoom.Text + "')";

                SqlCommand reserve = new SqlCommand(insert, connection.connection.conn);

                reserve.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void retrieveID()
        {
            try
            {
                connection.connection.DB();

                SqlCommand command = new SqlCommand("SELECT * FROM AccDetails", connection.connection.conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    txtReserveFName.Text = reader.GetValue(0).ToString();
                    txtReserveLName.Text = reader.GetValue(1).ToString();
                    txtReserveIDNo.Text = reader.GetValue(2).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
