using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SQLDataAdapterNesnesi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                // 2.Yol
                // SqlDataAdapter da = new SqlDataAdapter(); --> parametresiz
                // da.SelectCommand = new SqlCommand("upGettblProductById", con); --> parametre buraya

                SqlDataAdapter da = new SqlDataAdapter("upGettblProductById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ProductId", TextBox1.Text);
                DataSet ds = new DataSet();
                da.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
}