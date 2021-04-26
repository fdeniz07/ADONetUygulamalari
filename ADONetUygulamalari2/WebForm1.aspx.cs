using System;
using System.Data.SqlClient;

namespace ADONetUygulamalari2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = "Data Source =.;Initial Catalog=ADONETDEMO; Integrated Security=true; ";
           //Using icerisinde baglanti islemleri
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from tblEmployee", con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }

            // Try -Catch blogu icinde baglantinin acilmasi
            //SqlConnection con = new SqlConnection(CS);
            //
            //try
            //{
            //    SqlCommand cmd = new SqlCommand("select * from tblEmployee", con);
            //    con.Open();
            //    GridView1.DataSource = cmd.ExecuteReader();
            //    GridView1.DataBind();
            //}
            //catch ()
            //{

            //}
            //finally
            //{
            //    con.Close();
            //}
        }
    }
}