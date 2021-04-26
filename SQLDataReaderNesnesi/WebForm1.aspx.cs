using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SQLDataReaderNesnesi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                #region I.Yol (Read Metodu Kullanarak)
                 
                SqlCommand cmd = new SqlCommand("select * from tblProduct", con);

                // SqlDataReader nesnesinin instance alinamaz. Bunun yerine SqlCommand nesnesinin ExecuteReader metodunu kullaniriz.
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("Id");
                    table.Columns.Add("Name");
                    table.Columns.Add("Price");
                    table.Columns.Add("DiscountedPrice");

                    while (rdr.Read())
                    {
                        DataRow dataRow = table.NewRow();
                        int OriginalPrice = Convert.ToInt32(rdr["UnitPrice"]);
                        double DiscountedPrice = OriginalPrice * 0.9;

                        dataRow["ID"] = rdr["Id"];
                        dataRow["Name"] = rdr["ProductName"];
                        dataRow["Price"] = OriginalPrice;
                        dataRow["DiscountedPrice"] = DiscountedPrice;

                        table.Rows.Add(dataRow);
                    }
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
                
                #endregion

                #region II.Yol (Read Metodu Kullanmadan SQL Komutu Kullanarak)

                SqlCommand cmd = new SqlCommand("select Id,ProductName,UnitPrice,(UnitPrice * 0.9) as DiscountedPrice from tblProduct", con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
                #endregion
            }
        }
    }
}
