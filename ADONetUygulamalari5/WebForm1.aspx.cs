using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ADONetUygulamalari5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                //SqlCommand cmd = new SqlCommand("Select ProductId,Name,UnitPrice,QtyAvailable from tblProduct", con);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"delete from tblProduct where ProductId=4";
                cmd.Connection = con; 
                con.Open();
                int Affected = cmd.ExecuteNonQuery();
                Response.Write("Total Rows Affected =" + Affected.ToString());

                //ExecuteReader nesnesi, T-SQL ifadesinden dönen değer birden fazla değere sahip ise kullanılabilir.
                //cmd.CommandText = @"Select ProductId,Name,UnitPrice,QtyAvailable from tblProduct";
                //GridView1.DataSource = cmd.ExecuteReader();
                //GridView1.DataBind();

                //ExecuteScalar nesnesi, Sorgudan dönen değer tek satir ise (scalar) kullanılabilir. 
                //cmd.CommandText = @"Select Count(ProductId) from tblProduct";
                //int TotalRows = (int)cmd.ExecuteScalar();
                //Response.Write("Total Rows =" + TotalRows.ToString());

                //ExecuteNonQuery nesnesi, Insert, Update ya da Delete operasyonları gerçekleştiğinde kullanılabilir.
                //cmd.CommandText = @"insert into tblProduct Values('XYZ',100,200)";
                //int TotolRowsAffected = cmd.ExecuteNonQuery();
                //Response.Write("Total Rows Inserted =" + TotolRowsAffected.ToString());
                //
                //cmd.CommandText = @"update tblProduct set QtyAvailable = 15 where ProductId=3";
                //int Affected = cmd.ExecuteNonQuery();
                //Response.Write("Total Rows Affected =" + Affected.ToString());
            }
        }
    }
}