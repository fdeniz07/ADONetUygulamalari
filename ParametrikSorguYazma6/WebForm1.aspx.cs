using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ParametrikSorguYazma6
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
                string Command = "upGetProductsByName"; // Stored Procedure adi buraya yazilir
                SqlCommand cmd = new SqlCommand(Command, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure; //Sistemin procedure anlamasi icin burada belirtiyoruz
                cmd.Parameters.AddWithValue("@Name",TextBox1.Text + "%");
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
}