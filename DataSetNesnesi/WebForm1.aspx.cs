using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataSetNesnesi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("upGetProduct", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                da.Fill(ds);

                ds.Tables[0].TableName = "Product";   // Daha iyi okunabilirlik icin burada tanimlaniyor
                ds.Tables[1].TableName = "Categories";

                GridView1.DataSource = ds.Tables["Product"]; //Index no da verilir ama okunabilir olmaz
                GridView1.DataBind();

                GridView2.DataSource = ds.Tables["Categories"]; //Table da verilir ama okunabilir olmaz
                GridView2.DataBind();

            }
        }
    }
}