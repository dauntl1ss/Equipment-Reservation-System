using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace UCLM_CCS_Equiment_Reservation_System
{
    public partial class printDetails : Form
    {
        private Reservation x;
        public printDetails(Reservation x)
        {
            this.x = x;
            InitializeComponent();
        }
        public printDetails()
        {
           
            InitializeComponent();
        }

        private void PrintDetails_Load(object sender, EventArgs e)
        {
            tansactionID.Text = x.txtTransaction.Text;
            fName.Text = x.txtReserveFName.Text;
            lName.Text = x.txtReserveLName.Text;
            idNo.Text = x.txtReserveIDNo.Text;
            equipment.Text = x.cmbReserveEquipment.Text;
            qty.Text = x.txtQty.Text;
            reserveDate.Text = x.dateReserveDate.Text;
        }
        public void PrintPanel(Panel pnl)
        {
            PrintDialog myPrintDialog = new PrintDialog();
            System.Drawing.Bitmap memoryImage = new System.Drawing.Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryImage, pnl.ClientRectangle);
            if (myPrintDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Printing.PrinterSettings values;
                values = myPrintDialog.PrinterSettings;
                myPrintDialog.Document = printDocument1;
                printDocument1.PrintController = new StandardPrintController();
                printDocument1.Print();
            }
            printDocument1.Dispose();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintPanel(pnlPrintDetails);
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintPanel(pnlPrintDetails);

        }
    }
}
