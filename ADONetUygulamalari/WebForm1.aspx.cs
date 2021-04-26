using System;
using System.Data.SqlClient;


namespace ADONetUygulamalari
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=.;Database=ADONETDEMO;Integrated Security=SSPI;");
            SqlCommand cmd = new SqlCommand("select * from tblEmployee", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            con.Close();

            //Oracle Veritabanina baglanmak icin
            //OracleConnection con = new OracleConnection("Server=.;Database=ADONETDEMO;Integrated Security=SSPI;");
            //OracleCommand cmd = new OracleCommand("select * from tblEmployee", con);
            //con.Open();
            //OracleDataReader rdr = cmd.ExecuteReader();
            //GridView1.DataSource = rdr;
            //GridView1.DataBind();
            //con.Close();
        }
    }
}