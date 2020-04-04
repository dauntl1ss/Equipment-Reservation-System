using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace UCLM_CCS_Equiment_Reservation_System.connection
{
    class connection
    {
        public static SqlConnection conn;
        private static String dbconnect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Documents\\SECONDYEAR\\APPSDEV\\UCLM CCS Equipment Reservation FINAL\\UCLM CCS Equiment Reservation System\\UCLM CCS Equiment Reservation System\\ReservationSystem.mdf;Integrated Security = True";
         
       
         public static void DB()
        {
            try
            {
                conn = new SqlConnection(dbconnect);
                conn.Open();
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            
         }

        
    }
}
