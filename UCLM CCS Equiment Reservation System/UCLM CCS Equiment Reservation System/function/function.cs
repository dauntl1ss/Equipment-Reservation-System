using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace UCLM_CCS_Equiment_Reservation_System.function
{
    class function
    {
        public static SqlDataReader datareader = null;

        public static void datagridfill(string q, DataGridView dgv)
        {
              try
            {
                connection.connection.DB();
                DataTable dt = new DataTable();

                SqlDataAdapter data = null;
                SqlCommand command = new SqlCommand(q, connection.connection.conn);
                data = new SqlDataAdapter(command);
                data.Fill(dt);
                dgv.DataSource = dt;
                connection.connection.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
