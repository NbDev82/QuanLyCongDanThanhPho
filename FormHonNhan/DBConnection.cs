using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace FormHonNhan
{
    internal class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.conn);
        public void Execute(string SQLstr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQLstr, conn);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Thành công");
                else
                    MessageBox.Show("Thất bại");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai" + ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable GetList(string str)
        {
            try
            {
                conn.Open();
                string sqlStr = string.Format("SELECT *FROM {0}", str);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtGiaoVien = new DataTable();
                adapter.Fill(dtGiaoVien);
                return dtGiaoVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("them that bai" + ex);
            }
            finally
            {
                conn.Close();

            }
            return null;
        }
    }
}
